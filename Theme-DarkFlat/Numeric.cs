// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Numeric.cs" company="Zeroit Dev Technologies">
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
    public class DarkFlatNumeric : Control
    {
        #region  Variables

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

        #region  Properties

        public long Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value <= _Max && value >= _Min)
                {
                    _Value = value;
                }
                Invalidate();
            }
        }

        public long Maximum
        {
            get
            {
                return _Max;
            }
            set
            {
                if (value > _Min)
                {
                    _Max = value;
                }
                if (_Value > _Max)
                {
                    _Value = _Max;
                }
                Invalidate();
            }
        }

        public long Minimum
        {
            get
            {
                return _Min;
            }
            set
            {
                if (value < _Max)
                {
                    _Min = value;
                }
                if (_Value < _Min)
                {
                    _Value = Minimum;
                }
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
            {
                Cursor = Cursors.IBeam;
            }
            else
            {
                Cursor = Cursors.Hand;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (x > Width - 21 && x < Width - 3)
            {
                if (y < 15)
                {
                    if ((Value + 1) <= _Max)
                    {
                        _Value += 1;
                    }
                }
                else
                {
                    if ((Value - 1) >= _Min)
                    {
                        _Value -= 1;
                    }
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
                {
                    _Value = Convert.ToInt64(Convert.ToString(Convert.ToString(_Value) + e.KeyChar.ToString()));
                }
                if (_Value > _Max)
                {
                    _Value = _Max;
                }
                Invalidate();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        #region  Colors

        [Category("Colors")]
        public Color BaseColor
        {
            get
            {
                return _BaseColor;
            }
            set
            {
                _BaseColor = value;
            }
        }

        [Category("Colors")]
        public Color ButtonColor
        {
            get
            {
                return _ButtonColor;
            }
            set
            {
                _ButtonColor = value;
            }
        }

        #endregion

        #endregion

        #region  Colors

        private Color _BaseColor = Color.FromArgb(60, 60, 60);
        private Color _ButtonColor = Color.FromArgb(0, 170, 220);

        #endregion

        public DarkFlatNumeric()
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
            Helpers.B = new Bitmap(Width, Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            W = Width;
            H = Height;

            Rectangle Base = new Rectangle(0, 0, W, H);

            Helpers.G.SmoothingMode = (System.Drawing.Drawing2D.SmoothingMode)2;
            Helpers.G.PixelOffsetMode = (System.Drawing.Drawing2D.PixelOffsetMode)2;
            Helpers.G.TextRenderingHint = (System.Drawing.Text.TextRenderingHint)5;
            Helpers.G.Clear(BackColor);

            //-- Base
            Helpers.G.FillRectangle(new SolidBrush(_BaseColor), Base);
            Helpers.G.FillRectangle(new SolidBrush(_ButtonColor), new Rectangle(Width - 24, 0, 24, H));

            //-- Add
            Helpers.G.DrawString("+", new Font("Segoe UI", 12), Brushes.White, new Point(Width - 12, 8), Helpers.CenterSF);
            //-- Subtract
            Helpers.G.DrawString("-", new Font("Segoe UI", 10F, FontStyle.Bold), Brushes.White, new Point(Width - 12, 22), Helpers.CenterSF);

            //-- Text
            Helpers.G.DrawString(Value.ToString(), Font, Brushes.White, new Rectangle(5, 1, W, H), new StringFormat() { LineAlignment = StringAlignment.Center });

            base.OnPaint(e);
            Helpers.G.Dispose();
            e.Graphics.InterpolationMode = (System.Drawing.Drawing2D.InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
            Helpers.B.Dispose();
        }

    }

}



