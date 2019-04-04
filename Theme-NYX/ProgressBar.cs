// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.NYX
{
    public class NYXProgressBar : ThemeControl154
    {
        //Coded by HΛWK
        private int _Maximum = 100;
        private int _Value;

        private int Progress;
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 1)
                    value = 1;
                if (value < _Value)
                    _Value = value;
                _Maximum = value;
                Invalidate();
            }
        }
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum)
                    value = Maximum;
                _Value = value;
                Invalidate();
            }
        }

        public NYXProgressBar()
        {
            Size = new Size(200, 25);
        }

        protected override void ColorHook()
        {
        }

        //Coded by HΛWK
        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(22, 22, 22));
            //Background
            ColorBlend bg_cblend = new ColorBlend(3);
            bg_cblend.Colors[0] = Color.FromArgb(20, 20, 20);
            bg_cblend.Colors[1] = Color.FromArgb(15, 15, 15);
            bg_cblend.Colors[2] = Color.FromArgb(20, 20, 20);
            bg_cblend.Positions = new float[]{
            0,
            0.5f,
            1
        };
            DrawGradient(bg_cblend, new Rectangle(1, 1, Width - 2, Height - 2));
            //Bar
            ColorBlend bar_cblend = new ColorBlend(3);
            bar_cblend.Colors[0] = Color.FromArgb(210, 10, 10);
            bar_cblend.Colors[1] = Color.FromArgb(120, 10, 10);
            bar_cblend.Colors[2] = Color.FromArgb(165, 10, 10);
            bar_cblend.Positions = new float[]{
            0,
            0.5f,
            1
        };
            DrawGradient(bar_cblend, new Rectangle(1, 1, Convert.ToInt32(((Width / _Maximum) * _Value) - 2), Height - 2));
            //Border
            Point[] borderPoints = {
            new Point(0, 2),
            new Point(2, 0),
            new Point(Width - 3, 0),
            new Point(Width - 1, 2),
            new Point(Width - 1, Height - 3),
            new Point(Width - 3, Height - 1),
            new Point(2, Height - 1),
            new Point(0, Height - 3)
        };
            G.DrawPolygon(Pens.Black, borderPoints);
        }
    }


}

