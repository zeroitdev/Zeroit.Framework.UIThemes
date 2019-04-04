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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Doom
{
    public class DoomButton : ThemeControl154
    {

        Brush TextColor;

        Pen Border;
        public DoomButton()
        {
            SetColor("Text", Color.Red);
            SetColor("Border", Color.Black);
            Font = new Font("Arial", 9);
        }

        protected override void ColorHook()
        {
            TextColor = GetBrush("Text");
            Border = GetPen("Border");
        }

        protected override void PaintHook()
        {
            G.Clear(Color.Black);
            G.DrawRectangle(Border, new Rectangle(0, 0, Width - 3, Height - 1));
            switch (State)
            {
                case MouseState.None:
                    LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(8, 20, Width - 10, Height - 8), Color.FromArgb(24, 24, 24), Color.FromArgb(15, 15, 15), 75f);
                    G.FillRectangle(LGB, new Rectangle(1, 1, Width - 2, Height - 2));
                    DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                    break;
                case MouseState.Over:
                    LinearGradientBrush LGB1 = new LinearGradientBrush(new Rectangle(8, 30, Width - 10, Height - 8), Color.FromArgb(24, 24, 24), Color.FromArgb(15, 15, 15), 75f);
                    G.FillRectangle(LGB1, new Rectangle(1, 1, Width - 2, Height - 2));
                    DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                    break;
                case MouseState.Down:
                    LinearGradientBrush LGB2 = new LinearGradientBrush(new Rectangle(8, 70, Width - 10, Height - 8), Color.FromArgb(30, 192, 0, 0), Color.FromArgb(70, 192, 0, 0), 75f);
                    G.FillRectangle(LGB2, new Rectangle(1, 1, Width - 2, Height - 2));
                    DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                    break;
            }
            DrawCorners(Color.Transparent, 0);
        }
    }


}

