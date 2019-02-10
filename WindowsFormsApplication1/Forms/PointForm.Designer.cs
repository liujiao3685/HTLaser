namespace WindowsFormsApplication1
{
    partial class PointForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.txt3 = new System.Windows.Forms.TextBox();
            this.txt4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCurPoint = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rabPie = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEndAngle = new System.Windows.Forms.TextBox();
            this.txtStartAngle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.rabArc = new System.Windows.Forms.RadioButton();
            this.rabRectangle = new System.Windows.Forms.RadioButton();
            this.rabCircle = new System.Windows.Forms.RadioButton();
            this.labstart = new System.Windows.Forms.Label();
            this.btnsimulation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(169, 77);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(627, 539);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(676, 642);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 55);
            this.button1.TabIndex = 1;
            this.button1.Text = "重绘";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt1
            // 
            this.txt1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.txt1.Location = new System.Drawing.Point(220, 28);
            this.txt1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt1.Name = "txt1";
            this.txt1.ReadOnly = true;
            this.txt1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txt1.Size = new System.Drawing.Size(108, 27);
            this.txt1.TabIndex = 2;
            // 
            // txt2
            // 
            this.txt2.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.txt2.Location = new System.Drawing.Point(382, 28);
            this.txt2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt2.Name = "txt2";
            this.txt2.ReadOnly = true;
            this.txt2.Size = new System.Drawing.Size(100, 27);
            this.txt2.TabIndex = 3;
            // 
            // txt3
            // 
            this.txt3.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.txt3.Location = new System.Drawing.Point(542, 28);
            this.txt3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt3.Name = "txt3";
            this.txt3.ReadOnly = true;
            this.txt3.Size = new System.Drawing.Size(100, 27);
            this.txt3.TabIndex = 4;
            // 
            // txt4
            // 
            this.txt4.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.txt4.Location = new System.Drawing.Point(696, 28);
            this.txt4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt4.Name = "txt4";
            this.txt4.ReadOnly = true;
            this.txt4.Size = new System.Drawing.Size(100, 27);
            this.txt4.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label1.Location = new System.Drawing.Point(192, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DodgerBlue;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label3.Location = new System.Drawing.Point(514, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DodgerBlue;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label4.Location = new System.Drawing.Point(354, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DodgerBlue;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label5.Location = new System.Drawing.Point(666, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "4";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(529, 642);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 55);
            this.button2.TabIndex = 1;
            this.button2.Text = "解析";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(382, 642);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 55);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCurPoint
            // 
            this.txtCurPoint.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.txtCurPoint.Location = new System.Drawing.Point(247, 654);
            this.txtCurPoint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCurPoint.Name = "txtCurPoint";
            this.txtCurPoint.ReadOnly = true;
            this.txtCurPoint.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtCurPoint.Size = new System.Drawing.Size(108, 27);
            this.txtCurPoint.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DodgerBlue;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label2.Location = new System.Drawing.Point(185, 658);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Point";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rabPie);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtEndAngle);
            this.groupBox1.Controls.Add(this.txtStartAngle);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtHeight);
            this.groupBox1.Controls.Add(this.txtWidth);
            this.groupBox1.Controls.Add(this.rabArc);
            this.groupBox1.Controls.Add(this.rabRectangle);
            this.groupBox1.Controls.Add(this.rabCircle);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupBox1.Location = new System.Drawing.Point(24, 28);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(124, 510);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "形状选择";
            // 
            // rabPie
            // 
            this.rabPie.AutoSize = true;
            this.rabPie.Location = new System.Drawing.Point(24, 242);
            this.rabPie.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rabPie.Name = "rabPie";
            this.rabPie.Size = new System.Drawing.Size(60, 25);
            this.rabPie.TabIndex = 11;
            this.rabPie.Text = "扇形";
            this.rabPie.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 401);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 21);
            this.label8.TabIndex = 10;
            this.label8.Text = "E°";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 366);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 21);
            this.label9.TabIndex = 9;
            this.label9.Text = "S°";
            // 
            // txtEndAngle
            // 
            this.txtEndAngle.Location = new System.Drawing.Point(39, 398);
            this.txtEndAngle.Name = "txtEndAngle";
            this.txtEndAngle.Size = new System.Drawing.Size(60, 29);
            this.txtEndAngle.TabIndex = 8;
            this.txtEndAngle.Text = "90";
            this.txtEndAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtStartAngle
            // 
            this.txtStartAngle.Location = new System.Drawing.Point(39, 363);
            this.txtStartAngle.Name = "txtStartAngle";
            this.txtStartAngle.Size = new System.Drawing.Size(60, 29);
            this.txtStartAngle.TabIndex = 7;
            this.txtStartAngle.Text = "360";
            this.txtStartAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 325);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 21);
            this.label7.TabIndex = 6;
            this.label7.Text = "高";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "宽";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(39, 322);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(60, 29);
            this.txtHeight.TabIndex = 4;
            this.txtHeight.Text = "100";
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(39, 287);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(60, 29);
            this.txtWidth.TabIndex = 3;
            this.txtWidth.Text = "100";
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rabArc
            // 
            this.rabArc.AutoSize = true;
            this.rabArc.Location = new System.Drawing.Point(24, 184);
            this.rabArc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rabArc.Name = "rabArc";
            this.rabArc.Size = new System.Drawing.Size(60, 25);
            this.rabArc.TabIndex = 2;
            this.rabArc.Text = "圆弧";
            this.rabArc.UseVisualStyleBackColor = true;
            // 
            // rabRectangle
            // 
            this.rabRectangle.AutoSize = true;
            this.rabRectangle.Checked = true;
            this.rabRectangle.Location = new System.Drawing.Point(24, 65);
            this.rabRectangle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rabRectangle.Name = "rabRectangle";
            this.rabRectangle.Size = new System.Drawing.Size(60, 25);
            this.rabRectangle.TabIndex = 1;
            this.rabRectangle.TabStop = true;
            this.rabRectangle.Text = "矩形";
            this.rabRectangle.UseVisualStyleBackColor = true;
            // 
            // rabCircle
            // 
            this.rabCircle.AutoSize = true;
            this.rabCircle.Location = new System.Drawing.Point(24, 126);
            this.rabCircle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rabCircle.Name = "rabCircle";
            this.rabCircle.Size = new System.Drawing.Size(60, 25);
            this.rabCircle.TabIndex = 0;
            this.rabCircle.Text = "圆形";
            this.rabCircle.UseVisualStyleBackColor = true;
            // 
            // labstart
            // 
            this.labstart.AutoSize = true;
            this.labstart.Location = new System.Drawing.Point(450, 300);
            this.labstart.Name = "labstart";
            this.labstart.Size = new System.Drawing.Size(11, 17);
            this.labstart.TabIndex = 14;
            this.labstart.Text = ".";
            this.labstart.Visible = false;
            // 
            // btnsimulation
            // 
            this.btnsimulation.Location = new System.Drawing.Point(24, 570);
            this.btnsimulation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnsimulation.Name = "btnsimulation";
            this.btnsimulation.Size = new System.Drawing.Size(113, 55);
            this.btnsimulation.TabIndex = 15;
            this.btnsimulation.Text = "模拟轨迹";
            this.btnsimulation.UseVisualStyleBackColor = true;
            this.btnsimulation.Click += new System.EventHandler(this.btnsimulation_Click);
            // 
            // PointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 715);
            this.Controls.Add(this.btnsimulation);
            this.Controls.Add(this.labstart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCurPoint);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt4);
            this.Controls.Add(this.txt3);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PointForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PointForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.TextBox txt3;
        private System.Windows.Forms.TextBox txt4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtCurPoint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rabCircle;
        private System.Windows.Forms.RadioButton rabRectangle;
        private System.Windows.Forms.Label labstart;
        private System.Windows.Forms.Button btnsimulation;
        private System.Windows.Forms.RadioButton rabArc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEndAngle;
        private System.Windows.Forms.TextBox txtStartAngle;
        private System.Windows.Forms.RadioButton rabPie;
    }
}