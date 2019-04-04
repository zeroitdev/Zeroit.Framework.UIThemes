﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="TrackBar.cs" company="Zeroit Dev Technologies">
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
using static Zeroit.Framework.UIThemes.FlatUI.Helpers;
using System.ComponentModel;
//using System.Threading;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.FlatUI
{

    [DefaultEvent("Scroll")]
    public class FlatTrackBar : Control
    {

        #region " Variables"

        private int W;
        private int H;
        private int Val;
        private bool Bool;
        private Rectangle Track;
        private Rectangle Knob;

        private _Style Style_;
        #endregion

        #region " Properties"

        #region " Mouse States"

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                Val = Convert.ToInt32((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 11));
                Track = new Rectangle(Val, 0, 10, 20);

                Bool = Track.Contains(e.Location);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Bool && e.X > -1 && e.X < (Width + 1))
            {
                Value = _Minimum + Convert.ToInt32((_Maximum - _Minimum) * (e.X / Width));
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Bool = false;
        }

        #endregion

        #region " Styles"

        [Flags()]
        public enum _Style
        {
            Slider,
            Knob
        }

        public _Style Style
        {
            get { return Style_; }
            set { Style_ = value; }
        }

        #endregion

        #region " Colors"

        [Category("Colors")]
        public Color TrackColor
        {
            get { return _TrackColor; }
            set { _TrackColor = value; }
        }

        [Category("Colors")]
        public Color HatchColor
        {
            get { return _HatchColor; }
            set { _HatchColor = value; }
        }

        #endregion

        public event ScrollEventHandler Scroll;
        public delegate void ScrollEventHandler(object sender);
        private int _Minimum;
        public int Minimum
        {
            get
            {
                int functionReturnValue = 0;
                return functionReturnValue;
                return functionReturnValue;
            }
            set
            {
                if (value < 0)
                {
                }

                _Minimum = value;

                if (value > _Value)
                    _Value = value;
                if (value > _Maximum)
                    _Maximum = value;
                Invalidate();
            }
        }
        private int _Maximum = 10;
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 0)
                {
                }

                _Maximum = value;
                if (value < _Value)
                    _Value = value;
                if (value < _Minimum)
                    _Minimum = value;
                Invalidate();
            }
        }
        private int _Value;
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value == _Value)
                    return;

                if (value > _Maximum || value < _Minimum)
                {
                }

                _Value = value;
                Invalidate();
                if (Scroll != null)
                {
                    Scroll(this);
                }
            }
        }
        private bool _ShowValue = false;
        public bool ShowValue
        {
            get { return _ShowValue; }
            set { _ShowValue = value; }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Subtract)
            {
                if (Value == 0)
                    return;
                Value -= 1;
            }
            else if (e.KeyCode == Keys.Add)
            {
                if (Value == _Maximum)
                    return;
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

        #region " Colors"

        private Color BaseColor = Color.FromArgb(45, 47, 49);
        private Color _TrackColor = _FlatColor;
        private Color SliderColor = Color.FromArgb(25, 27, 29);

        private Color _HatchColor = Color.FromArgb(23, 148, 92);
        #endregion

        public FlatTrackBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            Height = 18;

            BackColor = Color.FromArgb(60, 70, 73);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);
            W = Width - 1;
            H = Height - 1;

            Rectangle Base = new Rectangle(1, 6, W - 2, 8);
            GraphicsPath GP = new GraphicsPath();
            GraphicsPath GP2 = new GraphicsPath();

            var _with20 = G;
            _with20.SmoothingMode = SmoothingMode.HighQuality;
            _with20.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with20.TextRenderingHint = TextRenderingHint.AntiAlias;
            _with20.Clear(BackColor);

            //-- Value
            Val = Convert.ToInt32((_Value - _Minimum) / (_Maximum - _Minimum) * (W - 10));
            Track = new Rectangle(Val, 0, 10, 20);
            Knob = new Rectangle(Val, 4, 11, 14);

            //-- Base
            GP.AddRectangle(Base);
            _with20.SetClip(GP);
            _with20.FillRectangle(new SolidBrush(BaseColor), new Rectangle(0, 7, W, 8));
            _with20.FillRectangle(new SolidBrush(_TrackColor), new Rectangle(0, 7, Track.X + Track.Width, 8));
            _with20.ResetClip();

            //-- Hatch Brush
            HatchBrush HB = new HatchBrush(HatchStyle.Plaid, HatchColor, _TrackColor);
            _with20.FillRectangle(HB, new Rectangle(-10, 7, Track.X + Track.Width, 8));

            //-- Slider/Knob
            switch (Style)
            {
                case _Style.Slider:
                    GP2.AddRectangle(Track);
                    _with20.FillPath(new SolidBrush(SliderColor), GP2);
                    break;
                case _Style.Knob:
                    GP2.AddEllipse(Knob);
                    _with20.FillPath(new SolidBrush(SliderColor), GP2);
                    break;
            }

            //-- Show the value 
            if (ShowValue)
            {
                _with20.DrawString(Value.ToString(), new Font("Segoe UI", 8), Brushes.White, new Rectangle(1, 6, W, H), new StringFormat
                {
                    Alignment = StringAlignment.Far,
                    LineAlignment = StringAlignment.Far
                });
            }

            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
    }

}

