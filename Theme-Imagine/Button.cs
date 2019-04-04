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

namespace Zeroit.Framework.UIThemes.Newer
{
    public class ImagineButton : ThemeControl154
    {

        Color BG;
        public ImagineButton()
        {
            SetColor("BG", 12, 27, 74);
            BackColor = GetColor("BG");
        }

        protected override void ColorHook()
        {
            BG = GetColor("BG");
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            if (State == MouseState.Down)
            {
                DrawGradient(Color.FromArgb(25, Color.Black), Color.FromArgb(5, Color.White), ClientRectangle);
                DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
                DrawBorders(Pens.Black, ClientRectangle);
            }
            else if (State == MouseState.None)
            {
                DrawGradient(Color.FromArgb(25, Color.White), Color.FromArgb(5, Color.White), ClientRectangle);
                DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
                DrawBorders(Pens.Black, ClientRectangle);
            }
            else if (State == MouseState.Over)
            {
                DrawGradient(Color.FromArgb(40, Color.White), Color.FromArgb(10, Color.White), ClientRectangle);
                DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
                DrawBorders(Pens.Black, ClientRectangle);
            }
        }
    }

}

