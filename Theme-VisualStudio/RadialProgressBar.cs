// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="RadialProgressBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.VisualStudio
{
    public class VisualStudioRadialProgressBar : Control
    {
        #region Declarations
        private Color _BorderColour = Color.FromArgb(28, 28, 28);
        private Color _BaseColour = Color.FromArgb(45, 45, 48);
        private Color _ProgressColour = Color.FromArgb(62, 62, 66);
        private Color _TextColour = Color.FromArgb(153, 153, 153);
        private int _Value = 0;
        private int _Maximum = 100;
        private int _StartingAngle = 110;
        private int _RotationAngle = 255;
        private Font _Font = new Font("Segoe UI", 20);
        #endregion

        #region Properties

        [Category("Control")]
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                if (value < _Value)
                {
                    _Value = value;
                }
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
                if (value > _Maximum)
                {
                    value = _Maximum;
                    Invalidate();
                }
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
            get
            {
                return _BorderColour;
            }
            set
            {
                _BorderColour = value;
                Invalidate();
            }
        }

        [Category("Colours")]
        public Color TextColour
        {
            get
            {
                return _TextColour;
            }
            set
            {
                _TextColour = value;
                Invalidate();

            }
        }

        [Category("Colours")]
        public Color ProgressColour
        {
            get
            {
                return _ProgressColour;
            }
            set
            {
                _ProgressColour = value;
                Invalidate();

            }
        }

        [Category("Colours")]
        public Color BaseColour
        {
            get
            {
                return _BaseColour;
            }
            set
            {
                _BaseColour = value;
                Invalidate();

            }
        }

        [Category("Control")]
        public int StartingAngle
        {
            get
            {
                return _StartingAngle;
            }
            set
            {
                _StartingAngle = value;
            }
        }

        [Category("Control")]
        public int RotationAngle
        {
            get
            {
                return _RotationAngle;
            }
            set
            {
                _RotationAngle = value;
            }
        }



        #endregion

        #region Draw Control
        public VisualStudioRadialProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new Size(78, 78);
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            var G = Graphics.FromImage(B);
            G.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.PixelOffsetMode = PixelOffsetMode.HighQuality;
            G.Clear(BackColor);
            if (_Value == 0)
            {
                G.DrawArc(new Pen(new SolidBrush(_BorderColour), 1 + 6), Convert.ToInt32(3 / 2.0) + 1, Convert.ToInt32(3 / 2.0) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5);
                G.DrawArc(new Pen(new SolidBrush(_BaseColour), 1 + 3), Convert.ToInt32(3 / 2.0) + 1, Convert.ToInt32(3 / 2.0) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle);
                G.DrawString(Convert.ToString(_Value), _Font, new SolidBrush(_TextColour), new Point(Convert.ToInt32(Width / 2), Convert.ToInt32(Height / 2 - 1)), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }
            //ORIGINAL LINE: Case _Maximum
            else if (_Value == _Maximum)
            {
                G.DrawArc(new Pen(new SolidBrush(_BorderColour), 1 + 6), Convert.ToInt32(3 / 2.0) + 1, Convert.ToInt32(3 / 2.0) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5);
                G.DrawArc(new Pen(new SolidBrush(_BaseColour), 1 + 3), Convert.ToInt32(3 / 2.0) + 1, Convert.ToInt32(3 / 2.0) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle);
                G.DrawArc(new Pen(new SolidBrush(_ProgressColour), 1 + 3), Convert.ToInt32(3 / 2.0) + 1, Convert.ToInt32(3 / 2.0) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle);
                G.DrawString(Convert.ToString(_Value), _Font, new SolidBrush(_TextColour), new Point(Convert.ToInt32(Width / 2), Convert.ToInt32(Height / 2 - 1)), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }
            //ORIGINAL LINE: Case Else
            else
            {
                G.DrawArc(new Pen(new SolidBrush(_BorderColour), 1 + 6), Convert.ToInt32(3 / 2.0) + 1, Convert.ToInt32(3 / 2.0) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5);
                G.DrawArc(new Pen(new SolidBrush(_BaseColour), 1 + 3), Convert.ToInt32(3 / 2.0) + 1, Convert.ToInt32(3 / 2.0) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle);
                G.DrawArc(new Pen(new SolidBrush(_ProgressColour), 1 + 3), Convert.ToInt32(3 / 2.0) + 1, Convert.ToInt32(3 / 2.0) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, Convert.ToInt32((_RotationAngle / (double)_Maximum) * _Value));
                G.DrawString(Convert.ToString(_Value), _Font, new SolidBrush(_TextColour), new Point(Convert.ToInt32(Width / 2), Convert.ToInt32(Height / 2 - 1)), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }
            base.OnPaint(e);
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
        #endregion

    }

}
