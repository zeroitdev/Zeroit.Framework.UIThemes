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
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Empress
{
    public class EmpressGroupBox : ThemeContainer154
    {

        public EmpressGroupBox()
        {
            ControlMode = true;
            SetColor("Border", Color.Black);
            SetColor("Header", ColorConverter.HexToColor("#A12F35"));
            SetColor("Text", Color.Black);
        }
        Pen Border;
        Brush HeaderColor;
        Brush textcolor;
        protected override void ColorHook()
        {
            Border = GetPen("Border");
            HeaderColor = GetBrush("Header");
            textcolor = GetBrush("Text");
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            G.FillRectangle(HeaderColor, new Rectangle(0, 0, Width - 1, 25));
            G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, 25));
            G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawString(Text, Font, textcolor, new Point(7, 6));

            HatchBrush BodyHatch = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(20, Color.Black), Color.Transparent);
            G.FillRectangle(BodyHatch, new Rectangle(0, 0, Width - 1, Height - 1));

        }
    }


}


