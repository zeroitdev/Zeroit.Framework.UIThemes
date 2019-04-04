// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="RadialProgressBar.cs" company="Zeroit Dev Technologies">
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

    public class LogInRadialProgressBar : Control
    {

        #region "Declarations"
        private Color _BorderColour = Color.FromArgb(35, 35, 35);
        private Color _BaseColour = Color.FromArgb(42, 42, 42);
        private Color _ProgressColour = Color.FromArgb(23, 119, 151);
        private int _Value = 0;
        private int _Maximum = 100;
        private int _StartingAngle = 110;
        private int _RotationAngle = 255;
        #endregion
        private readonly Font _Font = new Font("Segoe UI", 20);

        #region "Properties"

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

        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }

        [Category("Colours")]
        public Color ProgressColour
        {
            get { return _ProgressColour; }
            set { _ProgressColour = value; }
        }

        [Category("Colours")]
        public Color BaseColour
        {
            get { return _BaseColour; }
            set { _BaseColour = value; }
        }

        [Category("Control")]
        public int StartingAngle
        {
            get { return _StartingAngle; }
            set { _StartingAngle = value; }
        }

        [Category("Control")]
        public int RotationAngle
        {
            get { return _RotationAngle; }
            set { _RotationAngle = value; }
        }

        #endregion

        #region "Draw Control"
        public LogInRadialProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new Size(78, 78);
            BackColor = Color.FromArgb(54, 54, 54);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            var _with8 = G;
            _with8.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            _with8.SmoothingMode = SmoothingMode.HighQuality;
            _with8.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with8.Clear(BackColor);

            if (_Value == 0)
            {
                _with8.DrawArc(new Pen(new SolidBrush(_BorderColour), 1 + 5), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5);
                _with8.DrawArc(new Pen(new SolidBrush(_BaseColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle);
                _with8.DrawString(Convert.ToString(_Value), _Font, Brushes.White, new Point(Convert.ToInt32(Width / 2), Convert.ToInt32(Height / 2 - 1)), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }
            else if (_Value == _Maximum)
            {
                _with8.DrawArc(new Pen(new SolidBrush(_BorderColour), 1 + 5), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5);
                _with8.DrawArc(new Pen(new SolidBrush(_BaseColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle);
                _with8.DrawArc(new Pen(new SolidBrush(_ProgressColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle);
                _with8.DrawString(Convert.ToString(_Value), _Font, Brushes.White, new Point(Convert.ToInt32(Width / 2), Convert.ToInt32(Height / 2 - 1)), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }
            else
            {
                _with8.DrawArc(new Pen(new SolidBrush(_BorderColour), 1 + 5), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5);
                _with8.DrawArc(new Pen(new SolidBrush(_BaseColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle);
                _with8.DrawArc(new Pen(new SolidBrush(_ProgressColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, Convert.ToInt32((_RotationAngle / _Maximum) * _Value));
                _with8.DrawString(Convert.ToString(_Value), _Font, Brushes.White, new Point(Convert.ToInt32(Width / 2), Convert.ToInt32(Height / 2 - 1)), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }

            #region Old Code
            //switch (_Value) {
            //	case 0:
            //		_with8.DrawArc(new Pen(new SolidBrush(_BorderColour), 1 + 5), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5);
            //		_with8.DrawArc(new Pen(new SolidBrush(_BaseColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle);
            //		_with8.DrawString(Convert.ToString(_Value), _Font, Brushes.White, new Point(Convert.ToInt32(Width / 2), Convert.ToInt32(Height / 2 - 1)), new StringFormat {
            //			Alignment = StringAlignment.Center,
            //			LineAlignment = StringAlignment.Center
            //		});
            //		break;
            //	case _Maximum:
            //		_with8.DrawArc(new Pen(new SolidBrush(_BorderColour), 1 + 5), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5);
            //		_with8.DrawArc(new Pen(new SolidBrush(_BaseColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle);
            //		_with8.DrawArc(new Pen(new SolidBrush(_ProgressColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle);
            //		_with8.DrawString(Convert.ToString(_Value), _Font, Brushes.White, new Point(Convert.ToInt32(Width / 2), Convert.ToInt32(Height / 2 - 1)), new StringFormat {
            //			Alignment = StringAlignment.Center,
            //			LineAlignment = StringAlignment.Center
            //		});
            //		break;
            //	default:
            //		_with8.DrawArc(new Pen(new SolidBrush(_BorderColour), 1 + 5), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5);
            //		_with8.DrawArc(new Pen(new SolidBrush(_BaseColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle);
            //		_with8.DrawArc(new Pen(new SolidBrush(_ProgressColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, Convert.ToInt32((_RotationAngle / _Maximum) * _Value));
            //		_with8.DrawString(Convert.ToString(_Value), _Font, Brushes.White, new Point(Convert.ToInt32(Width / 2), Convert.ToInt32(Height / 2 - 1)), new StringFormat {
            //			Alignment = StringAlignment.Center,
            //			LineAlignment = StringAlignment.Center
            //		});
            //		break;
            //} 
            #endregion

            _with8.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }
        #endregion

    }

}


