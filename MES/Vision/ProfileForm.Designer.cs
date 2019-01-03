namespace MES.Vision
{
	partial class ProfileForm
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
			this._txtboxTargetBank = new System.Windows.Forms.TextBox();
			this._lblTargetBank = new System.Windows.Forms.Label();
			this._txtboxPosMode = new System.Windows.Forms.TextBox();
			this._lblPosMode = new System.Windows.Forms.Label();
			this._txtboxGetProfNo = new System.Windows.Forms.TextBox();
			this._lblGetProfNo = new System.Windows.Forms.Label();
			this._txtboxGetProfCount = new System.Windows.Forms.TextBox();
			this._lblGetProfCount = new System.Windows.Forms.Label();
			this._btnCancel = new System.Windows.Forms.Button();
			this._btnOk = new System.Windows.Forms.Button();
			this._lblTargetBankDescription = new System.Windows.Forms.Label();
			this._txtboxPosModeDescription = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this._txtboxErase = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this._lblProfileDescription = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// _txtboxTargetBank
			// 
			this._txtboxTargetBank.Location = new System.Drawing.Point(18, 51);
			this._txtboxTargetBank.Name = "_txtboxTargetBank";
			this._txtboxTargetBank.Size = new System.Drawing.Size(69, 21);
			this._txtboxTargetBank.TabIndex = 0;
			this._txtboxTargetBank.Text = "00";
			// 
			// _lblTargetBank
			// 
			this._lblTargetBank.AutoSize = true;
			this._lblTargetBank.Location = new System.Drawing.Point(93, 54);
			this._lblTargetBank.Name = "_lblTargetBank";
			this._lblTargetBank.Size = new System.Drawing.Size(145, 13);
			this._lblTargetBank.TabIndex = 29;
			this._lblTargetBank.Text = "Get profile bank specification";
			// 
			// _txtboxPosMode
			// 
			this._txtboxPosMode.Location = new System.Drawing.Point(18, 115);
			this._txtboxPosMode.Name = "_txtboxPosMode";
			this._txtboxPosMode.Size = new System.Drawing.Size(69, 21);
			this._txtboxPosMode.TabIndex = 1;
			this._txtboxPosMode.Text = "00";
			// 
			// _lblPosMode
			// 
			this._lblPosMode.AutoSize = true;
			this._lblPosMode.Location = new System.Drawing.Point(93, 118);
			this._lblPosMode.Name = "_lblPosMode";
			this._lblPosMode.Size = new System.Drawing.Size(198, 13);
			this._lblPosMode.TabIndex = 31;
			this._lblPosMode.Text = "Get profile position specification method";
			// 
			// _txtboxGetProfNo
			// 
			this._txtboxGetProfNo.Location = new System.Drawing.Point(18, 189);
			this._txtboxGetProfNo.Name = "_txtboxGetProfNo";
			this._txtboxGetProfNo.Size = new System.Drawing.Size(69, 21);
			this._txtboxGetProfNo.TabIndex = 2;
			this._txtboxGetProfNo.Text = "0";
			// 
			// _lblGetProfNo
			// 
			this._lblGetProfNo.AutoSize = true;
			this._lblGetProfNo.Location = new System.Drawing.Point(93, 192);
			this._lblGetProfNo.Name = "_lblGetProfNo";
			this._lblGetProfNo.Size = new System.Drawing.Size(321, 13);
			this._lblGetProfNo.TabIndex = 33;
			this._lblGetProfNo.Text = "From what number profile do you want to start acquiring profiles?";
			// 
			// _txtboxGetProfCount
			// 
			this._txtboxGetProfCount.Location = new System.Drawing.Point(18, 251);
			this._txtboxGetProfCount.Name = "_txtboxGetProfCount";
			this._txtboxGetProfCount.Size = new System.Drawing.Size(69, 21);
			this._txtboxGetProfCount.TabIndex = 3;
			this._txtboxGetProfCount.Text = "1";
			// 
			// _lblGetProfCount
			// 
			this._lblGetProfCount.AutoSize = true;
			this._lblGetProfCount.Location = new System.Drawing.Point(93, 255);
			this._lblGetProfCount.Name = "_lblGetProfCount";
			this._lblGetProfCount.Size = new System.Drawing.Size(233, 13);
			this._lblGetProfCount.TabIndex = 35;
			this._lblGetProfCount.Text = "Number of profiles to request the acquisition of";
			// 
			// _btnCancel
			// 
			this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btnCancel.Location = new System.Drawing.Point(363, 349);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(75, 25);
			this._btnCancel.TabIndex = 6;
			this._btnCancel.Text = "Cancel";
			this._btnCancel.UseVisualStyleBackColor = true;
			// 
			// _btnOk
			// 
			this._btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._btnOk.Location = new System.Drawing.Point(267, 349);
			this._btnOk.Name = "_btnOk";
			this._btnOk.Size = new System.Drawing.Size(75, 25);
			this._btnOk.TabIndex = 5;
			this._btnOk.Text = "OK";
			this._btnOk.UseVisualStyleBackColor = true;
			// 
			// _lblTargetBankDescription
			// 
			this._lblTargetBankDescription.AutoSize = true;
			this._lblTargetBankDescription.Location = new System.Drawing.Point(20, 75);
			this._lblTargetBankDescription.Name = "_lblTargetBankDescription";
			this._lblTargetBankDescription.Size = new System.Drawing.Size(116, 26);
			this._lblTargetBankDescription.TabIndex = 44;
			this._lblTargetBankDescription.Text = "0x00: Active surface\r\n0x01: Inactive surface";
			// 
			// _txtboxPosModeDescription
			// 
			this._txtboxPosModeDescription.AutoSize = true;
			this._txtboxPosModeDescription.Location = new System.Drawing.Point(20, 139);
			this._txtboxPosModeDescription.Name = "_txtboxPosModeDescription";
			this._txtboxPosModeDescription.Size = new System.Drawing.Size(113, 39);
			this._txtboxPosModeDescription.TabIndex = 45;
			this._txtboxPosModeDescription.Text = "0x00: From current\r\n0x01: From oldest\r\n0x02: Specify position";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 212);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(323, 26);
			this.label1.TabIndex = 46;
			this.label1.Text = "When the profile position specification is [0x02: Specify position], \r\nspecify th" +
				"e number of the profile to get.";
			// 
			// _txtboxErase
			// 
			this._txtboxErase.Location = new System.Drawing.Point(18, 289);
			this._txtboxErase.Name = "_txtboxErase";
			this._txtboxErase.Size = new System.Drawing.Size(69, 21);
			this._txtboxErase.TabIndex = 4;
			this._txtboxErase.Text = "0";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(93, 293);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(138, 13);
			this.label2.TabIndex = 48;
			this.label2.Text = "Already read indication flag";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 313);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(397, 13);
			this.label3.TabIndex = 49;
			this.label3.Text = "0: Do not erase the profiles that were read. 1: Erase the profiles that were read" +
				".";
			// 
			// _lblProfileDescription
			// 
			this._lblProfileDescription.AutoSize = true;
			this._lblProfileDescription.Location = new System.Drawing.Point(16, 10);
			this._lblProfileDescription.Name = "_lblProfileDescription";
			this._lblProfileDescription.Size = new System.Drawing.Size(395, 26);
			this._lblProfileDescription.TabIndex = 50;
			this._lblProfileDescription.Text = "From what number profile do you want to start acquiring profiles : ushort format " +
				"\r\nother than that above : byte format";
			// 
			// ProfileForm
			// 
			this.AcceptButton = this._btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this._btnCancel;
			this.ClientSize = new System.Drawing.Size(471, 387);
			this.Controls.Add(this._lblProfileDescription);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this._txtboxErase);
			this.Controls.Add(this.label1);
			this.Controls.Add(this._txtboxPosModeDescription);
			this.Controls.Add(this._lblTargetBankDescription);
			this.Controls.Add(this._btnCancel);
			this.Controls.Add(this._btnOk);
			this.Controls.Add(this._txtboxGetProfCount);
			this.Controls.Add(this._lblGetProfCount);
			this.Controls.Add(this._txtboxGetProfNo);
			this.Controls.Add(this._lblGetProfNo);
			this.Controls.Add(this._txtboxPosMode);
			this.Controls.Add(this._lblPosMode);
			this.Controls.Add(this._txtboxTargetBank);
			this.Controls.Add(this._lblTargetBank);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProfileForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Read the profile.";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox _txtboxTargetBank;
		private System.Windows.Forms.Label _lblTargetBank;
		private System.Windows.Forms.TextBox _txtboxPosMode;
		private System.Windows.Forms.Label _lblPosMode;
		private System.Windows.Forms.TextBox _txtboxGetProfNo;
		private System.Windows.Forms.Label _lblGetProfNo;
		private System.Windows.Forms.TextBox _txtboxGetProfCount;
		private System.Windows.Forms.Label _lblGetProfCount;
		private System.Windows.Forms.Button _btnCancel;
		private System.Windows.Forms.Button _btnOk;
		private System.Windows.Forms.Label _lblTargetBankDescription;
		private System.Windows.Forms.Label _txtboxPosModeDescription;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox _txtboxErase;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label _lblProfileDescription;
	}
}