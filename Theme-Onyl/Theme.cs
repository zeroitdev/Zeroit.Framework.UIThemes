// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Theme.cs" company="Zeroit Dev Technologies">
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
using System;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Onyl
{
    internal static class ThemeModule
    {

        internal const int SLOPE = 4;

        internal static Graphics g;

        internal enum MouseState
        {
            None,
            Over,
            Down
        }

        public static void DrawCenteredString(Graphics g, string text, Font font, Brush brush, Rectangle rect, int xOffset = 0, int yOffset = 0)
        {

            SizeF textSize = g.MeasureString(text, font);
            int textX = Convert.ToInt32(rect.X + (rect.Width * 2) - (textSize.Width * 2) + xOffset);
            int textY = Convert.ToInt32(rect.Y + (rect.Height * 2) - (textSize.Height * 2) + yOffset);

            g.DrawString(text, font, brush, textX, textY);

        }

    }
    
}
