﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ColorTable.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.SLC
{
    #region "SCLCT"

    public class SLCColorTable : ProfessionalColorTable
    {


        private Color BackColor = Color.White;
        public override Color ButtonSelectedBorder
        {
            get { return BackColor; }
        }

        public override Color CheckBackground
        {
            get { return BackColor; }
        }

        public override Color CheckPressedBackground
        {
            get { return BackColor; }
        }

        public override Color CheckSelectedBackground
        {
            get { return BackColor; }
        }

        public override Color ImageMarginGradientBegin
        {
            get { return BackColor; }
        }

        public override Color ImageMarginGradientEnd
        {
            get { return BackColor; }
        }

        public override Color ImageMarginGradientMiddle
        {
            get { return BackColor; }
        }

        public override Color MenuBorder
        {
            get { return Color.FromArgb(1, 75, 124); }
        }

        public override Color MenuItemBorder
        {
            get { return BackColor; }
        }

        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(50, Color.LightGray); }
        }

        public override Color SeparatorDark
        {
            get { return Color.FromArgb(35, 35, 35); }
        }

        public override Color ToolStripDropDownBackground
        {
            get { return BackColor; }
        }

    }
    #endregion

}

