namespace ProductManage.UserControls
{
    partial class MonitorLControl
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lanternState = new HslCommunication.Controls.UserLantern();
            this.txtSurface = new HslCommunication.Controls.UserButton();
            this.labState = new System.Windows.Forms.Label();
            this.labSurface = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lanternState
            // 
            this.lanternState.BackColor = System.Drawing.Color.Transparent;
            this.lanternState.Location = new System.Drawing.Point(34, 203);
            this.lanternState.Margin = new System.Windows.Forms.Padding(7, 10, 7, 10);
            this.lanternState.Name = "lanternState";
            this.lanternState.Size = new System.Drawing.Size(130, 136);
            this.lanternState.TabIndex = 8;
            // 
            // txtSurface
            // 
            this.txtSurface.BackColor = System.Drawing.Color.Transparent;
            this.txtSurface.CustomerInformation = "";
            this.txtSurface.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.txtSurface.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.txtSurface.Location = new System.Drawing.Point(27, 65);
            this.txtSurface.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.txtSurface.Name = "txtSurface";
            this.txtSurface.Size = new System.Drawing.Size(157, 48);
            this.txtSurface.TabIndex = 11;
            this.txtSurface.UIText = "";
            // 
            // labState
            // 
            this.labState.AutoSize = true;
            this.labState.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.labState.Location = new System.Drawing.Point(72, 163);
            this.labState.Name = "labState";
            this.labState.Size = new System.Drawing.Size(65, 30);
            this.labState.TabIndex = 10;
            this.labState.Text = "在线";
            // 
            // labSurface
            // 
            this.labSurface.AutoSize = true;
            this.labSurface.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.labSurface.Location = new System.Drawing.Point(47, 27);
            this.labSurface.Name = "labSurface";
            this.labSurface.Size = new System.Drawing.Size(117, 30);
            this.labSurface.TabIndex = 9;
            this.labSurface.Text = "表面成型";
            // 
            // MonitorLControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lanternState);
            this.Controls.Add(this.txtSurface);
            this.Controls.Add(this.labState);
            this.Controls.Add(this.labSurface);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MonitorLControl";
            this.Size = new System.Drawing.Size(206, 357);
            this.Load += new System.EventHandler(this.MonitorLControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HslCommunication.Controls.UserLantern lanternState;
        private HslCommunication.Controls.UserButton txtSurface;
        private System.Windows.Forms.Label labState;
        private System.Windows.Forms.Label labSurface;
    }
}
