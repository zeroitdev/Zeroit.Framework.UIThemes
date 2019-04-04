// ***********************************************************************
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


namespace Zeroit.Framework.UIThemes.Orains
{
    public class OrainsGroupBox : ThemeContainer154
    {

        public OrainsGroupBox()
        {
            ControlMode = true;
            SetColor("Border", Color.Black);
            SetColor("Header", 32, 32, 32);
            SetColor("Text", Color.Orange);
            SetColor("R1", 14, 14, 14);
            SetColor("R2", 41, 41, 41);
        }
        Pen Border;
        Brush HeaderColor;
        Brush textcolor;
        Color R1;

        Color R2;

        protected override void ColorHook()
        {
            Border = GetPen("Border");
            HeaderColor = GetBrush("Header");
            textcolor = GetBrush("Text");
            R1 = GetColor("R1");
            R2 = GetColor("R2");

        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(14, 14, 14));

            LinearGradientBrush LGB1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), R1, R2, 90);
            G.FillRectangle(LGB1, new Rectangle(0, 0, Width - 1, Height - 25));

            HatchBrush BodyHatch = new HatchBrush(HatchStyle.NarrowVertical, Color.FromArgb(15, Color.White), Color.Transparent);
            G.FillRectangle(BodyHatch, new Rectangle(0, 0, Width - 1, Height - 1));

            G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, 25));
            G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawString(Text, Font, textcolor, new Point(7, 6));

            G.FillRectangle(new SolidBrush(Color.FromArgb(20, 20, 20)), new Rectangle(1, 26, Width - 2, Height - 27));
            // BG

            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(40, 40, 40))), new Rectangle(1, 1, Width - 3, Height + 25));
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(40, 40, 40))), new Rectangle(1, 26, Width - 3, Height - 28));

        }
    }

}


