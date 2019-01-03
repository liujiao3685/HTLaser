using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csLTDMC;

namespace HuaTianProject.Interface.Impl
{
    public class AxisMove : IAxisMove
    {
        /// <summary>
        /// 紧急停止所有轴
        /// </summary>
        /// <param name="cardId"></param>
        /// <returns>错误码</returns>
        public short MakeEmgStop(ushort cardId)
        {
            return LTDMC.dmc_emg_stop(cardId);
        }

        /// <summary>
        /// 使指定轴停止运动
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="axis"></param>
        /// <param name="stopMode">停止方式：0-减速停止，1-紧急停止</param>
        /// <returns>错误码</returns>
        public short MakeAxisStop(ushort cardId, ushort axis, ushort stopMode)
        {
            return LTDMC.dmc_stop(cardId, axis, stopMode);
        }

        /// <summary>
        /// 使坐标系内所有轴停止运动-用于插补运动
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="crd">输入范围：0~1</param>
        /// <param name="stopMode">停止方式：0-减速停止，1-紧急停止</param>
        /// <returns>错误码</returns>
        public short MakeMulticoorAxisStop(ushort cardId, ushort crd, ushort stopMode)
        {
            return LTDMC.dmc_stop_multicoor(cardId, crd, stopMode);
        }
    }
}
