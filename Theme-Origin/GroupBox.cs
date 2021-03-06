﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Origin
{
    public class OriginGroupBox : ThemeContainer154
    {

        public OriginGroupBox()
        {
            ControlMode = true;
            SetColor("Border", Color.Silver);
            SetColor("Header", Color.Gray);
            SetColor("TextColor", Color.White);
        }

        Pen Border;
        Brush HeaderColor;

        Brush TextColor;
        protected override void ColorHook()
        {
            Border = GetPen("Border");
            HeaderColor = GetBrush("Header");
            TextColor = GetBrush("TextColor");
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            HatchBrush HB = new HatchBrush(HatchStyle.Percent80, Color.FromArgb(45, Color.FromArgb(39, 38, 38)), Color.Transparent);
            G.FillRectangle(HeaderColor, new Rectangle(0, 0, Width - 2, 25));
            G.FillRectangle(HB, new Rectangle(0, 0, Width - 2, Height - 1));

            G.DrawRectangle(Border, new Rectangle(0, 0, Width - 2, 25));
            G.DrawRectangle(Border, new Rectangle(0, 0, Width - 2, Height - 1));
            G.DrawString(Text, Font, TextColor, new Point(5, 5));
        }
    }

}


