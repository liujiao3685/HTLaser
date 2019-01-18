using System.Drawing;

namespace MES.UserControls
{
    partial class CollectingSystem
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
            this.labBarCode = new System.Windows.Forms.Label();
            this.txtRPos = new System.Windows.Forms.TextBox();
            this.labR = new System.Windows.Forms.Label();
            this.txtZPos = new System.Windows.Forms.TextBox();
            this.labZ = new System.Windows.Forms.Label();
            this.txtYPos = new System.Windows.Forms.TextBox();
            this.labY = new System.Windows.Forms.Label();
            this.btnStart = new HslCommunication.Controls.UserButton();
            this.txtFlow = new System.Windows.Forms.TextBox();
            this.labProtectFlow = new System.Windows.Forms.Label();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.labWeldSpeed = new System.Windows.Forms.Label();
            this.txtWeldTime = new System.Windows.Forms.TextBox();
            this.labWeldTime = new System.Windows.Forms.Label();
            this.txtPressure = new System.Windows.Forms.TextBox();
            this.labPressName = new System.Windows.Forms.Label();
            this.txtXPos = new System.Windows.Forms.TextBox();
            this.labX = new System.Windows.Forms.Label();
            this.txtWeldPower = new System.Windows.Forms.TextBox();
            this.labWeldPower = new System.Windows.Forms.Label();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panelPressure = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // labBarCode
            // 
            this.labBarCode.AutoSize = true;
            this.labBarCode.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labBarCode.Location = new System.Drawing.Point(369, 36);
            this.labBarCode.Name = "labBarCode";
            this.labBarCode.Size = new System.Drawing.Size(72, 30);
            this.labBarCode.TabIndex = 0;
            this.labBarCode.Text = "条码:";
            // 
            // txtRPos
            // 
            this.txtRPos.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtRPos.Location = new System.Drawing.Point(693, 320);
            this.txtRPos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRPos.Name = "txtRPos";
            this.txtRPos.ReadOnly = true;
            this.txtRPos.Size = new System.Drawing.Size(207, 38);
            this.txtRPos.TabIndex = 23;
            this.txtRPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labR
            // 
            this.labR.AutoSize = true;
            this.labR.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labR.Location = new System.Drawing.Point(566, 325);
            this.labR.Name = "labR";
            this.labR.Size = new System.Drawing.Size(112, 30);
            this.labR.TabIndex = 22;
            this.labR.Text = "R  坐 标:";
            // 
            // txtZPos
            // 
            this.txtZPos.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtZPos.Location = new System.Drawing.Point(224, 325);
            this.txtZPos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtZPos.Name = "txtZPos";
            this.txtZPos.ReadOnly = true;
            this.txtZPos.Size = new System.Drawing.Size(207, 38);
            this.txtZPos.TabIndex = 21;
            this.txtZPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labZ
            // 
            this.labZ.AutoSize = true;
            this.labZ.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labZ.Location = new System.Drawing.Point(93, 328);
            this.labZ.Name = "labZ";
            this.labZ.Size = new System.Drawing.Size(118, 30);
            this.labZ.TabIndex = 20;
            this.labZ.Text = " Z  坐 标:";
            // 
            // txtYPos
            // 
            this.txtYPos.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtYPos.Location = new System.Drawing.Point(693, 212);
            this.txtYPos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtYPos.Name = "txtYPos";
            this.txtYPos.ReadOnly = true;
            this.txtYPos.Size = new System.Drawing.Size(207, 38);
            this.txtYPos.TabIndex = 19;
            this.txtYPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labY
            // 
            this.labY.AutoSize = true;
            this.labY.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labY.Location = new System.Drawing.Point(566, 216);
            this.labY.Name = "labY";
            this.labY.Size = new System.Drawing.Size(110, 30);
            this.labY.TabIndex = 18;
            this.labY.Text = "Y  坐 标:";
            // 
            // btnStart
            // 
            this.btnStart.AutoSize = true;
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.CornerRadius = 5;
            this.btnStart.CustomerInformation = "";
            this.btnStart.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnStart.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.btnStart.Location = new System.Drawing.Point(683, 513);
            this.btnStart.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.btnStart.Name = "btnStart";
            this.btnStart.OriginalColor = System.Drawing.Color.Lime;
            this.btnStart.Size = new System.Drawing.Size(208, 79);
            this.btnStart.TabIndex = 14;
            this.btnStart.UIText = "采集";
            this.btnStart.Visible = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtFlow
            // 
            this.txtFlow.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtFlow.Location = new System.Drawing.Point(223, 420);
            this.txtFlow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFlow.Name = "txtFlow";
            this.txtFlow.ReadOnly = true;
            this.txtFlow.Size = new System.Drawing.Size(207, 38);
            this.txtFlow.TabIndex = 13;
            this.txtFlow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labProtectFlow
            // 
            this.labProtectFlow.AutoSize = true;
            this.labProtectFlow.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labProtectFlow.Location = new System.Drawing.Point(67, 424);
            this.labProtectFlow.Name = "labProtectFlow";
            this.labProtectFlow.Size = new System.Drawing.Size(147, 30);
            this.labProtectFlow.TabIndex = 12;
            this.labProtectFlow.Text = "保护气流量:";
            // 
            // txtSpeed
            // 
            this.txtSpeed.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtSpeed.Location = new System.Drawing.Point(693, 110);
            this.txtSpeed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.ReadOnly = true;
            this.txtSpeed.Size = new System.Drawing.Size(207, 38);
            this.txtSpeed.TabIndex = 11;
            this.txtSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labWeldSpeed
            // 
            this.labWeldSpeed.AutoSize = true;
            this.labWeldSpeed.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labWeldSpeed.Location = new System.Drawing.Point(554, 114);
            this.labWeldSpeed.Name = "labWeldSpeed";
            this.labWeldSpeed.Size = new System.Drawing.Size(122, 30);
            this.labWeldSpeed.TabIndex = 10;
            this.labWeldSpeed.Text = "焊接速度:";
            // 
            // txtWeldTime
            // 
            this.txtWeldTime.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtWeldTime.Location = new System.Drawing.Point(693, 420);
            this.txtWeldTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWeldTime.Name = "txtWeldTime";
            this.txtWeldTime.ReadOnly = true;
            this.txtWeldTime.Size = new System.Drawing.Size(207, 38);
            this.txtWeldTime.TabIndex = 9;
            this.txtWeldTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labWeldTime
            // 
            this.labWeldTime.AutoSize = true;
            this.labWeldTime.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labWeldTime.Location = new System.Drawing.Point(559, 424);
            this.labWeldTime.Name = "labWeldTime";
            this.labWeldTime.Size = new System.Drawing.Size(122, 30);
            this.labWeldTime.TabIndex = 8;
            this.labWeldTime.Text = "焊接时间:";
            // 
            // txtPressure
            // 
            this.txtPressure.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtPressure.Location = new System.Drawing.Point(224, 513);
            this.txtPressure.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPressure.Name = "txtPressure";
            this.txtPressure.ReadOnly = true;
            this.txtPressure.Size = new System.Drawing.Size(207, 38);
            this.txtPressure.TabIndex = 7;
            this.txtPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labPressName
            // 
            this.labPressName.AutoSize = true;
            this.labPressName.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labPressName.Location = new System.Drawing.Point(64, 517);
            this.labPressName.Name = "labPressName";
            this.labPressName.Size = new System.Drawing.Size(147, 30);
            this.labPressName.TabIndex = 6;
            this.labPressName.Text = "卡盘夹紧力:";
            // 
            // txtXPos
            // 
            this.txtXPos.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtXPos.Location = new System.Drawing.Point(224, 217);
            this.txtXPos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtXPos.Name = "txtXPos";
            this.txtXPos.ReadOnly = true;
            this.txtXPos.Size = new System.Drawing.Size(207, 38);
            this.txtXPos.TabIndex = 5;
            this.txtXPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labX
            // 
            this.labX.AutoSize = true;
            this.labX.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labX.Location = new System.Drawing.Point(92, 220);
            this.labX.Name = "labX";
            this.labX.Size = new System.Drawing.Size(119, 30);
            this.labX.TabIndex = 4;
            this.labX.Text = " X  坐 标:";
            // 
            // txtWeldPower
            // 
            this.txtWeldPower.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtWeldPower.Location = new System.Drawing.Point(224, 114);
            this.txtWeldPower.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWeldPower.Name = "txtWeldPower";
            this.txtWeldPower.ReadOnly = true;
            this.txtWeldPower.Size = new System.Drawing.Size(207, 38);
            this.txtWeldPower.TabIndex = 3;
            this.txtWeldPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labWeldPower
            // 
            this.labWeldPower.AutoSize = true;
            this.labWeldPower.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labWeldPower.Location = new System.Drawing.Point(89, 118);
            this.labWeldPower.Name = "labWeldPower";
            this.labWeldPower.Size = new System.Drawing.Size(122, 30);
            this.labWeldPower.TabIndex = 2;
            this.labWeldPower.Text = "焊接功率:";
            // 
            // txtBarCode
            // 
            this.txtBarCode.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtBarCode.Location = new System.Drawing.Point(476, 31);
            this.txtBarCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.ReadOnly = true;
            this.txtBarCode.Size = new System.Drawing.Size(224, 38);
            this.txtBarCode.TabIndex = 1;
            this.txtBarCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label11.Location = new System.Drawing.Point(444, 121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 29);
            this.label11.TabIndex = 2;
            this.label11.Text = "W";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label12.Location = new System.Drawing.Point(906, 114);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 29);
            this.label12.TabIndex = 2;
            this.label12.Text = "°/s";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label13.Location = new System.Drawing.Point(443, 426);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 29);
            this.label13.TabIndex = 2;
            this.label13.Text = "L/min";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label14.Location = new System.Drawing.Point(444, 517);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 30);
            this.label14.TabIndex = 2;
            this.label14.Text = "MPa";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label15.Location = new System.Drawing.Point(444, 332);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 29);
            this.label15.TabIndex = 2;
            this.label15.Text = "mm";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label16.Location = new System.Drawing.Point(906, 216);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 29);
            this.label16.TabIndex = 2;
            this.label16.Text = "mm";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label17.Location = new System.Drawing.Point(906, 324);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(24, 29);
            this.label17.TabIndex = 2;
            this.label17.Text = "°";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label18.Location = new System.Drawing.Point(444, 222);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 29);
            this.label18.TabIndex = 2;
            this.label18.Text = "mm";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label19.Location = new System.Drawing.Point(906, 424);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(26, 29);
            this.label19.TabIndex = 2;
            this.label19.Text = "S";
            // 
            // panelPressure
            // 
            this.panelPressure.Location = new System.Drawing.Point(567, 502);
            this.panelPressure.Name = "panelPressure";
            this.panelPressure.Size = new System.Drawing.Size(400, 90);
            this.panelPressure.TabIndex = 24;
            // 
            // CollectingSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.labPressName);
            this.Controls.Add(this.txtPressure);
            this.Controls.Add(this.panelPressure);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtRPos);
            this.Controls.Add(this.labR);
            this.Controls.Add(this.labBarCode);
            this.Controls.Add(this.txtZPos);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.labZ);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.labWeldPower);
            this.Controls.Add(this.txtYPos);
            this.Controls.Add(this.txtWeldPower);
            this.Controls.Add(this.labY);
            this.Controls.Add(this.labX);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtXPos);
            this.Controls.Add(this.txtFlow);
            this.Controls.Add(this.labProtectFlow);
            this.Controls.Add(this.txtSpeed);
            this.Controls.Add(this.labWeldTime);
            this.Controls.Add(this.labWeldSpeed);
            this.Controls.Add(this.txtWeldTime);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CollectingSystem";
            this.Size = new System.Drawing.Size(1051, 633);
            this.Load += new System.EventHandler(this.CollectDataControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labBarCode;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.TextBox txtWeldPower;
        private System.Windows.Forms.Label labWeldPower;
        private System.Windows.Forms.TextBox txtPressure;
        private System.Windows.Forms.Label labPressName;
        private System.Windows.Forms.TextBox txtXPos;
        private System.Windows.Forms.Label labX;
        private System.Windows.Forms.TextBox txtFlow;
        private System.Windows.Forms.Label labProtectFlow;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.Label labWeldSpeed;
        private System.Windows.Forms.TextBox txtWeldTime;
        private System.Windows.Forms.Label labWeldTime;
        private HslCommunication.Controls.UserButton btnStart;
        private System.Windows.Forms.TextBox txtRPos;
        private System.Windows.Forms.Label labR;
        private System.Windows.Forms.TextBox txtZPos;
        private System.Windows.Forms.Label labZ;
        private System.Windows.Forms.TextBox txtYPos;
        private System.Windows.Forms.Label labY;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panelPressure;
    }
}
