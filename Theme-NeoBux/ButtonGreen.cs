// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ButtonGreen.cs" company="Zeroit Dev Technologies">
//     Copyright � Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.NeoBux
{
    public class clsButtonGreen : ThemeControl154
    {

        Brush TextColor;

        Pen Border;
        public clsButtonGreen()
        {
            SetColor("Text", Color.WhiteSmoke);
            SetColor("Border", Color.DarkGray);
        }

        protected override void ColorHook()
        {
            TextColor = GetBrush("Text");
            Border = GetPen("Border");
        }

        protected override void PaintHook()
        {
            DrawCorners(Color.Fuchsia);
            G.Clear(BackColor);
            switch (State)
            {
                case MouseState.None:
                    LinearGradientBrush LGB1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(23, 178, 23), Color.FromArgb(1, 156, 1), 90f);

                    G.SmoothingMode = SmoothingMode.HighQuality;
                    G.FillPath(LGB1, CreateRound(0, 1, Width - 1, Height - 2, 3));
                    G.DrawPath(new Pen(Color.FromArgb(0, 124, 0)), CreateRound(0, 0, Width - 1, Height - 1, 5));

                    DrawText(TextColor, HorizontalAlignment.Center, 0, 0);

                    break;

                case MouseState.Over:
                    LinearGradientBrush LGBO1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(49, 188, 49), Color.FromArgb(26, 180, 26), 90f);

                    G.SmoothingMode = SmoothingMode.HighQuality;
                    G.FillPath(LGBO1, CreateRound(0, 1, Width - 1, Height - 2, 3));
                    G.DrawPath(new Pen(Color.FromArgb(0, 124, 0)), CreateRound(0, 0, Width - 1, Height - 1, 5));

                    DrawText(TextColor, HorizontalAlignment.Center, 0, 0);

                    break;
                case MouseState.Down:
                    LinearGradientBrush LGBD1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(49, 188, 49), Color.FromArgb(26, 180, 26), 90f);

                    G.SmoothingMode = SmoothingMode.HighQuality;
                    G.FillPath(LGBD1, CreateRound(0, 1, Width - 1, Height - 2, 3));
                    G.DrawPath(new Pen(Color.FromArgb(0, 124, 0)), CreateRound(0, 0, Width - 1, Height - 1, 5));

                    DrawText(TextColor, HorizontalAlignment.Center, 0, 1);
                    break;
            }
        }
    }

}

