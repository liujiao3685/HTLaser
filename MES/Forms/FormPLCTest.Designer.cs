namespace MES.UI
{
    partial class CheckOneProductForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.txtSurface = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCoaxiality = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labCheckResult = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.labTime = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20F);
            this.label1.Location = new System.Drawing.Point(96, 261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 41);
            this.label1.TabIndex = 41;
            this.label1.Text = "条码:";
            // 
            // txtBarCode
            // 
            this.txtBarCode.Font = new System.Drawing.Font("Tahoma", 20F);
            this.txtBarCode.Location = new System.Drawing.Point(216, 261);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(314, 48);
            this.txtBarCode.TabIndex = 40;
            this.txtBarCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFirstScan_KeyPress);
            // 
            // txtSurface
            // 
            this.txtSurface.Font = new System.Drawing.Font("Tahoma", 18F);
            this.txtSurface.Location = new System.Drawing.Point(216, 415);
            this.txtSurface.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSurface.Name = "txtSurface";
            this.txtSurface.ReadOnly = true;
            this.txtSurface.Size = new System.Drawing.Size(247, 44);
            this.txtSurface.TabIndex = 45;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 18F);
            this.label5.Location = new System.Drawing.Point(45, 417);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 36);
            this.label5.TabIndex = 44;
            this.label5.Text = "表面质量：";
            // 
            // txtCoaxiality
            // 
            this.txtCoaxiality.Font = new System.Drawing.Font("Tahoma", 18F);
            this.txtCoaxiality.Location = new System.Drawing.Point(216, 334);
            this.txtCoaxiality.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCoaxiality.Name = "txtCoaxiality";
            this.txtCoaxiality.ReadOnly = true;
            this.txtCoaxiality.Size = new System.Drawing.Size(247, 44);
            this.txtCoaxiality.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 18F);
            this.label2.Location = new System.Drawing.Point(3, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 36);
            this.label2.TabIndex = 42;
            this.label2.Text = "同心度(mm)：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 18F);
            this.label3.Location = new System.Drawing.Point(45, 495);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 36);
            this.label3.TabIndex = 46;
            this.label3.Text = "检测结果：";
            // 
            // labCheckResult
            // 
            this.labCheckResult.AutoSize = true;
            this.labCheckResult.Font = new System.Drawing.Font("Tahoma", 30F);
            this.labCheckResult.Location = new System.Drawing.Point(216, 484);
            this.labCheckResult.Name = "labCheckResult";
            this.labCheckResult.Size = new System.Drawing.Size(41, 60);
            this.labCheckResult.TabIndex = 47;
            this.labCheckResult.Text = " ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 20F);
            this.label4.Location = new System.Drawing.Point(53, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 41);
            this.label4.TabIndex = 49;
            this.label4.Text = "地址:";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Tahoma", 20F);
            this.txtAddress.Location = new System.Drawing.Point(158, 42);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(155, 48);
            this.txtAddress.TabIndex = 48;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 20F);
            this.label6.Location = new System.Drawing.Point(400, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 41);
            this.label6.TabIndex = 51;
            this.label6.Text = "数据:";
            // 
            // txtValue
            // 
            this.txtValue.Font = new System.Drawing.Font("Tahoma", 20F);
            this.txtValue.Location = new System.Drawing.Point(505, 42);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(155, 48);
            this.txtValue.TabIndex = 50;
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(158, 142);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(159, 60);
            this.btnWrite.TabIndex = 52;
            this.btnWrite.Text = "写入";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // labTime
            // 
            this.labTime.AutoSize = true;
            this.labTime.Font = new System.Drawing.Font("Tahoma", 30F);
            this.labTime.Location = new System.Drawing.Point(495, 142);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(68, 60);
            this.labTime.TabIndex = 54;
            this.labTime.Text = " 0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 18F);
            this.label8.Location = new System.Drawing.Point(393, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 36);
            this.label8.TabIndex = 53;
            this.label8.Text = "耗时：";
            // 
            // CheckOneProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 545);
            this.Controls.Add(this.labTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.labCheckResult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSurface);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCoaxiality);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBarCode);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CheckOneProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "单个产品检测";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.TextBox txtSurface;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCoaxiality;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labCheckResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Label labTime;
        private System.Windows.Forms.Label label8;
    }
}