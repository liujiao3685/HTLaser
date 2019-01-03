using System;

namespace HuaTianProject
{
    /// <summary>
    /// 自定义事件参数类型，根据需要可设定多种参数便于传递
    /// </summary>
    public class MyEvent : EventArgs
    {
        public bool Result { get; set; }

        public bool LoginResult { set; get; }

        public object data { get; set; }

        public MyEvent()
        {
        }

        public MyEvent(bool boo)
        {
            this.Result = boo;
        }

        public bool GetReslut(bool boo)
        {
            return boo;
        }

        public object GetObject(object obj)
        {
            return obj;
        }
    }
}
