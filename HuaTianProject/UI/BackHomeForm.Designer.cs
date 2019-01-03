namespace HuaTianProject.UI
{
    partial class BackHomeForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rabW = new System.Windows.Forms.RadioButton();
            this.rabZ = new System.Windows.Forms.RadioButton();
            this.rabY = new System.Windows.Forms.RadioButton();
            this.rabX = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnOneKeyBack = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rabW);
            this.groupBox2.Controls.Add(this.rabZ);
            this.groupBox2.Controls.Add(this.rabY);
            this.groupBox2.Controls.Add(this.rabX);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupBox2.Location = new System.Drawing.Point(23, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 175);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "回零方式";
            // 
            // rabW
            // 
            this.rabW.AutoSize = true;
            this.rabW.Location = new System.Drawing.Point(137, 110);
            this.rabW.Name = "rabW";
            this.rabW.Size = new System.Drawing.Size(60, 25);
            this.rabW.TabIndex = 3;
            this.rabW.Text = "W轴";
            this.rabW.UseVisualStyleBackColor = true;
            // 
            // rabZ
            // 
            this.rabZ.AutoSize = true;
            this.rabZ.Location = new System.Drawing.Point(38, 112);
            this.rabZ.Name = "rabZ";
            this.rabZ.Size = new System.Drawing.Size(54, 25);
            this.rabZ.TabIndex = 2;
            this.rabZ.Text = "Z轴";
            this.rabZ.UseVisualStyleBackColor = true;
            // 
            // rabY
            // 
            this.rabY.AutoSize = true;
            this.rabY.Location = new System.Drawing.Point(137, 48);
            this.rabY.Name = "rabY";
            this.rabY.Size = new System.Drawing.Size(54, 25);
            this.rabY.TabIndex = 1;
            this.rabY.Text = "Y轴";
            this.rabY.UseVisualStyleBackColor = true;
            // 
            // rabX
            // 
            this.rabX.AutoSize = true;
            this.rabX.Checked = true;
            this.rabX.Location = new System.Drawing.Point(38, 48);
            this.rabX.Name = "rabX";
            this.rabX.Size = new System.Drawing.Size(54, 25);
            this.rabX.TabIndex = 0;
            this.rabX.TabStop = true;
            this.rabX.Text = "X轴";
            this.rabX.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btnStart.Location = new System.Drawing.Point(312, 37);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(114, 51);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "启动";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btnExit.Location = new System.Drawing.Point(301, 234);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(114, 51);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOneKeyBack
            // 
            this.btnOneKeyBack.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btnOneKeyBack.Location = new System.Drawing.Point(61, 238);
            this.btnOneKeyBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOneKeyBack.Name = "btnOneKeyBack";
            this.btnOneKeyBack.Size = new System.Drawing.Size(113, 47);
            this.btnOneKeyBack.TabIndex = 9;
            this.btnOneKeyBack.Text = "一键回零";
            this.btnOneKeyBack.UseVisualStyleBackColor = true;
            this.btnOneKeyBack.Click += new System.EventHandler(this.btnOneKeyBack_Click);
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btnStop.Location = new System.Drawing.Point(312, 133);
            this.btnStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(114, 51);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // BackHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 322);
            this.Controls.Add(this.btnOneKeyBack);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BackHomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BackHomeForm_FormClosing);
            this.Load += new System.EventHandler(this.BackHomeForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RadioButton rabW;
        private System.Windows.Forms.RadioButton rabZ;
        private System.Windows.Forms.RadioButton rabY;
        private System.Windows.Forms.RadioButton rabX;
        private System.Windows.Forms.Button btnOneKeyBack;
        private System.Windows.Forms.Button btnStop;
    }
}