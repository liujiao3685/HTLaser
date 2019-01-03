﻿using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Client.Controls;
using Opc.Ua.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcUaHelper
{

    /************************************************************************
     * 
     *    时间：  2017年9月21日 17:25:38
     *    创建人：胡少林
     *    说明：  一个操作OPC UA SERVER的客户端类，实现了一些基本的操作功能
     *            具体的调用示例，参照本解决方案的Opc Ua Test项目，里面测试
     *            了一些基本的操作，节点读写，浏览，历史数据读取，特性读取，
     *            方法调用等等
     * 
     ************************************************************************/


    /// <summary>
    /// a class that cennect to Opc Ua Server
    /// </summary>
    public class OpcUaClient
    {

        #region Constructors

        /// <summary>
        /// Constructors method
        /// </summary>
        public OpcUaClient()
        {

            var certificateValidator = new CertificateValidator();
            certificateValidator.CertificateValidation += (sender, eventArgs) =>
            {
                if (ServiceResult.IsGood(eventArgs.Error))
                    eventArgs.Accept = true;
                else if ((eventArgs.Error.StatusCode.Code == StatusCodes.BadCertificateUntrusted) && true)
                    eventArgs.Accept = true;
                else
                    throw new Exception(string.Format("Failed to validate certificate with error code {0}: {1}", eventArgs.Error.Code, eventArgs.Error.AdditionalInfo));
            };

            // Build the application configuration
            application = new ApplicationInstance
            {
                ApplicationType = ApplicationType.Client,
                ConfigSectionName = OpcUaName,
                ApplicationConfiguration = new ApplicationConfiguration
                {
                    ApplicationUri = "",
                    ApplicationName = OpcUaName,
                    ApplicationType = ApplicationType.Client,
                    CertificateValidator = certificateValidator,
                    ServerConfiguration = new ServerConfiguration
                    {
                        MaxSubscriptionCount = 100,
                        MaxMessageQueueSize = 100,
                        MaxNotificationQueueSize = 100,
                        MaxPublishRequestCount = 100
                    },
                    SecurityConfiguration = new SecurityConfiguration
                    {
                        AutoAcceptUntrustedCertificates = true,
                    },
                    TransportQuotas = new TransportQuotas
                    {
                        OperationTimeout = 600000,
                        MaxStringLength = 1048576,
                        MaxByteStringLength = 1048576,
                        MaxArrayLength = 65535,
                        MaxMessageSize = 4194304,
                        MaxBufferSize = 65535,
                        ChannelLifetime = 600000,
                        SecurityTokenLifetime = 3600000
                    },
                    ClientConfiguration = new ClientConfiguration
                    {
                        DefaultSessionTimeout = 60000,
                        MinSubscriptionLifetime = 10000
                    },
                    DisableHiResClock = true
                }
            };

            // Assign a application certificate (when specified)
            // if (ApplicationCertificate != null)
            //    application.ApplicationConfiguration.SecurityConfiguration.ApplicationCertificate = new CertificateIdentifier(_options.ApplicationCertificate);


            m_configuration = application.ApplicationConfiguration;

        }


        #endregion

        #region Connect And Disconnect
        /// <summary>
        /// connect to server
        /// </summary>
        /// <param name="serverUrl"></param>
        public void ConnectServer(string serverUrl)
        {
            m_session = Connect(serverUrl);
        }

        /// <summary>
        /// Creates a new session.
        /// </summary>
        /// <returns>The new session object.</returns>
        private Session Connect(string serverUrl)
        {
            // disconnect from existing session.
            Disconnect();


            if (m_configuration == null)
            {
                throw new ArgumentNullException("m_configuration");
            }

            // select the best endpoint.
            EndpointDescription endpointDescription = ClientUtils.SelectEndpoint(serverUrl, UseSecurity);

            EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create(m_configuration);
            ConfiguredEndpoint endpoint = new ConfiguredEndpoint(null, endpointDescription, endpointConfiguration);


            // create the session with server
            m_session = Session.Create(
                m_configuration,
                endpoint,
                false,
                false,
                (String.IsNullOrEmpty(OpcUaName)) ? m_configuration.ApplicationName : OpcUaName,
                60000,
                UserIdentity,
                new string[] { });

            // set up keep alive callback.
            m_session.KeepAlive += new KeepAliveEventHandler(Session_KeepAlive);

            // update the client status
            m_IsConnected = true;

            // raise an event.
            DoConnectComplete(null);

            // return the new session.
            return m_session;
        }

        /// <summary>
        /// Disconnects from the server.
        /// </summary>
        public void Disconnect()
        {
            UpdateStatus(false, DateTime.UtcNow, "Disconnected");

            // stop any reconnect operation.
            if (m_reconnectHandler != null)
            {
                m_reconnectHandler.Dispose();
                m_reconnectHandler = null;
            }

            // disconnect any existing session.
            if (m_session != null)
            {
                m_session.Close(10000);
                m_session = null;
            }

            // update the client status
            m_IsConnected = false;

            // raise an event.
            DoConnectComplete(null);
        }

        #endregion

        #region Event Handlers
        /// <summary>
        /// Report the client status
        /// </summary>
        /// <param name="error">Whether the status represents an error.</param>
        /// <param name="time">The time associated with the status.</param>
        /// <param name="status">The status message.</param>
        /// <param name="args">Arguments used to format the status message.</param>
        private void UpdateStatus(bool error, DateTime time, string status, params object[] args)
        {
            m_OpcStatusChange?.Invoke(this, new OpcUaStatusEventArgs()
            {
                Error = error,
                Time = time.ToLocalTime(),
                Text = String.Format(status, args),
            });
        }

        /// <summary>
        /// Handles a keep alive event from a session.
        /// </summary>
        private void Session_KeepAlive(Session session, KeepAliveEventArgs e)
        {
            try
            {
                // check for events from discarded sessions.
                if (!ReferenceEquals(session, m_session))
                {
                    return;
                }

                // start reconnect sequence on communication error.
                if (ServiceResult.IsBad(e.Status))
                {
                    if (m_reconnectPeriod <= 0)
                    {
                        UpdateStatus(true, e.CurrentTime, "Communication Error ({0})", e.Status);
                        return;
                    }

                    UpdateStatus(true, e.CurrentTime, "Reconnecting in {0}s", m_reconnectPeriod);

                    if (m_reconnectHandler == null)
                    {
                        m_ReconnectStarting?.Invoke(this, e);

                        m_reconnectHandler = new SessionReconnectHandler();
                        m_reconnectHandler.BeginReconnect(m_session, m_reconnectPeriod * 1000, Server_ReconnectComplete);
                    }

                    return;
                }

                // update status.
                UpdateStatus(false, e.CurrentTime, "Connected [{0}]", session.Endpoint.EndpointUrl);

                // raise any additional notifications.
                m_KeepAliveComplete?.Invoke(this, e);
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(OpcUaName, exception);
            }
        }

        /// <summary>
        /// Handles a reconnect event complete from the reconnect handler.
        /// </summary>
        private void Server_ReconnectComplete(object sender, EventArgs e)
        {
            try
            {
                // ignore callbacks from discarded objects.
                if (!ReferenceEquals(sender, m_reconnectHandler))
                {
                    return;
                }

                m_session = m_reconnectHandler.Session;
                m_reconnectHandler.Dispose();
                m_reconnectHandler = null;

                // raise any additional notifications.
                m_ReconnectComplete?.Invoke(this, e);
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(OpcUaName, exception);
            }
        }




        #endregion

        #region LogOut Setting

        /// <summary>
        /// 设置OPC客户端的日志输出
        /// </summary>
        /// <param name="filePath">完整的文件路径</param>
        /// <param name="deleteExisting">是否删除原文件</param>
        public void SetLogPathName(string filePath, bool deleteExisting)
        {
            Utils.SetTraceLog(filePath, deleteExisting);
            Utils.SetTraceMask(515);
        }

        #endregion

        #region Public Members

        /// <summary>
        /// a name of application name show on server
        /// </summary>
        public string OpcUaName { get; set; } = "Opc Ua Helper";

        /// <summary>
        /// Whether to use security when connecting.
        /// </summary>
        public bool UseSecurity
        {
            get { return m_useSecurity; }
            set { m_useSecurity = value; }
        }

        /// <summary>
        /// The user identity to use when creating the session.
        /// </summary>
        public IUserIdentity UserIdentity { get; set; }



        /// <summary>
        /// The currently active session. 
        /// </summary>
        public Session Session
        {
            get { return m_session; }
        }

        /// <summary>
        /// Indicate the connect status
        /// </summary>
        public bool Connected
        {
            get { return m_IsConnected; }
        }

        /// <summary>
        /// The number of seconds between reconnect attempts (0 means reconnect is disabled).
        /// </summary>
        [DefaultValue(10)]
        public int ReconnectPeriod
        {
            get { return m_reconnectPeriod; }
            set { m_reconnectPeriod = value; }
        }

        /// <summary>
        /// Raised when a good keep alive from the server arrives.
        /// </summary>
        public event EventHandler KeepAliveComplete
        {
            add { m_KeepAliveComplete += value; }
            remove { m_KeepAliveComplete -= value; }
        }

        /// <summary>
        /// Raised when a reconnect operation starts.
        /// </summary>
        public event EventHandler ReconnectStarting
        {
            add { m_ReconnectStarting += value; }
            remove { m_ReconnectStarting -= value; }
        }


        /// <summary>
        /// Raised when a reconnect operation completes.
        /// </summary>
        public event EventHandler ReconnectComplete
        {
            add { m_ReconnectComplete += value; }
            remove { m_ReconnectComplete -= value; }
        }

        /// <summary>
        /// Raised after successfully connecting to or disconnecing from a server.
        /// </summary>
        public event EventHandler ConnectComplete
        {
            add { m_ConnectComplete += value; }
            remove { m_ConnectComplete -= value; }
        }

        /// <summary>
        /// Raised after the client status change
        /// </summary>
        public event EventHandler<OpcUaStatusEventArgs> OpcStatusChange
        {
            add { m_OpcStatusChange += value; }
            remove { m_OpcStatusChange -= value; }
        }

        /// <summary>
        /// 配置信息
        /// </summary>
        public ApplicationConfiguration AppConfig
        {
            get
            {
                return m_configuration;
            }
        }

        #endregion

        #region Node Write/Read Support


        /// <summary>
        /// Read a value node from server
        /// </summary>
        /// <param name="nodeId">node id</param>
        /// <returns></returns>
        public DataValue ReadNode(NodeId nodeId)
        {

            ReadValueId nodeToRead = new ReadValueId()
            {
                NodeId = nodeId,
                AttributeId = Attributes.Value
            };
            ReadValueIdCollection nodesToRead = new ReadValueIdCollection
            {
                nodeToRead
            };

            // read the current value
            m_session.Read(
                null,
                0,
                TimestampsToReturn.Neither,
                nodesToRead,
                out DataValueCollection results,
                out DiagnosticInfoCollection diagnosticInfos);

            ClientBase.ValidateResponse(results, nodesToRead);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToRead);

            return results[0];
        }

        /// <summary>
        /// Read a value node from server
        /// </summary>
        /// <typeparam name="T">type of value</typeparam>
        /// <param name="tag">node id</param>
        /// <returns></returns>
        public T ReadNode<T>(string tag)
        {
            ReadValueId nodeToRead = new ReadValueId()
            {
                NodeId = new NodeId(tag),
                AttributeId = Attributes.Value
            };
            ReadValueIdCollection nodesToRead = new ReadValueIdCollection
            {
                nodeToRead
            };

            // read the current value
            m_session.Read(
                null,
                0,
                TimestampsToReturn.Neither,
                nodesToRead,
                out DataValueCollection results,
                out DiagnosticInfoCollection diagnosticInfos);

            ClientBase.ValidateResponse(results, nodesToRead);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToRead);

            return (T)results[0].Value;
        }


        /// <summary>
        /// Read a tag asynchronously
        /// </summary>
        /// <typeparam name="T">The type of tag to read</typeparam>
        /// <param name="tag">The fully-qualified identifier of the tag. You can specify a subfolder by using a comma delimited name.
        /// E.g: the tag `foo.bar` reads the tag `bar` on the folder `foo`</param>
        /// <returns>The value retrieved from the OPC</returns>
        public Task<T> ReadNodeAsync<T>(string tag)
        {
            ReadValueIdCollection nodesToRead = new ReadValueIdCollection
            {
                new ReadValueId()
                {
                    NodeId = new NodeId(tag),
                    AttributeId = Attributes.Value
                }
            };

            // Wrap the ReadAsync logic in a TaskCompletionSource, so we can use C# async/await syntax to call it:
            var taskCompletionSource = new TaskCompletionSource<T>();
            m_session.BeginRead(
                requestHeader: null,
                maxAge: 0,
                timestampsToReturn: TimestampsToReturn.Neither,
                nodesToRead: nodesToRead,
                callback: ar =>
                {
                    DataValueCollection results;
                    DiagnosticInfoCollection diag;
                    var response = m_session.EndRead(
                  result: ar,
                  results: out results,
                  diagnosticInfos: out diag);

                    try
                    {
                        CheckReturnValue(response.ServiceResult);
                        CheckReturnValue(results[0].StatusCode);
                        var val = results[0];
                        taskCompletionSource.TrySetResult((T)val.Value);
                    }
                    catch (Exception ex)
                    {
                        taskCompletionSource.TrySetException(ex);
                    }
                },
                asyncState: null);

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// read several value nodes from server
        /// </summary>
        /// <param name="Tags">all Tags</param>
        /// <returns></returns>
        public IEnumerable<DataValue> ReadNodes(string[] Tags)
        {
            ReadValueIdCollection nodesToRead = new ReadValueIdCollection();
            for (int i = 0; i < Tags.Length; i++)
            {
                nodesToRead.Add(new ReadValueId()
                {
                    NodeId = new NodeId(Tags[i]),
                    AttributeId = Attributes.Value
                });
            }

            // 读取当前的值
            m_session.Read(
                null,
                0,
                TimestampsToReturn.Neither,
                nodesToRead,
                out DataValueCollection results,
                out DiagnosticInfoCollection diagnosticInfos);

            ClientBase.ValidateResponse(results, nodesToRead);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToRead);

            foreach (var v in results)
            {
                yield return v;
            }
        }

        /// <summary>
        /// write a note to server(you should use try catch)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tag"></param>
        /// <param name="value"></param>
        /// <returns>if success True,otherwise False</returns>
        public bool WriteNode<T>(string tag, T value)
        {
            WriteValue valueToWrite = new WriteValue()
            {
                NodeId = new NodeId(tag),
                AttributeId = Attributes.Value
            };
            valueToWrite.Value.Value = value;
            valueToWrite.Value.StatusCode = StatusCodes.Good;
            valueToWrite.Value.ServerTimestamp = DateTime.MinValue;
            valueToWrite.Value.SourceTimestamp = DateTime.MinValue;

            WriteValueCollection valuesToWrite = new WriteValueCollection
            {
                valueToWrite
            };

            // 写入当前的值
            m_session.Write(
                null,
                valuesToWrite,
                out StatusCodeCollection results,
                out DiagnosticInfoCollection diagnosticInfos);

            ClientBase.ValidateResponse(results, valuesToWrite);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, valuesToWrite);

            return !StatusCode.IsBad(results[0]);
        }


        /// <summary>
        /// Write a value on the specified opc tag asynchronously
        /// </summary>
        /// <typeparam name="T">The type of tag to write on</typeparam>
        /// <param name="tag">The fully-qualified identifier of the tag. You can specify a subfolder by using a comma delimited name.
        /// E.g: the tag `foo.bar` writes on the tag `bar` on the folder `foo`</param>
        /// <param name="value">The value for the item to write</param>
        public Task<bool> WriteNodeAsync<T>(string tag, T value)
        {
            WriteValue valueToWrite = new WriteValue()
            {
                NodeId = new NodeId(tag),
                AttributeId = Attributes.Value,
            };
            valueToWrite.Value.Value = value;
            valueToWrite.Value.StatusCode = StatusCodes.Good;
            valueToWrite.Value.ServerTimestamp = DateTime.MinValue;
            valueToWrite.Value.SourceTimestamp = DateTime.MinValue;
            WriteValueCollection valuesToWrite = new WriteValueCollection
            {
                valueToWrite
            };

            // Wrap the WriteAsync logic in a TaskCompletionSource, so we can use C# async/await syntax to call it:
            var taskCompletionSource = new TaskCompletionSource<bool>();
            m_session.BeginWrite(
                requestHeader: null,
                nodesToWrite: valuesToWrite,
                callback: ar =>
                {
                    var response = m_session.EndWrite(
                      result: ar,
                      results: out StatusCodeCollection results,
                      diagnosticInfos: out DiagnosticInfoCollection diag);

                    try
                    {
                        ClientBase.ValidateResponse(results, valuesToWrite);
                        ClientBase.ValidateDiagnosticInfos(diag, valuesToWrite);
                        taskCompletionSource.SetResult(StatusCode.IsGood(results[0]));
                    }
                    catch (Exception ex)
                    {
                        taskCompletionSource.TrySetException(ex);
                    }
                },
                asyncState: null);
            return taskCompletionSource.Task;
        }


        /// <summary>
        /// 所有的节点都写入成功，返回<c>True</c>，否则返回<c>False</c>
        /// </summary>
        /// <param name="tags">节点名称数组</param>
        /// <param name="values">节点的值数据</param>
        /// <returns></returns>
        public bool WriteNodes(string[] tags, object[] values)
        {
            WriteValueCollection valuesToWrite = new WriteValueCollection();

            for (int i = 0; i < tags.Length; i++)
            {
                if (i < values.Length)
                {
                    WriteValue valueToWrite = new WriteValue()
                    {
                        NodeId = new NodeId(tags[i]),
                        AttributeId = Attributes.Value
                    };
                    valueToWrite.Value.Value = values[i];
                    valueToWrite.Value.StatusCode = StatusCodes.Good;
                    valueToWrite.Value.ServerTimestamp = DateTime.MinValue;
                    valueToWrite.Value.SourceTimestamp = DateTime.MinValue;
                    valuesToWrite.Add(valueToWrite);
                }
            }

            // 写入当前的值

            m_session.Write(
                null,
                valuesToWrite,
                out StatusCodeCollection results,
                out DiagnosticInfoCollection diagnosticInfos);

            ClientBase.ValidateResponse(results, valuesToWrite);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, valuesToWrite);

            bool result = true;
            foreach (var r in results)
            {
                if (StatusCode.IsBad(r))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }


        #endregion

        #region DeleteNode Support

        /// <summary>
        /// 删除一个节点的操作，除非服务器配置允许，否则引发异常，成功返回<c>True</c>，否则返回<c>False</c>
        /// </summary>
        /// <param name="tag">节点文本描述</param>
        /// <returns></returns>
        public bool DeleteExsistNode(string tag)
        {
            DeleteNodesItemCollection waitDelete = new DeleteNodesItemCollection();

            DeleteNodesItem nodesItem = new DeleteNodesItem()
            {
                NodeId = new NodeId(tag),
            };

            m_session.DeleteNodes(
                null,
                waitDelete,
                out StatusCodeCollection results,
                out DiagnosticInfoCollection diagnosticInfos);

            ClientBase.ValidateResponse(results, waitDelete);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, waitDelete);

            return !StatusCode.IsBad(results[0]);
        }
        #endregion

        #region Test Function

        /// <summary>
        /// 新增一个节点数据
        /// </summary>
        /// <param name="parent">父节点tag名称</param>
        [Obsolete("还未经过测试，无法使用")]
        public void AddNewNode(NodeId parent)
        {
            // Create a Variable node.
            AddNodesItem node2 = new AddNodesItem();
            node2.ParentNodeId = new NodeId(parent);
            node2.ReferenceTypeId = ReferenceTypes.HasComponent;
            node2.RequestedNewNodeId = null;
            node2.BrowseName = new QualifiedName("DataVariable1");
            node2.NodeClass = NodeClass.Variable;
            node2.NodeAttributes = null;
            node2.TypeDefinition = VariableTypeIds.BaseDataVariableType;

            //specify node attributes.
            VariableAttributes node2Attribtues = new VariableAttributes();
            node2Attribtues.DisplayName = "DataVariable1";
            node2Attribtues.Description = "DataVariable1 Description";
            node2Attribtues.Value = new Variant(123);
            node2Attribtues.DataType = (uint)BuiltInType.Int32;
            node2Attribtues.ValueRank = ValueRanks.Scalar;
            node2Attribtues.ArrayDimensions = new UInt32Collection();
            node2Attribtues.AccessLevel = AccessLevels.CurrentReadOrWrite;
            node2Attribtues.UserAccessLevel = AccessLevels.CurrentReadOrWrite;
            node2Attribtues.MinimumSamplingInterval = 0;
            node2Attribtues.Historizing = false;
            node2Attribtues.WriteMask = (uint)AttributeWriteMask.None;
            node2Attribtues.UserWriteMask = (uint)AttributeWriteMask.None;
            node2Attribtues.SpecifiedAttributes = (uint)NodeAttributesMask.All;

            node2.NodeAttributes = new ExtensionObject(node2Attribtues);



            AddNodesItemCollection nodesToAdd = new AddNodesItemCollection
            {
                node2
            };

            m_session.AddNodes(
                null,
                nodesToAdd,
                out AddNodesResultCollection results,
                out DiagnosticInfoCollection diagnosticInfos);

            ClientBase.ValidateResponse(results, nodesToAdd);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToAdd);

        }

        #endregion

        #region Monitor Support

        /// <summary>
        /// Monitor a value from server
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tag"></param>
        /// <param name="callback"></param>
        public void MonitorValue<T>(string tag, Action<T, Action> callback)
        {
            var node = new NodeId(tag);

            var sub = new Subscription
            {
                PublishingInterval = 0,
                PublishingEnabled = true,
                LifetimeCount = 0,
                KeepAliveCount = 0,
                DisplayName = tag,
                Priority = byte.MaxValue
            };


            var item = new MonitoredItem
            {
                StartNodeId = node,
                AttributeId = Attributes.Value,
                DisplayName = tag,
                SamplingInterval = 100
            };
            sub.AddItem(item);
            m_session.AddSubscription(sub);
            sub.Create();
            sub.ApplyChanges();

            item.Notification += (monitoredItem, args) =>
            {
                var notification = (MonitoredItemNotification)args.NotificationValue;
                if (notification == null) return;//如果为空就退出
                var t = notification.Value.WrappedValue.Value;
                Action unsubscribe = () =>
                {
                    sub.RemoveItems(sub.MonitoredItems);
                    sub.Delete(true);
                    m_session.RemoveSubscription(sub);
                    sub.Dispose();
                };
                callback?.Invoke((T)t, unsubscribe);
            };

        }

        #endregion

        #region ReadHistory Support
        /// <summary>
        /// read History data
        /// </summary>
        /// <param name="tag">节点的索引</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="count">读取的个数</param>
        /// <param name="containBound">是否包含边界</param>
        /// <returns></returns>
        public IEnumerable<DataValue> ReadHistoryRawDataValues(string tag, DateTime start, DateTime end, uint count = 1, bool containBound = false)
        {
            HistoryReadValueId m_nodeToContinue = new HistoryReadValueId()
            {
                NodeId = new NodeId(tag),
            };

            ReadRawModifiedDetails m_details = new ReadRawModifiedDetails
            {
                StartTime = start,
                EndTime = end,
                NumValuesPerNode = count,
                IsReadModified = false,
                ReturnBounds = containBound
            };

            HistoryReadValueIdCollection nodesToRead = new HistoryReadValueIdCollection();
            nodesToRead.Add(m_nodeToContinue);


            m_session.HistoryRead(
                null,
                new ExtensionObject(m_details),
                TimestampsToReturn.Both,
                false,
                nodesToRead,
                out HistoryReadResultCollection results,
                out DiagnosticInfoCollection diagnosticInfos);

            ClientBase.ValidateResponse(results, nodesToRead);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToRead);

            if (StatusCode.IsBad(results[0].StatusCode))
            {
                throw new ServiceResultException(results[0].StatusCode);
            }

            HistoryData values = ExtensionObject.ToEncodeable(results[0].HistoryData) as HistoryData;
            foreach (var value in values.DataValues)
            {
                yield return value;
            }
        }

        /// <summary>
        /// 读取一连串的历史数据，并将其转化成指定的类型
        /// </summary>
        /// <param name="url">节点的索引</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="count">读取的个数</param>
        /// <param name="containBound">是否包含边界</param>
        /// <returns></returns>
        public IEnumerable<T> ReadHistoryRawDataValues<T>(string url, DateTime start, DateTime end, uint count = 1, bool containBound = false)
        {
            HistoryReadValueId m_nodeToContinue = new HistoryReadValueId()
            {
                NodeId = new NodeId(url),
            };

            ReadRawModifiedDetails m_details = new ReadRawModifiedDetails
            {
                StartTime = start.ToUniversalTime(),
                EndTime = end.ToUniversalTime(),
                NumValuesPerNode = count,
                IsReadModified = false,
                ReturnBounds = containBound
            };

            HistoryReadValueIdCollection nodesToRead = new HistoryReadValueIdCollection();
            nodesToRead.Add(m_nodeToContinue);


            m_session.HistoryRead(
                null,
                new ExtensionObject(m_details),
                TimestampsToReturn.Both,
                false,
                nodesToRead,
                out HistoryReadResultCollection results,
                out DiagnosticInfoCollection diagnosticInfos);

            ClientBase.ValidateResponse(results, nodesToRead);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToRead);

            if (StatusCode.IsBad(results[0].StatusCode))
            {
                throw new ServiceResultException(results[0].StatusCode);
            }

            HistoryData values = ExtensionObject.ToEncodeable(results[0].HistoryData) as HistoryData;
            foreach (var value in values.DataValues)
            {
                yield return (T)value.Value;
            }
        }

        #endregion

        #region BrowseNode Support

        /// <summary>
        /// 浏览一个节点的引用
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public ReferenceDescription[] BrowseNodeReference(string tag)
        {
            NodeId sourceId = new NodeId(tag);

            // 该节点可以读取到方法
            BrowseDescription nodeToBrowse1 = new BrowseDescription();

            nodeToBrowse1.NodeId = sourceId;
            nodeToBrowse1.BrowseDirection = BrowseDirection.Forward;
            nodeToBrowse1.ReferenceTypeId = ReferenceTypeIds.Aggregates;
            nodeToBrowse1.IncludeSubtypes = true;
            nodeToBrowse1.NodeClassMask = (uint)(NodeClass.Object | NodeClass.Variable | NodeClass.Method);
            nodeToBrowse1.ResultMask = (uint)BrowseResultMask.All;

            // 该节点无论怎么样都读取不到方法
            // find all nodes organized by the node.
            BrowseDescription nodeToBrowse2 = new BrowseDescription();

            nodeToBrowse2.NodeId = sourceId;
            nodeToBrowse2.BrowseDirection = BrowseDirection.Forward;
            nodeToBrowse2.ReferenceTypeId = ReferenceTypeIds.Organizes;
            nodeToBrowse2.IncludeSubtypes = true;
            nodeToBrowse2.NodeClassMask = (uint)(NodeClass.Object | NodeClass.Variable);
            nodeToBrowse2.ResultMask = (uint)BrowseResultMask.All;

            BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
            nodesToBrowse.Add(nodeToBrowse1);
            nodesToBrowse.Add(nodeToBrowse2);

            // fetch references from the server.
            ReferenceDescriptionCollection references = FormUtils.Browse(m_session, nodesToBrowse, false);

            return references.ToArray();
        }
        #endregion

        #region Read Attributes Support
        /// <summary>
        /// 读取一个节点的所有属性
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public OpcNodeAttribute[] ReadNoteAttributes(string tag)
        {
            NodeId sourceId = new NodeId(tag);
            ReadValueIdCollection nodesToRead = new ReadValueIdCollection();

            // attempt to read all possible attributes.
            // 尝试着去读取所有可能的特性
            for (uint ii = Attributes.NodeClass; ii <= Attributes.UserExecutable; ii++)
            {
                ReadValueId nodeToRead = new ReadValueId();
                nodeToRead.NodeId = sourceId;
                nodeToRead.AttributeId = ii;
                nodesToRead.Add(nodeToRead);
            }

            int startOfProperties = nodesToRead.Count;

            // find all of the pror of the node.
            BrowseDescription nodeToBrowse1 = new BrowseDescription();

            nodeToBrowse1.NodeId = sourceId;
            nodeToBrowse1.BrowseDirection = BrowseDirection.Forward;
            nodeToBrowse1.ReferenceTypeId = ReferenceTypeIds.HasProperty;
            nodeToBrowse1.IncludeSubtypes = true;
            nodeToBrowse1.NodeClassMask = 0;
            nodeToBrowse1.ResultMask = (uint)BrowseResultMask.All;

            BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
            nodesToBrowse.Add(nodeToBrowse1);

            // fetch property references from the server.
            ReferenceDescriptionCollection references = FormUtils.Browse(m_session, nodesToBrowse, false);

            if (references == null)
            {
                return new OpcNodeAttribute[0];
            }

            for (int ii = 0; ii < references.Count; ii++)
            {
                // ignore external references.
                if (references[ii].NodeId.IsAbsolute)
                {
                    continue;
                }

                ReadValueId nodeToRead = new ReadValueId();
                nodeToRead.NodeId = (NodeId)references[ii].NodeId;
                nodeToRead.AttributeId = Attributes.Value;
                nodesToRead.Add(nodeToRead);
            }

            // read all values.
            DataValueCollection results = null;
            DiagnosticInfoCollection diagnosticInfos = null;

            m_session.Read(
                null,
                0,
                TimestampsToReturn.Neither,
                nodesToRead,
                out results,
                out diagnosticInfos);

            ClientBase.ValidateResponse(results, nodesToRead);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToRead);

            // process results.


            List<OpcNodeAttribute> nodeAttribute = new List<OpcNodeAttribute>();
            for (int ii = 0; ii < results.Count; ii++)
            {
                OpcNodeAttribute item = new OpcNodeAttribute();

                // process attribute value.
                if (ii < startOfProperties)
                {
                    // ignore attributes which are invalid for the node.
                    if (results[ii].StatusCode == StatusCodes.BadAttributeIdInvalid)
                    {
                        continue;
                    }

                    // get the name of the attribute.
                    item.Name = Attributes.GetBrowseName(nodesToRead[ii].AttributeId);

                    // display any unexpected error.
                    if (StatusCode.IsBad(results[ii].StatusCode))
                    {
                        item.Type = Utils.Format("{0}", Attributes.GetDataTypeId(nodesToRead[ii].AttributeId));
                        item.Value = Utils.Format("{0}", results[ii].StatusCode);
                    }

                    // display the value.
                    else
                    {
                        TypeInfo typeInfo = TypeInfo.Construct(results[ii].Value);

                        item.Type = typeInfo.BuiltInType.ToString();

                        if (typeInfo.ValueRank >= ValueRanks.OneOrMoreDimensions)
                        {
                            item.Type += "[]";
                        }

                        item.Value = results[ii].Value;//Utils.Format("{0}", results[ii].Value);
                    }
                }

                // process property value.
                else
                {
                    // ignore properties which are invalid for the node.
                    if (results[ii].StatusCode == StatusCodes.BadNodeIdUnknown)
                    {
                        continue;
                    }

                    // get the name of the property.
                    item.Name = Utils.Format("{0}", references[ii - startOfProperties]);

                    // display any unexpected error.
                    if (StatusCode.IsBad(results[ii].StatusCode))
                    {
                        item.Type = String.Empty;
                        item.Value = Utils.Format("{0}", results[ii].StatusCode);
                    }

                    // display the value.
                    else
                    {
                        TypeInfo typeInfo = TypeInfo.Construct(results[ii].Value);

                        item.Type = typeInfo.BuiltInType.ToString();

                        if (typeInfo.ValueRank >= ValueRanks.OneOrMoreDimensions)
                        {
                            item.Type += "[]";
                        }

                        item.Value = results[ii].Value; //Utils.Format("{0}", results[ii].Value);
                    }
                }

                nodeAttribute.Add(item);
            }

            return nodeAttribute.ToArray();
        }

        /// <summary>
        /// 读取一个节点的所有属性
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public DataValue[] ReadNoteDataValueAttributes(string tag)
        {
            NodeId sourceId = new NodeId(tag);
            ReadValueIdCollection nodesToRead = new ReadValueIdCollection();

            // attempt to read all possible attributes.
            // 尝试着去读取所有可能的特性
            for (uint ii = Attributes.NodeId; ii <= Attributes.UserExecutable; ii++)
            {
                ReadValueId nodeToRead = new ReadValueId();
                nodeToRead.NodeId = sourceId;
                nodeToRead.AttributeId = ii;
                nodesToRead.Add(nodeToRead);
            }

            int startOfProperties = nodesToRead.Count;

            // find all of the pror of the node.
            BrowseDescription nodeToBrowse1 = new BrowseDescription();

            nodeToBrowse1.NodeId = sourceId;
            nodeToBrowse1.BrowseDirection = BrowseDirection.Forward;
            nodeToBrowse1.ReferenceTypeId = ReferenceTypeIds.HasProperty;
            nodeToBrowse1.IncludeSubtypes = true;
            nodeToBrowse1.NodeClassMask = 0;
            nodeToBrowse1.ResultMask = (uint)BrowseResultMask.All;

            BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
            nodesToBrowse.Add(nodeToBrowse1);

            // fetch property references from the server.
            ReferenceDescriptionCollection references = FormUtils.Browse(m_session, nodesToBrowse, false);

            if (references == null)
            {
                return new DataValue[0];
            }

            for (int ii = 0; ii < references.Count; ii++)
            {
                // ignore external references.
                if (references[ii].NodeId.IsAbsolute)
                {
                    continue;
                }

                ReadValueId nodeToRead = new ReadValueId();
                nodeToRead.NodeId = (NodeId)references[ii].NodeId;
                nodeToRead.AttributeId = Attributes.Value;
                nodesToRead.Add(nodeToRead);
            }

            // read all values.
            DataValueCollection results = null;
            DiagnosticInfoCollection diagnosticInfos = null;

            m_session.Read(
                null,
                0,
                TimestampsToReturn.Neither,
                nodesToRead,
                out results,
                out diagnosticInfos);

            ClientBase.ValidateResponse(results, nodesToRead);
            ClientBase.ValidateDiagnosticInfos(diagnosticInfos, nodesToRead);

            return results.ToArray();
        }
        #endregion

        #region Method Call Support
        /// <summary>
        /// call a server method
        /// </summary>
        /// <param name="tagParent"></param>
        /// <param name="tag"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public object[] CallMethodByNodeId(string tagParent, string tag, params object[] args)
        {
            if (m_session == null)
            {
                return null;
            }

            IList<object> outputArguments = m_session.Call(
                new NodeId(tagParent),
                new NodeId(tag),
                args);

            return outputArguments.ToArray();
        }

        #endregion

        #region Private Methods


        /// <summary>
        /// Raises the connect complete event on the main GUI thread.
        /// </summary>
        private void DoConnectComplete(object state)
        {
            m_ConnectComplete?.Invoke(this, null);
        }

        private void CheckReturnValue(StatusCode status)
        {
            if (!StatusCode.IsGood(status))
                throw new Exception(string.Format("Invalid response from the server. (Response Status: {0})", status));
        }

        #endregion

        #region Private Fields
        private ApplicationInstance application;
        private ApplicationConfiguration m_configuration;
        private Session m_session;
        private bool m_IsConnected;                       //是否已经连接过
        private int m_reconnectPeriod = 10;               // 重连状态
        private bool m_useSecurity;

        private SessionReconnectHandler m_reconnectHandler;
        private EventHandler m_ReconnectComplete;
        private EventHandler m_ReconnectStarting;
        private EventHandler m_KeepAliveComplete;
        private EventHandler m_ConnectComplete;
        private EventHandler<OpcUaStatusEventArgs> m_OpcStatusChange;
        #endregion
    }
}
