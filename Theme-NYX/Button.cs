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
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.NYX
{
    public class NYXButton : ThemeControl154
    {
        //Coded by HΛWK

        public NYXButton()
        {
            Cursor = Cursors.Hand;
            Size = new Size(100, 25);
            Font = new Font("Arial", 8);
        }

        protected override void ColorHook()
        {
        }

        //Coded by HΛWK
        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(30, 30, 30));
            //Background
            ColorBlend bg_cblend = new ColorBlend(3);
            bg_cblend.Colors[0] = Color.FromArgb(150, 10, 10);
            bg_cblend.Colors[1] = Color.FromArgb(90, 10, 10);
            bg_cblend.Colors[2] = Color.FromArgb(120, 10, 10);
            bg_cblend.Positions = new float[]{
            0,
            0.6f,
            1
        };
            DrawGradient(bg_cblend, new Rectangle(1, 1, Width - 2, Height - 2));
            //MouseState
            Point[] backPoints = {
            new Point(0, 1),
            new Point(1, 0),
            new Point(Width - 2, 0),
            new Point(Width - 1, 1),
            new Point(Width - 1, Height - 2),
            new Point(Width - 2, Height - 1),
            new Point(1, Height - 1),
            new Point(0, Height - 2)
        };
            Rectangle innerRect = new Rectangle(1, 1, Width - 2, Height - 2);
            switch (State)
            {
                case MouseState.None:
                    DrawGradient(bg_cblend, new Rectangle(1, 1, Width - 2, Height - 2));
                    G.DrawPolygon(Pens.Black, backPoints);
                    break;
                case MouseState.Over:
                    DrawGradient(bg_cblend, new Rectangle(1, 1, Width - 2, Height - 2));
                    G.FillRectangle(new SolidBrush(Color.FromArgb(10, Color.White)), innerRect);
                    G.DrawPolygon(Pens.WhiteSmoke, backPoints);
                    break;
                case MouseState.Down:
                    DrawGradient(bg_cblend, new Rectangle(1, 1, Width - 2, Height - 2));
                    G.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), innerRect);
                    G.DrawPolygon(Pens.WhiteSmoke, backPoints);
                    break;
            }
            int textWidth = (int)this.CreateGraphics().MeasureString(Text, Font).Width;
            int textHeight = (int)this.CreateGraphics().MeasureString(Text, Font).Height;
            SolidBrush textShadow = new SolidBrush(Color.FromArgb(30, 15, 0));
            Rectangle textRect = new Rectangle(3, 3, textWidth + 10, textHeight);
            Point textPoint = new Point((Width / 2) - (textWidth / 2), (Height / 2) - (textHeight / 2));
            Point textShadowPoint = new Point((Width / 2) - (textWidth / 2) + 1, (Height / 2) - (textHeight / 2) + 1);
            G.DrawString(Text, Font, textShadow, textShadowPoint);
            G.DrawString(Text, Font, Brushes.WhiteSmoke, textPoint);
        }
    }

}

