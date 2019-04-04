// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TopButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Booster
{
    public class BoosterTopButton : ThemeControl154
    {
        public BoosterTopButton()
        {
            Transparent = true;
            BackColor = Color.Transparent;
        }

        protected override void ColorHook()
        {
        }


        protected override void PaintHook()
        {
            DrawGradient(Color.FromArgb(141, 141, 141), Color.FromArgb(23, 23, 23), 0, 0, Width, Height, 45);
            DrawBorders(new Pen(Color.FromArgb(41, 41, 41)), 0);
            DrawBorders(new Pen(Color.FromArgb(41, 41, 41)), 1);
            DrawBorders(Pens.Black, 2);
            G.DrawLine(new Pen(Color.FromArgb(100, 100, 100)), 0, Height - 1, Width, Height - 1);
            DrawGradient(Color.FromArgb(41, 41, 41), Color.FromArgb(100, 100, 100), 0, 0, 1, Height);
            DrawGradient(Color.FromArgb(41, 41, 41), Color.FromArgb(100, 100, 100), Width - 1, 0, Width, Height);
            DrawCorners(BackColor);
            DrawCorners(Color.FromArgb(41, 41, 41), 2);

            if (State == MouseState.Over)
            {
                DrawGradient(Color.FromArgb(255, 255, 255), Color.FromArgb(23, 23, 23), 0, 0, Width, Height, 45);
                DrawBorders(new Pen(Color.FromArgb(41, 41, 41)), 0);
                DrawBorders(new Pen(Color.FromArgb(41, 41, 41)), 1);
                DrawBorders(Pens.Black, 2);
                G.DrawLine(new Pen(Color.FromArgb(100, 100, 100)), 0, Height - 1, Width, Height - 1);
                DrawGradient(Color.FromArgb(41, 41, 41), Color.FromArgb(100, 100, 100), 0, 0, 1, Height);
                DrawGradient(Color.FromArgb(41, 41, 41), Color.FromArgb(100, 100, 100), Width - 1, 0, Width, Height);
                DrawCorners(BackColor);
                DrawCorners(Color.FromArgb(41, 41, 41), 2);
            }
            else if (State == MouseState.Down)
            {
                DrawGradient(Color.FromArgb(100, 100, 100), Color.FromArgb(23, 23, 23), 0, 0, Width, Height, 45);
                DrawBorders(new Pen(Color.FromArgb(41, 41, 41)), 0);
                DrawBorders(new Pen(Color.FromArgb(41, 41, 41)), 1);
                DrawBorders(Pens.Black, 2);
                G.DrawLine(new Pen(Color.FromArgb(100, 100, 100)), 0, Height - 1, Width, Height - 1);
                DrawGradient(Color.FromArgb(41, 41, 41), Color.FromArgb(100, 100, 100), 0, 0, 1, Height);
                DrawGradient(Color.FromArgb(41, 41, 41), Color.FromArgb(100, 100, 100), Width - 1, 0, Width, Height);
                DrawCorners(BackColor);
                DrawCorners(Color.FromArgb(41, 41, 41), 2);
            }
            else
            {
            }
        }
    }


}

