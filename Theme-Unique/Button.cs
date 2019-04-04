// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 06-04-2018
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Text;


namespace Zeroit.Framework.UIThemes.Unique
{

    public class UniqueButton : Control
    {
        private MouseState _state;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _state = MouseState.Down;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _state = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _state = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _state = MouseState.None;
            Invalidate();
        }

        public UniqueButton()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Size = new Size(150, 30);
            _state = MouseState.None;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            Font btnfont = new Font("Verdana", 10F, FontStyle.Regular);
            base.OnPaint(e);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.Clear(BackColor);
            LinearGradientBrush buttonrect = new LinearGradientBrush(rect, Color.FromArgb(56, 68, 85), Color.FromArgb(41, 42, 46), LinearGradientMode.Vertical);
            g.FillPath(buttonrect, Draw.RoundRect(rect, 3));
            g.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(rect, 3));
            switch (_state)
            {
                case MouseState.None:
                    LinearGradientBrush buttonrectnone = new LinearGradientBrush(rect, Color.FromArgb(56, 68, 85), Color.FromArgb(41, 42, 46), LinearGradientMode.Vertical);
                    g.FillPath(buttonrectnone, Draw.RoundRect(rect, 3));
                    g.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(rect, 3));
                    g.DrawString(Text, btnfont, Brushes.White, new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    break;
                case MouseState.Down:
                    LinearGradientBrush buttonrectdown = new LinearGradientBrush(rect, Color.FromArgb(76, 88, 105), Color.FromArgb(61, 62, 66), LinearGradientMode.Vertical);
                    g.FillPath(buttonrectdown, Draw.RoundRect(rect, 3));
                    g.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(rect, 3));
                    g.DrawString(Text, btnfont, Brushes.White, new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    break;
                case MouseState.Over:
                    LinearGradientBrush buttonrectover = new LinearGradientBrush(rect, Color.FromArgb(66, 78, 95), Color.FromArgb(51, 52, 56), LinearGradientMode.Vertical);
                    g.FillPath(buttonrectover, Draw.RoundRect(rect, 3));
                    g.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(rect, 3));
                    g.DrawString(Text, btnfont, Brushes.White, new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    break;
            }
            e.Graphics.DrawImage(b, new Point(0, 0));
            g.Dispose();
            b.Dispose();
        }
    }

}