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

namespace Zeroit.Framework.UIThemes.MPGH
{
    public class MpghButton : ThemeControl
    {


        private Pen P1;
        private Pen P2;
        private Color C1;

        private Color C2;
        public MpghButton()
        {
            C2 = Color.FromArgb(0, 0, 228);
            C1 = Color.FromArgb(50, 34, 34, 34);
        }


        protected override void PaintHook()
        {
            G.Clear(BackColor);
            if (State == MouseState.Down)
            {
                DrawGradient(C1, C2, 0, 0, Width, Height, 90);
            }
            else
            {
                DrawGradient(C2, C1, 0, 0, Width, Height, 90);
            }

            DrawText(Brushes.Black, HorizontalAlignment.Center, 0, 0);
            DrawBorders(Pens.Transparent, ClientRectangle);

            DrawCorners(Color.FromArgb(34, 34, 34), ClientRectangle);
        }


        protected override void ColorHook()
        {
        }
    }


}

