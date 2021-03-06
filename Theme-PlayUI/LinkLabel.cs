// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="LinkLabel.cs" company="Zeroit Dev Technologies">
//    This program is for creating Theme controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
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