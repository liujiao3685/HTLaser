using csLTDMC;

namespace HuaTianProject.Interface.Impl
{
    public class AxisState : IAxisState
    {
        /// <summary>
        /// 获取指定控制卡的全部输入电平
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="outBit"></param>
        /// <returns></returns>
        public uint GetAxisAllInLevel(ushort cardId, ushort portNo)
        {
            return LTDMC.dmc_read_inport(cardId, portNo);
        }

        /// <summary>
        /// 获取指定控制卡的全部输出电平
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="outBit"></param>
        /// <returns></returns>
        public uint GetAxisAllOutLevel(ushort cardId, ushort portNo)
        {
            return LTDMC.dmc_read_outport(cardId, portNo);
        }

        /// <summary>
        /// 获取指定输入端口的电平
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="outBit"></param>
        /// <returns></returns>
        public short GetAxisLevelByInBit(ushort cardId, ushort inBit)
        {
            return LTDMC.dmc_read_inbit(cardId, inBit);
        }

        /// <summary>
        /// 获取指定输出端口的电平
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="outBit"></param>
        /// <returns></returns>
        public short GetAxisLevelByOutBit(ushort cardId, ushort outBit)
        {
            return LTDMC.dmc_read_outbit(cardId, outBit);
        }

        /// <summary>
        /// 获取坐标系运动状态
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="crd">值范围：0~1</param>
        /// <returns>0-使用中，1-正常停止</returns>
        public short GetMulticoorState(ushort cardId, ushort crd)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取指定轴运动状态
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="axis"></param>
        /// <returns>0-运行中，1-已停止</returns>
        public short GetAxisState(ushort cardId, ushort axis)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取轴运动状态
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="axis"></param>
        /// <param name="runMode">运动模式：0-空闲，1-Pmove，2-Vmove，3-Hmove，4-Handwheel</param>
        /// <returns>错误码</returns>
        public short GetAxisRunMode(ushort cardId, ushort axis, ref ushort runMode)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取指定轴位置
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="axis"></param>
        /// <param name="posistion"></param>
        /// <returns>错误码</returns>
        public short GetAxisPosition(ushort cardId, ushort axis, ref double posistion)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取正在运动轴的坐标-绝对坐标
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="axis"></param>
        /// <returns>脉冲位置，单位：pulse</returns>
        public long GetMoveAxisPosition(ushort cardId, ushort axis)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取指定轴的当前速度
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="axis"></param>
        /// <param name="speed">当前轴速度值</param>
        /// <returns>错误码</returns>
        public short GetAxisSpeed(ushort cardId, ushort axis, ref double speed)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取指定轴的当前速度
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="axis"></param>
        /// <returns>指定轴速度，单位：pulse/s</returns>
        public double GetAxisSpeed(ushort cardId, ushort axis)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 获取指定控制卡状态
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="state">控制卡状态：0-连接，1-断开</param>
        /// <returns>错误码</returns>
        public short GetCardState(ushort cardId, ref ushort state)
        {
            throw new System.NotImplementedException();
        }
    }
}