namespace MES.UI
{
    partial class ProgressForm
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
            this.labTips = new System.Windows.Forms.Label();
            this.progress = new HslCommunication.Controls.UserVerticalProgress();
            this.SuspendLayout();
            // 
            // labTips
            // 
            this.labTips.AutoSize = true;
            this.labTips.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labTips.Location = new System.Drawing.Point(75, 18);
            this.labTips.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labTips.Name = "labTips";
            this.labTips.Size = new System.Drawing.Size(188, 21);
            this.labTips.TabIndex = 3;
            this.labTips.Text = "数据加载中，请稍等.....";
            // 
            // progress
            // 
            this.progress.BackColor = System.Drawing.SystemColors.Control;
            this.progress.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.progress.Location = new System.Drawing.Point(32, 54);
            this.progress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progress.Name = "progress";
            this.progress.ProgressStyle = HslCommunication.Controls.ProgressStyle.Horizontal;
            this.progress.Size = new System.Drawing.Size(320, 45);
            this.progress.TabIndex = 4;
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(388, 111);
            this.Controls.Add(this.labTips);
            this.Controls.Add(this.progress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ProgressForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "加载中...";
            this.Load += new System.EventHandler(this.ProgressForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labTips;
        private HslCommunication.Controls.UserVerticalProgress progress;
    }
}