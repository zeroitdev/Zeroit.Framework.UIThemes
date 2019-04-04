// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
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
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.VisualStudio
{
    public class VisualStudioHorizontalScrollBar : Control
    {
        #region Declarations

        private Color _BaseColour = Color.FromArgb(62, 62, 66);
        private Color _ThumbNormalColour = Color.FromArgb(104, 104, 104);
        private Color _ThumbHoverColour = Color.FromArgb(158, 158, 158);
        private Color _ThumbPressedColour = Color.FromArgb(239, 235, 239);
        private Color _ArrowNormalColour = Color.FromArgb(153, 153, 153);
        private Color _ArrowHoveerColour = Color.FromArgb(39, 123, 181);
        private Color _ArrowPressedColour = Color.FromArgb(0, 113, 171);
        private Color _OuterBorderColour;
        private Color _ThumbBorderColour;
        private int _Minimum = 0;
        private int _Maximum = 100;
        private int _Value = 0;
        private int _SmallChange = 1;
        private int _ButtonSize = 16;
        private int _LargeChange = 10;
        private bool _ShowOuterBorder = false;
        private bool _ShowThumbBorder = false;
        private __InnerLineCount _AmountOfInnerLines = __InnerLineCount.None;
        private Point _MousePos /*= new Point(_MouseXLoc, _MouseYLoc)*/;
        private MouseState _ThumbState = MouseState.None;
        private MouseState _ArrowState = MouseState.None;
        private int _MouseXLoc;
        private int _MouseYLoc;
        private int ThumbMovement;
        private Rectangle LSA;
        private Rectangle RSA;
        private Rectangle Shaft;
        private Rectangle Thumb;
        private bool ShowThumb;
        private bool ThumbPressed;
        private int _ThumbSize = 24;


        #endregion

        #region Properties & Events

        [Category("Colours")]
        public Color BaseColour
        {
            get
            {
                return _BaseColour;
            }
            set
            {
                _BaseColour = value;
            }
        }

        [Category("Colours")]
        public Color ThumbNormalColour
        {
            get
            {
                return _ThumbNormalColour;
            }
            set
            {
                _ThumbNormalColour = value;
            }
        }

        [Category("Colours")]
        public Color ThumbHoverColour
        {
            get
            {
                return _ThumbHoverColour;
            }
            set
            {
                _ThumbHoverColour = value;
            }
        }

        [Category("Colours")]
        public Color ThumbPressedColour
        {
            get
            {
                return _ThumbPressedColour;
            }
            set
            {
                _ThumbPressedColour = value;
            }
        }

        [Category("Colours")]
        public Color ArrowNormalColour
        {
            get
            {
                return _ArrowNormalColour;
            }
            set
            {
                _ArrowNormalColour = value;
            }
        }

        [Category("Colours")]
        public Color ArrowHoveerColour
        {
            get
            {
                return _ArrowHoveerColour;
            }
            set
            {
                _ArrowHoveerColour = value;
            }
        }

        [Category("Colours")]
        public Color ArrowPressedColour
        {
            get
            {
                return _ArrowPressedColour;
            }
            set
            {
                _ArrowPressedColour = value;
            }
        }

        [Category("Colours")]
        public Color OuterBorderColour
        {
            get
            {
                return _OuterBorderColour;
            }
            set
            {
                _OuterBorderColour = value;
            }
        }

        [Category("Colours")]
        public Color ThumbBorderColour
        {
            get
            {
                return _ThumbBorderColour;
            }
            set
            {
                _ThumbBorderColour = value;
            }
        }

        [Category("Control")]
        public int Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                _Minimum = value;
                if (value > _Value)
                {
                    _Value = value;
                }
                if (value > _Maximum)
                {
                    _Maximum = value;
                }
                InvalidateLayout();
            }
        }

        [Category("Control")]
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                if (value < _Value)
                {
                    _Value = value;
                }
                if (value < _Minimum)
                {
                    _Minimum = value;
                }
                InvalidateLayout();
            }
        }

        [Category("Control")]
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value == _Value)
                {
                    return;
                }
                //ORIGINAL LINE: Case Is < _Minimum
                else if (value < _Minimum)
                {
                    _Value = _Minimum;
                }
                //ORIGINAL LINE: Case Is > _Maximum
                else if (value > _Maximum)
                {
                    _Value = _Maximum;
                }
                //ORIGINAL LINE: Case Else
                else
                {
                    _Value = value;
                }
                InvalidatePosition();
                if (Scroll != null)
                    Scroll(this);
            }
        }

        [Category("Control")]
        public int SmallChange
        {
            get
            {
                return _SmallChange;
            }
            set
            {
                if (value < 1)
                {
                }
                //ORIGINAL LINE: Case Is > CInt(_SmallChange = value)
                else if (value > Convert.ToInt32(_SmallChange == value))
                {
                }
            }
        }

        [Category("Control")]
        public int LargeChange
        {
            get
            {
                return _LargeChange;
            }
            set
            {
                if (value < 1)
                {
                }
                //ORIGINAL LINE: Case Else
                else
                {
                    _LargeChange = value;
                }
            }
        }

        [Category("Control")]
        public int ButtonSize
        {
            get
            {
                return _ButtonSize;
            }
            set
            {
                if (value < 16)
                {
                    _ButtonSize = 16;
                }
                //ORIGINAL LINE: Case Else
                else
                {
                    _ButtonSize = value;
                }
            }
        }

        [Category("Control")]
        public bool ShowOuterBorder
        {
            get
            {
                return _ShowOuterBorder;
            }
            set
            {
                _ShowOuterBorder = value;
                Invalidate();
            }
        }

        [Category("Control")]
        public bool ShowThumbBorder
        {
            get
            {
                return _ShowThumbBorder;
            }
            set
            {
                _ShowThumbBorder = value;
                Invalidate();
            }
        }

        [Category("Control")]
        public __InnerLineCount AmountOfInnerLines
        {
            get
            {
                return _AmountOfInnerLines;
            }
            set
            {
                _AmountOfInnerLines = value;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            InvalidateLayout();
        }

        private void InvalidateLayout()
        {

            //'End width here goes with end in invalidateposition() for starting height of thumb
            LSA = new Rectangle(0, 0, 16, Height);
            RSA = new Rectangle(Width - ButtonSize, 0, ButtonSize, Height);
            //'End width here should be double the start for symetry
            Shaft = new Rectangle(LSA.Right + 1, 0, Convert.ToInt32(Width - Width / 8 - 8), Height);
            ShowThumb = Convert.ToBoolean(((_Maximum - _Minimum)));
            if (ShowThumb)
            {
                Thumb = new Rectangle(0, 4, Convert.ToInt32(Width / 8), Height - 8);
            }
            if (Scroll != null)
                Scroll(this);
            InvalidatePosition();
        }

        public enum __InnerLineCount
        {
            None,
            One,
            Two,
            Three
        }

        public delegate void ScrollEventHandler(object sender);
        public event ScrollEventHandler Scroll;

        private void InvalidatePosition()
        {
            Thumb.X = Convert.ToInt32(((_Value - _Minimum) / (double)(_Maximum - _Minimum)) * (Shaft.Width - _ThumbSize) + 16);
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ShowThumb)
            {
                if (LSA.Contains(e.Location))
                {
                    _ArrowState = MouseState.Down;
                    ThumbMovement = _Value - _SmallChange;
                }
                else if (RSA.Contains(e.Location))
                {
                    ThumbMovement = _Value + _SmallChange;
                    _ArrowState = MouseState.Down;
                }
                else
                {
                    if (Thumb.Contains(e.Location))
                    {
                        _ThumbState = MouseState.Down;
                        Invalidate();
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
                Invalidate();
                InvalidatePosition();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            _MouseXLoc = e.Location.X;
            _MouseYLoc = e.Location.Y;
            if (LSA.Contains(e.Location))
            {
                _ArrowState = MouseState.Over;
            }
            else if (RSA.Contains(e.Location))
            {
                _ArrowState = MouseState.Over;
            }
            else if (!(_ArrowState == MouseState.Down))
            {
                _ArrowState = MouseState.None;
            }
            if (Thumb.Contains(e.Location) && !(_ThumbState == MouseState.Down))
            {
                _ThumbState = MouseState.Over;
            }
            else if (!(_ThumbState == MouseState.Down))
            {
                _ThumbState = MouseState.None;
            }
            Invalidate();
            if (_ThumbState == MouseState.Down || _ArrowState == MouseState.Down && ShowThumb)
            {
                int ThumbPosition = e.X + 2 - LSA.Width - (_ThumbSize / 2);
                int ThumbBounds = Shaft.Width - _ThumbSize;
                ThumbMovement = Convert.ToInt32((ThumbPosition / (double)ThumbBounds) * (_Maximum - _Minimum)) - _Minimum;
                Value = Math.Min(Math.Max(ThumbMovement, _Minimum), _Maximum);
                InvalidatePosition();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (Thumb.Contains(e.Location))
            {
                _ThumbState = MouseState.Over;
            }
            else if (!(Thumb.Contains(e.Location)))
            {
                _ThumbState = MouseState.None;
            }
            if (e.Location.X < 16 || e.Location.X > Width - 16)
            {
                _ThumbState = MouseState.Over;
            }
            else if (!(e.Location.X < 16) || e.Location.X > Width - 16)
            {
                _ThumbState = MouseState.None;
            }
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _ThumbState = MouseState.None;
            _ArrowState = MouseState.None;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Invalidate();
        }

        #endregion

        #region Draw Control

        public VisualStudioHorizontalScrollBar()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.Selectable | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new Size(50, 19);
            _MousePos = new Point(_MouseXLoc, _MouseYLoc);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            var g = e.Graphics;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.Clear(_BaseColour);
            Point[] TrianglePointLeft = {
            new Point(5, Convert.ToInt32(Height / 2)),
            new Point(11, Convert.ToInt32(Height / 4)),
            new Point(11, Convert.ToInt32(Height / 2 + Height / 4))
        };
            Point[] TrianglePointRight = {
            new Point(Width - 5, Convert.ToInt32(Height / 2)),
            new Point(Width - 11, Convert.ToInt32(Height / 4)),
            new Point(Width - 11, Convert.ToInt32(Height / 2 + Height / 4))
        };
            switch (_ThumbState)
            {
                case MouseState.None:
                    using (SolidBrush SBrush = new SolidBrush(_ThumbNormalColour))
                    {
                        g.FillRectangle(SBrush, Thumb);
                    }
                    break;
                case MouseState.Over:
                    using (SolidBrush SBrush = new SolidBrush(_ThumbHoverColour))
                    {
                        g.FillRectangle(SBrush, Thumb);
                    }
                    break;
                case MouseState.Down:
                    using (SolidBrush SBrush = new SolidBrush(_ThumbPressedColour))
                    {
                        g.FillRectangle(SBrush, Thumb);
                    }
                    break;
            }
            switch (_ArrowState)
            {
                case MouseState.Down:
                    if (!(Thumb.Contains(_MousePos)))
                    {
                        using (SolidBrush SBrush = new SolidBrush(_ThumbNormalColour))
                        {
                            g.FillRectangle(SBrush, Thumb);
                        }
                    }
                    if (_MouseXLoc < 16)
                    {
                        g.FillPolygon(new SolidBrush(_ArrowPressedColour), TrianglePointLeft);
                        g.FillPolygon(new SolidBrush(_ArrowNormalColour), TrianglePointRight);

                    }
                    else if (_MouseXLoc > Width - 16)
                    {
                        g.FillPolygon(new SolidBrush(_ArrowPressedColour), TrianglePointRight);
                        g.FillPolygon(new SolidBrush(_ArrowNormalColour), TrianglePointLeft);
                    }
                    else
                    {
                        g.FillPolygon(new SolidBrush(_ArrowNormalColour), TrianglePointLeft);
                        g.FillPolygon(new SolidBrush(_ArrowNormalColour), TrianglePointRight);
                    }
                    break;
                case MouseState.Over:

                    if (_MouseXLoc < 16)
                    {
                        g.FillPolygon(new SolidBrush(_ArrowHoveerColour), TrianglePointLeft);
                        g.FillPolygon(new SolidBrush(_ArrowNormalColour), TrianglePointRight);
                    }
                    else if (_MouseXLoc > Width - 16)
                    {
                        g.FillPolygon(new SolidBrush(_ArrowHoveerColour), TrianglePointRight);
                        g.FillPolygon(new SolidBrush(_ArrowNormalColour), TrianglePointLeft);
                    }
                    else
                    {
                        g.FillPolygon(new SolidBrush(_ArrowNormalColour), TrianglePointLeft);
                        g.FillPolygon(new SolidBrush(_ArrowNormalColour), TrianglePointRight);
                    }
                    break;
                case MouseState.None:

                    g.FillPolygon(new SolidBrush(_ArrowNormalColour), TrianglePointLeft);
                    g.FillPolygon(new SolidBrush(_ArrowNormalColour), TrianglePointRight);
                    break;
            }
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }

        #endregion
    }

}
