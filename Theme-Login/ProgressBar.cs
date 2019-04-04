// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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

    public class LogInProgressBar : Control
    {

        #region "Declarations"
        private Color _ProgressColour = Color.FromArgb(0, 160, 199);
        private Color _BorderColour = Color.FromArgb(35, 35, 35);
        private Color _BaseColour = Color.FromArgb(42, 42, 42);
        private Color _FontColour = Color.FromArgb(50, 50, 50);
        private Color _SecondColour = Color.FromArgb(0, 145, 184);
        private int _Value = 0;
        private int _Maximum = 100;
        #endregion
        private bool _TwoColour = true;

        #region "Properties"

        public Color SecondColour
        {
            get { return _SecondColour; }
            set { _SecondColour = value; }
        }

        [Category("Control")]
        public bool TwoColour
        {
            get { return _TwoColour; }
            set { _TwoColour = value; }
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
        public Color FontColour
        {
            get { return _FontColour; }
            set { _FontColour = value; }
        }

        #endregion

        #region "Events"

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 25;
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Height = 25;
        }

        public void Increment(int Amount)
        {
            Value += Amount;
        }

        #endregion

        #region "Draw Control"
        public LogInProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            Rectangle Base = new Rectangle(0, 0, Width, Height);
            var _with19 = G;
            _with19.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with19.SmoothingMode = SmoothingMode.HighQuality;
            _with19.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with19.Clear(BackColor);
            int ProgVal = Convert.ToInt32(_Value / _Maximum * Width);




            if (_Value == 0)
            {
                _with19.FillRectangle(new SolidBrush(_BaseColour), Base);
                _with19.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
                _with19.DrawRectangle(new Pen(_BorderColour, 3), Base);

            }
            else if (_Value == _Maximum)
            {
                _with19.FillRectangle(new SolidBrush(_BaseColour), Base);
                _with19.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
                if (_TwoColour)
                {
                    G.SetClip(new Rectangle(0, -10, Convert.ToInt32(Width * _Value / _Maximum - 1), Height - 5));
                    for (int i = 0; i <= (Width - 1) * _Maximum / _Value; i += 25)
                    {
                        G.DrawLine(new Pen(new SolidBrush(_SecondColour), 7), new Point(Convert.ToInt32(i), 0), new Point(Convert.ToInt32(i - 15), Height));
                    }
                    G.ResetClip();
                }
                else
                {
                }
                _with19.DrawRectangle(new Pen(_BorderColour, 3), Base);

            }
            else
            {
                _with19.FillRectangle(new SolidBrush(_BaseColour), Base);
                _with19.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
                if (_TwoColour)
                {
                    _with19.SetClip(new Rectangle(0, 0, Convert.ToInt32(Width * _Value / _Maximum - 1), Height - 1));
                    for (int i = 0; i <= (Width - 1) * _Maximum / _Value; i += 25)
                    {
                        _with19.DrawLine(new Pen(new SolidBrush(_SecondColour), 7), new Point(Convert.ToInt32(i), 0), new Point(Convert.ToInt32(i - 10), Height));
                    }
                    _with19.ResetClip();
                }
                else
                {
                }
                _with19.DrawRectangle(new Pen(_BorderColour, 3), Base);

            }


            #region Old Code
            //      switch (Value) {
            //	case 0:
            //		_with19.FillRectangle(new SolidBrush(_BaseColour), Base);
            //		_with19.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
            //		_with19.DrawRectangle(new Pen(_BorderColour, 3), Base);
            //		break;
            //	case _Maximum:
            //		_with19.FillRectangle(new SolidBrush(_BaseColour), Base);
            //		_with19.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
            //		if (_TwoColour) {
            //			G.SetClip(new Rectangle(0, -10, Convert.ToInt32(Width * _Value / _Maximum - 1), Height - 5));
            //			for (int i = 0; i <= (Width - 1) * _Maximum / _Value; i += 25) {
            //				G.DrawLine(new Pen(new SolidBrush(_SecondColour), 7), new Point(Convert.ToInt32(i), 0), new Point(Convert.ToInt32(i - 15), Height));
            //			}
            //			G.ResetClip();
            //		} else {
            //		}
            //		_with19.DrawRectangle(new Pen(_BorderColour, 3), Base);
            //		break;
            //	default:
            //		_with19.FillRectangle(new SolidBrush(_BaseColour), Base);
            //		_with19.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
            //		if (_TwoColour) {
            //			_with19.SetClip(new Rectangle(0, 0, Convert.ToInt32(Width * _Value / _Maximum - 1), Height - 1));
            //			for (int i = 0; i <= (Width - 1) * _Maximum / _Value; i += 25) {
            //				_with19.DrawLine(new Pen(new SolidBrush(_SecondColour), 7), new Point(Convert.ToInt32(i), 0), new Point(Convert.ToInt32(i - 10), Height));
            //			}
            //			_with19.ResetClip();
            //		} else {
            //		}
            //		_with19.DrawRectangle(new Pen(_BorderColour, 3), Base);
            //		break;
            //} 
            #endregion


            _with19.InterpolationMode = (InterpolationMode)7;
        }

        #endregion

    }

}


