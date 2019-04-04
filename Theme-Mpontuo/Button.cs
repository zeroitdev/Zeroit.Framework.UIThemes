// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
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
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.Mpontuo
{
    public class MpontuoButton : ThemeControl
    {
        public MpontuoButton()
        {
            ForeColor = Color.FromArgb(66, 130, 181);
        }

        private Color G1 = Color.FromArgb(50, 50, 50);
        private Color G2 = Color.FromArgb(42, 42, 42);
        private Color G3 = Color.Gray;
        private Color G4 = Color.FromArgb(17, 89, 119);
        private Pen Bl = Pens.Black;
        private Color G5 = Color.FromArgb(28, 107, 144);
        private Color N = Color.FromArgb(40, 40, 40);

        public override void PaintHook()
        {
            G.Clear(N); //Temporary, gradient will cover it

            if (MouseState == State.MouseNone) //Draws a gradient depending on the mousestate
            {
                DrawGradient(G1, G2, 0, 0, Width, Height, 90);
            }
            else if (MouseState == State.MouseOver)
            {
                if (Pover)
                {
                    DrawGradient(G1, G3, 0, 0, Width, Height, 90);
                }
                if (!Pover)
                {
                    DrawGradient(G1, G2, 0, 0, Width, Height, 90);
                }
            }
            else if (MouseState == State.MouseDown)
            {
                DrawGradient(G2, G1, 0, 0, Width, Height, 90);
            }

            DrawText(HorizontalAlignment.Center, ForeColor, 0); //Draws the text...
            G.DrawRectangle(Bl, ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1); //Border
        }
        private bool Pover = true;
        public bool ColorMouseOn
        {
            get
            {
                return Pover;
            }
            set
            {
                Pover = value;
            }
        }
    }
}

