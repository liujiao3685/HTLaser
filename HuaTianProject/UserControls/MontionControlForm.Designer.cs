namespace HuaTianProject.UserControls
{
    partial class MontionControlForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnMontionParam = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.btnBackHome = new System.Windows.Forms.Button();
            this.txtWLocation = new System.Windows.Forms.TextBox();
            this.txtZLocation = new System.Windows.Forms.TextBox();
            this.txtYLocation = new System.Windows.Forms.TextBox();
            this.txtXLocation = new System.Windows.Forms.TextBox();
            this.labXAdd = new System.Windows.Forms.Label();
            this.labXDec = new System.Windows.Forms.Label();
            this.labWAdd = new System.Windows.Forms.Label();
            this.labWDec = new System.Windows.Forms.Label();
            this.labZAdd = new System.Windows.Forms.Label();
            this.labZDec = new System.Windows.Forms.Label();
            this.labYAdd = new System.Windows.Forms.Label();
            this.labYDec = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioRlt = new System.Windows.Forms.RadioButton();
            this.radioJog = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnMontionParam
            // 
            this.btnMontionParam.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMontionParam.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnMontionParam.Location = new System.Drawing.Point(176, 89);
            this.btnMontionParam.Name = "btnMontionParam";
            this.btnMontionParam.Size = new System.Drawing.Size(88, 37);
            this.btnMontionParam.TabIndex = 16;
            this.btnMontionParam.Text = "参数设置";
            this.btnMontionParam.UseVisualStyleBackColor = true;
            this.btnMontionParam.Click += new System.EventHandler(this.btnMontionParam_Click);
            // 
            // button11
            // 
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button11.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.button11.Location = new System.Drawing.Point(177, 21);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(88, 37);
            this.button11.TabIndex = 8;
            this.button11.Text = "绝对运动";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button10.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.button10.Location = new System.Drawing.Point(31, 89);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(88, 37);
            this.button10.TabIndex = 8;
            this.button10.Text = "手动IO";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // btnBackHome
            // 
            this.btnBackHome.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBackHome.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnBackHome.Location = new System.Drawing.Point(32, 21);
            this.btnBackHome.Name = "btnBackHome";
            this.btnBackHome.Size = new System.Drawing.Size(88, 37);
            this.btnBackHome.TabIndex = 8;
            this.btnBackHome.Text = "回零";
            this.btnBackHome.UseVisualStyleBackColor = true;
            this.btnBackHome.Click += new System.EventHandler(this.btnBackHome_Click);
            // 
            // txtWLocation
            // 
            this.txtWLocation.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtWLocation.Location = new System.Drawing.Point(76, 122);
            this.txtWLocation.Name = "txtWLocation";
            this.txtWLocation.ReadOnly = true;
            this.txtWLocation.Size = new System.Drawing.Size(148, 25);
            this.txtWLocation.TabIndex = 4;
            this.txtWLocation.Text = "0";
            this.txtWLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtZLocation
            // 
            this.txtZLocation.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtZLocation.Location = new System.Drawing.Point(76, 88);
            this.txtZLocation.Name = "txtZLocation";
            this.txtZLocation.ReadOnly = true;
            this.txtZLocation.Size = new System.Drawing.Size(148, 25);
            this.txtZLocation.TabIndex = 3;
            this.txtZLocation.Text = "0";
            this.txtZLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtYLocation
            // 
            this.txtYLocation.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtYLocation.Location = new System.Drawing.Point(76, 54);
            this.txtYLocation.Name = "txtYLocation";
            this.txtYLocation.ReadOnly = true;
            this.txtYLocation.Size = new System.Drawing.Size(148, 25);
            this.txtYLocation.TabIndex = 2;
            this.txtYLocation.Text = "0";
            this.txtYLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtXLocation
            // 
            this.txtXLocation.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtXLocation.Location = new System.Drawing.Point(76, 20);
            this.txtXLocation.Name = "txtXLocation";
            this.txtXLocation.ReadOnly = true;
            this.txtXLocation.Size = new System.Drawing.Size(148, 25);
            this.txtXLocation.TabIndex = 1;
            this.txtXLocation.Text = "0";
            this.txtXLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labXAdd
            // 
            this.labXAdd.AutoSize = true;
            this.labXAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.labXAdd.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labXAdd.Location = new System.Drawing.Point(243, 21);
            this.labXAdd.Name = "labXAdd";
            this.labXAdd.Size = new System.Drawing.Size(28, 20);
            this.labXAdd.TabIndex = 0;
            this.labXAdd.Text = "X+";
            this.labXAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labXAdd.Click += new System.EventHandler(this.labXAdd_Click);
            this.labXAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labXAdd_MouseDown);
            this.labXAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labXAdd_MouseUp);
            // 
            // labXDec
            // 
            this.labXDec.AutoSize = true;
            this.labXDec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.labXDec.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labXDec.Location = new System.Drawing.Point(31, 20);
            this.labXDec.Name = "labXDec";
            this.labXDec.Size = new System.Drawing.Size(24, 20);
            this.labXDec.TabIndex = 0;
            this.labXDec.Text = "X-";
            this.labXDec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labXDec.Click += new System.EventHandler(this.labXDec_Click);
            this.labXDec.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labXDec_MouseDown);
            this.labXDec.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labXDec_MouseUp);
            // 
            // labWAdd
            // 
            this.labWAdd.AutoSize = true;
            this.labWAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.labWAdd.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labWAdd.Location = new System.Drawing.Point(241, 127);
            this.labWAdd.Name = "labWAdd";
            this.labWAdd.Size = new System.Drawing.Size(33, 20);
            this.labWAdd.TabIndex = 0;
            this.labWAdd.Text = "W+";
            this.labWAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labWAdd.Click += new System.EventHandler(this.labWAdd_Click);
            this.labWAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labWAdd_MouseDown);
            this.labWAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labWAdd_MouseUp);
            // 
            // labWDec
            // 
            this.labWDec.AutoSize = true;
            this.labWDec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.labWDec.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labWDec.Location = new System.Drawing.Point(29, 126);
            this.labWDec.Name = "labWDec";
            this.labWDec.Size = new System.Drawing.Size(29, 20);
            this.labWDec.TabIndex = 0;
            this.labWDec.Text = "W-";
            this.labWDec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labWDec.Click += new System.EventHandler(this.labWDec_Click);
            this.labWDec.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labWDec_MouseDown);
            this.labWDec.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labWDec_MouseUp);
            // 
            // labZAdd
            // 
            this.labZAdd.AutoSize = true;
            this.labZAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.labZAdd.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labZAdd.Location = new System.Drawing.Point(243, 93);
            this.labZAdd.Name = "labZAdd";
            this.labZAdd.Size = new System.Drawing.Size(28, 20);
            this.labZAdd.TabIndex = 0;
            this.labZAdd.Text = "Z+";
            this.labZAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labZAdd.Click += new System.EventHandler(this.labZAdd_Click);
            this.labZAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labZAdd_MouseDown);
            this.labZAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labZAdd_MouseUp);
            // 
            // labZDec
            // 
            this.labZDec.AutoSize = true;
            this.labZDec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.labZDec.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labZDec.Location = new System.Drawing.Point(31, 92);
            this.labZDec.Name = "labZDec";
            this.labZDec.Size = new System.Drawing.Size(24, 20);
            this.labZDec.TabIndex = 0;
            this.labZDec.Text = "Z-";
            this.labZDec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labZDec.Click += new System.EventHandler(this.labZDec_Click);
            this.labZDec.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labZDec_MouseDown);
            this.labZDec.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labZDec_MouseUp);
            // 
            // labYAdd
            // 
            this.labYAdd.AutoSize = true;
            this.labYAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.labYAdd.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labYAdd.Location = new System.Drawing.Point(244, 59);
            this.labYAdd.Name = "labYAdd";
            this.labYAdd.Size = new System.Drawing.Size(27, 20);
            this.labYAdd.TabIndex = 0;
            this.labYAdd.Text = "Y+";
            this.labYAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labYAdd.Click += new System.EventHandler(this.labYAdd_Click);
            this.labYAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labYAdd_MouseDown);
            this.labYAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labYAdd_MouseUp);
            // 
            // labYDec
            // 
            this.labYDec.AutoSize = true;
            this.labYDec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.labYDec.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labYDec.Location = new System.Drawing.Point(32, 58);
            this.labYDec.Name = "labYDec";
            this.labYDec.Size = new System.Drawing.Size(23, 20);
            this.labYDec.TabIndex = 0;
            this.labYDec.Text = "Y-";
            this.labYDec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labYDec.Click += new System.EventHandler(this.labYDec_Click);
            this.labYDec.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labYDec_MouseDown);
            this.labYDec.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labYDec_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioRlt);
            this.groupBox1.Controls.Add(this.radioJog);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.groupBox1.Location = new System.Drawing.Point(26, 167);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 84);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "运动模式";
            // 
            // radioRlt
            // 
            this.radioRlt.AutoSize = true;
            this.radioRlt.Location = new System.Drawing.Point(144, 37);
            this.radioRlt.Margin = new System.Windows.Forms.Padding(4);
            this.radioRlt.Name = "radioRlt";
            this.radioRlt.Size = new System.Drawing.Size(57, 24);
            this.radioRlt.TabIndex = 1;
            this.radioRlt.Text = "相对";
            this.radioRlt.UseVisualStyleBackColor = true;
            // 
            // radioJog
            // 
            this.radioJog.AutoSize = true;
            this.radioJog.Checked = true;
            this.radioJog.Location = new System.Drawing.Point(34, 37);
            this.radioJog.Margin = new System.Windows.Forms.Padding(4);
            this.radioJog.Name = "radioJog";
            this.radioJog.Size = new System.Drawing.Size(53, 24);
            this.radioJog.TabIndex = 2;
            this.radioJog.TabStop = true;
            this.radioJog.Text = "Jog";
            this.radioJog.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBackHome);
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.button11);
            this.panel1.Controls.Add(this.btnMontionParam);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 463);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 144);
            this.panel1.TabIndex = 19;
            // 
            // MontionControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtXLocation);
            this.Controls.Add(this.txtWLocation);
            this.Controls.Add(this.txtZLocation);
            this.Controls.Add(this.txtYLocation);
            this.Controls.Add(this.labXAdd);
            this.Controls.Add(this.labXDec);
            this.Controls.Add(this.labWAdd);
            this.Controls.Add(this.labWDec);
            this.Controls.Add(this.labZAdd);
            this.Controls.Add(this.labZDec);
            this.Controls.Add(this.labYAdd);
            this.Controls.Add(this.labYDec);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MontionControlForm";
            this.Size = new System.Drawing.Size(305, 607);
            this.Load += new System.EventHandler(this.MontionControlForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labYDec;
        private System.Windows.Forms.Label labXDec;
        private System.Windows.Forms.Label labZDec;
        private System.Windows.Forms.Label labWDec;
        private System.Windows.Forms.TextBox txtXLocation;
        private System.Windows.Forms.TextBox txtYLocation;
        private System.Windows.Forms.TextBox txtZLocation;
        private System.Windows.Forms.TextBox txtWLocation;
        private System.Windows.Forms.Label labYAdd;
        private System.Windows.Forms.Label labZAdd;
        private System.Windows.Forms.Label labWAdd;
        private System.Windows.Forms.Label labXAdd;
        private System.Windows.Forms.Button btnBackHome;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button btnMontionParam;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioRlt;
        private System.Windows.Forms.RadioButton radioJog;
        private System.Windows.Forms.Panel panel1;

    }
}
