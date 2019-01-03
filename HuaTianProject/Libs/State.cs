using System;
using System.Threading;

namespace HuaTianProject.Libs
{
    public abstract class State
    {
        //线程状态
        public bool ThreadLive { set; get; }
        public bool ThreadSwitch = false;

        //工作线程
        private Thread m_wkThread;

        //线程名称
        private string m_name;

        ~State()
        {
            if (m_wkThread != null && m_wkThread.IsAlive)
            {
                m_wkThread.Abort();
            }

            //500ms延迟关闭
            int nTimes = 0;
            bool bOK = false;

            do
            {
                ThreadSwitch = false;
                bOK = true;

                if (nTimes++ > 500)
                {
                    bOK = false;
                    Console.WriteLine(m_name + " Thread End TimeOut......");
                }

                Thread.Sleep(1);

            } while (ThreadLive);

            if (bOK)
            {
                Console.WriteLine(m_name + " Thread END....");
            }
        }

        public Thread InitThread(string name)
        {
            Thread selfThread = new Thread(new ParameterizedThreadStart(RunProcess));
            selfThread.IsBackground = true;
            selfThread.Name = name;
            selfThread.Start(this);
            ThreadSwitch = true;

            m_wkThread = selfThread;
            m_name = name;

            return m_wkThread;
        }
        public virtual void AbortThread()
        {
            if (m_wkThread != null)
                m_wkThread.Abort();
        }

        public virtual void RunProcess(object obj)
        {
            ThreadLive = true;
            Run();
            ThreadLive = false;
            ThreadSwitch = false;
        }

        public virtual void AutoStop()
        {
            ThreadSwitch = false;
        }

        /// <summary>
        /// virtual:此方法可被任何继承它的类重写。
        /// </summary>
        public virtual void Run()
        {

        }

    }
}