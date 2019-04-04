// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="VerticalScrollBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
    [DefaultEvent("Scroll")]
    public class VisualStudioVerticalScrollBar : Control
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
        public int _Minimum = 0;
        public int _Maximum = 100;
        private int _Value = 0;
        public int _SmallChange = 1;
        private int _ButtonSize = 16;
        public int _LargeChange = 10;
        private bool _ShowOuterBorder = false;
        private bool _ShowThumbBorder = false;
        private __InnerLineCount _AmountOfInnerLines = __InnerLineCount.None;
        private Point _MousePos /*= new Point(_MouseXLoc, _MouseYLoc)*/;
        private MouseState _ThumbState = MouseState.None;
        private MouseState _ArrowState = MouseState.None;
        private int _MouseXLoc;
        private int _MouseYLoc;
        private int ThumbMovement;
        private Rectangle TSA;
        private Rectangle BSA;
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
            //'End Height here goes with end in invalidateposition() for starting height of thumb
            TSA = new Rectangle(0, 0, Width, 16);
            BSA = new Rectangle(0, Height - ButtonSize, Width, ButtonSize);
            //'End height here should be double the start for symetry
            Shaft = new Rectangle(0, TSA.Bottom + 1, Width, Convert.ToInt32(Height - Height / 8 - 8));
            ShowThumb = Convert.ToBoolean(((_Maximum - _Minimum)));
            if (ShowThumb)
            {
                Thumb = new Rectangle(4, 0, Width - 8, Convert.ToInt32(Height / 8));
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

        public void InvalidatePosition()
        {
            Thumb.Y = Convert.ToInt32(((_Value - _Minimum) / (double)(_Maximum - _Minimum)) * (Shaft.Height - _ThumbSize) + 16);
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ShowThumb)
            {
                if (TSA.Contains(e.Location))
                {
                    _ArrowState = MouseState.Down;
                    ThumbMovement = _Value - _SmallChange;
                }
                else if (BSA.Contains(e.Location))
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
                Invalidate();
                InvalidatePosition();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            _MouseXLoc = e.Location.X;
            _MouseYLoc = e.Location.Y;
            if (TSA.Contains(e.Location))
            {
                _ArrowState = MouseState.Over;
            }
            else if (BSA.Contains(e.Location))
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
                int ThumbPosition = e.Y + 2 - TSA.Height - (_ThumbSize / 2);
                int ThumbBounds = Shaft.Height - _ThumbSize;
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
            if (e.Location.Y < 16 || e.Location.Y > Width - 16)
            {
                _ThumbState = MouseState.Over;
            }
            else if (!(e.Location.Y < 16) || e.Location.Y > Width - 16)
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

        public VisualStudioVerticalScrollBar()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.Selectable | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new Size(19, 50);
            _MousePos = new Point(_MouseXLoc, _MouseYLoc);

        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            var g = e.Graphics;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.Clear(_BaseColour);
            Point[] TrianglePointTop = {
            new Point(Convert.ToInt32(Width / 2), 5),
            new Point(Convert.ToInt32(Width / 4), 11),
            new Point(Convert.ToInt32(Width / 2 + Width / 4), 11)
        };
            Point[] TrianglePointBottom = {
            new Point(Convert.ToInt32(Width / 2), Height - 5),
            new Point(Convert.ToInt32(Width / 4), Height - 11),
            new Point(Convert.ToInt32(Width / 2 + Width / 4), Height - 11)
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
                    if (_MouseYLoc < 16)
                    {
                        g.FillPolygon(new SolidBrush(_ArrowPressedColour), TrianglePointTop);
                        g.FillPolygon(new SolidBrush(_ArrowNormalColour), TrianglePointBottom);

                    }
                    else if (_MouseXLoc > Width - 16)
                    {
                        g.FillPolygon(new SolidBrush(_ArrowPressedColour), TrianglePointBottom);
                        g.FillPolygon(new SolidBrush(_ArrowNormalColour), TrianglePointTop);
                    }
                    else
                    {
                        g.FillPolygon(new SolidBrush(_ArrowNormalColour), TrianglePointTop);
                        g.FillPolygon(new SolidBrush(_ArrowNormalColour), TrianglePointBottom);
                    }
                    break;
                case MouseState.Over:

                    if (_MouseYLoc < 16)
                    {
                        g.FillPolygon(new SolidBrush(_ArrowHoveerColour), TrianglePointTop);
                        g.FillPolygon(new SolidBrush(_ArrowNormalColour), TrianglePointBottom);
                    }
                    else if (_MouseXLoc > Width - 16)
                    {
                        g.FillPolygon(new SolidBrush(_ArrowHoveerColour), TrianglePointBottom);
                        g.FillPolygon(new SolidBrush(_ArrowNormalColour), TrianglePointTop);
                    }
                    else
                    {
                        g.FillPolygon(new SolidBrush(_ArrowNormalColour), TrianglePointTop);
                        g.FillPolygon(new SolidBrush(_ArrowNormalColour), TrianglePointBottom);
                    }
                    break;
                case MouseState.None:

                    g.FillPolygon(new SolidBrush(_ArrowNormalColour), TrianglePointTop);
                    g.FillPolygon(new SolidBrush(_ArrowNormalColour), TrianglePointBottom);
                    break;
            }
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }

        #endregion

    }

}
