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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.NeSeal
{

    public class NSProgressBar : Control
    {

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

        public NSProgressBar()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            P1 = new Pen(Color.FromArgb(24, 24, 24));
            P2 = new Pen(Color.FromArgb(55, 55, 55));
            B1 = new SolidBrush(Color.FromArgb(51, 181, 229));
        }

        private GraphicsPath GP1;
        private GraphicsPath GP2;

        private GraphicsPath GP3;
        private Rectangle R1;

        private Rectangle R2;
        private Pen P1;
        private Pen P2;
        private SolidBrush B1;
        private LinearGradientBrush GB1;

        private LinearGradientBrush GB2;

        private int I1;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            ThemeModule theme = new ThemeModule();

            theme.G = e.Graphics;

            theme.G.Clear(BackColor);
            theme.G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = theme.CreateRound(0, 0, Width - 1, Height - 1, 7);
            GP2 = theme.CreateRound(1, 1, Width - 3, Height - 3, 7);

            R1 = new Rectangle(0, 2, Width - 1, Height - 1);
            GB1 = new LinearGradientBrush(R1, Color.FromArgb(45, 45, 45), Color.FromArgb(50, 50, 50), 90f);

            theme.G.SetClip(GP1);
            theme.G.FillRectangle(GB1, R1);

            I1 = Convert.ToInt32((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 3));

            if (I1 > 1)
            {
                GP3 = theme.CreateRound(1, 1, I1, Height - 3, 7);

                R2 = new Rectangle(1, 1, I1, Height - 3);
                GB2 = new LinearGradientBrush(R2, Color.FromArgb(51, 181, 229), Color.FromArgb(0, 153, 204), 90f);

                theme.G.FillPath(GB2, GP3);
                theme.G.DrawPath(P1, GP3);

                theme.G.SetClip(GP3);
                theme.G.SmoothingMode = SmoothingMode.None;

                theme.G.FillRectangle(B1, R2.X, R2.Y + 1, R2.Width, R2.Height / 2);

                theme.G.SmoothingMode = SmoothingMode.AntiAlias;
                theme.G.ResetClip();
            }

            theme.G.DrawPath(P2, GP1);
            theme.G.DrawPath(P1, GP2);
        }

    }


}


