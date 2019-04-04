// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Facebook
{

    public class FacebookProgressBar : Control
    {

        #region "Declarations"
        private Color _ProgressColour = Color.LightBlue;
        private Color _GlowColour = Color.FromArgb(73, 185, 213);
        private Color _BorderColour = Color.FromArgb(187, 191, 200);
        private Color _BaseColour = Color.FromArgb(237, 237, 237);
        private Color _FontColour = Color.FromArgb(50, 50, 50);
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
        public FacebookProgressBar()
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
            var _with11 = G;
            _with11.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with11.SmoothingMode = SmoothingMode.HighQuality;
            _with11.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with11.Clear(BackColor);
            int ProgVal = Convert.ToInt32(_Value / _Maximum * (Width - 40));

            if (Value == 0)
            {
                _with11.FillRectangle(new SolidBrush(_BaseColour), Base);
                _with11.DrawLine(new Pen(_BorderColour), new Point(Width - 40, 0), new Point(Width - 40, Height));
                _with11.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
                _with11.DrawRectangle(new Pen(_BorderColour), Base);
                _with11.DrawString(string.Format("{0}%", _Value), Font, new SolidBrush(_FontColour), new Point(Width - 37, 4));

            }
            else if (Value == _Maximum)
            {
                _with11.FillRectangle(new SolidBrush(_BaseColour), Base);
                _with11.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
                _with11.DrawRectangle(new Pen(_GlowColour), Base);
                _with11.DrawLine(new Pen(_GlowColour), new Point(Width - 40, 0), new Point(Width - 40, Height));
                _with11.DrawString(string.Format("{0}%", _Value), Font, new SolidBrush(_FontColour), new Point(Width - 37, 4));

            }
            else
            {
                _with11.FillRectangle(new SolidBrush(_BaseColour), Base);
                _with11.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
                _with11.DrawRectangle(new Pen(_BorderColour), Base);
                _with11.DrawLine(new Pen(_BorderColour), new Point(Width - 40, 0), new Point(Width - 40, Height));
                _with11.DrawString(string.Format("{0}%", _Value), Font, new SolidBrush(_FontColour), new Point(Width - 37, 4));

            }

            #region Old Code
            //      switch (Value) {
            //	case 0:
            //		_with11.FillRectangle(new SolidBrush(_BaseColour), Base);
            //		_with11.DrawLine(new Pen(_BorderColour), new Point(Width - 40, 0), new Point(Width - 40, Height));
            //		_with11.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
            //		_with11.DrawRectangle(new Pen(_BorderColour), Base);
            //		_with11.DrawString(string.Format("{0}%", _Value), Font, new SolidBrush(_FontColour), new Point(Width - 37, 4));
            //		break;
            //	case _Maximum:
            //		_with11.FillRectangle(new SolidBrush(_BaseColour), Base);
            //		_with11.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
            //		_with11.DrawRectangle(new Pen(_GlowColour), Base);
            //		_with11.DrawLine(new Pen(_GlowColour), new Point(Width - 40, 0), new Point(Width - 40, Height));
            //		_with11.DrawString(string.Format("{0}%", _Value), Font, new SolidBrush(_FontColour), new Point(Width - 37, 4));
            //		break;
            //	default:
            //		_with11.FillRectangle(new SolidBrush(_BaseColour), Base);
            //		_with11.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
            //		_with11.DrawRectangle(new Pen(_BorderColour), Base);
            //		_with11.DrawLine(new Pen(_BorderColour), new Point(Width - 40, 0), new Point(Width - 40, Height));
            //		_with11.DrawString(string.Format("{0}%", _Value), Font, new SolidBrush(_FontColour), new Point(Width - 37, 4));
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

