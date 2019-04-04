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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.NeSeal
{
    [DefaultEvent("Scroll")]
    public class NSHScrollBar : Control
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
                if (value < 0)
                {
                    throw new Exception("Property value is not valid.");
                }

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

        private Rectangle LSA;
        private Rectangle RSA;
        private Rectangle Shaft;

        private Rectangle Thumb;
        private bool ShowThumb;

        private bool ThumbDown;
        public NSHScrollBar()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            Height = 18;

            B1 = new SolidBrush(Color.FromArgb(55, 55, 55));
            B2 = new SolidBrush(Color.FromArgb(24, 24, 24));

            P1 = new Pen(Color.FromArgb(24, 24, 24));
            P2 = new Pen(Color.FromArgb(65, 65, 65));
            P3 = new Pen(Color.FromArgb(55, 55, 55));
            P4 = new Pen(Color.FromArgb(40, 40, 40));
        }

        private GraphicsPath GP1;
        private GraphicsPath GP2;
        private GraphicsPath GP3;

        private GraphicsPath GP4;
        private Pen P1;
        private Pen P2;
        private Pen P3;
        private Pen P4;
        private SolidBrush B1;

        private SolidBrush B2;

        int I1;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            ThemeModule theme = new ThemeModule();
            var G = theme.G;

            G = e.Graphics;
            G.Clear(BackColor);

            GP1 = DrawArrow(6, 4, false);
            GP2 = DrawArrow(7, 5, false);

            G.FillPath(B1, GP2);
            G.FillPath(B2, GP1);

            GP3 = DrawArrow(Width - 11, 4, true);
            GP4 = DrawArrow(Width - 10, 5, true);

            G.FillPath(B1, GP4);
            G.FillPath(B2, GP3);

            if (ShowThumb)
            {
                G.FillRectangle(B1, Thumb);
                G.DrawRectangle(P1, Thumb);
                G.DrawRectangle(P2, Thumb.X + 1, Thumb.Y + 1, Thumb.Width - 2, Thumb.Height - 2);

                int X = 0;
                int LX = Thumb.X + (Thumb.Width / 2) - 3;

                for (int I = 0; I <= 2; I++)
                {
                    X = LX + (I * 3);

                    G.DrawLine(P1, X, Thumb.Y + 5, X, Thumb.Bottom - 5);
                    G.DrawLine(P2, X + 1, Thumb.Y + 5, X + 1, Thumb.Bottom - 5);
                }
            }

            G.DrawRectangle(P3, 0, 0, Width - 1, Height - 1);
            G.DrawRectangle(P4, 1, 1, Width - 3, Height - 3);
        }

        private GraphicsPath DrawArrow(int x, int y, bool flip)
        {
            GraphicsPath GP = new GraphicsPath();

            int W = 5;
            int H = 9;

            if (flip)
            {
                GP.AddLine(x, y + 1, x, y + H + 1);
                GP.AddLine(x, y + H, x + W - 1, y + W);
            }
            else
            {
                GP.AddLine(x + W, y, x + W, y + H);
                GP.AddLine(x + W, y + H, x + 1, y + W);
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
            LSA = new Rectangle(0, 0, ButtonSize, Height);
            RSA = new Rectangle(Width - ButtonSize, 0, ButtonSize, Height);
            Shaft = new Rectangle(LSA.Right + 1, 0, Width - (ButtonSize * 2) - 1, Height);

            ShowThumb = ((_Maximum - _Minimum) > Shaft.Width);

            if (ShowThumb)
            {
                //ThumbSize = Math.Max(0, 14) 'TODO: Implement this.
                Thumb = new Rectangle(0, 1, ThumbSize, Height - 3);
            }

            if (Scroll != null)
            {
                Scroll(this);
            }
            InvalidatePosition();
        }

        private void InvalidatePosition()
        {
            Thumb.X = Convert.ToInt32(GetProgress() * (Shaft.Width - ThumbSize)) + LSA.Width;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ShowThumb)
            {
                if (LSA.Contains(e.Location))
                {
                    I1 = _Value - _SmallChange;
                }
                else if (RSA.Contains(e.Location))
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
                        if (e.X < Thumb.X)
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
                int ThumbPosition = e.X - LSA.Width - (ThumbSize / 2);
                int ThumbBounds = Shaft.Width - ThumbSize;

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

    }

}


