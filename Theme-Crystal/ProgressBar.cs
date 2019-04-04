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

namespace Zeroit.Framework.UIThemes.Crystal
{
    public class CrystalClearProgressBar : ThemeControl154
    {

        Color G1;
        Color G2;
        Color Glow;
        Color Edge;

        int GlowPosition;
        private int _Minimum;
        public int Minimum
        {
            get { return _Minimum; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Minimum = value;
                if (value > _Value)
                    _Value = value;
                if (value > _Maximum)
                    _Maximum = value;
                Invalidate();
            }
        }

        private int _Maximum = 100;
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Maximum = value;
                if (value < _Value)
                    _Value = value;
                if (value < _Minimum)
                    _Minimum = value;
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

        private int _Value;
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum || value < _Minimum)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Value = value;
                Invalidate();
            }
        }

        private void Increment(int amount)
        {
            Value += amount;
        }

        public CrystalClearProgressBar()
        {
            SetColor("Gradient 1", 230, 230, 230);
            SetColor("Gradient 2", 210, 210, 210);
            SetColor("Glow", 230, 230, 230);
            SetColor("Edge", 170, 170, 170);
            IsAnimated = true;

        }

        protected override void ColorHook()
        {
            G1 = GetColor("Gradient 1");
            G2 = GetColor("Gradient 2");
            Glow = GetColor("Glow");
            Edge = GetColor("Edge");
        }

        protected override void OnAnimation()
        {
            if (GlowPosition == 0)
            {
                GlowPosition = 7;
            }
            else
            {
                GlowPosition -= 1;
            }
        }

        protected override void PaintHook()
        {
            G.Clear(G1);
            LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(new Point(1, 1), new Size(Width - 2, Height - 2)), G1, G2, 90f);
            G.FillRectangle(LGB, new Rectangle(new Point(1, 1), new Size((Width / Maximum) * Value - 1, Height - 2)));
            G.FillRectangle(new SolidBrush(Glow), new Rectangle(new Point(1, 1), new Size((Width / Maximum) * Value - 1, (Height / 2) - 3)));

            G.RenderingOrigin = new Point(GlowPosition, 0);
            HatchBrush HB = new HatchBrush(HatchStyle.ForwardDiagonal, Color.FromArgb(20, Color.Black), Color.Transparent);
            G.FillRectangle(HB, new Rectangle(new Point(1, 2), new Size((Width / Maximum) * Value - 1, Height - 3)));

            G.DrawLine(new Pen(Edge), new Point((Width / Maximum) * Value - 1, 1), new Point((Width / Maximum) * Value - 1, Height - 1));
            G.DrawRectangle(new Pen(Edge), new Rectangle(new Point(1, 1), new Size(Width - 2, Height - 2)));
        }

    }

}



