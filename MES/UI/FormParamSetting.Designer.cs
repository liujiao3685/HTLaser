namespace 生产管理系统.UI
{
    partial class FormParamSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormParamSetting));
            this.grbS = new System.Windows.Forms.GroupBox();
            this.labCoaxUp = new System.Windows.Forms.Label();
            this.labCoaxDown = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkCheckData = new System.Windows.Forms.CheckBox();
            this.numCoaxDownS = new System.Windows.Forms.NumericUpDown();
            this.numCoaxUpS = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new HslCommunication.Controls.UserButton();
            this.btnExist = new HslCommunication.Controls.UserButton();
            this.grbSpotCheck = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.chkSpotCheck = new System.Windows.Forms.CheckBox();
            this.labPower = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.labFlow = new System.Windows.Forms.Label();
            this.labSpeed = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.numWeldPressure = new System.Windows.Forms.NumericUpDown();
            this.numWeldPower = new System.Windows.Forms.NumericUpDown();
            this.labPress = new System.Windows.Forms.Label();
            this.numWeldSpeed = new System.Windows.Forms.NumericUpDown();
            this.numWeldFlow = new System.Windows.Forms.NumericUpDown();
            this.grbS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCoaxDownS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoaxUpS)).BeginInit();
            this.grbSpotCheck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldPressure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldFlow)).BeginInit();
            this.SuspendLayout();
            // 
            // grbS
            // 
            this.grbS.Controls.Add(this.labCoaxUp);
            this.grbS.Controls.Add(this.labCoaxDown);
            this.grbS.Controls.Add(this.label3);
            this.grbS.Controls.Add(this.label4);
            this.grbS.Controls.Add(this.chkCheckData);
            this.grbS.Controls.Add(this.numCoaxDownS);
            this.grbS.Controls.Add(this.numCoaxUpS);
            this.grbS.Font = new System.Drawing.Font("Tahoma", 11F);
            this.grbS.Location = new System.Drawing.Point(17, 16);
            this.grbS.Name = "grbS";
            this.grbS.Size = new System.Drawing.Size(359, 194);
            this.grbS.TabIndex = 1;
            this.grbS.TabStop = false;
            // 
            // labCoaxUp
            // 
            this.labCoaxUp.AutoSize = true;
            this.labCoaxUp.Location = new System.Drawing.Point(26, 60);
            this.labCoaxUp.Name = "labCoaxUp";
            this.labCoaxUp.Size = new System.Drawing.Size(112, 23);
            this.labCoaxUp.TabIndex = 6;
            this.labCoaxUp.Text = "同心度上限:";
            // 
            // labCoaxDown
            // 
            this.labCoaxDown.AutoSize = true;
            this.labCoaxDown.Location = new System.Drawing.Point(26, 130);
            this.labCoaxDown.Name = "labCoaxDown";
            this.labCoaxDown.Size = new System.Drawing.Size(112, 23);
            this.labCoaxDown.TabIndex = 7;
            this.labCoaxDown.Text = "同心度下限:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(270, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "mm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "mm";
            // 
            // chkCheckData
            // 
            this.chkCheckData.AutoSize = true;
            this.chkCheckData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCheckData.Location = new System.Drawing.Point(1, 0);
            this.chkCheckData.Name = "chkCheckData";
            this.chkCheckData.Size = new System.Drawing.Size(108, 27);
            this.chkCheckData.TabIndex = 2;
            this.chkCheckData.Text = "检测参数";
            this.chkCheckData.UseVisualStyleBackColor = true;
            this.chkCheckData.CheckedChanged += new System.EventHandler(this.chkParamS_CheckedChanged);
            // 
            // numCoaxDownS
            // 
            this.numCoaxDownS.DecimalPlaces = 3;
            this.numCoaxDownS.Location = new System.Drawing.Point(144, 126);
            this.numCoaxDownS.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numCoaxDownS.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numCoaxDownS.Name = "numCoaxDownS";
            this.numCoaxDownS.Size = new System.Drawing.Size(120, 30);
            this.numCoaxDownS.TabIndex = 3;
            this.numCoaxDownS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numCoaxUpS
            // 
            this.numCoaxUpS.DecimalPlaces = 3;
            this.numCoaxUpS.Location = new System.Drawing.Point(144, 58);
            this.numCoaxUpS.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numCoaxUpS.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numCoaxUpS.Name = "numCoaxUpS";
            this.numCoaxUpS.Size = new System.Drawing.Size(120, 30);
            this.numCoaxUpS.TabIndex = 2;
            this.numCoaxUpS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.CustomerInformation = "";
            this.btnSave.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnSave.Location = new System.Drawing.Point(61, 236);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 51);
            this.btnSave.TabIndex = 4;
            this.btnSave.UIText = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExist
            // 
            this.btnExist.BackColor = System.Drawing.Color.Transparent;
            this.btnExist.CustomerInformation = "";
            this.btnExist.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnExist.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnExist.Location = new System.Drawing.Point(241, 236);
            this.btnExist.Margin = new System.Windows.Forms.Padding(6);
            this.btnExist.Name = "btnExist";
            this.btnExist.Size = new System.Drawing.Size(102, 51);
            this.btnExist.TabIndex = 5;
            this.btnExist.UIText = "关闭";
            this.btnExist.Click += new System.EventHandler(this.btnExist_Click);
            // 
            // grbSpotCheck
            // 
            this.grbSpotCheck.Controls.Add(this.label13);
            this.grbSpotCheck.Controls.Add(this.label14);
            this.grbSpotCheck.Controls.Add(this.chkSpotCheck);
            this.grbSpotCheck.Controls.Add(this.labPower);
            this.grbSpotCheck.Controls.Add(this.label15);
            this.grbSpotCheck.Controls.Add(this.labFlow);
            this.grbSpotCheck.Controls.Add(this.labSpeed);
            this.grbSpotCheck.Controls.Add(this.label16);
            this.grbSpotCheck.Controls.Add(this.numWeldPressure);
            this.grbSpotCheck.Controls.Add(this.numWeldPower);
            this.grbSpotCheck.Controls.Add(this.labPress);
            this.grbSpotCheck.Controls.Add(this.numWeldSpeed);
            this.grbSpotCheck.Controls.Add(this.numWeldFlow);
            this.grbSpotCheck.Font = new System.Drawing.Font("Tahoma", 11F);
            this.grbSpotCheck.Location = new System.Drawing.Point(36, 331);
            this.grbSpotCheck.Name = "grbSpotCheck";
            this.grbSpotCheck.Size = new System.Drawing.Size(322, 351);
            this.grbSpotCheck.TabIndex = 9;
            this.grbSpotCheck.TabStop = false;
            this.grbSpotCheck.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label13.Location = new System.Drawing.Point(238, 294);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 23);
            this.label13.TabIndex = 49;
            this.label13.Text = "L/min";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label14.Location = new System.Drawing.Point(238, 215);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 23);
            this.label14.TabIndex = 50;
            this.label14.Text = "MPa";
            // 
            // chkSpotCheck
            // 
            this.chkSpotCheck.AutoSize = true;
            this.chkSpotCheck.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSpotCheck.Location = new System.Drawing.Point(1, 0);
            this.chkSpotCheck.Name = "chkSpotCheck";
            this.chkSpotCheck.Size = new System.Drawing.Size(108, 27);
            this.chkSpotCheck.TabIndex = 2;
            this.chkSpotCheck.Text = "点检参数";
            this.chkSpotCheck.UseVisualStyleBackColor = true;
            // 
            // labPower
            // 
            this.labPower.AutoSize = true;
            this.labPower.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labPower.Location = new System.Drawing.Point(13, 66);
            this.labPower.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labPower.Name = "labPower";
            this.labPower.Size = new System.Drawing.Size(93, 23);
            this.labPower.TabIndex = 41;
            this.labPower.Text = "焊接功率:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label15.Location = new System.Drawing.Point(238, 140);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 23);
            this.label15.TabIndex = 51;
            this.label15.Text = "mm/s";
            // 
            // labFlow
            // 
            this.labFlow.AutoSize = true;
            this.labFlow.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labFlow.Location = new System.Drawing.Point(27, 292);
            this.labFlow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labFlow.Name = "labFlow";
            this.labFlow.Size = new System.Drawing.Size(74, 23);
            this.labFlow.TabIndex = 44;
            this.labFlow.Text = "流量值:";
            // 
            // labSpeed
            // 
            this.labSpeed.AutoSize = true;
            this.labSpeed.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labSpeed.Location = new System.Drawing.Point(12, 139);
            this.labSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labSpeed.Name = "labSpeed";
            this.labSpeed.Size = new System.Drawing.Size(93, 23);
            this.labSpeed.TabIndex = 43;
            this.labSpeed.Text = "焊接转速:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label16.Location = new System.Drawing.Point(238, 68);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(27, 23);
            this.label16.TabIndex = 52;
            this.label16.Text = "W";
            // 
            // numWeldPressure
            // 
            this.numWeldPressure.DecimalPlaces = 3;
            this.numWeldPressure.Font = new System.Drawing.Font("Tahoma", 11F);
            this.numWeldPressure.Location = new System.Drawing.Point(117, 211);
            this.numWeldPressure.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWeldPressure.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numWeldPressure.Name = "numWeldPressure";
            this.numWeldPressure.Size = new System.Drawing.Size(116, 30);
            this.numWeldPressure.TabIndex = 48;
            this.numWeldPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numWeldPower
            // 
            this.numWeldPower.DecimalPlaces = 3;
            this.numWeldPower.Font = new System.Drawing.Font("Tahoma", 11F);
            this.numWeldPower.Location = new System.Drawing.Point(115, 64);
            this.numWeldPower.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWeldPower.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numWeldPower.Name = "numWeldPower";
            this.numWeldPower.Size = new System.Drawing.Size(116, 30);
            this.numWeldPower.TabIndex = 45;
            this.numWeldPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labPress
            // 
            this.labPress.AutoSize = true;
            this.labPress.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labPress.Location = new System.Drawing.Point(27, 213);
            this.labPress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labPress.Name = "labPress";
            this.labPress.Size = new System.Drawing.Size(74, 23);
            this.labPress.TabIndex = 42;
            this.labPress.Text = "压力值:";
            // 
            // numWeldSpeed
            // 
            this.numWeldSpeed.DecimalPlaces = 3;
            this.numWeldSpeed.Font = new System.Drawing.Font("Tahoma", 11F);
            this.numWeldSpeed.Location = new System.Drawing.Point(117, 137);
            this.numWeldSpeed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWeldSpeed.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numWeldSpeed.Name = "numWeldSpeed";
            this.numWeldSpeed.Size = new System.Drawing.Size(116, 30);
            this.numWeldSpeed.TabIndex = 47;
            this.numWeldSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numWeldFlow
            // 
            this.numWeldFlow.DecimalPlaces = 3;
            this.numWeldFlow.Font = new System.Drawing.Font("Tahoma", 11F);
            this.numWeldFlow.Location = new System.Drawing.Point(115, 289);
            this.numWeldFlow.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWeldFlow.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numWeldFlow.Name = "numWeldFlow";
            this.numWeldFlow.Size = new System.Drawing.Size(116, 30);
            this.numWeldFlow.TabIndex = 46;
            this.numWeldFlow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FormParamSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(393, 309);
            this.Controls.Add(this.grbSpotCheck);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExist);
            this.Controls.Add(this.grbS);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormParamSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参数配置";
            this.Load += new System.EventHandler(this.FormParamSetting_Load);
            this.grbS.ResumeLayout(false);
            this.grbS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCoaxDownS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoaxUpS)).EndInit();
            this.grbSpotCheck.ResumeLayout(false);
            this.grbSpotCheck.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldPressure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeldFlow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbS;
        private System.Windows.Forms.NumericUpDown numCoaxUpS;
        private System.Windows.Forms.NumericUpDown numCoaxDownS;
        private System.Windows.Forms.CheckBox chkCheckData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private HslCommunication.Controls.UserButton btnSave;
        private HslCommunication.Controls.UserButton btnExist;
        private System.Windows.Forms.GroupBox grbSpotCheck;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkSpotCheck;
        private System.Windows.Forms.Label labPower;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label labFlow;
        private System.Windows.Forms.Label labSpeed;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numWeldPressure;
        private System.Windows.Forms.NumericUpDown numWeldPower;
        private System.Windows.Forms.Label labPress;
        private System.Windows.Forms.NumericUpDown numWeldSpeed;
        private System.Windows.Forms.NumericUpDown numWeldFlow;
        private System.Windows.Forms.Label labCoaxUp;
        private System.Windows.Forms.Label labCoaxDown;
    }
}