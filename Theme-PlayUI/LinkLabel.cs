// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="LinkLabel.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region  Imports

using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Drawing.Drawing2D;
    using System.ComponentModel;
	
#endregion
	
	

namespace Zeroit.Framework.UIThemes.PlayUI
{
    #region  Link Label
    public class PlayUILinkLabel : LinkLabel
    {

        public PlayUILinkLabel()
        {
            Font = new Font("Arial", 8, FontStyle.Regular);
            BackColor = Color.Transparent;
            LinkColor = Color.FromArgb(115, 118, 125);
            ActiveLinkColor = Color.FromArgb(103, 105, 112);
            VisitedLinkColor = Color.FromArgb(115, 118, 125);
            LinkBehavior = LinkBehavior.NeverUnderline;
        }
    }

    #endregion
}