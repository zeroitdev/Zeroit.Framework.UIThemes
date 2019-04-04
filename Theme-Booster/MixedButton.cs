// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="MixedButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Booster
{
    public class BossterMixedButton : ThemeControl154
    {
        public BossterMixedButton()
        {
            Transparent = true;
            BackColor = Color.Transparent;
        }

        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            DrawGradient(Color.FromArgb(59, 59, 59), Color.FromArgb(24, 24, 24), 0, 0, Width, Height);
            DrawGradient(Color.FromArgb(204, 37, 37), Color.FromArgb(104, 2, 2), 0, 0, (Width / 5) + 8, Height);
            G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)), 0, 0, Width, Height / 2);

            DrawBorders(new Pen(Color.FromArgb(216, 70, 70)), 1);
            G.DrawLine(new Pen(Color.FromArgb(151, 36, 36)), (Width / 5) + 7, 1, (Width / 5) + 7, Height - 1);
            G.DrawLine(new Pen(Color.FromArgb(64, 64, 64)), (Width / 5) + 8, 1, (Width / 5) + 8, Height - 1);
            G.DrawLine(new Pen(Color.FromArgb(87, 87, 87)), (Width / 5) + 8, 1, Width, 1);
            G.DrawLine(new Pen(Color.FromArgb(87, 87, 87)), Width - 2, 1, Width - 2, Height - 1);
            G.DrawLine(new Pen(Color.FromArgb(87, 87, 87)), (Width / 5) + 8, Height - 2, Width, Height - 2);
            DrawBorders(Pens.Black);
            DrawCorners(BackColor);

            if (State == MouseState.Over)
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), (Width / 5) + 8, 0, Width, Height);
                DrawBorders(new Pen(Color.FromArgb(216, 70, 70)), 1);
                G.DrawLine(new Pen(Color.FromArgb(151, 36, 36)), (Width / 5) + 7, 1, (Width / 5) + 7, Height - 1);
                G.DrawLine(new Pen(Color.FromArgb(64, 64, 64)), (Width / 5) + 8, 1, (Width / 5) + 8, Height - 1);
                G.DrawLine(new Pen(Color.FromArgb(87, 87, 87)), (Width / 5) + 8, 1, Width, 1);
                G.DrawLine(new Pen(Color.FromArgb(87, 87, 87)), Width - 2, 1, Width - 2, Height - 1);
                G.DrawLine(new Pen(Color.FromArgb(87, 87, 87)), (Width / 5) + 8, Height - 2, Width, Height - 2);
                DrawBorders(Pens.Black);
            }
            else if (State == MouseState.Down)
            {
                DrawGradient(Color.FromArgb(45, 45, 45), Color.FromArgb(0, 0, 0), (Width / 5) + 8, 0, Width, Height);
                G.FillRectangle(new SolidBrush(Color.FromArgb(15, Color.White)), (Width / 5) + 8, 0, Width, Height / 2);
                DrawBorders(new Pen(Color.FromArgb(216, 70, 70)), 1);
                G.DrawLine(new Pen(Color.FromArgb(151, 36, 36)), (Width / 5) + 7, 1, (Width / 5) + 7, Height - 1);
                G.DrawLine(new Pen(Color.FromArgb(64, 64, 64)), (Width / 5) + 8, 1, (Width / 5) + 8, Height - 1);
                G.DrawLine(new Pen(Color.FromArgb(87, 87, 87)), (Width / 5) + 8, 1, Width, 1);
                G.DrawLine(new Pen(Color.FromArgb(87, 87, 87)), Width - 2, 1, Width - 2, Height - 1);
                G.DrawLine(new Pen(Color.FromArgb(87, 87, 87)), (Width / 5) + 8, Height - 2, Width, Height - 2);
                DrawBorders(Pens.Black);
            }
            else
            {
            }

            DrawText(Brushes.White, HorizontalAlignment.Center, 8, 0);
        }
    }


}

