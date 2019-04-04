// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace Zeroit.Framework.UIThemes.Visible
{
    public class VIButton : ThemeControl154
    {
        protected override void ColorHook()
        {

        }
        public VIButton()
        {
            Size = new Size(75, 25);
        }
        protected override void PaintHook()
        {

            Pen P1 = new Pen(Color.FromArgb(16, 16, 16));
            G.FillRectangle(new HatchBrush(HatchStyle.Divot, Color.FromArgb(35, 35, 35), Color.FromArgb(15, 15, 15)), 0, 0, Width, Height);
            DrawBorders(Pens.Black);
            DrawBorders(P1, 1);
            DrawBorders(Pens.Black, 2);
            DrawCorners(Color.Transparent, 3);
            if (State == MouseState.Over)
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(25, 25, 25)), 3, 3, Width - 6, Height - 6);
                DrawBorders(new Pen(Color.FromArgb(0, 0, 0)), 2);
            }
            else if (State == MouseState.Down)
            {
                G.FillRectangle(new LinearGradientBrush(new Rectangle(3, 3, Width - 6, Height - 6), Color.FromArgb(12, 12, 12), Color.FromArgb(30, 30, 30), LinearGradientMode.BackwardDiagonal), 3, 3, Width - 6, Height - 6);
                DrawBorders(new Pen(Color.FromArgb(0, 0, 0)), 2);
            }
            else
            {
                G.FillRectangle(new HatchBrush(HatchStyle.Divot, Color.FromArgb(35, 35, 35), Color.FromArgb(15, 15, 15)), 0, 0, Width, Height);
                DrawBorders(Pens.Black);
                DrawBorders(P1, 1);
                DrawBorders(Pens.Black, 2);

            }
            if (State == MouseState.Down)
            {
                DrawText(Brushes.White, HorizontalAlignment.Center, 2, 2);
            }
            else
            {
                DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
            }
        }

    }
}


