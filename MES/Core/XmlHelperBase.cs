using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace MES.Core
{
    public class XmlHelperBase
    {
        /// <summary>
        /// 文件夹保存路径
        /// </summary>
        public string XmlDirPath { set; get; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { set; get; }

        /// <summary>
        /// 文件后缀名
        /// </summary>
        public string XmlSuf { set; get; }

        /// <summary>
        /// 模板文件地址
        /// </summary>
        public string XmlFilePath = string.Empty;

        public string NodesName = "Nodes";

        public string NodeName = "Node";

        public XmlHelperBase()
        {
            XmlDirPath = Application.StartupPath;
            XmlSuf = ".xml";
            XmlFilePath = XmlDirPath + @"\" + FileName + XmlSuf;
        }

        /// <summary>
        /// 判断模板文件夹是否存在，不存在则创建
        /// </summary>
        /// <returns></returns>
        public bool CreateXmlDir()
        {
            if (Directory.Exists(XmlDirPath)) return false;

            Directory.CreateDirectory(XmlDirPath);

            return true;
        }

        public bool CreateXmlFile()
        {
            if (!String.IsNullOrEmpty(FileName)) XmlFilePath = XmlDirPath + @"\" + FileName + XmlSuf;

            if (File.Exists(XmlFilePath)) return false;

            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration xmlDec = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);

            xmlDoc.AppendChild(xmlDec);

            XmlElement root = xmlDoc.CreateElement(NodesName);
            root.SetAttribute(NodeName, FileName);
            xmlDoc.AppendChild(root);
            xmlDoc.Save(XmlFilePath);
            xmlDoc.Clone();
            xmlDoc = null;

            return true;
        }

        /// <summary>
        /// 加载配置文件
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> LoadFile()
        {
            Dictionary<string, string> dicModule = new Dictionary<string, string>();

            if (!File.Exists(XmlFilePath)) CreateXmlFile();

            try
            {
                if (!String.IsNullOrEmpty(FileName)) XmlFilePath = XmlDirPath + @"\" + FileName + XmlSuf;

                XmlDocument doc = new XmlDocument();
                doc.Load(XmlFilePath);
                XmlNode root = doc.SelectSingleNode(NodesName);
                FileName = root.Attributes[NodeName].Value;
                XmlNodeList list = root.ChildNodes;

                for (int i = 0; i < list.Count; i++)
                {
                    dicModule.Add(Convert.ToString(list[i].Attributes["key"].Value),
                        Convert.ToString(list[i].Attributes["value"].Value));
                }
            }
            catch (Exception ex)
            {
                Program.LogNet.WriteError("加载配置文件异常", ex.Message);
                return null;
            }

            return dicModule;
        }

        /// <summary>
        /// 保存模板文件
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public bool SaveFile(Dictionary<string, string> dic)
        {
            if (!File.Exists(XmlFilePath)) CreateXmlFile();

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(XmlFilePath);
                XmlNode root = doc.SelectSingleNode(NodesName);
                root.Attributes[NodeName].Value = FileName;
                if (root != null)
                {
                    XmlNodeList list = root.ChildNodes;
                    foreach (var item in dic)
                    {
                        bool isExitKey = false;
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (Convert.ToString(list[i].Attributes["key"].Value) == item.Key)
                            {
                                list[i].Attributes["value"].Value = Convert.ToString(item.Value);
                                isExitKey = true;
                            }
                        }
                        if (!isExitKey)
                        {
                            XmlElement xe = doc.CreateElement("Item");
                            xe.SetAttribute("key", item.Key);
                            xe.SetAttribute("value", item.Value);
                            root.AppendChild(xe);
                        }

                    }

                }
                doc.Save(XmlFilePath);
                doc.Clone();
                doc = null;

            }
            catch (Exception ex)
            {
                Program.LogNet.WriteError("保存配置文件异常", ex.Message);
                return false;
            }
            return true;
        }
    }
}
