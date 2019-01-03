namespace HuaTianProject.UI
{
    partial class ManualIOForm
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
            this.chkSideBlown = new System.Windows.Forms.CheckBox();
            this.chkCoaxial = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLaser = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.btnConxial = new System.Windows.Forms.Button();
            this.btnSideBlown = new System.Windows.Forms.Button();
            this.btnGuangzha = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkSideBlown
            // 
            this.chkSideBlown.AutoSize = true;
            this.chkSideBlown.Location = new System.Drawing.Point(13, 14);
            this.chkSideBlown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkSideBlown.Name = "chkSideBlown";
            this.chkSideBlown.Size = new System.Drawing.Size(109, 25);
            this.chkSideBlown.TabIndex = 0;
            this.chkSideBlown.Text = "使用侧吹气";
            this.chkSideBlown.UseVisualStyleBackColor = true;
            // 
            // chkCoaxial
            // 
            this.chkCoaxial.AutoSize = true;
            this.chkCoaxial.Location = new System.Drawing.Point(13, 49);
            this.chkCoaxial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkCoaxial.Name = "chkCoaxial";
            this.chkCoaxial.Size = new System.Drawing.Size(125, 25);
            this.chkCoaxial.TabIndex = 0;
            this.chkCoaxial.Text = "使用同轴吹气";
            this.chkCoaxial.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLaser);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Location = new System.Drawing.Point(13, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 244);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnLaser
            // 
            this.btnLaser.AutoSize = true;
            this.btnLaser.Location = new System.Drawing.Point(64, 180);
            this.btnLaser.Name = "btnLaser";
            this.btnLaser.Size = new System.Drawing.Size(153, 46);
            this.btnLaser.TabIndex = 6;
            this.btnLaser.Text = "激光";
            this.btnLaser.UseVisualStyleBackColor = true;
            this.btnLaser.Click += new System.EventHandler(this.btnLaser_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(145, 130);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 29);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "间隔时间(ms)";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(16, 98);
            this.checkBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(189, 25);
            this.checkBox5.TabIndex = 3;
            this.checkBox5.Text = "间隔时间后自动关激光";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(16, 64);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(134, 25);
            this.checkBox3.TabIndex = 1;
            this.checkBox3.Text = "使用激光通道2";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(16, 30);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(134, 25);
            this.checkBox4.TabIndex = 2;
            this.checkBox4.Text = "使用激光通道1";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // btnConxial
            // 
            this.btnConxial.AutoSize = true;
            this.btnConxial.Location = new System.Drawing.Point(321, 28);
            this.btnConxial.Name = "btnConxial";
            this.btnConxial.Size = new System.Drawing.Size(153, 46);
            this.btnConxial.TabIndex = 7;
            this.btnConxial.Text = "同轴吹";
            this.btnConxial.UseVisualStyleBackColor = true;
            this.btnConxial.Click += new System.EventHandler(this.btnConxial_Click);
            // 
            // btnSideBlown
            // 
            this.btnSideBlown.AutoSize = true;
            this.btnSideBlown.Location = new System.Drawing.Point(321, 91);
            this.btnSideBlown.Name = "btnSideBlown";
            this.btnSideBlown.Size = new System.Drawing.Size(153, 46);
            this.btnSideBlown.TabIndex = 7;
            this.btnSideBlown.Text = "侧吹";
            this.btnSideBlown.UseVisualStyleBackColor = true;
            this.btnSideBlown.Click += new System.EventHandler(this.btnSideBlown_Click);
            // 
            // btnGuangzha
            // 
            this.btnGuangzha.AutoSize = true;
            this.btnGuangzha.Location = new System.Drawing.Point(321, 154);
            this.btnGuangzha.Name = "btnGuangzha";
            this.btnGuangzha.Size = new System.Drawing.Size(153, 46);
            this.btnGuangzha.TabIndex = 8;
            this.btnGuangzha.Text = "光闸";
            this.btnGuangzha.UseVisualStyleBackColor = true;
            this.btnGuangzha.Click += new System.EventHandler(this.btnGuangzha_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(321, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 46);
            this.button1.TabIndex = 8;
            this.button1.Text = "Cooling";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.Location = new System.Drawing.Point(321, 280);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 46);
            this.button2.TabIndex = 8;
            this.button2.Text = "Grating";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.AutoSize = true;
            this.button5.Location = new System.Drawing.Point(321, 343);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(153, 46);
            this.button5.TabIndex = 8;
            this.button5.Text = "Reserve";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(158, 359);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(141, 25);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "启动软件即输出";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // ManualIOForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 420);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnGuangzha);
            this.Controls.Add(this.btnSideBlown);
            this.Controls.Add(this.btnConxial);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkCoaxial);
            this.Controls.Add(this.chkSideBlown);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManualIOForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "手动IO";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSideBlown;
        private System.Windows.Forms.CheckBox chkCoaxial;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnLaser;
        private System.Windows.Forms.Button btnConxial;
        private System.Windows.Forms.Button btnSideBlown;
        private System.Windows.Forms.Button btnGuangzha;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}