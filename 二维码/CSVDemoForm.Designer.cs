namespace QRCode
{
    partial class CsvDemoForm
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
            this.btnOutCSV = new System.Windows.Forms.Button();
            this.listViewUsers = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPassword = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPasssword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labUseTime = new System.Windows.Forms.Label();
            this.labSum = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnInPutCsv = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOutCSV
            // 
            this.btnOutCSV.Location = new System.Drawing.Point(621, 251);
            this.btnOutCSV.Name = "btnOutCSV";
            this.btnOutCSV.Size = new System.Drawing.Size(111, 43);
            this.btnOutCSV.TabIndex = 4;
            this.btnOutCSV.Text = "导出CSV文件";
            this.btnOutCSV.UseVisualStyleBackColor = true;
            this.btnOutCSV.Click += new System.EventHandler(this.btnOutCSV_Click);
            // 
            // listViewUsers
            // 
            this.listViewUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colName,
            this.colPassword,
            this.colPid});
            this.listViewUsers.FullRowSelect = true;
            this.listViewUsers.GridLines = true;
            this.listViewUsers.Location = new System.Drawing.Point(12, 1);
            this.listViewUsers.Name = "listViewUsers";
            this.listViewUsers.Size = new System.Drawing.Size(590, 452);
            this.listViewUsers.TabIndex = 5;
            this.listViewUsers.UseCompatibleStateImageBehavior = false;
            this.listViewUsers.View = System.Windows.Forms.View.Details;
            this.listViewUsers.VirtualMode = true;
            this.listViewUsers.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.listViewUsers_RetrieveVirtualItem);
            this.listViewUsers.SelectedIndexChanged += new System.EventHandler(this.listViewUsers_SelectedIndexChanged);
            // 
            // colID
            // 
            this.colID.Text = "ID";
            // 
            // colName
            // 
            this.colName.Text = "Name";
            // 
            // colPassword
            // 
            this.colPassword.Text = "Password";
            this.colPassword.Width = 97;
            // 
            // colPid
            // 
            this.colPid.Text = "PId";
            this.colPid.Width = 106;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(26, 476);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(78, 43);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(313, 476);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(78, 43);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(447, 476);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(78, 43);
            this.btnInsert.TabIndex = 4;
            this.btnInsert.Text = "增加";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(160, 476);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(78, 43);
            this.btnModify.TabIndex = 6;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(618, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(681, 21);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 22);
            this.txtID.TabIndex = 8;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(681, 86);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 22);
            this.txtName.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(618, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "Name";
            // 
            // txtPasssword
            // 
            this.txtPasssword.Location = new System.Drawing.Point(681, 161);
            this.txtPasssword.Name = "txtPasssword";
            this.txtPasssword.Size = new System.Drawing.Size(100, 22);
            this.txtPasssword.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(618, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Red;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label4.Location = new System.Drawing.Point(632, 476);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "操作耗时：";
            // 
            // labUseTime
            // 
            this.labUseTime.AutoSize = true;
            this.labUseTime.BackColor = System.Drawing.Color.Red;
            this.labUseTime.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labUseTime.Location = new System.Drawing.Point(721, 476);
            this.labUseTime.Name = "labUseTime";
            this.labUseTime.Size = new System.Drawing.Size(0, 18);
            this.labUseTime.TabIndex = 14;
            // 
            // labSum
            // 
            this.labSum.AutoSize = true;
            this.labSum.BackColor = System.Drawing.Color.Red;
            this.labSum.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labSum.Location = new System.Drawing.Point(721, 435);
            this.labSum.Name = "labSum";
            this.labSum.Size = new System.Drawing.Size(0, 18);
            this.labSum.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Red;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label6.Location = new System.Drawing.Point(647, 435);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 18);
            this.label6.TabIndex = 15;
            this.label6.Text = "数据量：";
            // 
            // btnInPutCsv
            // 
            this.btnInPutCsv.Location = new System.Drawing.Point(621, 327);
            this.btnInPutCsv.Name = "btnInPutCsv";
            this.btnInPutCsv.Size = new System.Drawing.Size(111, 43);
            this.btnInPutCsv.TabIndex = 17;
            this.btnInPutCsv.Text = "导入CSV文件";
            this.btnInPutCsv.UseVisualStyleBackColor = true;
            this.btnInPutCsv.Click += new System.EventHandler(this.btnInPutCsv_Click);
            // 
            // CsvDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 545);
            this.Controls.Add(this.btnInPutCsv);
            this.Controls.Add(this.labSum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labUseTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPasssword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.listViewUsers);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnOutCSV);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "CsvDemoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSVDemoForm";
            this.Load += new System.EventHandler(this.CsvDemoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOutCSV;
        private System.Windows.Forms.ListView listViewUsers;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colPassword;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPasssword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labUseTime;
        private System.Windows.Forms.Label labSum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader colPid;
        private System.Windows.Forms.Button btnInPutCsv;
    }
}