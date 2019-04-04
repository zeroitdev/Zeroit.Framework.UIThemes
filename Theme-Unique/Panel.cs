﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 06-04-2018
// ***********************************************************************
// <copyright file="Panel.cs" company="Zeroit Dev Technologies">
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

    public class UniquePanel : ContainerControl
    {
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        public UniquePanel() : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Size = new Size(240, 160);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            Rectangle outerrect = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle innerrect = new Rectangle(3, 3, Width - 7, Height - 7);
            base.OnPaint(e);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.Clear(BackColor);
            g.FillPath(new SolidBrush(Color.FromArgb(89, 87, 85)), Draw.RoundRect(outerrect, 3));
            g.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(outerrect, 3));
            g.FillPath(new SolidBrush(Color.FromArgb(52, 52, 52)), Draw.RoundRect(innerrect, 3));
            g.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(innerrect, 3));
            e.Graphics.DrawImage(b, new Point(0, 0));
            g.Dispose();
            b.Dispose();
        }
    }
}