namespace ProductManage.UserControls
{
    partial class LogErrorControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvLogError = new System.Windows.Forms.DataGridView();
            this.txtSelectValue = new System.Windows.Forms.TextBox();
            this.grbSelectLog = new System.Windows.Forms.GroupBox();
            this.cmbSelectResult = new System.Windows.Forms.ComboBox();
            this.timeCheckStart = new System.Windows.Forms.DateTimePicker();
            this.labSelectMethod = new System.Windows.Forms.Label();
            this.btnSelectLastTen = new HslCommunication.Controls.UserButton();
            this.cmbSelectCondition = new System.Windows.Forms.ComboBox();
            this.btnSelect = new HslCommunication.Controls.UserButton();
            this.timeCheckEnd = new System.Windows.Forms.DateTimePicker();
            this.labFuhao = new System.Windows.Forms.Label();
            this.labSelectValue = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grbEditLog = new System.Windows.Forms.GroupBox();
            this.timeDealTime = new System.Windows.Forms.DateTimePicker();
            this.labDealTime = new System.Windows.Forms.Label();
            this.btnDelete = new HslCommunication.Controls.UserButton();
            this.btnUpdate = new HslCommunication.Controls.UserButton();
            this.cmbLogResult = new System.Windows.Forms.ComboBox();
            this.timeRecord = new System.Windows.Forms.DateTimePicker();
            this.labHappenTime = new System.Windows.Forms.Label();
            this.txtLogName = new System.Windows.Forms.TextBox();
            this.labLogContent = new System.Windows.Forms.Label();
            this.btnRecord = new HslCommunication.Controls.UserButton();
            this.labLogResult = new System.Windows.Forms.Label();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHappenTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDealTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogError)).BeginInit();
            this.grbSelectLog.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grbEditLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLogError
            // 
            this.dgvLogError.AllowUserToDeleteRows = false;
            this.dgvLogError.AllowUserToResizeColumns = false;
            this.dgvLogError.AllowUserToResizeRows = false;
            this.dgvLogError.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLogError.ColumnHeadersHeight = 30;
            this.dgvLogError.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colNo,
            this.colContent,
            this.colResult,
            this.colHappenTime,
            this.colDealTime});
            this.dgvLogError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLogError.Location = new System.Drawing.Point(0, 0);
            this.dgvLogError.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvLogError.Name = "dgvLogError";
            this.dgvLogError.ReadOnly = true;
            this.dgvLogError.RowTemplate.Height = 27;
            this.dgvLogError.Size = new System.Drawing.Size(1130, 457);
            this.dgvLogError.TabIndex = 0;
            this.dgvLogError.DataSourceChanged += new System.EventHandler(this.dgvLogError_DataSourceChanged);
            this.dgvLogError.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLogError_CellClick);
            // 
            // txtSelectValue
            // 
            this.txtSelectValue.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtSelectValue.Location = new System.Drawing.Point(107, 123);
            this.txtSelectValue.Name = "txtSelectValue";
            this.txtSelectValue.Size = new System.Drawing.Size(133, 28);
            this.txtSelectValue.TabIndex = 1;
            // 
            // grbSelectLog
            // 
            this.grbSelectLog.AutoSize = true;
            this.grbSelectLog.Controls.Add(this.cmbSelectResult);
            this.grbSelectLog.Controls.Add(this.txtSelectValue);
            this.grbSelectLog.Controls.Add(this.timeCheckStart);
            this.grbSelectLog.Controls.Add(this.labSelectMethod);
            this.grbSelectLog.Controls.Add(this.btnSelectLastTen);
            this.grbSelectLog.Controls.Add(this.cmbSelectCondition);
            this.grbSelectLog.Controls.Add(this.btnSelect);
            this.grbSelectLog.Controls.Add(this.timeCheckEnd);
            this.grbSelectLog.Controls.Add(this.labFuhao);
            this.grbSelectLog.Controls.Add(this.labSelectValue);
            this.grbSelectLog.Location = new System.Drawing.Point(3, 3);
            this.grbSelectLog.Name = "grbSelectLog";
            this.grbSelectLog.Size = new System.Drawing.Size(421, 274);
            this.grbSelectLog.TabIndex = 3;
            this.grbSelectLog.TabStop = false;
            this.grbSelectLog.Text = "搜索日志";
            // 
            // cmbSelectResult
            // 
            this.cmbSelectResult.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cmbSelectResult.FormattingEnabled = true;
            this.cmbSelectResult.Location = new System.Drawing.Point(107, 121);
            this.cmbSelectResult.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbSelectResult.Name = "cmbSelectResult";
            this.cmbSelectResult.Size = new System.Drawing.Size(133, 30);
            this.cmbSelectResult.TabIndex = 77;
            this.cmbSelectResult.Visible = false;
            this.cmbSelectResult.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSelectCondition_KeyPress);
            // 
            // timeCheckStart
            // 
            this.timeCheckStart.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.timeCheckStart.Font = new System.Drawing.Font("Tahoma", 10F);
            this.timeCheckStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeCheckStart.Location = new System.Drawing.Point(107, 121);
            this.timeCheckStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.timeCheckStart.Name = "timeCheckStart";
            this.timeCheckStart.Size = new System.Drawing.Size(133, 28);
            this.timeCheckStart.TabIndex = 71;
            this.timeCheckStart.Value = new System.DateTime(2018, 7, 17, 0, 0, 0, 0);
            this.timeCheckStart.Visible = false;
            // 
            // labSelectMethod
            // 
            this.labSelectMethod.AutoSize = true;
            this.labSelectMethod.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labSelectMethod.Location = new System.Drawing.Point(8, 57);
            this.labSelectMethod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labSelectMethod.Name = "labSelectMethod";
            this.labSelectMethod.Size = new System.Drawing.Size(84, 21);
            this.labSelectMethod.TabIndex = 76;
            this.labSelectMethod.Text = "查询方式:";
            // 
            // btnSelectLastTen
            // 
            this.btnSelectLastTen.BackColor = System.Drawing.Color.Transparent;
            this.btnSelectLastTen.CustomerInformation = "";
            this.btnSelectLastTen.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnSelectLastTen.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSelectLastTen.Location = new System.Drawing.Point(216, 197);
            this.btnSelectLastTen.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSelectLastTen.Name = "btnSelectLastTen";
            this.btnSelectLastTen.Size = new System.Drawing.Size(166, 47);
            this.btnSelectLastTen.TabIndex = 75;
            this.btnSelectLastTen.UIText = "查询最新20条日志";
            this.btnSelectLastTen.Click += new System.EventHandler(this.btnSelectLsetTen_Click);
            // 
            // cmbSelectCondition
            // 
            this.cmbSelectCondition.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cmbSelectCondition.FormattingEnabled = true;
            this.cmbSelectCondition.Location = new System.Drawing.Point(108, 53);
            this.cmbSelectCondition.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbSelectCondition.Name = "cmbSelectCondition";
            this.cmbSelectCondition.Size = new System.Drawing.Size(132, 29);
            this.cmbSelectCondition.TabIndex = 75;
            this.cmbSelectCondition.SelectedIndexChanged += new System.EventHandler(this.cmbSelectCondition_SelectedIndexChanged);
            this.cmbSelectCondition.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSelectCondition_KeyPress);
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.Transparent;
            this.btnSelect.CustomerInformation = "";
            this.btnSelect.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnSelect.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnSelect.Location = new System.Drawing.Point(51, 199);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(119, 45);
            this.btnSelect.TabIndex = 74;
            this.btnSelect.UIText = "查询";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // timeCheckEnd
            // 
            this.timeCheckEnd.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.timeCheckEnd.Font = new System.Drawing.Font("Tahoma", 10F);
            this.timeCheckEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeCheckEnd.Location = new System.Drawing.Point(270, 121);
            this.timeCheckEnd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.timeCheckEnd.Name = "timeCheckEnd";
            this.timeCheckEnd.Size = new System.Drawing.Size(134, 28);
            this.timeCheckEnd.TabIndex = 72;
            this.timeCheckEnd.Value = new System.DateTime(2018, 7, 17, 0, 0, 0, 0);
            this.timeCheckEnd.Visible = false;
            // 
            // labFuhao
            // 
            this.labFuhao.AutoSize = true;
            this.labFuhao.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labFuhao.Location = new System.Drawing.Point(243, 125);
            this.labFuhao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labFuhao.Name = "labFuhao";
            this.labFuhao.Size = new System.Drawing.Size(22, 21);
            this.labFuhao.TabIndex = 73;
            this.labFuhao.Text = "~";
            this.labFuhao.Visible = false;
            // 
            // labSelectValue
            // 
            this.labSelectValue.AutoSize = true;
            this.labSelectValue.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labSelectValue.Location = new System.Drawing.Point(8, 125);
            this.labSelectValue.Name = "labSelectValue";
            this.labSelectValue.Size = new System.Drawing.Size(84, 21);
            this.labSelectValue.TabIndex = 4;
            this.labSelectValue.Text = "查询条件:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grbEditLog);
            this.panel1.Controls.Add(this.grbSelectLog);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.panel1.Location = new System.Drawing.Point(0, 457);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1130, 274);
            this.panel1.TabIndex = 4;
            // 
            // grbEditLog
            // 
            this.grbEditLog.AutoSize = true;
            this.grbEditLog.Controls.Add(this.timeDealTime);
            this.grbEditLog.Controls.Add(this.labDealTime);
            this.grbEditLog.Controls.Add(this.btnDelete);
            this.grbEditLog.Controls.Add(this.btnUpdate);
            this.grbEditLog.Controls.Add(this.cmbLogResult);
            this.grbEditLog.Controls.Add(this.timeRecord);
            this.grbEditLog.Controls.Add(this.labHappenTime);
            this.grbEditLog.Controls.Add(this.txtLogName);
            this.grbEditLog.Controls.Add(this.labLogContent);
            this.grbEditLog.Controls.Add(this.btnRecord);
            this.grbEditLog.Controls.Add(this.labLogResult);
            this.grbEditLog.Location = new System.Drawing.Point(430, 3);
            this.grbEditLog.Name = "grbEditLog";
            this.grbEditLog.Size = new System.Drawing.Size(520, 282);
            this.grbEditLog.TabIndex = 77;
            this.grbEditLog.TabStop = false;
            this.grbEditLog.Text = "编辑日志";
            // 
            // timeDealTime
            // 
            this.timeDealTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.timeDealTime.Font = new System.Drawing.Font("Tahoma", 10F);
            this.timeDealTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeDealTime.Location = new System.Drawing.Point(105, 227);
            this.timeDealTime.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.timeDealTime.Name = "timeDealTime";
            this.timeDealTime.Size = new System.Drawing.Size(181, 28);
            this.timeDealTime.TabIndex = 85;
            this.timeDealTime.Value = new System.DateTime(2018, 7, 17, 0, 0, 0, 0);
            // 
            // labDealTime
            // 
            this.labDealTime.AutoSize = true;
            this.labDealTime.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labDealTime.Location = new System.Drawing.Point(7, 232);
            this.labDealTime.Name = "labDealTime";
            this.labDealTime.Size = new System.Drawing.Size(84, 21);
            this.labDealTime.TabIndex = 84;
            this.labDealTime.Text = "处理时间:";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.CustomerInformation = "";
            this.btnDelete.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnDelete.Location = new System.Drawing.Point(374, 118);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(105, 46);
            this.btnDelete.TabIndex = 83;
            this.btnDelete.UIText = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.CustomerInformation = "";
            this.btnUpdate.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnUpdate.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnUpdate.Location = new System.Drawing.Point(374, 38);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(105, 46);
            this.btnUpdate.TabIndex = 82;
            this.btnUpdate.UIText = "修改";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cmbLogResult
            // 
            this.cmbLogResult.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cmbLogResult.FormattingEnabled = true;
            this.cmbLogResult.Location = new System.Drawing.Point(105, 135);
            this.cmbLogResult.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbLogResult.Name = "cmbLogResult";
            this.cmbLogResult.Size = new System.Drawing.Size(137, 29);
            this.cmbLogResult.TabIndex = 81;
            this.cmbLogResult.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSelectCondition_KeyPress);
            // 
            // timeRecord
            // 
            this.timeRecord.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.timeRecord.Font = new System.Drawing.Font("Tahoma", 10F);
            this.timeRecord.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeRecord.Location = new System.Drawing.Point(105, 182);
            this.timeRecord.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.timeRecord.Name = "timeRecord";
            this.timeRecord.Size = new System.Drawing.Size(181, 28);
            this.timeRecord.TabIndex = 80;
            this.timeRecord.Value = new System.DateTime(2018, 7, 17, 0, 0, 0, 0);
            // 
            // labHappenTime
            // 
            this.labHappenTime.AutoSize = true;
            this.labHappenTime.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labHappenTime.Location = new System.Drawing.Point(7, 187);
            this.labHappenTime.Name = "labHappenTime";
            this.labHappenTime.Size = new System.Drawing.Size(84, 21);
            this.labHappenTime.TabIndex = 79;
            this.labHappenTime.Text = "发生时间:";
            // 
            // txtLogName
            // 
            this.txtLogName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtLogName.Location = new System.Drawing.Point(105, 38);
            this.txtLogName.Multiline = true;
            this.txtLogName.Name = "txtLogName";
            this.txtLogName.Size = new System.Drawing.Size(231, 74);
            this.txtLogName.TabIndex = 77;
            // 
            // labLogContent
            // 
            this.labLogContent.AutoSize = true;
            this.labLogContent.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labLogContent.Location = new System.Drawing.Point(7, 41);
            this.labLogContent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labLogContent.Name = "labLogContent";
            this.labLogContent.Size = new System.Drawing.Size(84, 21);
            this.labLogContent.TabIndex = 76;
            this.labLogContent.Text = "日志内容:";
            // 
            // btnRecord
            // 
            this.btnRecord.BackColor = System.Drawing.Color.Transparent;
            this.btnRecord.CustomerInformation = "";
            this.btnRecord.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnRecord.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnRecord.Location = new System.Drawing.Point(374, 196);
            this.btnRecord.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(102, 46);
            this.btnRecord.TabIndex = 74;
            this.btnRecord.UIText = "记录";
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // labLogResult
            // 
            this.labLogResult.AutoSize = true;
            this.labLogResult.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labLogResult.Location = new System.Drawing.Point(7, 139);
            this.labLogResult.Name = "labLogResult";
            this.labLogResult.Size = new System.Drawing.Size(84, 21);
            this.labLogResult.TabIndex = 4;
            this.labLogResult.Text = "日志结果:";
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colNo
            // 
            this.colNo.DataPropertyName = "LogNo";
            this.colNo.HeaderText = "日志编号";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            this.colNo.Visible = false;
            // 
            // colContent
            // 
            this.colContent.DataPropertyName = "LogContent";
            this.colContent.HeaderText = "日志内容";
            this.colContent.Name = "colContent";
            this.colContent.ReadOnly = true;
            // 
            // colResult
            // 
            this.colResult.DataPropertyName = "LogResult";
            this.colResult.HeaderText = "日志结果";
            this.colResult.Name = "colResult";
            this.colResult.ReadOnly = true;
            // 
            // colHappenTime
            // 
            this.colHappenTime.DataPropertyName = "HappenTime";
            dataGridViewCellStyle1.Format = "G";
            dataGridViewCellStyle1.NullValue = null;
            this.colHappenTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.colHappenTime.HeaderText = "发生时间";
            this.colHappenTime.Name = "colHappenTime";
            this.colHappenTime.ReadOnly = true;
            // 
            // colDealTime
            // 
            this.colDealTime.DataPropertyName = "DealTime";
            dataGridViewCellStyle2.Format = "G";
            dataGridViewCellStyle2.NullValue = null;
            this.colDealTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDealTime.HeaderText = "处理时间";
            this.colDealTime.Name = "colDealTime";
            this.colDealTime.ReadOnly = true;
            // 
            // LogErrorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.dgvLogError);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LogErrorControl";
            this.Size = new System.Drawing.Size(1130, 731);
            this.Load += new System.EventHandler(this.LogErrorControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogError)).EndInit();
            this.grbSelectLog.ResumeLayout(false);
            this.grbSelectLog.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbEditLog.ResumeLayout(false);
            this.grbEditLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLogError;
        private System.Windows.Forms.TextBox txtSelectValue;
        private System.Windows.Forms.GroupBox grbSelectLog;
        private System.Windows.Forms.Label labSelectValue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker timeCheckStart;
        private System.Windows.Forms.DateTimePicker timeCheckEnd;
        private System.Windows.Forms.Label labFuhao;
        private HslCommunication.Controls.UserButton btnSelect;
        private HslCommunication.Controls.UserButton btnSelectLastTen;
        private System.Windows.Forms.Label labSelectMethod;
        private System.Windows.Forms.ComboBox cmbSelectCondition;
        private System.Windows.Forms.GroupBox grbEditLog;
        private System.Windows.Forms.Label labLogContent;
        private HslCommunication.Controls.UserButton btnRecord;
        private System.Windows.Forms.Label labLogResult;
        private System.Windows.Forms.TextBox txtLogName;
        private System.Windows.Forms.Label labHappenTime;
        private System.Windows.Forms.DateTimePicker timeRecord;
        private System.Windows.Forms.ComboBox cmbLogResult;
        private System.Windows.Forms.ComboBox cmbSelectResult;
        private HslCommunication.Controls.UserButton btnUpdate;
        private HslCommunication.Controls.UserButton btnDelete;
        private System.Windows.Forms.DateTimePicker timeDealTime;
        private System.Windows.Forms.Label labDealTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHappenTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDealTime;
    }
}
