// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Seperator.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.Morphic
{
    public class MorphicSeparator : Control
    {
        private Graphics g;

        private Color _lineColor;
        private int _intensity = 40;

        public Color LineColor
        {
            get
            {
                return _lineColor;
            }
            set
            {
                _lineColor = value;
                Invalidate();
            }
        }

        public int Intensity
        {
            get
            {
                return _intensity;
            }
            set
            {
                _intensity = value;
                Invalidate();
            }
        }

        public MorphicSeparator()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            Size = new Size(260, 9);
            LineColor = Color.White;
        }

        protected override void CreateHandle()
        {
            Font = new Font(Preferences.FontFamily, Font.Size);
            base.CreateHandle();
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Parent.BackColor);

            Point p1 = new Point(0, (Height - 1) / 2);
            Point p2 = new Point(Width - 1, (Height - 1) / 2);

            ColorBlend lineBlend = new ColorBlend(3);
            lineBlend.Colors = new[] { Color.Transparent, Color.FromArgb(_intensity, _lineColor), Color.Transparent };
            lineBlend.Positions = new[] { 0.0F, 0.5F, 1.0F };

            LinearGradientBrush lineBrush = new LinearGradientBrush(p1, p2, Color.Transparent, Color.Transparent);
            lineBrush.InterpolationColors = lineBlend;

            g.DrawLine(new Pen(lineBrush), p1, p2);

        }

    }
}
