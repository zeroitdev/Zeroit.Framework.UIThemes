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

namespace Zeroit.Framework.UIThemes.Drone
{
    public class DroneProgressBar : ThemeControl153
    {


        private ColorBlend Blend;

        public DroneProgressBar()
        {
            Blend = new ColorBlend();
            Blend.Colors = new Color[] {
            Color.FromArgb(0, 55, 90),
            Color.FromArgb(0, 66, 108),
            Color.FromArgb(0, 66, 108),
            Color.FromArgb(0, 55, 90)
        };
            Blend.Positions = new float[] {
            0f,
            0.4f,
            0.6f,
            1f
        };
        }

        protected override void OnCreation()
        {
            if (!DesignMode)
            {
                System.Threading.Thread T = new System.Threading.Thread(MoveGlow);
                T.IsBackground = true;
                T.Start();
            }
        }

        private float GlowPosition = -1f;
        private void MoveGlow()
        {
            while (true)
            {
                GlowPosition += 0.01f;
                if (GlowPosition >= 1f)
                    GlowPosition = -1f;
                Invalidate();
                System.Threading.Thread.Sleep(25);
            }
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

        private int Progress;
        protected override void PaintHook()
        {
            DrawBorders(new Pen(Color.FromArgb(32, 32, 32)), 1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), 0, 0, Width, 8);

            DrawGradient(Color.FromArgb(8, 8, 8), Color.FromArgb(23, 23, 23), 2, 2, Width - 4, Height - 4, 90f);

            Progress = Convert.ToInt32((_Value / _Maximum) * Width);

            if (!(Progress == 0))
            {
                G.SetClip(new Rectangle(3, 3, Progress - 6, Height - 6));
                G.FillRectangle(new SolidBrush(Color.FromArgb(0, 55, 90)), 0, 0, Progress, Height);

                DrawGradient(Blend, Convert.ToInt32(GlowPosition * Progress), 0, Progress, Height, 0f);
                DrawBorders(new Pen(Color.FromArgb(15, Color.White)), 3, 3, Progress - 6, Height - 6);

                G.FillRectangle(new SolidBrush(Color.FromArgb(13, Color.White)), 3, 3, Width - 6, 5);

                G.ResetClip();
            }

            DrawBorders(Pens.Black, 2);
            DrawBorders(Pens.Black);
        }
    }


}


