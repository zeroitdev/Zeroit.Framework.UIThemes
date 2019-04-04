// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 06-04-2018
// ***********************************************************************
// <copyright file="Seperator.cs" company="Zeroit Dev Technologies">
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

    public class UniqueSeperator : Control
    {
        public enum Style
        {
            Horizontal,
            Verticle
        }

        private Style _alignment = Style.Horizontal;
        public Style Alignment
        {
            get
            {
                return _alignment;
            }
            set
            {
                _alignment = value;
            }
        }

        private bool _showInfo = false;
        public bool ShowInfo
        {
            get
            {
                return _showInfo;
            }
            set
            {
                _showInfo = value;
                Invalidate();
            }
        }

        public UniqueSeperator()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Size = new Size(40, 40);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            base.OnPaint(e);
            g.Clear(BackColor);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            switch (_alignment)
            {
                case Style.Horizontal:
                    g.DrawLine(new Pen(Color.FromArgb(89, 87, 85)), new Point(20, Convert.ToInt32((Height / 2)) - 2), new Point(Width - 20, Convert.ToInt32((Height / 2)) - 2));
                    g.DrawLine(new Pen(Color.FromArgb(89, 87, 85)), new Point(10, Convert.ToInt32((Height / 2)) - 1), new Point(Width - 10, Convert.ToInt32((Height / 2)) - 1));
                    g.DrawLine(new Pen(Color.FromArgb(89, 87, 85)), new Point(0, Convert.ToInt32((Height / 2))), new Point(Width, Convert.ToInt32((Height / 2))));
                    g.DrawLine(new Pen(Color.FromArgb(89, 87, 85)), new Point(10, Convert.ToInt32((Height / 2)) + 1), new Point(Width - 10, Convert.ToInt32((Height / 2)) + 1));
                    g.DrawLine(new Pen(Color.FromArgb(89, 87, 85)), new Point(20, Convert.ToInt32((Height / 2)) + 2), new Point(Width - 20, Convert.ToInt32((Height / 2)) + 2));
                    if (ShowInfo == true)
                    {
                        g.DrawString(Text, new Font("Verdana", 10F, FontStyle.Regular), new SolidBrush(Color.FromArgb(255, 255, 255)), new Rectangle(0, 0, Width - 1, Convert.ToInt32((Height / 2))), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    break;
                case Style.Verticle:
                    g.DrawLine(new Pen(Color.FromArgb(89, 87, 85)), new Point(Convert.ToInt32((Width / 2)) - 2, 20), new Point(Convert.ToInt32((Width / 2)) - 2, Height - 20));
                    g.DrawLine(new Pen(Color.FromArgb(89, 87, 85)), new Point(Convert.ToInt32((Width / 2)) - 1, 10), new Point(Convert.ToInt32((Width / 2)) - 1, Height - 10));
                    g.DrawLine(new Pen(Color.FromArgb(89, 87, 85)), new Point(Convert.ToInt32((Width / 2)), 0), new Point(Convert.ToInt32((Width / 2)), Height));
                    g.DrawLine(new Pen(Color.FromArgb(89, 87, 85)), new Point(Convert.ToInt32((Width / 2)) + 1, 10), new Point(Convert.ToInt32((Width / 2)) + 1, Height - 10));
                    g.DrawLine(new Pen(Color.FromArgb(89, 87, 85)), new Point(Convert.ToInt32((Width / 2)) + 2, 20), new Point(Convert.ToInt32((Width / 2)) + 2, Height - 20));
                    break;
            }
            e.Graphics.DrawImage(b, new Point(0, 0));
            g.Dispose();
            b.Dispose();
        }
    }

}