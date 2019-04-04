// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Preview
{
    public class PVButton : ThemedControl
    {
        public PVButton() : base()
        {
            Font = new Font("Trebuchet MS", 10.0F);
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);
            try
            {
                BackColor = this.Parent.BackColor;
            }
            catch (Exception ex)
            {
            }
            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.HighQuality;

            //| Drawing the button
            Rectangle ButtonRect = new Rectangle(0, 0, Width - 1, Height - 1);
            int Roundness = 4;
            if (Size.Width <= 30 && Size.Height <= 30)
            {
                Roundness = 2;
            }
            GraphicsPath ButtonPath = D.RoundRect(ButtonRect, Roundness);
            GraphicsPath ButtonHighlightPath = D.RoundRect(new Rectangle(ButtonRect.X, ButtonRect.Y + 1, ButtonRect.Width, ButtonRect.Height - 2), 4);
            switch (State)
            {
                case MouseState.None:
                    G.FillPath(new SolidBrush(Color.FromArgb(100, Pal.ColDim)), ButtonPath);
                    G.FillPath(new SolidBrush(Pal.ColDim), ButtonPath);
                    D.FillGradientBeam(G, Color.FromArgb(20, Color.Black), Color.FromArgb(20, Pal.ColHighest), ButtonRect, GradientAlignment.Vertical);
                    break;
                case MouseState.Over:
                    G.FillPath(new SolidBrush(Color.FromArgb(255, Pal.ColDim)), ButtonPath);
                    G.FillPath(new SolidBrush(Color.FromArgb(Pal.ColDim.R + 10, Pal.ColDim.G + 10, Pal.ColDim.B + 10)), ButtonPath);
                    D.FillGradientBeam(G, Color.FromArgb(20, Color.Black), Color.FromArgb(20, Pal.ColHighest), ButtonRect, GradientAlignment.Vertical);
                    break;
                case MouseState.Down:
                    G.FillPath(new SolidBrush(Color.FromArgb(70, Pal.ColDim)), ButtonPath);
                    G.FillPath(new SolidBrush(Pal.ColDim), ButtonPath);
                    G.FillPath(new SolidBrush(Color.FromArgb(50, Pal.ColDark)), ButtonPath);
                    D.FillGradientBeam(G, Color.FromArgb(35, Color.Black), Color.FromArgb(14, Pal.ColHighest), ButtonRect, GradientAlignment.Vertical);
                    break;
            }
            if (State == MouseState.Down)
            {
                ButtonHighlightPath = D.RoundRect(new Rectangle(ButtonRect.X, ButtonRect.Y + 1, ButtonRect.Width, ButtonRect.Height - 1), 4);
                G.DrawPath(new Pen(Color.FromArgb(100, Color.Black), 3F), ButtonHighlightPath);
                D.DrawTextWithShadow(G, ButtonRect, Text, Font, HorizontalAlignment.Center, Color.FromArgb(200, Pal.ColHighest), Color.Black);

            }
            else
            {
                G.DrawPath(new Pen(Color.FromArgb(60, Pal.ColHighest)), ButtonHighlightPath);
                D.DrawTextWithShadow(G, ButtonRect, Text, Font, HorizontalAlignment.Center, Color.FromArgb(120, Color.WhiteSmoke), Color.Black);

            }
            G.DrawPath(Pens.Black, ButtonPath);

        }
    }
}
