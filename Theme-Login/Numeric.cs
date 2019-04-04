// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Numeric.cs" company="Zeroit Dev Technologies">
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

using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using static Zeroit.Framework.UIThemes.Login.DrawHelpers;

namespace Zeroit.Framework.UIThemes.Login
{

    public class LogInNumeric : Control
    {

        #region "Variables"

        private MouseState State = MouseState.None;
        private int MouseXLoc;
        private int MouseYLoc;
        private long _Value;
        private long _Minimum = 0;
        private long _Maximum = 9999999;
        private bool BoolValue;
        private Color _BaseColour = Color.FromArgb(42, 42, 42);
        private Color _ButtonColour = Color.FromArgb(47, 47, 47);
        private Color _BorderColour = Color.FromArgb(35, 35, 35);
        private Color _SecondBorderColour = Color.FromArgb(0, 191, 255);

        private Color _FontColour = Color.FromArgb(255, 255, 255);
        #endregion

        #region "Properties & Events"

        public long Value
        {
            get { return _Value; }
            set
            {
                if (value <= _Maximum & value >= _Minimum)
                    _Value = value;
                Invalidate();
            }
        }

        public long Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value > _Minimum)
                    _Maximum = value;
                if (_Value > _Maximum)
                    _Value = _Maximum;
                Invalidate();
            }
        }

        public long Minimum
        {
            get { return _Minimum; }
            set
            {
                if (value < _Maximum)
                    _Minimum = value;
                if (_Value < _Minimum)
                    _Value = Minimum;
                Invalidate();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            MouseXLoc = e.Location.X;
            MouseYLoc = e.Location.Y;
            Invalidate();
            if (e.X < Width - 47)
                Cursor = Cursors.IBeam;
            else
                Cursor = Cursors.Hand;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (MouseXLoc > Width - 47 && MouseXLoc < Width - 3)
            {
                if (MouseXLoc < Width - 23)
                {
                    if ((Value + 1) <= _Maximum)
                        _Value += 1;
                }
                else
                {
                    if ((Value - 1) >= _Minimum)
                        _Value -= 1;
                }
            }
            else
            {
                BoolValue = !BoolValue;
                Focus();
            }
            Invalidate();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            try
            {
                if (BoolValue)
                    _Value = Convert.ToInt64(Convert.ToString(Convert.ToString(_Value) + e.KeyChar.ToString()));
                if (_Value > _Maximum)
                    _Value = _Maximum;
                Invalidate();
            }
            catch
            {
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Back)
            {
                Value = 0;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 24;
        }

        [Category("Colours")]
        public Color BaseColour
        {
            get { return _BaseColour; }
            set { _BaseColour = value; }
        }

        [Category("Colours")]
        public Color ButtonColour
        {
            get { return _ButtonColour; }
            set { _ButtonColour = value; }
        }

        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }

        [Category("Colours")]
        public Color SecondBorderColour
        {
            get { return _SecondBorderColour; }
            set { _SecondBorderColour = value; }
        }

        [Category("Colours")]
        public Color FontColour
        {
            get { return _FontColour; }
            set { _FontColour = value; }
        }

        #endregion

        #region "Draw Control"

        public LogInNumeric()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 10);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle Base = new Rectangle(0, 0, Width, Height);
            StringFormat CenterSF = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };
            var _with14 = g;
            _with14.SmoothingMode = SmoothingMode.HighQuality;
            _with14.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with14.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with14.Clear(BackColor);
            _with14.FillRectangle(new SolidBrush(_BaseColour), Base);
            _with14.FillRectangle(new SolidBrush(_ButtonColour), new Rectangle(Width - 48, 0, 48, Height));
            _with14.DrawRectangle(new Pen(_BorderColour, 2), Base);
            _with14.DrawLine(new Pen(_SecondBorderColour), new Point(Width - 48, 1), new Point(Width - 48, Height - 2));
            _with14.DrawLine(new Pen(_BorderColour), new Point(Width - 24, 1), new Point(Width - 24, Height - 2));
            _with14.DrawLine(new Pen(_FontColour), new Point(Width - 36, 7), new Point(Width - 36, 17));
            _with14.DrawLine(new Pen(_FontColour), new Point(Width - 31, 12), new Point(Width - 41, 12));
            _with14.DrawLine(new Pen(_FontColour), new Point(Width - 17, 13), new Point(Width - 7, 13));
            _with14.DrawString(Convert.ToString(Value), Font, new SolidBrush(_FontColour), new Rectangle(5, 1, Width, Height), new StringFormat { LineAlignment = StringAlignment.Center });
            _with14.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }

        #endregion

    }

}


