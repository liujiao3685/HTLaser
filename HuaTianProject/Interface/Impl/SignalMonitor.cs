using System.Drawing.Printing;
using csLTDMC;

namespace HuaTianProject.Interface.Impl
{
    /// <summary>
    /// 轴信号监听类
    /// </summary>
    public class SignalMonitor : SignalMonitorBase
    {
        private readonly ushort m_cardId;

        private uint m_portValue;

        public SignalMonitor()
        {
            m_cardId = FormMain.CardId;
        }

        /// <summary>
        ///  监控原点信号
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <returns>信号状态</returns>
        public override bool HomeSignal(ushort axis)
        {
            m_portValue = LTDMC.dmc_read_inport(m_cardId, 1);
            return (m_portValue & (0x1 << axis)) == 0;
        }

        /// <summary>
        /// 轴正限位监控
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <returns>信号状态</returns>
        public override bool PosSignal(ushort axis)
        {
            m_portValue = LTDMC.dmc_read_inport(m_cardId, 0);
            return (m_portValue & (0x1 << (axis + 16))) == 0;
        }

        /// <summary>
        /// 轴负限位监控
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <returns>信号状态</returns>
        public override bool NegSignal(ushort axis)
        {
            m_portValue = LTDMC.dmc_read_inport(m_cardId, 0);
            return (m_portValue & (0x1 << (axis + 24))) == 0;
        }

        /// <summary>
        /// 轴坐标监控
        /// </summary>
        /// <param name="axis">轴号</param>
        /// <returns>轴坐标</returns>
        public override int GetAxisPosition(ushort axis)
        {
            int pos = LTDMC.dmc_get_position(m_cardId, axis);
            return pos;
        }
    }
}
