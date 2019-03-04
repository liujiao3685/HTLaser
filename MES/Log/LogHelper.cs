using HslCommunication.LogNet;
using MES;

namespace ProductManage.Log
{
    public class LogHelper
    {
        public static ILogNet LogNet;

        static LogHelper()
        {
            LogNet = Program.LogNet;
        }

        public static void WriteLog(string title, string info)
        {
            LogNet.WriteInfo(title, info);
        }

        public static void WriteDebugLog(string info)
        {
            LogNet.WriteDebug(info);
        }

        public static void WriteWarmLog(string info)
        {
            LogNet.WriteWarn(info);
        }

    }
}
