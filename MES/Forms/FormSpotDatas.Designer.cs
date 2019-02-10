namespace ProductManage.UI
{
    partial class FormSpotDatas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSpotDatas));
            this.dgvSpotData = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPWeldPower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPWeldSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPWeldPressure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPWeldFlow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPWeldXPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPWeldYPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPWeldZPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPWeldRPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpotResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFailReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpotTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labEach = new System.Windows.Forms.Label();
            this.txtCurPage = new System.Windows.Forms.TextBox();
            this.labPage = new System.Windows.Forms.Label();
            this.labWhich = new System.Windows.Forms.Label();
            this.labAfterPage = new System.Windows.Forms.LinkLabel();
            this.cmbPageSize = new System.Windows.Forms.ComboBox();
            this.labNextPage = new System.Windows.Forms.LinkLabel();
            this.labHomePage = new System.Windows.Forms.LinkLabel();
            this.labLastPage = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labSum = new System.Windows.Forms.Label();
            this.txtPageCount = new System.Windows.Forms.TextBox();
            this.labPage2 = new System.Windows.Forms.Label();
            this.btnSelectLast = new HslCommunication.Controls.UserButton();
            this.btnSelect = new HslCommunication.Controls.UserButton();
            this.txtSelectValue = new System.Windows.Forms.TextBox();
            this.labSelectValue = new System.Windows.Forms.Label();
            this.labSelectMethod = new System.Windows.Forms.Label();
            this.cmbSelectCondition = new System.Windows.Forms.ComboBox();
            this.cmbResult = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timeCheckStart = new System.Windows.Forms.DateTimePicker();
            this.timeCheckEnd = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpotData)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSpotData
            // 
            this.dgvSpotData.AllowUserToDeleteRows = false;
            this.dgvSpotData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSpotData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSpotData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSpotData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colEmpNo,
            this.colPWeldPower,
            this.colPWeldSpeed,
            this.colPWeldPressure,
            this.colPWeldFlow,
            this.colPWeldXPos,
            this.colPWeldYPos,
            this.colPWeldZPos,
            this.colPWeldRPos,
            this.colSpotResult,
            this.colFailReason,
            this.colSpotTime});
            this.dgvSpotData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSpotData.Location = new System.Drawing.Point(0, 0);
            this.dgvSpotData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvSpotData.MultiSelect = false;
            this.dgvSpotData.Name = "dgvSpotData";
            this.dgvSpotData.ReadOnly = true;
            this.dgvSpotData.RowHeadersWidth = 60;
            this.dgvSpotData.RowTemplate.Height = 23;
            this.dgvSpotData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSpotData.Size = new System.Drawing.Size(1343, 418);
            this.dgvSpotData.TabIndex = 38;
            this.dgvSpotData.DataSourceChanged += new System.EventHandler(this.dgvSpotData_DataSourceChanged);
            // 
            // colID
            // 
            this.colID.DataPropertyName = "SID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colEmpNo
            // 
            this.colEmpNo.DataPropertyName = "EmpNo";
            this.colEmpNo.HeaderText = "点检人";
            this.colEmpNo.Name = "colEmpNo";
            this.colEmpNo.ReadOnly = true;
            // 
            // colPWeldPower
            // 
            this.colPWeldPower.DataPropertyName = "PWeldPower";
            this.colPWeldPower.HeaderText = "焊接功率(W)";
            this.colPWeldPower.Name = "colPWeldPower";
            this.colPWeldPower.ReadOnly = true;
            // 
            // colPWeldSpeed
            // 
            this.colPWeldSpeed.DataPropertyName = "PWeldSpeed";
            this.colPWeldSpeed.HeaderText = "焊接速度(°/s)";
            this.colPWeldSpeed.Name = "colPWeldSpeed";
            this.colPWeldSpeed.ReadOnly = true;
            // 
            // colPWeldPressure
            // 
            this.colPWeldPressure.DataPropertyName = "PWeldPressure";
            this.colPWeldPressure.HeaderText = "气体压力值(MPa)";
            this.colPWeldPressure.Name = "colPWeldPressure";
            this.colPWeldPressure.ReadOnly = true;
            // 
            // colPWeldFlow
            // 
            this.colPWeldFlow.DataPropertyName = "PWeldFlow";
            this.colPWeldFlow.HeaderText = "保护气流量(L/min)";
            this.colPWeldFlow.Name = "colPWeldFlow";
            this.colPWeldFlow.ReadOnly = true;
            // 
            // colPWeldXPos
            // 
            this.colPWeldXPos.DataPropertyName = "PWeldXPos";
            this.colPWeldXPos.HeaderText = "X坐标(mm)";
            this.colPWeldXPos.Name = "colPWeldXPos";
            this.colPWeldXPos.ReadOnly = true;
            // 
            // colPWeldYPos
            // 
            this.colPWeldYPos.DataPropertyName = "PWeldYPos";
            this.colPWeldYPos.HeaderText = "Y坐标(mm)";
            this.colPWeldYPos.Name = "colPWeldYPos";
            this.colPWeldYPos.ReadOnly = true;
            // 
            // colPWeldZPos
            // 
            this.colPWeldZPos.DataPropertyName = "PWeldZPos";
            this.colPWeldZPos.HeaderText = "Z坐标(mm)";
            this.colPWeldZPos.Name = "colPWeldZPos";
            this.colPWeldZPos.ReadOnly = true;
            // 
            // colPWeldRPos
            // 
            this.colPWeldRPos.DataPropertyName = "PWeldRPos";
            this.colPWeldRPos.HeaderText = "R坐标(°)";
            this.colPWeldRPos.Name = "colPWeldRPos";
            this.colPWeldRPos.ReadOnly = true;
            // 
            // colSpotResult
            // 
            this.colSpotResult.DataPropertyName = "SpotResult";
            this.colSpotResult.HeaderText = "点检结果";
            this.colSpotResult.Name = "colSpotResult";
            this.colSpotResult.ReadOnly = true;
            // 
            // colFailReason
            // 
            this.colFailReason.DataPropertyName = "FailReason";
            this.colFailReason.HeaderText = "点检失败原因";
            this.colFailReason.Name = "colFailReason";
            this.colFailReason.ReadOnly = true;
            // 
            // colSpotTime
            // 
            this.colSpotTime.DataPropertyName = "SpotTime";
            dataGridViewCellStyle1.Format = "G";
            dataGridViewCellStyle1.NullValue = null;
            this.colSpotTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.colSpotTime.HeaderText = "点检时间";
            this.colSpotTime.Name = "colSpotTime";
            this.colSpotTime.ReadOnly = true;
            // 
            // labEach
            // 
            this.labEach.AutoSize = true;
            this.labEach.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labEach.Location = new System.Drawing.Point(36, 25);
            this.labEach.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labEach.Name = "labEach";
            this.labEach.Size = new System.Drawing.Size(108, 27);
            this.labEach.TabIndex = 67;
            this.labEach.Text = "每页条数:";
            // 
            // txtCurPage
            // 
            this.txtCurPage.Font = new System.Drawing.Font("Tahoma", 13F);
            this.txtCurPage.Location = new System.Drawing.Point(605, 22);
            this.txtCurPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCurPage.Name = "txtCurPage";
            this.txtCurPage.ReadOnly = true;
            this.txtCurPage.Size = new System.Drawing.Size(68, 34);
            this.txtCurPage.TabIndex = 66;
            this.txtCurPage.Text = "1";
            this.txtCurPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labPage
            // 
            this.labPage.AutoSize = true;
            this.labPage.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labPage.Location = new System.Drawing.Point(682, 26);
            this.labPage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labPage.Name = "labPage";
            this.labPage.Size = new System.Drawing.Size(34, 27);
            this.labPage.TabIndex = 65;
            this.labPage.Text = "页";
            // 
            // labWhich
            // 
            this.labWhich.AutoSize = true;
            this.labWhich.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labWhich.Location = new System.Drawing.Point(548, 26);
            this.labWhich.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labWhich.Name = "labWhich";
            this.labWhich.Size = new System.Drawing.Size(34, 27);
            this.labWhich.TabIndex = 64;
            this.labWhich.Text = "第";
            // 
            // labAfterPage
            // 
            this.labAfterPage.AutoSize = true;
            this.labAfterPage.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labAfterPage.Location = new System.Drawing.Point(885, 26);
            this.labAfterPage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labAfterPage.Name = "labAfterPage";
            this.labAfterPage.Size = new System.Drawing.Size(56, 27);
            this.labAfterPage.TabIndex = 63;
            this.labAfterPage.TabStop = true;
            this.labAfterPage.Text = "末页";
            this.labAfterPage.VisitedLinkColor = System.Drawing.Color.Red;
            this.labAfterPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // cmbPageSize
            // 
            this.cmbPageSize.Font = new System.Drawing.Font("Tahoma", 13F);
            this.cmbPageSize.FormattingEnabled = true;
            this.cmbPageSize.Items.AddRange(new object[] {
            "20",
            "50",
            "100",
            "300",
            "500",
            "700",
            "900"});
            this.cmbPageSize.Location = new System.Drawing.Point(152, 22);
            this.cmbPageSize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbPageSize.Name = "cmbPageSize";
            this.cmbPageSize.Size = new System.Drawing.Size(118, 35);
            this.cmbPageSize.TabIndex = 59;
            this.cmbPageSize.SelectedIndexChanged += new System.EventHandler(this.cmbPageSize_SelectedIndexChanged);
            this.cmbPageSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbPageSize_KeyPress);
            // 
            // labNextPage
            // 
            this.labNextPage.AutoSize = true;
            this.labNextPage.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labNextPage.Location = new System.Drawing.Point(780, 26);
            this.labNextPage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labNextPage.Name = "labNextPage";
            this.labNextPage.Size = new System.Drawing.Size(78, 27);
            this.labNextPage.TabIndex = 62;
            this.labNextPage.TabStop = true;
            this.labNextPage.Text = "下一页";
            this.labNextPage.VisitedLinkColor = System.Drawing.Color.Red;
            this.labNextPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // labHomePage
            // 
            this.labHomePage.AutoSize = true;
            this.labHomePage.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labHomePage.Location = new System.Drawing.Point(341, 25);
            this.labHomePage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labHomePage.Name = "labHomePage";
            this.labHomePage.Size = new System.Drawing.Size(56, 27);
            this.labHomePage.TabIndex = 60;
            this.labHomePage.TabStop = true;
            this.labHomePage.Text = "首页";
            this.labHomePage.VisitedLinkColor = System.Drawing.Color.Red;
            this.labHomePage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // labLastPage
            // 
            this.labLastPage.AutoSize = true;
            this.labLastPage.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labLastPage.Location = new System.Drawing.Point(426, 25);
            this.labLastPage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labLastPage.Name = "labLastPage";
            this.labLastPage.Size = new System.Drawing.Size(78, 27);
            this.labLastPage.TabIndex = 61;
            this.labLastPage.TabStop = true;
            this.labLastPage.Text = "上一页";
            this.labLastPage.VisitedLinkColor = System.Drawing.Color.Red;
            this.labLastPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.timeCheckEnd);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.labSum);
            this.panel1.Controls.Add(this.txtPageCount);
            this.panel1.Controls.Add(this.labPage2);
            this.panel1.Controls.Add(this.btnSelectLast);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.txtSelectValue);
            this.panel1.Controls.Add(this.labSelectValue);
            this.panel1.Controls.Add(this.labSelectMethod);
            this.panel1.Controls.Add(this.cmbSelectCondition);
            this.panel1.Controls.Add(this.labNextPage);
            this.panel1.Controls.Add(this.labEach);
            this.panel1.Controls.Add(this.labLastPage);
            this.panel1.Controls.Add(this.txtCurPage);
            this.panel1.Controls.Add(this.labHomePage);
            this.panel1.Controls.Add(this.labPage);
            this.panel1.Controls.Add(this.cmbPageSize);
            this.panel1.Controls.Add(this.labWhich);
            this.panel1.Controls.Add(this.labAfterPage);
            this.panel1.Controls.Add(this.cmbResult);
            this.panel1.Controls.Add(this.timeCheckStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 418);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1343, 230);
            this.panel1.TabIndex = 68;
            // 
            // labSum
            // 
            this.labSum.AutoSize = true;
            this.labSum.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labSum.Location = new System.Drawing.Point(1006, 25);
            this.labSum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labSum.Name = "labSum";
            this.labSum.Size = new System.Drawing.Size(42, 27);
            this.labSum.TabIndex = 75;
            this.labSum.Text = "共:";
            // 
            // txtPageCount
            // 
            this.txtPageCount.Font = new System.Drawing.Font("Tahoma", 13F);
            this.txtPageCount.Location = new System.Drawing.Point(1055, 22);
            this.txtPageCount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPageCount.Name = "txtPageCount";
            this.txtPageCount.ReadOnly = true;
            this.txtPageCount.Size = new System.Drawing.Size(63, 34);
            this.txtPageCount.TabIndex = 80;
            this.txtPageCount.Text = "1";
            this.txtPageCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labPage2
            // 
            this.labPage2.AutoSize = true;
            this.labPage2.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labPage2.Location = new System.Drawing.Point(1138, 27);
            this.labPage2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labPage2.Name = "labPage2";
            this.labPage2.Size = new System.Drawing.Size(34, 27);
            this.labPage2.TabIndex = 77;
            this.labPage2.Text = "页";
            // 
            // btnSelectLast
            // 
            this.btnSelectLast.BackColor = System.Drawing.Color.Transparent;
            this.btnSelectLast.CustomerInformation = "";
            this.btnSelectLast.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnSelectLast.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.btnSelectLast.Location = new System.Drawing.Point(760, 114);
            this.btnSelectLast.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelectLast.Name = "btnSelectLast";
            this.btnSelectLast.Size = new System.Drawing.Size(219, 59);
            this.btnSelectLast.TabIndex = 74;
            this.btnSelectLast.UIText = "查询最新点检数据";
            this.btnSelectLast.Click += new System.EventHandler(this.btnSelectLast_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.Transparent;
            this.btnSelect.CustomerInformation = "";
            this.btnSelect.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnSelect.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.btnSelect.Location = new System.Drawing.Point(531, 114);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(142, 59);
            this.btnSelect.TabIndex = 73;
            this.btnSelect.UIText = "查询";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtSelectValue
            // 
            this.txtSelectValue.Font = new System.Drawing.Font("Tahoma", 13F);
            this.txtSelectValue.Location = new System.Drawing.Point(152, 170);
            this.txtSelectValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSelectValue.Name = "txtSelectValue";
            this.txtSelectValue.Size = new System.Drawing.Size(156, 34);
            this.txtSelectValue.TabIndex = 72;
            // 
            // labSelectValue
            // 
            this.labSelectValue.AutoSize = true;
            this.labSelectValue.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labSelectValue.Location = new System.Drawing.Point(36, 173);
            this.labSelectValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labSelectValue.Name = "labSelectValue";
            this.labSelectValue.Size = new System.Drawing.Size(108, 27);
            this.labSelectValue.TabIndex = 71;
            this.labSelectValue.Text = "查询条件:";
            // 
            // labSelectMethod
            // 
            this.labSelectMethod.AutoSize = true;
            this.labSelectMethod.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labSelectMethod.Location = new System.Drawing.Point(36, 101);
            this.labSelectMethod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labSelectMethod.Name = "labSelectMethod";
            this.labSelectMethod.Size = new System.Drawing.Size(108, 27);
            this.labSelectMethod.TabIndex = 69;
            this.labSelectMethod.Text = "查询方式:";
            // 
            // cmbSelectCondition
            // 
            this.cmbSelectCondition.Font = new System.Drawing.Font("Tahoma", 13F);
            this.cmbSelectCondition.FormattingEnabled = true;
            this.cmbSelectCondition.Location = new System.Drawing.Point(152, 98);
            this.cmbSelectCondition.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbSelectCondition.Name = "cmbSelectCondition";
            this.cmbSelectCondition.Size = new System.Drawing.Size(156, 35);
            this.cmbSelectCondition.TabIndex = 68;
            this.cmbSelectCondition.SelectedIndexChanged += new System.EventHandler(this.cmbSelectCondition_SelectedIndexChanged);
            this.cmbSelectCondition.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbPageSize_KeyPress);
            // 
            // cmbResult
            // 
            this.cmbResult.Font = new System.Drawing.Font("Tahoma", 13F);
            this.cmbResult.FormattingEnabled = true;
            this.cmbResult.Location = new System.Drawing.Point(152, 170);
            this.cmbResult.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbResult.Name = "cmbResult";
            this.cmbResult.Size = new System.Drawing.Size(156, 35);
            this.cmbResult.TabIndex = 81;
            this.cmbResult.Visible = false;
            this.cmbResult.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbPageSize_KeyPress);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvSpotData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1343, 418);
            this.panel2.TabIndex = 69;
            // 
            // timeCheckStart
            // 
            this.timeCheckStart.CustomFormat = "yyyy/MM/dd";
            this.timeCheckStart.Font = new System.Drawing.Font("Tahoma", 13F);
            this.timeCheckStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeCheckStart.Location = new System.Drawing.Point(152, 170);
            this.timeCheckStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.timeCheckStart.Name = "timeCheckStart";
            this.timeCheckStart.Size = new System.Drawing.Size(156, 34);
            this.timeCheckStart.TabIndex = 82;
            this.timeCheckStart.Value = new System.DateTime(2018, 7, 17, 0, 0, 0, 0);
            this.timeCheckStart.Visible = false;
            // 
            // timeCheckEnd
            // 
            this.timeCheckEnd.CustomFormat = "yyyy/MM/dd";
            this.timeCheckEnd.Font = new System.Drawing.Font("Tahoma", 13F);
            this.timeCheckEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeCheckEnd.Location = new System.Drawing.Point(337, 170);
            this.timeCheckEnd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.timeCheckEnd.Name = "timeCheckEnd";
            this.timeCheckEnd.Size = new System.Drawing.Size(139, 34);
            this.timeCheckEnd.TabIndex = 83;
            this.timeCheckEnd.Value = new System.DateTime(2018, 7, 17, 0, 0, 0, 0);
            this.timeCheckEnd.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label6.Location = new System.Drawing.Point(310, 174);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 23);
            this.label6.TabIndex = 84;
            this.label6.Text = "~";
            this.label6.Visible = false;
            // 
            // FormSpotDatas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 648);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "FormSpotDatas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "点检数据中心";
            this.Load += new System.EventHandler(this.FormSpotDatas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpotData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSpotData;
        private System.Windows.Forms.Label labEach;
        private System.Windows.Forms.TextBox txtCurPage;
        private System.Windows.Forms.Label labPage;
        private System.Windows.Forms.Label labWhich;
        private System.Windows.Forms.LinkLabel labAfterPage;
        private System.Windows.Forms.ComboBox cmbPageSize;
        private System.Windows.Forms.LinkLabel labNextPage;
        private System.Windows.Forms.LinkLabel labHomePage;
        private System.Windows.Forms.LinkLabel labLastPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labSelectMethod;
        private System.Windows.Forms.ComboBox cmbSelectCondition;
        private System.Windows.Forms.Label labSelectValue;
        private System.Windows.Forms.TextBox txtSelectValue;
        private HslCommunication.Controls.UserButton btnSelect;
        private System.Windows.Forms.Panel panel2;
        private HslCommunication.Controls.UserButton btnSelectLast;
        private System.Windows.Forms.Label labSum;
        private System.Windows.Forms.TextBox txtPageCount;
        private System.Windows.Forms.Label labPage2;
        private System.Windows.Forms.ComboBox cmbResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPWeldPower;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPWeldSpeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPWeldPressure;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPWeldFlow;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPWeldXPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPWeldYPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPWeldZPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPWeldRPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpotResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFailReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpotTime;
        private System.Windows.Forms.DateTimePicker timeCheckStart;
        private System.Windows.Forms.DateTimePicker timeCheckEnd;
        private System.Windows.Forms.Label label6;
    }
}