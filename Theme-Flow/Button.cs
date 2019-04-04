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
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Flow
{
    public class FlowButton : ThemeControl152
    {

        public FlowButton()
        {
            SetColor("DownGradient1", 24, 24, 24);
            SetColor("DownGradient2", 38, 38, 38);
            SetColor("NoneGradient1", 38, 38, 38);
            SetColor("NoneGradient2", 24, 24, 24);
            SetColor("Text", 0, 132, 255);
            SetColor("Border1", 22, 22, 22);
            SetColor("Border2A", 60, 60, 60);
            SetColor("Border2B", 36, 36, 36);
        }

        private Color C1;
        private Color C2;
        private Color C3;
        private Color C4;
        private Color C5;
        private Color C6;
        private SolidBrush B1;
        private LinearGradientBrush B2;
        private Pen P1;

        private Pen P2;
        protected override void ColorHook()
        {
            C1 = GetColor("DownGradient1");
            C2 = GetColor("DownGradient2");
            C3 = GetColor("NoneGradient1");
            C4 = GetColor("NoneGradient2");
            C5 = GetColor("Border2A");
            C6 = GetColor("Border2B");

            B1 = new SolidBrush(GetColor("Text"));

            P1 = new Pen(GetColor("Border1"));
        }

        protected override void PaintHook()
        {
            if (State == MouseState.Down)
            {
                DrawGradient(C1, C2, ClientRectangle, 90f);
            }
            else
            {
                DrawGradient(C3, C4, ClientRectangle, 90f);
            }

            DrawText(B1, HorizontalAlignment.Center, 0, 0);

            B2 = new LinearGradientBrush(ClientRectangle, C5, C6, 90f);
            P2 = new Pen(B2);

            DrawBorders(P1);
            DrawBorders(P2, 1);
        }
    }


}
