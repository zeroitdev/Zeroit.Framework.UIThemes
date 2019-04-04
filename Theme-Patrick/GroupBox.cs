// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Patrick
{

    public class PatrickGroupBox : ThemeContainer151
    {
        //G.Clear
        private Color C1;
        private Color C2;
        //Lime Gradient
        private Color C3;
        //DrawRectangle
        private Pen P1;
        //Gloss
        private Brush B1;
        //Grey Text
        private Brush B2;
        private Brush B5;
        //BackGround
        private Brush HB1;
        public PatrickGroupBox()
        {
            ControlMode = true;
            Size = new Size(205, 95);
        }
        protected override void ColorHook()
        {
            C1 = Color.FromArgb(15, 15, 15);
            C2 = Color.FromArgb(50, 50, 50);
            C3 = Color.FromArgb(0, 0, 0);
            P1 = Pens.Black;
            B1 = new SolidBrush(Color.FromArgb(60, Color.White));
            B2 = new SolidBrush(Color.White);
            B5 = new SolidBrush(Color.White);

        }

        protected override void PaintHook()
        {
            HatchBrush hb1 = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(15, 15, 15));
            HatchBrush hb2 = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(35, 35, 35));
            HatchBrush hb3 = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(0, 0, 0));
            //G.Clear(C1);

            G.Clear(BackColor);

            G.FillRectangle(B5, 0, 0, Width, Height);
            //BackGround'
            G.FillRectangle(B5, 0, 0, Width, 15);
            //Outside'
            G.DrawRectangle(P1, 0, 15, Width - 1, Convert.ToInt32(Height - 16));
            //Green'
            G.FillRectangle(hb1, 5, 5, Width - 15, 20);
            //Gloss
            G.FillRectangle(hb1, 5, 5, Width - 15, 10);
            G.DrawRectangle(P1, 5, 5, Width - 15, 20);
            DrawText(B2, HorizontalAlignment.Center, 0, 3);
        }
    }

}
