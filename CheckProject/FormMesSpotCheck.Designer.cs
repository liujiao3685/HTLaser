namespace CheckProject
{
    partial class FormMesSpotCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMesSpotCheck));
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numWeldPressure = new System.Windows.Forms.NumericUpDown();
            this.numWeldSpeed = new System.Windows.Forms.NumericUpDown();
            this.numWeldFlow = new System.Windows.Forms.NumericUpDown();
            this.numWeldPower = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSpotCheck = new HslCommunication.Controls.UserButton();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldPressure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldPower)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtEmpNo.Location = new System.Drawing.Point(153, 367);
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(217, 38);
            this.txtEmpNo.TabIndex = 57;
            this.txtEmpNo.Text = "No001";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label9.Location = new System.Drawing.Point(24, 371);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 30);
            this.label9.TabIndex = 56;
            this.label9.Text = "员工编号:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label4.Location = new System.Drawing.Point(359, 225);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 30);
            this.label4.TabIndex = 52;
            this.label4.Text = "L/min";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label8.Location = new System.Drawing.Point(800, 223);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 30);
            this.label8.TabIndex = 53;
            this.label8.Text = "MPa";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label7.Location = new System.Drawing.Point(800, 68);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 30);
            this.label7.TabIndex = 54;
            this.label7.Text = "mm/s";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label1.Location = new System.Drawing.Point(359, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 30);
            this.label1.TabIndex = 55;
            this.label1.Text = "W";
            // 
            // numWeldPressure
            // 
            this.numWeldPressure.DecimalPlaces = 2;
            this.numWeldPressure.Font = new System.Drawing.Font("Tahoma", 15F);
            this.numWeldPressure.Location = new System.Drawing.Point(594, 218);
            this.numWeldPressure.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWeldPressure.Name = "numWeldPressure";
            this.numWeldPressure.Size = new System.Drawing.Size(201, 38);
            this.numWeldPressure.TabIndex = 51;
            this.numWeldPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numWeldPressure.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numWeldSpeed
            // 
            this.numWeldSpeed.DecimalPlaces = 2;
            this.numWeldSpeed.Font = new System.Drawing.Font("Tahoma", 15F);
            this.numWeldSpeed.Location = new System.Drawing.Point(594, 64);
            this.numWeldSpeed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWeldSpeed.Name = "numWeldSpeed";
            this.numWeldSpeed.Size = new System.Drawing.Size(201, 38);
            this.numWeldSpeed.TabIndex = 50;
            this.numWeldSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numWeldSpeed.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numWeldFlow
            // 
            this.numWeldFlow.DecimalPlaces = 2;
            this.numWeldFlow.Font = new System.Drawing.Font("Tahoma", 15F);
            this.numWeldFlow.Location = new System.Drawing.Point(151, 222);
            this.numWeldFlow.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWeldFlow.Name = "numWeldFlow";
            this.numWeldFlow.Size = new System.Drawing.Size(201, 38);
            this.numWeldFlow.TabIndex = 49;
            this.numWeldFlow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numWeldFlow.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numWeldPower
            // 
            this.numWeldPower.DecimalPlaces = 2;
            this.numWeldPower.Font = new System.Drawing.Font("Tahoma", 15F);
            this.numWeldPower.Location = new System.Drawing.Point(151, 66);
            this.numWeldPower.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWeldPower.Name = "numWeldPower";
            this.numWeldPower.Size = new System.Drawing.Size(201, 38);
            this.numWeldPower.TabIndex = 48;
            this.numWeldPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numWeldPower.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label2.Location = new System.Drawing.Point(22, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 30);
            this.label2.TabIndex = 44;
            this.label2.Text = "焊接功率:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label3.Location = new System.Drawing.Point(490, 221);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 30);
            this.label3.TabIndex = 45;
            this.label3.Text = "压力值:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label5.Location = new System.Drawing.Point(47, 226);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 30);
            this.label5.TabIndex = 47;
            this.label5.Text = "流量值:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label6.Location = new System.Drawing.Point(465, 66);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 30);
            this.label6.TabIndex = 46;
            this.label6.Text = "焊接转速:";
            // 
            // btnSpotCheck
            // 
            this.btnSpotCheck.BackColor = System.Drawing.Color.Transparent;
            this.btnSpotCheck.CustomerInformation = "";
            this.btnSpotCheck.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnSpotCheck.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.btnSpotCheck.Location = new System.Drawing.Point(549, 347);
            this.btnSpotCheck.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnSpotCheck.Name = "btnSpotCheck";
            this.btnSpotCheck.Size = new System.Drawing.Size(205, 83);
            this.btnSpotCheck.TabIndex = 43;
            this.btnSpotCheck.UIText = "点检";
            this.btnSpotCheck.Click += new System.EventHandler(this.btnSpotCheck_Click);
            // 
            // FormMesSpotCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 481);
            this.Controls.Add(this.txtEmpNo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numWeldPressure);
            this.Controls.Add(this.numWeldSpeed);
            this.Controls.Add(this.numWeldFlow);
            this.Controls.Add(this.numWeldPower);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSpotCheck);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMesSpotCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "点检中心";
            this.Load += new System.EventHandler(this.FormMesSpotCheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numWeldPressure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldPower)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmpNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numWeldPressure;
        private System.Windows.Forms.NumericUpDown numWeldSpeed;
        private System.Windows.Forms.NumericUpDown numWeldFlow;
        private System.Windows.Forms.NumericUpDown numWeldPower;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private HslCommunication.Controls.UserButton btnSpotCheck;
    }
}