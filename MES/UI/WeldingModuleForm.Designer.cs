namespace MES.UI
{
    partial class WeldingModuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeldingModuleForm));
            this.numWeldPressure = new System.Windows.Forms.NumericUpDown();
            this.numWeldSpeed = new System.Windows.Forms.NumericUpDown();
            this.numWeldFlow = new System.Windows.Forms.NumericUpDown();
            this.numWeldPower = new System.Windows.Forms.NumericUpDown();
            this.labPower = new System.Windows.Forms.Label();
            this.labPressure = new System.Windows.Forms.Label();
            this.labFlow = new System.Windows.Forms.Label();
            this.labSpeed = new System.Windows.Forms.Label();
            this.btnSave = new HslCommunication.Controls.UserButton();
            this.btnLoadModule = new HslCommunication.Controls.UserButton();
            this.labModuleName = new System.Windows.Forms.Label();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.btnClose = new HslCommunication.Controls.UserButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numR = new System.Windows.Forms.NumericUpDown();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.numZ = new System.Windows.Forms.NumericUpDown();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labX = new System.Windows.Forms.Label();
            this.labR = new System.Windows.Forms.Label();
            this.labZ = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.labY = new System.Windows.Forms.Label();
            this.numWeldPowerUp = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numWeldSpeedUp = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numWeldFlowUp = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numWeldPressureUp = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldPressure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldPowerUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldSpeedUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldFlowUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldPressureUp)).BeginInit();
            this.SuspendLayout();
            // 
            // numWeldPressure
            // 
            this.numWeldPressure.DecimalPlaces = 2;
            this.numWeldPressure.Font = new System.Drawing.Font("Tahoma", 13F);
            this.numWeldPressure.Location = new System.Drawing.Point(169, 381);
            this.numWeldPressure.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWeldPressure.Name = "numWeldPressure";
            this.numWeldPressure.Size = new System.Drawing.Size(121, 34);
            this.numWeldPressure.TabIndex = 5;
            this.numWeldPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numWeldSpeed
            // 
            this.numWeldSpeed.DecimalPlaces = 2;
            this.numWeldSpeed.Font = new System.Drawing.Font("Tahoma", 13F);
            this.numWeldSpeed.Location = new System.Drawing.Point(167, 214);
            this.numWeldSpeed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWeldSpeed.Name = "numWeldSpeed";
            this.numWeldSpeed.Size = new System.Drawing.Size(121, 34);
            this.numWeldSpeed.TabIndex = 3;
            this.numWeldSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numWeldFlow
            // 
            this.numWeldFlow.DecimalPlaces = 2;
            this.numWeldFlow.Font = new System.Drawing.Font("Tahoma", 13F);
            this.numWeldFlow.Location = new System.Drawing.Point(169, 301);
            this.numWeldFlow.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWeldFlow.Name = "numWeldFlow";
            this.numWeldFlow.Size = new System.Drawing.Size(121, 34);
            this.numWeldFlow.TabIndex = 4;
            this.numWeldFlow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numWeldPower
            // 
            this.numWeldPower.DecimalPlaces = 2;
            this.numWeldPower.Font = new System.Drawing.Font("Tahoma", 13F);
            this.numWeldPower.Location = new System.Drawing.Point(169, 133);
            this.numWeldPower.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWeldPower.Name = "numWeldPower";
            this.numWeldPower.Size = new System.Drawing.Size(121, 34);
            this.numWeldPower.TabIndex = 2;
            this.numWeldPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labPower
            // 
            this.labPower.AutoSize = true;
            this.labPower.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labPower.Location = new System.Drawing.Point(43, 136);
            this.labPower.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labPower.Name = "labPower";
            this.labPower.Size = new System.Drawing.Size(108, 27);
            this.labPower.TabIndex = 41;
            this.labPower.Text = "焊接功率:";
            // 
            // labPressure
            // 
            this.labPressure.AutoSize = true;
            this.labPressure.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labPressure.Location = new System.Drawing.Point(67, 385);
            this.labPressure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labPressure.Name = "labPressure";
            this.labPressure.Size = new System.Drawing.Size(86, 27);
            this.labPressure.TabIndex = 42;
            this.labPressure.Text = "压力值:";
            // 
            // labFlow
            // 
            this.labFlow.AutoSize = true;
            this.labFlow.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labFlow.Location = new System.Drawing.Point(67, 303);
            this.labFlow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labFlow.Name = "labFlow";
            this.labFlow.Size = new System.Drawing.Size(86, 27);
            this.labFlow.TabIndex = 44;
            this.labFlow.Text = "流量值:";
            // 
            // labSpeed
            // 
            this.labSpeed.AutoSize = true;
            this.labSpeed.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labSpeed.Location = new System.Drawing.Point(44, 217);
            this.labSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labSpeed.Name = "labSpeed";
            this.labSpeed.Size = new System.Drawing.Size(108, 27);
            this.labSpeed.TabIndex = 43;
            this.labSpeed.Text = "焊接速度:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.CustomerInformation = "";
            this.btnSave.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.btnSave.Location = new System.Drawing.Point(127, 472);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(161, 72);
            this.btnSave.TabIndex = 6;
            this.btnSave.UIText = "保存模板";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoadModule
            // 
            this.btnLoadModule.BackColor = System.Drawing.Color.Transparent;
            this.btnLoadModule.CustomerInformation = "";
            this.btnLoadModule.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnLoadModule.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.btnLoadModule.Location = new System.Drawing.Point(410, 472);
            this.btnLoadModule.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnLoadModule.Name = "btnLoadModule";
            this.btnLoadModule.Size = new System.Drawing.Size(161, 72);
            this.btnLoadModule.TabIndex = 7;
            this.btnLoadModule.UIText = "选择模板";
            this.btnLoadModule.Click += new System.EventHandler(this.userButton1_Click);
            // 
            // labModuleName
            // 
            this.labModuleName.AutoSize = true;
            this.labModuleName.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labModuleName.Location = new System.Drawing.Point(31, 47);
            this.labModuleName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labModuleName.Name = "labModuleName";
            this.labModuleName.Size = new System.Drawing.Size(122, 30);
            this.labModuleName.TabIndex = 50;
            this.labModuleName.Text = "模板名称:";
            // 
            // txtModule
            // 
            this.txtModule.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtModule.Location = new System.Drawing.Point(169, 43);
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(205, 38);
            this.txtModule.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.CustomerInformation = "";
            this.btnClose.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.btnClose.Location = new System.Drawing.Point(696, 472);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(161, 72);
            this.btnClose.TabIndex = 51;
            this.btnClose.UIText = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label4.Location = new System.Drawing.Point(450, 139);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 27);
            this.label4.TabIndex = 41;
            this.label4.Text = "W";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label7.Location = new System.Drawing.Point(452, 221);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 27);
            this.label7.TabIndex = 43;
            this.label7.Text = "°/s";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label8.Location = new System.Drawing.Point(452, 305);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 27);
            this.label8.TabIndex = 41;
            this.label8.Text = "L/min";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label9.Location = new System.Drawing.Point(452, 383);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 27);
            this.label9.TabIndex = 43;
            this.label9.Text = "MPa";
            // 
            // numR
            // 
            this.numR.DecimalPlaces = 2;
            this.numR.Font = new System.Drawing.Font("Tahoma", 13F);
            this.numR.Location = new System.Drawing.Point(695, 379);
            this.numR.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numR.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numR.Name = "numR";
            this.numR.Size = new System.Drawing.Size(145, 34);
            this.numR.TabIndex = 55;
            this.numR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numY
            // 
            this.numY.DecimalPlaces = 2;
            this.numY.Font = new System.Drawing.Font("Tahoma", 13F);
            this.numY.Location = new System.Drawing.Point(694, 217);
            this.numY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(145, 34);
            this.numY.TabIndex = 53;
            this.numY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numZ
            // 
            this.numZ.DecimalPlaces = 2;
            this.numZ.Font = new System.Drawing.Font("Tahoma", 13F);
            this.numZ.Location = new System.Drawing.Point(694, 299);
            this.numZ.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numZ.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numZ.Name = "numZ";
            this.numZ.Size = new System.Drawing.Size(145, 34);
            this.numZ.TabIndex = 54;
            this.numZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numX
            // 
            this.numX.DecimalPlaces = 2;
            this.numX.Font = new System.Drawing.Font("Tahoma", 13F);
            this.numX.Location = new System.Drawing.Point(693, 132);
            this.numX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(145, 34);
            this.numX.TabIndex = 52;
            this.numX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label10.Location = new System.Drawing.Point(846, 303);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 27);
            this.label10.TabIndex = 56;
            this.label10.Text = "mm";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label11.Location = new System.Drawing.Point(845, 136);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 27);
            this.label11.TabIndex = 57;
            this.label11.Text = "mm";
            // 
            // labX
            // 
            this.labX.AutoSize = true;
            this.labX.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labX.Location = new System.Drawing.Point(600, 136);
            this.labX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labX.Name = "labX";
            this.labX.Size = new System.Drawing.Size(77, 27);
            this.labX.TabIndex = 58;
            this.labX.Text = "X坐标:";
            // 
            // labR
            // 
            this.labR.AutoSize = true;
            this.labR.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labR.Location = new System.Drawing.Point(599, 383);
            this.labR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labR.Name = "labR";
            this.labR.Size = new System.Drawing.Size(78, 27);
            this.labR.TabIndex = 59;
            this.labR.Text = "R坐标:";
            // 
            // labZ
            // 
            this.labZ.AutoSize = true;
            this.labZ.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labZ.Location = new System.Drawing.Point(601, 302);
            this.labZ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labZ.Name = "labZ";
            this.labZ.Size = new System.Drawing.Size(76, 27);
            this.labZ.TabIndex = 63;
            this.labZ.Text = "Z坐标:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label15.Location = new System.Drawing.Point(846, 384);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 27);
            this.label15.TabIndex = 60;
            this.label15.Text = "°";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label16.Location = new System.Drawing.Point(846, 220);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 27);
            this.label16.TabIndex = 61;
            this.label16.Text = "mm";
            // 
            // labY
            // 
            this.labY.AutoSize = true;
            this.labY.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labY.Location = new System.Drawing.Point(600, 220);
            this.labY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labY.Name = "labY";
            this.labY.Size = new System.Drawing.Size(77, 27);
            this.labY.TabIndex = 62;
            this.labY.Text = "Y坐标:";
            // 
            // numWeldPowerUp
            // 
            this.numWeldPowerUp.DecimalPlaces = 2;
            this.numWeldPowerUp.Font = new System.Drawing.Font("Tahoma", 13F);
            this.numWeldPowerUp.Location = new System.Drawing.Point(332, 134);
            this.numWeldPowerUp.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWeldPowerUp.Name = "numWeldPowerUp";
            this.numWeldPowerUp.Size = new System.Drawing.Size(113, 34);
            this.numWeldPowerUp.TabIndex = 64;
            this.numWeldPowerUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label1.Location = new System.Drawing.Point(297, 139);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 27);
            this.label1.TabIndex = 65;
            this.label1.Text = "~";
            // 
            // numWeldSpeedUp
            // 
            this.numWeldSpeedUp.DecimalPlaces = 2;
            this.numWeldSpeedUp.Font = new System.Drawing.Font("Tahoma", 13F);
            this.numWeldSpeedUp.Location = new System.Drawing.Point(332, 216);
            this.numWeldSpeedUp.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWeldSpeedUp.Name = "numWeldSpeedUp";
            this.numWeldSpeedUp.Size = new System.Drawing.Size(113, 34);
            this.numWeldSpeedUp.TabIndex = 66;
            this.numWeldSpeedUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label2.Location = new System.Drawing.Point(297, 219);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 27);
            this.label2.TabIndex = 67;
            this.label2.Text = "~";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label3.Location = new System.Drawing.Point(297, 307);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 27);
            this.label3.TabIndex = 69;
            this.label3.Text = "~";
            // 
            // numWeldFlowUp
            // 
            this.numWeldFlowUp.DecimalPlaces = 2;
            this.numWeldFlowUp.Font = new System.Drawing.Font("Tahoma", 13F);
            this.numWeldFlowUp.Location = new System.Drawing.Point(332, 303);
            this.numWeldFlowUp.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWeldFlowUp.Name = "numWeldFlowUp";
            this.numWeldFlowUp.Size = new System.Drawing.Size(113, 34);
            this.numWeldFlowUp.TabIndex = 68;
            this.numWeldFlowUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label5.Location = new System.Drawing.Point(297, 386);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 27);
            this.label5.TabIndex = 71;
            this.label5.Text = "~";
            // 
            // numWeldPressureUp
            // 
            this.numWeldPressureUp.DecimalPlaces = 2;
            this.numWeldPressureUp.Font = new System.Drawing.Font("Tahoma", 13F);
            this.numWeldPressureUp.Location = new System.Drawing.Point(332, 382);
            this.numWeldPressureUp.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWeldPressureUp.Name = "numWeldPressureUp";
            this.numWeldPressureUp.Size = new System.Drawing.Size(113, 34);
            this.numWeldPressureUp.TabIndex = 70;
            this.numWeldPressureUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // WeldingModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 575);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numWeldPressureUp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numWeldFlowUp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numWeldSpeedUp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numWeldPowerUp);
            this.Controls.Add(this.numR);
            this.Controls.Add(this.numY);
            this.Controls.Add(this.numZ);
            this.Controls.Add(this.numX);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.labX);
            this.Controls.Add(this.labR);
            this.Controls.Add(this.labZ);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.labY);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtModule);
            this.Controls.Add(this.labModuleName);
            this.Controls.Add(this.btnLoadModule);
            this.Controls.Add(this.numWeldPressure);
            this.Controls.Add(this.numWeldSpeed);
            this.Controls.Add(this.numWeldFlow);
            this.Controls.Add(this.numWeldPower);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labPower);
            this.Controls.Add(this.labPressure);
            this.Controls.Add(this.labFlow);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labSpeed);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "WeldingModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "模块配置";
            this.Load += new System.EventHandler(this.WeldingModuleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numWeldPressure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldPowerUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldSpeedUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldFlowUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldPressureUp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numWeldPressure;
        private System.Windows.Forms.NumericUpDown numWeldSpeed;
        private System.Windows.Forms.NumericUpDown numWeldFlow;
        private System.Windows.Forms.NumericUpDown numWeldPower;
        private System.Windows.Forms.Label labPower;
        private System.Windows.Forms.Label labPressure;
        private System.Windows.Forms.Label labFlow;
        private System.Windows.Forms.Label labSpeed;
        private HslCommunication.Controls.UserButton btnSave;
        private HslCommunication.Controls.UserButton btnLoadModule;
        private System.Windows.Forms.Label labModuleName;
        private System.Windows.Forms.TextBox txtModule;
        private HslCommunication.Controls.UserButton btnClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numR;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.NumericUpDown numZ;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labX;
        private System.Windows.Forms.Label labR;
        private System.Windows.Forms.Label labZ;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label labY;
        private System.Windows.Forms.NumericUpDown numWeldPowerUp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numWeldSpeedUp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numWeldFlowUp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numWeldPressureUp;
    }
}