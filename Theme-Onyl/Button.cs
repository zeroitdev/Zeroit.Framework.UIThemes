// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
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
