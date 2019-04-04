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

namespace Zeroit.Framework.UIThemes.Cola
{
    public class CCButton : ThemeControl151
    {


        protected override void ColorHook()
        {
        }


        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(192, 0, 0));
            DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
            DrawBorders(new Pen(new SolidBrush(Color.LightGray)));
            DrawBorders(new Pen(new SolidBrush(Color.RosyBrown)), 1);
            DrawCorners(Color.RosyBrown, ClientRectangle);
            if (State == MouseState.Over)
            {
                DrawBorders(new Pen(new SolidBrush(Color.Goldenrod)));
                DrawBorders(new Pen(new SolidBrush(Color.Goldenrod)), 1);
                DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
            }
            else if (State == MouseState.Down)
            {
                G.Clear(Color.FromArgb(204, 0, 5));
                DrawBorders(new Pen(new SolidBrush(Color.Gold)));
                DrawBorders(new Pen(new SolidBrush(Color.Gold)), 1);
                DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
            }


        }
    }


}

