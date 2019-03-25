using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Forms
{
    public partial class FormNineToNiie : Form
    {
        private int Nums = 100;

        public FormNineToNiie()
        {
            InitializeComponent();
        }

        private void FormNineToNiie_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                Nums = Convert.ToInt32(textBox1.Text);
            }

            Task.Factory.StartNew(() =>
            {
                ShowMessage();
            });

        }

        private void ShowMessage()
        {
            long sum = 1;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 1; i <= Nums; i++)
            {
                sum *= i;
                Debug.WriteLine("Sum：" + sum);
            }

            /**
            for (int i = 1; i <= Nums; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    //Debug.Write(string.Format("{0}*{1} ", i, j));
                    sum += (i * j);
                }
                //Debug.WriteLine("");
            }*/

            Arithmetic.Factorial f = new Arithmetic.Factorial(Nums);
            List<int> result = f.Calculate();
            
            Debug.WriteLine("Sum2：" + f.ToString());

            sw.Stop();
            Debug.Write(string.Format("----------耗时(s)：{0}----------- ", sw.Elapsed.TotalSeconds));
        }
    }
}
