﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Butter
{
    public class BambaraButton : Control
    {
        MouseState _state;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _state = MouseState.Down;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _state = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _state = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _state = MouseState.None;
            Invalidate();
        }

        public BambaraButton()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Size = new Size(160, 35);
            _state = MouseState.None;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle innerrect = new Rectangle(3, 3, Width - 7, Height - 7);
            Font btnfont = new Font("Verdana", 10, FontStyle.Regular);
            base.OnPaint(e);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.Clear(BackColor);
            LinearGradientBrush buttonrect = new LinearGradientBrush(rect, Color.FromArgb(100, 90, 80), Color.FromArgb(48, 43, 39), LinearGradientMode.Vertical);
            g.FillPath(new SolidBrush(Color.FromArgb(26, 25, 21)), Draw.RoundRect(rect, 3));
            g.FillPath(buttonrect, Draw.RoundRect(innerrect, 3));
            switch (_state)
            {
                case MouseState.None:
                    LinearGradientBrush buttonrectnone = new LinearGradientBrush(innerrect, Color.FromArgb(100, 90, 80), Color.FromArgb(48, 43, 39), LinearGradientMode.Vertical);
                    g.FillPath(new SolidBrush(Color.FromArgb(26, 25, 21)), Draw.RoundRect(rect, 3));
                    g.FillPath(buttonrectnone, Draw.RoundRect(innerrect, 3));
                    g.DrawString(Text, btnfont, Brushes.White, innerrect, new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Down:
                    LinearGradientBrush buttonrectdown = new LinearGradientBrush(innerrect, Color.FromArgb(48, 43, 39), Color.FromArgb(100, 90, 80), LinearGradientMode.Vertical);
                    g.FillPath(new SolidBrush(Color.FromArgb(26, 25, 21)), Draw.RoundRect(rect, 3));
                    g.FillPath(buttonrectdown, Draw.RoundRect(innerrect, 3));
                    g.DrawString(Text, btnfont, Brushes.White, innerrect, new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Over:
                    LinearGradientBrush buttonrectover = new LinearGradientBrush(innerrect, Color.FromArgb(48, 43, 39), Color.FromArgb(100, 90, 80), LinearGradientMode.Vertical);
                    g.FillPath(new SolidBrush(Color.FromArgb(26, 25, 21)), Draw.RoundRect(rect, 3));
                    g.FillPath(buttonrectover, Draw.RoundRect(innerrect, 3));
                    g.DrawString(Text, btnfont, Brushes.White, innerrect, new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
            }
            e.Graphics.DrawImage(b, new Point(0, 0));
            g.Dispose();
            b.Dispose();
        }
    }


}
