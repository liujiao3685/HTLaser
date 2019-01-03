namespace HuaTianProject.UI
{
    partial class MDIForm
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lbPointZ = new System.Windows.Forms.TextBox();
            this.labelZ = new System.Windows.Forms.Label();
            this.lbPointW = new System.Windows.Forms.TextBox();
            this.labelW = new System.Windows.Forms.Label();
            this.lbPointY = new System.Windows.Forms.TextBox();
            this.labelY = new System.Windows.Forms.Label();
            this.lbPointX = new System.Windows.Forms.TextBox();
            this.labelX = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxManual = new System.Windows.Forms.GroupBox();
            this.btnWPosDir = new System.Windows.Forms.Button();
            this.btnWNegDir = new System.Windows.Forms.Button();
            this.btnZPosDir = new System.Windows.Forms.Button();
            this.btnYPosDir = new System.Windows.Forms.Button();
            this.btnZNegDir = new System.Windows.Forms.Button();
            this.btnYNegDir = new System.Windows.Forms.Button();
            this.btnXPosDir = new System.Windows.Forms.Button();
            this.btnXNegDir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtRltDis = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioRlt = new System.Windows.Forms.RadioButton();
            this.radioJog = new System.Windows.Forms.RadioButton();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnSavePos = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnAddPoint = new System.Windows.Forms.Button();
            this.txtPoint = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBoxManual.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(401, 16);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(450, 463);
            this.pictureBox.TabIndex = 22;
            this.pictureBox.TabStop = false;
            // 
            // cmbLocation
            // 
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Items.AddRange(new object[] {
            "起始位置",
            "终点位置",
            "焊接位置1",
            "焊接位置2",
            "备用位置1",
            "备用位置2"});
            this.cmbLocation.Location = new System.Drawing.Point(146, 13);
            this.cmbLocation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(159, 26);
            this.cmbLocation.TabIndex = 23;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox5.Controls.Add(this.lbPointZ);
            this.groupBox5.Controls.Add(this.labelZ);
            this.groupBox5.Controls.Add(this.lbPointW);
            this.groupBox5.Controls.Add(this.labelW);
            this.groupBox5.Controls.Add(this.lbPointY);
            this.groupBox5.Controls.Add(this.labelY);
            this.groupBox5.Controls.Add(this.lbPointX);
            this.groupBox5.Controls.Add(this.labelX);
            this.groupBox5.Location = new System.Drawing.Point(22, 96);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Size = new System.Drawing.Size(337, 171);
            this.groupBox5.TabIndex = 24;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "编辑点位置：(mm)";
            // 
            // lbPointZ
            // 
            this.lbPointZ.Location = new System.Drawing.Point(61, 110);
            this.lbPointZ.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbPointZ.Name = "lbPointZ";
            this.lbPointZ.Size = new System.Drawing.Size(77, 25);
            this.lbPointZ.TabIndex = 4;
            this.lbPointZ.Text = "0.000";
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Location = new System.Drawing.Point(22, 115);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(31, 18);
            this.labelZ.TabIndex = 3;
            this.labelZ.Text = "Z轴";
            // 
            // lbPointW
            // 
            this.lbPointW.Location = new System.Drawing.Point(206, 112);
            this.lbPointW.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbPointW.Name = "lbPointW";
            this.lbPointW.Size = new System.Drawing.Size(77, 25);
            this.lbPointW.TabIndex = 2;
            this.lbPointW.Text = "0.000";
            // 
            // labelW
            // 
            this.labelW.AutoSize = true;
            this.labelW.Location = new System.Drawing.Point(164, 115);
            this.labelW.Name = "labelW";
            this.labelW.Size = new System.Drawing.Size(37, 18);
            this.labelW.TabIndex = 1;
            this.labelW.Text = "W轴";
            // 
            // lbPointY
            // 
            this.lbPointY.Location = new System.Drawing.Point(206, 47);
            this.lbPointY.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbPointY.Name = "lbPointY";
            this.lbPointY.Size = new System.Drawing.Size(77, 25);
            this.lbPointY.TabIndex = 2;
            this.lbPointY.Text = "0.000";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(168, 51);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(33, 18);
            this.labelY.TabIndex = 1;
            this.labelY.Text = "Y轴";
            // 
            // lbPointX
            // 
            this.lbPointX.Location = new System.Drawing.Point(61, 47);
            this.lbPointX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbPointX.Name = "lbPointX";
            this.lbPointX.Size = new System.Drawing.Size(77, 25);
            this.lbPointX.TabIndex = 2;
            this.lbPointX.Text = "0.000";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(20, 51);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(32, 18);
            this.labelX.TabIndex = 1;
            this.labelX.Text = "X轴";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 18);
            this.label1.TabIndex = 25;
            this.label1.Text = "点位选择：";
            // 
            // groupBoxManual
            // 
            this.groupBoxManual.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBoxManual.Controls.Add(this.btnWPosDir);
            this.groupBoxManual.Controls.Add(this.btnWNegDir);
            this.groupBoxManual.Controls.Add(this.btnZPosDir);
            this.groupBoxManual.Controls.Add(this.btnYPosDir);
            this.groupBoxManual.Controls.Add(this.btnZNegDir);
            this.groupBoxManual.Controls.Add(this.btnYNegDir);
            this.groupBoxManual.Controls.Add(this.btnXPosDir);
            this.groupBoxManual.Controls.Add(this.btnXNegDir);
            this.groupBoxManual.Location = new System.Drawing.Point(22, 285);
            this.groupBoxManual.Name = "groupBoxManual";
            this.groupBoxManual.Size = new System.Drawing.Size(337, 240);
            this.groupBoxManual.TabIndex = 26;
            this.groupBoxManual.TabStop = false;
            this.groupBoxManual.Text = "手动调试:";
            // 
            // btnWPosDir
            // 
            this.btnWPosDir.Location = new System.Drawing.Point(263, 23);
            this.btnWPosDir.Name = "btnWPosDir";
            this.btnWPosDir.Size = new System.Drawing.Size(47, 70);
            this.btnWPosDir.TabIndex = 0;
            this.btnWPosDir.Tag = "RY";
            this.btnWPosDir.Text = "W+";
            this.btnWPosDir.UseVisualStyleBackColor = true;
            // 
            // btnWNegDir
            // 
            this.btnWNegDir.Location = new System.Drawing.Point(263, 156);
            this.btnWNegDir.Name = "btnWNegDir";
            this.btnWNegDir.Size = new System.Drawing.Size(47, 70);
            this.btnWNegDir.TabIndex = 0;
            this.btnWNegDir.Tag = "RY";
            this.btnWNegDir.Text = "W-";
            this.btnWNegDir.UseVisualStyleBackColor = true;
            // 
            // btnZPosDir
            // 
            this.btnZPosDir.Location = new System.Drawing.Point(191, 23);
            this.btnZPosDir.Name = "btnZPosDir";
            this.btnZPosDir.Size = new System.Drawing.Size(46, 69);
            this.btnZPosDir.TabIndex = 0;
            this.btnZPosDir.Tag = "Z";
            this.btnZPosDir.Text = "Z+";
            this.btnZPosDir.UseVisualStyleBackColor = true;
            // 
            // btnYPosDir
            // 
            this.btnYPosDir.Location = new System.Drawing.Point(66, 20);
            this.btnYPosDir.Name = "btnYPosDir";
            this.btnYPosDir.Size = new System.Drawing.Size(47, 70);
            this.btnYPosDir.TabIndex = 0;
            this.btnYPosDir.Tag = "Y";
            this.btnYPosDir.Text = "Y+";
            this.btnYPosDir.UseVisualStyleBackColor = true;
            // 
            // btnZNegDir
            // 
            this.btnZNegDir.Location = new System.Drawing.Point(191, 156);
            this.btnZNegDir.Name = "btnZNegDir";
            this.btnZNegDir.Size = new System.Drawing.Size(46, 69);
            this.btnZNegDir.TabIndex = 0;
            this.btnZNegDir.Tag = "Z";
            this.btnZNegDir.Text = "Z-";
            this.btnZNegDir.UseVisualStyleBackColor = true;
            // 
            // btnYNegDir
            // 
            this.btnYNegDir.Location = new System.Drawing.Point(66, 156);
            this.btnYNegDir.Name = "btnYNegDir";
            this.btnYNegDir.Size = new System.Drawing.Size(47, 70);
            this.btnYNegDir.TabIndex = 0;
            this.btnYNegDir.Tag = "Y";
            this.btnYNegDir.Text = "Y-";
            this.btnYNegDir.UseVisualStyleBackColor = true;
            // 
            // btnXPosDir
            // 
            this.btnXPosDir.Location = new System.Drawing.Point(109, 102);
            this.btnXPosDir.Name = "btnXPosDir";
            this.btnXPosDir.Size = new System.Drawing.Size(70, 47);
            this.btnXPosDir.TabIndex = 0;
            this.btnXPosDir.Tag = "X";
            this.btnXPosDir.Text = "X+";
            this.btnXPosDir.UseVisualStyleBackColor = true;
            // 
            // btnXNegDir
            // 
            this.btnXNegDir.Location = new System.Drawing.Point(6, 102);
            this.btnXNegDir.Name = "btnXNegDir";
            this.btnXNegDir.Size = new System.Drawing.Size(70, 47);
            this.btnXNegDir.TabIndex = 0;
            this.btnXNegDir.Tag = "X";
            this.btnXNegDir.Text = "X-";
            this.btnXNegDir.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox2.Controls.Add(this.txtRltDis);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.radioRlt);
            this.groupBox2.Controls.Add(this.radioJog);
            this.groupBox2.Location = new System.Drawing.Point(22, 553);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 79);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "运动模式:";
            // 
            // txtRltDis
            // 
            this.txtRltDis.Location = new System.Drawing.Point(199, 37);
            this.txtRltDis.Name = "txtRltDis";
            this.txtRltDis.Size = new System.Drawing.Size(84, 25);
            this.txtRltDis.TabIndex = 2;
            this.txtRltDis.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "mm";
            // 
            // radioRlt
            // 
            this.radioRlt.AutoSize = true;
            this.radioRlt.Location = new System.Drawing.Point(137, 39);
            this.radioRlt.Name = "radioRlt";
            this.radioRlt.Size = new System.Drawing.Size(56, 22);
            this.radioRlt.TabIndex = 0;
            this.radioRlt.Text = "步进";
            this.radioRlt.UseVisualStyleBackColor = true;
            // 
            // radioJog
            // 
            this.radioJog.AutoSize = true;
            this.radioJog.Checked = true;
            this.radioJog.Location = new System.Drawing.Point(42, 39);
            this.radioJog.Name = "radioJog";
            this.radioJog.Size = new System.Drawing.Size(56, 22);
            this.radioJog.TabIndex = 0;
            this.radioJog.TabStop = true;
            this.radioJog.Text = "连续";
            this.radioJog.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox10.Controls.Add(this.btnMove);
            this.groupBox10.Controls.Add(this.btnSavePos);
            this.groupBox10.Location = new System.Drawing.Point(401, 507);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(450, 128);
            this.groupBox10.TabIndex = 28;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "运动：";
            // 
            // btnMove
            // 
            this.btnMove.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnMove.ForeColor = System.Drawing.Color.Black;
            this.btnMove.Location = new System.Drawing.Point(75, 38);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(98, 66);
            this.btnMove.TabIndex = 0;
            this.btnMove.Text = "Move";
            this.btnMove.UseVisualStyleBackColor = true;
            // 
            // btnSavePos
            // 
            this.btnSavePos.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnSavePos.ForeColor = System.Drawing.Color.Black;
            this.btnSavePos.Location = new System.Drawing.Point(271, 38);
            this.btnSavePos.Name = "btnSavePos";
            this.btnSavePos.Size = new System.Drawing.Size(98, 66);
            this.btnSavePos.TabIndex = 0;
            this.btnSavePos.Text = "保存示教位";
            this.btnSavePos.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Location = new System.Drawing.Point(872, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 450);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "轨迹:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 66);
            this.button1.TabIndex = 19;
            this.button1.Text = "停止";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 11F);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(18, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 66);
            this.button2.TabIndex = 0;
            this.button2.Text = "重绘";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Tahoma", 11F);
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(18, 148);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 66);
            this.button3.TabIndex = 0;
            this.button3.Text = "去除上一段";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnAddPoint
            // 
            this.btnAddPoint.AutoSize = true;
            this.btnAddPoint.Location = new System.Drawing.Point(45, 51);
            this.btnAddPoint.Name = "btnAddPoint";
            this.btnAddPoint.Size = new System.Drawing.Size(78, 28);
            this.btnAddPoint.TabIndex = 30;
            this.btnAddPoint.Text = "增加点位";
            this.btnAddPoint.UseVisualStyleBackColor = true;
            this.btnAddPoint.Click += new System.EventHandler(this.btnAddPoint_Click);
            // 
            // txtPoint
            // 
            this.txtPoint.Location = new System.Drawing.Point(146, 52);
            this.txtPoint.Name = "txtPoint";
            this.txtPoint.Size = new System.Drawing.Size(159, 25);
            this.txtPoint.TabIndex = 31;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(18, 364);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 66);
            this.button4.TabIndex = 20;
            this.button4.Text = "停止";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // MDIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 667);
            this.Controls.Add(this.txtPoint);
            this.Controls.Add(this.btnAddPoint);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxManual);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.pictureBox);
            this.Font = new System.Drawing.Font("Tahoma", 11F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MDIForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "示教";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBoxManual.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox lbPointZ;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.TextBox lbPointW;
        private System.Windows.Forms.Label labelW;
        private System.Windows.Forms.TextBox lbPointY;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.TextBox lbPointX;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxManual;
        private System.Windows.Forms.Button btnWPosDir;
        private System.Windows.Forms.Button btnWNegDir;
        private System.Windows.Forms.Button btnZPosDir;
        private System.Windows.Forms.Button btnYPosDir;
        private System.Windows.Forms.Button btnZNegDir;
        private System.Windows.Forms.Button btnYNegDir;
        private System.Windows.Forms.Button btnXPosDir;
        private System.Windows.Forms.Button btnXNegDir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtRltDis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioRlt;
        private System.Windows.Forms.RadioButton radioJog;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnSavePos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnAddPoint;
        private System.Windows.Forms.TextBox txtPoint;
        private System.Windows.Forms.Button button4;
    }
}