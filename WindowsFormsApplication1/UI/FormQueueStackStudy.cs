using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace WindowsFormsApplication1.UI
{
    public partial class FormQueueStackStudy : Form
    {
        /// <summary>
        /// 队列，先进先出，在队列中间操作项是不合法的，例：买火车票
        /// 入队：在列表的末尾增加一项
        /// 出队：在列表的开头移除一项
        /// </summary>
        private Queue queue = new Queue();
        private Queue<object> queueT = new Queue<object>();

        /// <summary>
        /// 堆栈：先进后出
        /// 推入：在列表中增加一项
        /// 弹出：在列表中移除一项
        /// </summary>
        private Stack stack = new Stack();
        private Stack<object> stackT = new Stack<object>();

        public FormQueueStackStudy()
        {
            InitializeComponent();
        }

        private void FormQueueStackStudy_Load(object sender, System.EventArgs e)
        {

        }

        private static void Start(object obj)
        {
            //Task.Factory.StartNew(new System.Action());
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            string queues = textBox1.Text.ToString();
            foreach (var item in queues.Split(','))
            {
                queue.Enqueue(item);
            }

            label1.Text = string.Empty;
            foreach (string item in queue)
            {
                label1.Text += item;
            }

            label1.Text += "\r\nCount:" + queue.Count.ToString();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            label1.Text = string.Empty;
            queue.Enqueue("E");
            foreach (string item in queue)
            {
                label1.Text += item;
            }
            label1.Text += "\r\nCount:" + queue.Count.ToString();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            label1.Text = string.Empty;
            queue?.Dequeue();
            foreach (string item in queue)
            {
                label1.Text += item;
            }
            label1.Text += "\r\nCount:" + queue.Count.ToString();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            string stacks = textBox2.Text.ToString();
            foreach (var item in stacks.Split(','))
            {
                stack.Push(item);
            }


            label2.Text = string.Empty;
            foreach (string item in stack)
            {
                label2.Text += item;
            }
            label2.Text += "\r\nCount:" + stack.Count.ToString();
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            label2.Text = string.Empty;
            stack.Push("S");
            foreach (string item in stack)
            {
                label2.Text += item;
            }
            label2.Text += "\r\nCount:" + stack.Count.ToString();
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            label2.Text = string.Empty;
            stack?.Pop();
            foreach (string item in stack)
            {
                label2.Text += item;
            }
            label2.Text += "\r\nCount:" + stack.Count.ToString();
        }

        private void button7_Click(object sender, System.EventArgs e)
        {
           // 格式字符串只能是“D”、“d”、“N”、“n”、“P”、“p”、“B”、“b”、“X”或“x”。 出现了

            txtGuid.Text = Guid.NewGuid().ToString("D");
        }
    }
}
