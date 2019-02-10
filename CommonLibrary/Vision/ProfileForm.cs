//----------------------------------------------------------------------------- 
// <copyright file="ProfileForm.cs" company="KEYENCE">
//	 Copyright (c) 2013 KEYENCE CORPORATION.  All rights reserved.
// </copyright>
//----------------------------------------------------------------------------- 

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CommonLibrary.Vision
{
	public partial class ProfileForm : Form
	{
		#region Field
		/// <summary>
		/// Specify the position, etc., of the profiles to get.
		/// </summary>
		private LJV7IF_GET_PROFILE_REQ _req;
		#endregion

		#region Property
		/// <summary>
		/// Specify the position, etc., of the profiles to get.
		/// </summary>
		public LJV7IF_GET_PROFILE_REQ Req
		{
			get { return _req; }
		}
		#endregion

		#region Event

		/// <summary>
		/// Close start event
		/// </summary>
		/// <param name="e"></param>
		protected override void OnClosing(CancelEventArgs e)
		{
			if (DialogResult == DialogResult.OK)
			{
				try
				{
					_req.byTargetBank = Convert.ToByte(_txtboxTargetBank.Text, 16);
					_req.byPosMode = Convert.ToByte(_txtboxPosMode.Text, 16);
					_req.dwGetProfNo = Convert.ToUInt16(_txtboxGetProfNo.Text);
					_req.byGetProfCnt = Convert.ToByte(_txtboxGetProfCount.Text);
					_req.byErase = Convert.ToByte(_txtboxErase.Text);
				}
				catch (Exception ex)
				{
					MessageBox.Show(this, ex.Message);
					e.Cancel = true;
					return;
				}
			}

			base.OnClosing(e);
		}
		#endregion

		#region Method
		/// <summary>
		/// Constructor
		/// </summary>
		public ProfileForm()
		{
			InitializeComponent();

			// Field initialization
			_req = new LJV7IF_GET_PROFILE_REQ();
		}
		#endregion
	}
}
