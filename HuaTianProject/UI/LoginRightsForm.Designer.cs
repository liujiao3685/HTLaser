﻿namespace HuaTianProject.UI
{
    partial class LoginRightsForm
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
            this.cmbUserType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbUserType
            // 
            this.cmbUserType.Font = new System.Drawing.Font("Tahoma", 15F);
            this.cmbUserType.FormattingEnabled = true;
            this.cmbUserType.Items.AddRange(new object[] {
            "操作员",
            "管理员",
            "程序员"});
            this.cmbUserType.Location = new System.Drawing.Point(129, 34);
            this.cmbUserType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbUserType.Name = "cmbUserType";
            this.cmbUserType.Size = new System.Drawing.Size(185, 35);
            this.cmbUserType.TabIndex = 0;
            this.cmbUserType.SelectedIndexChanged += new System.EventHandler(this.cmbUserType_SelectedIndexChanged);
            this.cmbUserType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbUserType_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label1.Location = new System.Drawing.Point(51, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label2.Location = new System.Drawing.Point(51, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtPassword.Location = new System.Drawing.Point(129, 102);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(185, 34);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "123";
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // btnOK
            // 
            this.btnOK.AutoSize = true;
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnOK.Location = new System.Drawing.Point(68, 175);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(83, 40);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnCancel.Location = new System.Drawing.Point(208, 175);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 40);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // LoginRightsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 243);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbUserType);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginRightsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择权限";
            this.Load += new System.EventHandler(this.LogonRightsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbUserType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}