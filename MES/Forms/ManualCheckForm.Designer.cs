namespace MES.UI
{
    partial class ManualCheckForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManualCheckForm));
            this.txtManualInfo = new System.Windows.Forms.TextBox();
            this.btnUpdate = new HslCommunication.Controls.UserButton();
            this.labReason = new System.Windows.Forms.Label();
            this.labFinalResult = new System.Windows.Forms.Label();
            this.cmbLwmCheckUpdate = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtManualInfo
            // 
            this.txtManualInfo.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtManualInfo.Location = new System.Drawing.Point(158, 34);
            this.txtManualInfo.Margin = new System.Windows.Forms.Padding(4);
            this.txtManualInfo.Multiline = true;
            this.txtManualInfo.Name = "txtManualInfo";
            this.txtManualInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtManualInfo.Size = new System.Drawing.Size(283, 116);
            this.txtManualInfo.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.CustomerInformation = "";
            this.btnUpdate.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnUpdate.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.Location = new System.Drawing.Point(158, 265);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(162, 67);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.UIText = "修改";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // labReason
            // 
            this.labReason.AutoSize = true;
            this.labReason.Location = new System.Drawing.Point(22, 37);
            this.labReason.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labReason.Name = "labReason";
            this.labReason.Size = new System.Drawing.Size(97, 24);
            this.labReason.TabIndex = 2;
            this.labReason.Text = "修改原因:";
            // 
            // labFinalResult
            // 
            this.labFinalResult.AutoSize = true;
            this.labFinalResult.Location = new System.Drawing.Point(13, 192);
            this.labFinalResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labFinalResult.Name = "labFinalResult";
            this.labFinalResult.Size = new System.Drawing.Size(137, 24);
            this.labFinalResult.TabIndex = 3;
            this.labFinalResult.Text = "最终检测结果:";
            // 
            // cmbLwmCheckUpdate
            // 
            this.cmbLwmCheckUpdate.Font = new System.Drawing.Font("Tahoma", 15F);
            this.cmbLwmCheckUpdate.FormattingEnabled = true;
            this.cmbLwmCheckUpdate.Items.AddRange(new object[] {
            "OK",
            "NG"});
            this.cmbLwmCheckUpdate.Location = new System.Drawing.Point(158, 185);
            this.cmbLwmCheckUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.cmbLwmCheckUpdate.Name = "cmbLwmCheckUpdate";
            this.cmbLwmCheckUpdate.Size = new System.Drawing.Size(190, 38);
            this.cmbLwmCheckUpdate.TabIndex = 4;
            this.cmbLwmCheckUpdate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbLwmCheckUpdate_KeyPress);
            // 
            // ManualCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(476, 357);
            this.Controls.Add(this.cmbLwmCheckUpdate);
            this.Controls.Add(this.labFinalResult);
            this.Controls.Add(this.labReason);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtManualInfo);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ManualCheckForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "人工干预";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManualCheckForm_FormClosing);
            this.Load += new System.EventHandler(this.ManualCheckForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtManualInfo;
        private HslCommunication.Controls.UserButton btnUpdate;
        private System.Windows.Forms.Label labReason;
        private System.Windows.Forms.Label labFinalResult;
        private System.Windows.Forms.ComboBox cmbLwmCheckUpdate;
    }
}