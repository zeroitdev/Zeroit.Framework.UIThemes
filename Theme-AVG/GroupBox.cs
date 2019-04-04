// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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

namespace Zeroit.Framework.UIThemes.AVG
{


    public class AVGGroupBox : ThemeContainer154
    {

        public AVGGroupBox()
        {
            ControlMode = true;
            SetColor("Border", Color.WhiteSmoke);
            SetColor("Header", Color.FromArgb(24, 143, 124));
            SetColor("Text", Color.WhiteSmoke);
        }
        Pen Border;
        Brush HeaderColor;
        Brush textColor;
        Color Hello;
        protected override void ColorHook()
        {
            Border = GetPen("Border");
            HeaderColor = GetBrush("Header");
            textColor = GetBrush("Text");
            Hello = Color.FromArgb(24, 143, 124);
        }

        protected override void PaintHook()
        {
            G.Clear(Hello);
            G.FillRectangle(HeaderColor, new Rectangle(0, 0, Width - 0, 26));
            G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, 25));
            G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawString(Text, Font, textColor, new Point(4, 5));

        }
    }
    
}

