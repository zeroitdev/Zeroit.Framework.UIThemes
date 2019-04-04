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
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Login
{

    public class LogInColourTable : ProfessionalColorTable
    {

        #region "Declarations"

        private Color _BackColour = Color.FromArgb(42, 42, 42);
        private Color _BorderColour = Color.FromArgb(35, 35, 35);

        private Color _SelectedColour = Color.FromArgb(47, 47, 47);
        #endregion

        #region "Properties"

        [Category("Colours")]
        public Color SelectedColour
        {
            get { return _SelectedColour; }
            set { _SelectedColour = value; }
        }

        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }

        [Category("Colours")]
        public Color BackColour
        {
            get { return _BackColour; }
            set { _BackColour = value; }
        }

        public override Color ButtonSelectedBorder
        {
            get { return _BackColour; }
        }

        public override Color CheckBackground
        {
            get { return _BackColour; }
        }

        public override Color CheckPressedBackground
        {
            get { return _BackColour; }
        }

        public override Color CheckSelectedBackground
        {
            get { return _BackColour; }
        }

        public override Color ImageMarginGradientBegin
        {
            get { return _BackColour; }
        }

        public override Color ImageMarginGradientEnd
        {
            get { return _BackColour; }
        }

        public override Color ImageMarginGradientMiddle
        {
            get { return _BackColour; }
        }

        public override Color MenuBorder
        {
            get { return _BorderColour; }
        }

        public override Color MenuItemBorder
        {
            get { return _BackColour; }
        }

        public override Color MenuItemSelected
        {
            get { return _SelectedColour; }
        }

        public override Color SeparatorDark
        {
            get { return _BorderColour; }
        }

        public override Color ToolStripDropDownBackground
        {
            get { return _BackColour; }
        }

        #endregion

    }

}


