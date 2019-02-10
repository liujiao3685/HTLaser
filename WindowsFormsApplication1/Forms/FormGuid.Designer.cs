namespace WindowsFormsApplication1.UI
{
    partial class FormGuid
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
            this.button7 = new System.Windows.Forms.Button();
            this.txtGuid = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(629, 17);
            this.button7.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(257, 129);
            this.button7.TabIndex = 13;
            this.button7.Text = "GUID";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // txtGuid
            // 
            this.txtGuid.Font = new System.Drawing.Font("宋体", 15F);
            this.txtGuid.Location = new System.Drawing.Point(81, 57);
            this.txtGuid.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.txtGuid.Name = "txtGuid";
            this.txtGuid.Size = new System.Drawing.Size(478, 36);
            this.txtGuid.TabIndex = 12;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(586, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 65);
            this.button1.TabIndex = 14;
            this.button1.Text = "保存txt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtModel
            // 
            this.txtModel.Font = new System.Drawing.Font("宋体", 15F);
            this.txtModel.Location = new System.Drawing.Point(213, 206);
            this.txtModel.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(269, 36);
            this.txtModel.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 32);
            this.label1.TabIndex = 16;
            this.label1.Text = "model";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(586, 316);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(168, 65);
            this.button2.TabIndex = 17;
            this.button2.Text = "打开txt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormGuid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 491);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.txtGuid);
            this.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "FormGuid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormGuid";
            this.Load += new System.EventHandler(this.FormGuid_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox txtGuid;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}