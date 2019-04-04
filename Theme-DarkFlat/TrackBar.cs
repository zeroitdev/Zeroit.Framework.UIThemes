﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="TrackBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.DarkFlat
{
    [DefaultEvent("Scroll")]
    public class DarkFlatTrackBar : Control
    {
        #region  Variables

        private int W;
        private int H;
        private int Val;
        private bool Bool;
        private Rectangle Track;
        private Rectangle Knob;
        private _Style Style_;

        #endregion

        #region  Properties

        #region  Mouse States

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                Val = Convert.ToInt32((_Value - _Minimum) / (double)(_Maximum - _Minimum) * (Width - 11));
                Track = new Rectangle(Val, 0, 10, 20);

                Bool = Track.Contains(e.Location);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Bool && e.X > -1 && e.X < (Width + 1))
            {
                Value = _Minimum + Convert.ToInt32((_Maximum - _Minimum) * (e.X / (double)Width));
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Bool = false;
        }

        #endregion

        #region  Styles

        [Flags]
        public enum _Style
        {
            Slider,
            Knob
        }

        public _Style Style
        {
            get
            {
                return Style_;
            }
            set
            {
                Style_ = value;
            }
        }

        #endregion

        #region  Colors

        [Category("Colors")]
        public Color TrackColor
        {
            get
            {
                return _TrackColor;
            }
            set
            {
                _TrackColor = value;
            }
        }

        [Category("Colors")]
        public Color HatchColor
        {
            get
            {
                return _HatchColor;
            }
            set
            {
                _HatchColor = value;
            }
        }

        #endregion

        public delegate void ScrollEventHandler(object sender);
        public event ScrollEventHandler Scroll;
        private int _Minimum;
        public int Minimum
        {
            get
            {
                return 0;
            }
            set
            {
                if (value < 0)
                {
                }

                _Minimum = value;

                if (value > _Value)
                {
                    _Value = value;
                }
                if (value > _Maximum)
                {
                    _Maximum = value;
                }
                Invalidate();
            }
        }
        private int _Maximum = 10;
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                if (value < 0)
                {
                }

                _Maximum = value;
                if (value < _Value)
                {
                    _Value = value;
                }
                if (value < _Minimum)
                {
                    _Minimum = value;
                }
                Invalidate();
            }
        }
        private int _Value;
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value == _Value)
                {
                    return;
                }

                if (value > _Maximum || value < _Minimum)
                {
                }

                _Value = value;
                Invalidate();
                if (Scroll != null)
                    Scroll(this);
            }
        }
        private bool _ShowValue = false;
        public bool ShowValue
        {
            get
            {
                return _ShowValue;
            }
            set
            {
                _ShowValue = value;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Subtract)
            {
                if (Value == 0)
                {
                    return;
                }
                Value -= 1;
            }
            else if (e.KeyCode == Keys.Add)
            {
                if (Value == _Maximum)
                {
                    return;
                }
                Value += 1;
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 23;
        }

        #endregion

        #region  Colors

        private Color BaseColor = Color.FromArgb(60, 60, 60);
        private Color _TrackColor = Color.FromArgb(0, 170, 220);
        private Color SliderColor = Color.FromArgb(75, 75, 75);
        private Color _HatchColor = Color.FromArgb(0, 170, 220);

        #endregion

        public DarkFlatTrackBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            Height = 18;

            BackColor = Color.FromArgb(50, 50, 50);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(Width, Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            W = Width - 1;
            H = Height - 1;

            Rectangle Base = new Rectangle(1, 6, W - 2, 8);
            GraphicsPath GP = new GraphicsPath();
            GraphicsPath GP2 = new GraphicsPath();

            Helpers.G.SmoothingMode = (System.Drawing.Drawing2D.SmoothingMode)2;
            Helpers.G.PixelOffsetMode = (System.Drawing.Drawing2D.PixelOffsetMode)2;
            Helpers.G.TextRenderingHint = (System.Drawing.Text.TextRenderingHint)5;
            Helpers.G.Clear(BackColor);

            //-- Value
            Val = Convert.ToInt32((_Value - _Minimum) / (double)(_Maximum - _Minimum) * (W - 10));
            Track = new Rectangle(Val, 0, 10, 20);
            Knob = new Rectangle(Val, 4, 11, 14);

            //-- Base
            GP.AddRectangle(Base);
            Helpers.G.SetClip(GP);
            Helpers.G.FillRectangle(new SolidBrush(BaseColor), new Rectangle(0, 7, W, 8));
            Helpers.G.FillRectangle(new SolidBrush(_TrackColor), new Rectangle(0, 7, Track.X + Track.Width, 8));
            Helpers.G.ResetClip();

            //-- Hatch Brush
            HatchBrush HB = new HatchBrush(HatchStyle.Plaid, HatchColor, _TrackColor);
            Helpers.G.FillRectangle(HB, new Rectangle(-10, 7, Track.X + Track.Width, 8));

            //-- Slider/Knob
            switch (Style)
            {
                case _Style.Slider:
                    GP2.AddRectangle(Track);
                    Helpers.G.FillPath(new SolidBrush(SliderColor), GP2);
                    break;
                case _Style.Knob:
                    GP2.AddEllipse(Knob);
                    Helpers.G.FillPath(new SolidBrush(SliderColor), GP2);
                    break;
            }

            //-- Show the value 
            if (ShowValue)
            {
                Helpers.G.DrawString(Value.ToString(), new Font("Segoe UI", 8), Brushes.White, new Rectangle(1, 6, W, H), new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Far });
            }

            base.OnPaint(e);
            Helpers.G.Dispose();
            e.Graphics.InterpolationMode = (System.Drawing.Drawing2D.InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
            Helpers.B.Dispose();
        }
    }
}



