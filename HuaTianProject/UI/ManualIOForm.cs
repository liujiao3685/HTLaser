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
    public partial class ManualIOForm : Form
    {
        public ManualIOForm()
        {
            InitializeComponent();
        }

        private void btnLaser_Click(object sender, EventArgs e)
        {
            if (this.btnLaser.Text == "激光")
            {
                this.btnLaser.Text = "关激光";
            }
            else if (this.btnLaser.Text == "关激光")
            {
                this.btnLaser.Text = "激光";
            }
        }

        private void btnConxial_Click(object sender, EventArgs e)
        {
            if (this.btnConxial.Text == "同轴吹")
            {
                this.btnConxial.Text = "关气";
                this.chkCoaxial.Enabled = false;
                this.chkSideBlown.Enabled = false;
            }
            else if (this.btnConxial.Text == "关气")
            {
                this.btnConxial.Text = "同轴吹";
                this.chkCoaxial.Enabled = true;
                this.chkSideBlown.Enabled = true;
            }
        }

        private void btnSideBlown_Click(object sender, EventArgs e)
        {
            if (this.btnSideBlown.Text == "侧吹")
            {
                this.btnSideBlown.Text = "关气";
            }
            else if (this.btnSideBlown.Text == "关气")
            {
                this.btnSideBlown.Text = "侧吹";
            }
        }

        private void btnGuangzha_Click(object sender, EventArgs e)
        {
            if (this.btnGuangzha.Text == "光闸")
            {
                this.btnGuangzha.Text = "关光闸";
            }
            else if (this.btnGuangzha.Text == "关光闸")
            {
                this.btnGuangzha.Text = "光闸";
            }
        }

    }
}
