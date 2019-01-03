using csLTDMC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuaTianProject.UI
{
    public partial class AbsoluteControlForm : Form
    {
        public AbsoluteControlForm()
        {
            InitializeComponent();
        }
        private ushort _CardID = 0;

        private void AbsoluteControlForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // ushort axis = GetAxis(); //轴号
            double dcurrent_speedX = 0, dcurrent_speedY = 0, dcurrent_speedZ = 0, dcurrent_speedW = 0;//速度值
            //  double dunitPosX, dunitPosY, dunitPosZ, dunitPosW; //脉冲当量转换后指令值
            int PosX, PosY, PosZ, PosW; //脉冲值

            LTDMC.dmc_read_current_speed_unit(_CardID, 0, ref dcurrent_speedX); // 读取轴当前速度
            LTDMC.dmc_read_current_speed_unit(_CardID, 1, ref dcurrent_speedY);
            LTDMC.dmc_read_current_speed_unit(_CardID, 2, ref dcurrent_speedZ);
            LTDMC.dmc_read_current_speed_unit(_CardID, 3, ref dcurrent_speedW);
            txtCurrentSpeedX.Text = dcurrent_speedX.ToString();
            txtCurrentSpeedY.Text = dcurrent_speedY.ToString();
            txtCurrentSpeedZ.Text = dcurrent_speedZ.ToString();
            txtCurrentSpeedW.Text = dcurrent_speedW.ToString();
            //LTDMC.dmc_get_position_unit(_CardID, 0, ref dunitPosX); //读取指定轴指令位置值
            //txtFinalPosY.Text = dunitPosX.ToString();
            PosX = LTDMC.dmc_get_position(_CardID, 0);//读取指定轴的脉冲值
            PosY = LTDMC.dmc_get_position(_CardID, 1);
            PosZ = LTDMC.dmc_get_position(_CardID, 2);
            PosW = LTDMC.dmc_get_position(_CardID, 3);
            txtCurrentPosX.Text = PosX.ToString();
            txtCurrentPosY.Text = PosY.ToString();
            txtCurrentPosZ.Text = PosZ.ToString();
            txtCurrentPosW.Text = PosW.ToString();
            if (LTDMC.dmc_check_done(_CardID, 0) == 0) // 读取指定轴运动状态
            {
                txtStateX.Text = "运行中";
            }
            else
            {
                txtStateX.Text = "停止中";
            }
            if (LTDMC.dmc_check_done(_CardID, 1) == 0) // 读取指定轴运动状态
            {
                txtStateY.Text = "运行中";
            }
            else
            {
                txtStateY.Text = "停止中";
            }
            if (LTDMC.dmc_check_done(_CardID, 2) == 0) // 读取指定轴运动状态
            {
                txtStateZ.Text = "运行中";
            }
            else
            {
                txtStateZ.Text = "停止中";
            }
            if (LTDMC.dmc_check_done(_CardID, 3) == 0) // 读取指定轴运动状态
            {
                txtStateW.Text = "运行中";
            }
            else
            {
                txtStateW.Text = "停止中";
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //  ushort axis = GetAxis(); //轴号
            ushort stop_mode = 0; //制动方式，0：减速停止，1：紧急停止
            for (ushort axis = 0; axis < 4; axis++)
            {
                LTDMC.dmc_stop(_CardID, axis, stop_mode);
            }
        }
        private void setPara(ushort axis)
        {
           // ushort axis = 0; //轴号
            double dEquiv = 100; //脉冲当量
            double dStartVel = 500;//起始速度
            double dMaxVel = 2000;//运行速度
            double dTacc = 0.1;//加速时间
            double dTdec = 0.1;//减速时间
            double dStopVel = 1000;//停止速度
            double dS_para = 0.1;//S段时间
            
         //   ushort sPosi_mode = 1; //运动模式0：相对坐标模式，1：绝对坐标模式
            
           // sPosi_mode = 0;

            LTDMC.dmc_set_equiv(_CardID, axis, dEquiv);  //设置脉冲当量

            LTDMC.dmc_set_profile_unit(_CardID, axis, dStartVel, dMaxVel, dTacc, dTdec, dStopVel);//设置速度参数

            LTDMC.dmc_set_s_profile(_CardID, axis, 0, dS_para);//设置S段速度参数

            LTDMC.dmc_set_dec_stop_time(_CardID, axis, dTdec); //设置减速停止时间
        }

        private void btnAxisX_Click(object sender, EventArgs e)
        {
            double dDist;//目标位置
            dDist = Convert.ToDouble(txtFinalPosX.Text);
            setPara(0);
            LTDMC.dmc_pmove_unit(_CardID, 0, dDist, 1);//定长运动
        }

        private void btnAxisY_Click(object sender, EventArgs e)
        {
            double dDist;//目标位置
            dDist = Convert.ToDouble(txtFinalPosY.Text);
            setPara(1);
            LTDMC.dmc_pmove_unit(_CardID, 1, dDist, 1);//定长运动
        }

        private void btnAxisZ_Click(object sender, EventArgs e)
        {
            double dDist;//目标位置
            dDist = Convert.ToDouble(txtFinalPosZ.Text);
            setPara(2);
            LTDMC.dmc_pmove_unit(_CardID, 2, dDist, 1);//定长运动
        }

        private void btnAxisW_Click(object sender, EventArgs e)
        {
            double dDist;//目标位置
            dDist = Convert.ToDouble(txtFinalPosW.Text);
            setPara(3);
            LTDMC.dmc_pmove_unit(_CardID, 3, dDist, 1);//定长运动
        }

    }
}
