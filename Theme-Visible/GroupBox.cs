// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
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
    public class VIGroupBox : ThemeContainer154
    {
        public VIGroupBox()
        {
            ControlMode = true;
            Size = new Size(150, 150);
        }

        protected override void ColorHook()
        {

        }

        protected override void PaintHook()
        {
            G.Clear(Color.Transparent);
            Pen P1 = new Pen(Color.FromArgb(36, 36, 36));
            Pen P2 = new Pen(Color.FromArgb(48, 48, 48));
            DrawBorders(P1, 1);
            DrawBorders(Pens.Black);
            G.DrawLine(P2, 1, 1, Width - 2, 1);
            G.FillRectangle(new LinearGradientBrush(new Rectangle(4, 4, Width - 8, Height - 8), Color.FromArgb(12, 12, 12), Color.FromArgb(18, 18, 18), LinearGradientMode.BackwardDiagonal), 4, 4, Width - 8, Height - 8);
            DrawBorders(P1, 3);
            DrawBorders(Pens.Black, 5);
            Rectangle R1 = new Rectangle(5, 5, Width - 25, 20);
            G.DrawRectangle(Pens.Black, R1);
            G.DrawLine(P1, 5, 27, Width - 20, 27);
            G.DrawLine(P1, Width - 19, 6, Width - 19, 27);
            G.DrawLine(P2, 5, 25, Width - 22, 25);
            G.DrawLine(P2, Width - 21, 6, Width - 21, 25);
            DrawText(Brushes.White, 35, Convert.ToInt32(7.5F));
        }
    }
}


