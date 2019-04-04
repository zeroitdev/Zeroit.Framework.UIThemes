// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ButtonWithProgress.cs" company="Zeroit Dev Technologies">
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
using static Zeroit.Framework.UIThemes.Login.DrawHelpers;

namespace Zeroit.Framework.UIThemes.Login
{

    public class LogInButtonWithProgress : Control
    {

        #region "Declarations"
        private int _Value = 0;
        private int _Maximum = 100;
        private Font _Font = new Font("Segoe UI", 9);
        private Color _ProgressColour = Color.FromArgb(0, 191, 255);
        private Color _BorderColour = Color.FromArgb(25, 25, 25);
        private Color _FontColour = Color.FromArgb(255, 255, 255);
        private Color _MainColour = Color.FromArgb(42, 42, 42);
        private Color _HoverColour = Color.FromArgb(52, 52, 52);
        private Color _PressedColour = Color.FromArgb(47, 47, 47);
        #endregion
        private MouseState State = new MouseState();

        #region "Mouse States"

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }

        #endregion

        #region "Properties"

        [Category("Colours")]
        public Color ProgressColour
        {
            get { return _ProgressColour; }
            set { _ProgressColour = value; }
        }

        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }

        [Category("Colours")]
        public Color FontColour
        {
            get { return _FontColour; }
            set { _FontColour = value; }
        }

        [Category("Colours")]
        public Color BaseColour
        {
            get { return _MainColour; }
            set { _MainColour = value; }
        }

        [Category("Colours")]
        public Color HoverColour
        {
            get { return _HoverColour; }
            set { _HoverColour = value; }
        }

        [Category("Colours")]
        public Color PressedColour
        {
            get { return _PressedColour; }
            set { _PressedColour = value; }
        }

        [Category("Control")]
        public int Maximum
        {
            get { return _Maximum; }
            set
            {

                if (value == _Value)
                {
                    _Value = value;
                }
                #region Old Code

                //			switch (value) {
                //				case  // ERROR: Case labels with binary operators are unsupported : LessThan
                //_Value:
                //					_Value = value;
                //					break;
                //			} 
                #endregion

                _Maximum = value;
                Invalidate();
            }
        }

        [Category("Control")]
        public int Value
        {
            get
            {
                switch (_Value)
                {
                    case 0:

                        return 0;
                    default:

                        return _Value;
                }
            }
            set
            {
                if (value == _Maximum)
                {
                    value = _Maximum;
                    Invalidate();
                }

                #region Old Code
                //			switch (value) {
                //				case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
                //_Maximum:
                //					value = _Maximum;
                //					Invalidate();
                //					break;
                //			} 
                #endregion

                _Value = value;
                Invalidate();
            }
        }

        public void Increment(int Amount)
        {
            Value += Amount;
        }

        #endregion

        #region "Draw Control"
        public LogInButtonWithProgress()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new Size(75, 30);
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            var _with11 = g;
            _with11.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with11.SmoothingMode = SmoothingMode.HighQuality;
            _with11.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with11.Clear(BackColor);
            switch (State)
            {
                case MouseState.None:
                    _with11.FillRectangle(new SolidBrush(_MainColour), new Rectangle(0, 0, Width, Height - 4));
                    _with11.DrawRectangle(new Pen(_BorderColour, 2), new Rectangle(0, 0, Width, Height - 4));
                    _with11.DrawString(Text, _Font, Brushes.White, new Point(Convert.ToInt32(Width / 2), Convert.ToInt32(Height / 2 - 2)), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Over:
                    _with11.FillRectangle(new SolidBrush(_HoverColour), new Rectangle(0, 0, Width, Height - 4));
                    _with11.DrawRectangle(new Pen(_BorderColour, 1), new Rectangle(1, 1, Width - 2, Height - 5));
                    _with11.DrawString(Text, _Font, Brushes.White, new Point(Convert.ToInt32(Width / 2), Convert.ToInt32(Height / 2 - 2)), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Down:
                    _with11.FillRectangle(new SolidBrush(_PressedColour), new Rectangle(0, 0, Width, Height - 4));
                    _with11.DrawRectangle(new Pen(_BorderColour, 1), new Rectangle(1, 1, Width - 2, Height - 5));
                    _with11.DrawString(Text, _Font, Brushes.White, new Point(Convert.ToInt32(Width / 2), Convert.ToInt32(Height / 2 - 2)), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
            }

            if (_Value == 0)
            {
                return;
            }
            else if (_Value == _Maximum)
            {
                _with11.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, Height - 4, Width, Height - 4));
                _with11.DrawRectangle(new Pen(_BorderColour, 2), new Rectangle(0, 0, Width, Height));

            }
            else
            {
                _with11.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, Height - 4, Convert.ToInt32(Width / _Maximum * _Value), Height - 4));
                _with11.DrawRectangle(new Pen(_BorderColour, 2), new Rectangle(0, 0, Width, Height));

            }

            #region Old Code
            //      switch (_Value) {
            //	case 0:
            //		break;
            //	case _Maximum:
            //		_with11.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, Height - 4, Width, Height - 4));
            //		_with11.DrawRectangle(new Pen(_BorderColour, 2), new Rectangle(0, 0, Width, Height));
            //		break;
            //	default:
            //		_with11.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, Height - 4, Convert.ToInt32(Width / _Maximum * _Value), Height - 4));
            //		_with11.DrawRectangle(new Pen(_BorderColour, 2), new Rectangle(0, 0, Width, Height));
            //		break;
            //} 
            #endregion

            _with11.InterpolationMode = (InterpolationMode)7;
        }

        #endregion

    }

}


