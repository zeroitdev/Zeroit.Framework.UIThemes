// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="RoundButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Redemption
{
    public class RedemptionRoundButton : Control
    {
        MouseState MouseState = MouseState.None;
        public enum HorizontalAlignment : byte
        {
            Left,
            Center,
            Right
        }
        private HorizontalAlignment _TextAlign = HorizontalAlignment.Center;
        public HorizontalAlignment TextAlign
        {
            get { return _TextAlign; }
            set
            {
                _TextAlign = value;
                Invalidate();
            }
        }

        public RedemptionRoundButton() : base()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Font = new Font("Arial", 8.25f, FontStyle.Bold);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            int curve = 13;
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            base.OnPaint(e);
            if (Enabled)
            {
                g.Clear(BackColor);
                switch (MouseState)
                {
                    case MouseState.None:
                        LinearGradientBrush MainBody = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(131, 198, 240), Color.FromArgb(24, 121, 218), 90);
                        g.FillPath(MainBody, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), curve));
                        LinearGradientBrush GlossPen = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(145, 212, 254), Color.Transparent, 90);
                        g.DrawPath(new Pen(GlossPen), Draw.RoundRect(new Rectangle(0, 1, Width - 1, Height - 2), curve + 1));
                        break;
                    case MouseState.Over:
                        LinearGradientBrush MainBody1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(150, 203, 235), Color.FromArgb(35, 135, 220), 90);
                        g.FillPath(MainBody1, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), curve));
                        LinearGradientBrush GlossPen1 = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 3), Color.FromArgb(173, 226, 255), Color.FromArgb(54, 155, 235), 90);
                        g.DrawPath(new Pen(GlossPen1), Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), curve));
                        break;
                    case MouseState.Down:
                        LinearGradientBrush MainBody2 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(30, 121, 210), Color.FromArgb(84, 172, 236), 90);
                        g.FillPath(MainBody2, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), curve));
                        LinearGradientBrush GlossPen2 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(54, 145, 234), Color.Transparent, 90);
                        g.DrawPath(new Pen(GlossPen2), Draw.RoundRect(new Rectangle(0, 1, Width - 1, Height - 1), curve + 1));
                        break;
                }
                g.DrawPath(new Pen(Color.FromArgb(21, 38, 56)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), curve));
                g.FillRectangle(new SolidBrush(Parent.BackColor), new Rectangle(-1, -1, 2, 10));
                g.FillRectangle(new SolidBrush(Parent.BackColor), new Rectangle(-2, -1, 4, 9));

            }
            else
            {
            }


            StringFormat sf = new StringFormat();
            switch (TextAlign)
            {
                case HorizontalAlignment.Center:
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(16, 20, 21)), new Rectangle(1, 2, Width - 1, Height - 1), sf);
                    g.DrawString(Text, Font, Brushes.White, new Rectangle(0, 1, Width - 1, Height - 1), sf);
                    break;
                case HorizontalAlignment.Left:
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Center;
                    g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(16, 20, 21)), new Rectangle(6, 2, Width - 1, Height - 1), sf);
                    g.DrawString(Text, Font, Brushes.White, new Rectangle(5, 1, Width - 1, Height - 1), sf);
                    break;
                case HorizontalAlignment.Right:
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Center;
                    g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(16, 20, 21)), new Rectangle(-3, 2, Width - 1, Height - 1), sf);
                    g.DrawString(Text, Font, Brushes.White, new Rectangle(-4, 1, Width - 1, Height - 1), sf);
                    break;
            }


            e.Graphics.DrawImage(b, new Point(0, 0));
            g.Dispose();
            b.Dispose();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            if (Enabled)
            {
                base.OnMouseEnter(e);
                MouseState = MouseState.Over;
                Invalidate();
                Cursor = Cursors.Hand;
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (Enabled)
            {
                base.OnMouseDown(e);
                MouseState = MouseState.Down;
                Invalidate();
                Cursor = Cursors.Hand;
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (Enabled)
            {
                base.OnMouseUp(e);
                MouseState = MouseState.Over;
                Invalidate();
                Cursor = Cursors.Hand;
            }
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            if (Enabled)
            {
                base.OnMouseLeave(e);
                MouseState = MouseState.None;
                Invalidate();
                Cursor = Cursors.Default;
            }
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
    }

}

