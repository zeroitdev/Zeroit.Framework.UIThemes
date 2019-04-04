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

namespace Zeroit.Framework.UIThemes.Fusion
{


    
    public class FusionButton : ThemeControl152
    {

        public FusionButton()
        {
            SetColor("DownGradient1", 255, 127, 1);
            SetColor("DownGradient2", 255, 175, 12);
            SetColor("NoneGradient1", 255, 175, 12);
            SetColor("NoneGradient2", 255, 127, 1);
            SetColor("TextShade", 30, Color.Black);
            SetColor("Text", Color.White);
            SetColor("Border1", 255, 197, 19);
            SetColor("Border2", 254, 133, 0);
        }

        private Color C1;
        private Color C2;
        private Color C3;
        private Color C4;
        private SolidBrush B1;
        private SolidBrush B2;
        private Pen P1;

        private Pen P2;
        protected override void ColorHook()
        {
            C1 = GetColor("DownGradient1");
            C2 = GetColor("DownGradient2");
            C3 = GetColor("NoneGradient1");
            C4 = GetColor("NoneGradient2");

            B1 = new SolidBrush(GetColor("TextShade"));
            B2 = new SolidBrush(GetColor("Text"));

            P1 = new Pen(GetColor("Border1"));
            P2 = new Pen(GetColor("Border2"));
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

            DrawText(B1, HorizontalAlignment.Center, 1, 1);
            DrawText(B2, HorizontalAlignment.Center, 0, 0);

            DrawBorders(P1, 1);
            DrawBorders(P2);

            DrawCorners(BackColor);
        }

    }


}
