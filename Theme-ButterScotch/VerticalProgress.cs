// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="VerticalProgress.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Butter
{
    public class ButterscotchVerticalProgressBar : Control
    {
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

        private bool _showPercentage = false;
        public bool ShowPercentage
        {
            get { return _showPercentage; }
            set
            {
                _showPercentage = value;
                Invalidate();
            }
        }

        public ButterscotchVerticalProgressBar()
            : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Size = new Size(20, 250);
            DoubleBuffered = true;
            _max = 100;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            int percent = Convert.ToInt32((Height - 1) * (_val / _max));
            Rectangle outerrect = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle maininnerrect = new Rectangle(7, 7, Width - 15, Height - 15);
            Rectangle innerrect = new Rectangle(4, (Height - percent) + 4, Width - 9, percent - 9);
            base.OnPaint(e);
            g.Clear(BackColor);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillPath(new SolidBrush(Color.FromArgb(40, 37, 33)), Draw.RoundRect(outerrect, 5));
            g.DrawPath(new Pen(Color.FromArgb(0, 0, 0)), Draw.RoundRect(outerrect, 5));
            g.FillPath(new SolidBrush(Color.FromArgb(26, 25, 21)), Draw.RoundRect(maininnerrect, 3));
            g.DrawPath(new Pen(Color.FromArgb(0, 0, 0)), Draw.RoundRect(maininnerrect, 3));
            if (percent != 0)
            {
                try
                {
                    LinearGradientBrush progressgb = new LinearGradientBrush(innerrect, Color.FromArgb(91, 82, 73), Color.FromArgb(57, 52, 46), 90);
                    g.FillPath(progressgb, Draw.RoundRect(innerrect, 7));
                }
                catch
                {
                }
            }
            if (_showPercentage)
            {
                g.DrawString(string.Format("{0}%", _val), new Font("Segoe UI", 8, FontStyle.Bold), new SolidBrush(Color.FromArgb(246, 180, 12)), outerrect, new StringFormat
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
