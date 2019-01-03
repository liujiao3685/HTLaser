using System;
using System.Drawing;
using System.Windows.Forms;
using csLTDMC;
namespace HuaTianProject.UI
{
    public partial class IOStateForm : Form
    {
        private ushort m_cardID = 0;

        bool homeSensor0 = false, posLimited0 = false, negLimited0 = false;
        bool homeSensor1 = false, posLimited1 = false, negLimited1 = false;
        bool homeSensor2 = false, posLimited2 = false, negLimited2 = false;
        bool homeSensor3 = false, posLimited3 = false, negLimited3 = false;

        public IOStateForm()
        {
            InitializeComponent();
        }

        private void IOShowForm_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
        }

        private void IOStateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.timer1.Stop();
        }

        private void SetIOStateColor(Label label, bool state)
        {
            if (label != null)
            {
                if (state)
                {
                    label.BackColor = Color.Red;
                }
                else
                {
                    label.BackColor = Color.Green;
                }
            }

        }

        //输入IO口
        private Label GetINLabel(int index)
        {
            string txt = index.ToString();
            foreach (Label label in groupBox1.Controls)
            {
                if (label != null && label.Text == txt)
                {
                    return label;
                }
            }
            return null;
        }

        //输出IO口
        private Label GetOUTLabel(int index)
        {
            string txt = index.ToString();
            foreach (Label label in groupBox2.Controls)
            {
                if (label != null && label.Text == txt)
                {
                    return label;
                }
            }
            return null;
        }

        private void label_Click(object sender, EventArgs e)
        {
            int index = -1;
            foreach (Label label in groupBox2.Controls)
            {
                if (label == sender)
                {
                    index = Convert.ToInt32(label.Text);
                    break;
                }
            }
            if (index > -1)
            {
                short state = LTDMC.dmc_read_outbit(m_cardID, (ushort)index);
                if (state == 0)
                {
                    LTDMC.dmc_write_outbit(m_cardID, (ushort)index, 1);
                }
                else
                {
                    LTDMC.dmc_write_outbit(m_cardID, (ushort)index, 0);
                }
            }
        }
        public void GetAxisLimitedSensor(ushort axis, ref bool homeSensor, ref bool positiveLtd, ref bool negativeLtd)
        {
            uint portValue;

            portValue = LTDMC.dmc_read_inport(0, (ushort)1);
            homeSensor = ((portValue & (0x1 << (axis))) == 0) ? true : false;

            portValue = LTDMC.dmc_read_inport(0, (ushort)0);
            positiveLtd = ((portValue & (0x1 << (axis + 16))) > 0) ? true : false;
            negativeLtd = ((portValue & (0x1 << (axis + 24))) > 0) ? true : false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetAxisLimitedSensor(0, ref homeSensor0, ref posLimited0, ref negLimited0);
            GetAxisLimitedSensor(1, ref homeSensor1, ref posLimited1, ref negLimited1);
            GetAxisLimitedSensor(2, ref homeSensor2, ref posLimited2, ref negLimited2);
            GetAxisLimitedSensor(3, ref homeSensor3, ref posLimited3, ref negLimited3);
            SetCondition();
            //输入口
            uint n = LTDMC.dmc_read_inport(m_cardID, 0);
            for (int i = 0; i < 16; i++)
            {
                Label lable = GetINLabel(i);
                if (label1 != null)
                {
                    SetIOStateColor(lable, (n & 1) == 1);
                }
                n = n >> 1;//n右移一位
            }

            //输出口
            n = LTDMC.dmc_read_outport(m_cardID, 0);
            for (int i = 0; i < 16; i++)
            {
                Label label = GetOUTLabel(i);
                if (label1 != null)
                {
                    SetIOStateColor(label, (n & 1) == 1);
                }
                n = n >> 1;
            }

        }
       
        private void SetCondition()
        {
            if (posLimited0) labPositiveLimited0.BackColor = Color.Green;
            else labPositiveLimited0.BackColor = Color.Red;

            if (posLimited1) labPositiveLimited1.BackColor = Color.Green;
            else labPositiveLimited1.BackColor = Color.Red;

            if (posLimited2) labPositiveLimited2.BackColor = Color.Green;
            else labPositiveLimited2.BackColor = Color.Red;

            if (posLimited3) labPositiveLimited3.BackColor = Color.Green;
            else labPositiveLimited3.BackColor = Color.Red;

            if (negLimited0) labNegtiveLimited0.BackColor = Color.Green;
            else labNegtiveLimited0.BackColor = Color.Red;

            if (negLimited1) labNegtiveLimited1.BackColor = Color.Green;
            else labNegtiveLimited1.BackColor = Color.Red;

            if (negLimited2) labNegtiveLimited2.BackColor = Color.Green;
            else labNegtiveLimited2.BackColor = Color.Red;

            if (negLimited3) labNegtiveLimited3.BackColor = Color.Green;
            else labNegtiveLimited3.BackColor = Color.Red;

            if (homeSensor0)
            {
                labHome0.BackColor = Color.Green;
            }
            else
            {
                labHome0.BackColor = Color.Red;
            }
            if (homeSensor1)
            {
                labHome1.BackColor = Color.Green;
            }
            else
            {
                labHome1.BackColor = Color.Red;
            } if (homeSensor2)
            {
                labHome2.BackColor = Color.Green;
            }
            else
            {
                labHome2.BackColor = Color.Red;
            } if (homeSensor3)
            {
                labHome3.BackColor = Color.Green;
            }
            else
            {
                labHome3.BackColor = Color.Red;
            }

        }
    }
}
