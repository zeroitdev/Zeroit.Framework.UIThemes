﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ContextmenuStrip.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using static Zeroit.Framework.UIThemes.MetroDisk.Helpers;
using System.Drawing.Text;


namespace Zeroit.Framework.UIThemes.MetroDisk
{
    public class MetroDiskContextMenuStrip : ContextMenuStrip
    {
        private bool _LightTheme;
        public bool LightTheme
        {
            get { return _LightTheme; }
            set { _LightTheme = value; }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        public MetroDiskContextMenuStrip() : base()
        {
            Renderer = new ToolStripProfessionalRenderer(new TColorTable());
            ShowImageMargin = false;
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 8);
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            if (_LightTheme)
            {
            }
            base.OnPaint(e);
            e.Graphics.TextRenderingHint = (TextRenderingHint)5;
        }

        public class TColorTable : ProfessionalColorTable
        {

            #region " Properties"

            #region " Colors"

            [Category("Colors")]
            public Color _BackColor
            {
                get { return BackColor; }
                set { BackColor = value; }
            }

            [Category("Colors")]
            public Color _CheckedColor
            {
                get { return CheckedColor; }
                set { CheckedColor = value; }
            }

            [Category("Colors")]
            public Color _BorderColor
            {
                get { return BorderColor; }
                set { BorderColor = value; }
            }

            #endregion

            #endregion

            #region " Colors"

            private Color BackColor = Color.FromArgb(45, 47, 49);
            private Color CheckedColor = _FlatColor;

            private Color BorderColor = Color.FromArgb(53, 58, 60);
            #endregion

            #region " Overrides"

            public override Color ButtonSelectedBorder
            {
                get { return BackColor; }
            }
            public override Color CheckBackground
            {
                get { return CheckedColor; }
            }
            public override Color CheckPressedBackground
            {
                get { return CheckedColor; }
            }
            public override Color CheckSelectedBackground
            {
                get { return CheckedColor; }
            }
            public override Color ImageMarginGradientBegin
            {
                get { return CheckedColor; }
            }
            public override Color ImageMarginGradientEnd
            {
                get { return CheckedColor; }
            }
            public override Color ImageMarginGradientMiddle
            {
                get { return CheckedColor; }
            }
            public override Color MenuBorder
            {
                get { return BorderColor; }
            }
            public override Color MenuItemBorder
            {
                get { return BorderColor; }
            }
            public override Color MenuItemSelected
            {
                get { return CheckedColor; }
            }
            public override Color SeparatorDark
            {
                get { return BorderColor; }
            }
            public override Color ToolStripDropDownBackground
            {
                get { return BackColor; }
            }

            #endregion

        }

    }

}