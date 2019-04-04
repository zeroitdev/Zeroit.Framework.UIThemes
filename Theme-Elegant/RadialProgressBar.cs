// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="RadialProgressBar.cs" company="Zeroit Dev Technologies">
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

    public class ElegantThemeRadialProgressBar : Control
    {

        #region "Declarations"
        private Color _BorderColour = Color.FromArgb(210, 210, 210);
        private Color _BaseColour = Color.FromArgb(255, 255, 255);
        private Color _ProgressColour = Color.FromArgb(163, 190, 146);
        private Color _TextColour = Color.FromArgb(163, 163, 163);
        private int _Value = 0;
        private int _Maximum = 100;
        private int _StartingAngle = 110;
        private int _RotationAngle = 255;
        #endregion
        private Font _Font = new Font("Segoe UI", 20);

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
        public Color TextColour
        {
            get { return _TextColour; }
            set { _TextColour = value; }
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
        public ElegantThemeRadialProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new Size(78, 78);
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G = Graphics.FromImage(B);
            var _with19 = G;
            _with19.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            _with19.SmoothingMode = SmoothingMode.HighQuality;
            _with19.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with19.Clear(BackColor);

            if (_Value == 0)
            {
                _with19.DrawArc(new Pen(new SolidBrush(_BorderColour), 1 + 6), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5);
                _with19.DrawArc(new Pen(new SolidBrush(_BaseColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle);
                _with19.DrawString(_Value.ToString(), _Font, new SolidBrush(_TextColour), new Point(Width / 2, Height / 2 - 1), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }
            else if (_Value == _Maximum)
            {
                _with19.DrawArc(new Pen(new SolidBrush(_BorderColour), 1 + 6), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5);
                _with19.DrawArc(new Pen(new SolidBrush(_BaseColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle);
                _with19.DrawArc(new Pen(new SolidBrush(_ProgressColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle);
                _with19.DrawString(_Value.ToString(), _Font, new SolidBrush(_TextColour), new Point(Width / 2, Height / 2 - 1), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }
            else
            {
                _with19.DrawArc(new Pen(new SolidBrush(_BorderColour), 1 + 6), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5);
                _with19.DrawArc(new Pen(new SolidBrush(_BaseColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle);
                _with19.DrawArc(new Pen(new SolidBrush(_ProgressColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, Convert.ToInt32((_RotationAngle / _Maximum) * _Value));
                _with19.DrawString(_Value.ToString(), _Font, new SolidBrush(_TextColour), new Point(Width / 2, Height / 2 - 1), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }

            

            base.OnPaint(e);
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
        #endregion

    }


}


