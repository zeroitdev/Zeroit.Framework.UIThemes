// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Seperator.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.Morphic
{
    public class MorphicSeparator : Control
    {
        private Graphics g;

        private Color _lineColor;
        private int _intensity = 40;

        public Color LineColor
        {
            get
            {
                return _lineColor;
            }
            set
            {
                _lineColor = value;
                Invalidate();
            }
        }

        public int Intensity
        {
            get
            {
                return _intensity;
            }
            set
            {
                _intensity = value;
                Invalidate();
            }
        }

        public MorphicSeparator()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            Size = new Size(260, 9);
            LineColor = Color.White;
        }

        protected override void CreateHandle()
        {
            Font = new Font(Preferences.FontFamily, Font.Size);
            base.CreateHandle();
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Parent.BackColor);

            Point p1 = new Point(0, (Height - 1) / 2);
            Point p2 = new Point(Width - 1, (Height - 1) / 2);

            ColorBlend lineBlend = new ColorBlend(3);
            lineBlend.Colors = new[] { Color.Transparent, Color.FromArgb(_intensity, _lineColor), Color.Transparent };
            lineBlend.Positions = new[] { 0.0F, 0.5F, 1.0F };

            LinearGradientBrush lineBrush = new LinearGradientBrush(p1, p2, Color.Transparent, Color.Transparent);
            lineBrush.InterpolationColors = lineBlend;

            g.DrawLine(new Pen(lineBrush), p1, p2);

        }

    }
}
