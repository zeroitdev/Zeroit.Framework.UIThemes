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

namespace Zeroit.Framework.UIThemes.Earn
{
    public class EarnGroupBox : ThemeContainer154
    {

        public EarnGroupBox()
        {
            ControlMode = true;
            TransparencyKey = Color.Fuchsia;

            SetColor("Bord", Color.FromArgb(75, 77, 89));
            SetColor("Border", Color.FromArgb(75, 77, 89));
            SetColor("Head", Color.FromArgb(75, 77, 89));
            SetColor("Text", Color.White);
        }

        Pen BordColor;
        Brush HeadColor;

        Brush TextColor;
        protected override void ColorHook()
        {
            TextColor = GetBrush("Text");
            HeadColor = GetBrush("Head");
            BordColor = GetPen("Bord");

        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(242, 242, 242));
            G.FillRectangle(HeadColor, new Rectangle(0, 0, Width - 1, 25));
            G.DrawRectangle(BordColor, new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawString(Text, Font, TextColor, new Point(7, 6));
            DrawCorners(Color.FromArgb(240, 240, 240));
        }
    }


}

