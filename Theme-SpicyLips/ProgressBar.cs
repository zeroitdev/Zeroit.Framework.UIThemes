// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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

namespace Zeroit.Framework.UIThemes.SpicyLips
{
    public class BlackProgressBar : ThemeControl154
    {


        private ColorBlend Blend;
        public BlackProgressBar()
        {
            Blend = new ColorBlend();
            Blend.Colors = new Color[] {
            Color.FromArgb(37, 37, 37),
            Color.FromArgb(64, 66, 68),
            Color.FromArgb(64, 66, 68),
            Color.FromArgb(37, 37, 37)
        };
            Blend.Positions = new float[] {
            0f,
            0.4f,
            0.6f,
            1f
        };

            IsAnimated = true;

            P1 = new Pen(Color.FromArgb(32, 32, 32));
            P2 = new Pen(Color.FromArgb(15, Color.White));
            P3 = Pens.Black;
            P4 = Pens.Black;

            B1 = new SolidBrush(Color.FromArgb(50, 50, 50));
            B2 = new SolidBrush(Color.FromArgb(37, 37, 37));
            B3 = new SolidBrush(Color.FromArgb(13, Color.White));

            C1 = Color.FromArgb(8, 8, 8);
            C2 = Color.FromArgb(23, 23, 23);
        }

        private float GlowPosition = -1f;
        protected override void OnAnimation()
        {
            GlowPosition += 0.05f;
            if (GlowPosition >= 1f)
                GlowPosition = -1f;
        }

        private int _Value;
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum)
                    value = _Maximum;
                if (value < 0)
                    value = 0;

                _Value = value;
                Invalidate();
            }
        }

        private int _Maximum = 100;
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 1)
                    value = 1;
                if (_Value > value)
                    _Value = value;

                _Maximum = value;
                Invalidate();
            }
        }

        public void Increment(int amount)
        {
            Value += amount;
        }


        protected override void ColorHook()
        {
        }

        private Pen P1;
        private Pen P2;
        private Pen P3;
        private Pen P4;
        private SolidBrush B1;
        private SolidBrush B2;
        private SolidBrush B3;
        private Color C1;

        private Color C2;

        private Rectangle R1;
        private int Progress;
        protected override void PaintHook()
        {
            DrawBorders(P1, 1);
            G.FillRectangle(B1, 0, 0, Width, 8);

            DrawGradient(C1, C2, 2, 2, Width - 4, Height - 4, 90f);

            Progress = Convert.ToInt32((_Value / _Maximum) * Width);

            if (!(Progress == 0))
            {
                R1 = new Rectangle(3, 3, Progress - 6, Height - 6);

                G.SetClip(R1);
                G.FillRectangle(B2, 0, 0, Progress, Height);

                DrawGradient(Blend, Convert.ToInt32(GlowPosition * Progress), 0, Progress, Height, 0f);
                DrawBorders(P2, 3, 3, Progress - 6, Height - 6);

                G.FillRectangle(B3, 3, 3, Width - 6, 5);
                G.ResetClip();
            }

            DrawBorders(P3, 2);
            DrawBorders(P4);
        }
    }

}