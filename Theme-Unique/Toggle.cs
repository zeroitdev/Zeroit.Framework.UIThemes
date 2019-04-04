// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 06-04-2018
// ***********************************************************************
// <copyright file="Toggle.cs" company="Zeroit Dev Technologies">
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

    public class UniqueToggle : Control
    {
        private bool _check;
        public bool Checked
        {
            get
            {
                return _check;
            }
            set
            {
                _check = value;
                Invalidate();
            }
        }

        public UniqueToggle() : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Size = new Size(80, 25);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (!Checked)
            {
                Checked = true;
            }
            else
            {
                Checked = false;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            base.OnPaint(e);
            g.Clear(BackColor);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.FillPath(new SolidBrush(Color.FromArgb(52, 52, 52)), Draw.RoundRect(rect, 3));
            g.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(rect, 3));
            if (Checked)
            {
                g.FillPath(new SolidBrush(Color.FromArgb(72, 72, 72)), Draw.RoundRect(new Rectangle(Convert.ToInt32((Width / 2) - 2), 2, Convert.ToInt32((Width / 2) - 1), Height - 5), 3));
                g.DrawString("ON", new Font("Verdana", 10F, FontStyle.Bold), new SolidBrush(Color.FromArgb(255, 255, 255)), new Rectangle(0, 5, Convert.ToInt32((Width / 2)), 15), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                g.DrawLine(new Pen(Color.Black), 56, 5, 56, Height - 7);
                g.DrawLine(new Pen(Color.Black), 58, 3, 58, Height - 5);
                g.DrawLine(new Pen(Color.Black), 60, 5, 60, Height - 7);
            }
            else
            {
                g.FillPath(new SolidBrush(Color.FromArgb(72, 72, 72)), Draw.RoundRect(new Rectangle(2, 2, Convert.ToInt32((Width / 2) - 1), Height - 5), 3));
                g.DrawString("OFF", new Font("Verdana", 10F, FontStyle.Bold), new SolidBrush(Color.FromArgb(255, 255, 255)), new Rectangle(Convert.ToInt32((Width / 2)), 5, Convert.ToInt32((Width / 2)), 15), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                g.DrawLine(new Pen(Color.Black), 20, 5, 20, Height - 7);
                g.DrawLine(new Pen(Color.Black), 22, 3, 22, Height - 5);
                g.DrawLine(new Pen(Color.Black), 24, 5, 24, Height - 7);
            }
            e.Graphics.DrawImage(b, new Point(0, 0));
            g.Dispose();
            b.Dispose();
        }
    }
}