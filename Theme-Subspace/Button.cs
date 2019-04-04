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

namespace Zeroit.Framework.UIThemes.SubSpace
{
    public class SubspaceButton : ThemeControl154
    {

        public SubspaceButton()
        {
            Transparent = true;
            BackColor = Color.Transparent;
        }


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            DrawGradient(Color.FromArgb(25, 25, 25), Color.Black, 0, 0, Width, Height, 45);
            DrawText(Brushes.DodgerBlue, HorizontalAlignment.Center, 0, 0);
            G.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.White)), 0, 0, Width, Height / 2);
            DrawBorders(Pens.Black);
            DrawBorders(new Pen(Color.FromArgb(69, 71, 70)), 1);
            DrawGradient(Color.White, Color.FromArgb(69, 71, 70), 1, 1, Width / 2, 1, 360);
            DrawGradient(Color.White, Color.FromArgb(69, 71, 70), 1, 1, 1, Height / 2);
            DrawGradient(Color.White, Color.FromArgb(69, 71, 70), Width - 2, 1, 1, Height / 2, 270);
            DrawGradient(Color.White, Color.FromArgb(69, 71, 70), Width - 2, Height / 2, 1, Height / 2);

            if (State == MouseState.Over)
            {
                DrawGradient(Color.FromArgb(98, 192, 255), Color.FromArgb(59, 144, 255), 0, 0, Width, Height, 45);
                DrawBorders(new Pen(Color.FromArgb(0, 44, 190), 0));
                DrawBorders(new Pen(Color.FromArgb(84, 177, 255)), 1);
                DrawGradient(Color.White, Color.FromArgb(84, 177, 255), 1, 1, Width / 2, 1, 360);
                DrawGradient(Color.White, Color.FromArgb(84, 177, 255), 1, 1, 1, Height / 2);
                DrawText(Brushes.Black, HorizontalAlignment.Center, 0, 0);
                G.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.White)), 0, 0, Width, 13);
                DrawCorners(BackColor, 1);
            }
            else if (State == MouseState.Down)
            {
                DrawGradient(Color.FromArgb(84, 182, 255), Color.FromArgb(45, 134, 255), 0, 0, Width, Height, 45);
                DrawBorders(new Pen(Color.FromArgb(0, 44, 190), 0));
                DrawBorders(new Pen(Color.FromArgb(84, 177, 255)), 1);
                DrawGradient(Color.White, Color.FromArgb(84, 177, 255), 1, 1, Width / 2, 1, 360);
                DrawGradient(Color.White, Color.FromArgb(84, 177, 255), 1, 1, 1, Height / 2);
                DrawText(Brushes.Black, HorizontalAlignment.Center, 0, 0);
                G.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.White)), 0, 0, Width, 13);
                DrawCorners(BackColor, 1);
            }
            else
            {
            }

            DrawCorners(BackColor, 1);
        }
    }

}




