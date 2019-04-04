// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button2.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Beyond
{

    public class BeyondButton2 : ThemeControl151
    {
        private Color C1;
        private Color C2;
        private Color C3;
        private Pen P1;
        public BeyondButton2()
        {
            SetColor("BackColor", Color.White);
        }
        protected override void ColorHook()
        {
            C1 = GetColor("BackColor");
            C2 = Color.FromArgb(50, 50, 50);
            C3 = Color.FromArgb(70, 70, 70);
            P1 = new Pen(Color.Black);
        }

        protected override void PaintHook()
        {
            G.Clear(C1);
            if ((State == MouseState.Over))
            {
                DrawGradient(C2, C3, 0, 0, Width, Height);
            }
            else if ((State == MouseState.Down))
            {
                DrawGradient(C3, C2, 0, 0, Width, Height);
            }
            else
            {
                DrawGradient(C3, C2, 0, 0, Width, Height);
            }
            DrawBorders(P1, ClientRectangle);
            DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
        }
    }

    
}
