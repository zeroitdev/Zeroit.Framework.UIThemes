﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Ambience
{

    #region ProgressBar

    public class AmbianceProgressBar : Control
    {

        #region Enums 

        public enum Alignment
        {
            Right,
            Center
        }

        #endregion
        #region Variables 

        private int _Minimum;
        private int _Maximum = 100;
        private int _Value = 0;
        private Alignment ALN;
        private bool _DrawHatch;

        private bool _ShowPercentage;
        private GraphicsPath GP1;
        private GraphicsPath GP2;
        private GraphicsPath GP3;
        private Rectangle R1;
        private Rectangle R2;
        private LinearGradientBrush GB1;
        private LinearGradientBrush GB2;
        private int I1;

        #endregion
        #region Properties 

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

        public int Minimum
        {
            get { return _Minimum; }
            set
            {
                _Minimum = value;

                if (value > _Maximum)
                    _Maximum = value;
                if (value > _Value)
                    _Value = value;

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

        public Alignment ValueAlignment
        {
            get { return ALN; }
            set
            {
                ALN = value;
                Invalidate();
            }
        }

        public bool DrawHatch
        {
            get { return _DrawHatch; }
            set
            {
                _DrawHatch = value;
                Invalidate();
            }
        }

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
        #region EventArgs

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Height = 20;
            Size minimumSize = new Size(58, 20);
            this.MinimumSize = minimumSize;
        }

        #endregion

        public AmbianceProgressBar()
        {
            _Maximum = 100;
            _ShowPercentage = true;
            _DrawHatch = true;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
        }

        public void Increment(int value)
        {
            this._Value += value;
            Invalidate();
        }

        public void Deincrement(int value)
        {
            this._Value -= value;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            G.Clear(Color.Transparent);
            G.SmoothingMode = SmoothingMode.HighQuality;

            GP1 = RoundRectangle.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 4);
            GP2 = RoundRectangle.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), 4);

            R1 = new Rectangle(0, 2, Width - 1, Height - 1);
            GB1 = new LinearGradientBrush(R1, Color.FromArgb(255, 255, 255), Color.FromArgb(230, 230, 230), 90f);

            // Draw inside background
            G.FillRectangle(new SolidBrush(Color.FromArgb(244, 241, 243)), R1);
            G.SetClip(GP1);
            G.FillPath(new SolidBrush(Color.FromArgb(244, 241, 243)), RoundRectangle.RoundRect(new Rectangle(1, 1, Width - 3, Height / 2 - 2), 4));


            I1 = (int)Math.Round(((double)(this._Value - this._Minimum) / (double)(this._Maximum - this._Minimum)) * (double)(this.Width - 3));
            if (I1 > 1)
            {
                GP3 = RoundRectangle.RoundRect(new Rectangle(1, 1, I1, Height - 3), 4);

                R2 = new Rectangle(1, 1, I1, Height - 3);
                GB2 = new LinearGradientBrush(R2, Color.FromArgb(214, 89, 37), Color.FromArgb(223, 118, 75), 90f);

                // Fill the value with its gradient
                G.FillPath(GB2, GP3);

                // Draw diagonal lines
                if (_DrawHatch == true)
                {
                    for (var i = 0; i <= (Width - 1) * _Maximum / _Value; i += 20)
                    {
                        G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(25, Color.White)), 10.0F), new Point(System.Convert.ToInt32(i), 0), new Point((int)(i - 10), Height));
                    }
                }

                G.SetClip(GP3);
                G.SmoothingMode = SmoothingMode.None;
                G.SmoothingMode = SmoothingMode.AntiAlias;
                G.ResetClip();
            }

            // Draw value as a string
            string DrawString = Convert.ToString(Convert.ToInt32(Value)) + "%";
            int textX = (int)(this.Width - G.MeasureString(DrawString, Font).Width - 1);
            int textY = (int)((this.Height / 2) - (System.Convert.ToInt32(G.MeasureString(DrawString, Font).Height / 2) - 2));

            if (_ShowPercentage == true)
            {
                switch (ValueAlignment)
                {
                    case Alignment.Right:
                        G.DrawString(DrawString, new Font("Segoe UI", 8), Brushes.DimGray, new Point(textX, textY));
                        break;
                    case Alignment.Center:
                        G.DrawString(DrawString, new Font("Segoe UI", 8), Brushes.DimGray, new Rectangle(0, 0, Width, Height + 2), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        break;
                }
            }

            // Draw border
            G.DrawPath(new Pen(Color.FromArgb(180, 180, 180)), GP2);

            e.Graphics.DrawImage((Image)(B.Clone()), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

    #endregion


}
