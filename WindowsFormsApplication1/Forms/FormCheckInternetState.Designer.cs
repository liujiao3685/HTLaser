namespace WindowsFormsApplication1.Forms
{
    partial class FormCheckInternetState
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
            this.userButton1 = new HslCommunication.Controls.UserButton();
            this.lanState = new HslCommunication.Controls.UserLantern();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // userButton1
            // 
            this.userButton1.BackColor = System.Drawing.Color.Transparent;
            this.userButton1.CustomerInformation = "";
            this.userButton1.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.userButton1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.userButton1.Location = new System.Drawing.Point(308, 168);
            this.userButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userButton1.Name = "userButton1";
            this.userButton1.Size = new System.Drawing.Size(125, 50);
            this.userButton1.TabIndex = 0;
            this.userButton1.UIText = "检查网络连接";
            this.userButton1.Click += new System.EventHandler(this.userButton1_Click);
            // 
            // lanState
            // 
            this.lanState.BackColor = System.Drawing.Color.Transparent;
            this.lanState.LanternBackground = System.Drawing.Color.Red;
            this.lanState.Location = new System.Drawing.Point(53, 45);
            this.lanState.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lanState.Name = "lanState";
            this.lanState.Size = new System.Drawing.Size(200, 188);
            this.lanState.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(295, 70);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(181, 25);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "172.16.22.80";
            // 
            // FormCheckInternetState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 531);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lanState);
            this.Controls.Add(this.userButton1);
            this.Name = "FormCheckInternetState";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormInternetState";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HslCommunication.Controls.UserButton userButton1;
        private HslCommunication.Controls.UserLantern lanState;
        private System.Windows.Forms.TextBox textBox1;
    }
}