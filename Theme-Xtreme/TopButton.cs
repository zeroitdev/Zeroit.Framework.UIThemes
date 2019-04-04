// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TopButton.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Xtreme
{
    public class XtremeIncTopButton : ThemeControl154
    {
        public XtremeIncTopButton()
        {
            Transparent = true;
            BackColor = Color.Transparent;
        }

        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.Black);
            DrawBorders(Pens.Black);
            DrawBorders(new Pen(Color.FromArgb(69, 71, 70)), 1);
            DrawBorders(Pens.Black, 2);
            DrawGradient(Color.White, Color.FromArgb(69, 71, 70), 1, 1, Width / 2, 1, 360);
            DrawGradient(Color.White, Color.FromArgb(69, 71, 70), 1, 1, 1, Height / 2);
            G.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.White)), 0, 0, Width, 13);

            if (State == MouseState.Over)
            {
                DrawGradient(Color.FromArgb(98, 192, 255), Color.FromArgb(59, 144, 255), 0, 0, Width, Height);
                DrawBorders(new Pen(Color.FromArgb(0, 44, 190), 0));
                DrawBorders(new Pen(Color.FromArgb(84, 177, 255)), 1);
                DrawGradient(Color.White, Color.FromArgb(84, 177, 255), 1, 1, Width / 2, 1, 360);
                DrawGradient(Color.White, Color.FromArgb(84, 177, 255), 1, 1, 1, Height / 2);
                G.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.White)), 0, 0, Width, 13);
            }
            else if (State == MouseState.Down)
            {
                DrawGradient(Color.FromArgb(84, 182, 255), Color.FromArgb(45, 134, 255), 0, 0, Width, Height);
                DrawBorders(new Pen(Color.FromArgb(0, 44, 190), 0));
                DrawBorders(new Pen(Color.FromArgb(84, 177, 255)), 1);
                DrawGradient(Color.White, Color.FromArgb(84, 177, 255), 1, 1, Width / 2, 1, 360);
                DrawGradient(Color.White, Color.FromArgb(84, 177, 255), 1, 1, 1, Height / 2);
                G.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.White)), 0, 0, Width, 13);
            }
            else
            {
            }

            G.FillRectangle(new SolidBrush(Color.FromArgb(13, Color.White)), 3, 3, Width - 6, 8);
            DrawCorners(BackColor, 1);
        }
    }

}


