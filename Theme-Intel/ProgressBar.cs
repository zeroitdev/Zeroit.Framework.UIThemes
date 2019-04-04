// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Intel
{

    public class iProgBar : ThemeControl154
    {

        private int _Maximum = 100;
        private int _Value;

        private int Progress;
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 1)
                    value = 1;
                if (value < _Value)
                    _Value = value;
                _Maximum = value;
                Invalidate();
            }
        }
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum)
                    value = Maximum;
                _Value = value;
                Invalidate();
            }
        }

        public iProgBar()
        {
            Size = new Size(200, 25);
        }

        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(45, 45, 45));
            //Background
            ColorBlend bg_cblend = new ColorBlend(3);
            bg_cblend.Colors[0] = Color.FromArgb(30, 30, 30);
            bg_cblend.Colors[1] = Color.FromArgb(22, 22, 22);
            bg_cblend.Colors[2] = Color.FromArgb(30, 30, 30);
            bg_cblend.Positions = new float[]{
            0,
            0.5f,
            1
        };
            DrawGradient(bg_cblend, new Rectangle(1, 1, Width - 2, Height - 2));
            //Bar
            ColorBlend bar_cblend = new ColorBlend(3);
            bar_cblend.Colors[0] = Color.FromArgb(180, Color.DeepSkyBlue);
            bar_cblend.Colors[1] = Color.FromArgb(135, Color.DeepSkyBlue);
            bar_cblend.Colors[2] = bar_cblend.Colors[0];
            bar_cblend.Positions = new float[]{
            0,
            0.5f,
            1
        };
            DrawGradient(bar_cblend, new Rectangle(1, 1, Convert.ToInt32(((Width / _Maximum) * _Value) - 2), Height - 2));
            //Border
            Point[] borderPoints = {
            new Point(0, 2),
            new Point(2, 0),
            new Point(Width - 3, 0),
            new Point(Width - 1, 2),
            new Point(Width - 1, Height - 3),
            new Point(Width - 3, Height - 1),
            new Point(2, Height - 1),
            new Point(0, Height - 3)
        };
            G.DrawPolygon(Pens.Black, borderPoints);
        }
    }


}


