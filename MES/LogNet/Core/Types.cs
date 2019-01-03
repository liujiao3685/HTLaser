namespace MES.LogNet.Core
{
    /// <summary>
    /// 日志记录等级
    /// </summary>
    public enum MessageDegree
    {
        /// <summary>
        /// 一条消息都不记录
        /// </summary>
        None = 1,

        /// <summary>
        /// 记录致命等级及以上日志信息
        /// </summary>
        FATAL = 2,

        /// <summary>
        /// 记录警告等级及以上日志信息
        /// </summary>
        WARN = 3,

        /// <summary>
        /// 记录异常等级及以上日志信息
        /// </summary>
        ERROR = 4,

        /// <summary>
        /// 记录信息等级及以上日志信息
        /// </summary>
        INFO = 5



    }
}
