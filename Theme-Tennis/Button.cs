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

namespace Zeroit.Framework.UIThemes.Tennis
{
    public class TennisButton : ThemeControl151
    {
        private Color C1;
        private Pen P1;
        public TennisButton()
        {
            SetColor("BackColor", Color.White);
        }
        protected override void ColorHook()
        {
            C1 = GetColor("BackColor");
            P1 = new Pen(Color.FromArgb(50, 50, 50));
        }

        protected override void PaintHook()
        {
            G.Clear(C1);
            if ((State == MouseState.Over))
            {
                DrawGradient(Color.FromArgb(30, 30, 30), Color.FromArgb(50, 50, 50), 0, 0, Width, Height);
            }
            else if ((State == MouseState.Down))
            {
                DrawGradient(Color.FromArgb(118, 118, 118), Color.FromArgb(110, 110, 110), 0, 0, Width, Height);
            }
            else
            {
                DrawGradient(Color.FromArgb(50, 50, 50), Color.FromArgb(30, 30, 30), 0, 0, Width, Height);
            }
            DrawBorders(P1, ClientRectangle);
            DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);

        }
    }

}


