namespace HuaTianProject.UI
{
    partial class LaserControlForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.cmbChannel = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.rabEnable = new System.Windows.Forms.RadioButton();
            this.rabUnEnable = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFreq = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDuty = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOutPutVol = new System.Windows.Forms.NumericUpDown();
            this.btnDARun = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDAChannel = new System.Windows.Forms.ComboBox();
            this.rabDAEnable = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rabDADisable = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuty)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutPutVol)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.cmbChannel);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.rabEnable);
            this.groupBox1.Controls.Add(this.rabUnEnable);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFreq);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDuty);
            this.groupBox1.Location = new System.Drawing.Point(17, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 267);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置PWM参数";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(73, 213);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(84, 32);
            this.btnStart.TabIndex = 12;
            this.btnStart.Text = "启动";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cmbChannel
            // 
            this.cmbChannel.FormattingEnabled = true;
            this.cmbChannel.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cmbChannel.Location = new System.Drawing.Point(121, 77);
            this.cmbChannel.Name = "cmbChannel";
            this.cmbChannel.Size = new System.Drawing.Size(47, 22);
            this.cmbChannel.TabIndex = 11;
            this.cmbChannel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbChannel_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(200, 122);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 14);
            this.label13.TabIndex = 8;
            this.label13.Text = "%";
            // 
            // rabEnable
            // 
            this.rabEnable.AutoSize = true;
            this.rabEnable.Checked = true;
            this.rabEnable.Location = new System.Drawing.Point(36, 40);
            this.rabEnable.Name = "rabEnable";
            this.rabEnable.Size = new System.Drawing.Size(49, 18);
            this.rabEnable.TabIndex = 1;
            this.rabEnable.TabStop = true;
            this.rabEnable.Text = "使能";
            this.rabEnable.UseVisualStyleBackColor = true;
            // 
            // rabUnEnable
            // 
            this.rabUnEnable.AutoSize = true;
            this.rabUnEnable.Location = new System.Drawing.Point(121, 40);
            this.rabUnEnable.Name = "rabUnEnable";
            this.rabUnEnable.Size = new System.Drawing.Size(49, 18);
            this.rabUnEnable.TabIndex = 0;
            this.rabUnEnable.Text = "禁止";
            this.rabUnEnable.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Hz";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "PWM通道：";
            // 
            // txtFreq
            // 
            this.txtFreq.Location = new System.Drawing.Point(121, 163);
            this.txtFreq.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.txtFreq.Name = "txtFreq";
            this.txtFreq.Size = new System.Drawing.Size(73, 22);
            this.txtFreq.TabIndex = 5;
            this.txtFreq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFreq.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "频率：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "占空比：";
            // 
            // txtDuty
            // 
            this.txtDuty.Location = new System.Drawing.Point(121, 120);
            this.txtDuty.Name = "txtDuty";
            this.txtDuty.Size = new System.Drawing.Size(73, 22);
            this.txtDuty.TabIndex = 3;
            this.txtDuty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDuty.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtOutPutVol);
            this.groupBox2.Controls.Add(this.btnDARun);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cmbDAChannel);
            this.groupBox2.Controls.Add(this.rabDAEnable);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.rabDADisable);
            this.groupBox2.Location = new System.Drawing.Point(289, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(219, 202);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DA设置";
            // 
            // txtOutPutVol
            // 
            this.txtOutPutVol.Location = new System.Drawing.Point(102, 104);
            this.txtOutPutVol.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtOutPutVol.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.txtOutPutVol.Name = "txtOutPutVol";
            this.txtOutPutVol.Size = new System.Drawing.Size(69, 22);
            this.txtOutPutVol.TabIndex = 16;
            this.txtOutPutVol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnDARun
            // 
            this.btnDARun.Location = new System.Drawing.Point(64, 152);
            this.btnDARun.Name = "btnDARun";
            this.btnDARun.Size = new System.Drawing.Size(84, 32);
            this.btnDARun.TabIndex = 15;
            this.btnDARun.Text = "启动";
            this.btnDARun.UseVisualStyleBackColor = true;
            this.btnDARun.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(177, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 14);
            this.label7.TabIndex = 13;
            this.label7.Text = "V";
            // 
            // cmbDAChannel
            // 
            this.cmbDAChannel.FormattingEnabled = true;
            this.cmbDAChannel.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cmbDAChannel.Location = new System.Drawing.Point(102, 66);
            this.cmbDAChannel.Name = "cmbDAChannel";
            this.cmbDAChannel.Size = new System.Drawing.Size(61, 22);
            this.cmbDAChannel.TabIndex = 14;
            this.cmbDAChannel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbChannel_KeyPress);
            // 
            // rabDAEnable
            // 
            this.rabDAEnable.AutoSize = true;
            this.rabDAEnable.Checked = true;
            this.rabDAEnable.Location = new System.Drawing.Point(27, 34);
            this.rabDAEnable.Name = "rabDAEnable";
            this.rabDAEnable.Size = new System.Drawing.Size(49, 18);
            this.rabDAEnable.TabIndex = 14;
            this.rabDAEnable.TabStop = true;
            this.rabDAEnable.Text = "使能";
            this.rabDAEnable.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 14);
            this.label6.TabIndex = 13;
            this.label6.Text = "输出电压：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 14);
            this.label5.TabIndex = 13;
            this.label5.Text = "DA通道：";
            // 
            // rabDADisable
            // 
            this.rabDADisable.AutoSize = true;
            this.rabDADisable.Location = new System.Drawing.Point(99, 34);
            this.rabDADisable.Name = "rabDADisable";
            this.rabDADisable.Size = new System.Drawing.Size(49, 18);
            this.rabDADisable.TabIndex = 13;
            this.rabDADisable.Text = "禁止";
            this.rabDADisable.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LaserControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 305);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "LaserControlForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "激光控制";
            this.Load += new System.EventHandler(this.LaserControlForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuty)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutPutVol)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rabUnEnable;
        private System.Windows.Forms.RadioButton rabEnable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtDuty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtFreq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbChannel;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnDARun;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDAChannel;
        private System.Windows.Forms.RadioButton rabDAEnable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rabDADisable;
        private System.Windows.Forms.NumericUpDown txtOutPutVol;
        private System.Windows.Forms.Timer timer1;
    }
}