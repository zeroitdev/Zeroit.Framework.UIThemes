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
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Metal
{
    public class Button : ThemeControl
    {
        private Pen P1;
        private Pen P2;
        public override void PaintHook()
        {
            P1 = new Pen(Color.FromArgb(55, 55, 55));
            P2 = new Pen(Color.FromArgb(75, 80, 75));
            Color gradient1 = Color.FromArgb(50, 50, 50);
            Color gradient2 = Color.FromArgb(55, 55, 55);
            Color gradient11 = Color.FromArgb(55, 55, 55);
            Color gradient12 = Color.FromArgb(60, 60, 60);


            G.FillRectangle(new SolidBrush(Color.FromArgb(45, 45, 45)), ClientRectangle);
            DrawGradient(gradient1, gradient2, 0, 0, Width, 18, 90);


            switch (MouseState)
            {

                case State.MouseOver:

                    G.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), ClientRectangle);
                    DrawGradient(gradient11, gradient12, 0, 0, Width, 18, 90);

                    break;
            }


            DrawBorders(P2, P1, ClientRectangle);
            DrawCorners(Color.FromArgb(63, 63, 63), ClientRectangle);
            DrawText(HorizontalAlignment.Center, Color.White, 0);
        }
    }


}
