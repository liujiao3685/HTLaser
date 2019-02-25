namespace MonitorDevice
{
    partial class FormMonitorForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labTips = new System.Windows.Forms.Label();
            this.lab = new System.Windows.Forms.Label();
            this.lanVisionState = new HslCommunication.Controls.UserLantern();
            this.labVision = new System.Windows.Forms.Label();
            this.lanLwmState = new HslCommunication.Controls.UserLantern();
            this.label4 = new System.Windows.Forms.Label();
            this.lanScanState = new HslCommunication.Controls.UserLantern();
            this.label3 = new System.Windows.Forms.Label();
            this.lanPlcState = new HslCommunication.Controls.UserLantern();
            this.label2 = new System.Windows.Forms.Label();
            this.lanDbState = new HslCommunication.Controls.UserLantern();
            this.label1 = new System.Windows.Forms.Label();
            this.timerMonitor = new System.Windows.Forms.Timer(this.components);
            this.timerDB = new System.Windows.Forms.Timer(this.components);
            this.userLantern1 = new HslCommunication.Controls.UserLantern();
            this.DBState = new System.Windows.Forms.Label();
            this.timerTPOS = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labTips
            // 
            this.labTips.AutoSize = true;
            this.labTips.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labTips.ForeColor = System.Drawing.Color.Red;
            this.labTips.Location = new System.Drawing.Point(92, 36);
            this.labTips.Name = "labTips";
            this.labTips.Size = new System.Drawing.Size(42, 21);
            this.labTips.TabIndex = 23;
            this.labTips.Text = "tips";
            // 
            // lab
            // 
            this.lab.AutoSize = true;
            this.lab.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.lab.ForeColor = System.Drawing.Color.Black;
            this.lab.Location = new System.Drawing.Point(34, 41);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(48, 30);
            this.lab.TabIndex = 22;
            this.lab.Text = "注:";
            // 
            // lanVisionState
            // 
            this.lanVisionState.BackColor = System.Drawing.Color.Transparent;
            this.lanVisionState.LanternBackground = System.Drawing.Color.Gray;
            this.lanVisionState.Location = new System.Drawing.Point(349, 277);
            this.lanVisionState.Margin = new System.Windows.Forms.Padding(4, 21, 4, 21);
            this.lanVisionState.Name = "lanVisionState";
            this.lanVisionState.Size = new System.Drawing.Size(129, 126);
            this.lanVisionState.TabIndex = 21;
            // 
            // labVision
            // 
            this.labVision.AutoSize = true;
            this.labVision.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labVision.Location = new System.Drawing.Point(339, 238);
            this.labVision.Name = "labVision";
            this.labVision.Size = new System.Drawing.Size(152, 24);
            this.labVision.TabIndex = 20;
            this.labVision.Text = "LJ7000连接状态";
            // 
            // lanLwmState
            // 
            this.lanLwmState.BackColor = System.Drawing.Color.Transparent;
            this.lanLwmState.LanternBackground = System.Drawing.Color.Gray;
            this.lanLwmState.Location = new System.Drawing.Point(96, 277);
            this.lanLwmState.Margin = new System.Windows.Forms.Padding(4, 15, 4, 15);
            this.lanLwmState.Name = "lanLwmState";
            this.lanLwmState.Size = new System.Drawing.Size(129, 126);
            this.lanLwmState.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label4.Location = new System.Drawing.Point(92, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 24);
            this.label4.TabIndex = 18;
            this.label4.Text = "LWM连接状态";
            // 
            // lanScanState
            // 
            this.lanScanState.BackColor = System.Drawing.Color.Transparent;
            this.lanScanState.LanternBackground = System.Drawing.Color.Gray;
            this.lanScanState.Location = new System.Drawing.Point(609, 60);
            this.lanScanState.Margin = new System.Windows.Forms.Padding(4, 11, 4, 11);
            this.lanScanState.Name = "lanScanState";
            this.lanScanState.Size = new System.Drawing.Size(129, 126);
            this.lanScanState.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label3.Location = new System.Drawing.Point(602, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 24);
            this.label3.TabIndex = 16;
            this.label3.Text = "扫描仪连接状态";
            // 
            // lanPlcState
            // 
            this.lanPlcState.BackColor = System.Drawing.Color.Transparent;
            this.lanPlcState.LanternBackground = System.Drawing.Color.Gray;
            this.lanPlcState.Location = new System.Drawing.Point(349, 60);
            this.lanPlcState.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.lanPlcState.Name = "lanPlcState";
            this.lanPlcState.Size = new System.Drawing.Size(129, 126);
            this.lanPlcState.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.Location = new System.Drawing.Point(353, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 24);
            this.label2.TabIndex = 14;
            this.label2.Text = "PLC连接状态";
            // 
            // lanDbState
            // 
            this.lanDbState.BackColor = System.Drawing.Color.Transparent;
            this.lanDbState.LanternBackground = System.Drawing.Color.Gray;
            this.lanDbState.Location = new System.Drawing.Point(96, 60);
            this.lanDbState.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.lanDbState.Name = "lanDbState";
            this.lanDbState.Size = new System.Drawing.Size(129, 126);
            this.lanDbState.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.Location = new System.Drawing.Point(92, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "DB-192.168.0.71";
            // 
            // timerDB
            // 
            this.timerDB.Enabled = true;
            this.timerDB.Interval = 1000;
            this.timerDB.Tick += new System.EventHandler(this.timerDB_Tick);
            // 
            // userLantern1
            // 
            this.userLantern1.BackColor = System.Drawing.Color.Transparent;
            this.userLantern1.LanternBackground = System.Drawing.Color.Gray;
            this.userLantern1.Location = new System.Drawing.Point(609, 277);
            this.userLantern1.Margin = new System.Windows.Forms.Padding(4, 21, 4, 21);
            this.userLantern1.Name = "userLantern1";
            this.userLantern1.Size = new System.Drawing.Size(129, 126);
            this.userLantern1.TabIndex = 25;
            // 
            // DBState
            // 
            this.DBState.AutoSize = true;
            this.DBState.Font = new System.Drawing.Font("Tahoma", 12F);
            this.DBState.Location = new System.Drawing.Point(602, 238);
            this.DBState.Name = "DBState";
            this.DBState.Size = new System.Drawing.Size(149, 24);
            this.DBState.TabIndex = 24;
            this.DBState.Text = "DB-192.168.0.1";
            // 
            // timerTPOS
            // 
            this.timerTPOS.Enabled = true;
            this.timerTPOS.Interval = 1300;
            this.timerTPOS.Tick += new System.EventHandler(this.timerTPOS_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.userLantern1);
            this.panel1.Controls.Add(this.lanDbState);
            this.panel1.Controls.Add(this.DBState);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lanPlcState);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lanVisionState);
            this.panel1.Controls.Add(this.lanScanState);
            this.panel1.Controls.Add(this.labVision);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lanLwmState);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(849, 528);
            this.panel1.TabIndex = 26;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lab);
            this.panel2.Controls.Add(this.labTips);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 428);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(849, 100);
            this.panel2.TabIndex = 27;
            // 
            // FormMonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 528);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormMonitorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "通讯监控";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMonitor_FormClosing);
            this.Load += new System.EventHandler(this.FormMonitor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labTips;
        private System.Windows.Forms.Label lab;
        private HslCommunication.Controls.UserLantern lanVisionState;
        private System.Windows.Forms.Label labVision;
        private HslCommunication.Controls.UserLantern lanLwmState;
        private System.Windows.Forms.Label label4;
        private HslCommunication.Controls.UserLantern lanScanState;
        private System.Windows.Forms.Label label3;
        private HslCommunication.Controls.UserLantern lanPlcState;
        private System.Windows.Forms.Label label2;
        private HslCommunication.Controls.UserLantern lanDbState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerMonitor;
        private System.Windows.Forms.Timer timerDB;
        private HslCommunication.Controls.UserLantern userLantern1;
        private System.Windows.Forms.Label DBState;
        private System.Windows.Forms.Timer timerTPOS;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

