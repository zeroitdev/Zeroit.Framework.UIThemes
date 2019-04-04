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
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Elegant
{

    public class ElegantThemeProgressBar : Control
    {

        #region "Declarations"

        private Color _ProgressColour = Color.FromArgb(163, 190, 146);
        private Color _BorderColour = Color.FromArgb(210, 210, 210);
        private Color _BaseColour = Color.FromArgb(255, 255, 255);
        private Color _SecondColour = Color.FromArgb(148, 190, 131);
        private int _Value = 0;
        private int _Maximum = 100;

        private bool _TwoColour = true;
        #endregion

        #region "Properties"

        [Category("Colours")]
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


        #endregion

        #region "Events"

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (Height < 25)
            {
                Height = 25;
            }
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

        public ElegantThemeProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G = Graphics.FromImage(B);
            Rectangle Base = new Rectangle(0, 0, Width, Height);
            var _with17 = G;
            _with17.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with17.SmoothingMode = SmoothingMode.HighQuality;
            _with17.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with17.Clear(BackColor);
            int ProgVal = Convert.ToInt32(_Value / _Maximum * Width);

            if (_Value == 0)
            {
                _with17.FillRectangle(new SolidBrush(_BaseColour), Base);
                _with17.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
                _with17.DrawRectangle(new Pen(_BorderColour, 3), Base);
            }
            else if (_Value == _Maximum)
            {
                _with17.FillRectangle(new SolidBrush(_BaseColour), Base);
                _with17.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
                if (_TwoColour)
                {
                    G.SetClip(new Rectangle(0, -10, Width * _Value / _Maximum - 1, Height - 5));
                    for (int i = 0; i <= (Width - 1) * _Maximum / _Value; i += 20)
                    {
                        G.DrawLine(new Pen(new SolidBrush(_SecondColour), 7), new Point(i, 0), new Point(i - 15, Height));
                    }
                    G.ResetClip();
                }
                else
                {
                }
                _with17.DrawRectangle(new Pen(_BorderColour, 3), Base);
            }
            else
            {
                _with17.FillRectangle(new SolidBrush(_BaseColour), Base);
                _with17.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
                if (_TwoColour)
                {
                    _with17.SetClip(new Rectangle(0, 0, Width * _Value / _Maximum - 1, Height - 1));
                    for (int i = 0; i <= (Width - 1) * _Maximum / _Value; i += 20)
                    {
                        _with17.DrawLine(new Pen(new SolidBrush(_SecondColour), 7), new Point(i, 0), new Point(i - 10, Height));
                    }
                    _with17.ResetClip();
                }
                else
                {
                }
                _with17.DrawRectangle(new Pen(_BorderColour, 3), Base);
            }

            

            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }

        #endregion

    }


}


