using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HuaTianProject.Core;

namespace HuaTianProject.UserControls
{
    public partial class ParamSetForm : FormBase
    {
        private Dictionary<string, string> dictionary = new Dictionary<string, string>();

        //定义委托
        public delegate void DataChangeHandle(object sender, MyEvent arges);

        //定义事件
        public event DataChangeHandle DataChange;

        //调用事件函数
        public void OnDataChange(object sender, MyEvent args)
        {
            if (DataChange != null)
            {
                DataChange(this, args);
            }
        }

        public ParamSetForm()
        {
            InitializeComponent();
        }

        private void ParamSetForm_Load(object sender, EventArgs e)
        {
            this.ControlName = "参数设置";
    
        }

     }
}
