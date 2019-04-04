// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-22-2018
// ***********************************************************************
// <copyright file="Check.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;



namespace Zeroit.Framework.UIThemes.Advantium
{
    //CheckBox
    public class AdvantiumCheck : ThemeControl154
    {
        private bool _CheckedState;
        public bool CheckedState {
            get { return _CheckedState; }
            set {
                _CheckedState = value;
                Invalidate();
            }
        }
        public AdvantiumCheck()
        {
            Click += changeCheck;
            Size = new Size(100, 15);
            MinimumSize = new Size(16, 16);
            MaximumSize = new Size(600, 16);
            CheckedState = false;
            SetColor("CheckBorderOut", Color.FromArgb(25, 25, 25));
            SetColor("CheckBorderIn", Color.FromArgb(59, 59, 59));
            SetColor("TextColor", Color.LawnGreen);
            SetColor("CheckBack1", Color.FromArgb(132, 192, 240));
            SetColor("CheckBack2", Color.LawnGreen);
            SetColor("CheckFore1", Color.LawnGreen);
            SetColor("CheckFore2", Color.FromArgb(42, 242, 77));
            SetColor("ColorUncheck", Color.FromArgb(35, 35, 35));
            SetColor("BackColor", Color.FromArgb(35, 35, 35));
        }
        Color C1;
        Color C2;
        Color C3;
        Color C4;
        Color C5;
        Color C6;
        Color P1;
        Color P2;
        Color B1;
        protected override void ColorHook()
        {
            C1 = GetColor("CheckBack1");
            C2 = GetColor("CheckBack2");
            C3 = GetColor("CheckFore1");
            C4 = GetColor("CheckFore2");
            C5 = GetColor("ColorUncheck");
            C6 = GetColor("BackColor");
            P1 = GetColor("CheckBorderOut");
            P2 = GetColor("CheckBorderIn");
            B1 = GetColor("TextColor");
        }
        protected override void PaintHook()
        {
            G.Clear(C6);
            switch (CheckedState) {
                case true:
                    DrawGradient(C1, C2, 3, 3, 9, 9, 90);
                    DrawGradient(C3, C4, 4, 4, 7, 7, 90);
                    break;
                case false:
                    DrawGradient(C5, C5, 0, 0, 15, 15, 90);
                    break;
            }
            G.DrawRectangle(new Pen(new SolidBrush(P1)), 0, 0, 14, 14);
            G.DrawRectangle(new Pen(new SolidBrush(P2)), 1, 1, 12, 12);
            DrawText(new SolidBrush(B1), 17, 0);
            DrawCorners(C6, new Rectangle(0, 0, 13, 13));
        }
        public void changeCheck(object sender, EventArgs e)
        {
            switch (CheckedState) {
                case true:
                    CheckedState = false;
                    break;
                case false:
                    CheckedState = true;
                    break;
            }
        }
    }

}