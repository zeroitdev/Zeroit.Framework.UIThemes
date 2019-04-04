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
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Prime
{
    public class PrimeButton : ThemeControl152
    {

        public PrimeButton()
        {
            SetColor("DownGradient1", 215, 215, 215);
            SetColor("DownGradient2", 235, 235, 235);
            SetColor("NoneGradient1", 235, 235, 235);
            SetColor("NoneGradient2", 215, 215, 215);
            SetColor("NoneGradient3", 252, 252, 252);
            SetColor("NoneGradient4", 242, 242, 242);
            SetColor("Glow", 50, Color.White);
            SetColor("TextShade", Color.White);
            SetColor("Text", 80, 80, 80);
            SetColor("Border1", Color.White);
            SetColor("Border2", 180, 180, 180);
        }

        private Color C1;
        private Color C2;
        private Color C3;
        private Color C4;
        private Color C5;
        private Color C6;
        private SolidBrush B1;
        private SolidBrush B2;
        private SolidBrush B3;
        private Pen P1;

        private Pen P2;
        protected override void ColorHook()
        {
            C1 = GetColor("DownGradient1");
            C2 = GetColor("DownGradient2");
            C3 = GetColor("NoneGradient1");
            C4 = GetColor("NoneGradient2");
            C5 = GetColor("NoneGradient3");
            C6 = GetColor("NoneGradient4");

            B1 = new SolidBrush(GetColor("Glow"));
            B2 = new SolidBrush(GetColor("TextShade"));
            B3 = new SolidBrush(GetColor("Text"));

            P1 = new Pen(GetColor("Border1"));
            P2 = new Pen(GetColor("Border2"));
        }


        protected override void PaintHook()
        {
            if (State == MouseState.Down)
            {
                DrawGradient(C1, C2, ClientRectangle, 90);
            }
            else
            {
                DrawGradient(C3, C4, ClientRectangle, 90);
                DrawGradient(C5, C6, 0, 0, Width, Height / 2, 90f);
            }

            if (State == MouseState.Over)
            {
                G.FillRectangle(B1, ClientRectangle);
            }

            if (State == MouseState.Down)
            {
                DrawText(B2, HorizontalAlignment.Center, 2, 2);
                DrawText(B3, HorizontalAlignment.Center, 1, 1);
            }
            else
            {
                DrawText(B2, HorizontalAlignment.Center, 1, 1);
                DrawText(B3, HorizontalAlignment.Center, 0, 0);
            }

            DrawBorders(P1, 1);
            DrawBorders(P2);

            DrawCorners(BackColor);
        }
    }

}

