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
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.CarbonFibre
{
    public class CarbonFiberProgressBar : Control
    {
        #region " Properties "
        public CarbonFiberProgressBar()
        {
            Size = new Size(419, 27);
        }
        private double _Maximum;
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
        private double _Progress;
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
                _Progress = value;
                _Current = value * 0.01 * _Maximum;
                Invalidate();
            }
        }

        private bool _ShowPercentage = true;
        public bool ShowPercentage
        {
            get { return _ShowPercentage; }
            set
            {
                _ShowPercentage = value;
                Invalidate();
            }
        }
        #endregion
        #region "Color Of Control"
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            Bitmap B = new Bitmap(Width, Height);

            Graphics G = e.Graphics;

            G = Graphics.FromImage(B);

            G.Clear(Color.FromArgb(22, 22, 22));
            LinearGradientBrush Glow = new LinearGradientBrush(new Rectangle(3, 3, Width - 7, Height - 7), Color.FromArgb(22, 22, 22), Color.FromArgb(27, 27, 27), -270);
            G.FillRectangle(Glow, new Rectangle(3, 3, Width - 7, Height - 7));
            G.DrawRectangle(Pens.Black, new Rectangle(3, 3, Width - 7, Height - 7));



            dynamic W = Convert.ToInt32(_Progress * 0.01 * Width);

            Rectangle R = new Rectangle(3, 3, W - 6, Height - 6);

            LinearGradientBrush Header = new LinearGradientBrush(R, Color.FromArgb(25, 25, 25), Color.FromArgb(50, 50, 50), 270);
            G.FillRectangle(Header, R);
            HatchBrush HeaderHatch = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(35, Color.Black), Color.Transparent);
            G.FillRectangle(HeaderHatch, R);

            if (_ShowPercentage)
            {
                G.DrawString(Convert.ToString(string.Concat(Progress, "%")), Font, new SolidBrush(Color.FromArgb(6, 6, 6)), new Rectangle(1, 2, Width - 1, Height - 1), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
                G.DrawString(Convert.ToString(string.Concat(Progress, "%")), Font, new SolidBrush(Color.FromArgb(255, 150, 0)), new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }

            G.FillRectangle(new SolidBrush(Color.FromArgb(3, Color.White)), R.X, R.Y, R.Width, Convert.ToInt32(R.Height * 0.45));
            G.DrawRectangle(new Pen(Color.FromArgb(32, 32, 32)), new Rectangle(4, 4, Width - 9, Height - 9));
            G.DrawRectangle(new Pen(Color.FromArgb(10, 10, 10)), R.X, R.X, R.Width - 1, R.Height - 1);


            e.Graphics.DrawImage(B, 0, 0);

            base.OnPaint(e);
            G.Dispose();
        }
        #endregion
    }

}


