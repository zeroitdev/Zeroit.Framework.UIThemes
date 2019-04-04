// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Header.cs" company="Zeroit Dev Technologies">
//     Copyright � Zeroit Dev Technologies  2017. All Rights Reserved.
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
    #region  Header Label

    public class PlayUIHeaderLabel : Label
    {

        public PlayUIHeaderLabel()
        {
            Font = new Font("Arial", 9, FontStyle.Bold);
            ForeColor = Color.FromArgb(253, 254, 255);
            BackColor = Color.Transparent;
        }
    }

    #endregion
}