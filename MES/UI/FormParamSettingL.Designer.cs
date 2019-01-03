namespace ProductManage.UI
{
    partial class FormParamSettingL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormParamSettingL));
            this.grbL = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numHFDown = new System.Windows.Forms.NumericUpDown();
            this.numHFUp = new System.Windows.Forms.NumericUpDown();
            this.labDepthDown = new System.Windows.Forms.Label();
            this.labDepthUp = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkCheckData = new System.Windows.Forms.CheckBox();
            this.labCoaxUp = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numCoaxDownL = new System.Windows.Forms.NumericUpDown();
            this.labCoaxDown = new System.Windows.Forms.Label();
            this.numCoaxUpL = new System.Windows.Forms.NumericUpDown();
            this.btnExist = new HslCommunication.Controls.UserButton();
            this.btnSave = new HslCommunication.Controls.UserButton();
            this.grbL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHFDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHFUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoaxDownL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoaxUpL)).BeginInit();
            this.SuspendLayout();
            // 
            // grbL
            // 
            this.grbL.Controls.Add(this.label9);
            this.grbL.Controls.Add(this.label10);
            this.grbL.Controls.Add(this.numHFDown);
            this.grbL.Controls.Add(this.numHFUp);
            this.grbL.Controls.Add(this.labDepthDown);
            this.grbL.Controls.Add(this.labDepthUp);
            this.grbL.Controls.Add(this.label5);
            this.grbL.Controls.Add(this.chkCheckData);
            this.grbL.Controls.Add(this.labCoaxUp);
            this.grbL.Controls.Add(this.label6);
            this.grbL.Controls.Add(this.numCoaxDownL);
            this.grbL.Controls.Add(this.labCoaxDown);
            this.grbL.Controls.Add(this.numCoaxUpL);
            this.grbL.Font = new System.Drawing.Font("Tahoma", 11F);
            this.grbL.Location = new System.Drawing.Point(17, 13);
            this.grbL.Name = "grbL";
            this.grbL.Size = new System.Drawing.Size(358, 344);
            this.grbL.TabIndex = 3;
            this.grbL.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(294, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 23);
            this.label9.TabIndex = 10;
            this.label9.Text = "mm";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(294, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 23);
            this.label10.TabIndex = 11;
            this.label10.Text = "mm";
            // 
            // numHFDown
            // 
            this.numHFDown.DecimalPlaces = 3;
            this.numHFDown.Location = new System.Drawing.Point(168, 126);
            this.numHFDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numHFDown.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numHFDown.Name = "numHFDown";
            this.numHFDown.Size = new System.Drawing.Size(120, 30);
            this.numHFDown.TabIndex = 9;
            this.numHFDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numHFUp
            // 
            this.numHFUp.DecimalPlaces = 3;
            this.numHFUp.Location = new System.Drawing.Point(168, 53);
            this.numHFUp.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numHFUp.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numHFUp.Name = "numHFUp";
            this.numHFUp.Size = new System.Drawing.Size(120, 30);
            this.numHFUp.TabIndex = 8;
            this.numHFUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labDepthDown
            // 
            this.labDepthDown.AutoSize = true;
            this.labDepthDown.Location = new System.Drawing.Point(12, 129);
            this.labDepthDown.Name = "labDepthDown";
            this.labDepthDown.Size = new System.Drawing.Size(150, 23);
            this.labDepthDown.TabIndex = 7;
            this.labDepthDown.Text = "焊缝高度差下限:";
            // 
            // labDepthUp
            // 
            this.labDepthUp.AutoSize = true;
            this.labDepthUp.Location = new System.Drawing.Point(12, 56);
            this.labDepthUp.Name = "labDepthUp";
            this.labDepthUp.Size = new System.Drawing.Size(150, 23);
            this.labDepthUp.TabIndex = 6;
            this.labDepthUp.Text = "焊缝高度差上限:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(294, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "mm";
            // 
            // chkCheckData
            // 
            this.chkCheckData.AutoSize = true;
            this.chkCheckData.Location = new System.Drawing.Point(0, 0);
            this.chkCheckData.Name = "chkCheckData";
            this.chkCheckData.Size = new System.Drawing.Size(108, 27);
            this.chkCheckData.TabIndex = 2;
            this.chkCheckData.Text = "检测参数";
            this.chkCheckData.UseVisualStyleBackColor = true;
            this.chkCheckData.CheckedChanged += new System.EventHandler(this.chkParamL_CheckedChanged);
            // 
            // labCoaxUp
            // 
            this.labCoaxUp.AutoSize = true;
            this.labCoaxUp.Location = new System.Drawing.Point(43, 202);
            this.labCoaxUp.Name = "labCoaxUp";
            this.labCoaxUp.Size = new System.Drawing.Size(112, 23);
            this.labCoaxUp.TabIndex = 0;
            this.labCoaxUp.Text = "同心度上限:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(294, 272);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "mm";
            // 
            // numCoaxDownL
            // 
            this.numCoaxDownL.DecimalPlaces = 3;
            this.numCoaxDownL.Location = new System.Drawing.Point(168, 269);
            this.numCoaxDownL.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numCoaxDownL.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numCoaxDownL.Name = "numCoaxDownL";
            this.numCoaxDownL.Size = new System.Drawing.Size(120, 30);
            this.numCoaxDownL.TabIndex = 3;
            this.numCoaxDownL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labCoaxDown
            // 
            this.labCoaxDown.AutoSize = true;
            this.labCoaxDown.Location = new System.Drawing.Point(43, 272);
            this.labCoaxDown.Name = "labCoaxDown";
            this.labCoaxDown.Size = new System.Drawing.Size(112, 23);
            this.labCoaxDown.TabIndex = 1;
            this.labCoaxDown.Text = "同心度下限:";
            // 
            // numCoaxUpL
            // 
            this.numCoaxUpL.DecimalPlaces = 3;
            this.numCoaxUpL.Location = new System.Drawing.Point(168, 199);
            this.numCoaxUpL.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numCoaxUpL.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numCoaxUpL.Name = "numCoaxUpL";
            this.numCoaxUpL.Size = new System.Drawing.Size(120, 30);
            this.numCoaxUpL.TabIndex = 2;
            this.numCoaxUpL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnExist
            // 
            this.btnExist.BackColor = System.Drawing.Color.Transparent;
            this.btnExist.CustomerInformation = "";
            this.btnExist.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnExist.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnExist.Location = new System.Drawing.Point(234, 379);
            this.btnExist.Margin = new System.Windows.Forms.Padding(6);
            this.btnExist.Name = "btnExist";
            this.btnExist.Size = new System.Drawing.Size(119, 59);
            this.btnExist.TabIndex = 7;
            this.btnExist.UIText = "关闭";
            this.btnExist.Click += new System.EventHandler(this.btnExist_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.CustomerInformation = "";
            this.btnSave.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnSave.Location = new System.Drawing.Point(43, 379);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(119, 59);
            this.btnSave.TabIndex = 6;
            this.btnSave.UIText = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormParamSettingL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 456);
            this.Controls.Add(this.btnExist);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grbL);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormParamSettingL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参数配置";
            this.Load += new System.EventHandler(this.FormParamSettingL_Load);
            this.grbL.ResumeLayout(false);
            this.grbL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHFDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHFUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoaxDownL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoaxUpL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbL;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numHFDown;
        private System.Windows.Forms.NumericUpDown numHFUp;
        private System.Windows.Forms.Label labDepthDown;
        private System.Windows.Forms.Label labDepthUp;
        private System.Windows.Forms.CheckBox chkCheckData;
        private HslCommunication.Controls.UserButton btnExist;
        private HslCommunication.Controls.UserButton btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numCoaxDownL;
        private System.Windows.Forms.NumericUpDown numCoaxUpL;
        private System.Windows.Forms.Label labCoaxDown;
        private System.Windows.Forms.Label labCoaxUp;
    }
}