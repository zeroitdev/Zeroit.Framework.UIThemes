﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ProgressButton.cs" company="Zeroit Dev Technologies">
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

    public class ButterscotchProgressButton : Control
    {
        MouseState _state;
        private int _val;
        public int Value
        {
            get { return _val; }
            set
            {
                if (value > _max)
                {
                    _val = _max;
                }
                else if (value < 0)
                {
                    _val = 0;
                }
                else
                {
                    _val = value;
                }
                Invalidate();
            }
        }

        private int _max;
        public int Maximum
        {
            get { return _max; }
            set
            {
                if (value < 1)
                {
                    _max = 1;
                }
                else
                {
                    _max = value;
                }
                if (value < _val)
                {
                    _val = _max;
                }
                Invalidate();
            }
        }

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
        public ButterscotchProgressButton()
            : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Size = new Size(160, 50);
            DoubleBuffered = true;
            _max = 100;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            int percent = Convert.ToInt32((Width - 1) * (_val / _max));
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle innerrect = new Rectangle(3, 3, Width - 7, Height - 7);
            Rectangle progressinnerrect = new Rectangle(4, 4, percent - 9, Height - 9);
            Font btnfont = new Font("Segoe UI", 10, FontStyle.Regular);
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
            if (percent != 0)
            {
                LinearGradientBrush progressgb = new LinearGradientBrush(progressinnerrect, Color.FromArgb(91, 82, 73), Color.FromArgb(57, 52, 46), 180);
                g.FillPath(progressgb, Draw.RoundRect(progressinnerrect, 3));
                g.DrawPath(new Pen(Color.FromArgb(0, 0, 0)), Draw.RoundRect(progressinnerrect, 3));
                g.DrawString(Text, btnfont, Brushes.White, innerrect, new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }
            e.Graphics.DrawImage(b, new Point(0, 0));
            g.Dispose();
            b.Dispose();
        }
    }


}