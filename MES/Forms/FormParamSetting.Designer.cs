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
            this.grbS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCoaxDownS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoaxUpS)).BeginInit();
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
            // FormParamSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(393, 310);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExist);
            this.Controls.Add(this.grbS);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormParamSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "参数配置";
            this.Load += new System.EventHandler(this.FormParamSetting_Load);
            this.grbS.ResumeLayout(false);
            this.grbS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCoaxDownS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoaxUpS)).EndInit();
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
        private System.Windows.Forms.Label labCoaxUp;
        private System.Windows.Forms.Label labCoaxDown;
    }
}