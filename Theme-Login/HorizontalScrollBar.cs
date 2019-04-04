// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="HorizontalScrollBar.cs" company="Zeroit Dev Technologies">
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

    [DefaultEvent("Scroll")]
    public class LogInHorizontalScrollBar : Control
    {

        #region "Declarations"

        private int ThumbMovement;
        private Rectangle LSA;
        private Rectangle RSA;
        private Rectangle Shaft;
        private Rectangle Thumb;
        private bool ShowThumb;
        private bool ThumbPressed;
        private int _ThumbSize = 24;
        private int _Minimum = 0;
        private int _Maximum = 100;
        private int _Value = 0;
        private int _SmallChange = 1;
        private int _ButtonSize = 16;
        private int _LargeChange = 10;
        private Color _ThumbBorder = Color.FromArgb(35, 35, 35);
        private Color _LineColour = Color.FromArgb(23, 119, 151);
        private Color _ArrowColour = Color.FromArgb(37, 37, 37);
        private Color _BaseColour = Color.FromArgb(47, 47, 47);
        private Color _ThumbColour = Color.FromArgb(55, 55, 55);
        private Color _ThumbSecondBorder = Color.FromArgb(65, 65, 65);
        private Color _FirstBorder = Color.FromArgb(55, 55, 55);
        private Color _SecondBorder = Color.FromArgb(35, 35, 35);

        private bool ThumbDown = false;
        #endregion

        #region "Properties & Events"

        [Category("Colours")]
        public Color ThumbBorder
        {
            get { return _ThumbBorder; }
            set { _ThumbBorder = value; }
        }

        [Category("Colours")]
        public Color LineColour
        {
            get { return _LineColour; }
            set { _LineColour = value; }
        }

        [Category("Colours")]
        public Color ArrowColour
        {
            get { return _ArrowColour; }
            set { _ArrowColour = value; }
        }

        [Category("Colours")]
        public Color BaseColour
        {
            get { return _BaseColour; }
            set { _BaseColour = value; }
        }

        [Category("Colours")]
        public Color ThumbColour
        {
            get { return _ThumbColour; }
            set { _ThumbColour = value; }
        }

        [Category("Colours")]
        public Color ThumbSecondBorder
        {
            get { return _ThumbSecondBorder; }
            set { _ThumbSecondBorder = value; }
        }

        [Category("Colours")]
        public Color FirstBorder
        {
            get { return _FirstBorder; }
            set { _FirstBorder = value; }
        }

        [Category("Colours")]
        public Color SecondBorder
        {
            get { return _SecondBorder; }
            set { _SecondBorder = value; }
        }

        public event ScrollEventHandler Scroll;
        public delegate void ScrollEventHandler(object sender);

        public int Minimum
        {
            get { return _Minimum; }
            set
            {
                _Minimum = value;
                if (value > _Value)
                    _Value = value;
                if (value > _Maximum)
                    _Maximum = value;
                InvalidateLayout();
            }
        }

        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < _Value)
                    _Value = value;
                if (value < _Minimum)
                    _Minimum = value;
            }
        }

        public int Value
        {
            get { return _Value; }
            set
            {

                if (value == _Value)
                {
                    return;
                }
                else if (value == _Minimum)
                {
                    _Value = _Minimum;
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
                //            switch (value) {
                //				case  // ERROR: Case labels with binary operators are unsupported : Equality
                //_Value:
                //					return;

                //					break;
                //				case  // ERROR: Case labels with binary operators are unsupported : LessThan
                //_Minimum:
                //					_Value = _Minimum;
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

                InvalidatePosition();
                if (Scroll != null)
                {
                    Scroll(this);
                }
            }
        }

        public int SmallChange
        {
            get { return _SmallChange; }
            set
            {
                if (value == 1)
                    return;

                _SmallChange = value;
                Invalidate();

                #region Old Code
                //			switch (value) {
                //				case  // ERROR: Case labels with binary operators are unsupported : LessThan
                //1:
                //					break;
                //				case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
                //Convert.ToInt32(_SmallChange == value):
                //					break;
                //			} 
                #endregion

            }
        }

        public int LargeChange
        {
            get { return _LargeChange; }
            set
            {
                switch (value)
                {
                    case  // ERROR: Case labels with binary operators are unsupported : LessThan
    1:
                        break;
                    default:
                        _LargeChange = value;
                        break;
                }
            }
        }

        public int ButtonSize
        {
            get { return _ButtonSize; }
            set
            {
                switch (value)
                {
                    case  // ERROR: Case labels with binary operators are unsupported : LessThan
    16:
                        _ButtonSize = 16;
                        break;
                    default:
                        _ButtonSize = value;
                        break;
                }
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            InvalidateLayout();
        }

        private void InvalidateLayout()
        {
            LSA = new Rectangle(0, 1, 0, Height);
            Shaft = new Rectangle(LSA.Right + 1, 0, Width - 3, Height);
            ShowThumb = Convert.ToBoolean(((_Maximum - _Minimum)));
            Thumb = new Rectangle(0, 1, _ThumbSize, Height - 3);
            if (Scroll != null)
            {
                Scroll(this);
            }
            InvalidatePosition();
        }

        private void InvalidatePosition()
        {
            Thumb.X = Convert.ToInt32(((_Value - _Minimum) / (_Maximum - _Minimum)) * (Shaft.Width - _ThumbSize) + 1);
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ShowThumb)
            {
                if (LSA.Contains(e.Location))
                {
                    ThumbMovement = _Value - _SmallChange;
                }
                else if (RSA.Contains(e.Location))
                {
                    ThumbMovement = _Value + _SmallChange;
                }
                else
                {
                    if (Thumb.Contains(e.Location))
                    {
                        ThumbDown = true;
                        return;
                    }
                    else
                    {
                        if (e.X < Thumb.X)
                        {
                            ThumbMovement = _Value - _LargeChange;
                        }
                        else
                        {
                            ThumbMovement = _Value + _LargeChange;
                        }
                    }
                }
                Value = Math.Min(Math.Max(ThumbMovement, _Minimum), _Maximum);
                InvalidatePosition();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (ThumbDown && ShowThumb)
            {
                int ThumbPosition = e.X - LSA.Width - (_ThumbSize / 2);
                int ThumbBounds = Shaft.Width - _ThumbSize;

                ThumbMovement = Convert.ToInt32((ThumbPosition / ThumbBounds) * (_Maximum - _Minimum)) + _Minimum;

                Value = Math.Min(Math.Max(ThumbMovement, _Minimum), _Maximum);
                InvalidatePosition();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            ThumbDown = false;
        }

        #endregion

        #region "Draw Control"

        public LogInHorizontalScrollBar()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.Selectable | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Height = 18;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            var _with29 = g;
            _with29.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with29.SmoothingMode = SmoothingMode.HighQuality;
            _with29.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with29.Clear(Color.FromArgb(47, 47, 47));
            Point[] P = {
            new Point(5, Convert.ToInt32(Height / 2)),
            new Point(13, Convert.ToInt32(Height / 4)),
            new Point(13, Convert.ToInt32(Height / 2 - 2)),
            new Point(Width - 13, Convert.ToInt32(Height / 2 - 2)),
            new Point(Width - 13, Convert.ToInt32(Height / 4)),
            new Point(Width - 5, Convert.ToInt32(Height / 2)),
            new Point(Width - 13, Convert.ToInt32(Height - Height / 4 - 1)),
            new Point(Width - 13, Convert.ToInt32(Height / 2 + 2)),
            new Point(13, Convert.ToInt32(Height / 2 + 2)),
            new Point(13, Convert.ToInt32(Height - Height / 4 - 1))
        };
            _with29.FillPolygon(new SolidBrush(_ArrowColour), P);
            _with29.FillRectangle(new SolidBrush(_ThumbColour), Thumb);
            _with29.DrawRectangle(new Pen(_ThumbBorder), Thumb);
            _with29.DrawRectangle(new Pen(_ThumbSecondBorder), Thumb.X + 1, Thumb.Y + 1, Thumb.Width - 2, Thumb.Height - 2);
            _with29.DrawLine(new Pen((_LineColour), 2), new Point(Thumb.X + 4, (Convert.ToInt32(Thumb.Height / 2 + 1))), new Point(Thumb.Right - 4, (Convert.ToInt32(Thumb.Height / 2 + 1))));
            _with29.DrawRectangle(new Pen(_FirstBorder), 0, 0, Width - 1, Height - 1);
            _with29.DrawRectangle(new Pen(_SecondBorder), 1, 1, Width - 3, Height - 3);
            _with29.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }

        #endregion

    }

}


