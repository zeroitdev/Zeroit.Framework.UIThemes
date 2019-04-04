// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ButtonB.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Storm
{
    public class StormButtonB : ThemeControl
    {

        public StormButtonB()
        {
            SetColor("DownGradient1", 170, 180, 0);
            SetColor("DownGradient2", 220, 230, 0);
            SetColor("UpGradient1", 220, 230, 0);
            SetColor("UpGradient2", 170, 180, 0);
            SetColor("Text", Color.Black);
            SetColor("Light", 65, Color.White);
            SetColor("Border", 70, 70, 90);
            SetColor("OuterLight", 105, 105, 120);
            SetColor("Corners", 125, 130, 70);
        }

        protected override void ColorHook()
        {
            C1 = GetColor("DownGradient1");
            C2 = GetColor("DownGradient2");
            C3 = GetColor("UpGradient1");
            C4 = GetColor("UpGradient2");
            C5 = GetColor("Corners");

            P1 = new Pen(GetColor("Light"));
            P2 = new Pen(GetColor("Border"));
            P3 = new Pen(GetColor("OuterLight"));

            B1 = new SolidBrush(GetColor("Text"));
        }

        private Color C1;
        private Color C2;
        private Color C3;
        private Color C4;
        private Color C5;
        private Pen P1;
        private Pen P2;
        private Pen P3;

        private SolidBrush B1;
        protected override void PaintHook()
        {
            G.Clear(BackColor);

            if (State == MouseState.Down)
            {
                DrawGradient(C1, C2, 0, 0, Width, Height - 1, 90);
            }
            else
            {
                DrawGradient(C3, C4, 0, 0, Width, Height - 1, 90);
            }

            DrawText(B1, HorizontalAlignment.Center, 0, 0);

            DrawBorders(P1, 1, 1, Width - 2, Height - 3);
            DrawBorders(P2, 0, 0, Width, Height - 1);

            if (NoRounding)
            {
                G.DrawLine(P3, 0, Height - 1, Width, Height - 1);
            }
            else
            {
                G.DrawLine(P3, 2, Height - 1, Width - 3, Height - 1);
            }

            DrawCorners(C5, 1, 1, Width - 2, Height - 3);
            DrawCorners(BackColor, 0, 0, Width, Height - 1);
        }
    }

}
