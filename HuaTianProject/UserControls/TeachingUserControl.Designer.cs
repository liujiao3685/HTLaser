namespace HuaTianProject.UserControls
{
    partial class TeachingUserControl
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxMotionTrail = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtRltDis = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioRlt = new System.Windows.Forms.RadioButton();
            this.radioJog = new System.Windows.Forms.RadioButton();
            this.groupBoxManual = new System.Windows.Forms.GroupBox();
            this.btnWPosDir = new System.Windows.Forms.Button();
            this.btnWNegDir = new System.Windows.Forms.Button();
            this.btnZPosDir = new System.Windows.Forms.Button();
            this.btnYPosDir = new System.Windows.Forms.Button();
            this.btnZNegDir = new System.Windows.Forms.Button();
            this.btnYNegDir = new System.Windows.Forms.Button();
            this.btnXPosDir = new System.Windows.Forms.Button();
            this.btnXNegDir = new System.Windows.Forms.Button();
            this.groupBoxPt = new System.Windows.Forms.GroupBox();
            this.radioStartePos = new System.Windows.Forms.RadioButton();
            this.radioWeldPos1 = new System.Windows.Forms.RadioButton();
            this.radioEndPos = new System.Windows.Forms.RadioButton();
            this.radioWeldPos2 = new System.Windows.Forms.RadioButton();
            this.rabReserve1 = new System.Windows.Forms.RadioButton();
            this.rabReserve2 = new System.Windows.Forms.RadioButton();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnSavePos = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.lbRealW = new System.Windows.Forms.TextBox();
            this.lbRealZ = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbRealY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbRealX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lbPointZ = new System.Windows.Forms.TextBox();
            this.labelZ = new System.Windows.Forms.Label();
            this.lbPointW = new System.Windows.Forms.TextBox();
            this.labelW = new System.Windows.Forms.Label();
            this.lbPointY = new System.Windows.Forms.TextBox();
            this.labelY = new System.Windows.Forms.Label();
            this.lbPointX = new System.Windows.Forms.TextBox();
            this.labelX = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtZeroVector = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSaveVector = new System.Windows.Forms.Button();
            this.txtArcVector = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLineVector = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtJogVector = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRltVector = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAbsVector = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnWHome = new System.Windows.Forms.Button();
            this.btnYHome = new System.Windows.Forms.Button();
            this.btnZHome = new System.Windows.Forms.Button();
            this.btnXHome = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBoxManual.SuspendLayout();
            this.groupBoxPt.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(489, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(375, 358);
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(761, 382);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(102, 41);
            this.btnStart.TabIndex = 45;
            this.btnStart.Text = "启动";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "轨迹选择";
            // 
            // cbxMotionTrail
            // 
            this.cbxMotionTrail.FormattingEnabled = true;
            this.cbxMotionTrail.Items.AddRange(new object[] {
            "轨迹1",
            "轨迹2",
            "轨迹3",
            "轨迹4"});
            this.cbxMotionTrail.Location = new System.Drawing.Point(73, 12);
            this.cbxMotionTrail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxMotionTrail.Name = "cbxMotionTrail";
            this.cbxMotionTrail.Size = new System.Drawing.Size(91, 21);
            this.cbxMotionTrail.TabIndex = 43;
            this.cbxMotionTrail.SelectedIndexChanged += new System.EventHandler(this.cbxMotionTrail_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox2.Controls.Add(this.txtRltDis);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.radioRlt);
            this.groupBox2.Controls.Add(this.radioJog);
            this.groupBox2.Location = new System.Drawing.Point(15, 503);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(338, 75);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "运动模式:";
            // 
            // txtRltDis
            // 
            this.txtRltDis.Location = new System.Drawing.Point(194, 35);
            this.txtRltDis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRltDis.Name = "txtRltDis";
            this.txtRltDis.Size = new System.Drawing.Size(64, 20);
            this.txtRltDis.TabIndex = 2;
            this.txtRltDis.Text = "50";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "mm";
            // 
            // radioRlt
            // 
            this.radioRlt.AutoSize = true;
            this.radioRlt.Location = new System.Drawing.Point(115, 36);
            this.radioRlt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioRlt.Name = "radioRlt";
            this.radioRlt.Size = new System.Drawing.Size(73, 17);
            this.radioRlt.TabIndex = 0;
            this.radioRlt.Text = "相对距离";
            this.radioRlt.UseVisualStyleBackColor = true;
            // 
            // radioJog
            // 
            this.radioJog.AutoSize = true;
            this.radioJog.Checked = true;
            this.radioJog.Location = new System.Drawing.Point(23, 36);
            this.radioJog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioJog.Name = "radioJog";
            this.radioJog.Size = new System.Drawing.Size(42, 17);
            this.radioJog.TabIndex = 0;
            this.radioJog.TabStop = true;
            this.radioJog.Text = "Jog";
            this.radioJog.UseVisualStyleBackColor = true;
            // 
            // groupBoxManual
            // 
            this.groupBoxManual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBoxManual.Controls.Add(this.btnWPosDir);
            this.groupBoxManual.Controls.Add(this.btnWNegDir);
            this.groupBoxManual.Controls.Add(this.btnZPosDir);
            this.groupBoxManual.Controls.Add(this.btnYPosDir);
            this.groupBoxManual.Controls.Add(this.btnZNegDir);
            this.groupBoxManual.Controls.Add(this.btnYNegDir);
            this.groupBoxManual.Controls.Add(this.btnXPosDir);
            this.groupBoxManual.Controls.Add(this.btnXNegDir);
            this.groupBoxManual.Location = new System.Drawing.Point(15, 311);
            this.groupBoxManual.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxManual.Name = "groupBoxManual";
            this.groupBoxManual.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxManual.Size = new System.Drawing.Size(338, 177);
            this.groupBoxManual.TabIndex = 41;
            this.groupBoxManual.TabStop = false;
            this.groupBoxManual.Text = "手动调试:";
            // 
            // btnWPosDir
            // 
            this.btnWPosDir.Location = new System.Drawing.Point(257, 24);
            this.btnWPosDir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWPosDir.Name = "btnWPosDir";
            this.btnWPosDir.Size = new System.Drawing.Size(39, 48);
            this.btnWPosDir.TabIndex = 0;
            this.btnWPosDir.Tag = "RY";
            this.btnWPosDir.Text = "W+";
            this.btnWPosDir.UseVisualStyleBackColor = true;
            this.btnWPosDir.Click += new System.EventHandler(this.btnWPosDir_Click);
            this.btnWPosDir.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnWPosDir_MouseDown);
            this.btnWPosDir.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnWPosDir_MouseUp);
            // 
            // btnWNegDir
            // 
            this.btnWNegDir.Location = new System.Drawing.Point(257, 115);
            this.btnWNegDir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWNegDir.Name = "btnWNegDir";
            this.btnWNegDir.Size = new System.Drawing.Size(39, 48);
            this.btnWNegDir.TabIndex = 0;
            this.btnWNegDir.Tag = "RY";
            this.btnWNegDir.Text = "W-";
            this.btnWNegDir.UseVisualStyleBackColor = true;
            this.btnWNegDir.Click += new System.EventHandler(this.btnWNegDir_Click);
            this.btnWNegDir.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnWNegDir_MouseDown);
            this.btnWNegDir.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnWNegDir_MouseUp);
            // 
            // btnZPosDir
            // 
            this.btnZPosDir.Location = new System.Drawing.Point(189, 24);
            this.btnZPosDir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnZPosDir.Name = "btnZPosDir";
            this.btnZPosDir.Size = new System.Drawing.Size(39, 48);
            this.btnZPosDir.TabIndex = 0;
            this.btnZPosDir.Tag = "Z";
            this.btnZPosDir.Text = "Z+";
            this.btnZPosDir.UseVisualStyleBackColor = true;
            this.btnZPosDir.Click += new System.EventHandler(this.btnZPosDir_Click);
            this.btnZPosDir.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnZPosDir_MouseDown);
            this.btnZPosDir.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnZPosDir_MouseUp);
            // 
            // btnYPosDir
            // 
            this.btnYPosDir.Location = new System.Drawing.Point(69, 27);
            this.btnYPosDir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnYPosDir.Name = "btnYPosDir";
            this.btnYPosDir.Size = new System.Drawing.Size(35, 48);
            this.btnYPosDir.TabIndex = 0;
            this.btnYPosDir.Tag = "Y";
            this.btnYPosDir.Text = "Y+";
            this.btnYPosDir.UseVisualStyleBackColor = true;
            this.btnYPosDir.Click += new System.EventHandler(this.btnYPosDir_Click);
            this.btnYPosDir.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnYPosDir_MouseDown);
            this.btnYPosDir.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnYPosDir_MouseUp);
            // 
            // btnZNegDir
            // 
            this.btnZNegDir.Location = new System.Drawing.Point(189, 115);
            this.btnZNegDir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnZNegDir.Name = "btnZNegDir";
            this.btnZNegDir.Size = new System.Drawing.Size(39, 48);
            this.btnZNegDir.TabIndex = 0;
            this.btnZNegDir.Tag = "Z";
            this.btnZNegDir.Text = "Z-";
            this.btnZNegDir.UseVisualStyleBackColor = true;
            this.btnZNegDir.Click += new System.EventHandler(this.btnZNegDir_Click);
            this.btnZNegDir.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnZNegDir_MouseDown);
            this.btnZNegDir.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnZNegDir_MouseUp);
            // 
            // btnYNegDir
            // 
            this.btnYNegDir.Location = new System.Drawing.Point(69, 117);
            this.btnYNegDir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnYNegDir.Name = "btnYNegDir";
            this.btnYNegDir.Size = new System.Drawing.Size(35, 48);
            this.btnYNegDir.TabIndex = 0;
            this.btnYNegDir.Tag = "Y";
            this.btnYNegDir.Text = "Y-";
            this.btnYNegDir.UseVisualStyleBackColor = true;
            this.btnYNegDir.Click += new System.EventHandler(this.btnYNegDir_Click);
            this.btnYNegDir.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnYNegDir_MouseDown);
            this.btnYNegDir.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnYNegDir_MouseUp);
            // 
            // btnXPosDir
            // 
            this.btnXPosDir.Location = new System.Drawing.Point(105, 77);
            this.btnXPosDir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXPosDir.Name = "btnXPosDir";
            this.btnXPosDir.Size = new System.Drawing.Size(52, 32);
            this.btnXPosDir.TabIndex = 0;
            this.btnXPosDir.Tag = "X";
            this.btnXPosDir.Text = "X+";
            this.btnXPosDir.UseVisualStyleBackColor = true;
            this.btnXPosDir.Click += new System.EventHandler(this.btnXPosDir_Click);
            this.btnXPosDir.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnXPosDir_MouseDown);
            this.btnXPosDir.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnXPosDir_MouseUp);
            // 
            // btnXNegDir
            // 
            this.btnXNegDir.Location = new System.Drawing.Point(15, 77);
            this.btnXNegDir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXNegDir.Name = "btnXNegDir";
            this.btnXNegDir.Size = new System.Drawing.Size(52, 32);
            this.btnXNegDir.TabIndex = 0;
            this.btnXNegDir.Tag = "X";
            this.btnXNegDir.Text = "X-";
            this.btnXNegDir.UseVisualStyleBackColor = true;
            this.btnXNegDir.Click += new System.EventHandler(this.btnXNegDir_Click);
            this.btnXNegDir.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnXNegDir_MouseDown);
            this.btnXNegDir.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnXNegDir_MouseUp);
            // 
            // groupBoxPt
            // 
            this.groupBoxPt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBoxPt.Controls.Add(this.radioStartePos);
            this.groupBoxPt.Controls.Add(this.radioWeldPos1);
            this.groupBoxPt.Controls.Add(this.radioEndPos);
            this.groupBoxPt.Controls.Add(this.radioWeldPos2);
            this.groupBoxPt.Controls.Add(this.rabReserve1);
            this.groupBoxPt.Controls.Add(this.rabReserve2);
            this.groupBoxPt.Location = new System.Drawing.Point(14, 13);
            this.groupBoxPt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxPt.Name = "groupBoxPt";
            this.groupBoxPt.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxPt.Size = new System.Drawing.Size(454, 82);
            this.groupBoxPt.TabIndex = 38;
            this.groupBoxPt.TabStop = false;
            this.groupBoxPt.Text = "示教位置：";
            // 
            // radioStartePos
            // 
            this.radioStartePos.AutoSize = true;
            this.radioStartePos.Location = new System.Drawing.Point(27, 24);
            this.radioStartePos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioStartePos.Name = "radioStartePos";
            this.radioStartePos.Size = new System.Drawing.Size(84, 17);
            this.radioStartePos.TabIndex = 10;
            this.radioStartePos.Tag = "30";
            this.radioStartePos.Text = "A:起始位置";
            this.radioStartePos.UseVisualStyleBackColor = true;
            this.radioStartePos.CheckedChanged += new System.EventHandler(this.radioWeldPos1_Click);
            // 
            // radioWeldPos1
            // 
            this.radioWeldPos1.AutoSize = true;
            this.radioWeldPos1.Location = new System.Drawing.Point(27, 54);
            this.radioWeldPos1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioWeldPos1.Name = "radioWeldPos1";
            this.radioWeldPos1.Size = new System.Drawing.Size(89, 17);
            this.radioWeldPos1.TabIndex = 9;
            this.radioWeldPos1.Tag = "31";
            this.radioWeldPos1.Text = "B:焊接位置1";
            this.radioWeldPos1.UseVisualStyleBackColor = true;
            this.radioWeldPos1.Click += new System.EventHandler(this.radioWeldPos1_Click);
            // 
            // radioEndPos
            // 
            this.radioEndPos.AutoSize = true;
            this.radioEndPos.Location = new System.Drawing.Point(149, 54);
            this.radioEndPos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioEndPos.Name = "radioEndPos";
            this.radioEndPos.Size = new System.Drawing.Size(84, 17);
            this.radioEndPos.TabIndex = 8;
            this.radioEndPos.Tag = "3";
            this.radioEndPos.Text = "D:终点位置";
            this.radioEndPos.UseVisualStyleBackColor = true;
            this.radioEndPos.Click += new System.EventHandler(this.radioWeldPos1_Click);
            // 
            // radioWeldPos2
            // 
            this.radioWeldPos2.AutoSize = true;
            this.radioWeldPos2.Location = new System.Drawing.Point(149, 24);
            this.radioWeldPos2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioWeldPos2.Name = "radioWeldPos2";
            this.radioWeldPos2.Size = new System.Drawing.Size(90, 17);
            this.radioWeldPos2.TabIndex = 7;
            this.radioWeldPos2.Tag = "2";
            this.radioWeldPos2.Text = "C:焊接位置2";
            this.radioWeldPos2.UseVisualStyleBackColor = true;
            this.radioWeldPos2.Click += new System.EventHandler(this.radioWeldPos1_Click);
            // 
            // rabReserve1
            // 
            this.rabReserve1.AutoSize = true;
            this.rabReserve1.Location = new System.Drawing.Point(279, 24);
            this.rabReserve1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rabReserve1.Name = "rabReserve1";
            this.rabReserve1.Size = new System.Drawing.Size(89, 17);
            this.rabReserve1.TabIndex = 5;
            this.rabReserve1.Tag = "1";
            this.rabReserve1.Text = "E:备用位置1";
            this.rabReserve1.UseVisualStyleBackColor = true;
            this.rabReserve1.Click += new System.EventHandler(this.radioWeldPos1_Click);
            // 
            // rabReserve2
            // 
            this.rabReserve2.AutoSize = true;
            this.rabReserve2.Location = new System.Drawing.Point(279, 54);
            this.rabReserve2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rabReserve2.Name = "rabReserve2";
            this.rabReserve2.Size = new System.Drawing.Size(89, 17);
            this.rabReserve2.TabIndex = 6;
            this.rabReserve2.Tag = "6";
            this.rabReserve2.Text = "F:备用位置2";
            this.rabReserve2.UseVisualStyleBackColor = true;
            this.rabReserve2.Click += new System.EventHandler(this.radioWeldPos1_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox10.Controls.Add(this.btnMove);
            this.groupBox10.Controls.Add(this.btnSavePos);
            this.groupBox10.Controls.Add(this.btnStop);
            this.groupBox10.Location = new System.Drawing.Point(363, 246);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox10.Size = new System.Drawing.Size(105, 210);
            this.groupBox10.TabIndex = 40;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "运动：";
            // 
            // btnMove
            // 
            this.btnMove.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btnMove.ForeColor = System.Drawing.Color.Blue;
            this.btnMove.Location = new System.Drawing.Point(14, 28);
            this.btnMove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(76, 46);
            this.btnMove.TabIndex = 0;
            this.btnMove.Text = "Move";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // btnSavePos
            // 
            this.btnSavePos.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btnSavePos.ForeColor = System.Drawing.Color.Blue;
            this.btnSavePos.Location = new System.Drawing.Point(14, 91);
            this.btnSavePos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSavePos.Name = "btnSavePos";
            this.btnSavePos.Size = new System.Drawing.Size(76, 46);
            this.btnSavePos.TabIndex = 0;
            this.btnSavePos.Text = "保存示教位";
            this.btnSavePos.UseVisualStyleBackColor = true;
            this.btnSavePos.Click += new System.EventHandler(this.btnSavePos_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(14, 154);
            this.btnStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(76, 46);
            this.btnStop.TabIndex = 18;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox11.Controls.Add(this.lbRealW);
            this.groupBox11.Controls.Add(this.lbRealZ);
            this.groupBox11.Controls.Add(this.label5);
            this.groupBox11.Controls.Add(this.label16);
            this.groupBox11.Controls.Add(this.lbRealY);
            this.groupBox11.Controls.Add(this.label3);
            this.groupBox11.Controls.Add(this.lbRealX);
            this.groupBox11.Controls.Add(this.label4);
            this.groupBox11.Location = new System.Drawing.Point(15, 171);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox11.Size = new System.Drawing.Size(453, 61);
            this.groupBox11.TabIndex = 39;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "实时位置：(mm）";
            // 
            // lbRealW
            // 
            this.lbRealW.Location = new System.Drawing.Point(339, 28);
            this.lbRealW.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbRealW.Name = "lbRealW";
            this.lbRealW.ReadOnly = true;
            this.lbRealW.Size = new System.Drawing.Size(52, 20);
            this.lbRealW.TabIndex = 4;
            this.lbRealW.Text = "0.000";
            // 
            // lbRealZ
            // 
            this.lbRealZ.Location = new System.Drawing.Point(229, 28);
            this.lbRealZ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbRealZ.Name = "lbRealZ";
            this.lbRealZ.ReadOnly = true;
            this.lbRealZ.Size = new System.Drawing.Size(52, 20);
            this.lbRealZ.TabIndex = 8;
            this.lbRealZ.Text = "0.000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(306, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "W轴";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(201, 30);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(25, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "Z轴";
            // 
            // lbRealY
            // 
            this.lbRealY.Location = new System.Drawing.Point(138, 28);
            this.lbRealY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbRealY.Name = "lbRealY";
            this.lbRealY.ReadOnly = true;
            this.lbRealY.Size = new System.Drawing.Size(52, 20);
            this.lbRealY.TabIndex = 6;
            this.lbRealY.Text = "0.000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Y轴";
            // 
            // lbRealX
            // 
            this.lbRealX.Location = new System.Drawing.Point(46, 28);
            this.lbRealX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbRealX.Name = "lbRealX";
            this.lbRealX.ReadOnly = true;
            this.lbRealX.Size = new System.Drawing.Size(52, 20);
            this.lbRealX.TabIndex = 4;
            this.lbRealX.Text = "0.000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "X轴";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox5.Controls.Add(this.lbPointZ);
            this.groupBox5.Controls.Add(this.labelZ);
            this.groupBox5.Controls.Add(this.lbPointW);
            this.groupBox5.Controls.Add(this.labelW);
            this.groupBox5.Controls.Add(this.lbPointY);
            this.groupBox5.Controls.Add(this.labelY);
            this.groupBox5.Controls.Add(this.lbPointX);
            this.groupBox5.Controls.Add(this.labelX);
            this.groupBox5.Location = new System.Drawing.Point(15, 103);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(453, 55);
            this.groupBox5.TabIndex = 37;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "编辑点位置：(mm)";
            // 
            // lbPointZ
            // 
            this.lbPointZ.Location = new System.Drawing.Point(229, 24);
            this.lbPointZ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbPointZ.Name = "lbPointZ";
            this.lbPointZ.Size = new System.Drawing.Size(52, 20);
            this.lbPointZ.TabIndex = 4;
            this.lbPointZ.Text = "0.000";
            this.lbPointZ.Visible = false;
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Location = new System.Drawing.Point(201, 26);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(25, 13);
            this.labelZ.TabIndex = 3;
            this.labelZ.Text = "Z轴";
            // 
            // lbPointW
            // 
            this.lbPointW.Location = new System.Drawing.Point(339, 24);
            this.lbPointW.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbPointW.Name = "lbPointW";
            this.lbPointW.Size = new System.Drawing.Size(52, 20);
            this.lbPointW.TabIndex = 2;
            this.lbPointW.Text = "0.000";
            this.lbPointW.Visible = false;
            // 
            // labelW
            // 
            this.labelW.AutoSize = true;
            this.labelW.Location = new System.Drawing.Point(305, 26);
            this.labelW.Name = "labelW";
            this.labelW.Size = new System.Drawing.Size(29, 13);
            this.labelW.TabIndex = 1;
            this.labelW.Text = "W轴";
            // 
            // lbPointY
            // 
            this.lbPointY.Location = new System.Drawing.Point(136, 24);
            this.lbPointY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbPointY.Name = "lbPointY";
            this.lbPointY.Size = new System.Drawing.Size(52, 20);
            this.lbPointY.TabIndex = 2;
            this.lbPointY.Text = "0.000";
            this.lbPointY.Visible = false;
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(111, 27);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(25, 13);
            this.labelY.TabIndex = 1;
            this.labelY.Text = "Y轴";
            // 
            // lbPointX
            // 
            this.lbPointX.Location = new System.Drawing.Point(45, 24);
            this.lbPointX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbPointX.Name = "lbPointX";
            this.lbPointX.Size = new System.Drawing.Size(52, 20);
            this.lbPointX.TabIndex = 2;
            this.lbPointX.Text = "0.000";
            this.lbPointX.Visible = false;
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(16, 26);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(25, 13);
            this.labelX.TabIndex = 1;
            this.labelX.Text = "X轴";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbxMotionTrail);
            this.panel1.Location = new System.Drawing.Point(489, 380);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 43);
            this.panel1.TabIndex = 46;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.groupBox1.Controls.Add(this.txtZeroVector);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.btnSaveVector);
            this.groupBox1.Controls.Add(this.txtArcVector);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtLineVector);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtJogVector);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtRltVector);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtAbsVector);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(489, 435);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(474, 152);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "速度设置(mm/s)";
            // 
            // txtZeroVector
            // 
            this.txtZeroVector.Location = new System.Drawing.Point(105, 115);
            this.txtZeroVector.Name = "txtZeroVector";
            this.txtZeroVector.Size = new System.Drawing.Size(100, 20);
            this.txtZeroVector.TabIndex = 48;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label12.Location = new System.Drawing.Point(33, 118);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 47;
            this.label12.Text = "回零速度";
            // 
            // btnSaveVector
            // 
            this.btnSaveVector.Location = new System.Drawing.Point(252, 106);
            this.btnSaveVector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveVector.Name = "btnSaveVector";
            this.btnSaveVector.Size = new System.Drawing.Size(89, 37);
            this.btnSaveVector.TabIndex = 46;
            this.btnSaveVector.Text = "速度保存";
            this.btnSaveVector.UseVisualStyleBackColor = true;
            this.btnSaveVector.Click += new System.EventHandler(this.btnSaveVector_Click);
            // 
            // txtArcVector
            // 
            this.txtArcVector.Location = new System.Drawing.Point(349, 77);
            this.txtArcVector.Name = "txtArcVector";
            this.txtArcVector.Size = new System.Drawing.Size(100, 20);
            this.txtArcVector.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label9.Location = new System.Drawing.Point(249, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "圆弧插补速度";
            // 
            // txtLineVector
            // 
            this.txtLineVector.Location = new System.Drawing.Point(349, 31);
            this.txtLineVector.Name = "txtLineVector";
            this.txtLineVector.Size = new System.Drawing.Size(100, 20);
            this.txtLineVector.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label11.Location = new System.Drawing.Point(249, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "直线插补速度";
            // 
            // txtJogVector
            // 
            this.txtJogVector.Location = new System.Drawing.Point(105, 88);
            this.txtJogVector.Name = "txtJogVector";
            this.txtJogVector.Size = new System.Drawing.Size(100, 20);
            this.txtJogVector.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label8.Location = new System.Drawing.Point(33, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "JOG速度";
            // 
            // txtRltVector
            // 
            this.txtRltVector.Location = new System.Drawing.Point(105, 61);
            this.txtRltVector.Name = "txtRltVector";
            this.txtRltVector.Size = new System.Drawing.Size(100, 20);
            this.txtRltVector.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label7.Location = new System.Drawing.Point(33, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "相对速度";
            // 
            // txtAbsVector
            // 
            this.txtAbsVector.Location = new System.Drawing.Point(105, 32);
            this.txtAbsVector.Name = "txtAbsVector";
            this.txtAbsVector.Size = new System.Drawing.Size(100, 20);
            this.txtAbsVector.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label6.Location = new System.Drawing.Point(33, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "绝对速度";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox3.Controls.Add(this.btnWHome);
            this.groupBox3.Controls.Add(this.btnYHome);
            this.groupBox3.Controls.Add(this.btnZHome);
            this.groupBox3.Controls.Add(this.btnXHome);
            this.groupBox3.Location = new System.Drawing.Point(15, 236);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(338, 71);
            this.groupBox3.TabIndex = 43;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "原点监控";
            // 
            // btnWHome
            // 
            this.btnWHome.Enabled = false;
            this.btnWHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWHome.Location = new System.Drawing.Point(267, 24);
            this.btnWHome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWHome.Name = "btnWHome";
            this.btnWHome.Size = new System.Drawing.Size(52, 32);
            this.btnWHome.TabIndex = 4;
            this.btnWHome.Tag = "X";
            this.btnWHome.Text = "W原点";
            this.btnWHome.UseVisualStyleBackColor = true;
            // 
            // btnYHome
            // 
            this.btnYHome.Enabled = false;
            this.btnYHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYHome.Location = new System.Drawing.Point(103, 24);
            this.btnYHome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnYHome.Name = "btnYHome";
            this.btnYHome.Size = new System.Drawing.Size(52, 32);
            this.btnYHome.TabIndex = 3;
            this.btnYHome.Tag = "X";
            this.btnYHome.Text = "Y原点";
            this.btnYHome.UseVisualStyleBackColor = true;
            // 
            // btnZHome
            // 
            this.btnZHome.Enabled = false;
            this.btnZHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZHome.Location = new System.Drawing.Point(185, 24);
            this.btnZHome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnZHome.Name = "btnZHome";
            this.btnZHome.Size = new System.Drawing.Size(52, 32);
            this.btnZHome.TabIndex = 2;
            this.btnZHome.Tag = "X";
            this.btnZHome.Text = "Z原点";
            this.btnZHome.UseVisualStyleBackColor = true;
            // 
            // btnXHome
            // 
            this.btnXHome.Enabled = false;
            this.btnXHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXHome.Location = new System.Drawing.Point(21, 24);
            this.btnXHome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXHome.Name = "btnXHome";
            this.btnXHome.Size = new System.Drawing.Size(52, 32);
            this.btnXHome.TabIndex = 1;
            this.btnXHome.Tag = "X";
            this.btnXHome.Text = "X原点";
            this.btnXHome.UseVisualStyleBackColor = true;
            // 
            // TeachingUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxManual);
            this.Controls.Add(this.groupBoxPt);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.groupBox5);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TeachingUserControl";
            this.Size = new System.Drawing.Size(1045, 611);
            this.Load += new System.EventHandler(this.TeachingUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxManual.ResumeLayout(false);
            this.groupBoxPt.ResumeLayout(false);
            this.groupBoxPt.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxMotionTrail;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtRltDis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioRlt;
        private System.Windows.Forms.RadioButton radioJog;
        private System.Windows.Forms.GroupBox groupBoxManual;
        private System.Windows.Forms.Button btnWPosDir;
        private System.Windows.Forms.Button btnWNegDir;
        private System.Windows.Forms.Button btnZPosDir;
        private System.Windows.Forms.Button btnYPosDir;
        private System.Windows.Forms.Button btnZNegDir;
        private System.Windows.Forms.Button btnYNegDir;
        private System.Windows.Forms.Button btnXPosDir;
        private System.Windows.Forms.Button btnXNegDir;
        private System.Windows.Forms.GroupBox groupBoxPt;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnSavePos;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox lbRealW;
        private System.Windows.Forms.TextBox lbRealZ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox lbRealY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lbRealX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox lbPointZ;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.TextBox lbPointW;
        private System.Windows.Forms.Label labelW;
        private System.Windows.Forms.TextBox lbPointY;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.TextBox lbPointX;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioStartePos;
        private System.Windows.Forms.RadioButton radioWeldPos1;
        private System.Windows.Forms.RadioButton radioEndPos;
        private System.Windows.Forms.RadioButton radioWeldPos2;
        private System.Windows.Forms.RadioButton rabReserve1;
        private System.Windows.Forms.RadioButton rabReserve2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtJogVector;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRltVector;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAbsVector;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSaveVector;
        private System.Windows.Forms.TextBox txtArcVector;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLineVector;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtZeroVector;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnXHome;
        private System.Windows.Forms.Button btnWHome;
        private System.Windows.Forms.Button btnYHome;
        private System.Windows.Forms.Button btnZHome;
    }
}
