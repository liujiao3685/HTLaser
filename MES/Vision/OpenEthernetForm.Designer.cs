namespace MES.Vision
{
	partial class OpenEthernetForm
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
            this._lblIpAddress = new System.Windows.Forms.Label();
            this._txtboxIpFirstSegment = new System.Windows.Forms.TextBox();
            this._txtboxIpSecondSegment = new System.Windows.Forms.TextBox();
            this._txtboxIpThirdSegment = new System.Windows.Forms.TextBox();
            this._txtboxIpFourthSegment = new System.Windows.Forms.TextBox();
            this._lblPort = new System.Windows.Forms.Label();
            this._btnOk = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._txtboxPort = new System.Windows.Forms.TextBox();
            this._lblDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _lblIpAddress
            // 
            this._lblIpAddress.AutoSize = true;
            this._lblIpAddress.Location = new System.Drawing.Point(12, 40);
            this._lblIpAddress.Name = "_lblIpAddress";
            this._lblIpAddress.Size = new System.Drawing.Size(71, 17);
            this._lblIpAddress.TabIndex = 0;
            this._lblIpAddress.Text = "IP address";
            // 
            // _txtboxIpFirstSegment
            // 
            this._txtboxIpFirstSegment.Location = new System.Drawing.Point(81, 37);
            this._txtboxIpFirstSegment.Name = "_txtboxIpFirstSegment";
            this._txtboxIpFirstSegment.Size = new System.Drawing.Size(44, 24);
            this._txtboxIpFirstSegment.TabIndex = 1;
            this._txtboxIpFirstSegment.Text = "192";
            // 
            // _txtboxIpSecondSegment
            // 
            this._txtboxIpSecondSegment.Location = new System.Drawing.Point(131, 37);
            this._txtboxIpSecondSegment.Name = "_txtboxIpSecondSegment";
            this._txtboxIpSecondSegment.Size = new System.Drawing.Size(44, 24);
            this._txtboxIpSecondSegment.TabIndex = 2;
            this._txtboxIpSecondSegment.Text = "168";
            // 
            // _txtboxIpThirdSegment
            // 
            this._txtboxIpThirdSegment.Location = new System.Drawing.Point(181, 37);
            this._txtboxIpThirdSegment.Name = "_txtboxIpThirdSegment";
            this._txtboxIpThirdSegment.Size = new System.Drawing.Size(44, 24);
            this._txtboxIpThirdSegment.TabIndex = 3;
            this._txtboxIpThirdSegment.Text = "0";
            // 
            // _txtboxIpFourthSegment
            // 
            this._txtboxIpFourthSegment.Location = new System.Drawing.Point(231, 37);
            this._txtboxIpFourthSegment.Name = "_txtboxIpFourthSegment";
            this._txtboxIpFourthSegment.Size = new System.Drawing.Size(44, 24);
            this._txtboxIpFourthSegment.TabIndex = 4;
            this._txtboxIpFourthSegment.Text = "66";
            // 
            // _lblPort
            // 
            this._lblPort.AutoSize = true;
            this._lblPort.Location = new System.Drawing.Point(12, 74);
            this._lblPort.Name = "_lblPort";
            this._lblPort.Size = new System.Drawing.Size(34, 17);
            this._lblPort.TabIndex = 5;
            this._lblPort.Text = "Port";
            // 
            // _btnOk
            // 
            this._btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOk.Location = new System.Drawing.Point(231, 104);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(75, 25);
            this._btnOk.TabIndex = 6;
            this._btnOk.Text = "OK";
            this._btnOk.UseVisualStyleBackColor = true;
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(327, 104);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 25);
            this._btnCancel.TabIndex = 7;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _txtboxPort
            // 
            this._txtboxPort.Location = new System.Drawing.Point(81, 70);
            this._txtboxPort.Name = "_txtboxPort";
            this._txtboxPort.Size = new System.Drawing.Size(194, 24);
            this._txtboxPort.TabIndex = 8;
            this._txtboxPort.Text = "24691";
            // 
            // _lblDescription
            // 
            this._lblDescription.AutoSize = true;
            this._lblDescription.Location = new System.Drawing.Point(12, 10);
            this._lblDescription.Name = "_lblDescription";
            this._lblDescription.Size = new System.Drawing.Size(457, 17);
            this._lblDescription.TabIndex = 9;
            this._lblDescription.Text = "[Valid range] The IP address is a byte value and the port is a ushort value.";
            // 
            // OpenEthernetForm
            // 
            this.AcceptButton = this._btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(414, 142);
            this.Controls.Add(this._lblDescription);
            this.Controls.Add(this._txtboxPort);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this._lblPort);
            this.Controls.Add(this._txtboxIpFourthSegment);
            this.Controls.Add(this._txtboxIpThirdSegment);
            this.Controls.Add(this._txtboxIpSecondSegment);
            this.Controls.Add(this._txtboxIpFirstSegment);
            this.Controls.Add(this._lblIpAddress);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenEthernetForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Open Ethernet";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label _lblIpAddress;
		private System.Windows.Forms.TextBox _txtboxIpFirstSegment;
		private System.Windows.Forms.TextBox _txtboxIpSecondSegment;
		private System.Windows.Forms.TextBox _txtboxIpThirdSegment;
		private System.Windows.Forms.TextBox _txtboxIpFourthSegment;
		private System.Windows.Forms.Label _lblPort;
		private System.Windows.Forms.TextBox _txtboxPort;
		private System.Windows.Forms.Label _lblDescription;
		public System.Windows.Forms.Button _btnOk;
		public System.Windows.Forms.Button _btnCancel;
	}
}