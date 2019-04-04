// ***********************************************************************
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
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Booster
{
    public class BoosterButton : ThemeControl154
    {
        public BoosterButton()
        {
            Transparent = true;
            BackColor = Color.Transparent;
        }

        protected override void ColorHook()
        {
        }


        protected override void PaintHook()
        {
            DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(95, 0, 0), 0, 2, Width / 2, Height / 2, 45);
            DrawGradient(Color.FromArgb(95, 0, 0), Color.FromArgb(0, 0, 0), Width / 2, 2, Width - 15, Height / 2, -45);
            DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(95, 0, 0), 0, Height / 2, Width / 2, Height, 45);
            DrawGradient(Color.FromArgb(95, 0, 0), Color.FromArgb(0, 0, 0), Width / 2, Height / 2, Width, Height / 2, 315);


            DrawBorders(Pens.Black, 0);
            DrawBorders(Pens.Black, 1);
            DrawBorders(new Pen(Color.FromArgb(95, 0, 0)), 3);
            G.DrawLine(new Pen(Color.FromArgb(93, 93, 93)), 3, 3, Width - 5, 3);
            G.DrawLine(new Pen(Color.FromArgb(73, 73, 73)), 0, Height - 1, Width, Height - 1);
            DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(73, 73, 73), 0, 0, 1, Height);
            DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(73, 73, 73), Width - 1, 0, 1, Height);

            if (State == MouseState.Over)
            {
                DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(95, 0, 0), 0, 2, Width / 2, Height / 2, 45);
                DrawGradient(Color.FromArgb(95, 0, 0), Color.FromArgb(0, 0, 0), Width / 2, 2, Width - 15, Height / 2, -45);
                DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(95, 0, 0), 0, Height / 2, Width / 2, Height, 45);
                DrawGradient(Color.FromArgb(95, 0, 0), Color.FromArgb(0, 0, 0), Width / 2, Height / 2, Width, Height / 2, 315);
                G.FillRectangle(new SolidBrush(Color.FromArgb(13, Color.White)), 0, 0, Width, (Height / 2) - 7);
                DrawBorders(Pens.Black, 0);
                DrawBorders(Pens.Black, 1);
                DrawBorders(new Pen(Color.FromArgb(95, 0, 0)), 3);
                G.DrawLine(new Pen(Color.FromArgb(93, 93, 93)), 3, 3, Width - 5, 3);
                G.DrawLine(new Pen(Color.FromArgb(73, 73, 73)), 0, Height - 1, Width, Height - 1);
                DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(73, 73, 73), 0, 0, 1, Height);
                DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(73, 73, 73), Width - 1, 0, 1, Height);
            }
            else if (State == MouseState.Down)
            {
                DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(95, 0, 0), 0, 2, Width / 2, Height / 2, 45);
                DrawGradient(Color.FromArgb(95, 0, 0), Color.FromArgb(0, 0, 0), Width / 2, 2, Width - 15, Height / 2, -45);
                DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(95, 0, 0), 0, Height / 2, Width / 2, Height, 45);
                DrawGradient(Color.FromArgb(95, 0, 0), Color.FromArgb(0, 0, 0), Width / 2, Height / 2, Width, Height / 2, 315);
                G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.Black)), 0, 0, Width, (Height / 2) - 7);
                DrawBorders(Pens.Black, 0);
                DrawBorders(Pens.Black, 1);
                DrawBorders(new Pen(Color.FromArgb(95, 0, 0)), 3);
                G.DrawLine(new Pen(Color.FromArgb(93, 93, 93)), 3, 3, Width - 5, 3);
                G.DrawLine(new Pen(Color.FromArgb(73, 73, 73)), 0, Height - 1, Width, Height - 1);
                DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(73, 73, 73), 0, 0, 1, Height);
                DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(73, 73, 73), Width - 1, 0, 1, Height);
            }
            else
            {
            }

            DrawCorners(BackColor);
            DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);

        }
    }


}

