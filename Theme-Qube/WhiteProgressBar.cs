﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="WhiteProgressBar.cs" company="Zeroit Dev Technologies">
//    This program is for creating Theme controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Qube
{
    public class QubeWhiteProgressBar : Control
    {
        #region " Properties "
        ProgressBar Pgs = new ProgressBar();
        public QubeWhiteProgressBar()
        {
            Size = new Size(132, 14);
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
        #region "Couleur"
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            using (Bitmap B = new Bitmap(Width, Height))
            {

                using (Graphics G = Graphics.FromImage(B))
                {
                    G.Clear(Color.FromArgb(255, 255, 255));
                    LinearGradientBrush Glow = new LinearGradientBrush(new Rectangle(3, 3, Width - 7, Height - 7), Color.FromArgb(54, 62, 83), Color.FromArgb(54, 62, 83), -270);
                    G.FillRectangle(Glow, new Rectangle(3, 3, Width - 7, Height - 7));
                    //54,62,83
                    G.DrawRectangle(new Pen(Color.FromArgb(54, 62, 83)), new Rectangle(3, 3, Width - 7, Height - 7));
                    dynamic W = Convert.ToInt32(_Progress * 0.01 * Width);

                    Rectangle R = new Rectangle(3, 3, W - 7, Height - 6);

                    LinearGradientBrush Header = new LinearGradientBrush(R, Color.FromArgb(0, 182, 248), Color.FromArgb(0, 182, 248), 270);
                    G.FillRectangle(Header, R);

                    G.FillRectangle(new SolidBrush(Color.FromArgb(3, Color.White)), R.X, R.Y, R.Width, Convert.ToInt32(R.Height * 0.25));
                }
                e.Graphics.DrawImage(B, 0, 0);
            }
            base.OnPaint(e);
        }


        #endregion
    }

}
