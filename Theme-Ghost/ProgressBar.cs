// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
//     Copyright � Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Ghost
{
    public class GhostProgressbar : ThemeControl154
    {
        private int _Maximum = 100;
        private int _Value;
        private int HOffset = 0;
        private int Progress;

        protected override void ColorHook()
        {
        }

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
        public bool Animated
        {
            get { return IsAnimated; }
            set
            {
                IsAnimated = value;
                Invalidate();
            }
        }

        protected override void OnAnimation()
        {
            HOffset -= 1;
            if (HOffset == 7)
                HOffset = 0;
        }

        protected override void PaintHook()
        {
            HatchBrush hatch = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(60, Color.Black));
            G.Clear(Color.FromArgb(0, 30, 30, 30));
            ColorBlend cblend = new ColorBlend(2);
            cblend.Colors[0] = Color.FromArgb(50, 50, 50);
            cblend.Colors[1] = Color.FromArgb(70, 70, 70);
            cblend.Positions[0] = 0;
            cblend.Positions[1] = 1;
            DrawGradient(cblend, new Rectangle(0, 0, Convert.ToInt32(((Width / _Maximum) * _Value) - 2), Height - 2));
            cblend.Colors[1] = Color.FromArgb(80, 80, 80);
            DrawGradient(cblend, new Rectangle(0, 0, Convert.ToInt32(((Width / _Maximum) * _Value) - 2), Height / 5 * 2));
            G.RenderingOrigin = new Point(HOffset, 0);
            hatch = new HatchBrush(HatchStyle.ForwardDiagonal, Color.FromArgb(40, Color.Black), Color.FromArgb(0, Color.Gray));
            G.FillRectangle(hatch, 0, 0, Convert.ToInt32(((Width / _Maximum) * _Value) - 2), Height - 2);
            DrawBorders(Pens.Black);
            DrawBorders(new Pen(Color.FromArgb(90, 90, 90)), 1);
            DrawCorners(Color.Black);
            G.DrawLine(new Pen(Color.FromArgb(200, 90, 90, 90)), Convert.ToInt32(((Width / _Maximum) * _Value) - 2), 1, Convert.ToInt32(((Width / _Maximum) * _Value) - 2), Height - 2);
            G.DrawLine(Pens.Black, Convert.ToInt32(((Width / _Maximum) * _Value) - 2) + 1, 2, Convert.ToInt32(((Width / _Maximum) * _Value) - 2) + 1, Height - 3);
            Progress = Convert.ToInt32(((Width / _Maximum) * _Value));
            ColorBlend cblend2 = new ColorBlend(3);
            cblend2.Colors[0] = Color.FromArgb(0, Color.Gray);
            cblend2.Colors[1] = Color.FromArgb(80, Color.DimGray);
            cblend2.Colors[2] = Color.FromArgb(0, Color.Gray);
            cblend2.Positions = new float[]{
            0,
            0.5f,
            1
        };
            if (Value > 0)
                G.FillRectangle(new SolidBrush(Color.FromArgb(5, 5, 5)), Convert.ToInt32(((Width / _Maximum) * _Value)) - 1, 2, Width - Convert.ToInt32(((Width / _Maximum) * _Value)) - 1, Height - 4);
        }

        public GhostProgressbar()
        {
            _Maximum = 100;
            IsAnimated = true;
        }
    }

}