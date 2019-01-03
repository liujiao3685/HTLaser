//----------------------------------------------------------------------------- 
// <copyright file="OpenEthernetForm.cs" company="KEYENCE">
//	 Copyright (c) 2013 KEYENCE CORPORATION.  All rights reserved.
// </copyright>
//----------------------------------------------------------------------------- 

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MES.Vision
{
    public partial class OpenEthernetForm : Form
    {
        #region Field
        /// <summary>
        /// Ethernet communication settings
        /// </summary>
        private LJV7IF_ETHERNET_CONFIG _ethernetConfig;
        #endregion

        #region Property
        /// <summary>
        /// Ethernet communication settings
        /// </summary>
        public LJV7IF_ETHERNET_CONFIG EthernetConfig
        {
            get { return _ethernetConfig; }
            set
            {
                _ethernetConfig = value;
                if (_ethernetConfig.abyIpAddress != null)
                {
                    _txtboxIpFirstSegment.Text = _ethernetConfig.abyIpAddress[0].ToString();
                    _txtboxIpSecondSegment.Text = _ethernetConfig.abyIpAddress[1].ToString();
                    _txtboxIpThirdSegment.Text = _ethernetConfig.abyIpAddress[2].ToString();
                    _txtboxIpFourthSegment.Text = _ethernetConfig.abyIpAddress[3].ToString();
                }
                _txtboxPort.Text = _ethernetConfig.wPortNo.ToString();
            }
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
                    _ethernetConfig.abyIpAddress = new byte[]
                    {
                        Convert.ToByte(_txtboxIpFirstSegment.Text),
                        Convert.ToByte(_txtboxIpSecondSegment.Text),
                        Convert.ToByte(_txtboxIpThirdSegment.Text),
                        Convert.ToByte(_txtboxIpFourthSegment.Text)
                    };

                    //_ethernetConfig.abyIpAddress = new byte[] { 192, 168, 0, 66 };

                    _ethernetConfig.wPortNo = Convert.ToUInt16(_txtboxPort.Text);
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
        public OpenEthernetForm()
        {
            InitializeComponent();
            _ethernetConfig = new LJV7IF_ETHERNET_CONFIG();
        }

        /// <summary>
        /// Control display setting
        /// </summary>
        protected virtual void SetControlVisible(bool isVisible)
        {
            _lblDescription.Visible = isVisible;
            _lblIpAddress.Visible = isVisible;
            _txtboxIpFirstSegment.Visible = isVisible;
            _txtboxIpSecondSegment.Visible = isVisible;
            _txtboxIpThirdSegment.Visible = isVisible;
            _txtboxIpFourthSegment.Visible = isVisible;
            _lblPort.Visible = isVisible;
            _txtboxPort.Visible = isVisible;
        }
        #endregion

    }
}
