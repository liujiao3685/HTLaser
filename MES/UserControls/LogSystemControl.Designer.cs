namespace MES.UserControls
{
    partial class LogSystemControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbLogKey = new System.Windows.Forms.ComboBox();
            this.cmbLogLv = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtLogKey = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.btnWriteLog = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.txtLogContent = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBox = new System.Windows.Forms.ListBox();
            this.btnClearLogFile = new System.Windows.Forms.Button();
            this.btnLoadLogFile = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.txtLogInfo = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmbLogKey);
            this.panel1.Controls.Add(this.cmbLogLv);
            this.panel1.Controls.Add(this.label27);
            this.panel1.Controls.Add(this.txtLogKey);
            this.panel1.Controls.Add(this.label29);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.btnWriteLog);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.txtLogContent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1021, 385);
            this.panel1.TabIndex = 4;
            // 
            // cmbLogKey
            // 
            this.cmbLogKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogKey.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cmbLogKey.FormattingEnabled = true;
            this.cmbLogKey.Location = new System.Drawing.Point(310, 54);
            this.cmbLogKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbLogKey.Name = "cmbLogKey";
            this.cmbLogKey.Size = new System.Drawing.Size(154, 32);
            this.cmbLogKey.TabIndex = 18;
            this.cmbLogKey.Visible = false;
            // 
            // cmbLogLv
            // 
            this.cmbLogLv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogLv.FormattingEnabled = true;
            this.cmbLogLv.Location = new System.Drawing.Point(149, 26);
            this.cmbLogLv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbLogLv.Name = "cmbLogLv";
            this.cmbLogLv.Size = new System.Drawing.Size(154, 29);
            this.cmbLogLv.TabIndex = 17;
            this.cmbLogLv.Visible = false;
            this.cmbLogLv.SelectedIndexChanged += new System.EventHandler(this.cmbLogLv_SelectedIndexChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.label27.ForeColor = System.Drawing.Color.Blue;
            this.label27.Location = new System.Drawing.Point(668, 35);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(340, 26);
            this.label27.TabIndex = 16;
            this.label27.Text = "日志路径：当前目录下-->用户日志.txt";
            // 
            // txtLogKey
            // 
            this.txtLogKey.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtLogKey.Location = new System.Drawing.Point(148, 54);
            this.txtLogKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLogKey.Name = "txtLogKey";
            this.txtLogKey.Size = new System.Drawing.Size(154, 32);
            this.txtLogKey.TabIndex = 4;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(39, 29);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(95, 21);
            this.label29.TabIndex = 3;
            this.label29.Text = "日志等级：";
            this.label29.Visible = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label26.Location = new System.Drawing.Point(43, 57);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(97, 24);
            this.label26.TabIndex = 3;
            this.label26.Text = "日志结果:";
            // 
            // btnWriteLog
            // 
            this.btnWriteLog.AutoSize = true;
            this.btnWriteLog.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnWriteLog.Location = new System.Drawing.Point(154, 331);
            this.btnWriteLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnWriteLog.Name = "btnWriteLog";
            this.btnWriteLog.Size = new System.Drawing.Size(105, 47);
            this.btnWriteLog.TabIndex = 2;
            this.btnWriteLog.Text = "写日志";
            this.btnWriteLog.UseVisualStyleBackColor = true;
            this.btnWriteLog.Click += new System.EventHandler(this.btnWriteLog_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label25.Location = new System.Drawing.Point(44, 126);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(97, 24);
            this.label25.TabIndex = 0;
            this.label25.Text = "日志内容:";
            // 
            // txtLogContent
            // 
            this.txtLogContent.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtLogContent.Location = new System.Drawing.Point(148, 123);
            this.txtLogContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLogContent.Multiline = true;
            this.txtLogContent.Name = "txtLogContent";
            this.txtLogContent.Size = new System.Drawing.Size(846, 188);
            this.txtLogContent.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.listBox);
            this.panel2.Controls.Add(this.btnClearLogFile);
            this.panel2.Controls.Add(this.btnLoadLogFile);
            this.panel2.Controls.Add(this.label28);
            this.panel2.Controls.Add(this.txtLogInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.panel2.Location = new System.Drawing.Point(0, 385);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1021, 319);
            this.panel2.TabIndex = 5;
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.SystemColors.WindowText;
            this.listBox.Font = new System.Drawing.Font("Tahoma", 12F);
            this.listBox.ForeColor = System.Drawing.SystemColors.Window;
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 24;
            this.listBox.Location = new System.Drawing.Point(150, 94);
            this.listBox.Name = "listBox";
            this.listBox.ScrollAlwaysVisible = true;
            this.listBox.Size = new System.Drawing.Size(844, 220);
            this.listBox.TabIndex = 19;
            // 
            // btnClearLogFile
            // 
            this.btnClearLogFile.AutoSize = true;
            this.btnClearLogFile.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnClearLogFile.Location = new System.Drawing.Point(300, 25);
            this.btnClearLogFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClearLogFile.Name = "btnClearLogFile";
            this.btnClearLogFile.Size = new System.Drawing.Size(105, 47);
            this.btnClearLogFile.TabIndex = 2;
            this.btnClearLogFile.Text = "清空日志";
            this.btnClearLogFile.UseVisualStyleBackColor = true;
            this.btnClearLogFile.Visible = false;
            this.btnClearLogFile.Click += new System.EventHandler(this.btnClearLogFile_Click);
            // 
            // btnLoadLogFile
            // 
            this.btnLoadLogFile.AutoSize = true;
            this.btnLoadLogFile.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnLoadLogFile.Location = new System.Drawing.Point(154, 25);
            this.btnLoadLogFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLoadLogFile.Name = "btnLoadLogFile";
            this.btnLoadLogFile.Size = new System.Drawing.Size(105, 47);
            this.btnLoadLogFile.TabIndex = 2;
            this.btnLoadLogFile.Text = "加载日志";
            this.btnLoadLogFile.UseVisualStyleBackColor = true;
            this.btnLoadLogFile.Click += new System.EventHandler(this.btnLoadLogFile_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label28.Location = new System.Drawing.Point(44, 94);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(97, 24);
            this.label28.TabIndex = 0;
            this.label28.Text = "日志信息:";
            // 
            // txtLogInfo
            // 
            this.txtLogInfo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtLogInfo.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtLogInfo.ForeColor = System.Drawing.SystemColors.Window;
            this.txtLogInfo.Location = new System.Drawing.Point(149, 91);
            this.txtLogInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLogInfo.Multiline = true;
            this.txtLogInfo.Name = "txtLogInfo";
            this.txtLogInfo.ReadOnly = true;
            this.txtLogInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogInfo.Size = new System.Drawing.Size(845, 200);
            this.txtLogInfo.TabIndex = 1;
            this.txtLogInfo.Visible = false;
            // 
            // LogSystemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "LogSystemControl";
            this.Size = new System.Drawing.Size(1021, 704);
            this.Load += new System.EventHandler(this.LogSystem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbLogKey;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtLogKey;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnWriteLog;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtLogContent;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClearLogFile;
        private System.Windows.Forms.Button btnLoadLogFile;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cmbLogLv;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.TextBox txtLogInfo;
    }
}
