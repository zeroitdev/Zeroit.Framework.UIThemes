// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ScrollBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.SLC
{
    #region "SLCScrollBar"
    [DefaultEvent("Scroll")]
    public class SLCScrollBar : Control
    {

        public event ScrollEventHandler Scroll;
        public delegate void ScrollEventHandler(object sender);

        private int _Minimum;
        public int Minimum
        {
            get { return _Minimum; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Minimum = value;
                if (value > _Value)
                    _Value = value;
                if (value > _Maximum)
                    _Maximum = value;

                InvalidateLayout();
            }
        }

        private int _Maximum = 100;
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 1)
                    value = 1;

                _Maximum = value;
                if (value < _Value)
                    _Value = value;
                if (value < _Minimum)
                    _Minimum = value;

                InvalidateLayout();
            }
        }

        private int _Value;
        public int Value
        {
            get
            {
                if (!ShowThumb)
                    return _Minimum;
                return _Value;
            }
            set
            {
                if (value == _Value)
                    return;

                if (value > _Maximum || value < _Minimum)
                {
                    throw new Exception("Property value is not valid.");
                }

                _Value = value;
                InvalidatePosition();

                if (Scroll != null)
                {
                    Scroll(this);
                }
            }
        }

        public double _Percent { get; set; }
        public double Percent
        {
            get
            {
                if (!ShowThumb)
                    return 0;
                return GetProgress();
            }
        }

        private int _SmallChange = 1;
        public int SmallChange
        {
            get { return _SmallChange; }
            set
            {
                if (value < 1)
                {
                    throw new Exception("Property value is not valid.");
                }

                _SmallChange = value;
            }
        }

        private int _LargeChange = 10;
        public int LargeChange
        {
            get { return _LargeChange; }
            set
            {
                if (value < 1)
                {
                    throw new Exception("Property value is not valid.");
                }

                _LargeChange = value;
            }
        }

        private int ButtonSize = 16;
        // 14 minimum
        private int ThumbSize = 24;

        private Rectangle TSA;
        private Rectangle BSA;
        private Rectangle Shaft;

        private Rectangle Thumb;
        private bool ShowThumb;

        private bool ThumbDown;
        public SLCScrollBar()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            Width = 18;


        }

        private GraphicsPath GP1;
        private GraphicsPath GP2;
        private GraphicsPath GP3;

        private GraphicsPath GP4;



        int I1;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            G = e.Graphics;
            G.Clear(Color.FromArgb(255, 255, 255));

            GP1 = DrawArrow(4, 6, false);
            GP2 = DrawArrow(5, 7, false);

            G.FillPath(new SolidBrush(Color.LightGray), GP2);
            G.FillPath(new SolidBrush(Color.FromArgb(83, 123, 168)), GP1);

            GP3 = DrawArrow(4, Height - 11, true);
            GP4 = DrawArrow(5, Height - 10, true);

            G.FillPath(new SolidBrush(Color.LightGray), GP4);
            G.FillPath(new SolidBrush(Color.FromArgb(83, 123, 168)), GP3);

            if (ShowThumb)
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(250, 250, 250)), Thumb);
                G.DrawRectangle(Pens.LightGray, Thumb);
                G.DrawRectangle(Pens.White, Thumb.X + 1, Thumb.Y + 1, Thumb.Width - 2, Thumb.Height - 2);

                int Y = 0;
                int LY = Thumb.Y + (Thumb.Height / 2) - 3;

                for (int I = 0; I <= 2; I++)
                {
                    Y = LY + (I * 3);

                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(68, 95, 127))), Thumb.X + 5, Y, Thumb.Right - 5, Y);
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(50, Color.FromArgb(68, 95, 127)))), Thumb.X + 5, Y + 1, Thumb.Right - 5, Y + 1);
                }
            }
            G.SmoothingMode = SmoothingMode.HighQuality;
            //G.DrawRectangle(New Pen(New SolidBrush(Color.Red)), 0, 0, Width - 1, Height - 1)
            G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(59, 122, 165))), RoundRec(new Rectangle(1, 1, Width - 3, Height - 3), 4));
            G.SmoothingMode = SmoothingMode.None;
        }

        private GraphicsPath DrawArrow(int x, int y, bool flip)
        {
            GraphicsPath GP = new GraphicsPath();

            int W = 9;
            int H = 5;

            if (flip)
            {
                GP.AddLine(x + 1, y, x + W + 1, y);
                GP.AddLine(x + W, y, x + H, y + H - 1);
            }
            else
            {
                GP.AddLine(x, y + H, x + W, y + H);
                GP.AddLine(x + W, y + H, x + H, y);
            }

            GP.CloseFigure();
            return GP;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            InvalidateLayout();
        }

        private void InvalidateLayout()
        {
            TSA = new Rectangle(0, 0, Width, ButtonSize);
            BSA = new Rectangle(0, Height - ButtonSize, Width, ButtonSize);
            Shaft = new Rectangle(0, TSA.Bottom + 1, Width, Height - (ButtonSize * 2) - 1);

            ShowThumb = ((_Maximum - _Minimum) > Shaft.Height);

            if (ShowThumb)
            {
                //ThumbSize = Math.Max(0, 14) 'TODO: Implement this.
                Thumb = new Rectangle(1, 0, Width - 3, ThumbSize);
            }

            if (Scroll != null)
            {
                Scroll(this);
            }
            InvalidatePosition();
        }

        private void InvalidatePosition()
        {
            Thumb.Y = Convert.ToInt32(GetProgress() * (Shaft.Height - ThumbSize)) + TSA.Height;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ShowThumb)
            {
                if (TSA.Contains(e.Location))
                {
                    I1 = _Value - _SmallChange;
                }
                else if (BSA.Contains(e.Location))
                {
                    I1 = _Value + _SmallChange;
                }
                else
                {
                    if (Thumb.Contains(e.Location))
                    {
                        ThumbDown = true;
                        base.OnMouseDown(e);
                        return;
                    }
                    else
                    {
                        if (e.Y < Thumb.Y)
                        {
                            I1 = _Value - _LargeChange;
                        }
                        else
                        {
                            I1 = _Value + _LargeChange;
                        }
                    }
                }

                Value = Math.Min(Math.Max(I1, _Minimum), _Maximum);
                InvalidatePosition();
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (ThumbDown && ShowThumb)
            {
                int ThumbPosition = e.Y - TSA.Height - (ThumbSize / 2);
                int ThumbBounds = Shaft.Height - ThumbSize;

                I1 = Convert.ToInt32((ThumbPosition / ThumbBounds) * (_Maximum - _Minimum)) + _Minimum;

                Value = Math.Min(Math.Max(I1, _Minimum), _Maximum);
                InvalidatePosition();
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            ThumbDown = false;
            base.OnMouseUp(e);
        }

        private double GetProgress()
        {
            return (_Value - _Minimum) / (_Maximum - _Minimum);
        }

        public GraphicsPath RoundRec(Rectangle Rectangle, int Curve)
        {
            GraphicsPath P = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return P;
        }
    }
    #endregion

}

