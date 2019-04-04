// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Somnium
{
    public class SomniumButtonA : ThemeControl151
    {
        //G.Clear
        private Color C1;
        private Color C2;
        //Lime Gradient
        private Color C3;
        //Gloss
        private Brush B1;
        //Grey Text
        private Brush B2;
        //DrawRectangle
        private Pen P1;
        protected override void ColorHook()
        {
            C1 = Color.White;
            C2 = Color.FromArgb(50, 50, 50);
            C3 = Color.FromArgb(0, 0, 0);
            B1 = new SolidBrush(Color.FromArgb(60, Color.White));
            B2 = new SolidBrush(Color.White);
            P1 = Pens.White;
        }
        public SomniumButtonA()
        {
            Size = new Size(115, 20);
        }
        protected override void PaintHook()
        {
            G.Clear(C1);
            DrawGradient(C2, C3, 0, 0, Width, Height, 90);
            //Gloss'
            if ((State == MouseState.Over))
            {
                G.FillRectangle(B1, 0, Convert.ToInt32(Height / 2), Width, Convert.ToInt32(Height / 2));
            }
            else if ((State == MouseState.Down))
            {
                G.FillRectangle(B1, 0, 0, Width, Convert.ToInt32(Height / 2));
            }
            else
            {
                G.FillRectangle(B1, 0, 0, Width, Convert.ToInt32(Height / 2));
            }
            DrawBorders(P1, 0, 0, Width, Height);
            DrawText(B2, HorizontalAlignment.Center, 0, 0);
        }
    }

}


