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
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Hacker
{
    public class HackerProgressBar : ThemeControl154
    {
        private int _Maximum = 100;
        private int _Value;

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

        protected override void PaintHook()
        {
            G.Clear(Color.Black);
            //Border
            Rectangle left = new Rectangle(0, 0, 60, Height - 1);
            LinearGradientBrush leftLGB = new LinearGradientBrush(left, Color.FromArgb(255, 32, 32, 32), Color.FromArgb(100, Color.White), 180f);
            G.FillRectangle(leftLGB, left);
            Rectangle right = new Rectangle(Width - 61, 0, 60, Height - 1);
            LinearGradientBrush rightLGB = new LinearGradientBrush(right, Color.FromArgb(100, Color.White), Color.FromArgb(255, 32, 32, 32), 180f);
            G.FillRectangle(rightLGB, right);
            Rectangle middle = new Rectangle(60, 0, Width - 120, Height - 1);
            SolidBrush middleSB = new SolidBrush(Color.FromArgb(255, 32, 32, 32));
            G.FillRectangle(middleSB, middle);
            //Background
            Rectangle rect = new Rectangle(2, 2, Width - 4, Height - 4);
            HatchBrush backHB = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(255, 10, 10, 10), Color.FromArgb(255, 11, 11, 11));
            G.FillRectangle(backHB, rect);
            //Bar
            ColorBlend cblend = new ColorBlend(2);
            cblend.Colors[0] = Color.Lime;
            cblend.Colors[1] = Color.FromArgb(255, 8, 90, 8);
            cblend.Positions[0] = 0;
            cblend.Positions[1] = 1;
            DrawGradient(cblend, new Rectangle(2, 2, Convert.ToInt32(((Width / _Maximum) * _Value) - 4), Height - 4));
            //Border
            DrawBorders(Pens.Black, 0);
            DrawBorders(Pens.Black, 2);
        }

        public HackerProgressBar()
        {
            _Maximum = 100;
        }

    }

}


