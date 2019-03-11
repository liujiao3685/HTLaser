using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;

namespace CommonLibrary.Log
{
    /** USE EXAMPLE FOR CODE
     * 
     *  public Queue<string> Step_Queue_msg;
     *  public void Add_Step_Queue_Msg(string title,string msg)
        {
            Step_Queue_msg.Enqueue(string.Format("{0} - {1}:{2}", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), title, msg));
            LogHelper.WriteLog(string.Format("{0},{1}", title, msg));
            //LogHelper.WriteLog(string.Format("{0},{1},{2}", station_id, title, msg));
            
            while (Step_Queue_msg.Count > 100)//界面超过100条日志则删除
            {
                Step_Queue_msg.Dequeue();
            }
        }
     * */
    /** USE EXAMPLE FOR FORM
     *  
     *  LogControl Style :
     *  
            lv_Error_log.View = View.Details;
            lv_Error_log.GridLines = true;//显示网格线
            lv_Error_log.Columns.Clear();//标题            
            lv_Error_log.Columns.Add("Log", "Error日志");//增加标题       
            lv_Error_log.Columns["Log"].Width = -2;//根据内容自适应宽度   
     * 
     * // In Timer
     * 
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (LogHelper.Log_Queue_Errmsg.Count > 0)//判断是否有新数据
            {
                for (int i = 0; i < LogHelper.Log_Queue_Errmsg.Count; i++)
                {
                    lv_Error_log.Items.Insert(0, LogHelper.Log_Queue_Errmsg.Dequeue().ToString());//lv_Error_log 第三方控件
                }
            }
        }
     * 
     **/


    public enum LoggerType
    {
        AppLogger,
    }

    public class LogHelper
    {
        public static readonly ILog loginfo = LogManager.GetLogger("loginfo");
        public static readonly Dictionary<string, ILog> logs;
        public static readonly ILog logerror = LogManager.GetLogger("logerror");

        public static Queue<string> Log_Queue_ErrMsg;

        static LogHelper()
        {
            FileInfo configFile = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + ("\\Configs\\log4net.config"));
            XmlConfigurator.Configure(configFile);
            logs = GetLoggers();
            Log_Queue_ErrMsg = new Queue<string>();
        }
        private static void InitConfig()
        {
            XmlConfigurator.Configure();
        }

        private static Dictionary<string, ILog> GetLoggers()
        {
            InitConfig();
            ILog[] allLoggers = LogManager.GetCurrentLoggers();
            Dictionary<string, ILog> dicLoggers = new Dictionary<string, ILog>();
            foreach (var logger in allLoggers)
            {
                dicLoggers.Add(logger.Logger.Name, logger);
            }
            return dicLoggers;
        }

        public static void WriteLog(string info, string loggerType = "AppLogger")
        {
            if (logs[loggerType].IsInfoEnabled)
            {
                logs[loggerType].Info(info);
            }
        }

        public static void WriteLog(string info, Exception ex)
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error(info, ex);
                Log_Queue_ErrMsg.Enqueue(info);
            }
        }

        public static void WriteDebugLog(string info)
        {
            if (loginfo.IsDebugEnabled)
            {
                loginfo.Debug(info);
            }
        }

        public static void WriteWarnLog(string info)
        {
            if (logs["AppLogger"].IsWarnEnabled)
            {
                logs["AppLogger"].Warn(info);
            }
        }

        public static Log GetLogger(Type type)
        {
            return new Log(LogManager.GetLogger(type));
        }

        public static Log GetLogger(string type)
        {
            return new Log(LogManager.GetLogger(type));
        }

    }
}
