using log4net;

namespace CommonLibrary.Log
{
    public class Log
    {
        private ILog logger;
        public Log(ILog log)
        {
            logger = log;
        }

        public void Debug(object msg)
        {
            logger.Debug(msg);
        }

        public void Error(object msg)
        {
            logger.Error(msg);
        }

        public void Info(object msg)
        {
            logger.Info(msg);
        }

        public void Warn(object msg)
        {
            logger.Warn(msg);
        }

    }
}
