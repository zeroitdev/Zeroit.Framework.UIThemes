// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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

namespace Zeroit.Framework.UIThemes.Xtreme
{
    public class XtremeIncButton : ThemeControl154
    {

        public XtremeIncButton()
        {
            Transparent = true;
            BackColor = Color.Transparent;
        }


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            DrawGradient(Color.FromArgb(25, 25, 25), Color.Black, 0, 0, Width, Height, 45);
            DrawText(Brushes.Red, HorizontalAlignment.Center, 0, 0);
            G.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.White)), 0, 0, Width, Height / 2);
            DrawBorders(Pens.Black);
            DrawBorders(new Pen(Color.FromArgb(69, 71, 70)), 1);
            DrawGradient(Color.White, Color.FromArgb(69, 71, 70), 1, 1, Width / 2, 1, 360);
            DrawGradient(Color.White, Color.FromArgb(69, 71, 70), 1, 1, 1, Height / 2);
            DrawGradient(Color.White, Color.FromArgb(69, 71, 70), Width - 2, 1, 1, Height / 2, 270);
            DrawGradient(Color.White, Color.FromArgb(69, 71, 70), Width - 2, Height / 2, 1, Height / 2);

            if (State == MouseState.Over)
            {
                DrawGradient(Color.FromArgb(98, 192, 255), Color.FromArgb(59, 144, 255), 0, 0, Width, Height, 45);
                DrawBorders(new Pen(Color.FromArgb(0, 44, 190), 0));
                DrawBorders(new Pen(Color.FromArgb(84, 177, 255)), 1);
                DrawGradient(Color.White, Color.FromArgb(84, 177, 255), 1, 1, Width / 2, 1, 360);
                DrawGradient(Color.White, Color.FromArgb(84, 177, 255), 1, 1, 1, Height / 2);
                DrawText(Brushes.Black, HorizontalAlignment.Center, 0, 0);
                G.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.White)), 0, 0, Width, 13);
                DrawCorners(BackColor, 1);
            }
            else if (State == MouseState.Down)
            {
                DrawGradient(Color.FromArgb(84, 182, 255), Color.FromArgb(45, 134, 255), 0, 0, Width, Height, 45);
                DrawBorders(new Pen(Color.FromArgb(0, 44, 190), 0));
                DrawBorders(new Pen(Color.FromArgb(84, 177, 255)), 1);
                DrawGradient(Color.White, Color.FromArgb(84, 177, 255), 1, 1, Width / 2, 1, 360);
                DrawGradient(Color.White, Color.FromArgb(84, 177, 255), 1, 1, 1, Height / 2);
                DrawText(Brushes.Black, HorizontalAlignment.Center, 0, 0);
                G.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.White)), 0, 0, Width, 13);
                DrawCorners(BackColor, 1);
            }
            else
            {
            }

            DrawCorners(BackColor, 1);
        }
    }

}


