using System;
using System.IO;
using System.Windows.Forms;
using HslCommunication.BasicFramework;
using HslCommunication.LogNet;

namespace WindowsFormsApplication1
{
    public partial class FormRegister : Form
    {
        private HslCommunication.BasicFramework.SoftAuthorize softAuthorize = null;

        public FormRegister()
        {
            InitializeComponent();
        }
        private void FormRegister_Load(object sender, EventArgs e)
        {
            softAuthorize = new SoftAuthorize();//实例化
            softAuthorize.ILogNet = new LogNetSingle("log.txt");//日志
            softAuthorize.FileSavePath = Application.StartupPath + @"\Authorize.txt";// 设置存储激活码的文件，该存储是加密
            softAuthorize.LoadByFile();
        }

        //获取本机机器码
        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = softAuthorize.GetMachineCodeString();
        }

        //计算计算机注册码
        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.AppendText(DateTime.Now.ToString() + " " + AuthorizeEncrypted(textBox3.Text) + Environment.NewLine);

        }

        /// <summary>
        /// 一个自定义的加密方法，传入一个原始数据，返回一个加密结果
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        private string AuthorizeEncrypted(string origin)
        {
            return SoftSecurity.MD5Encrypt(origin, textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 检测激活码是否正确，没有文件，或激活码错误都算作激活失败
            if (!softAuthorize.IsAuthorizeSuccess(AuthorizeEncrypted))
            {
                // 显示注册窗口
                using (
                    FormAuthorize form = new FormAuthorize(softAuthorize, "请联系华天世纪激光科技有限公司获取激活码！", AuthorizeEncrypted))
                {
                    if (form.ShowDialog() != DialogResult.OK)
                    {
                        // 授权失败，退出
                        MessageBox.Show("授权失败！");
                    }
                    else
                    {
                        MessageBox.Show("授权成功！");
                    }
                }
            }
            else
            {
                MessageBox.Show("授权成功！");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(Application.StartupPath + @"\Authorize.txt");
                MessageBox.Show("删除成功，重新打开窗口生效。");
            }
            catch (Exception ex)
            {
                SoftBasic.ShowExceptionMessage(ex);
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.PasswordChar = '\0';
            }
            else
            {
                textBox1.PasswordChar = '*';
            }
        }
    }
}
