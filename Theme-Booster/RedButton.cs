// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="RedButton.cs" company="Zeroit Dev Technologies">
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

    public class BoosterRedButton : ThemeControl154
    {
        public BoosterRedButton()
        {
            Transparent = true;
            BackColor = Color.Transparent;
        }

        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            DrawGradient(Color.FromArgb(175, 26, 26), Color.FromArgb(124, 0, 0), 0, 0, Width, Height);
            DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
            G.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), 0, 0, Width, Height / 2);
            DrawBorders(new Pen(Color.FromArgb(105, 0, 0)), 0);
            DrawBorders(new Pen(Color.FromArgb(199, 26, 26)), 1);


            if (State == MouseState.Over)
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), 0, 0, Width, Height);
            }
            else if (State == MouseState.Down)
            {
                DrawGradient(Color.FromArgb(45, 45, 45), Color.FromArgb(0, 0, 0), 0, 0, Width, Height);
                DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
                G.FillRectangle(new SolidBrush(Color.FromArgb(15, Color.White)), 0, 0, Width, Height / 2);
                DrawBorders(Pens.Black);
                DrawBorders(new Pen(Color.FromArgb(73, 73, 73)), 1);
            }
            else
            {
            }


            DrawCorners(BackColor);
        }
    }


}

