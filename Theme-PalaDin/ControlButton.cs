// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ControlButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Paladin
{
    public class PaladinControlButton : ThemeControl154
    {
        public PaladinControlButton()
        {
            Size = new Size(22, 21);
            MinimumSize = new Size(19, 20);
            MaximumSize = new Size(24, 23);
        }


        protected override void ColorHook()
        {
        }


        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(180, Color.Gainsboro));

            LinearGradientBrush HeaderLGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height / 2), Color.FromArgb(220, 220, 220), Color.FromArgb(180, 180, 180), 90);
            G.FillRectangle(HeaderLGB, 0, 0, Width, Height / 2);

            DrawBorders(new Pen(new SolidBrush(Color.FromArgb(130, 130, 130))), 1, 1, Width - 2, Height - 3);
            // up


            if (State == MouseState.Over)
            {
                G.Clear(Color.FromArgb(190, Color.Gainsboro));

                LinearGradientBrush HeaderLGB1 = new LinearGradientBrush(new Rectangle(0, 0, Width, Height / 2), Color.FromArgb(230, 230, 230), Color.FromArgb(190, 190, 190), 90);
                G.FillRectangle(HeaderLGB1, 0, 0, Width, Height / 2);

                DrawBorders(new Pen(new SolidBrush(Color.FromArgb(140, 140, 140))), 1, 1, Width - 2, Height - 3);
                // up

            }
            else if (State == MouseState.Down)
            {
                G.Clear(Color.FromArgb(175, Color.Gainsboro));

                LinearGradientBrush HeaderLGB1 = new LinearGradientBrush(new Rectangle(0, 0, Width, Height / 2), Color.FromArgb(215, 215, 215), Color.FromArgb(175, 175, 175), 90);
                G.FillRectangle(HeaderLGB1, 0, 0, Width, Height / 2);

                DrawBorders(new Pen(new SolidBrush(Color.FromArgb(125, 125, 125))), 1, 1, Width - 2, Height - 3);
                // up


            }

            DrawCorners(Color.FromArgb(160, 160, 160), 1, 1, Width - 2, Height - 3);
            DrawCorners(Color.FromArgb(200, 200, 200), 0, 0, Width, Height - 1);

            DrawText(new SolidBrush(Color.White), HorizontalAlignment.Center, 1, 1);
            DrawText(new SolidBrush(Color.Black), HorizontalAlignment.Center, 0, 0);
        }
    }

}

