namespace HuaTianProject.Interface
{
    /// <summary>
    /// 轴运动控制接口
    /// </summary>
    public interface IAxisMove
    {
        short MakeEmgStop(ushort cardId);

        short MakeAxisStop(ushort cardId, ushort axis, ushort stopMode);

        short MakeMulticoorAxisStop(ushort cardId, ushort crd, ushort stopMode);


    }
}