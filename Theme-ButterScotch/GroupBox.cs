﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
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
    public class ButterscotchGroupBox : ContainerControl
    {

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        public ButterscotchGroupBox()
            : base()
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
            Pen underlinepen = new Pen(Color.FromArgb(255, 255, 255), 2);
            base.OnPaint(e);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.Clear(BackColor);
            g.FillPath(new SolidBrush(Color.FromArgb(26, 25, 21)), Draw.RoundRect(outerrect, 3));
            LinearGradientBrush panelgb = new LinearGradientBrush(innerrect, Color.FromArgb(100, 90, 80), Color.FromArgb(48, 43, 39), 90);
            g.FillPath(panelgb, Draw.RoundRect(innerrect, 3));
            g.DrawString(Text, new Font("Segoe UI", 11, FontStyle.Bold), new SolidBrush(Color.FromArgb(255, 255, 255)), new Rectangle(0, 3, Width - 1, 30), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });
            g.DrawLine(underlinepen, 20, 30, Width - 21, 30);
            e.Graphics.DrawImage(b, new Point(0, 0));
            g.Dispose();
            b.Dispose();
        }
    }


}
