// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="VerticalLine.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Frog
{
    public class FrogVerticalLine : ThemeControl154
    {

        protected override void ColorHook()
        {
            SetColor("EndBorder", Color.FromArgb(255, 60, 60, 60));
            SetColor("Border", Color.FromArgb(255, 200, 200, 200));
        }

        protected override void PaintHook()
        {
            if ((Height > 1))
            {
                Height = 1;
            }
            Color LineColor = GetColor("Border");
            Color EndLineColor = GetColor("EndBorder");
            LinearGradientBrush LGB = new LinearGradientBrush(new Point(0, 0), new Point(Width / 2 / 2, 0), EndLineColor, LineColor);
            LinearGradientBrush LGB2 = new LinearGradientBrush(new Point((Width / 2) + (Width / 2 / 2), 0), new Point(Width, 0), LineColor, EndLineColor);
            G.Clear(LineColor);
            G.FillRectangle(LGB, new Rectangle(0, 0, Width / 2 / 2, Height));
            G.FillRectangle(LGB2, new Rectangle((Width / 2) + (Width / 2 / 2), 0, Width / 2 / 2, Height));
        }
    }


}

