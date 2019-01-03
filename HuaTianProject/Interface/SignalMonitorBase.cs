using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuaTianProject.Interface
{
    /// <summary>
    /// 轴信号监控类
    /// </summary>
    public abstract class SignalMonitorBase
    {
        public abstract bool HomeSignal(ushort axis);

        public abstract bool PosSignal(ushort axis);

        public abstract bool NegSignal(ushort axis);

        public abstract int GetAxisPosition(ushort axis);

    }
}
