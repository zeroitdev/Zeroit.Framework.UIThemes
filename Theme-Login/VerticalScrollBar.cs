// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="VerticalScrollBar.cs" company="Zeroit Dev Technologies">
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
    public class LogInVerticalScrollBar : Control
    {

        #region "Declarations"

        private int ThumbMovement;
        private Rectangle TSA;
        private Rectangle BSA;
        private Rectangle Shaft;
        private Rectangle Thumb;
        private bool ShowThumb;
        private bool ThumbPressed;
        private int _ThumbSize = 24;
        public int _Minimum = 0;
        public int _Maximum = 100;
        public int _Value = 0;
        public int _SmallChange = 1;
        private int _ButtonSize = 16;
        public int _LargeChange = 10;
        private Color _ThumbBorder = Color.FromArgb(35, 35, 35);
        private Color _LineColour = Color.FromArgb(23, 119, 151);
        private Color _ArrowColour = Color.FromArgb(37, 37, 37);
        private Color _BaseColour = Color.FromArgb(47, 47, 47);
        private Color _ThumbColour = Color.FromArgb(55, 55, 55);
        private Color _ThumbSecondBorder = Color.FromArgb(65, 65, 65);
        private Color _FirstBorder = Color.FromArgb(55, 55, 55);

        private Color _SecondBorder = Color.FromArgb(35, 35, 35);
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

                _SmallChange = value;/* Convert.ToInt32(value);*/
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
                    case 16: // ERROR: Case labels with binary operators are unsupported : LessThan

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
            TSA = new Rectangle(0, 1, Width, 0);
            Shaft = new Rectangle(0, TSA.Bottom - 1, Width, Height - 3);
            ShowThumb = Convert.ToBoolean(((_Maximum - _Minimum)));
            if (ShowThumb)
            {
                Thumb = new Rectangle(1, 0, Width - 3, _ThumbSize);
            }
            if (Scroll != null)
            {
                Scroll(this);
            }
            InvalidatePosition();
        }

        private void InvalidatePosition()
        {
            Thumb.Y = Convert.ToInt32(((_Value - _Minimum) / (_Maximum - _Minimum)) * (Shaft.Height - _ThumbSize) + 1);
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ShowThumb)
            {
                if (TSA.Contains(e.Location))
                {
                    ThumbMovement = _Value - _SmallChange;
                }
                else if (BSA.Contains(e.Location))
                {
                    ThumbMovement = _Value + _SmallChange;
                }
                else
                {
                    if (Thumb.Contains(e.Location))
                    {
                        ThumbPressed = true;
                        return;
                    }
                    else
                    {
                        if (e.Y < Thumb.Y)
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
            if (ThumbPressed && ShowThumb)
            {
                int ThumbPosition = e.Y - TSA.Height - (_ThumbSize / 2);
                int ThumbBounds = Shaft.Height - _ThumbSize;
                ThumbMovement = Convert.ToInt32((ThumbPosition / ThumbBounds) * (_Maximum - _Minimum)) + _Minimum;
                Value = Math.Min(Math.Max(ThumbMovement, _Minimum), _Maximum);
                InvalidatePosition();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            ThumbPressed = false;
        }

        #endregion

        #region "Draw Control"

        public LogInVerticalScrollBar()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.Selectable | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new Size(24, 50);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            var _with28 = g;
            _with28.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with28.SmoothingMode = SmoothingMode.HighQuality;
            _with28.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with28.Clear(_BaseColour);
            Point[] P = {
            new Point(Convert.ToInt32(Width / 2), 5),
            new Point(Convert.ToInt32(Width / 4), 13),
            new Point(Convert.ToInt32(Width / 2 - 2), 13),
            new Point(Convert.ToInt32(Width / 2 - 2), Height - 13),
            new Point(Convert.ToInt32(Width / 4), Height - 13),
            new Point(Convert.ToInt32(Width / 2), Height - 5),
            new Point(Convert.ToInt32(Width - Width / 4 - 1), Height - 13),
            new Point(Convert.ToInt32(Width / 2 + 2), Height - 13),
            new Point(Convert.ToInt32(Width / 2 + 2), 13),
            new Point(Convert.ToInt32(Width - Width / 4 - 1), 13)
        };
            _with28.FillPolygon(new SolidBrush(_ArrowColour), P);
            _with28.FillRectangle(new SolidBrush(_ThumbColour), Thumb);
            _with28.DrawRectangle(new Pen(_ThumbBorder), Thumb);
            _with28.DrawRectangle(new Pen(_ThumbSecondBorder), Thumb.X + 1, Thumb.Y + 1, Thumb.Width - 2, Thumb.Height - 2);
            _with28.DrawLine(new Pen(_LineColour, 2), new Point(Convert.ToInt32(Thumb.Width / 2 + 1), Thumb.Y + 4), new Point(Convert.ToInt32(Thumb.Width / 2 + 1), Thumb.Bottom - 4));
            _with28.DrawRectangle(new Pen(_FirstBorder), 0, 0, Width - 1, Height - 1);
            _with28.DrawRectangle(new Pen(_SecondBorder), 1, 1, Width - 3, Height - 3);
            _with28.InterpolationMode = InterpolationMode.HighQualityBicubic;

        }

        #endregion

    }

}


