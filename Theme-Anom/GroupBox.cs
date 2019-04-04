// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
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

namespace Zeroit.Framework.UIThemes.Anom
{

    public class AnomGroupBox : ThemeContainer154
    {

        public AnomGroupBox()
        {
            ControlMode = true;
            SetColor("Border", Color.Black);
            SetColor("Text", Color.Black);
        }

        Brush Border;

        Brush TextColor;
        protected override void ColorHook()
        {
            Border = GetBrush("Border");
            TextColor = GetBrush("Text");
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(1, 1, Width - 2, Height - 1), Color.FromArgb(255, 222, 222, 222), Color.FromArgb(255, 200, 200, 200), 90f);
            HatchBrush HB = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(80, Color.Gray), Color.Transparent);
            G.FillRectangle(LGB, new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawRectangle(new Pen(Border), 0, 0, Width - 1, Height - 1);
            G.FillRectangle(HB, new Rectangle(1, 1, Width - 2, Height - 2));
            G.FillRectangle(new SolidBrush(BackColor), new Rectangle(6, 28, Width - 13, Height - 33));
            G.DrawRectangle(new Pen(Border), 6, 27, Width - 13, Height - 33);
            DrawText(TextColor, 6, 6);
        }
    }
    
}


