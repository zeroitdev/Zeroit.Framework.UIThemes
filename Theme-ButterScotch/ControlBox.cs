// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ControlBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Butter
{
    public class ButterscotchControlBox : Control
    {
        MouseState _state = MouseState.None;
        int _x;
        readonly Rectangle _minrect = new Rectangle(5, 2, 24, 24);
        readonly Rectangle _maxrect = new Rectangle(32, 2, 24, 24);
        readonly Rectangle _closerect = new Rectangle(59, 2, 24, 24);
        private bool _minDisable = false;
        public bool MinimumDisable
        {
            get { return _minDisable; }
            set
            {
                _minDisable = value;
                Invalidate();
            }
        }

        private bool _maxDisable = false;
        public bool MaximumDisable
        {
            get { return _maxDisable; }
            set
            {
                _maxDisable = value;
                Invalidate();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (_x > 5 && _x < 29)
            {
                if (MinimumDisable == false)
                {
                    Parent.FindForm().WindowState = FormWindowState.Minimized;
                }
            }
            else if (_x > 32 && _x < 56)
            {
                if (MaximumDisable == false)
                {
                    if (Parent.FindForm().WindowState == FormWindowState.Maximized)
                    {
                        Parent.FindForm().WindowState = FormWindowState.Minimized;
                        Parent.FindForm().WindowState = FormWindowState.Normal;
                    }
                    else
                    {
                        Parent.FindForm().WindowState = FormWindowState.Minimized;
                        Parent.FindForm().WindowState = FormWindowState.Maximized;
                    }
                }
            }
            else if (_x > 59 && _x < 83)
            {
                Parent.FindForm().Close();
            }
            _state = MouseState.Down;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _state = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _state = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _state = MouseState.None;
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            _x = e.Location.X;
            Invalidate();
        }

        public ButterscotchControlBox()
            : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Width = 85;
            Height = 30;
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            base.OnPaint(e);
            g.SmoothingMode = SmoothingMode.HighQuality;
            LinearGradientBrush minrdefault = new LinearGradientBrush(_minrect, Color.FromArgb(100, 90, 80), Color.FromArgb(25, 23, 22), 90);
            g.FillRectangle(minrdefault, _minrect);
            g.DrawRectangle(Pens.Black, _minrect);
            LinearGradientBrush maxrdefault = new LinearGradientBrush(_maxrect, Color.FromArgb(100, 90, 80), Color.FromArgb(25, 23, 22), 90);
            g.FillRectangle(maxrdefault, _maxrect);
            g.DrawRectangle(Pens.Black, _maxrect);
            LinearGradientBrush crdefault = new LinearGradientBrush(_closerect, Color.FromArgb(100, 90, 80), Color.FromArgb(25, 23, 22), 90);
            g.FillRectangle(crdefault, _closerect);
            g.DrawRectangle(Pens.Black, _closerect);
            switch (_state)
            {
                case MouseState.None:
                    LinearGradientBrush minrnone = new LinearGradientBrush(_minrect, Color.FromArgb(100, 90, 80), Color.FromArgb(25, 23, 22), 90);
                    g.FillRectangle(minrnone, _minrect);
                    g.DrawRectangle(Pens.Black, _minrect);
                    LinearGradientBrush maxrnone = new LinearGradientBrush(_maxrect, Color.FromArgb(100, 90, 80), Color.FromArgb(25, 23, 22), 90);
                    g.FillRectangle(maxrnone, _maxrect);
                    g.DrawRectangle(Pens.Black, _maxrect);
                    LinearGradientBrush crnone = new LinearGradientBrush(_closerect, Color.FromArgb(100, 90, 80), Color.FromArgb(25, 23, 22), 90);
                    g.FillRectangle(crnone, _closerect);
                    g.DrawRectangle(Pens.Black, _closerect);
                    break;
                case MouseState.Over:
                    if (_x > 5 && _x < 29)
                    {
                        if (MinimumDisable == false)
                        {
                            LinearGradientBrush minrover = new LinearGradientBrush(_minrect, Color.FromArgb(25, 23, 22), Color.FromArgb(100, 90, 80), 90);
                            g.FillRectangle(minrover, _minrect);
                            g.DrawRectangle(Pens.DimGray, _minrect);
                        }
                    }
                    else if (_x > 32 && _x < 56)
                    {
                        if (MaximumDisable == false)
                        {
                            LinearGradientBrush maxrover = new LinearGradientBrush(_maxrect, Color.FromArgb(25, 23, 22), Color.FromArgb(100, 90, 80), 90);
                            g.FillRectangle(maxrover, _maxrect);
                            g.DrawRectangle(Pens.DimGray, _maxrect);
                        }
                    }
                    else if (_x > 59 && _x < 83)
                    {
                        LinearGradientBrush crover = new LinearGradientBrush(_closerect, Color.FromArgb(25, 23, 22), Color.FromArgb(100, 90, 80), 90);
                        g.FillRectangle(crover, _closerect);
                        g.DrawRectangle(Pens.DimGray, _closerect);
                    }
                    break;
                default:
                    if (MinimumDisable == false)
                    {
                        LinearGradientBrush minrelse = new LinearGradientBrush(_minrect, Color.FromArgb(100, 90, 80), Color.FromArgb(25, 23, 22), 90);
                        g.FillRectangle(minrelse, _minrect);
                        g.DrawRectangle(Pens.Silver, _minrect);
                    }
                    if (MaximumDisable == false)
                    {
                        LinearGradientBrush maxrelse = new LinearGradientBrush(_maxrect, Color.FromArgb(100, 90, 80), Color.FromArgb(25, 23, 22), 90);
                        g.FillRectangle(maxrelse, _maxrect);
                        g.DrawRectangle(Pens.Silver, _maxrect);
                    }
                    LinearGradientBrush crelse = new LinearGradientBrush(_closerect, Color.FromArgb(100, 90, 80), Color.FromArgb(25, 23, 22), 90);
                    g.FillRectangle(crelse, _closerect);
                    g.DrawRectangle(Pens.Silver, _closerect);
                    break;
            }
        }
    }


}
