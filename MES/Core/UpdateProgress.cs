namespace MES.Core
{

    public class UpdateProgress
    {
        public delegate void UpdateUI(int step);//更新主线程委托
        public event UpdateUI UpdateUIHandle;

        public delegate void AccomplishTask();//完成时通知主线程
        public event AccomplishTask TaskHandle;

        public void Update(object count)
        {
            for (int i = 0; i < (int)count; i++)
            {
                //更新UI
                UpdateUIHandle?.Invoke(1);
            }
            //完成更新
            TaskHandle?.Invoke();
        }

    }
}
