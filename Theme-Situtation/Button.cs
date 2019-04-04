// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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

namespace Zeroit.Framework.UIThemes.Situa
{
    public class SButton : ThemeControl
    {

        public override void PaintHook()
        {
            if (MouseState == State.MouseDown)
            {
                DrawGradient(Color.DarkSlateGray, Color.Black, 0, 0, Width, Height, 90);
            }
            else if (MouseState == State.MouseOver)
            {
                DrawGradient(Color.LightGray, Color.DarkSlateBlue, 0, 0, Width, Height, 90);
            }
            else
            {
                DrawGradient(Color.Black, Color.Black, 0, 0, Width, Height, 90);
            }
            DrawText(HorizontalAlignment.Center, ForeColor, 0);
            DrawBorders(Pens.LightBlue, Pens.Black, ClientRectangle);
        }
    }

}

