// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Label.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Login
{

    public class LogInLabel : Label
    {

        #region "Declaration"
        #endregion
        private Color _FontColour = Color.FromArgb(255, 255, 255);

        #region "Property & Event"

        [Category("Colours")]
        public Color FontColour
        {
            get { return _FontColour; }
            set { _FontColour = value; }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        #endregion

        #region "Draw Control"

        public LogInLabel()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            Font = new Font("Segoe UI", 9);
            ForeColor = _FontColour;
            BackColor = Color.Transparent;
            Text = Text;
        }

        #endregion

    }

}


