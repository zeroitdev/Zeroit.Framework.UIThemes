// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Header.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.XVisual
{

    public class xVisualHeader : ContainerControl
    {
        protected override void OnResize(EventArgs e)
        {
            Height = 32;
            base.OnResize(e);
        }

        public xVisualHeader()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(205, 205, 205);
            Size = new Size(174, 32);
            DoubleBuffered = true;
        }
        TextureBrush TopTexture = Draw.NoiseBrush(new Color[]{
        Color.FromArgb(49, 45, 41),
        Color.FromArgb(51, 47, 43),
        Color.FromArgb(47, 43, 39)
    });
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle BarRect = new Rectangle(0, 0, Width - 1, Height - 1);
            base.OnPaint(e);

            G.Clear(BackColor);

            G.SmoothingMode = SmoothingMode.HighQuality;

            LinearGradientBrush TopOverlay = new LinearGradientBrush(BarRect, Color.FromArgb(5, Color.White), Color.FromArgb(10, Color.White), 90);
            G.FillRectangle(TopTexture, BarRect);

            ColorBlend blend = new ColorBlend();

            //Add the Array of Color
            Color[] bColors = new Color[] {
            Color.FromArgb(20, Color.White),
            Color.FromArgb(10, Color.Black),
            Color.FromArgb(10, Color.White)
        };
            blend.Colors = bColors;

            //Add the Array Single (0-1) colorpoints to place each Color
            float[] bPts = new float[] {
            0,
            0.9f,
            1
        };
            blend.Positions = bPts;

            using (LinearGradientBrush br = new LinearGradientBrush(BarRect, Color.White, Color.Black, LinearGradientMode.Vertical))
            {

                //Blend the colors into the Brush
                br.InterpolationColors = blend;

                //Fill the rect with the blend
                G.FillRectangle(br, BarRect);

            }

            G.DrawRectangle(Pens.Black, BarRect);

            //// Top Bar Highlights
            G.DrawLine(Draw.GetPen(Color.FromArgb(112, 109, 107)), 1, 1, Width - 2, 1);
            G.DrawLine(Draw.GetPen(Color.FromArgb(67, 63, 60)), 1, BarRect.Height - 1, Width - 2, BarRect.Height - 1);


            Font drawFont = new Font("Arial", 9, FontStyle.Bold);
            G.DrawString(Text, drawFont, Brushes.White, new Rectangle(15, 3, Width - 1, 26), new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            });

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

}

