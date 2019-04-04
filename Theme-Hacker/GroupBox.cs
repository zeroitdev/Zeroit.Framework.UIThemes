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

namespace Zeroit.Framework.UIThemes.Hacker
{
    public class HackerGroupBox : ThemeContainer154
    {

        Pen Border;
        Brush HeaderColor;

        Brush TextColor;
        public HackerGroupBox()
        {
            ControlMode = true;
            SetColor("Border", Color.Black);
            SetColor("Text", Color.Lime);
            Font = new Font("Arial", 9);
        }

        protected override void ColorHook()
        {
            Border = GetPen("Border");
            TextColor = GetBrush("Text");
        }

        protected override void PaintHook()
        {
            G.Clear(Color.Black);
            //Group Area
            HatchBrush BackBG = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(255, 16, 16, 16), Color.FromArgb(255, 14, 14, 14));
            G.FillRectangle(BackBG, new Rectangle(0, 22, Width - 1, Height - 23));
            //Text Area
            LinearGradientBrush TopBG = new LinearGradientBrush(new Rectangle(0, 0, 75, 22), Color.FromArgb(255, 18, 18, 18), Color.FromArgb(255, Color.Black), 180f);
            G.FillRectangle(TopBG, new Rectangle(0, 0, 75, 22));
            G.FillRectangle(new SolidBrush(Color.FromArgb(255, 18, 18, 18)), new Rectangle(75, 0, Width - 75, 22));
            //Draw Borders
            G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, 22));
            //Text
            G.DrawString(Text, Font, TextColor, new Point(5, 4));
        }
    }


}


