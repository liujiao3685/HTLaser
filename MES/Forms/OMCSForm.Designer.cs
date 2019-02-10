namespace MES.UI
{
    partial class OMCSForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OMCSForm));
            this.dgvUsersInfo = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbAddUser = new System.Windows.Forms.GroupBox();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.labEmpNo = new System.Windows.Forms.Label();
            this.btnReset = new HslCommunication.Controls.UserButton();
            this.btnAdd = new HslCommunication.Controls.UserButton();
            this.cmbAuth = new System.Windows.Forms.ComboBox();
            this.labAuth = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.labPassword = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.labUserName = new System.Windows.Forms.Label();
            this.grbCurrentUser = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new HslCommunication.Controls.UserButton();
            this.btnDelete = new HslCommunication.Controls.UserButton();
            this.btnModify = new HslCommunication.Controls.UserButton();
            this.cmbCurAuth = new System.Windows.Forms.ComboBox();
            this.labAuthCur = new System.Windows.Forms.Label();
            this.txtPasswordInfo = new System.Windows.Forms.TextBox();
            this.labPasswordCur = new System.Windows.Forms.Label();
            this.txtNameInfo = new System.Windows.Forms.TextBox();
            this.labUserCur = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersInfo)).BeginInit();
            this.grbAddUser.SuspendLayout();
            this.grbCurrentUser.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUsersInfo
            // 
            this.dgvUsersInfo.AllowUserToDeleteRows = false;
            this.dgvUsersInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsersInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsersInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colEmpNo,
            this.colName,
            this.colPassword,
            this.colAuth});
            this.dgvUsersInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsersInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvUsersInfo.MultiSelect = false;
            this.dgvUsersInfo.Name = "dgvUsersInfo";
            this.dgvUsersInfo.ReadOnly = true;
            this.dgvUsersInfo.RowTemplate.Height = 23;
            this.dgvUsersInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsersInfo.Size = new System.Drawing.Size(1036, 335);
            this.dgvUsersInfo.TabIndex = 0;
            this.dgvUsersInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsersInfo_CellClick);
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colEmpNo
            // 
            this.colEmpNo.HeaderText = "员工编号";
            this.colEmpNo.Name = "colEmpNo";
            this.colEmpNo.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.HeaderText = "用户名";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colPassword
            // 
            this.colPassword.HeaderText = "密码";
            this.colPassword.Name = "colPassword";
            this.colPassword.ReadOnly = true;
            // 
            // colAuth
            // 
            this.colAuth.HeaderText = "权限";
            this.colAuth.Name = "colAuth";
            this.colAuth.ReadOnly = true;
            // 
            // grbAddUser
            // 
            this.grbAddUser.Controls.Add(this.chkShowPassword);
            this.grbAddUser.Controls.Add(this.txtEmpNo);
            this.grbAddUser.Controls.Add(this.labEmpNo);
            this.grbAddUser.Controls.Add(this.btnReset);
            this.grbAddUser.Controls.Add(this.btnAdd);
            this.grbAddUser.Controls.Add(this.cmbAuth);
            this.grbAddUser.Controls.Add(this.labAuth);
            this.grbAddUser.Controls.Add(this.txtPassword);
            this.grbAddUser.Controls.Add(this.labPassword);
            this.grbAddUser.Controls.Add(this.txtName);
            this.grbAddUser.Controls.Add(this.labUserName);
            this.grbAddUser.Location = new System.Drawing.Point(3, 6);
            this.grbAddUser.Name = "grbAddUser";
            this.grbAddUser.Size = new System.Drawing.Size(437, 303);
            this.grbAddUser.TabIndex = 1;
            this.grbAddUser.TabStop = false;
            this.grbAddUser.Text = "添加用户";
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Font = new System.Drawing.Font("Tahoma", 10F);
            this.chkShowPassword.Location = new System.Drawing.Point(293, 186);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(66, 25);
            this.chkShowPassword.TabIndex = 10;
            this.chkShowPassword.Text = "隐藏";
            this.chkShowPassword.UseVisualStyleBackColor = true;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Location = new System.Drawing.Point(130, 50);
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(157, 30);
            this.txtEmpNo.TabIndex = 9;
            // 
            // labEmpNo
            // 
            this.labEmpNo.AutoSize = true;
            this.labEmpNo.Location = new System.Drawing.Point(19, 53);
            this.labEmpNo.Name = "labEmpNo";
            this.labEmpNo.Size = new System.Drawing.Size(105, 23);
            this.labEmpNo.TabIndex = 8;
            this.labEmpNo.Text = "员工编号：";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.CustomerInformation = "";
            this.btnReset.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnReset.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnReset.Location = new System.Drawing.Point(317, 229);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(96, 41);
            this.btnReset.TabIndex = 7;
            this.btnReset.UIText = "重置";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.CustomerInformation = "";
            this.btnAdd.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnAdd.Location = new System.Drawing.Point(317, 74);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(96, 41);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.UIText = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbAuth
            // 
            this.cmbAuth.FormattingEnabled = true;
            this.cmbAuth.Items.AddRange(new object[] {
            "操作员",
            "管理员"});
            this.cmbAuth.Location = new System.Drawing.Point(130, 244);
            this.cmbAuth.Name = "cmbAuth";
            this.cmbAuth.Size = new System.Drawing.Size(157, 30);
            this.cmbAuth.TabIndex = 5;
            this.cmbAuth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbAuthInfo_KeyPress);
            // 
            // labAuth
            // 
            this.labAuth.AutoSize = true;
            this.labAuth.Location = new System.Drawing.Point(21, 247);
            this.labAuth.Name = "labAuth";
            this.labAuth.Size = new System.Drawing.Size(103, 23);
            this.labAuth.TabIndex = 4;
            this.labAuth.Text = "权      限：";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(130, 181);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(157, 30);
            this.txtPassword.TabIndex = 3;
            // 
            // labPassword
            // 
            this.labPassword.AutoSize = true;
            this.labPassword.Location = new System.Drawing.Point(21, 184);
            this.labPassword.Name = "labPassword";
            this.labPassword.Size = new System.Drawing.Size(103, 23);
            this.labPassword.TabIndex = 2;
            this.labPassword.Text = "密      码：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(130, 115);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(157, 30);
            this.txtName.TabIndex = 1;
            // 
            // labUserName
            // 
            this.labUserName.AutoSize = true;
            this.labUserName.Location = new System.Drawing.Point(20, 118);
            this.labUserName.Name = "labUserName";
            this.labUserName.Size = new System.Drawing.Size(104, 23);
            this.labUserName.TabIndex = 0;
            this.labUserName.Text = "用  户 名：";
            // 
            // grbCurrentUser
            // 
            this.grbCurrentUser.Controls.Add(this.btnUpdate);
            this.grbCurrentUser.Controls.Add(this.btnDelete);
            this.grbCurrentUser.Controls.Add(this.btnModify);
            this.grbCurrentUser.Controls.Add(this.cmbCurAuth);
            this.grbCurrentUser.Controls.Add(this.labAuthCur);
            this.grbCurrentUser.Controls.Add(this.txtPasswordInfo);
            this.grbCurrentUser.Controls.Add(this.labPasswordCur);
            this.grbCurrentUser.Controls.Add(this.txtNameInfo);
            this.grbCurrentUser.Controls.Add(this.labUserCur);
            this.grbCurrentUser.Location = new System.Drawing.Point(456, 8);
            this.grbCurrentUser.Name = "grbCurrentUser";
            this.grbCurrentUser.Size = new System.Drawing.Size(451, 303);
            this.grbCurrentUser.TabIndex = 2;
            this.grbCurrentUser.TabStop = false;
            this.grbCurrentUser.Text = "所选用户信息";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.CustomerInformation = "";
            this.btnUpdate.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnUpdate.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnUpdate.Location = new System.Drawing.Point(320, 51);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(96, 41);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.UIText = "更新";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.CustomerInformation = "";
            this.btnDelete.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnDelete.Location = new System.Drawing.Point(320, 216);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(96, 41);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.UIText = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.Transparent;
            this.btnModify.CustomerInformation = "";
            this.btnModify.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnModify.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnModify.Location = new System.Drawing.Point(320, 136);
            this.btnModify.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(96, 41);
            this.btnModify.TabIndex = 7;
            this.btnModify.UIText = "修改";
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // cmbCurAuth
            // 
            this.cmbCurAuth.FormattingEnabled = true;
            this.cmbCurAuth.Items.AddRange(new object[] {
            "操作员",
            "管理员"});
            this.cmbCurAuth.Location = new System.Drawing.Point(128, 223);
            this.cmbCurAuth.Name = "cmbCurAuth";
            this.cmbCurAuth.Size = new System.Drawing.Size(157, 30);
            this.cmbCurAuth.TabIndex = 5;
            this.cmbCurAuth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbAuthInfo_KeyPress);
            // 
            // labAuthCur
            // 
            this.labAuthCur.AutoSize = true;
            this.labAuthCur.Location = new System.Drawing.Point(25, 226);
            this.labAuthCur.Name = "labAuthCur";
            this.labAuthCur.Size = new System.Drawing.Size(97, 23);
            this.labAuthCur.TabIndex = 4;
            this.labAuthCur.Text = "权     限：";
            // 
            // txtPasswordInfo
            // 
            this.txtPasswordInfo.Location = new System.Drawing.Point(128, 140);
            this.txtPasswordInfo.Name = "txtPasswordInfo";
            this.txtPasswordInfo.Size = new System.Drawing.Size(157, 30);
            this.txtPasswordInfo.TabIndex = 3;
            // 
            // labPasswordCur
            // 
            this.labPasswordCur.AutoSize = true;
            this.labPasswordCur.Location = new System.Drawing.Point(25, 144);
            this.labPasswordCur.Name = "labPasswordCur";
            this.labPasswordCur.Size = new System.Drawing.Size(97, 23);
            this.labPasswordCur.TabIndex = 2;
            this.labPasswordCur.Text = "密     码：";
            // 
            // txtNameInfo
            // 
            this.txtNameInfo.Location = new System.Drawing.Point(128, 56);
            this.txtNameInfo.Name = "txtNameInfo";
            this.txtNameInfo.Size = new System.Drawing.Size(157, 30);
            this.txtNameInfo.TabIndex = 1;
            // 
            // labUserCur
            // 
            this.labUserCur.AutoSize = true;
            this.labUserCur.Location = new System.Drawing.Point(24, 59);
            this.labUserCur.Name = "labUserCur";
            this.labUserCur.Size = new System.Drawing.Size(98, 23);
            this.labUserCur.TabIndex = 0;
            this.labUserCur.Text = "用 户 名：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grbAddUser);
            this.panel1.Controls.Add(this.grbCurrentUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 335);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1036, 318);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvUsersInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1036, 335);
            this.panel2.TabIndex = 4;
            // 
            // OMCSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 653);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 11F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OMCSForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "资质维护中心";
            this.Load += new System.EventHandler(this.AptitudeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersInfo)).EndInit();
            this.grbAddUser.ResumeLayout(false);
            this.grbAddUser.PerformLayout();
            this.grbCurrentUser.ResumeLayout(false);
            this.grbCurrentUser.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsersInfo;
        private System.Windows.Forms.GroupBox grbAddUser;
        private System.Windows.Forms.Label labUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label labPassword;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label labAuth;
        private System.Windows.Forms.ComboBox cmbAuth;
        private HslCommunication.Controls.UserButton btnAdd;
        private HslCommunication.Controls.UserButton btnReset;
        private System.Windows.Forms.GroupBox grbCurrentUser;
        private HslCommunication.Controls.UserButton btnModify;
        private System.Windows.Forms.ComboBox cmbCurAuth;
        private System.Windows.Forms.Label labAuthCur;
        private System.Windows.Forms.TextBox txtPasswordInfo;
        private System.Windows.Forms.Label labPasswordCur;
        private System.Windows.Forms.TextBox txtNameInfo;
        private System.Windows.Forms.Label labUserCur;
        private HslCommunication.Controls.UserButton btnDelete;
        private HslCommunication.Controls.UserButton btnUpdate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtEmpNo;
        private System.Windows.Forms.Label labEmpNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuth;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.Panel panel2;
    }
}