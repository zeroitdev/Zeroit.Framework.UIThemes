// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Trackbar.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Login
{

    public class LogInTrackBar : Control
    {

        #region "Declaration"
        private int _Maximum = 10;
        private int _Value = 0;
        private bool CaptureMovement = false;
        private Rectangle Bar;
        private Size Track = new Size(25, 14);
        private Color _TextColour = Color.FromArgb(255, 255, 255);
        private Color _BorderColour = Color.FromArgb(35, 35, 35);
        private Color _BarBaseColour = Color.FromArgb(47, 47, 47);
        private Color _StripColour = Color.FromArgb(42, 42, 42);
        #endregion
        private Color _StripAmountColour = Color.FromArgb(23, 119, 151);

        #region "Properties"

        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }

        [Category("Colours")]
        public Color BarBaseColour
        {
            get { return _BarBaseColour; }
            set { _BarBaseColour = value; }
        }

        [Category("Colours")]
        public Color StripColour
        {
            get { return _StripColour; }
            set { _StripColour = value; }
        }

        [Category("Colours")]
        public Color TextColour
        {
            get { return _TextColour; }
            set { _TextColour = value; }
        }

        [Category("Colours")]
        public Color StripAmountColour
        {
            get { return _StripAmountColour; }
            set { _StripAmountColour = value; }
        }

        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value > 0)
                    _Maximum = value;
                if (value < _Value)
                    _Value = value;
                Invalidate();
            }
        }

        public event ValueChangedEventHandler ValueChanged;
        public delegate void ValueChangedEventHandler();

        public int Value
        {
            get { return _Value; }
            set
            {
                if (value == _Value)
                {
                    return;
                }
                else if (value == _Value)
                {
                    _Value = 0;
                }
                else if (value == _Maximum)
                {
                    _Value = _Maximum;
                }
                else
                {
                    _Value = value;
                }

                #region Old Code
                //			switch (value) {
                //				case  // ERROR: Case labels with binary operators are unsupported : Equality
                //_Value:
                //					return;

                //					break;
                //				case  // ERROR: Case labels with binary operators are unsupported : LessThan
                //0:
                //					_Value = 0;
                //					break;
                //				case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
                //_Maximum:
                //					_Value = _Maximum;
                //					break;
                //				default:
                //					_Value = value;
                //					break;
                //			} 
                #endregion

                if (ValueChanged != null)
                {
                    ValueChanged();
                }

                Invalidate();

            }
        }



        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Rectangle MovementPoint = new Rectangle(new Point(e.Location.X, e.Location.Y), new Size(1, 1));
            Rectangle Bar = new Rectangle(10, 10, Width - 21, Height - 21);
            if (new Rectangle(new Point(Bar.X + Convert.ToInt32(Bar.Width * (Value / Maximum)) - Convert.ToInt32(Track.Width / 2 - 1), 0), new Size(Track.Width, Height)).IntersectsWith(MovementPoint))
            {
                CaptureMovement = true;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            CaptureMovement = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (CaptureMovement)
            {
                Point MovementPoint = new Point(e.X, e.Y);
                Rectangle Bar = new Rectangle(10, 10, Width - 21, Height - 21);
                Value = Convert.ToInt32(Maximum * ((MovementPoint.X - Bar.X) / Bar.Width));
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            CaptureMovement = false;
        }

        #endregion

        #region "Draw Control"

        public LogInTrackBar()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.Selectable | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(54, 54, 54);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bar = new Rectangle(0, 10, Width - 21, Height - 21);
            Graphics g = e.Graphics;
            var _with27 = g;
            _with27.SmoothingMode = SmoothingMode.AntiAlias;
            _with27.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with27.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            Bar = new Rectangle(13, 11, Width - 27, Height - 21);
            _with27.Clear(BackColor);
            _with27.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            _with27.FillRectangle(new SolidBrush(_StripColour), new Rectangle(3, Convert.ToInt32((Height / 2) - 4), Width - 5, 8));
            _with27.DrawRectangle(new Pen(_BorderColour, 2), new Rectangle(4, Convert.ToInt32((Height / 2) - 4), Width - 5, 8));
            _with27.FillRectangle(new SolidBrush(_StripAmountColour), new Rectangle(4, Convert.ToInt32((Height / 2) - 4), Convert.ToInt32(Bar.Width * (Value / Maximum)) + Convert.ToInt32(Track.Width / 2), 8));
            _with27.FillRectangle(new SolidBrush(_BarBaseColour), Bar.X + Convert.ToInt32(Bar.Width * (Value / Maximum)) - Convert.ToInt32(Track.Width / 2), Bar.Y + Convert.ToInt32((Bar.Height / 2)) - Convert.ToInt32(Track.Height / 2), Track.Width, Track.Height);
            _with27.DrawRectangle(new Pen(_BorderColour, 2), Bar.X + Convert.ToInt32(Bar.Width * (Value / Maximum)) - Convert.ToInt32(Track.Width / 2), Bar.Y + Convert.ToInt32((Bar.Height / 2)) - Convert.ToInt32(Track.Height / 2), Track.Width, Track.Height);
            _with27.DrawString(Convert.ToString(_Value), new Font("Segoe UI", 6.5f, FontStyle.Regular), new SolidBrush(_TextColour), new Rectangle(Bar.X + Convert.ToInt32(Bar.Width * (Value / Maximum)) - Convert.ToInt32(Track.Width / 2), Bar.Y + Convert.ToInt32((Bar.Height / 2)) - Convert.ToInt32(Track.Height / 2), Track.Width - 1, Track.Height), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });
            _with27.InterpolationMode = InterpolationMode.HighQualityBicubic;

        }

        #endregion

    }

}


