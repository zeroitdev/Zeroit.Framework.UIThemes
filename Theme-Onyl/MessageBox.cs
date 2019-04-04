// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="MessageBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Onyl
{
    public class OnylMessageBox : Control
    {
        public OnylMessageBox()
        {

            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            Font = new Font(Font.FontFamily, 10);
            Size = new Size(400, 44);

            textBrush = new SolidBrush(Color.FromArgb(100, 140, 150));

        }

        private Rectangle boundsRect;

        private SolidBrush textBrush;

        protected override void OnPaint(PaintEventArgs e)
        {

            ThemeModule.g = e.Graphics;
            ThemeModule.g.Clear(Color.FromArgb(25, 90, 105));

            boundsRect = new Rectangle(0, 0, Width - 1, Height - 1);
            ThemeModule.DrawCenteredString(ThemeModule.g, Text, Font, textBrush, boundsRect, 0, 1);

        }

        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

    }

}
