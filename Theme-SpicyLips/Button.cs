// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
//     Copyright � Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.SpicyLips
{
    public class BlackButton : ThemeControl154
    {
        public BlackButton()
        {
            Size = new Size(75, 23);
        }

        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(1, 1, 1));
            switch (State)
            {
                case MouseState.None:
                    DrawGradient(Color.FromArgb(40, 40, 40), Color.FromArgb(28, 28, 28), 0, 0, Width, Height, 90);
                    break;
                case MouseState.Over:
                    DrawGradient(Color.FromArgb(40, 40, 40), Color.FromArgb(28, 28, 28), 0, 0, Width, Height, 90);
                    break;
                case MouseState.Down:
                    DrawGradient(Color.FromArgb(4, 4, 4), Color.FromArgb(20, 20, 20), 0, 0, Width, Height, 90);
                    break;
            }
            G.FillRectangle(new SolidBrush(Color.FromArgb(6, Color.White)), 0, 0, Width, 12);
            DrawBorders(Pens.Black);
            DrawBorders(Pens.Black, 2);
            DrawCorners(Color.FromArgb(20, 20, 20), ClientRectangle);
            DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
        }

    }

}