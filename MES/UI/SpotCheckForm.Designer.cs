namespace MES.UI
{
    partial class SpotCheckForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpotCheckForm));
            this.btnSpotCheck = new HslCommunication.Controls.UserButton();
            this.labPower = new System.Windows.Forms.Label();
            this.labPress = new System.Windows.Forms.Label();
            this.labFlow = new System.Windows.Forms.Label();
            this.labSpeed = new System.Windows.Forms.Label();
            this.numWeldPower = new System.Windows.Forms.NumericUpDown();
            this.numWeldFlow = new System.Windows.Forms.NumericUpDown();
            this.numWeldSpeed = new System.Windows.Forms.NumericUpDown();
            this.numWeldPressure = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labEmpNo = new System.Windows.Forms.Label();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.numR = new System.Windows.Forms.NumericUpDown();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.numZ = new System.Windows.Forms.NumericUpDown();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.labX = new System.Windows.Forms.Label();
            this.labR = new System.Windows.Forms.Label();
            this.labZ = new System.Windows.Forms.Label();
            this.labY = new System.Windows.Forms.Label();
            this.btnSelectModule = new HslCommunication.Controls.UserButton();
            this.txtCurrentModule = new System.Windows.Forms.TextBox();
            this.labCurModule = new System.Windows.Forms.Label();
            this.grbSpotCheck = new System.Windows.Forms.GroupBox();
            this.btnCreateModule = new HslCommunication.Controls.UserButton();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldPressure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            this.grbSpotCheck.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSpotCheck
            // 
            this.btnSpotCheck.BackColor = System.Drawing.Color.Transparent;
            this.btnSpotCheck.CustomerInformation = "";
            this.btnSpotCheck.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnSpotCheck.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.btnSpotCheck.Location = new System.Drawing.Point(392, 481);
            this.btnSpotCheck.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnSpotCheck.Name = "btnSpotCheck";
            this.btnSpotCheck.Size = new System.Drawing.Size(166, 69);
            this.btnSpotCheck.TabIndex = 0;
            this.btnSpotCheck.UIText = "点检";
            this.btnSpotCheck.Click += new System.EventHandler(this.btnSpotCheck_Click);
            // 
            // labPower
            // 
            this.labPower.AutoSize = true;
            this.labPower.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labPower.Location = new System.Drawing.Point(33, 56);
            this.labPower.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labPower.Name = "labPower";
            this.labPower.Size = new System.Drawing.Size(108, 27);
            this.labPower.TabIndex = 24;
            this.labPower.Text = "焊接功率:";
            // 
            // labPress
            // 
            this.labPress.AutoSize = true;
            this.labPress.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labPress.Location = new System.Drawing.Point(436, 133);
            this.labPress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labPress.Name = "labPress";
            this.labPress.Size = new System.Drawing.Size(86, 27);
            this.labPress.TabIndex = 28;
            this.labPress.Text = "压力值:";
            // 
            // labFlow
            // 
            this.labFlow.AutoSize = true;
            this.labFlow.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labFlow.Location = new System.Drawing.Point(49, 131);
            this.labFlow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labFlow.Name = "labFlow";
            this.labFlow.Size = new System.Drawing.Size(86, 27);
            this.labFlow.TabIndex = 34;
            this.labFlow.Text = "流量值:";
            // 
            // labSpeed
            // 
            this.labSpeed.AutoSize = true;
            this.labSpeed.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labSpeed.Location = new System.Drawing.Point(420, 56);
            this.labSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labSpeed.Name = "labSpeed";
            this.labSpeed.Size = new System.Drawing.Size(108, 27);
            this.labSpeed.TabIndex = 32;
            this.labSpeed.Text = "焊接速度:";
            // 
            // numWeldPower
            // 
            this.numWeldPower.DecimalPlaces = 2;
            this.numWeldPower.Font = new System.Drawing.Font("Tahoma", 13F);
            this.numWeldPower.Location = new System.Drawing.Point(143, 53);
            this.numWeldPower.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWeldPower.Name = "numWeldPower";
            this.numWeldPower.Size = new System.Drawing.Size(154, 34);
            this.numWeldPower.TabIndex = 36;
            this.numWeldPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numWeldPower.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            // 
            // numWeldFlow
            // 
            this.numWeldFlow.DecimalPlaces = 2;
            this.numWeldFlow.Font = new System.Drawing.Font("Tahoma", 13F);
            this.numWeldFlow.Location = new System.Drawing.Point(143, 127);
            this.numWeldFlow.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWeldFlow.Name = "numWeldFlow";
            this.numWeldFlow.Size = new System.Drawing.Size(154, 34);
            this.numWeldFlow.TabIndex = 37;
            this.numWeldFlow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numWeldFlow.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numWeldSpeed
            // 
            this.numWeldSpeed.DecimalPlaces = 2;
            this.numWeldSpeed.Font = new System.Drawing.Font("Tahoma", 13F);
            this.numWeldSpeed.Location = new System.Drawing.Point(529, 53);
            this.numWeldSpeed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWeldSpeed.Name = "numWeldSpeed";
            this.numWeldSpeed.Size = new System.Drawing.Size(154, 34);
            this.numWeldSpeed.TabIndex = 38;
            this.numWeldSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numWeldSpeed.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // numWeldPressure
            // 
            this.numWeldPressure.DecimalPlaces = 2;
            this.numWeldPressure.Font = new System.Drawing.Font("Tahoma", 13F);
            this.numWeldPressure.Location = new System.Drawing.Point(529, 129);
            this.numWeldPressure.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWeldPressure.Name = "numWeldPressure";
            this.numWeldPressure.Size = new System.Drawing.Size(154, 34);
            this.numWeldPressure.TabIndex = 39;
            this.numWeldPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numWeldPressure.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label1.Location = new System.Drawing.Point(304, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 27);
            this.label1.TabIndex = 40;
            this.label1.Text = "W";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label4.Location = new System.Drawing.Point(304, 132);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 27);
            this.label4.TabIndex = 40;
            this.label4.Text = "L/min";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label7.Location = new System.Drawing.Point(690, 57);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 27);
            this.label7.TabIndex = 40;
            this.label7.Text = "°/s";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label8.Location = new System.Drawing.Point(690, 133);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 27);
            this.label8.TabIndex = 40;
            this.label8.Text = "MPa";
            // 
            // labEmpNo
            // 
            this.labEmpNo.AutoSize = true;
            this.labEmpNo.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labEmpNo.Location = new System.Drawing.Point(45, 502);
            this.labEmpNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labEmpNo.Name = "labEmpNo";
            this.labEmpNo.Size = new System.Drawing.Size(97, 30);
            this.labEmpNo.TabIndex = 41;
            this.labEmpNo.Text = "点检人:";
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtEmpNo.Location = new System.Drawing.Point(166, 498);
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(165, 38);
            this.txtEmpNo.TabIndex = 42;
            this.txtEmpNo.Text = "No001";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label11.Location = new System.Drawing.Point(304, 276);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 27);
            this.label11.TabIndex = 53;
            this.label11.Text = "mm";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label12.Location = new System.Drawing.Point(690, 277);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 27);
            this.label12.TabIndex = 54;
            this.label12.Text = "°";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label13.Location = new System.Drawing.Point(690, 201);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 27);
            this.label13.TabIndex = 55;
            this.label13.Text = "mm";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 13F);
            this.label14.Location = new System.Drawing.Point(304, 201);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 27);
            this.label14.TabIndex = 56;
            this.label14.Text = "mm";
            // 
            // numR
            // 
            this.numR.DecimalPlaces = 2;
            this.numR.Font = new System.Drawing.Font("Tahoma", 13F);
            this.numR.Location = new System.Drawing.Point(529, 273);
            this.numR.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numR.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.numR.Name = "numR";
            this.numR.Size = new System.Drawing.Size(154, 34);
            this.numR.TabIndex = 52;
            this.numR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numR.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // numY
            // 
            this.numY.DecimalPlaces = 2;
            this.numY.Font = new System.Drawing.Font("Tahoma", 13F);
            this.numY.Location = new System.Drawing.Point(529, 197);
            this.numY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numY.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(154, 34);
            this.numY.TabIndex = 51;
            this.numY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numY.Value = new decimal(new int[] {
            4134,
            0,
            0,
            131072});
            // 
            // numZ
            // 
            this.numZ.DecimalPlaces = 2;
            this.numZ.Font = new System.Drawing.Font("Tahoma", 13F);
            this.numZ.Location = new System.Drawing.Point(143, 271);
            this.numZ.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numZ.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.numZ.Name = "numZ";
            this.numZ.Size = new System.Drawing.Size(154, 34);
            this.numZ.TabIndex = 50;
            this.numZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numZ.Value = new decimal(new int[] {
            14417,
            0,
            0,
            131072});
            // 
            // numX
            // 
            this.numX.DecimalPlaces = 2;
            this.numX.Font = new System.Drawing.Font("Tahoma", 13F);
            this.numX.Location = new System.Drawing.Point(143, 197);
            this.numX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numX.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(154, 34);
            this.numX.TabIndex = 49;
            this.numX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numX.Value = new decimal(new int[] {
            688,
            0,
            0,
            65536});
            // 
            // labX
            // 
            this.labX.AutoSize = true;
            this.labX.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labX.Location = new System.Drawing.Point(59, 200);
            this.labX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labX.Name = "labX";
            this.labX.Size = new System.Drawing.Size(77, 27);
            this.labX.TabIndex = 45;
            this.labX.Text = "X坐标:";
            // 
            // labR
            // 
            this.labR.AutoSize = true;
            this.labR.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labR.Location = new System.Drawing.Point(445, 276);
            this.labR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labR.Name = "labR";
            this.labR.Size = new System.Drawing.Size(78, 27);
            this.labR.TabIndex = 46;
            this.labR.Text = "R坐标:";
            // 
            // labZ
            // 
            this.labZ.AutoSize = true;
            this.labZ.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labZ.Location = new System.Drawing.Point(59, 275);
            this.labZ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labZ.Name = "labZ";
            this.labZ.Size = new System.Drawing.Size(76, 27);
            this.labZ.TabIndex = 48;
            this.labZ.Text = "Z坐标:";
            // 
            // labY
            // 
            this.labY.AutoSize = true;
            this.labY.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labY.Location = new System.Drawing.Point(445, 200);
            this.labY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labY.Name = "labY";
            this.labY.Size = new System.Drawing.Size(77, 27);
            this.labY.TabIndex = 47;
            this.labY.Text = "Y坐标:";
            // 
            // btnSelectModule
            // 
            this.btnSelectModule.BackColor = System.Drawing.Color.Transparent;
            this.btnSelectModule.CustomerInformation = "";
            this.btnSelectModule.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnSelectModule.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnSelectModule.Location = new System.Drawing.Point(392, 388);
            this.btnSelectModule.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.btnSelectModule.Name = "btnSelectModule";
            this.btnSelectModule.Size = new System.Drawing.Size(166, 56);
            this.btnSelectModule.TabIndex = 57;
            this.btnSelectModule.UIText = "选择点检模板";
            this.btnSelectModule.Click += new System.EventHandler(this.btnSelectModule_Click);
            // 
            // txtCurrentModule
            // 
            this.txtCurrentModule.Font = new System.Drawing.Font("Tahoma", 13F);
            this.txtCurrentModule.Location = new System.Drawing.Point(166, 397);
            this.txtCurrentModule.Name = "txtCurrentModule";
            this.txtCurrentModule.ReadOnly = true;
            this.txtCurrentModule.Size = new System.Drawing.Size(165, 34);
            this.txtCurrentModule.TabIndex = 58;
            // 
            // labCurModule
            // 
            this.labCurModule.AutoSize = true;
            this.labCurModule.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labCurModule.Location = new System.Drawing.Point(34, 400);
            this.labCurModule.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labCurModule.Name = "labCurModule";
            this.labCurModule.Size = new System.Drawing.Size(108, 27);
            this.labCurModule.TabIndex = 59;
            this.labCurModule.Text = "当前模板:";
            // 
            // grbSpotCheck
            // 
            this.grbSpotCheck.Controls.Add(this.numWeldPower);
            this.grbSpotCheck.Controls.Add(this.labSpeed);
            this.grbSpotCheck.Controls.Add(this.labFlow);
            this.grbSpotCheck.Controls.Add(this.labPress);
            this.grbSpotCheck.Controls.Add(this.label11);
            this.grbSpotCheck.Controls.Add(this.labPower);
            this.grbSpotCheck.Controls.Add(this.label12);
            this.grbSpotCheck.Controls.Add(this.numWeldFlow);
            this.grbSpotCheck.Controls.Add(this.label13);
            this.grbSpotCheck.Controls.Add(this.numWeldSpeed);
            this.grbSpotCheck.Controls.Add(this.label14);
            this.grbSpotCheck.Controls.Add(this.numWeldPressure);
            this.grbSpotCheck.Controls.Add(this.numR);
            this.grbSpotCheck.Controls.Add(this.label1);
            this.grbSpotCheck.Controls.Add(this.numY);
            this.grbSpotCheck.Controls.Add(this.label7);
            this.grbSpotCheck.Controls.Add(this.numZ);
            this.grbSpotCheck.Controls.Add(this.label8);
            this.grbSpotCheck.Controls.Add(this.numX);
            this.grbSpotCheck.Controls.Add(this.label4);
            this.grbSpotCheck.Controls.Add(this.labX);
            this.grbSpotCheck.Controls.Add(this.labY);
            this.grbSpotCheck.Controls.Add(this.labR);
            this.grbSpotCheck.Controls.Add(this.labZ);
            this.grbSpotCheck.Location = new System.Drawing.Point(12, 12);
            this.grbSpotCheck.Name = "grbSpotCheck";
            this.grbSpotCheck.Size = new System.Drawing.Size(784, 348);
            this.grbSpotCheck.TabIndex = 60;
            this.grbSpotCheck.TabStop = false;
            this.grbSpotCheck.Text = "点检参数";
            // 
            // btnCreateModule
            // 
            this.btnCreateModule.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateModule.CustomerInformation = "";
            this.btnCreateModule.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnCreateModule.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnCreateModule.Location = new System.Drawing.Point(615, 388);
            this.btnCreateModule.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.btnCreateModule.Name = "btnCreateModule";
            this.btnCreateModule.Size = new System.Drawing.Size(140, 56);
            this.btnCreateModule.TabIndex = 61;
            this.btnCreateModule.UIText = "创建模板";
            this.btnCreateModule.Visible = false;
            this.btnCreateModule.Click += new System.EventHandler(this.btnCreateModule_Click);
            // 
            // SpotCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 578);
            this.Controls.Add(this.btnCreateModule);
            this.Controls.Add(this.grbSpotCheck);
            this.Controls.Add(this.labCurModule);
            this.Controls.Add(this.txtCurrentModule);
            this.Controls.Add(this.btnSelectModule);
            this.Controls.Add(this.txtEmpNo);
            this.Controls.Add(this.labEmpNo);
            this.Controls.Add(this.btnSpotCheck);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "SpotCheckForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "点检中心";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpotCheckForm_FormClosing);
            this.Load += new System.EventHandler(this.SpotCheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numWeldPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldPressure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            this.grbSpotCheck.ResumeLayout(false);
            this.grbSpotCheck.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HslCommunication.Controls.UserButton btnSpotCheck;
        private System.Windows.Forms.Label labPower;
        private System.Windows.Forms.Label labPress;
        private System.Windows.Forms.Label labFlow;
        private System.Windows.Forms.Label labSpeed;
        private System.Windows.Forms.NumericUpDown numWeldPower;
        private System.Windows.Forms.NumericUpDown numWeldFlow;
        private System.Windows.Forms.NumericUpDown numWeldSpeed;
        private System.Windows.Forms.NumericUpDown numWeldPressure;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labEmpNo;
        private System.Windows.Forms.TextBox txtEmpNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numR;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.NumericUpDown numZ;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.Label labX;
        private System.Windows.Forms.Label labR;
        private System.Windows.Forms.Label labZ;
        private System.Windows.Forms.Label labY;
        private HslCommunication.Controls.UserButton btnSelectModule;
        private System.Windows.Forms.TextBox txtCurrentModule;
        private System.Windows.Forms.Label labCurModule;
        private System.Windows.Forms.GroupBox grbSpotCheck;
        private HslCommunication.Controls.UserButton btnCreateModule;
    }
}