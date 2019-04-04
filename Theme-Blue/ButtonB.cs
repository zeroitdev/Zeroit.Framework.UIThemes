// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ButtonB.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Blue
{

    public class BlueButtonB : ThemeControl151
    {

        public BlueButtonB()
        {
            Font = new Font("Tahoma", 10, FontStyle.Bold);
            SetColor("BackColor", 236, 236, 236);
            SetColor("BackColor2", 221, 221, 221);
            SetColor("SideColor", 153, 153, 153);
            SetColor("DownColor", 217, 217, 217);
            SetColor("UpperColor", 255, 255, 255);
            SetColor("TextColor", 51, 51, 51);
        }

        protected override void ColorHook()
        {
            C1 = GetColor("BackColor");
            C2 = GetColor("BackColor2");
            P1 = new Pen(GetColor("SideColor"));
            P2 = new Pen(GetColor("DownColor"));
            P3 = new Pen(GetColor("UpperColor"));
            B1 = new SolidBrush(GetColor("TextColor"));
        }

        private Color C1;
        private Color C2;
        private Pen P1;
        private Pen P2;
        private Pen P3;

        private SolidBrush B1;
        protected override void PaintHook()
        {
            G.Clear(C1);
            if (State == MouseState.Down)
            {
                G.Clear(C2);
                DrawText(B1, HorizontalAlignment.Center, 0, 0);
            }
            else
            {
                G.DrawLine(P3, 1, 1, Width, 1);
                DrawText(B1, HorizontalAlignment.Center, 0, 0);
            }
            G.DrawLine(P1, 0, 0, Width, 0);
            G.DrawLine(P1, 0, 0, 0, Height - 2);
            G.DrawLine(P1, 0, Height - 2, Width, Height - 2);
            G.DrawLine(P1, Width - 1, 0, Width - 1, Height - 2);
            G.DrawLine(P2, 0, Height - 1, Width, Height - 1);
        }
    }
    
}



