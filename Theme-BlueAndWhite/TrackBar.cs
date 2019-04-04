// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="TrackBar.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.BlueWhite
{

    [DefaultEvent("Scroll")]
    public class BaWGUITrackBar : Control
    {
        #region " Declarations "
        private bool Moveable;
        private GraphicsPath Slider;
        private GraphicsPath Track;
        private int DrawValue;
        private LinearGradientBrush SliderGB;
        private LinearGradientBrush SliderOGB;
        private Pen P1;
        private Pen P2;
        private Pen P3;
        private SolidBrush B1;

        private SolidBrush B2;
        public event ScrollEventHandler Scroll;
        public delegate void ScrollEventHandler(object sender);

        private int _Maximum = 10;
        private int _Minimum;
        #endregion
        private int _Value;

        #region " Properties "
        [Category("Behavior")]
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                _Maximum = value;
                if (value < _Value)
                    _Value = value;
                if (value < _Minimum)
                    _Minimum = value;

                DrawValue = Convert.ToInt32((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 24));
                ChangePaths();
                Invalidate();
            }
        }

        [Category("Behavior")]
        public int Minimum
        {
            get { return _Minimum; }
            set
            {
                if (value < 0)
                {
                }

                _Minimum = value;

                if (value > _Value)
                    _Value = value;
                if (value > _Maximum)
                    _Maximum = value;

                DrawValue = Convert.ToInt32((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 24));
                ChangePaths();
                Invalidate();
            }
        }

        [Category("Behavior")]
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value == _Value)
                    return;

                if (value > _Maximum)
                    value = _Maximum;
                if (value < _Minimum)
                    value = _Minimum;

                _Value = value;

                DrawValue = Convert.ToInt32((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 24));
                ChangePaths();
                Invalidate();
                if (Scroll != null)
                {
                    Scroll(this);
                }
            }
        }
        #endregion

        public BaWGUITrackBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

            BackColor = Color.Transparent;
            DoubleBuffered = true;

            P1 = new Pen(Color.FromArgb(156, 156, 156));
            P2 = new Pen(Color.FromArgb(205, 205, 205));
            B1 = new SolidBrush(Color.FromArgb(194, 194, 194));
            B2 = new SolidBrush(Color.FromArgb(75, 145, 215));
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left)
            {
                if (Value == 0)
                    return;
                Value -= 1;
            }
            else if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right)
            {
                if (Value == _Maximum)
                    return;
                Value += 1;
            }

            base.OnKeyDown(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Height > 0)
            {
                DrawValue = Convert.ToInt32((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 24));
                ChangePaths();

                Moveable = new Rectangle(DrawValue, 0, 24, Height).Contains(e.Location);
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (Moveable && e.X > -1 && e.X < Width + 1)
                Value = _Minimum + Convert.ToInt32((_Maximum - _Minimum) * (e.X / Width));

            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            Moveable = false;
            base.OnMouseUp(e);
        }

        protected override void OnResize(EventArgs e)
        {
            if (Width > 0 && Height > 0)
            {
                DrawValue = Convert.ToInt32((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 24));

                Track = new GraphicsPath();

                SliderOGB = new LinearGradientBrush(new Rectangle(DrawValue, 0, 24, Height), Color.FromArgb(100, 170, 230), Color.FromArgb(70, 140, 210), 90);

                P3 = new Pen(SliderOGB);


                var _with1 = Track;
                _with1.AddArc(0, 27, 10, 10, 90, 180);
                _with1.AddArc(Width - 11, 27, 10, 10, -90, 180);
                _with1.CloseFigure();
                ChangePaths();

                Height = 37;
            }

            Invalidate();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var _with2 = e.Graphics;
            _with2.SmoothingMode = SmoothingMode.HighQuality;

            _with2.FillPath(B1, Track);
            _with2.DrawLine(P1, 5, 27, Width - 6, 27);

            for (int i = 0; i <= _Maximum - _Minimum + 1; i++)
            {
                _with2.DrawLine(P2, Convert.ToInt32(i / (_Maximum - _Minimum) * (Width - 24) + 10), 25, Convert.ToInt32(i / (_Maximum - _Minimum) * (Width - 24) + 10), 18);
            }

            _with2.FillPath(SliderGB, Slider);
            _with2.DrawPath(P3, Slider);

            _with2.FillEllipse(B2, DrawValue + 5, 10, 2, 2);
            _with2.FillEllipse(B2, DrawValue + 9, 10, 2, 2);
            _with2.FillEllipse(B2, DrawValue + 13, 10, 2, 2);
            _with2.FillEllipse(B2, DrawValue + 5, 14, 2, 2);
            _with2.FillEllipse(B2, DrawValue + 9, 14, 2, 2);
            _with2.FillEllipse(B2, DrawValue + 13, 14, 2, 2);
        }

        private void ChangePaths()
        {
            if (Width > 0 && Height > 0)
            {
                Slider = new GraphicsPath();

                SliderGB = new LinearGradientBrush(new Rectangle(DrawValue, 0, 24, Height), Color.FromArgb(170, 210, 245), Color.FromArgb(80, 150, 225), 90);


                var _with3 = Slider;
                _with3.AddArc(DrawValue, 0, 4, 4, 180, 90);
                _with3.AddArc(DrawValue + 17, 0, 4, 4, -90, 90);
                _with3.AddLine(DrawValue + 21, 4, DrawValue + 21, 25);
                _with3.AddLine(DrawValue + 21, 25, DrawValue + 10, Height - 1);
                _with3.AddLine(DrawValue, 25, DrawValue, 2);
            }
        }
    }

}


