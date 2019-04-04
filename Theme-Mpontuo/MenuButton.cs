// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="MenuButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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

