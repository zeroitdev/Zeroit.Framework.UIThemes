// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Minimize.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.SpicyLips
{

    public class BlackMinimizeButton : ThemeControl154
    {
        public BlackMinimizeButton()
        {
            Size = new Size(18, 18);
        }

        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(101, 101, 101));
            switch (State)
            {
                case MouseState.None:
                    DrawGradient(Color.FromArgb(40, 40, 40), Color.FromArgb(4, 4, 4), 0, 0, Width, Height, 90);
                    break;
                case MouseState.Over:
                    DrawGradient(Color.FromArgb(40, 40, 40), Color.FromArgb(4, 4, 4), 0, 0, Width, Height, 90);
                    break;
                case MouseState.Down:
                    DrawGradient(Color.FromArgb(4, 4, 4), Color.FromArgb(3, 65, 0), 0, 0, Width, Height, 90);
                    break;
            }
            DrawBorders(Pens.Black);
            DrawBorders(Pens.Black, 2);
            DrawCorners(Color.FromArgb(30, 30, 30), ClientRectangle);
            G.DrawString("_", Font, Brushes.White, 4, -2);
            DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
        }
    }

}