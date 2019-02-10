namespace WindowsFormsApplication1.UI
{
    partial class FormIniFile
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
            this.lstKeys = new System.Windows.Forms.ListBox();
            this.lstValues = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnOpen = new HslCommunication.Controls.UserButton();
            this.label2 = new System.Windows.Forms.Label();
            this.userButton1 = new HslCommunication.Controls.UserButton();
            this.SuspendLayout();
            // 
            // lstKeys
            // 
            this.lstKeys.FormattingEnabled = true;
            this.lstKeys.ItemHeight = 15;
            this.lstKeys.Location = new System.Drawing.Point(12, 29);
            this.lstKeys.Name = "lstKeys";
            this.lstKeys.Size = new System.Drawing.Size(269, 304);
            this.lstKeys.TabIndex = 0;
            // 
            // lstValues
            // 
            this.lstValues.FormattingEnabled = true;
            this.lstValues.ItemHeight = 15;
            this.lstValues.Location = new System.Drawing.Point(340, 29);
            this.lstValues.Name = "lstValues";
            this.lstValues.Size = new System.Drawing.Size(355, 304);
            this.lstValues.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(287, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "====>";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(140, 375);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(546, 25);
            this.txtPath.TabIndex = 3;
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.Transparent;
            this.btnOpen.CustomerInformation = "";
            this.btnOpen.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnOpen.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnOpen.Location = new System.Drawing.Point(149, 442);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(154, 47);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.UIText = "打开ini文件";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 379);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ini文件路径:";
            // 
            // userButton1
            // 
            this.userButton1.BackColor = System.Drawing.Color.Transparent;
            this.userButton1.CustomerInformation = "";
            this.userButton1.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.userButton1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.userButton1.Location = new System.Drawing.Point(421, 442);
            this.userButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userButton1.Name = "userButton1";
            this.userButton1.Size = new System.Drawing.Size(154, 47);
            this.userButton1.TabIndex = 6;
            this.userButton1.UIText = "Test";
            this.userButton1.Click += new System.EventHandler(this.userButton1_Click);
            // 
            // FormIniFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 514);
            this.Controls.Add(this.userButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstValues);
            this.Controls.Add(this.lstKeys);
            this.Name = "FormIniFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormIniFile";
            this.Load += new System.EventHandler(this.FormIniFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstKeys;
        private System.Windows.Forms.ListBox lstValues;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private HslCommunication.Controls.UserButton btnOpen;
        private System.Windows.Forms.Label label2;
        private HslCommunication.Controls.UserButton userButton1;
    }
}