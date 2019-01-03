namespace WindowsFormsApplication1
{
    partial class HslCurveForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new HslCommunication.Controls.UserButton();
            this.userCurveRight = new HslCommunication.Controls.UserCurve();
            this.userButton1 = new HslCommunication.Controls.UserButton();
            this.userButton2 = new HslCommunication.Controls.UserButton();
            this.userButton3 = new HslCommunication.Controls.UserButton();
            this.userCurveLeft = new HslCommunication.Controls.UserCurve();
            this.userButton4 = new HslCommunication.Controls.UserButton();
            this.userButton5 = new HslCommunication.Controls.UserButton();
            this.userButton6 = new HslCommunication.Controls.UserButton();
            this.userButton7 = new HslCommunication.Controls.UserButton();
            this.userButton8 = new HslCommunication.Controls.UserButton();
            this.userButton9 = new HslCommunication.Controls.UserButton();
            this.userButton10 = new HslCommunication.Controls.UserButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.CustomerInformation = "";
            this.button1.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button1.Location = new System.Drawing.Point(73, 493);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 59);
            this.button1.TabIndex = 0;
            this.button1.Click += new System.EventHandler(this.userButton1_Click);
            // 
            // userCurveRight
            // 
            this.userCurveRight.BackColor = System.Drawing.Color.Black;
            this.userCurveRight.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userCurveRight.Location = new System.Drawing.Point(511, 23);
            this.userCurveRight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userCurveRight.Name = "userCurveRight";
            this.userCurveRight.Size = new System.Drawing.Size(599, 428);
            this.userCurveRight.TabIndex = 1;
            this.userCurveRight.ValueMaxLeft = 200F;
            this.userCurveRight.ValueMaxRight = 10F;
            this.userCurveRight.ValueSegment = 10;
            // 
            // userButton1
            // 
            this.userButton1.BackColor = System.Drawing.Color.Transparent;
            this.userButton1.CustomerInformation = "";
            this.userButton1.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.userButton1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.userButton1.Location = new System.Drawing.Point(268, 493);
            this.userButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userButton1.Name = "userButton1";
            this.userButton1.Size = new System.Drawing.Size(151, 59);
            this.userButton1.TabIndex = 2;
            this.userButton1.UIText = "更新";
            this.userButton1.Click += new System.EventHandler(this.userButton1_Click_1);
            // 
            // userButton2
            // 
            this.userButton2.BackColor = System.Drawing.Color.Transparent;
            this.userButton2.CustomerInformation = "";
            this.userButton2.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.userButton2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.userButton2.Location = new System.Drawing.Point(536, 465);
            this.userButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userButton2.Name = "userButton2";
            this.userButton2.Size = new System.Drawing.Size(145, 59);
            this.userButton2.TabIndex = 3;
            this.userButton2.UIText = "十二个月销售";
            this.userButton2.Click += new System.EventHandler(this.userButton2_Click);
            // 
            // userButton3
            // 
            this.userButton3.BackColor = System.Drawing.Color.Transparent;
            this.userButton3.CustomerInformation = "";
            this.userButton3.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.userButton3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.userButton3.Location = new System.Drawing.Point(721, 465);
            this.userButton3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userButton3.Name = "userButton3";
            this.userButton3.Size = new System.Drawing.Size(145, 59);
            this.userButton3.TabIndex = 4;
            this.userButton3.UIText = "RightCurve";
            this.userButton3.Click += new System.EventHandler(this.userButton3_Click);
            // 
            // userCurveLeft
            // 
            this.userCurveLeft.BackColor = System.Drawing.Color.Transparent;
            this.userCurveLeft.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userCurveLeft.Location = new System.Drawing.Point(22, 41);
            this.userCurveLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userCurveLeft.Name = "userCurveLeft";
            this.userCurveLeft.Size = new System.Drawing.Size(481, 410);
            this.userCurveLeft.TabIndex = 5;
            this.userCurveLeft.ValueMaxLeft = 200F;
            this.userCurveLeft.ValueMaxRight = 200F;
            this.userCurveLeft.ValueSegment = 10;
            // 
            // userButton4
            // 
            this.userButton4.BackColor = System.Drawing.Color.Transparent;
            this.userButton4.CustomerInformation = "";
            this.userButton4.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.userButton4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.userButton4.Location = new System.Drawing.Point(901, 465);
            this.userButton4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userButton4.Name = "userButton4";
            this.userButton4.Size = new System.Drawing.Size(145, 59);
            this.userButton4.TabIndex = 6;
            this.userButton4.UIText = "动态坐标轴";
            this.userButton4.Click += new System.EventHandler(this.userButton4_Click);
            // 
            // userButton5
            // 
            this.userButton5.BackColor = System.Drawing.Color.Transparent;
            this.userButton5.CustomerInformation = "";
            this.userButton5.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.userButton5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.userButton5.Location = new System.Drawing.Point(536, 570);
            this.userButton5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userButton5.Name = "userButton5";
            this.userButton5.Size = new System.Drawing.Size(145, 59);
            this.userButton5.TabIndex = 7;
            this.userButton5.UIText = "初始化曲线";
            this.userButton5.Click += new System.EventHandler(this.userButton5_Click);
            // 
            // userButton6
            // 
            this.userButton6.BackColor = System.Drawing.Color.Transparent;
            this.userButton6.CustomerInformation = "";
            this.userButton6.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.userButton6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.userButton6.Location = new System.Drawing.Point(721, 570);
            this.userButton6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userButton6.Name = "userButton6";
            this.userButton6.Size = new System.Drawing.Size(145, 59);
            this.userButton6.TabIndex = 8;
            this.userButton6.UIText = "动态加载";
            this.userButton6.Click += new System.EventHandler(this.userButton6_Click);
            // 
            // userButton7
            // 
            this.userButton7.BackColor = System.Drawing.Color.Transparent;
            this.userButton7.CustomerInformation = "";
            this.userButton7.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.userButton7.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.userButton7.Location = new System.Drawing.Point(901, 570);
            this.userButton7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userButton7.Name = "userButton7";
            this.userButton7.Size = new System.Drawing.Size(145, 59);
            this.userButton7.TabIndex = 9;
            this.userButton7.UIText = "动态加载-拉伸模式";
            this.userButton7.Click += new System.EventHandler(this.userButton7_Click);
            // 
            // userButton8
            // 
            this.userButton8.BackColor = System.Drawing.Color.Transparent;
            this.userButton8.CustomerInformation = "";
            this.userButton8.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.userButton8.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.userButton8.Location = new System.Drawing.Point(721, 660);
            this.userButton8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userButton8.Name = "userButton8";
            this.userButton8.Size = new System.Drawing.Size(145, 59);
            this.userButton8.TabIndex = 10;
            this.userButton8.UIText = "多曲线，双坐标";
            this.userButton8.Click += new System.EventHandler(this.userButton8_Click);
            // 
            // userButton9
            // 
            this.userButton9.BackColor = System.Drawing.Color.Transparent;
            this.userButton9.CustomerInformation = "";
            this.userButton9.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.userButton9.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.userButton9.Location = new System.Drawing.Point(536, 660);
            this.userButton9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userButton9.Name = "userButton9";
            this.userButton9.Size = new System.Drawing.Size(145, 59);
            this.userButton9.TabIndex = 11;
            this.userButton9.UIText = "多曲线，双坐标（初始化）";
            this.userButton9.Click += new System.EventHandler(this.userButton9_Click);
            // 
            // userButton10
            // 
            this.userButton10.BackColor = System.Drawing.Color.Transparent;
            this.userButton10.CustomerInformation = "";
            this.userButton10.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.userButton10.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.userButton10.Location = new System.Drawing.Point(901, 660);
            this.userButton10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userButton10.Name = "userButton10";
            this.userButton10.Size = new System.Drawing.Size(145, 59);
            this.userButton10.TabIndex = 12;
            this.userButton10.UIText = "辅助线";
            this.userButton10.Click += new System.EventHandler(this.userButton10_Click);
            // 
            // HslCurveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 733);
            this.Controls.Add(this.userCurveRight);
            this.Controls.Add(this.userButton10);
            this.Controls.Add(this.userButton9);
            this.Controls.Add(this.userButton8);
            this.Controls.Add(this.userButton7);
            this.Controls.Add(this.userButton6);
            this.Controls.Add(this.userButton5);
            this.Controls.Add(this.userButton4);
            this.Controls.Add(this.userCurveLeft);
            this.Controls.Add(this.userButton3);
            this.Controls.Add(this.userButton2);
            this.Controls.Add(this.userButton1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HslCurveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HslCommunication.Controls.UserButton button1;
        private HslCommunication.Controls.UserCurve userCurveRight;
        private HslCommunication.Controls.UserButton userButton1;
        private HslCommunication.Controls.UserButton userButton2;
        private HslCommunication.Controls.UserButton userButton3;
        private HslCommunication.Controls.UserCurve userCurveLeft;
        private HslCommunication.Controls.UserButton userButton4;
        private HslCommunication.Controls.UserButton userButton5;
        private HslCommunication.Controls.UserButton userButton6;
        private HslCommunication.Controls.UserButton userButton7;
        private HslCommunication.Controls.UserButton userButton8;
        private HslCommunication.Controls.UserButton userButton9;
        private HslCommunication.Controls.UserButton userButton10;
    }
}

