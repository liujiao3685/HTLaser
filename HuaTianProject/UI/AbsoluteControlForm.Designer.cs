namespace HuaTianProject.UI
{
    partial class AbsoluteControlForm
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
            this.btnAxisX = new System.Windows.Forms.Button();
            this.btnAxisY = new System.Windows.Forms.Button();
            this.btnAxisZ = new System.Windows.Forms.Button();
            this.btnAxisW = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCurrentPosX = new System.Windows.Forms.TextBox();
            this.txtCurrentPosY = new System.Windows.Forms.TextBox();
            this.txtCurrentPosZ = new System.Windows.Forms.TextBox();
            this.txtCurrentPosW = new System.Windows.Forms.TextBox();
            this.txtCurrentSpeedW = new System.Windows.Forms.TextBox();
            this.txtCurrentSpeedZ = new System.Windows.Forms.TextBox();
            this.txtCurrentSpeedY = new System.Windows.Forms.TextBox();
            this.txtCurrentSpeedX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStateX = new System.Windows.Forms.TextBox();
            this.txtStateY = new System.Windows.Forms.TextBox();
            this.txtStateZ = new System.Windows.Forms.TextBox();
            this.txtStateW = new System.Windows.Forms.TextBox();
            this.txtFinalPosX = new System.Windows.Forms.NumericUpDown();
            this.txtFinalPosY = new System.Windows.Forms.NumericUpDown();
            this.txtFinalPosZ = new System.Windows.Forms.NumericUpDown();
            this.txtFinalPosW = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinalPosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinalPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinalPosZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinalPosW)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAxisX
            // 
            this.btnAxisX.AutoSize = true;
            this.btnAxisX.Location = new System.Drawing.Point(70, 106);
            this.btnAxisX.Name = "btnAxisX";
            this.btnAxisX.Size = new System.Drawing.Size(107, 37);
            this.btnAxisX.TabIndex = 2;
            this.btnAxisX.Text = "X轴";
            this.btnAxisX.UseVisualStyleBackColor = true;
            this.btnAxisX.Click += new System.EventHandler(this.btnAxisX_Click);
            // 
            // btnAxisY
            // 
            this.btnAxisY.AutoSize = true;
            this.btnAxisY.Location = new System.Drawing.Point(70, 169);
            this.btnAxisY.Name = "btnAxisY";
            this.btnAxisY.Size = new System.Drawing.Size(107, 37);
            this.btnAxisY.TabIndex = 5;
            this.btnAxisY.Text = "Y轴";
            this.btnAxisY.UseVisualStyleBackColor = true;
            this.btnAxisY.Click += new System.EventHandler(this.btnAxisY_Click);
            // 
            // btnAxisZ
            // 
            this.btnAxisZ.AutoSize = true;
            this.btnAxisZ.Location = new System.Drawing.Point(70, 232);
            this.btnAxisZ.Name = "btnAxisZ";
            this.btnAxisZ.Size = new System.Drawing.Size(107, 37);
            this.btnAxisZ.TabIndex = 9;
            this.btnAxisZ.Text = "Z轴";
            this.btnAxisZ.UseVisualStyleBackColor = true;
            this.btnAxisZ.Click += new System.EventHandler(this.btnAxisZ_Click);
            // 
            // btnAxisW
            // 
            this.btnAxisW.AutoSize = true;
            this.btnAxisW.Location = new System.Drawing.Point(70, 295);
            this.btnAxisW.Name = "btnAxisW";
            this.btnAxisW.Size = new System.Drawing.Size(107, 37);
            this.btnAxisW.TabIndex = 13;
            this.btnAxisW.Text = "W轴";
            this.btnAxisW.UseVisualStyleBackColor = true;
            this.btnAxisW.Click += new System.EventHandler(this.btnAxisW_Click);
            // 
            // btnStop
            // 
            this.btnStop.AutoSize = true;
            this.btnStop.Location = new System.Drawing.Point(378, 376);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(114, 50);
            this.btnStop.TabIndex = 15;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 16;
            this.label1.Text = "目标位置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(399, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 16;
            this.label2.Text = "当前位置";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(558, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 16;
            this.label3.Text = "当前速度";
            // 
            // txtCurrentPosX
            // 
            this.txtCurrentPosX.Location = new System.Drawing.Point(378, 111);
            this.txtCurrentPosX.Name = "txtCurrentPosX";
            this.txtCurrentPosX.ReadOnly = true;
            this.txtCurrentPosX.Size = new System.Drawing.Size(115, 29);
            this.txtCurrentPosX.TabIndex = 1;
            this.txtCurrentPosX.Text = "0";
            this.txtCurrentPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCurrentPosY
            // 
            this.txtCurrentPosY.Location = new System.Drawing.Point(378, 173);
            this.txtCurrentPosY.Name = "txtCurrentPosY";
            this.txtCurrentPosY.ReadOnly = true;
            this.txtCurrentPosY.Size = new System.Drawing.Size(115, 29);
            this.txtCurrentPosY.TabIndex = 1;
            this.txtCurrentPosY.Text = "0";
            this.txtCurrentPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCurrentPosZ
            // 
            this.txtCurrentPosZ.Location = new System.Drawing.Point(378, 239);
            this.txtCurrentPosZ.Name = "txtCurrentPosZ";
            this.txtCurrentPosZ.ReadOnly = true;
            this.txtCurrentPosZ.Size = new System.Drawing.Size(115, 29);
            this.txtCurrentPosZ.TabIndex = 1;
            this.txtCurrentPosZ.Text = "0";
            this.txtCurrentPosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCurrentPosW
            // 
            this.txtCurrentPosW.Location = new System.Drawing.Point(378, 301);
            this.txtCurrentPosW.Name = "txtCurrentPosW";
            this.txtCurrentPosW.ReadOnly = true;
            this.txtCurrentPosW.Size = new System.Drawing.Size(115, 29);
            this.txtCurrentPosW.TabIndex = 1;
            this.txtCurrentPosW.Text = "0";
            this.txtCurrentPosW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCurrentSpeedW
            // 
            this.txtCurrentSpeedW.Location = new System.Drawing.Point(536, 301);
            this.txtCurrentSpeedW.Name = "txtCurrentSpeedW";
            this.txtCurrentSpeedW.ReadOnly = true;
            this.txtCurrentSpeedW.Size = new System.Drawing.Size(115, 29);
            this.txtCurrentSpeedW.TabIndex = 17;
            this.txtCurrentSpeedW.Text = "0";
            this.txtCurrentSpeedW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCurrentSpeedZ
            // 
            this.txtCurrentSpeedZ.Location = new System.Drawing.Point(536, 239);
            this.txtCurrentSpeedZ.Name = "txtCurrentSpeedZ";
            this.txtCurrentSpeedZ.ReadOnly = true;
            this.txtCurrentSpeedZ.Size = new System.Drawing.Size(115, 29);
            this.txtCurrentSpeedZ.TabIndex = 18;
            this.txtCurrentSpeedZ.Text = "0";
            this.txtCurrentSpeedZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCurrentSpeedY
            // 
            this.txtCurrentSpeedY.Location = new System.Drawing.Point(536, 173);
            this.txtCurrentSpeedY.Name = "txtCurrentSpeedY";
            this.txtCurrentSpeedY.ReadOnly = true;
            this.txtCurrentSpeedY.Size = new System.Drawing.Size(115, 29);
            this.txtCurrentSpeedY.TabIndex = 19;
            this.txtCurrentSpeedY.Text = "0";
            this.txtCurrentSpeedY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCurrentSpeedX
            // 
            this.txtCurrentSpeedX.Location = new System.Drawing.Point(536, 111);
            this.txtCurrentSpeedX.Name = "txtCurrentSpeedX";
            this.txtCurrentSpeedX.ReadOnly = true;
            this.txtCurrentSpeedX.Size = new System.Drawing.Size(115, 29);
            this.txtCurrentSpeedX.TabIndex = 20;
            this.txtCurrentSpeedX.Text = "0";
            this.txtCurrentSpeedX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 16;
            this.label4.Text = "绝对定位";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(713, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 21);
            this.label5.TabIndex = 16;
            this.label5.Text = "运行状态";
            // 
            // txtStateX
            // 
            this.txtStateX.Location = new System.Drawing.Point(694, 111);
            this.txtStateX.Name = "txtStateX";
            this.txtStateX.ReadOnly = true;
            this.txtStateX.Size = new System.Drawing.Size(115, 29);
            this.txtStateX.TabIndex = 20;
            this.txtStateX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStateY
            // 
            this.txtStateY.Location = new System.Drawing.Point(694, 173);
            this.txtStateY.Name = "txtStateY";
            this.txtStateY.ReadOnly = true;
            this.txtStateY.Size = new System.Drawing.Size(115, 29);
            this.txtStateY.TabIndex = 19;
            this.txtStateY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStateZ
            // 
            this.txtStateZ.Location = new System.Drawing.Point(694, 239);
            this.txtStateZ.Name = "txtStateZ";
            this.txtStateZ.ReadOnly = true;
            this.txtStateZ.Size = new System.Drawing.Size(115, 29);
            this.txtStateZ.TabIndex = 18;
            this.txtStateZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStateW
            // 
            this.txtStateW.Location = new System.Drawing.Point(694, 301);
            this.txtStateW.Name = "txtStateW";
            this.txtStateW.ReadOnly = true;
            this.txtStateW.Size = new System.Drawing.Size(115, 29);
            this.txtStateW.TabIndex = 17;
            this.txtStateW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFinalPosX
            // 
            this.txtFinalPosX.DecimalPlaces = 3;
            this.txtFinalPosX.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtFinalPosX.Location = new System.Drawing.Point(215, 111);
            this.txtFinalPosX.Name = "txtFinalPosX";
            this.txtFinalPosX.Size = new System.Drawing.Size(120, 29);
            this.txtFinalPosX.TabIndex = 21;
            this.txtFinalPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFinalPosY
            // 
            this.txtFinalPosY.DecimalPlaces = 3;
            this.txtFinalPosY.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtFinalPosY.Location = new System.Drawing.Point(215, 173);
            this.txtFinalPosY.Name = "txtFinalPosY";
            this.txtFinalPosY.Size = new System.Drawing.Size(120, 29);
            this.txtFinalPosY.TabIndex = 21;
            this.txtFinalPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFinalPosZ
            // 
            this.txtFinalPosZ.DecimalPlaces = 3;
            this.txtFinalPosZ.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtFinalPosZ.Location = new System.Drawing.Point(215, 239);
            this.txtFinalPosZ.Name = "txtFinalPosZ";
            this.txtFinalPosZ.Size = new System.Drawing.Size(120, 29);
            this.txtFinalPosZ.TabIndex = 21;
            this.txtFinalPosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFinalPosW
            // 
            this.txtFinalPosW.DecimalPlaces = 3;
            this.txtFinalPosW.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtFinalPosW.Location = new System.Drawing.Point(215, 301);
            this.txtFinalPosW.Name = "txtFinalPosW";
            this.txtFinalPosW.Size = new System.Drawing.Size(120, 29);
            this.txtFinalPosW.TabIndex = 21;
            this.txtFinalPosW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // AbsoluteControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 466);
            this.Controls.Add(this.txtFinalPosW);
            this.Controls.Add(this.txtFinalPosY);
            this.Controls.Add(this.txtFinalPosZ);
            this.Controls.Add(this.txtFinalPosX);
            this.Controls.Add(this.txtStateW);
            this.Controls.Add(this.txtCurrentSpeedW);
            this.Controls.Add(this.txtStateZ);
            this.Controls.Add(this.txtCurrentSpeedZ);
            this.Controls.Add(this.txtStateY);
            this.Controls.Add(this.txtStateX);
            this.Controls.Add(this.txtCurrentSpeedY);
            this.Controls.Add(this.txtCurrentSpeedX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnAxisW);
            this.Controls.Add(this.btnAxisZ);
            this.Controls.Add(this.btnAxisY);
            this.Controls.Add(this.btnAxisX);
            this.Controls.Add(this.txtCurrentPosW);
            this.Controls.Add(this.txtCurrentPosZ);
            this.Controls.Add(this.txtCurrentPosY);
            this.Controls.Add(this.txtCurrentPosX);
            this.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AbsoluteControlForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "多轴绝对运动";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AbsoluteControlForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtFinalPosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinalPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinalPosZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinalPosW)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAxisX;
        private System.Windows.Forms.Button btnAxisY;
        private System.Windows.Forms.Button btnAxisZ;
        private System.Windows.Forms.Button btnAxisW;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCurrentPosX;
        private System.Windows.Forms.TextBox txtCurrentPosY;
        private System.Windows.Forms.TextBox txtCurrentPosZ;
        private System.Windows.Forms.TextBox txtCurrentPosW;
        private System.Windows.Forms.TextBox txtCurrentSpeedW;
        private System.Windows.Forms.TextBox txtCurrentSpeedZ;
        private System.Windows.Forms.TextBox txtCurrentSpeedY;
        private System.Windows.Forms.TextBox txtCurrentSpeedX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStateX;
        private System.Windows.Forms.TextBox txtStateY;
        private System.Windows.Forms.TextBox txtStateZ;
        private System.Windows.Forms.TextBox txtStateW;
        private System.Windows.Forms.NumericUpDown txtFinalPosX;
        private System.Windows.Forms.NumericUpDown txtFinalPosY;
        private System.Windows.Forms.NumericUpDown txtFinalPosZ;
        private System.Windows.Forms.NumericUpDown txtFinalPosW;
    }
}