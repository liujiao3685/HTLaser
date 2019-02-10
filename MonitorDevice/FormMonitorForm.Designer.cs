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
            this.SuspendLayout();
            // 
            // labTips
            // 
            this.labTips.AutoSize = true;
            this.labTips.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labTips.ForeColor = System.Drawing.Color.Red;
            this.labTips.Location = new System.Drawing.Point(105, 464);
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
            this.lab.Location = new System.Drawing.Point(47, 469);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(48, 30);
            this.lab.TabIndex = 22;
            this.lab.Text = "注:";
            // 
            // lanVisionState
            // 
            this.lanVisionState.BackColor = System.Drawing.Color.Transparent;
            this.lanVisionState.LanternBackground = System.Drawing.Color.Gray;
            this.lanVisionState.Location = new System.Drawing.Point(327, 299);
            this.lanVisionState.Margin = new System.Windows.Forms.Padding(4, 21, 4, 21);
            this.lanVisionState.Name = "lanVisionState";
            this.lanVisionState.Size = new System.Drawing.Size(129, 126);
            this.lanVisionState.TabIndex = 21;
            // 
            // labVision
            // 
            this.labVision.AutoSize = true;
            this.labVision.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labVision.Location = new System.Drawing.Point(317, 260);
            this.labVision.Name = "labVision";
            this.labVision.Size = new System.Drawing.Size(152, 24);
            this.labVision.TabIndex = 20;
            this.labVision.Text = "LJ7000连接状态";
            // 
            // lanLwmState
            // 
            this.lanLwmState.BackColor = System.Drawing.Color.Transparent;
            this.lanLwmState.LanternBackground = System.Drawing.Color.Gray;
            this.lanLwmState.Location = new System.Drawing.Point(102, 299);
            this.lanLwmState.Margin = new System.Windows.Forms.Padding(4, 15, 4, 15);
            this.lanLwmState.Name = "lanLwmState";
            this.lanLwmState.Size = new System.Drawing.Size(129, 126);
            this.lanLwmState.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label4.Location = new System.Drawing.Point(98, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 24);
            this.label4.TabIndex = 18;
            this.label4.Text = "LWM连接状态";
            // 
            // lanScanState
            // 
            this.lanScanState.BackColor = System.Drawing.Color.Transparent;
            this.lanScanState.LanternBackground = System.Drawing.Color.Gray;
            this.lanScanState.Location = new System.Drawing.Point(543, 82);
            this.lanScanState.Margin = new System.Windows.Forms.Padding(4, 11, 4, 11);
            this.lanScanState.Name = "lanScanState";
            this.lanScanState.Size = new System.Drawing.Size(129, 126);
            this.lanScanState.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label3.Location = new System.Drawing.Point(536, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 24);
            this.label3.TabIndex = 16;
            this.label3.Text = "扫描仪连接状态";
            // 
            // lanPlcState
            // 
            this.lanPlcState.BackColor = System.Drawing.Color.Transparent;
            this.lanPlcState.LanternBackground = System.Drawing.Color.Gray;
            this.lanPlcState.Location = new System.Drawing.Point(327, 82);
            this.lanPlcState.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.lanPlcState.Name = "lanPlcState";
            this.lanPlcState.Size = new System.Drawing.Size(129, 126);
            this.lanPlcState.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.Location = new System.Drawing.Point(331, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 24);
            this.label2.TabIndex = 14;
            this.label2.Text = "PLC连接状态";
            // 
            // lanDbState
            // 
            this.lanDbState.BackColor = System.Drawing.Color.Transparent;
            this.lanDbState.LanternBackground = System.Drawing.Color.Gray;
            this.lanDbState.Location = new System.Drawing.Point(102, 82);
            this.lanDbState.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.lanDbState.Name = "lanDbState";
            this.lanDbState.Size = new System.Drawing.Size(129, 126);
            this.lanDbState.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.Location = new System.Drawing.Point(93, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "数据库连接状态";
            // 
            // FormMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 528);
            this.Controls.Add(this.labTips);
            this.Controls.Add(this.lab);
            this.Controls.Add(this.lanVisionState);
            this.Controls.Add(this.labVision);
            this.Controls.Add(this.lanLwmState);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lanScanState);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lanPlcState);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lanDbState);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "通讯监控";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMonitor_FormClosing);
            this.Load += new System.EventHandler(this.FormMonitor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

