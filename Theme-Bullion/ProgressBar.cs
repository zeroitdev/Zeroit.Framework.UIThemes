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
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Bullion
{

    public class BullionProgressBar : Control
    {

        #region " Properties "
        private double _Maximum = 100;
        public double Maximum
        {
            get { return _Maximum; }
            set
            {
                _Maximum = value;
                Progress = _Current / value * 100;
                Invalidate();
            }
        }
        private double _Current;
        public double Current
        {
            get { return _Current; }
            set
            {
                _Current = value;
                Progress = value / _Maximum * 100;
                Invalidate();
            }
        }
        private int _Progress;
        public double Progress
        {
            get { return _Progress; }
            set
            {
                if (value < 0)
                    value = 0;
                else
                    if (value > 100)
                    value = 100;
                _Progress = Convert.ToInt32(value);
                _Current = value * 0.01 * _Maximum;
                if (Width > 0)
                    UpdateProgress();
                Invalidate();
            }
        }

        //Dark Color
        Color C2 = Color.PaleTurquoise;
        public Color Color1
        {
            get { return C2; }
            set
            {
                C2 = value;
                UpdateColors();
                Invalidate();
            }
        }
        //Light color
        Color C3 = Color.AliceBlue;
        public Color Color2
        {
            get { return C3; }
            set
            {
                C3 = value;
                UpdateColors();
                Invalidate();
            }
        }

        #endregion

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        Graphics G;
        Bitmap B;
        Rectangle R1;
        Rectangle R2;
        ColorBlend X;
        Color C1;
        Pen P1;
        Pen P2;
        Pen P3;
        LinearGradientBrush B1;
        LinearGradientBrush B2;
        SolidBrush B3;

        public BullionProgressBar()
        {
            C1 = Color.FromArgb(246, 246, 246);
            //Background
            P1 = new Pen(Color.FromArgb(70, Color.White), 2);
            P2 = new Pen(C2);
            P3 = new Pen(Color.FromArgb(255, 255, 255));
            //Highlight
            B3 = new SolidBrush(Color.FromArgb(100, Color.White));
            X = new ColorBlend(4);
            X.Colors = new Color[]{
            C2,
            C3,
            C3,
            C2
        };
            X.Positions = new float[]{
            0f,
            0.1f,
            0.9f,
            1f
        };
            R2 = new Rectangle(2, 2, 2, 2);
            B2 = new LinearGradientBrush(R2, Color.Transparent, Color.Transparent, 180f);
            B2.InterpolationColors = X;

        }

        public void UpdateColors()
        {
            P2.Color = C2;
            X.Colors = new Color[]{
            C2,
            C3,
            C3,
            C2
        };
            B2.InterpolationColors = X;
        }

        protected override void OnSizeChanged(System.EventArgs e)
        {
            R1 = new Rectangle(0, 1, Width, 4);
            B1 = new LinearGradientBrush(R1, Color.FromArgb(24, Color.Black), Color.Transparent, 90f);
            UpdateProgress();
            Invalidate();
            base.OnSizeChanged(e);
        }

        public void UpdateProgress()
        {
            if (_Progress == 0)
                return;
            R2 = new Rectangle(2, 2, Convert.ToInt32((Width - 4) * (_Progress * 0.01)), Height - 4);
            B2 = new LinearGradientBrush(R2, Color.Transparent, Color.Transparent, 180f);
            B2.InterpolationColors = X;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);

            G.Clear(C1);

            G.FillRectangle(B1, R1);

            if (_Progress > 0)
            {
                G.FillRectangle(B2, R2);

                G.FillRectangle(B3, 2, 3, R2.Width, 4);
                G.DrawRectangle(P1, 4, 4, R2.Width - 4, Height - 8);

                G.DrawRectangle(P2, 2, 2, R2.Width - 1, Height - 5);
            }

            G.DrawRectangle(P3, 0, 0, Width - 1, Height - 1);

            e.Graphics.DrawImage(B, 0, 0);
            G.Dispose();
            B.Dispose();
        }

    }
    
}


