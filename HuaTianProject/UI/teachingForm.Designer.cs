namespace HuaTianProject.UI
{
    partial class TeachingForm
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxMotionTrail = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBoxPt.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxManual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.groupBoxPt.Location = new System.Drawing.Point(12, 27);
            this.groupBoxPt.Name = "groupBoxPt";
            this.groupBoxPt.Size = new System.Drawing.Size(513, 120);
            this.groupBoxPt.TabIndex = 14;
            this.groupBoxPt.TabStop = false;
            this.groupBoxPt.Text = "示教位置：";
            // 
            // radioStartePos
            // 
            this.radioStartePos.AutoSize = true;
            this.radioStartePos.Location = new System.Drawing.Point(35, 35);
            this.radioStartePos.Name = "radioStartePos";
            this.radioStartePos.Size = new System.Drawing.Size(85, 18);
            this.radioStartePos.TabIndex = 4;
            this.radioStartePos.Tag = "30";
            this.radioStartePos.Text = "A:起始位置";
            this.radioStartePos.UseVisualStyleBackColor = true;
            this.radioStartePos.CheckedChanged += new System.EventHandler(this.radioWeldPos1_Click);
            // 
            // radioWeldPos1
            // 
            this.radioWeldPos1.AutoSize = true;
            this.radioWeldPos1.Location = new System.Drawing.Point(35, 78);
            this.radioWeldPos1.Name = "radioWeldPos1";
            this.radioWeldPos1.Size = new System.Drawing.Size(91, 18);
            this.radioWeldPos1.TabIndex = 3;
            this.radioWeldPos1.Tag = "31";
            this.radioWeldPos1.Text = "B:焊接位置1";
            this.radioWeldPos1.UseVisualStyleBackColor = true;
            this.radioWeldPos1.Click += new System.EventHandler(this.radioWeldPos1_Click);
            // 
            // radioEndPos
            // 
            this.radioEndPos.AutoSize = true;
            this.radioEndPos.Location = new System.Drawing.Point(177, 78);
            this.radioEndPos.Name = "radioEndPos";
            this.radioEndPos.Size = new System.Drawing.Size(85, 18);
            this.radioEndPos.TabIndex = 2;
            this.radioEndPos.Tag = "3";
            this.radioEndPos.Text = "D:终点位置";
            this.radioEndPos.UseVisualStyleBackColor = true;
            this.radioEndPos.Click += new System.EventHandler(this.radioWeldPos1_Click);
            // 
            // radioWeldPos2
            // 
            this.radioWeldPos2.AutoSize = true;
            this.radioWeldPos2.Location = new System.Drawing.Point(177, 36);
            this.radioWeldPos2.Name = "radioWeldPos2";
            this.radioWeldPos2.Size = new System.Drawing.Size(91, 18);
            this.radioWeldPos2.TabIndex = 1;
            this.radioWeldPos2.Tag = "2";
            this.radioWeldPos2.Text = "C:焊接位置2";
            this.radioWeldPos2.UseVisualStyleBackColor = true;
            this.radioWeldPos2.Click += new System.EventHandler(this.radioWeldPos1_Click);
            // 
            // rabReserve1
            // 
            this.rabReserve1.AutoSize = true;
            this.rabReserve1.Location = new System.Drawing.Point(325, 35);
            this.rabReserve1.Name = "rabReserve1";
            this.rabReserve1.Size = new System.Drawing.Size(91, 18);
            this.rabReserve1.TabIndex = 0;
            this.rabReserve1.Tag = "1";
            this.rabReserve1.Text = "E:备用位置1";
            this.rabReserve1.UseVisualStyleBackColor = true;
            this.rabReserve1.Click += new System.EventHandler(this.radioWeldPos1_Click);
            // 
            // rabReserve2
            // 
            this.rabReserve2.AutoSize = true;
            this.rabReserve2.Location = new System.Drawing.Point(324, 78);
            this.rabReserve2.Name = "rabReserve2";
            this.rabReserve2.Size = new System.Drawing.Size(90, 18);
            this.rabReserve2.TabIndex = 0;
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
            this.groupBox10.Location = new System.Drawing.Point(399, 320);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(133, 287);
            this.groupBox10.TabIndex = 16;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "运动：";
            // 
            // btnMove
            // 
            this.btnMove.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMove.ForeColor = System.Drawing.Color.Blue;
            this.btnMove.Location = new System.Drawing.Point(17, 35);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(98, 66);
            this.btnMove.TabIndex = 0;
            this.btnMove.Text = "Move";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // btnSavePos
            // 
            this.btnSavePos.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSavePos.ForeColor = System.Drawing.Color.Blue;
            this.btnSavePos.Location = new System.Drawing.Point(17, 117);
            this.btnSavePos.Name = "btnSavePos";
            this.btnSavePos.Size = new System.Drawing.Size(98, 66);
            this.btnSavePos.TabIndex = 0;
            this.btnSavePos.Text = "保存示教位";
            this.btnSavePos.UseVisualStyleBackColor = true;
            this.btnSavePos.Click += new System.EventHandler(this.btnSavePos_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(17, 199);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(98, 66);
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
            this.groupBox11.Location = new System.Drawing.Point(14, 237);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(513, 64);
            this.groupBox11.TabIndex = 15;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "实时位置：(mm）";
            // 
            // lbRealW
            // 
            this.lbRealW.Location = new System.Drawing.Point(413, 28);
            this.lbRealW.Name = "lbRealW";
            this.lbRealW.ReadOnly = true;
            this.lbRealW.Size = new System.Drawing.Size(68, 22);
            this.lbRealW.TabIndex = 4;
            this.lbRealW.Text = "0.000";
            // 
            // lbRealZ
            // 
            this.lbRealZ.Location = new System.Drawing.Point(293, 28);
            this.lbRealZ.Name = "lbRealZ";
            this.lbRealZ.ReadOnly = true;
            this.lbRealZ.Size = new System.Drawing.Size(68, 22);
            this.lbRealZ.TabIndex = 8;
            this.lbRealZ.Text = "0.000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(379, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "W轴";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(257, 31);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 14);
            this.label16.TabIndex = 7;
            this.label16.Text = "Z轴";
            // 
            // lbRealY
            // 
            this.lbRealY.Location = new System.Drawing.Point(173, 28);
            this.lbRealY.Name = "lbRealY";
            this.lbRealY.ReadOnly = true;
            this.lbRealY.Size = new System.Drawing.Size(68, 22);
            this.lbRealY.TabIndex = 6;
            this.lbRealY.Text = "0.000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Y轴";
            // 
            // lbRealX
            // 
            this.lbRealX.Location = new System.Drawing.Point(54, 24);
            this.lbRealX.Name = "lbRealX";
            this.lbRealX.ReadOnly = true;
            this.lbRealX.Size = new System.Drawing.Size(68, 22);
            this.lbRealX.TabIndex = 4;
            this.lbRealX.Text = "0.000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 14);
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
            this.groupBox5.Location = new System.Drawing.Point(12, 157);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(513, 65);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "编辑点位置：(mm)";
            // 
            // lbPointZ
            // 
            this.lbPointZ.Location = new System.Drawing.Point(291, 31);
            this.lbPointZ.Name = "lbPointZ";
            this.lbPointZ.Size = new System.Drawing.Size(68, 22);
            this.lbPointZ.TabIndex = 4;
            this.lbPointZ.Text = "0.000";
            this.lbPointZ.Visible = false;
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Location = new System.Drawing.Point(260, 34);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(26, 14);
            this.labelZ.TabIndex = 3;
            this.labelZ.Text = "Z轴";
            // 
            // lbPointW
            // 
            this.lbPointW.Location = new System.Drawing.Point(421, 31);
            this.lbPointW.Name = "lbPointW";
            this.lbPointW.Size = new System.Drawing.Size(68, 22);
            this.lbPointW.TabIndex = 2;
            this.lbPointW.Text = "0.000";
            this.lbPointW.Visible = false;
            // 
            // labelW
            // 
            this.labelW.AutoSize = true;
            this.labelW.Location = new System.Drawing.Point(384, 34);
            this.labelW.Name = "labelW";
            this.labelW.Size = new System.Drawing.Size(31, 14);
            this.labelW.TabIndex = 1;
            this.labelW.Text = "W轴";
            // 
            // lbPointY
            // 
            this.lbPointY.Location = new System.Drawing.Point(172, 31);
            this.lbPointY.Name = "lbPointY";
            this.lbPointY.Size = new System.Drawing.Size(68, 22);
            this.lbPointY.TabIndex = 2;
            this.lbPointY.Text = "0.000";
            this.lbPointY.Visible = false;
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(139, 34);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(27, 14);
            this.labelY.TabIndex = 1;
            this.labelY.Text = "Y轴";
            // 
            // lbPointX
            // 
            this.lbPointX.Location = new System.Drawing.Point(44, 31);
            this.lbPointX.Name = "lbPointX";
            this.lbPointX.Size = new System.Drawing.Size(68, 22);
            this.lbPointX.TabIndex = 2;
            this.lbPointX.Text = "0.000";
            this.lbPointX.Visible = false;
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(12, 34);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(26, 14);
            this.labelX.TabIndex = 1;
            this.labelX.Text = "X轴";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox2.Controls.Add(this.txtRltDis);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.radioRlt);
            this.groupBox2.Controls.Add(this.radioJog);
            this.groupBox2.Location = new System.Drawing.Point(12, 574);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(378, 79);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "运动模式:";
            // 
            // txtRltDis
            // 
            this.txtRltDis.Location = new System.Drawing.Point(181, 41);
            this.txtRltDis.Name = "txtRltDis";
            this.txtRltDis.Size = new System.Drawing.Size(84, 22);
            this.txtRltDis.TabIndex = 2;
            this.txtRltDis.Text = "10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "mm";
            // 
            // radioRlt
            // 
            this.radioRlt.AutoSize = true;
            this.radioRlt.Location = new System.Drawing.Point(84, 44);
            this.radioRlt.Name = "radioRlt";
            this.radioRlt.Size = new System.Drawing.Size(73, 18);
            this.radioRlt.TabIndex = 0;
            this.radioRlt.Text = "相对距离";
            this.radioRlt.UseVisualStyleBackColor = true;
            // 
            // radioJog
            // 
            this.radioJog.AutoSize = true;
            this.radioJog.Checked = true;
            this.radioJog.Location = new System.Drawing.Point(13, 43);
            this.radioJog.Name = "radioJog";
            this.radioJog.Size = new System.Drawing.Size(44, 18);
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
            this.groupBoxManual.Location = new System.Drawing.Point(14, 320);
            this.groupBoxManual.Name = "groupBoxManual";
            this.groupBoxManual.Size = new System.Drawing.Size(376, 239);
            this.groupBoxManual.TabIndex = 19;
            this.groupBoxManual.TabStop = false;
            this.groupBoxManual.Text = "手动调试:";
            // 
            // btnWPosDir
            // 
            this.btnWPosDir.Location = new System.Drawing.Point(232, 20);
            this.btnWPosDir.Name = "btnWPosDir";
            this.btnWPosDir.Size = new System.Drawing.Size(47, 70);
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
            this.btnWNegDir.Location = new System.Drawing.Point(232, 153);
            this.btnWNegDir.Name = "btnWNegDir";
            this.btnWNegDir.Size = new System.Drawing.Size(47, 70);
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
            this.btnZPosDir.Location = new System.Drawing.Point(156, 21);
            this.btnZPosDir.Name = "btnZPosDir";
            this.btnZPosDir.Size = new System.Drawing.Size(56, 69);
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
            this.btnYPosDir.Location = new System.Drawing.Point(59, 20);
            this.btnYPosDir.Name = "btnYPosDir";
            this.btnYPosDir.Size = new System.Drawing.Size(47, 70);
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
            this.btnZNegDir.Location = new System.Drawing.Point(156, 154);
            this.btnZNegDir.Name = "btnZNegDir";
            this.btnZNegDir.Size = new System.Drawing.Size(56, 69);
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
            this.btnYNegDir.Location = new System.Drawing.Point(59, 152);
            this.btnYNegDir.Name = "btnYNegDir";
            this.btnYNegDir.Size = new System.Drawing.Size(47, 70);
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
            this.btnXPosDir.Location = new System.Drawing.Point(84, 94);
            this.btnXPosDir.Name = "btnXPosDir";
            this.btnXPosDir.Size = new System.Drawing.Size(70, 47);
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
            this.btnXNegDir.Location = new System.Drawing.Point(7, 94);
            this.btnXNegDir.Name = "btnXNegDir";
            this.btnXNegDir.Size = new System.Drawing.Size(70, 47);
            this.btnXNegDir.TabIndex = 0;
            this.btnXNegDir.Tag = "X";
            this.btnXNegDir.Text = "X-";
            this.btnXNegDir.UseVisualStyleBackColor = true;
            this.btnXNegDir.Click += new System.EventHandler(this.btnXNegDir_Click);
            this.btnXNegDir.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnXNegDir_MouseDown);
            this.btnXNegDir.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnXNegDir_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(546, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 500);
            this.panel1.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(552, 558);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 24;
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
            this.cbxMotionTrail.Location = new System.Drawing.Point(620, 555);
            this.cbxMotionTrail.Name = "cbxMotionTrail";
            this.cbxMotionTrail.Size = new System.Drawing.Size(121, 22);
            this.cbxMotionTrail.TabIndex = 23;
            this.cbxMotionTrail.SelectedIndexChanged += new System.EventHandler(this.cbxMotionTrail_SelectedIndexChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(823, 546);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 38);
            this.btnStart.TabIndex = 25;
            this.btnStart.Text = "启动";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // TeachingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 707);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxMotionTrail);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxManual);
            this.Controls.Add(this.groupBoxPt);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.groupBox5);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TeachingForm";
            this.Text = "示教";
            this.groupBoxPt.ResumeLayout(false);
            this.groupBoxPt.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxManual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPt;
        private System.Windows.Forms.RadioButton radioStartePos;
        private System.Windows.Forms.RadioButton radioWeldPos1;
        private System.Windows.Forms.RadioButton radioEndPos;
        private System.Windows.Forms.RadioButton radioWeldPos2;
        private System.Windows.Forms.RadioButton rabReserve1;
        private System.Windows.Forms.RadioButton rabReserve2;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnSavePos;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox lbPointZ;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.TextBox lbPointW;
        private System.Windows.Forms.Label labelW;
        private System.Windows.Forms.TextBox lbPointY;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.TextBox lbPointX;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Button btnStop;
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox lbRealW;
        private System.Windows.Forms.TextBox lbRealZ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox lbRealY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lbRealX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxMotionTrail;
        private System.Windows.Forms.Button btnStart;
    }
}