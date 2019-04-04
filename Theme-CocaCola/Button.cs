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

namespace Zeroit.Framework.UIThemes.Cola
{
    public class CCButton : ThemeControl151
    {


        protected override void ColorHook()
        {
        }


        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(192, 0, 0));
            DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
            DrawBorders(new Pen(new SolidBrush(Color.LightGray)));
            DrawBorders(new Pen(new SolidBrush(Color.RosyBrown)), 1);
            DrawCorners(Color.RosyBrown, ClientRectangle);
            if (State == MouseState.Over)
            {
                DrawBorders(new Pen(new SolidBrush(Color.Goldenrod)));
                DrawBorders(new Pen(new SolidBrush(Color.Goldenrod)), 1);
                DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
            }
            else if (State == MouseState.Down)
            {
                G.Clear(Color.FromArgb(204, 0, 5));
                DrawBorders(new Pen(new SolidBrush(Color.Gold)));
                DrawBorders(new Pen(new SolidBrush(Color.Gold)), 1);
                DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
            }


        }
    }


}

