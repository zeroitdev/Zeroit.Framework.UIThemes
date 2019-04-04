// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ColorTable.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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

