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
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace Zeroit.Framework.UIThemes.Visible
{
    public class VIButton : ThemeControl154
    {
        protected override void ColorHook()
        {

        }
        public VIButton()
        {
            Size = new Size(75, 25);
        }
        protected override void PaintHook()
        {

            Pen P1 = new Pen(Color.FromArgb(16, 16, 16));
            G.FillRectangle(new HatchBrush(HatchStyle.Divot, Color.FromArgb(35, 35, 35), Color.FromArgb(15, 15, 15)), 0, 0, Width, Height);
            DrawBorders(Pens.Black);
            DrawBorders(P1, 1);
            DrawBorders(Pens.Black, 2);
            DrawCorners(Color.Transparent, 3);
            if (State == MouseState.Over)
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(25, 25, 25)), 3, 3, Width - 6, Height - 6);
                DrawBorders(new Pen(Color.FromArgb(0, 0, 0)), 2);
            }
            else if (State == MouseState.Down)
            {
                G.FillRectangle(new LinearGradientBrush(new Rectangle(3, 3, Width - 6, Height - 6), Color.FromArgb(12, 12, 12), Color.FromArgb(30, 30, 30), LinearGradientMode.BackwardDiagonal), 3, 3, Width - 6, Height - 6);
                DrawBorders(new Pen(Color.FromArgb(0, 0, 0)), 2);
            }
            else
            {
                G.FillRectangle(new HatchBrush(HatchStyle.Divot, Color.FromArgb(35, 35, 35), Color.FromArgb(15, 15, 15)), 0, 0, Width, Height);
                DrawBorders(Pens.Black);
                DrawBorders(P1, 1);
                DrawBorders(Pens.Black, 2);

            }
            if (State == MouseState.Down)
            {
                DrawText(Brushes.White, HorizontalAlignment.Center, 2, 2);
            }
            else
            {
                DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
            }
        }

    }
}


