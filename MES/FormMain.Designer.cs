namespace MES
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolLoginCenter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolProtectCenter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolParamSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMuduleSet = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSpotRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMachineState = new System.Windows.Forms.ToolStripMenuItem();
            this.toolLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolChinese = new System.Windows.Forms.ToolStripMenuItem();
            this.toolEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.点检中心ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolCurrentUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTips = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.labBarCode = new System.Windows.Forms.Label();
            this.panelBox = new System.Windows.Forms.Panel();
            this.btnCollection = new HslCommunication.Controls.UserButton();
            this.btnLogSystem = new HslCommunication.Controls.UserButton();
            this.btnTraceSystem = new HslCommunication.Controls.UserButton();
            this.grbMonitorOnline = new System.Windows.Forms.GroupBox();
            this.txtLwmCheck = new HslCommunication.Controls.UserButton();
            this.labLwmCheck = new System.Windows.Forms.Label();
            this.lanternState = new HslCommunication.Controls.UserLantern();
            this.txtCoaxility = new HslCommunication.Controls.UserButton();
            this.txtSurface = new HslCommunication.Controls.UserButton();
            this.labState = new System.Windows.Forms.Label();
            this.labSurface = new System.Windows.Forms.Label();
            this.labCoax = new System.Windows.Forms.Label();
            this.panelParBox = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.exeIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.timerGC = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.grbMonitorOnline.SuspendLayout();
            this.panelParBox.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLoginCenter,
            this.toolProtectCenter,
            this.toolParamSetting,
            this.toolMuduleSet,
            this.toolSpotRecord,
            this.toolMachineState,
            this.toolLanguage,
            this.testToolStripMenuItem,
            this.点检中心ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1458, 28);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolLoginCenter
            // 
            this.toolLoginCenter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLogin,
            this.toolCancel});
            this.toolLoginCenter.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.toolLoginCenter.Name = "toolLoginCenter";
            this.toolLoginCenter.Size = new System.Drawing.Size(81, 24);
            this.toolLoginCenter.Text = "&用户中心";
            // 
            // toolLogin
            // 
            this.toolLogin.Name = "toolLogin";
            this.toolLogin.Size = new System.Drawing.Size(108, 24);
            this.toolLogin.Text = "&登录";
            this.toolLogin.Click += new System.EventHandler(this.登录ToolStripMenuItem1_Click);
            // 
            // toolCancel
            // 
            this.toolCancel.Name = "toolCancel";
            this.toolCancel.Size = new System.Drawing.Size(108, 24);
            this.toolCancel.Text = "&注销";
            this.toolCancel.Click += new System.EventHandler(this.注销ToolStripMenuItem_Click);
            // 
            // toolProtectCenter
            // 
            this.toolProtectCenter.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.toolProtectCenter.Name = "toolProtectCenter";
            this.toolProtectCenter.Size = new System.Drawing.Size(81, 24);
            this.toolProtectCenter.Text = "&维护中心";
            this.toolProtectCenter.Click += new System.EventHandler(this.维护中心ToolStripMenuItem_Click);
            // 
            // toolParamSetting
            // 
            this.toolParamSetting.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.toolParamSetting.Name = "toolParamSetting";
            this.toolParamSetting.Size = new System.Drawing.Size(81, 24);
            this.toolParamSetting.Text = "&参数配置";
            this.toolParamSetting.Click += new System.EventHandler(this.参数配置ToolStripMenuItem_Click);
            // 
            // toolMuduleSet
            // 
            this.toolMuduleSet.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.toolMuduleSet.Name = "toolMuduleSet";
            this.toolMuduleSet.Size = new System.Drawing.Size(81, 24);
            this.toolMuduleSet.Text = "&模板配置";
            this.toolMuduleSet.Click += new System.EventHandler(this.模板配置ToolStripMenuItem_Click);
            // 
            // toolSpotRecord
            // 
            this.toolSpotRecord.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.toolSpotRecord.Name = "toolSpotRecord";
            this.toolSpotRecord.Size = new System.Drawing.Size(81, 24);
            this.toolSpotRecord.Text = "&点检记录";
            this.toolSpotRecord.Click += new System.EventHandler(this.点检记录ToolStripMenuItem_Click);
            // 
            // toolMachineState
            // 
            this.toolMachineState.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.toolMachineState.Name = "toolMachineState";
            this.toolMachineState.Size = new System.Drawing.Size(81, 24);
            this.toolMachineState.Text = "&通讯监控";
            this.toolMachineState.Click += new System.EventHandler(this.通讯监控ToolStripMenuItem_Click);
            // 
            // toolLanguage
            // 
            this.toolLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolChinese,
            this.toolEnglish});
            this.toolLanguage.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.toolLanguage.Name = "toolLanguage";
            this.toolLanguage.Size = new System.Drawing.Size(51, 24);
            this.toolLanguage.Text = "&语言";
            // 
            // toolChinese
            // 
            this.toolChinese.Name = "toolChinese";
            this.toolChinese.Size = new System.Drawing.Size(180, 24);
            this.toolChinese.Text = "中文";
            this.toolChinese.Click += new System.EventHandler(this.中文ToolStripMenuItem_Click);
            // 
            // toolEnglish
            // 
            this.toolEnglish.Name = "toolEnglish";
            this.toolEnglish.Size = new System.Drawing.Size(180, 24);
            this.toolEnglish.Text = "英语";
            this.toolEnglish.Click += new System.EventHandler(this.英语ToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Visible = false;
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // 点检中心ToolStripMenuItem
            // 
            this.点检中心ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.点检中心ToolStripMenuItem.Name = "点检中心ToolStripMenuItem";
            this.点检中心ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.点检中心ToolStripMenuItem.Text = "点检中心";
            this.点检中心ToolStripMenuItem.Visible = false;
            this.点检中心ToolStripMenuItem.Click += new System.EventHandler(this.点检中心ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.statusStrip1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolCurrentUser,
            this.toolTips});
            this.statusStrip1.Location = new System.Drawing.Point(0, 783);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1458, 29);
            this.statusStrip1.TabIndex = 31;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolCurrentUser
            // 
            this.toolCurrentUser.BackColor = System.Drawing.Color.Tomato;
            this.toolCurrentUser.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.toolCurrentUser.Name = "toolCurrentUser";
            this.toolCurrentUser.Size = new System.Drawing.Size(178, 24);
            this.toolCurrentUser.Text = "当前用户：未登录";
            // 
            // toolTips
            // 
            this.toolTips.BackColor = System.Drawing.SystemColors.Control;
            this.toolTips.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.toolTips.Name = "toolTips";
            this.toolTips.Size = new System.Drawing.Size(1265, 24);
            this.toolTips.Spring = true;
            this.toolTips.Text = "提示：";
            this.toolTips.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBarCode
            // 
            this.txtBarCode.Font = new System.Drawing.Font("Tahoma", 20F);
            this.txtBarCode.Location = new System.Drawing.Point(168, 28);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(297, 40);
            this.txtBarCode.TabIndex = 0;
            this.txtBarCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFirstScan_KeyPress);
            // 
            // labBarCode
            // 
            this.labBarCode.AutoSize = true;
            this.labBarCode.Font = new System.Drawing.Font("Tahoma", 20F);
            this.labBarCode.Location = new System.Drawing.Point(3, 31);
            this.labBarCode.Name = "labBarCode";
            this.labBarCode.Size = new System.Drawing.Size(133, 33);
            this.labBarCode.TabIndex = 39;
            this.labBarCode.Text = "过程条码:";
            // 
            // panelBox
            // 
            this.panelBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBox.Location = new System.Drawing.Point(0, 0);
            this.panelBox.Name = "panelBox";
            this.panelBox.Size = new System.Drawing.Size(1172, 656);
            this.panelBox.TabIndex = 41;
            // 
            // btnCollection
            // 
            this.btnCollection.AutoSize = true;
            this.btnCollection.BackColor = System.Drawing.Color.Transparent;
            this.btnCollection.CustomerInformation = "";
            this.btnCollection.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnCollection.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.btnCollection.Location = new System.Drawing.Point(530, 12);
            this.btnCollection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCollection.Name = "btnCollection";
            this.btnCollection.Size = new System.Drawing.Size(197, 75);
            this.btnCollection.TabIndex = 33;
            this.btnCollection.UIText = "参数监控";
            this.btnCollection.Click += new System.EventHandler(this.btnCollection_Click);
            // 
            // btnLogSystem
            // 
            this.btnLogSystem.BackColor = System.Drawing.Color.Transparent;
            this.btnLogSystem.CustomerInformation = "";
            this.btnLogSystem.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnLogSystem.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.btnLogSystem.Location = new System.Drawing.Point(1094, 12);
            this.btnLogSystem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogSystem.Name = "btnLogSystem";
            this.btnLogSystem.Size = new System.Drawing.Size(193, 75);
            this.btnLogSystem.TabIndex = 35;
            this.btnLogSystem.UIText = "日志系统";
            this.btnLogSystem.Click += new System.EventHandler(this.btnLogSystem_Click);
            // 
            // btnTraceSystem
            // 
            this.btnTraceSystem.AutoSize = true;
            this.btnTraceSystem.BackColor = System.Drawing.Color.Transparent;
            this.btnTraceSystem.CustomerInformation = "";
            this.btnTraceSystem.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnTraceSystem.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.btnTraceSystem.Location = new System.Drawing.Point(809, 12);
            this.btnTraceSystem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTraceSystem.Name = "btnTraceSystem";
            this.btnTraceSystem.Size = new System.Drawing.Size(193, 75);
            this.btnTraceSystem.TabIndex = 34;
            this.btnTraceSystem.UIText = "追溯系统";
            this.btnTraceSystem.Click += new System.EventHandler(this.btnTraceSystem_Click);
            // 
            // grbMonitorOnline
            // 
            this.grbMonitorOnline.Controls.Add(this.txtLwmCheck);
            this.grbMonitorOnline.Controls.Add(this.labLwmCheck);
            this.grbMonitorOnline.Controls.Add(this.lanternState);
            this.grbMonitorOnline.Controls.Add(this.txtCoaxility);
            this.grbMonitorOnline.Controls.Add(this.txtSurface);
            this.grbMonitorOnline.Controls.Add(this.labState);
            this.grbMonitorOnline.Controls.Add(this.labSurface);
            this.grbMonitorOnline.Controls.Add(this.labCoax);
            this.grbMonitorOnline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbMonitorOnline.Font = new System.Drawing.Font("Tahoma", 15F);
            this.grbMonitorOnline.Location = new System.Drawing.Point(0, 0);
            this.grbMonitorOnline.Name = "grbMonitorOnline";
            this.grbMonitorOnline.Size = new System.Drawing.Size(286, 656);
            this.grbMonitorOnline.TabIndex = 42;
            this.grbMonitorOnline.TabStop = false;
            this.grbMonitorOnline.Text = "实时监控";
            // 
            // txtLwmCheck
            // 
            this.txtLwmCheck.BackColor = System.Drawing.Color.Transparent;
            this.txtLwmCheck.CustomerInformation = "";
            this.txtLwmCheck.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.txtLwmCheck.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.txtLwmCheck.Location = new System.Drawing.Point(53, 354);
            this.txtLwmCheck.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.txtLwmCheck.Name = "txtLwmCheck";
            this.txtLwmCheck.Size = new System.Drawing.Size(178, 48);
            this.txtLwmCheck.TabIndex = 9;
            this.txtLwmCheck.UIText = "";
            // 
            // labLwmCheck
            // 
            this.labLwmCheck.AutoSize = true;
            this.labLwmCheck.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.labLwmCheck.Location = new System.Drawing.Point(87, 316);
            this.labLwmCheck.Name = "labLwmCheck";
            this.labLwmCheck.Size = new System.Drawing.Size(102, 24);
            this.labLwmCheck.TabIndex = 8;
            this.labLwmCheck.Text = "LWM检测";
            // 
            // lanternState
            // 
            this.lanternState.BackColor = System.Drawing.Color.Transparent;
            this.lanternState.LanternBackground = System.Drawing.Color.Gray;
            this.lanternState.Location = new System.Drawing.Point(75, 471);
            this.lanternState.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.lanternState.Name = "lanternState";
            this.lanternState.Size = new System.Drawing.Size(130, 130);
            this.lanternState.TabIndex = 1;
            // 
            // txtCoaxility
            // 
            this.txtCoaxility.BackColor = System.Drawing.Color.Transparent;
            this.txtCoaxility.CustomerInformation = "";
            this.txtCoaxility.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.txtCoaxility.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.txtCoaxility.Location = new System.Drawing.Point(53, 98);
            this.txtCoaxility.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.txtCoaxility.Name = "txtCoaxility";
            this.txtCoaxility.Size = new System.Drawing.Size(178, 48);
            this.txtCoaxility.TabIndex = 7;
            this.txtCoaxility.UIText = "0.000mm";
            this.txtCoaxility.Click += new System.EventHandler(this.txtCoaxility_Click);
            // 
            // txtSurface
            // 
            this.txtSurface.BackColor = System.Drawing.Color.Transparent;
            this.txtSurface.CustomerInformation = "";
            this.txtSurface.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.txtSurface.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.txtSurface.Location = new System.Drawing.Point(53, 227);
            this.txtSurface.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.txtSurface.Name = "txtSurface";
            this.txtSurface.Size = new System.Drawing.Size(178, 48);
            this.txtSurface.TabIndex = 7;
            this.txtSurface.UIText = "";
            // 
            // labState
            // 
            this.labState.AutoSize = true;
            this.labState.Location = new System.Drawing.Point(107, 433);
            this.labState.Name = "labState";
            this.labState.Size = new System.Drawing.Size(50, 24);
            this.labState.TabIndex = 2;
            this.labState.Text = "离线";
            // 
            // labSurface
            // 
            this.labSurface.AutoSize = true;
            this.labSurface.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.labSurface.Location = new System.Drawing.Point(90, 189);
            this.labSurface.Name = "labSurface";
            this.labSurface.Size = new System.Drawing.Size(94, 24);
            this.labSurface.TabIndex = 1;
            this.labSurface.Text = "焊缝质量";
            // 
            // labCoax
            // 
            this.labCoax.AutoSize = true;
            this.labCoax.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.labCoax.Location = new System.Drawing.Point(98, 58);
            this.labCoax.Name = "labCoax";
            this.labCoax.Size = new System.Drawing.Size(73, 24);
            this.labCoax.TabIndex = 0;
            this.labCoax.Text = "同心度";
            // 
            // panelParBox
            // 
            this.panelParBox.Controls.Add(this.panel3);
            this.panelParBox.Controls.Add(this.panel2);
            this.panelParBox.Controls.Add(this.panel1);
            this.panelParBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelParBox.Location = new System.Drawing.Point(0, 28);
            this.panelParBox.Name = "panelParBox";
            this.panelParBox.Size = new System.Drawing.Size(1458, 755);
            this.panelParBox.TabIndex = 43;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panelBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(286, 99);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1172, 656);
            this.panel3.TabIndex = 43;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grbMonitorOnline);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(286, 656);
            this.panel2.TabIndex = 42;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labBarCode);
            this.panel1.Controls.Add(this.txtBarCode);
            this.panel1.Controls.Add(this.btnTraceSystem);
            this.panel1.Controls.Add(this.btnCollection);
            this.panel1.Controls.Add(this.btnLogSystem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1458, 99);
            this.panel1.TabIndex = 0;
            // 
            // exeIcon
            // 
            this.exeIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("exeIcon.Icon")));
            this.exeIcon.Text = "notifyIcon1";
            this.exeIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // timerGC
            // 
            this.timerGC.Enabled = true;
            this.timerGC.Interval = 2000;
            this.timerGC.Tick += new System.EventHandler(this.timerGC_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1458, 812);
            this.Controls.Add(this.panelParBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HT 生产管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grbMonitorOnline.ResumeLayout(false);
            this.grbMonitorOnline.PerformLayout();
            this.panelParBox.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolLoginCenter;
        private System.Windows.Forms.ToolStripMenuItem toolProtectCenter;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolCurrentUser;
        private System.Windows.Forms.ToolStripStatusLabel toolTips;
        private HslCommunication.Controls.UserButton btnCollection;
        private HslCommunication.Controls.UserButton btnTraceSystem;
        private HslCommunication.Controls.UserButton btnLogSystem;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Label labBarCode;
        private System.Windows.Forms.Panel panelBox;
        private System.Windows.Forms.GroupBox grbMonitorOnline;
        private System.Windows.Forms.Label labCoax;
        private System.Windows.Forms.Label labSurface;
        private System.Windows.Forms.Label labState;
        private System.Windows.Forms.ToolStripMenuItem toolCancel;
        private System.Windows.Forms.ToolStripMenuItem toolLogin;
        private System.Windows.Forms.Panel panelParBox;
        private System.Windows.Forms.ToolStripMenuItem toolMuduleSet;
        private HslCommunication.Controls.UserButton txtSurface;
        private HslCommunication.Controls.UserButton txtCoaxility;
        private HslCommunication.Controls.UserLantern lanternState;
        private System.Windows.Forms.ToolStripMenuItem toolParamSetting;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolLanguage;
        private System.Windows.Forms.ToolStripMenuItem toolChinese;
        private System.Windows.Forms.ToolStripMenuItem toolEnglish;
        private System.Windows.Forms.ToolStripMenuItem 点检中心ToolStripMenuItem;
        private HslCommunication.Controls.UserButton txtLwmCheck;
        private System.Windows.Forms.Label labLwmCheck;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem toolSpotRecord;
        private System.Windows.Forms.NotifyIcon exeIcon;
        private System.Windows.Forms.Timer timerGC;
        private System.Windows.Forms.ToolStripMenuItem toolMachineState;
    }
}

