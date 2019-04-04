// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ProgressBar2.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Facebook
{
    public class Facebook2ndProgressBar : Control
    {

        #region "Declarations"
        private Color _ProgressColour = Color.FromArgb(109, 131, 179);
        private Color _GlowColour = Color.FromArgb(73, 185, 213);
        private Color _BorderColour = Color.FromArgb(64, 89, 134);
        private Color _BaseColour = Color.FromArgb(237, 237, 237);
        private int _Value = 0;
        #endregion
        private int _Maximum = 100;

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
                        Invalidate();
                        break;
                    default:
                        return _Value;
                        Invalidate();
                        break;
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

        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }

        [Category("Colours")]
        public Color GlowColour
        {
            get { return _GlowColour; }
            set { _GlowColour = value; }
        }
        #endregion

        #region "Events"

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 10;
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Height = 10;
        }

        public void Increment(int Amount)
        {
            Value += Amount;
        }

        #endregion

        #region "Draw Control"
        public Facebook2ndProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(60, 70, 73);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            dynamic B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle Base = new Rectangle(0, 0, Width, Height);
            var _with14 = G;
            _with14.SmoothingMode = SmoothingMode.HighQuality;
            _with14.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with14.Clear(BackColor);
            int ProgVal = Convert.ToInt32(_Value / _Maximum * Width);

            if (Value == 0)
            {
                _with14.FillRectangle(new SolidBrush(_BaseColour), Base);
                _with14.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
                _with14.DrawRectangle(new Pen(_BorderColour, 2), Base);

            }
            else if (Value == _Maximum)
            {
                _with14.FillRectangle(new SolidBrush(_BaseColour), Base);
                _with14.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
                _with14.DrawRectangle(new Pen(_BorderColour, 2), Base);

            }
            else
            {
                _with14.FillRectangle(new SolidBrush(_BaseColour), Base);
                _with14.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
                _with14.DrawRectangle(new Pen(_BorderColour, 2), Base);

            }

            #region Old Code
            //      switch (Value) {
            //	case 0:
            //		_with14.FillRectangle(new SolidBrush(_BaseColour), Base);
            //		_with14.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
            //		_with14.DrawRectangle(new Pen(_BorderColour, 2), Base);
            //		break;
            //	case _Maximum:
            //		_with14.FillRectangle(new SolidBrush(_BaseColour), Base);
            //		_with14.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
            //		_with14.DrawRectangle(new Pen(_BorderColour, 2), Base);
            //		break;
            //	default:
            //		_with14.FillRectangle(new SolidBrush(_BaseColour), Base);
            //		_with14.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
            //		_with14.DrawRectangle(new Pen(_BorderColour, 2), Base);
            //		break;
            //} 
            #endregion

            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
        #endregion

    }


}

