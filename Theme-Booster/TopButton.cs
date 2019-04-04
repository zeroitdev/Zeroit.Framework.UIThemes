// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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

namespace Zeroit.Framework.UIThemes.Booster
{
    public class BoosterTopButton : ThemeControl154
    {
        public BoosterTopButton()
        {
            Transparent = true;
            BackColor = Color.Transparent;
        }

        protected override void ColorHook()
        {
        }


        protected override void PaintHook()
        {
            DrawGradient(Color.FromArgb(141, 141, 141), Color.FromArgb(23, 23, 23), 0, 0, Width, Height, 45);
            DrawBorders(new Pen(Color.FromArgb(41, 41, 41)), 0);
            DrawBorders(new Pen(Color.FromArgb(41, 41, 41)), 1);
            DrawBorders(Pens.Black, 2);
            G.DrawLine(new Pen(Color.FromArgb(100, 100, 100)), 0, Height - 1, Width, Height - 1);
            DrawGradient(Color.FromArgb(41, 41, 41), Color.FromArgb(100, 100, 100), 0, 0, 1, Height);
            DrawGradient(Color.FromArgb(41, 41, 41), Color.FromArgb(100, 100, 100), Width - 1, 0, Width, Height);
            DrawCorners(BackColor);
            DrawCorners(Color.FromArgb(41, 41, 41), 2);

            if (State == MouseState.Over)
            {
                DrawGradient(Color.FromArgb(255, 255, 255), Color.FromArgb(23, 23, 23), 0, 0, Width, Height, 45);
                DrawBorders(new Pen(Color.FromArgb(41, 41, 41)), 0);
                DrawBorders(new Pen(Color.FromArgb(41, 41, 41)), 1);
                DrawBorders(Pens.Black, 2);
                G.DrawLine(new Pen(Color.FromArgb(100, 100, 100)), 0, Height - 1, Width, Height - 1);
                DrawGradient(Color.FromArgb(41, 41, 41), Color.FromArgb(100, 100, 100), 0, 0, 1, Height);
                DrawGradient(Color.FromArgb(41, 41, 41), Color.FromArgb(100, 100, 100), Width - 1, 0, Width, Height);
                DrawCorners(BackColor);
                DrawCorners(Color.FromArgb(41, 41, 41), 2);
            }
            else if (State == MouseState.Down)
            {
                DrawGradient(Color.FromArgb(100, 100, 100), Color.FromArgb(23, 23, 23), 0, 0, Width, Height, 45);
                DrawBorders(new Pen(Color.FromArgb(41, 41, 41)), 0);
                DrawBorders(new Pen(Color.FromArgb(41, 41, 41)), 1);
                DrawBorders(Pens.Black, 2);
                G.DrawLine(new Pen(Color.FromArgb(100, 100, 100)), 0, Height - 1, Width, Height - 1);
                DrawGradient(Color.FromArgb(41, 41, 41), Color.FromArgb(100, 100, 100), 0, 0, 1, Height);
                DrawGradient(Color.FromArgb(41, 41, 41), Color.FromArgb(100, 100, 100), Width - 1, 0, Width, Height);
                DrawCorners(BackColor);
                DrawCorners(Color.FromArgb(41, 41, 41), 2);
            }
            else
            {
            }
        }
    }


}

