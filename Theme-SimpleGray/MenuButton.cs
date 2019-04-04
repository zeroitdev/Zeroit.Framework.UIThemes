// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="MenuButton.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.SimpleGray
{
    public class SimplyGrayMenuButton : ThemeControl
    {

        public SimplyGrayMenuButton()
        {
            AllowTransparent();
            ForeColor = Color.White;
            Size S = new Size(15, 20);
            Size = S;
        }

        Color T = Color.Transparent;
        Color LG = Color.LightGray;
        Color Gr = Color.Gray;
        Pen P = Pens.DarkGray;

        Pen Pb = Pens.Black;
        public override void PaintHook()
        {
            G.Clear(Color.DarkGray);

            DrawGradient(LG, Gr, 0, 0, Width, Height, 90);

            G.DrawLine(Pb, 0, 0, Width, 0);
            G.DrawLine(P, 0, 1, Width, 1);

            DrawText(HorizontalAlignment.Center, ForeColor, 0);
        }
    }

}

