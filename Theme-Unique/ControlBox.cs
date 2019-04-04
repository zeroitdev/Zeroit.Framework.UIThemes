// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 06-04-2018
// ***********************************************************************
// <copyright file="ControlBox.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Text;


namespace Zeroit.Framework.UIThemes.Unique
{

    public class UniqueControlBox : Control
    {
        private MouseState _state = MouseState.None;
        private int _x;
        private readonly Rectangle _minrect = new Rectangle(5, 2, 24, 24);
        private readonly Rectangle _maxrect = new Rectangle(32, 2, 24, 24);
        private readonly Rectangle _closerect = new Rectangle(59, 2, 24, 24);
        private bool _minDisable = false;
        public bool MinimumDisable
        {
            get
            {
                return _minDisable;
            }
            set
            {
                _minDisable = value;
                Invalidate();
            }
        }

        private bool _maxDisable = false;
        public bool MaximumDisable
        {
            get
            {
                return _maxDisable;
            }
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
                    FindForm().WindowState = FormWindowState.Minimized;
                }
            }
            else if (_x > 32 && _x < 56)
            {
                if (MaximumDisable == false)
                {
                    if (FindForm().WindowState == FormWindowState.Maximized)
                    {
                        FindForm().WindowState = FormWindowState.Minimized;
                        FindForm().WindowState = FormWindowState.Normal;
                    }
                    else
                    {
                        FindForm().WindowState = FormWindowState.Minimized;
                        FindForm().WindowState = FormWindowState.Maximized;
                    }
                }
            }
            else if (_x > 59 && _x < 83)
            {
                FindForm().Close();
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

        public UniqueControlBox() : base()
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
            LinearGradientBrush minrdefault = new LinearGradientBrush(_minrect, Color.FromArgb(89, 87, 85), Color.FromArgb(52, 52, 52), 90);
            g.FillEllipse(minrdefault, _minrect);
            g.DrawEllipse(Pens.DimGray, _minrect);
            LinearGradientBrush maxrdefault = new LinearGradientBrush(_maxrect, Color.FromArgb(89, 87, 85), Color.FromArgb(52, 52, 52), 90);
            g.FillEllipse(maxrdefault, _maxrect);
            g.DrawEllipse(Pens.DimGray, _maxrect);
            LinearGradientBrush crdefault = new LinearGradientBrush(_closerect, Color.FromArgb(89, 87, 85), Color.FromArgb(52, 52, 52), 90);
            g.FillEllipse(crdefault, _closerect);
            g.DrawEllipse(Pens.DimGray, _closerect);
            switch (_state)
            {
                case MouseState.None:
                    LinearGradientBrush minrnone = new LinearGradientBrush(_minrect, Color.FromArgb(89, 87, 85), Color.FromArgb(52, 52, 52), 90);
                    g.FillEllipse(minrnone, _minrect);
                    g.DrawEllipse(Pens.DimGray, _minrect);
                    LinearGradientBrush maxrnone = new LinearGradientBrush(_maxrect, Color.FromArgb(89, 87, 85), Color.FromArgb(52, 52, 52), 90);
                    g.FillEllipse(maxrnone, _maxrect);
                    g.DrawEllipse(Pens.DimGray, _maxrect);
                    LinearGradientBrush crnone = new LinearGradientBrush(_closerect, Color.FromArgb(89, 87, 85), Color.FromArgb(52, 52, 52), 90);
                    g.FillEllipse(crnone, _closerect);
                    g.DrawEllipse(Pens.DimGray, _closerect);
                    break;
                case MouseState.Over:
                    if (_x > 5 && _x < 29)
                    {
                        if (MinimumDisable == false)
                        {
                            LinearGradientBrush minrover = new LinearGradientBrush(_minrect, Color.FromArgb(109, 107, 105), Color.FromArgb(72, 72, 72), 90);
                            g.FillEllipse(minrover, _minrect);
                            g.DrawEllipse(Pens.DimGray, _minrect);
                        }
                    }
                    else if (_x > 32 && _x < 56)
                    {
                        if (MaximumDisable == false)
                        {
                            LinearGradientBrush maxrover = new LinearGradientBrush(_maxrect, Color.FromArgb(109, 107, 105), Color.FromArgb(72, 72, 72), 90);
                            g.FillEllipse(maxrover, _maxrect);
                            g.DrawEllipse(Pens.DimGray, _maxrect);
                        }
                    }
                    else if (_x > 59 && _x < 83)
                    {
                        LinearGradientBrush crover = new LinearGradientBrush(_closerect, Color.FromArgb(109, 107, 105), Color.FromArgb(72, 72, 72), 90);
                        g.FillEllipse(crover, _closerect);
                        g.DrawEllipse(Pens.DimGray, _closerect);
                    }
                    break;
                default:
                    if (MinimumDisable == false)
                    {
                        LinearGradientBrush minrelse = new LinearGradientBrush(_minrect, Color.FromArgb(129, 127, 125), Color.FromArgb(92, 92, 92), 90);
                        g.FillEllipse(minrelse, _minrect);
                        g.DrawEllipse(Pens.DimGray, _minrect);
                    }
                    if (MaximumDisable == false)
                    {
                        LinearGradientBrush maxrelse = new LinearGradientBrush(_maxrect, Color.FromArgb(129, 127, 125), Color.FromArgb(92, 92, 92), 90);
                        g.FillEllipse(maxrelse, _maxrect);
                        g.DrawEllipse(Pens.DimGray, _maxrect);
                    }
                    LinearGradientBrush crelse = new LinearGradientBrush(_closerect, Color.FromArgb(129, 127, 125), Color.FromArgb(92, 92, 92), 90);
                    g.FillEllipse(crelse, _closerect);
                    g.DrawEllipse(Pens.DimGray, _closerect);
                    break;
            }
        }
    }

}