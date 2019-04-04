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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.NeSeal
{
    public class NSButton : Control
    {

        public NSButton()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            P1 = new Pen(Color.FromArgb(24, 24, 24));
            P2 = new Pen(Color.FromArgb(65, 65, 65));
        }


        private bool IsMouseDown;
        private GraphicsPath GP1;

        private GraphicsPath GP2;
        private SizeF SZ1;

        private PointF PT1;
        private Pen P1;

        private Pen P2;
        private PathGradientBrush PB1;

        private LinearGradientBrush GB1;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            ThemeModule theme = new ThemeModule();


            theme.G = e.Graphics;
            theme.G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            theme.G.Clear(BackColor);
            theme.G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = theme.CreateRound(0, 0, Width - 1, Height - 1, 7);
            GP2 = theme.CreateRound(1, 1, Width - 3, Height - 3, 7);

            if (IsMouseDown)
            {
                PB1 = new PathGradientBrush(GP1);
                PB1.CenterColor = Color.FromArgb(60, 60, 60);
                PB1.SurroundColors = new Color[] { Color.FromArgb(55, 55, 55) };
                PB1.FocusScales = new PointF(0.8f, 0.5f);

                theme.G.FillPath(PB1, GP1);
            }
            else
            {
                GB1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90f);
                theme.G.FillPath(GB1, GP1);
            }

            theme.G.DrawPath(P1, GP1);
            theme.G.DrawPath(P2, GP2);

            SZ1 = theme.G.MeasureString(Text, Font);
            PT1 = new PointF(5, Height / 2 - SZ1.Height / 2);

            if (IsMouseDown)
            {
                PT1.X += 1f;
                PT1.Y += 1f;
            }

            theme.G.DrawString(Text, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1);
            theme.G.DrawString(Text, Font, Brushes.WhiteSmoke, PT1);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            IsMouseDown = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            IsMouseDown = false;
            Invalidate();
        }

    }

}


