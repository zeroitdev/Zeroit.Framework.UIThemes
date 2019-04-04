// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="TrackBar.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.Morphic
{
    [DefaultEvent("Scroll")]
    public class MorphicTrackBar : Control
    {
        public delegate void ScrollEventHandler(object sender);
        public event ScrollEventHandler Scroll;

        private DrawingHelper dh = new DrawingHelper();
        private Graphics g;

        private int trackX;
        private int trackWidth;
        private Rectangle trackRect;
        private bool trackDown;
        private bool overTrack;
        private int _minimum;
        private int _maximum;
        private int _value;

        public int Minimum
        {
            get
            {
                return _minimum;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

                _minimum = value;
                if (value > _value)
                {
                    _value = value;
                }
                if (value > _maximum)
                {
                    _maximum = value;
                }
                Invalidate();
            }
        }

        public int Maximum
        {
            get
            {
                return _maximum;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

                _maximum = value;
                if (value < _value)
                {
                    _value = value;
                }
                if (value < _minimum)
                {
                    _minimum = value;
                }
                Invalidate();
            }
        }

        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value == _value)
                {
                    return;
                }

                if (value > _maximum || value < _minimum)
                {
                    throw new Exception("Property value is not valid.");
                }

                _value = value;
                Invalidate();

                if (Scroll != null)
                    Scroll(this);
            }
        }

        public MorphicTrackBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            Size = new Size(200, 24);
            Maximum = 10;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {

            g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Parent.BackColor);

            int slope = ((Height - 12) / 2);
            trackWidth = Height - 14;

            Rectangle barRect = new Rectangle(0, 6, Width - 1, Height - 12);
            GraphicsPath barPath = dh.RoundRect(barRect, slope);
            LinearGradientBrush barBrush = new LinearGradientBrush(barRect, Preferences.ControlBackColor, dh.AdjustColor(Preferences.ControlBackColor, 30, DrawingHelper.ColorAdjustmentType.Darken), 90.0F);
            g.FillPath(barBrush, barPath);
            barBrush.Dispose();

            trackX = Convert.ToInt32((_value - _minimum) / (_maximum - _minimum) * (Width - trackWidth - 1));

            if (_value > 0)
            {
                Rectangle filledBarRect = new Rectangle(0, barRect.Y, Convert.ToInt32(trackX + (trackWidth / 2.0)), barRect.Height);
                GraphicsPath filledBarPath = dh.RoundRect(filledBarRect, slope);
                SolidBrush filledBarBrush = new SolidBrush(Color.FromArgb(50, Preferences.MainColor));
                g.FillPath(filledBarBrush, filledBarPath);
                filledBarBrush.Dispose();
            }

            g.DrawPath(new Pen(Preferences.BorderColor), barPath);

            trackRect = new Rectangle(trackX, 0, trackWidth, Height - 1);
            GraphicsPath trackPath = dh.RoundRect(trackRect, Preferences.Rounding);
            LinearGradientBrush trackBrush = new LinearGradientBrush(trackRect, Preferences.TextColor, dh.AdjustColor(Preferences.TextColor, 50, DrawingHelper.ColorAdjustmentType.Darken), 90.0F);
            g.FillPath(trackBrush, trackPath);
            trackBrush.Dispose();
            if (overTrack)
            {
                g.FillPath(new SolidBrush(Color.FromArgb(35, Preferences.MainColor)), trackPath);
            }
            g.DrawPath(new Pen(Preferences.BorderColor), trackPath);

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                trackX = Convert.ToInt32((_value - _minimum) / (_maximum - _minimum) * (Width - trackWidth - 1));
                trackRect = new Rectangle(trackX, 0, trackWidth, Height - 1);
                trackDown = trackRect.Contains(e.Location);
            }

            base.OnMouseDown(e);

        }

        protected override void OnMouseMove(MouseEventArgs e)
        {

            if (trackDown && e.X > -1 && e.X < (Width + 1))
            {
                Value = _minimum + Convert.ToInt32((_maximum - _minimum) * (e.X / Width));
            }

            if (trackRect.Contains(e.Location) || trackDown)
            {
                overTrack = true;
            }
            else
            {
                overTrack = false;
            }

            Invalidate();

            base.OnMouseMove(e);

        }

        protected override void OnMouseLeave(EventArgs e)
        {

            overTrack = false;
            Invalidate();

            base.OnMouseLeave(e);

        }

        protected override void OnMouseUp(MouseEventArgs e)
        {

            trackDown = false;
            overTrack = trackRect.Contains(e.Location);
            Invalidate();

            base.OnMouseUp(e);

        }

    }
}
