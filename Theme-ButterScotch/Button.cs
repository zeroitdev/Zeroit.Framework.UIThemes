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
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Butter
{
    public class ButterscotchButton : Control
    {
        MouseState _state;
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

        public ButterscotchButton()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Size = new Size(160, 35);
            _state = MouseState.None;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle innerrect = new Rectangle(3, 3, Width - 7, Height - 7);
            Font btnfont = new Font("Verdana", 10, FontStyle.Regular);
            base.OnPaint(e);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.Clear(BackColor);
            LinearGradientBrush buttonrect = new LinearGradientBrush(rect, Color.FromArgb(100, 90, 80), Color.FromArgb(48, 43, 39), LinearGradientMode.Vertical);
            g.FillPath(new SolidBrush(Color.FromArgb(26, 25, 21)), Draw.RoundRect(rect, 3));
            g.FillPath(buttonrect, Draw.RoundRect(innerrect, 3));
            switch (_state)
            {
                case MouseState.None:
                    LinearGradientBrush buttonrectnone = new LinearGradientBrush(innerrect, Color.FromArgb(100, 90, 80), Color.FromArgb(48, 43, 39), LinearGradientMode.Vertical);
                    g.FillPath(new SolidBrush(Color.FromArgb(26, 25, 21)), Draw.RoundRect(rect, 3));
                    g.FillPath(buttonrectnone, Draw.RoundRect(innerrect, 3));
                    g.DrawString(Text, btnfont, Brushes.White, innerrect, new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Down:
                    LinearGradientBrush buttonrectdown = new LinearGradientBrush(innerrect, Color.FromArgb(48, 43, 39), Color.FromArgb(100, 90, 80), LinearGradientMode.Vertical);
                    g.FillPath(new SolidBrush(Color.FromArgb(26, 25, 21)), Draw.RoundRect(rect, 3));
                    g.FillPath(buttonrectdown, Draw.RoundRect(innerrect, 3));
                    g.DrawString(Text, btnfont, Brushes.White, innerrect, new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Over:
                    LinearGradientBrush buttonrectover = new LinearGradientBrush(innerrect, Color.FromArgb(48, 43, 39), Color.FromArgb(100, 90, 80), LinearGradientMode.Vertical);
                    g.FillPath(new SolidBrush(Color.FromArgb(26, 25, 21)), Draw.RoundRect(rect, 3));
                    g.FillPath(buttonrectover, Draw.RoundRect(innerrect, 3));
                    g.DrawString(Text, btnfont, Brushes.White, innerrect, new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
            }
            e.Graphics.DrawImage(b, new Point(0, 0));
            g.Dispose();
            b.Dispose();
        }
    }


}
