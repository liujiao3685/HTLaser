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
            this.登录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.登录ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.注销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.维护中心ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.模板配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolCurrentUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTips = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtFirstScan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelBox = new System.Windows.Forms.Panel();
            this.btnCollection = new HslCommunication.Controls.UserButton();
            this.btnLogSystem = new HslCommunication.Controls.UserButton();
            this.btnTraceSystem = new HslCommunication.Controls.UserButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStateChange = new HslCommunication.Controls.UserButton();
            this.labSurface = new System.Windows.Forms.Label();
            this.labCoaxility = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelParBox = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelParBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.登录ToolStripMenuItem,
            this.维护中心ToolStripMenuItem,
            this.visionToolStripMenuItem,
            this.模板配置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1326, 33);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 登录ToolStripMenuItem
            // 
            this.登录ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.登录ToolStripMenuItem1,
            this.注销ToolStripMenuItem});
            this.登录ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.登录ToolStripMenuItem.Name = "登录ToolStripMenuItem";
            this.登录ToolStripMenuItem.Size = new System.Drawing.Size(100, 29);
            this.登录ToolStripMenuItem.Text = "&用户中心";
            // 
            // 登录ToolStripMenuItem1
            // 
            this.登录ToolStripMenuItem1.Name = "登录ToolStripMenuItem1";
            this.登录ToolStripMenuItem1.Size = new System.Drawing.Size(128, 30);
            this.登录ToolStripMenuItem1.Text = "&登录";
            this.登录ToolStripMenuItem1.Click += new System.EventHandler(this.登录ToolStripMenuItem1_Click);
            // 
            // 注销ToolStripMenuItem
            // 
            this.注销ToolStripMenuItem.Name = "注销ToolStripMenuItem";
            this.注销ToolStripMenuItem.Size = new System.Drawing.Size(128, 30);
            this.注销ToolStripMenuItem.Text = "&注销";
            this.注销ToolStripMenuItem.Click += new System.EventHandler(this.注销ToolStripMenuItem_Click);
            // 
            // 维护中心ToolStripMenuItem
            // 
            this.维护中心ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.维护中心ToolStripMenuItem.Name = "维护中心ToolStripMenuItem";
            this.维护中心ToolStripMenuItem.Size = new System.Drawing.Size(100, 29);
            this.维护中心ToolStripMenuItem.Text = "&维护中心";
            this.维护中心ToolStripMenuItem.Click += new System.EventHandler(this.维护中心ToolStripMenuItem_Click);
            // 
            // visionToolStripMenuItem
            // 
            this.visionToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.visionToolStripMenuItem.Name = "visionToolStripMenuItem";
            this.visionToolStripMenuItem.Size = new System.Drawing.Size(80, 29);
            this.visionToolStripMenuItem.Text = "&Vision";
            this.visionToolStripMenuItem.Click += new System.EventHandler(this.visionToolStripMenuItem_Click);
            // 
            // 模板配置ToolStripMenuItem
            // 
            this.模板配置ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.模板配置ToolStripMenuItem.Name = "模板配置ToolStripMenuItem";
            this.模板配置ToolStripMenuItem.Size = new System.Drawing.Size(100, 29);
            this.模板配置ToolStripMenuItem.Text = "&模板配置";
            this.模板配置ToolStripMenuItem.Click += new System.EventHandler(this.模板配置ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.statusStrip1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolCurrentUser,
            this.toolTips});
            this.statusStrip1.Location = new System.Drawing.Point(0, 768);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1326, 35);
            this.statusStrip1.TabIndex = 31;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolCurrentUser
            // 
            this.toolCurrentUser.BackColor = System.Drawing.Color.Tomato;
            this.toolCurrentUser.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.toolCurrentUser.Name = "toolCurrentUser";
            this.toolCurrentUser.Size = new System.Drawing.Size(143, 30);
            this.toolCurrentUser.Text = "当前用户：";
            // 
            // toolTips
            // 
            this.toolTips.BackColor = System.Drawing.SystemColors.Control;
            this.toolTips.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.toolTips.Name = "toolTips";
            this.toolTips.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolTips.Size = new System.Drawing.Size(1168, 30);
            this.toolTips.Spring = true;
            this.toolTips.Text = "提示：";
            this.toolTips.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFirstScan
            // 
            this.txtFirstScan.Font = new System.Drawing.Font("Tahoma", 20F);
            this.txtFirstScan.Location = new System.Drawing.Point(131, 30);
            this.txtFirstScan.Name = "txtFirstScan";
            this.txtFirstScan.Size = new System.Drawing.Size(297, 48);
            this.txtFirstScan.TabIndex = 0;
            this.txtFirstScan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFirstScan_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20F);
            this.label1.Location = new System.Drawing.Point(27, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 41);
            this.label1.TabIndex = 39;
            this.label1.Text = "条码:";
            // 
            // panelBox
            // 
            this.panelBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelBox.Location = new System.Drawing.Point(307, 105);
            this.panelBox.Name = "panelBox";
            this.panelBox.Size = new System.Drawing.Size(1016, 629);
            this.panelBox.TabIndex = 41;
            // 
            // btnCollection
            // 
            this.btnCollection.AutoSize = true;
            this.btnCollection.BackColor = System.Drawing.Color.Transparent;
            this.btnCollection.CustomerInformation = "";
            this.btnCollection.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnCollection.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.btnCollection.Location = new System.Drawing.Point(488, 15);
            this.btnCollection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCollection.Name = "btnCollection";
            this.btnCollection.Size = new System.Drawing.Size(193, 75);
            this.btnCollection.TabIndex = 33;
            this.btnCollection.UIText = "数据采集";
            this.btnCollection.Click += new System.EventHandler(this.btnCollection_Click);
            // 
            // btnLogSystem
            // 
            this.btnLogSystem.BackColor = System.Drawing.Color.Transparent;
            this.btnLogSystem.CustomerInformation = "";
            this.btnLogSystem.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnLogSystem.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.btnLogSystem.Location = new System.Drawing.Point(1072, 15);
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
            this.btnTraceSystem.Location = new System.Drawing.Point(787, 15);
            this.btnTraceSystem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTraceSystem.Name = "btnTraceSystem";
            this.btnTraceSystem.Size = new System.Drawing.Size(193, 75);
            this.btnTraceSystem.TabIndex = 34;
            this.btnTraceSystem.UIText = "追溯系统";
            this.btnTraceSystem.Click += new System.EventHandler(this.btnTraceSystem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStateChange);
            this.groupBox1.Controls.Add(this.labSurface);
            this.groupBox1.Controls.Add(this.labCoaxility);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.groupBox1.Location = new System.Drawing.Point(1, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 641);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "实时监控";
            // 
            // btnStateChange
            // 
            this.btnStateChange.BackColor = System.Drawing.Color.Transparent;
            this.btnStateChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnStateChange.CustomerInformation = "";
            this.btnStateChange.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.btnStateChange.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.btnStateChange.Location = new System.Drawing.Point(46, 455);
            this.btnStateChange.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.btnStateChange.Name = "btnStateChange";
            this.btnStateChange.OriginalColor = System.Drawing.Color.Gray;
            this.btnStateChange.Size = new System.Drawing.Size(199, 66);
            this.btnStateChange.TabIndex = 5;
            this.btnStateChange.UIText = "离线";
            this.btnStateChange.Click += new System.EventHandler(this.btnStateChange_Click);
            // 
            // labSurface
            // 
            this.labSurface.AutoSize = true;
            this.labSurface.Location = new System.Drawing.Point(121, 284);
            this.labSurface.Name = "labSurface";
            this.labSurface.Size = new System.Drawing.Size(45, 30);
            this.labSurface.TabIndex = 4;
            this.labSurface.Text = "    ";
            // 
            // labCoaxility
            // 
            this.labCoaxility.AutoSize = true;
            this.labCoaxility.Location = new System.Drawing.Point(121, 129);
            this.labCoaxility.Name = "labCoaxility";
            this.labCoaxility.Size = new System.Drawing.Size(45, 30);
            this.labCoaxility.TabIndex = 3;
            this.labCoaxility.Text = "    ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 404);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 30);
            this.label4.TabIndex = 2;
            this.label4.Text = "设备状态";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "表面质量";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "同心度";
            // 
            // panelParBox
            // 
            this.panelParBox.Controls.Add(this.label1);
            this.panelParBox.Controls.Add(this.groupBox1);
            this.panelParBox.Controls.Add(this.btnTraceSystem);
            this.panelParBox.Controls.Add(this.btnLogSystem);
            this.panelParBox.Controls.Add(this.panelBox);
            this.panelParBox.Controls.Add(this.btnCollection);
            this.panelParBox.Controls.Add(this.txtFirstScan);
            this.panelParBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelParBox.Location = new System.Drawing.Point(0, 33);
            this.panelParBox.Name = "panelParBox";
            this.panelParBox.Size = new System.Drawing.Size(1326, 735);
            this.panelParBox.TabIndex = 43;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1326, 803);
            this.Controls.Add(this.panelParBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MES生产管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelParBox.ResumeLayout(false);
            this.panelParBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 登录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 维护中心ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolCurrentUser;
        private System.Windows.Forms.ToolStripStatusLabel toolTips;
        private HslCommunication.Controls.UserButton btnCollection;
        private HslCommunication.Controls.UserButton btnTraceSystem;
        private HslCommunication.Controls.UserButton btnLogSystem;
        private System.Windows.Forms.TextBox txtFirstScan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelBox;
        private System.Windows.Forms.ToolStripMenuItem visionToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labCoaxility;
        private HslCommunication.Controls.UserButton btnStateChange;
        private System.Windows.Forms.Label labSurface;
        private System.Windows.Forms.ToolStripMenuItem 注销ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 登录ToolStripMenuItem1;
        private System.Windows.Forms.Panel panelParBox;
        private System.Windows.Forms.ToolStripMenuItem 模板配置ToolStripMenuItem;
    }
}

