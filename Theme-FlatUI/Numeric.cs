// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Numeric.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static Zeroit.Framework.UIThemes.FlatUI.Helpers;
using System.ComponentModel;
//using System.Threading;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.FlatUI
{
    public class FlatNumeric : Control
    {

        #region " Variables"

        private int W;
        private int H;
        private MouseState State = MouseState.None;
        private int x;
        private int y;
        private long _Value;
        private long _Min;
        private long _Max;

        private bool Bool;
        #endregion

        #region " Properties"

        public long Value
        {
            get { return _Value; }
            set
            {
                if (value <= _Max & value >= _Min)
                    _Value = value;
                Invalidate();
            }
        }

        public long Maximum
        {
            get { return _Max; }
            set
            {
                if (value > _Min)
                    _Max = value;
                if (_Value > _Max)
                    _Value = _Max;
                Invalidate();
            }
        }

        public long Minimum
        {
            get { return _Min; }
            set
            {
                if (value < _Max)
                    _Min = value;
                if (_Value < _Min)
                    _Value = Minimum;
                Invalidate();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            x = e.Location.X;
            y = e.Location.Y;
            Invalidate();
            if (e.X < Width - 23)
                Cursor = Cursors.IBeam;
            else
                Cursor = Cursors.Hand;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (x > Width - 21 && x < Width - 3)
            {
                if (y < 15)
                {
                    if ((Value + 1) <= _Max)
                        _Value += 1;
                }
                else
                {
                    if ((Value - 1) >= _Min)
                        _Value -= 1;
                }
            }
            else
            {
                Bool = !Bool;
                Focus();
            }
            Invalidate();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            try
            {
                if (Bool)
                    _Value = Convert.ToInt32(_Value + (e.KeyChar.ToString()));
                if (_Value > _Max)
                    _Value = _Max;
                Invalidate();
            }
            catch
            {
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Back)
            {
                Value = 0;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 30;
        }

        #region " Colors"

        [Category("Colors")]
        public Color BaseColor
        {
            get { return _BaseColor; }
            set { _BaseColor = value; }
        }

        [Category("Colors")]
        public Color ButtonColor
        {
            get { return _ButtonColor; }
            set { _ButtonColor = value; }
        }

        #endregion

        #endregion

        #region " Colors"

        private Color _BaseColor = Color.FromArgb(45, 47, 49);

        private Color _ButtonColor = _FlatColor;
        #endregion

        public FlatNumeric()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 10);
            BackColor = Color.FromArgb(60, 70, 73);
            ForeColor = Color.White;
            _Min = 0;
            _Max = 9999999;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);
            W = Width;
            H = Height;

            Rectangle Base = new Rectangle(0, 0, W, H);

            var _with18 = G;
            _with18.SmoothingMode = SmoothingMode.HighQuality;
            _with18.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with18.TextRenderingHint = TextRenderingHint.AntiAlias;
            _with18.Clear(BackColor);

            //-- Base
            _with18.FillRectangle(new SolidBrush(_BaseColor), Base);
            _with18.FillRectangle(new SolidBrush(_ButtonColor), new Rectangle(Width - 24, 0, 24, H));

            //-- Add
            _with18.DrawString("+", new Font("Segoe UI", 12), Brushes.White, new Point(Width - 12, 8), CenterSF);
            //-- Subtract
            _with18.DrawString("-", new Font("Segoe UI", 10, FontStyle.Bold), Brushes.White, new Point(Width - 12, 22), CenterSF);

            //-- Text
            _with18.DrawString(Value.ToString(), Font, Brushes.White, new Rectangle(5, 1, W, H), new StringFormat { LineAlignment = StringAlignment.Center });

            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }

    }


}

