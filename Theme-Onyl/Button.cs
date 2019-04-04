// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
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
    public class OnylButton : Control
    {
        private ThemeModule.MouseState state;

        private SizeF textSize;
        private int textX;
        private int textY;

        public OnylButton()
        {

            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            Cursor = Cursors.Hand;
            Font = new Font(Font.FontFamily, 10);
            Size = new Size(120, 30);

            textBrush = new SolidBrush(Color.FromArgb(20, 60, 70));
            overBrush = new SolidBrush(Color.FromArgb(40, 0, 70, 90));
            downBrush = new SolidBrush(Color.FromArgb(100, 0, 70, 90));

        }

        private Rectangle boundsRect;

        private SolidBrush textBrush;
        private SolidBrush overBrush;
        private SolidBrush downBrush;

        protected override void OnPaint(PaintEventArgs e)
        {

            ThemeModule.g = e.Graphics;
            ThemeModule.g.SmoothingMode = SmoothingMode.AntiAlias;

            boundsRect = new Rectangle(0, 0, Width, Height);

            ThemeModule.g.FillRectangle(Brushes.WhiteSmoke, boundsRect);

            if (state == ThemeModule.MouseState.Over)
            {
                ThemeModule.g.FillRectangle(overBrush, boundsRect);
            }
            else if (state == ThemeModule.MouseState.Down)
            {
                ThemeModule.g.FillRectangle(downBrush, boundsRect);
            }

            ThemeModule.DrawCenteredString(ThemeModule.g, Text, Font, textBrush, boundsRect, 0, 1);

        }

        protected override void OnMouseEnter(EventArgs e)
        {
            state = ThemeModule.MouseState.Over;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            state = ThemeModule.MouseState.None;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            state = ThemeModule.MouseState.Down;
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            state = ThemeModule.MouseState.Over;
            Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

    }

}
