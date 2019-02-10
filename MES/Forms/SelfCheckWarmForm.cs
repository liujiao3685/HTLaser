using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace MES.UI
{
    public partial class SelfCheckWarmForm : Form
    {
        private FormMain m_formMain;

        #region 属性 API特效窗体显示和隐藏

        /// <summary>
        /// //从左到右
        /// </summary>
        public const Int32 AW_HOR_LEFT_RIGHT = 0x00000001;
        /// <summary>
        /// 从右到左
        /// </summary>
        private const Int32 AW_HOR_RIGHT_LEFT = 0x00000002;
        /// <summary>
        /// 从上到下
        /// </summary>
        private const Int32 AW_VER_UP_DOWN = 0x00000004;
        /// <summary>
        /// 从下到上
        /// </summary>
        private const Int32 AW_VER_DOWN_UP = 0x00000008;
        /// <summary>
        /// 从中间到四周
        /// </summary>
        private const Int32 AW_CENTER = 0x00000010;
        /// <summary>
        /// 隐藏窗口
        /// </summary>
        private const Int32 AW_HIDE = 0x00010000;
        /// <summary>
        /// 显示窗口
        /// </summary>
        private const Int32 AW_ACTIVATE = 0x00020000;
        /// <summary>
        /// 使用滑动类型。缺省则为滚动动画类型。当使用AW_CENTER标志时，这个标志就被忽略
        /// </summary>
        private const Int32 AW_SLIDE = 0x00040000;
        /// <summary>
        /// 改变透明度
        /// </summary>
        private const Int32 AW_BLEND = 0x00080000;

        /// <summary>
        /// 特效花费时间 单位：毫秒
        /// </summary>
        private int _speed = 500;

        [DllImport("user32.dll")]
        public static extern void AnimateWindow(IntPtr hwnd, int stime, int style);//显示效果

        /// <summary>
        /// 鼠标坐标
        /// </summary>
        private Point _cursorPoint;

        //API获取鼠标坐标
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point pt);

        //线程暂停时间 单位：毫秒
        private int _timespan = 3000;
        private System.Threading.Timer _timer;
        private delegate void LoadListDelegate();
        private LoadListDelegate _loaddelegate;

        /// <summary>
        /// 窗体显示时间（S）
        /// </summary>
        private int m_formShowTime = 5000;// * 60;

        /// <summary>
        /// 窗体是否显示，true——显示、false——隐藏
        /// </summary>
        private bool _isActive = true;

        /// <summary>
        /// 停靠在边缘时，显示窗体的宽度
        /// </summary>
        private const int _smallX = 5;

        #endregion

        public SelfCheckWarmForm()
        {

        }

        public SelfCheckWarmForm(FormMain main)
        {
            InitializeComponent();

            m_formMain = main;

            this.MaximizeBox = false;//取消最大化按钮
            this.MinimizeBox = false;//取消最小化按钮
            this.ShowInTaskbar = false;//任务栏不显示窗体图标
            this.TopMost = true;//设置窗体总是显示在最前面
            this.FormBorderStyle = FormBorderStyle.FixedDialog;//设置窗体大小固定（包含fix关键字亦可）

            _loaddelegate = LoadControl;

            //Init();
        }

        private void SelfCheckWarmForm_Load(object sender, EventArgs e)
        {
            //设置窗体显示位置 右下角
            int workY = Screen.PrimaryScreen.WorkingArea.Height - Height;
            int X = Screen.PrimaryScreen.Bounds.Width - Width;//X=0:左下角；Y=0：右上角
            this.Location = new Point(X, workY);

            //窗体打开的时候就开始计时器
            BeginTimer();
        }

        private void BeginTimer()
        {
            TimerCallback tcBack = new TimerCallback(InvokTimer);
            _timer = new System.Threading.Timer(tcBack, null, 3000, _timespan);
        }

        private void SelfCheckWarmForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timer.Dispose();
            //淡出效果
            AnimateWindow(this.Handle, 1000, AW_BLEND | AW_HIDE);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //从下到上滑动
            AnimateWindow(this.Handle, _speed, AW_VER_DOWN_UP | AW_SLIDE | AW_ACTIVATE);
        }

        //重写WndProc方法，禁止拖动和双击标题栏最大化
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x231)
            {
                this.SuspendLayout();
            }
            else if (m.Msg == 0x232)
            {
                this.ResumeLayout();
            }
            else if (m.Msg == 0xA1 && m.WParam.ToInt32() == 2)//禁止拖动
            {
                return;
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// 隐藏窗体
        /// </summary>
        private void SetHide()
        {
            if (_isActive)
            {
                AnimateWindow(this.Handle, _speed, AW_VER_UP_DOWN | AW_SLIDE | AW_HIDE);

                int X = Screen.PrimaryScreen.Bounds.Width - _smallX;
                int Y = this.Location.Y;
                this.Location = new Point(X, Y);

                AnimateWindow(this.Handle, 10, AW_BLEND | AW_ACTIVATE);
                _isActive = false;

                this.Close();
            }
        }

        /// <summary>
        /// 显示窗体
        /// </summary>
        private void SetActivate()
        {
            if (!_isActive)
            {
                //设置窗体显示时间(S)
                AnimateWindow(this.Handle, m_formShowTime, AW_BLEND | AW_HIDE);

                int X = Screen.PrimaryScreen.Bounds.Width - Width;
                int Y = this.Location.Y;
                this.Location = new Point(X, Y);

                AnimateWindow(this.Handle, _speed, AW_VER_DOWN_UP | AW_SLIDE | AW_ACTIVATE);
                _isActive = true;
            }
        }

        //控制窗体显示和隐藏
        private void LoadControl()
        {
            #region 控制窗体显示和隐藏
            //获取当前鼠标坐标
            GetCursorPos(out _cursorPoint);
            //根据 窗体当前状态，判断窗体接下来是显示还是隐藏。
            if (_isActive)
            {
                //当前窗体为显示，则接下来是隐藏
                //如果鼠标坐标不在窗体范围内，则设置窗体隐藏，否则不处理
                if (_cursorPoint.X < this.Location.X || _cursorPoint.Y < this.Location.Y)
                {
                    SetHide();
                }
            }
            else
            {
                //当前窗体为隐藏，则接下来是显示
                //如果鼠标坐标在窗体范围内，则设置窗体显示，否则不处理
                if (_cursorPoint.X >= this.Location.X && _cursorPoint.Y >= this.Location.Y)
                {
                    SetActivate();
                }
            }
            #endregion
        }

        private void InvokTimer(object state)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(_loaddelegate);
                }
            }
            catch (Exception ex)
            {
                m_formMain.LogNetProgramer.WriteError(ex.StackTrace);
            }
        }

        private void Init()
        {
            Rectangle rectangle = Screen.AllScreens[0].WorkingArea;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(rectangle.Width - this.Width, rectangle.Height);
            this.TopMost = true;

            try
            {
                System.Threading.Thread thread = new System.Threading.Thread(() =>
                    {
                        while (this.Top >= rectangle.Height - this.Height)
                        {
                            this.Invoke(new MethodInvoker(delegate
                            {
                                this.Top = this.Top - 1;
                                System.Threading.Thread.Sleep(1);
                                Application.DoEvents();
                            }));
                        }
                    });
                thread.Start();
            }
            catch (System.Exception ex)
            {
                m_formMain.LogNetProgramer.WriteError(ex.StackTrace);
            }
        }

    }
}
