namespace CoderMachine
{
    partial class FormMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnTest = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCloseSerial = new System.Windows.Forms.Button();
            this.btnOpenSerial = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtData = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.chkEmpNo = new System.Windows.Forms.CheckBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.timeCheckStart = new System.Windows.Forms.DateTimePicker();
            this.chkProductDate = new System.Windows.Forms.CheckBox();
            this.timeCheckEnd = new System.Windows.Forms.DateTimePicker();
            this.labFuhao = new System.Windows.Forms.Label();
            this.chkID = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSelectByTerm = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSelectCondition = new System.Windows.Forms.ComboBox();
            this.txtCurPage = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAllCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPageCount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.cmbPageSize = new System.Windows.Forms.ComboBox();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userButton1 = new HslCommunication.Controls.UserButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 24);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1110, 685);
            this.tabControl1.TabIndex = 39;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.userButton1);
            this.tabPage1.Controls.Add(this.btnTest);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnCloseSerial);
            this.tabPage1.Controls.Add(this.btnOpenSerial);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.txtData);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(1102, 648);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "数据监控";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(115, 480);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(203, 73);
            this.btnTest.TabIndex = 5;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(36, 174);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 207);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1号";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(287, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 24);
            this.label13.TabIndex = 6;
            this.label13.Text = "mA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "是否合格";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(129, 156);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(152, 32);
            this.textBox3.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "电流值";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(129, 97);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(152, 32);
            this.textBox2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(129, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(152, 32);
            this.textBox1.TabIndex = 0;
            // 
            // btnCloseSerial
            // 
            this.btnCloseSerial.Location = new System.Drawing.Point(475, 325);
            this.btnCloseSerial.Name = "btnCloseSerial";
            this.btnCloseSerial.Size = new System.Drawing.Size(203, 73);
            this.btnCloseSerial.TabIndex = 3;
            this.btnCloseSerial.Text = "关闭串口";
            this.btnCloseSerial.UseVisualStyleBackColor = true;
            this.btnCloseSerial.Click += new System.EventHandler(this.btnCloseSerial_Click);
            // 
            // btnOpenSerial
            // 
            this.btnOpenSerial.Location = new System.Drawing.Point(475, 124);
            this.btnOpenSerial.Name = "btnOpenSerial";
            this.btnOpenSerial.Size = new System.Drawing.Size(203, 73);
            this.btnOpenSerial.TabIndex = 2;
            this.btnOpenSerial.Text = "打开串口";
            this.btnOpenSerial.UseVisualStyleBackColor = true;
            this.btnOpenSerial.Click += new System.EventHandler(this.btnOpenSerial_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(799, 505);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(203, 73);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存文本";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(737, 42);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(307, 400);
            this.txtData.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.btnSelectByTerm);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.cmbSelectCondition);
            this.tabPage2.Controls.Add(this.txtCurPage);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtAllCount);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.txtPageCount);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.linkLabel4);
            this.tabPage2.Controls.Add(this.cmbPageSize);
            this.tabPage2.Controls.Add(this.linkLabel3);
            this.tabPage2.Controls.Add(this.linkLabel1);
            this.tabPage2.Controls.Add(this.linkLabel2);
            this.tabPage2.Controls.Add(this.dgvProduct);
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(1102, 648);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "数据查询";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtEmpNo);
            this.groupBox2.Controls.Add(this.chkEmpNo);
            this.groupBox2.Controls.Add(this.txtID);
            this.groupBox2.Controls.Add(this.timeCheckStart);
            this.groupBox2.Controls.Add(this.chkProductDate);
            this.groupBox2.Controls.Add(this.timeCheckEnd);
            this.groupBox2.Controls.Add(this.labFuhao);
            this.groupBox2.Controls.Add(this.chkID);
            this.groupBox2.Location = new System.Drawing.Point(28, 453);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(730, 164);
            this.groupBox2.TabIndex = 97;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询方式";
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Enabled = false;
            this.txtEmpNo.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtEmpNo.Location = new System.Drawing.Point(152, 110);
            this.txtEmpNo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(154, 30);
            this.txtEmpNo.TabIndex = 97;
            // 
            // chkEmpNo
            // 
            this.chkEmpNo.AutoSize = true;
            this.chkEmpNo.Location = new System.Drawing.Point(33, 110);
            this.chkEmpNo.Name = "chkEmpNo";
            this.chkEmpNo.Size = new System.Drawing.Size(112, 28);
            this.chkEmpNo.TabIndex = 2;
            this.chkEmpNo.Text = "员工编号";
            this.chkEmpNo.UseVisualStyleBackColor = true;
            this.chkEmpNo.CheckedChanged += new System.EventHandler(this.chkEmpNo_CheckedChanged);
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtID.Location = new System.Drawing.Point(151, 52);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(154, 30);
            this.txtID.TabIndex = 75;
            // 
            // timeCheckStart
            // 
            this.timeCheckStart.CustomFormat = "yyyy/MM/dd";
            this.timeCheckStart.Enabled = false;
            this.timeCheckStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeCheckStart.Location = new System.Drawing.Point(395, 88);
            this.timeCheckStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.timeCheckStart.Name = "timeCheckStart";
            this.timeCheckStart.Size = new System.Drawing.Size(138, 32);
            this.timeCheckStart.TabIndex = 94;
            this.timeCheckStart.Value = new System.DateTime(2018, 7, 17, 0, 0, 0, 0);
            // 
            // chkProductDate
            // 
            this.chkProductDate.AutoSize = true;
            this.chkProductDate.Location = new System.Drawing.Point(395, 45);
            this.chkProductDate.Name = "chkProductDate";
            this.chkProductDate.Size = new System.Drawing.Size(112, 28);
            this.chkProductDate.TabIndex = 1;
            this.chkProductDate.Text = "生产日期";
            this.chkProductDate.UseVisualStyleBackColor = true;
            this.chkProductDate.CheckedChanged += new System.EventHandler(this.chkProductDate_CheckedChanged);
            // 
            // timeCheckEnd
            // 
            this.timeCheckEnd.CustomFormat = "yyyy/MM/dd";
            this.timeCheckEnd.Enabled = false;
            this.timeCheckEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeCheckEnd.Location = new System.Drawing.Point(574, 88);
            this.timeCheckEnd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.timeCheckEnd.Name = "timeCheckEnd";
            this.timeCheckEnd.Size = new System.Drawing.Size(138, 32);
            this.timeCheckEnd.TabIndex = 95;
            this.timeCheckEnd.Value = new System.DateTime(2018, 7, 17, 0, 0, 0, 0);
            // 
            // labFuhao
            // 
            this.labFuhao.AutoSize = true;
            this.labFuhao.Enabled = false;
            this.labFuhao.Location = new System.Drawing.Point(541, 92);
            this.labFuhao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labFuhao.Name = "labFuhao";
            this.labFuhao.Size = new System.Drawing.Size(25, 24);
            this.labFuhao.TabIndex = 96;
            this.labFuhao.Text = "~";
            // 
            // chkID
            // 
            this.chkID.AutoSize = true;
            this.chkID.Location = new System.Drawing.Point(33, 52);
            this.chkID.Name = "chkID";
            this.chkID.Size = new System.Drawing.Size(53, 28);
            this.chkID.TabIndex = 0;
            this.chkID.Text = "ID";
            this.chkID.UseVisualStyleBackColor = true;
            this.chkID.CheckedChanged += new System.EventHandler(this.chkID_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label10.Location = new System.Drawing.Point(35, 400);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 23);
            this.label10.TabIndex = 90;
            this.label10.Text = "每条页数:";
            // 
            // btnSelectByTerm
            // 
            this.btnSelectByTerm.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnSelectByTerm.Location = new System.Drawing.Point(813, 499);
            this.btnSelectByTerm.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSelectByTerm.Name = "btnSelectByTerm";
            this.btnSelectByTerm.Size = new System.Drawing.Size(191, 74);
            this.btnSelectByTerm.TabIndex = 72;
            this.btnSelectByTerm.Text = "查询";
            this.btnSelectByTerm.UseVisualStyleBackColor = true;
            this.btnSelectByTerm.Click += new System.EventHandler(this.btnSelectByTerm_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label4.Location = new System.Drawing.Point(809, 594);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 23);
            this.label4.TabIndex = 73;
            this.label4.Text = "查询方式:";
            this.label4.Visible = false;
            // 
            // cmbSelectCondition
            // 
            this.cmbSelectCondition.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cmbSelectCondition.FormattingEnabled = true;
            this.cmbSelectCondition.Location = new System.Drawing.Point(913, 591);
            this.cmbSelectCondition.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbSelectCondition.Name = "cmbSelectCondition";
            this.cmbSelectCondition.Size = new System.Drawing.Size(154, 30);
            this.cmbSelectCondition.TabIndex = 71;
            this.cmbSelectCondition.Visible = false;
            this.cmbSelectCondition.SelectedIndexChanged += new System.EventHandler(this.cmbSelectCondition_SelectedIndexChanged);
            this.cmbSelectCondition.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbPageSize_KeyPress);
            // 
            // txtCurPage
            // 
            this.txtCurPage.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtCurPage.Location = new System.Drawing.Point(458, 394);
            this.txtCurPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCurPage.Name = "txtCurPage";
            this.txtCurPage.ReadOnly = true;
            this.txtCurPage.Size = new System.Drawing.Size(68, 30);
            this.txtCurPage.TabIndex = 89;
            this.txtCurPage.Text = "0";
            this.txtCurPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label5.Location = new System.Drawing.Point(809, 453);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 23);
            this.label5.TabIndex = 74;
            this.label5.Text = "查询条件:";
            this.label5.Visible = false;
            // 
            // txtAllCount
            // 
            this.txtAllCount.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtAllCount.Location = new System.Drawing.Point(950, 394);
            this.txtAllCount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtAllCount.Name = "txtAllCount";
            this.txtAllCount.ReadOnly = true;
            this.txtAllCount.Size = new System.Drawing.Size(68, 30);
            this.txtAllCount.TabIndex = 87;
            this.txtAllCount.Text = "0";
            this.txtAllCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label9.Location = new System.Drawing.Point(734, 400);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 23);
            this.label9.TabIndex = 76;
            this.label9.Text = "共:";
            // 
            // txtPageCount
            // 
            this.txtPageCount.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtPageCount.Location = new System.Drawing.Point(780, 395);
            this.txtPageCount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPageCount.Name = "txtPageCount";
            this.txtPageCount.ReadOnly = true;
            this.txtPageCount.Size = new System.Drawing.Size(50, 30);
            this.txtPageCount.TabIndex = 88;
            this.txtPageCount.Text = "0";
            this.txtPageCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label12.Location = new System.Drawing.Point(887, 399);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 23);
            this.label12.TabIndex = 77;
            this.label12.Text = "总计:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label8.Location = new System.Drawing.Point(532, 399);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 23);
            this.label8.TabIndex = 86;
            this.label8.Text = "页";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label11.Location = new System.Drawing.Point(839, 399);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 23);
            this.label11.TabIndex = 78;
            this.label11.Text = "页";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label7.Location = new System.Drawing.Point(422, 399);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 23);
            this.label7.TabIndex = 85;
            this.label7.Text = "第";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label14.Location = new System.Drawing.Point(1024, 398);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 23);
            this.label14.TabIndex = 79;
            this.label14.Text = "条";
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Font = new System.Drawing.Font("Tahoma", 11F);
            this.linkLabel4.Location = new System.Drawing.Point(661, 399);
            this.linkLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(48, 23);
            this.linkLabel4.TabIndex = 84;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "末页";
            this.linkLabel4.VisitedLinkColor = System.Drawing.Color.Red;
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // cmbPageSize
            // 
            this.cmbPageSize.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cmbPageSize.FormattingEnabled = true;
            this.cmbPageSize.Items.AddRange(new object[] {
            "10",
            "50",
            "100",
            "300",
            "500",
            "700",
            "900"});
            this.cmbPageSize.Location = new System.Drawing.Point(139, 396);
            this.cmbPageSize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbPageSize.Name = "cmbPageSize";
            this.cmbPageSize.Size = new System.Drawing.Size(87, 30);
            this.cmbPageSize.TabIndex = 80;
            this.cmbPageSize.SelectedIndexChanged += new System.EventHandler(this.cmbPageSize_SelectedIndexChanged);
            this.cmbPageSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbPageSize_KeyPress);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Font = new System.Drawing.Font("Tahoma", 11F);
            this.linkLabel3.Location = new System.Drawing.Point(581, 398);
            this.linkLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(67, 23);
            this.linkLabel3.TabIndex = 83;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "下一页";
            this.linkLabel3.VisitedLinkColor = System.Drawing.Color.Red;
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.linkLabel1.Location = new System.Drawing.Point(276, 398);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(48, 23);
            this.linkLabel1.TabIndex = 81;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "首页";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Red;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Tahoma", 11F);
            this.linkLabel2.Location = new System.Drawing.Point(338, 398);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(67, 23);
            this.linkLabel2.TabIndex = 82;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "上一页";
            this.linkLabel2.VisitedLinkColor = System.Drawing.Color.Red;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToDeleteRows = false;
            this.dgvProduct.AllowUserToResizeColumns = false;
            this.dgvProduct.AllowUserToResizeRows = false;
            this.dgvProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProduct.ColumnHeadersHeight = 30;
            this.dgvProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colPID,
            this.colPass,
            this.colCurrent,
            this.colProductTime,
            this.colEmpNo});
            this.dgvProduct.Location = new System.Drawing.Point(19, 10);
            this.dgvProduct.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dgvProduct.MultiSelect = false;
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.ReadOnly = true;
            this.dgvProduct.RowTemplate.Height = 23;
            this.dgvProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProduct.Size = new System.Drawing.Size(1061, 356);
            this.dgvProduct.TabIndex = 39;
            this.dgvProduct.DataSourceChanged += new System.EventHandler(this.dgvProduct_DataSourceChanged);
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colPID
            // 
            this.colPID.DataPropertyName = "PID";
            this.colPID.HeaderText = "UID";
            this.colPID.Name = "colPID";
            this.colPID.ReadOnly = true;
            // 
            // colPass
            // 
            this.colPass.DataPropertyName = "Pass";
            this.colPass.HeaderText = "是否合格";
            this.colPass.Name = "colPass";
            this.colPass.ReadOnly = true;
            // 
            // colCurrent
            // 
            this.colCurrent.DataPropertyName = "CurrentVal";
            this.colCurrent.HeaderText = "电流值";
            this.colCurrent.Name = "colCurrent";
            this.colCurrent.ReadOnly = true;
            // 
            // colProductTime
            // 
            this.colProductTime.DataPropertyName = "ProductTime";
            this.colProductTime.HeaderText = "生产日期";
            this.colProductTime.Name = "colProductTime";
            this.colProductTime.ReadOnly = true;
            // 
            // colEmpNo
            // 
            this.colEmpNo.DataPropertyName = "EmpNo";
            this.colEmpNo.HeaderText = "员工编号";
            this.colEmpNo.Name = "colEmpNo";
            this.colEmpNo.ReadOnly = true;
            // 
            // userButton1
            // 
            this.userButton1.BackColor = System.Drawing.Color.Transparent;
            this.userButton1.CustomerInformation = "";
            this.userButton1.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.userButton1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.userButton1.Location = new System.Drawing.Point(140, 53);
            this.userButton1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.userButton1.Name = "userButton1";
            this.userButton1.Size = new System.Drawing.Size(203, 64);
            this.userButton1.TabIndex = 6;
            this.userButton1.UIText = "打开点检中心";
            this.userButton1.Click += new System.EventHandler(this.userButton1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1136, 715);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HT Laser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker timeCheckStart;
        private System.Windows.Forms.DateTimePicker timeCheckEnd;
        private System.Windows.Forms.Label labFuhao;
        private System.Windows.Forms.Button btnSelectByTerm;
        private System.Windows.Forms.TextBox txtCurPage;
        private System.Windows.Forms.TextBox txtAllCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPageCount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.ComboBox cmbPageSize;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCloseSerial;
        private System.Windows.Forms.Button btnOpenSerial;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkProductDate;
        private System.Windows.Forms.CheckBox chkID;
        private System.Windows.Forms.CheckBox chkEmpNo;
        private System.Windows.Forms.TextBox txtEmpNo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSelectCondition;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpNo;
        private System.Windows.Forms.Button btnTest;
        private HslCommunication.Controls.UserButton userButton1;
    }
}

