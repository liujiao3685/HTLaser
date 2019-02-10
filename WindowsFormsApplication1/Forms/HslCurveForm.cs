using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// 测试项目
    /// </summary>
    public partial class HslCurveForm : Form
    {
        private Random random = new Random();

        // 模拟的数据
        string[] text = new string[]
        {
                "一月",
                "二月",
                "三月",
                "四月",
                "五月",
                "六月",
                "七月",
                "八月",
                "九月",
                "十月",
                "十一月",
                "十二月"
        };

        public HslCurveForm()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            userCurveLeft.IsAbscissaStrech = true;//默认的模式是像素点模式，切换为拉伸模式

            MyMethod1();

        }

        private void MyMethod1()
        {
            //跨线程访问UI
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => button1.Enabled = false));
                //button1.Invoke(new MethodInvoker(delegate() { button1.Enabled = false; }));
                //textBox1.SafeCall(() =>{ textBox1.Text = (i++).ToString();});

                button1.Invoke(new MethodInvoker(() => button1.Enabled = false));
                button1.Invoke(new Action(() => button1.Enabled = false));  // 跨线程访问UI控件
            }
        }

        /// <summary>
        /// 获取指定范围的，指定个数的随机数数组
        /// </summary>
        /// <param name="count"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private float[] GetRandomValueByCount(int count, float min, float max)
        {
            float[] data = new float[count];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (float)random.NextDouble() * (max - min) + min;
            }
            return data;
        }

        private void userButton1_Click(object sender, EventArgs e)
        {
            userCurveLeft.RemoveCurve("A");
            userCurveLeft.SetLeftCurve("A", GetRandomValueByCount(300, 0, 200), Color.DodgerBlue);
        }

        private void userButton1_Click_1(object sender, EventArgs e)
        {
            // 之前已经给A指定过颜色了，以后后续的数据更新不需要重新指定，指定了也无效
            // 如果需要重新设置颜色，或是线宽，需要先RemoveCurve，然后重新创建曲线信息
            userCurveLeft.RemoveCurve("A");
            userCurveLeft.SetLeftCurve("A", GetRandomValueByCount(300, 100, 200), Color.OrangeRed);
        }

        private void userButton2_Click(object sender, EventArgs e)
        {
            userCurveRight.IsAbscissaStrech = true;
            userCurveRight.StrechDataCountMax = 12;
            userCurveRight.RemoveAllCurve();
            userCurveRight.SetCurveText(text);

            //显示每个月用户1的销售金额 
            userCurveRight.SetLeftCurve("A", GetRandomValueByCount(12, 0, 200), Color.Tomato);
            //显示每个月用户2的销售金额，与曲线A进行对比
            userCurveRight.SetLeftCurve("B", GetRandomValueByCount(12, 0, 200), Color.DodgerBlue);
        }

        private void userButton3_Click(object sender, EventArgs e)
        {
            userCurveRight.RemoveAllCurve();
            userCurveRight.IsAbscissaStrech = true;
            userCurveRight.StrechDataCountMax = 12;

            userCurveRight.SetCurveText(text);

            //显示每个月用户1的销售金额 
            userCurveRight.SetLeftCurve("A", GetRandomValueByCount(12, 0, 200), Color.Tomato);
            //显示每个月用户2的销售金额，与曲线A进行对比
            userCurveRight.SetLeftCurve("B", GetRandomValueByCount(12, 0, 200), Color.DodgerBlue);

            userCurveRight.SetRightCurve("C", GetRandomValueByCount(12, 3, 6), Color.LimeGreen);
            userCurveRight.SetRightCurve("D", GetRandomValueByCount(12, 3, 6), Color.Orchid);

        }

        private void userButton4_Click(object sender, EventArgs e)
        {
            userCurveRight.RemoveAllCurve();
            userCurveRight.IsAbscissaStrech = true;
            userCurveRight.StrechDataCountMax = 12;

            ThreadPool.QueueUserWorkItem(t =>
            {
                while (true)
                {
                    float[] data = GetRandomValueByCount(12, 40, 150);

                    userCurveRight.ValueMaxLeft = (float)Math.Ceiling(data.Max());
                    userCurveRight.ValueMinLeft = (float)Math.Ceiling(data.Min());

                    userCurveRight.SetCurveText(text);
                    //// 每个月用户1的销售金额
                    userCurveRight.SetLeftCurve("A", data, Color.Tomato);

                    Thread.Sleep(1000);
                }
            });

        }

        private void userButton5_Click(object sender, EventArgs e)
        {
            userCurveRight.RemoveAllCurve();
            userCurveRight.IsAbscissaStrech = false;
            userCurveRight.StrechDataCountMax = 300;

            userCurveRight.SetLeftCurve("A", new float[] { }, Color.Tomato);//指定上限500个数据，该上限只对拉伸模式有效
            userCurveLeft.SetLeftCurve("A", new float[] { }, Color.Tomato);//指定上限500个数据，该上限只对拉伸模式有效

        }

        private void userButton6_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += (sender1, e1) =>
            {
                //一次更新一个数据，即一个像素
                userCurveLeft.AddCurveData("A", random.Next(50, 200));
                //一次更新多个数据(数据必须少于2048)
                //userCurveRight.AddCurveData("A", new float[] { random.Next(50, 200), random.Next(60, 200), random.Next(70, 200) });

            };
            timer.Start();

        }

        private void userButton7_Click(object sender, EventArgs e)
        {
            userCurveRight.IsAbscissaStrech = true;
            userCurveRight.StrechDataCountMax = 300;//强行显示300个点，最大300个点，仅仅在拉伸模式下有效果

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += (sender1, e1) =>
            {
                //一次更新一个数据，即一个像素
                userCurveRight.AddCurveData("A", random.Next(50, 200));

            };
            timer.Start();
        }

        //设我们有一台设备，需要监控4条曲线，2条温度，2条压力，温度的范围是0-200，压力的范围为0-5 mpa，
        private void userButton9_Click(object sender, EventArgs e)
        {
            userCurveRight.RemoveAllCurve();
            userCurveRight.ValueMaxLeft = 200;
            userCurveRight.ValueMaxRight = 5;
            userCurveRight.ValueSegment = 10;

            userCurveRight.SetLeftCurve("A", new float[] { }, Color.Tomato);            // 温度1
            userCurveRight.SetLeftCurve("B", new float[] { }, Color.DodgerBlue);        // 温度2
            userCurveRight.SetRightCurve("C", new float[] { }, Color.LimeGreen);         // 压力1
            userCurveRight.SetRightCurve("D", new float[] { }, Color.Purple);            // 压力2

        }

        private void userButton8_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += (sender1, e1) =>
            {
                userCurveRight.AddCurveData(
                    new string[] { "A", "B", "C", "D" },
                    new float[] { random.Next(160, 181), random.Next(150, 171), (float)random.NextDouble() * 2.5f + 1, (float)random.NextDouble() * 1f });
            };
            timer.Start();

        }

        private void userButton10_Click(object sender, EventArgs e)
        {
            userCurveRight.AddLeftAuxiliary(143, Color.Red);

            userCurveRight.AddLeftAuxiliary(163, Color.Red);

            userCurveRight.AddLeftAuxiliary(192, Color.Red);


            //userCurveRight.RemoveAuxiliary(192);

        }
    }
}
