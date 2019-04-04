// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
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
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.Morphic
{
    [DefaultEvent("ValueChanged")]
    public class MorphicProgressBar : Control
    {
        public delegate void ValueChangedEventHandler(object sender);
        public event ValueChangedEventHandler ValueChanged;

        private DrawingHelper dh = new DrawingHelper();
        private Graphics g;

        private int _value;
        private int _maximum;

        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (_value > _maximum)
                {
                    _value = Maximum;
                }
                else if (_value < 0)
                {
                    _value = 0;
                }
                if (!(value == _value))
                {
                    if (ValueChanged != null)
                        ValueChanged(this);
                }
                _value = value;
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
                if (_value > value)
                {
                    _value = value;
                }
                _maximum = value;
                Invalidate();
            }
        }

        public MorphicProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            Size = new Size(280, 40);
            Font = new Font(Preferences.FontFamily, 10);
            Maximum = 100;
        }

        protected override void CreateHandle()
        {
            Font = new Font(Preferences.FontFamily, Font.Size);
            base.CreateHandle();
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Parent.BackColor);

            float percent = (float)((_value / (double)_maximum));

            Rectangle boundsRect = new Rectangle(0, 0, Width - 1, Height - 1);
            GraphicsPath boundsPath = dh.RoundRect(boundsRect, Preferences.Rounding);

            LinearGradientBrush backBrush = new LinearGradientBrush(boundsRect, dh.AdjustColor(Preferences.SecondaryBackColor, 5, DrawingHelper.ColorAdjustmentType.Darken), Preferences.SecondaryBackColor, 90.0F);
            g.FillPath(backBrush, boundsPath);
            backBrush.Dispose();

            if (_value > 0)
            {

                Rectangle barRect = new Rectangle(0, 0, Convert.ToInt32((Width / _maximum) * _value) - 1, Height - 1);

                if (barRect.Width > (Preferences.Rounding * 2))
                {

                    GraphicsPath barPath = dh.RoundRect(barRect, Preferences.Rounding);
                    LinearGradientBrush barBrush = new LinearGradientBrush(barRect, Preferences.ControlBackColor, dh.AdjustColor(Preferences.ControlBackColor, 30, DrawingHelper.ColorAdjustmentType.Darken), 90.0F);
                    g.FillPath(barBrush, barPath);
                    barBrush.Dispose();

                    SolidBrush screenBrush = new SolidBrush(Color.FromArgb(Convert.ToInt32(50 * percent), Preferences.MainColor));
                    g.FillPath(screenBrush, barPath);
                    screenBrush.Dispose();

                    g.DrawPath(new Pen(Preferences.BorderColor), barPath);

                }

            }

            string percentStr = (percent * 100).ToString() + "%";
            dh.DrawCenteredString(g, percentStr, Font, new SolidBrush(Preferences.TextColor), boundsRect, false);

            g.DrawPath(new Pen(Preferences.BorderColor), boundsPath);

        }

    }
}
