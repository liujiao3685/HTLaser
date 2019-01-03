using System;
using System.Windows.Forms;
using HslCommunication;
using HslCommunication.Profinet.Siemens;
using MES.Entity;

namespace MES.UI
{
    public partial class CheckOneProductForm : Form
    {
        private FormMain m_formMain;

        private Product m_curProduct;

        public CheckOneProductForm()
        {
            InitializeComponent();
        }

        public CheckOneProductForm(FormMain main)
        {
            InitializeComponent();
            m_formMain = main;
        }

        private void txtFirstScan_KeyPress(object sender, KeyPressEventArgs e)
        {
            string barcode = txtBarCode.Text.Trim();

            if (String.IsNullOrEmpty(barcode)) return;

            if (e.KeyChar == (int)Keys.Enter)
            {
                m_curProduct = m_formMain.DbTool.SelectProductByNo(barcode);

                if (m_curProduct == null) return;

                txtCoaxiality.Text = m_curProduct.Coaxiality.ToString();
                txtSurface.Text = m_curProduct.Surface;

            }
        }

        private SiemensS7Net siemensTcpNet = null;

        private void btnWrite_Click(object sender, EventArgs e)
        {
            Connect();

            siemensTcpNet.Write("DB41", 123456789); 

        }

        private void Connect()
        {

            // 连接
            if (!System.Net.IPAddress.TryParse("192.168.0.85", out System.Net.IPAddress address))
            {
                MessageBox.Show("Ip地址输入不正确！");
                return;
            }

            siemensTcpNet.IpAddress = "192.168.0.85";

            try
            {
                siemensTcpNet = new SiemensS7Net(SiemensPLCS.S1500);
                OperateResult connect = siemensTcpNet.ConnectServer();
                if (connect.IsSuccess)
                {
                    MessageBox.Show("连接成功！");
                }
                else
                {
                    MessageBox.Show("连接失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
