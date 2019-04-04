// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="RedButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Booster
{

    public class BoosterRedButton : ThemeControl154
    {
        public BoosterRedButton()
        {
            Transparent = true;
            BackColor = Color.Transparent;
        }

        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            DrawGradient(Color.FromArgb(175, 26, 26), Color.FromArgb(124, 0, 0), 0, 0, Width, Height);
            DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
            G.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), 0, 0, Width, Height / 2);
            DrawBorders(new Pen(Color.FromArgb(105, 0, 0)), 0);
            DrawBorders(new Pen(Color.FromArgb(199, 26, 26)), 1);


            if (State == MouseState.Over)
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), 0, 0, Width, Height);
            }
            else if (State == MouseState.Down)
            {
                DrawGradient(Color.FromArgb(45, 45, 45), Color.FromArgb(0, 0, 0), 0, 0, Width, Height);
                DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
                G.FillRectangle(new SolidBrush(Color.FromArgb(15, Color.White)), 0, 0, Width, Height / 2);
                DrawBorders(Pens.Black);
                DrawBorders(new Pen(Color.FromArgb(73, 73, 73)), 1);
            }
            else
            {
            }


            DrawCorners(BackColor);
        }
    }


}

