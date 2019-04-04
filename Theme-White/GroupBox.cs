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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.WhitePure
{
    public class WhiteGroupBox : ThemeContainer153
    {

        public WhiteGroupBox()
        {
            ControlMode = true;
            BackColor = Color.FromArgb(225, 225, 225);

            SetColor("Grad1", 225, 225, 225);
            SetColor("Grad2", 185, 185, 185);
            SetColor("Grad3", 80, Color.White);
            SetColor("Transp", Color.Transparent);
            SetColor("Text", Color.FromArgb(0, 133, 157));
            SetColor("BG", Color.FromArgb(41, 41, 41));
            SetColor("Border1", 225, 225, 225);
            SetColor("Border2", 150, 150, 150);


            this.Size = new Size(200, 150);

        }

        Color C1;
        Color C2;
        Color C4;
        Pen P1;
        Pen P2;

        Brush B1;
        protected override void ColorHook()
        {
            C1 = GetColor("Grad1");
            C2 = GetColor("Grad2");
            C4 = GetColor("Transp");

            B1 = new SolidBrush(GetColor("Text"));

            P1 = new Pen(GetColor("Border1"));
            P2 = new Pen(GetColor("Border2"));
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);

            DrawGradient(C2, C1, 0, 0, Width, 20);
            HatchBrush DarkUp = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.Transparent, Color.FromArgb(50, Color.FromArgb(75, 75, 75)));
            G.FillRectangle(DarkUp, new Rectangle(0, 0, ClientRectangle.Width, 20));

            G.DrawLine(P1, 0, 20, Width, 20);
            G.DrawLine(P2, 0, 21, Width, 21);

            DrawBorders(P1);
            DrawBorders(P2, 1);


            DrawText(Brushes.DarkBlue, HorizontalAlignment.Center, 0, 0);
        }
    }

}

