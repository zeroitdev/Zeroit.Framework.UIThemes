// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TopButton.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Blue
{

    public class BlueTopButton : ThemeControl151
    {

        public BlueTopButton()
        {
            Size = new Size(14, 7);
            SetColor("BackColor", 98, 122, 173);
            SetColor("BackColor2", 109, 134, 183);
            SetColor("BorderColor", 29, 64, 136);
            SetColor("CornerColor", 109, 132, 180);
        }

        protected override void ColorHook()
        {
            C1 = GetColor("BackColor");
            C2 = GetColor("CornerColor");
            C3 = GetColor("BackColor2");
            P1 = new Pen(GetColor("BorderColor"));
        }

        private Color C1;
        private Color C2;
        private Color C3;

        private Pen P1;
        protected override void PaintHook()
        {
            G.Clear(C1);
            if (State == MouseState.Down)
            {
                G.Clear(C3);
            }
            DrawBorders(P1, 0, 0, Width, Height);
            DrawCorners(C2);
        }
    }
    
}



