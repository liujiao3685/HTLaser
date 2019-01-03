namespace HuaTianProject.Interface
{
    /// <summary>
    /// 轴状态接口
    /// </summary>
    public interface IAxisState
    {
        uint GetAxisAllInLevel(ushort cardId, ushort portNo);

        uint GetAxisAllOutLevel(ushort cardId, ushort portNo);

        short GetAxisLevelByInBit(ushort cardId, ushort inBit);

        short GetAxisLevelByOutBit(ushort cardId, ushort outBit);

        short GetMulticoorState(ushort cardId, ushort crd);

        short GetAxisState(ushort cardId, ushort axis);

        short GetAxisRunMode(ushort cardId, ushort axis, ref ushort runMode);

        short GetAxisPosition(ushort cardId, ushort axis, ref double posistion);

        long GetMoveAxisPosition(ushort cardId, ushort axis);

        short GetAxisSpeed(ushort cardId, ushort axis, ref double speed);

        double GetAxisSpeed(ushort cardId, ushort axis);

        short GetCardState(ushort cardId, ref ushort state);


    }
}