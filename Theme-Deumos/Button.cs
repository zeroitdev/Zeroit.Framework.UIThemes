// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Deumos
{
    public class DeumosButton : ThemeControl153
    {

        public DeumosButton()
        {
            SetColor("Back", 14, 14, 14);
            SetColor("DownGradient1", 14, 14, 14);
            SetColor("DownGradient2", 41, 41, 41);
            SetColor("OverShine", 5, Color.White);
            SetColor("GlossGradient1", 30, Color.White);
            SetColor("GlossGradient2", 5, Color.White);
            SetColor("Highlight1", 62, 62, 62);
            SetColor("Highlight2", 15, Color.White);
            SetColor("Border", Color.Black);
            SetColor("Corners", 16, 16, 16);
            SetColor("Text", Color.White);
        }

        protected override void ColorHook()
        {
            C1 = GetColor("Back");
            C2 = GetColor("DownGradient1");
            C3 = GetColor("DownGradient2");
            C4 = GetColor("GlossGradient1");
            C5 = GetColor("GlossGradient2");
            C6 = GetColor("Corners");

            B1 = new SolidBrush(GetColor("OverShine"));
            B2 = new SolidBrush(GetColor("Text"));

            P1 = new Pen(GetColor("Highlight1"));
            P2 = new Pen(GetColor("Highlight2"));
            P3 = new Pen(GetColor("Border"));
        }

        private Color C1;
        private Color C2;
        private Color C3;
        private Color C4;
        private Color C5;
        private Color C6;
        private SolidBrush B1;
        private SolidBrush B2;
        private Pen P1;
        private Pen P2;

        private Pen P3;
        protected override void PaintHook()
        {
            G.Clear(C1);

            if (State == MouseState.Down)
            {
                DrawGradient(C2, C3, 0, 0, Width, Height, 90);
            }

            if (State == MouseState.Over)
            {
                G.FillRectangle(B1, ClientRectangle);
            }

            DrawGradient(C4, C5, 0, 0, Width, Height / 2, 90);

            G.DrawLine(P1, 0, 1, Width, 1);
            DrawBorders(P2, ClientRectangle, 1);

            DrawBorders(P3, ClientRectangle);

            DrawCorners(C6, new Rectangle(1, 1, Width - 2, Height - 2));
            DrawCorners(BackColor, ClientRectangle);

            DrawText(B2, HorizontalAlignment.Center, 0, 0);
        }

    }

}


