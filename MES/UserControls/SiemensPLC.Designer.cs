namespace MES.UserControls
{
    partial class SiemensPLC
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
            this.btnDisConnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtManyReadResult = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnManyRead = new System.Windows.Forms.Button();
            this.txtManyReadLen = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtManyReadAddr = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.grbReadOnTime = new System.Windows.Forms.GroupBox();
            this.label35 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.txtTimingAddress = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.userCurve1 = new HslCommunication.Controls.UserCurve();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_read_short = new System.Windows.Forms.Button();
            this.button_read_double = new System.Windows.Forms.Button();
            this.button_read_float = new System.Windows.Forms.Button();
            this.txtStrLength = new System.Windows.Forms.TextBox();
            this.button_read_string = new System.Windows.Forms.Button();
            this.button_read_int = new System.Windows.Forms.Button();
            this.button_read_byte = new System.Windows.Forms.Button();
            this.button_read_bool = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.button_write_string = new System.Windows.Forms.Button();
            this.button_write_double = new System.Windows.Forms.Button();
            this.button_write_float = new System.Windows.Forms.Button();
            this.button_write_int = new System.Windows.Forms.Button();
            this.button_write_short = new System.Windows.Forms.Button();
            this.button_write_byte = new System.Windows.Forms.Button();
            this.button_write_bool = new System.Windows.Forms.Button();
            this.txtWValue = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtWAddress = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grbReadOnTime.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDisConnect
            // 
            this.btnDisConnect.Enabled = false;
            this.btnDisConnect.Location = new System.Drawing.Point(907, 16);
            this.btnDisConnect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDisConnect.Name = "btnDisConnect";
            this.btnDisConnect.Size = new System.Drawing.Size(117, 33);
            this.btnDisConnect.TabIndex = 33;
            this.btnDisConnect.Text = "断开连接";
            this.btnDisConnect.UseVisualStyleBackColor = true;
            this.btnDisConnect.Click += new System.EventHandler(this.btnDisConnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(770, 16);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(117, 33);
            this.btnConnect.TabIndex = 32;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(564, 19);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPort.Name = "txtPort";
            this.txtPort.ReadOnly = true;
            this.txtPort.Size = new System.Drawing.Size(180, 25);
            this.txtPort.TabIndex = 31;
            this.txtPort.Text = "102";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(479, 23);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 18);
            this.label17.TabIndex = 30;
            this.label17.Text = "端口号：";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(236, 22);
            this.txtIP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(180, 25);
            this.txtIP.TabIndex = 29;
            this.txtIP.Text = "192.168.0.100";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(164, 23);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 18);
            this.label18.TabIndex = 28;
            this.label18.Text = "IP地址：";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.grbReadOnTime);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Enabled = false;
            this.panel3.Location = new System.Drawing.Point(4, 55);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1157, 646);
            this.panel3.TabIndex = 26;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtManyReadResult);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.btnManyRead);
            this.groupBox3.Controls.Add(this.txtManyReadLen);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtManyReadAddr);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(12, 309);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(593, 330);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "批量读取测试";
            // 
            // txtManyReadResult
            // 
            this.txtManyReadResult.Location = new System.Drawing.Point(70, 70);
            this.txtManyReadResult.Multiline = true;
            this.txtManyReadResult.Name = "txtManyReadResult";
            this.txtManyReadResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtManyReadResult.Size = new System.Drawing.Size(445, 78);
            this.txtManyReadResult.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 18);
            this.label13.TabIndex = 9;
            this.label13.Text = "结果：";
            // 
            // btnManyRead
            // 
            this.btnManyRead.Location = new System.Drawing.Point(433, 34);
            this.btnManyRead.Name = "btnManyRead";
            this.btnManyRead.Size = new System.Drawing.Size(82, 28);
            this.btnManyRead.TabIndex = 8;
            this.btnManyRead.Text = "批量读取";
            this.btnManyRead.UseVisualStyleBackColor = true;
            this.btnManyRead.Click += new System.EventHandler(this.btnManyRead_Click);
            // 
            // txtManyReadLen
            // 
            this.txtManyReadLen.Location = new System.Drawing.Point(246, 37);
            this.txtManyReadLen.Name = "txtManyReadLen";
            this.txtManyReadLen.Size = new System.Drawing.Size(102, 25);
            this.txtManyReadLen.TabIndex = 7;
            this.txtManyReadLen.Text = "10";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(192, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 18);
            this.label12.TabIndex = 6;
            this.label12.Text = "长度：";
            // 
            // txtManyReadAddr
            // 
            this.txtManyReadAddr.Location = new System.Drawing.Point(70, 37);
            this.txtManyReadAddr.Name = "txtManyReadAddr";
            this.txtManyReadAddr.Size = new System.Drawing.Size(102, 25);
            this.txtManyReadAddr.TabIndex = 5;
            this.txtManyReadAddr.Text = "M100";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 18);
            this.label11.TabIndex = 4;
            this.label11.Text = "地址：";
            // 
            // grbReadOnTime
            // 
            this.grbReadOnTime.Controls.Add(this.label35);
            this.grbReadOnTime.Controls.Add(this.btnStart);
            this.grbReadOnTime.Controls.Add(this.txtInterval);
            this.grbReadOnTime.Controls.Add(this.label30);
            this.grbReadOnTime.Controls.Add(this.label32);
            this.grbReadOnTime.Controls.Add(this.txtTimingAddress);
            this.grbReadOnTime.Controls.Add(this.label33);
            this.grbReadOnTime.Controls.Add(this.userCurve1);
            this.grbReadOnTime.Enabled = false;
            this.grbReadOnTime.Location = new System.Drawing.Point(612, 309);
            this.grbReadOnTime.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grbReadOnTime.Name = "grbReadOnTime";
            this.grbReadOnTime.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grbReadOnTime.Size = new System.Drawing.Size(539, 330);
            this.grbReadOnTime.TabIndex = 27;
            this.grbReadOnTime.TabStop = false;
            this.grbReadOnTime.Text = "定时读取，曲线显示";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(400, 35);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(28, 18);
            this.label35.TabIndex = 10;
            this.label35.Text = "ms";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(441, 29);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(90, 33);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "启动";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(328, 33);
            this.txtInterval.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInterval.Size = new System.Drawing.Size(68, 25);
            this.txtInterval.TabIndex = 8;
            this.txtInterval.Text = "300";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(273, 35);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(53, 18);
            this.label30.TabIndex = 7;
            this.label30.Text = "间隔：";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label32.Location = new System.Drawing.Point(81, 69);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(191, 18);
            this.label32.TabIndex = 6;
            this.label32.Text = "默认数据的类型，为short：";
            // 
            // txtTimingAddress
            // 
            this.txtTimingAddress.Location = new System.Drawing.Point(82, 32);
            this.txtTimingAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTimingAddress.Name = "txtTimingAddress";
            this.txtTimingAddress.Size = new System.Drawing.Size(169, 25);
            this.txtTimingAddress.TabIndex = 5;
            this.txtTimingAddress.Text = "M100";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(13, 35);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(53, 18);
            this.label33.TabIndex = 4;
            this.label33.Text = "地址：";
            // 
            // userCurve1
            // 
            this.userCurve1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.userCurve1.Location = new System.Drawing.Point(17, 98);
            this.userCurve1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userCurve1.Name = "userCurve1";
            this.userCurve1.Size = new System.Drawing.Size(514, 225);
            this.userCurve1.TabIndex = 0;
            this.userCurve1.ValueMaxLeft = 200F;
            this.userCurve1.ValueMaxRight = 200F;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_read_short);
            this.groupBox1.Controls.Add(this.button_read_double);
            this.groupBox1.Controls.Add(this.button_read_float);
            this.groupBox1.Controls.Add(this.txtStrLength);
            this.groupBox1.Controls.Add(this.button_read_string);
            this.groupBox1.Controls.Add(this.button_read_int);
            this.groupBox1.Controls.Add(this.button_read_byte);
            this.groupBox1.Controls.Add(this.button_read_bool);
            this.groupBox1.Controls.Add(this.txtResult);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Location = new System.Drawing.Point(12, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(593, 285);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "单数据读取测试";
            // 
            // button_read_short
            // 
            this.button_read_short.Location = new System.Drawing.Point(342, 98);
            this.button_read_short.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_read_short.Name = "button_read_short";
            this.button_read_short.Size = new System.Drawing.Size(105, 33);
            this.button_read_short.TabIndex = 21;
            this.button_read_short.Text = "short读取";
            this.button_read_short.UseVisualStyleBackColor = true;
            // 
            // button_read_double
            // 
            this.button_read_double.Location = new System.Drawing.Point(469, 162);
            this.button_read_double.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_read_double.Name = "button_read_double";
            this.button_read_double.Size = new System.Drawing.Size(105, 33);
            this.button_read_double.TabIndex = 20;
            this.button_read_double.Text = "double读取";
            this.button_read_double.UseVisualStyleBackColor = true;
            // 
            // button_read_float
            // 
            this.button_read_float.Location = new System.Drawing.Point(342, 162);
            this.button_read_float.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_read_float.Name = "button_read_float";
            this.button_read_float.Size = new System.Drawing.Size(105, 33);
            this.button_read_float.TabIndex = 19;
            this.button_read_float.Text = "float读取";
            this.button_read_float.UseVisualStyleBackColor = true;
            // 
            // txtStrLength
            // 
            this.txtStrLength.Location = new System.Drawing.Point(391, 231);
            this.txtStrLength.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtStrLength.Name = "txtStrLength";
            this.txtStrLength.Size = new System.Drawing.Size(52, 25);
            this.txtStrLength.TabIndex = 17;
            this.txtStrLength.Text = "10";
            // 
            // button_read_string
            // 
            this.button_read_string.Location = new System.Drawing.Point(469, 227);
            this.button_read_string.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_read_string.Name = "button_read_string";
            this.button_read_string.Size = new System.Drawing.Size(105, 33);
            this.button_read_string.TabIndex = 16;
            this.button_read_string.Text = "字符串读取";
            this.button_read_string.UseVisualStyleBackColor = true;
            // 
            // button_read_int
            // 
            this.button_read_int.Location = new System.Drawing.Point(469, 98);
            this.button_read_int.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_read_int.Name = "button_read_int";
            this.button_read_int.Size = new System.Drawing.Size(105, 33);
            this.button_read_int.TabIndex = 10;
            this.button_read_int.Text = "int读取";
            this.button_read_int.UseVisualStyleBackColor = true;
            // 
            // button_read_byte
            // 
            this.button_read_byte.Location = new System.Drawing.Point(469, 35);
            this.button_read_byte.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_read_byte.Name = "button_read_byte";
            this.button_read_byte.Size = new System.Drawing.Size(105, 33);
            this.button_read_byte.TabIndex = 7;
            this.button_read_byte.Text = "byte读取";
            this.button_read_byte.UseVisualStyleBackColor = true;
            // 
            // button_read_bool
            // 
            this.button_read_bool.Location = new System.Drawing.Point(342, 35);
            this.button_read_bool.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_read_bool.Name = "button_read_bool";
            this.button_read_bool.Size = new System.Drawing.Size(105, 33);
            this.button_read_bool.TabIndex = 6;
            this.button_read_bool.Text = "bool读取";
            this.button_read_bool.UseVisualStyleBackColor = true;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(81, 67);
            this.txtResult.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(238, 194);
            this.txtResult.TabIndex = 5;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 69);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 18);
            this.label19.TabIndex = 4;
            this.label19.Text = "结果：";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(81, 32);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(238, 25);
            this.txtAddress.TabIndex = 3;
            this.txtAddress.Text = "M100";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 35);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 18);
            this.label20.TabIndex = 2;
            this.label20.Text = "地址：";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(336, 235);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 18);
            this.label21.TabIndex = 18;
            this.label21.Text = "长度：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.button_write_string);
            this.groupBox2.Controls.Add(this.button_write_double);
            this.groupBox2.Controls.Add(this.button_write_float);
            this.groupBox2.Controls.Add(this.button_write_int);
            this.groupBox2.Controls.Add(this.button_write_short);
            this.groupBox2.Controls.Add(this.button_write_byte);
            this.groupBox2.Controls.Add(this.button_write_bool);
            this.groupBox2.Controls.Add(this.txtWValue);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.txtWAddress);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Location = new System.Drawing.Point(617, 18);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(526, 285);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "单数据写入测试";
            // 
            // label22
            // 
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(78, 98);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(189, 48);
            this.label22.TabIndex = 17;
            this.label22.Text = "注意：值的字符串需要能转化成对应的数据类型";
            // 
            // button_write_string
            // 
            this.button_write_string.Location = new System.Drawing.Point(400, 185);
            this.button_write_string.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_write_string.Name = "button_write_string";
            this.button_write_string.Size = new System.Drawing.Size(105, 33);
            this.button_write_string.TabIndex = 16;
            this.button_write_string.Text = "字符串写入";
            this.button_write_string.UseVisualStyleBackColor = true;
            // 
            // button_write_double
            // 
            this.button_write_double.Location = new System.Drawing.Point(400, 132);
            this.button_write_double.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_write_double.Name = "button_write_double";
            this.button_write_double.Size = new System.Drawing.Size(105, 33);
            this.button_write_double.TabIndex = 15;
            this.button_write_double.Text = "double写入";
            this.button_write_double.UseVisualStyleBackColor = true;
            // 
            // button_write_float
            // 
            this.button_write_float.Location = new System.Drawing.Point(271, 136);
            this.button_write_float.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_write_float.Name = "button_write_float";
            this.button_write_float.Size = new System.Drawing.Size(105, 33);
            this.button_write_float.TabIndex = 14;
            this.button_write_float.Text = "float写入";
            this.button_write_float.UseVisualStyleBackColor = true;
            // 
            // button_write_int
            // 
            this.button_write_int.Location = new System.Drawing.Point(400, 79);
            this.button_write_int.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_write_int.Name = "button_write_int";
            this.button_write_int.Size = new System.Drawing.Size(105, 33);
            this.button_write_int.TabIndex = 10;
            this.button_write_int.Text = "int写入";
            this.button_write_int.UseVisualStyleBackColor = true;
            // 
            // button_write_short
            // 
            this.button_write_short.Location = new System.Drawing.Point(271, 81);
            this.button_write_short.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_write_short.Name = "button_write_short";
            this.button_write_short.Size = new System.Drawing.Size(105, 33);
            this.button_write_short.TabIndex = 8;
            this.button_write_short.Text = "short写入";
            this.button_write_short.UseVisualStyleBackColor = true;
            // 
            // button_write_byte
            // 
            this.button_write_byte.Location = new System.Drawing.Point(400, 25);
            this.button_write_byte.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_write_byte.Name = "button_write_byte";
            this.button_write_byte.Size = new System.Drawing.Size(105, 33);
            this.button_write_byte.TabIndex = 7;
            this.button_write_byte.Text = "byte写入";
            this.button_write_byte.UseVisualStyleBackColor = true;
            // 
            // button_write_bool
            // 
            this.button_write_bool.Location = new System.Drawing.Point(271, 25);
            this.button_write_bool.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_write_bool.Name = "button_write_bool";
            this.button_write_bool.Size = new System.Drawing.Size(105, 33);
            this.button_write_bool.TabIndex = 6;
            this.button_write_bool.Text = "bool写入";
            this.button_write_bool.UseVisualStyleBackColor = true;
            // 
            // txtWValue
            // 
            this.txtWValue.Location = new System.Drawing.Point(81, 67);
            this.txtWValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtWValue.Name = "txtWValue";
            this.txtWValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWValue.Size = new System.Drawing.Size(169, 25);
            this.txtWValue.TabIndex = 5;
            this.txtWValue.Text = "False";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(12, 69);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(38, 18);
            this.label23.TabIndex = 4;
            this.label23.Text = "值：";
            // 
            // txtWAddress
            // 
            this.txtWAddress.Location = new System.Drawing.Point(81, 32);
            this.txtWAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtWAddress.Name = "txtWAddress";
            this.txtWAddress.Size = new System.Drawing.Size(169, 25);
            this.txtWAddress.TabIndex = 3;
            this.txtWAddress.Text = "M100";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(12, 35);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(53, 18);
            this.label24.TabIndex = 2;
            this.label24.Text = "地址：";
            // 
            // SiemensPLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnDisConnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Font = new System.Drawing.Font("Tahoma", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SiemensPLC";
            this.Size = new System.Drawing.Size(1173, 713);
            this.Load += new System.EventHandler(this.SiemensPlc_Load);
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grbReadOnTime.ResumeLayout(false);
            this.grbReadOnTime.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDisConnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_read_short;
        private System.Windows.Forms.Button button_read_double;
        private System.Windows.Forms.Button button_read_float;
        private System.Windows.Forms.TextBox txtStrLength;
        private System.Windows.Forms.Button button_read_string;
        private System.Windows.Forms.Button button_read_int;
        private System.Windows.Forms.Button button_read_byte;
        private System.Windows.Forms.Button button_read_bool;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button button_write_string;
        private System.Windows.Forms.Button button_write_double;
        private System.Windows.Forms.Button button_write_float;
        private System.Windows.Forms.Button button_write_int;
        private System.Windows.Forms.Button button_write_short;
        private System.Windows.Forms.Button button_write_byte;
        private System.Windows.Forms.Button button_write_bool;
        private System.Windows.Forms.TextBox txtWValue;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtWAddress;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox grbReadOnTime;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txtTimingAddress;
        private System.Windows.Forms.Label label33;
        private HslCommunication.Controls.UserCurve userCurve1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtManyReadResult;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnManyRead;
        private System.Windows.Forms.TextBox txtManyReadLen;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtManyReadAddr;
        private System.Windows.Forms.Label label11;
    }
}
