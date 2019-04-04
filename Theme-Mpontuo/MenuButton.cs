// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
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
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.Mpontuo
{
    public class MpontuoMenuButton : ThemeControl
    {
        public MpontuoMenuButton()
        {
            AllowTransparent();
            ForeColor = Color.White;
            Size S = new Size(15, 20);
            Size = S;
        }

        private Pen Bl = Pens.Black;
        private Color G1 = Color.FromArgb(65, 65, 65);
        private Color G2 = Color.FromArgb(30, 30, 30);

        public override void PaintHook()
        {
            if (MouseState == State.MouseNone) //Draws a gradient depending on the mousestate
            {
                DrawGradient(G1, G2, 0, 0, Width, 20, 90);
            }
            else if (MouseState == State.MouseOver)
            {
                DrawGradient(G1, Color.Gray, 0, 0, Width, Height, 90);
            }
            else if (MouseState == State.MouseDown)
            {
                DrawGradient(G2, G1, 0, 0, Width, Height, 90);
            }
            G.DrawLine(Bl, 0, 0, Width, 0); //Draw a black line accross the top, matches the theme's border
            DrawText(HorizontalAlignment.Center, ForeColor, 0); //Draws text..
        }
    }
}

