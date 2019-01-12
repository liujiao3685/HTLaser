namespace ProductManage.UI
{
    partial class FormMonitor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMonitor));
            this.label1 = new System.Windows.Forms.Label();
            this.lanDbState = new HslCommunication.Controls.UserLantern();
            this.lanPlcState = new HslCommunication.Controls.UserLantern();
            this.label2 = new System.Windows.Forms.Label();
            this.lanScanState = new HslCommunication.Controls.UserLantern();
            this.label3 = new System.Windows.Forms.Label();
            this.lanLwmState = new HslCommunication.Controls.UserLantern();
            this.label4 = new System.Windows.Forms.Label();
            this.lanVisionState = new HslCommunication.Controls.UserLantern();
            this.labVision = new System.Windows.Forms.Label();
            this.lab = new System.Windows.Forms.Label();
            this.timerMonitor = new System.Windows.Forms.Timer(this.components);
            this.labTips = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.Location = new System.Drawing.Point(55, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库连接状态";
            // 
            // lanDbState
            // 
            this.lanDbState.BackColor = System.Drawing.Color.Transparent;
            this.lanDbState.LanternBackground = System.Drawing.Color.Gray;
            this.lanDbState.Location = new System.Drawing.Point(64, 85);
            this.lanDbState.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.lanDbState.Name = "lanDbState";
            this.lanDbState.Size = new System.Drawing.Size(129, 126);
            this.lanDbState.TabIndex = 1;
            // 
            // lanPlcState
            // 
            this.lanPlcState.BackColor = System.Drawing.Color.Transparent;
            this.lanPlcState.LanternBackground = System.Drawing.Color.Gray;
            this.lanPlcState.Location = new System.Drawing.Point(289, 85);
            this.lanPlcState.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.lanPlcState.Name = "lanPlcState";
            this.lanPlcState.Size = new System.Drawing.Size(129, 126);
            this.lanPlcState.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.Location = new System.Drawing.Point(293, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "PLC连接状态";
            // 
            // lanScanState
            // 
            this.lanScanState.BackColor = System.Drawing.Color.Transparent;
            this.lanScanState.LanternBackground = System.Drawing.Color.Gray;
            this.lanScanState.Location = new System.Drawing.Point(505, 85);
            this.lanScanState.Margin = new System.Windows.Forms.Padding(4, 11, 4, 11);
            this.lanScanState.Name = "lanScanState";
            this.lanScanState.Size = new System.Drawing.Size(129, 126);
            this.lanScanState.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label3.Location = new System.Drawing.Point(498, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "扫描仪连接状态";
            // 
            // lanLwmState
            // 
            this.lanLwmState.BackColor = System.Drawing.Color.Transparent;
            this.lanLwmState.LanternBackground = System.Drawing.Color.Gray;
            this.lanLwmState.Location = new System.Drawing.Point(64, 302);
            this.lanLwmState.Margin = new System.Windows.Forms.Padding(4, 15, 4, 15);
            this.lanLwmState.Name = "lanLwmState";
            this.lanLwmState.Size = new System.Drawing.Size(129, 126);
            this.lanLwmState.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label4.Location = new System.Drawing.Point(60, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "LWM连接状态";
            // 
            // lanVisionState
            // 
            this.lanVisionState.BackColor = System.Drawing.Color.Transparent;
            this.lanVisionState.LanternBackground = System.Drawing.Color.Gray;
            this.lanVisionState.Location = new System.Drawing.Point(289, 302);
            this.lanVisionState.Margin = new System.Windows.Forms.Padding(4, 21, 4, 21);
            this.lanVisionState.Name = "lanVisionState";
            this.lanVisionState.Size = new System.Drawing.Size(129, 126);
            this.lanVisionState.TabIndex = 9;
            // 
            // labVision
            // 
            this.labVision.AutoSize = true;
            this.labVision.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labVision.Location = new System.Drawing.Point(279, 263);
            this.labVision.Name = "labVision";
            this.labVision.Size = new System.Drawing.Size(152, 24);
            this.labVision.TabIndex = 8;
            this.labVision.Text = "LJ7000连接状态";
            // 
            // lab
            // 
            this.lab.AutoSize = true;
            this.lab.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.lab.ForeColor = System.Drawing.Color.Black;
            this.lab.Location = new System.Drawing.Point(34, 473);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(48, 30);
            this.lab.TabIndex = 10;
            this.lab.Text = "注:";
            // 
            // labTips
            // 
            this.labTips.AutoSize = true;
            this.labTips.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labTips.ForeColor = System.Drawing.Color.Red;
            this.labTips.Location = new System.Drawing.Point(92, 468);
            this.labTips.Name = "labTips";
            this.labTips.Size = new System.Drawing.Size(42, 21);
            this.labTips.TabIndex = 11;
            this.labTips.Text = "tips";
            // 
            // FormMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 520);
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
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "通讯监控";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMonitor_FormClosing);
            this.Load += new System.EventHandler(this.FromMonitor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private HslCommunication.Controls.UserLantern lanDbState;
        private HslCommunication.Controls.UserLantern lanPlcState;
        private System.Windows.Forms.Label label2;
        private HslCommunication.Controls.UserLantern lanScanState;
        private System.Windows.Forms.Label label3;
        private HslCommunication.Controls.UserLantern lanLwmState;
        private System.Windows.Forms.Label label4;
        private HslCommunication.Controls.UserLantern lanVisionState;
        private System.Windows.Forms.Label labVision;
        private System.Windows.Forms.Label lab;
        private System.Windows.Forms.Timer timerMonitor;
        private System.Windows.Forms.Label labTips;
    }
}