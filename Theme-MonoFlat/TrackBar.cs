// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
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
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.ComponentModel;


namespace Zeroit.Framework.UIThemes.MonoFlat
{
    #region  TrackBar

    [DefaultEvent("ValueChanged")]
    public class MonoFlatTrackBar : Control
    {

        #region  Enums

        public enum ValueDivisor
        {
            By1 = 1,
            By10 = 10,
            By100 = 100,
            By1000 = 1000
        }

        #endregion
        #region  Variables

        private Rectangle FillValue;
        private Rectangle PipeBorder;
        private Rectangle TrackBarHandleRect;
        private bool Cap;
        private int ValueDrawer;

        private Size ThumbSize = new Size(14, 14);
        private Rectangle TrackThumb;

        private int _Minimum = 0;
        private int _Maximum = 10;
        private int _Value = 0;

        private bool _JumpToMouse = false;
        private ValueDivisor DividedValue = ValueDivisor.By1;

        #endregion
        #region  Properties

        public int Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {

                if (value >= _Maximum)
                {
                    value = _Maximum - 10;
                }
                if (_Value < value)
                {
                    _Value = value;
                }

                _Minimum = value;
                Invalidate();
            }
        }

        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {

                if (value <= _Minimum)
                {
                    value = _Minimum + 10;
                }
                if (_Value > value)
                {
                    _Value = value;
                }

                _Maximum = value;
                Invalidate();
            }
        }

        public delegate void ValueChangedEventHandler();
        private ValueChangedEventHandler ValueChangedEvent;

        public event ValueChangedEventHandler ValueChanged
        {
            add
            {
                ValueChangedEvent = (ValueChangedEventHandler)System.Delegate.Combine(ValueChangedEvent, value);
            }
            remove
            {
                ValueChangedEvent = (ValueChangedEventHandler)System.Delegate.Remove(ValueChangedEvent, value);
            }
        }

        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (_Value != value)
                {
                    if (value < _Minimum)
                    {
                        _Value = _Minimum;
                    }
                    else
                    {
                        if (value > _Maximum)
                        {
                            _Value = _Maximum;
                        }
                        else
                        {
                            _Value = value;
                        }
                    }
                    Invalidate();
                    if (ValueChangedEvent != null)
                        ValueChangedEvent();
                }
            }
        }

        public ValueDivisor ValueDivison
        {
            get
            {
                return DividedValue;
            }
            set
            {
                DividedValue = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        public float ValueToSet
        {
            get
            {
                return _Value / (int)DividedValue;
            }
            set
            {
                Value = (int)(value * (int)DividedValue);
            }
        }

        public bool JumpToMouse
        {
            get
            {
                return _JumpToMouse;
            }
            set
            {
                _JumpToMouse = value;
                Invalidate();
            }
        }

        #endregion
        #region  EventArgs

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            checked
            {
                bool flag = this.Cap && e.X > -1 && e.X < this.Width + 1;
                if (flag)
                {
                    this.Value = this._Minimum + (int)Math.Round((double)(this._Maximum - this._Minimum) * ((double)e.X / (double)this.Width));
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                this.ValueDrawer = (int)Math.Round(((double)(this._Value - this._Minimum) / (double)(this._Maximum - this._Minimum)) * (double)(this.Width - 11));
                TrackBarHandleRect = new Rectangle(ValueDrawer, 0, 25, 25);
                Cap = TrackBarHandleRect.Contains(e.Location);
                Focus();
                if (_JumpToMouse)
                {
                    this.Value = this._Minimum + (int)Math.Round((double)(this._Maximum - this._Minimum) * ((double)e.X / (double)this.Width));
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cap = false;
        }

        #endregion

        public MonoFlatTrackBar()
        {
            SetStyle((System.Windows.Forms.ControlStyles)(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer), true);

            Size = new Size(80, 22);
            MinimumSize = new Size(47, 22);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 22;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;

            G.Clear(Parent.BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;
            TrackThumb = new Rectangle(7, 10, Width - 16, 2);
            PipeBorder = new Rectangle(1, 10, Width - 3, 2);

            try
            {
                this.ValueDrawer = (int)Math.Round(((double)(this._Value - this._Minimum) / (double)(this._Maximum - this._Minimum)) * (double)(this.Width));
            }
            catch (Exception)
            {
            }

            TrackBarHandleRect = new Rectangle(ValueDrawer, 0, 3, 20);

            G.FillRectangle(new SolidBrush(Color.FromArgb(124, 131, 137)), PipeBorder);
            FillValue = new Rectangle(0, 10, TrackBarHandleRect.X + TrackBarHandleRect.Width - 4, 3);

            G.ResetClip();

            G.SmoothingMode = SmoothingMode.Default;
            G.DrawRectangle(new Pen(Color.FromArgb(124, 131, 137)), PipeBorder); // Draw pipe border
            G.FillRectangle(new SolidBrush(Color.FromArgb(181, 41, 42)), FillValue);

            G.ResetClip();

            G.SmoothingMode = SmoothingMode.HighQuality;

            G.FillEllipse(new SolidBrush(Color.FromArgb(181, 41, 42)), this.TrackThumb.X + (int)Math.Round(unchecked((double)this.TrackThumb.Width * ((double)this.Value / (double)this.Maximum))) - (int)Math.Round((double)this.ThumbSize.Width / 2.0), this.TrackThumb.Y + (int)Math.Round((double)this.TrackThumb.Height / 2.0) - (int)Math.Round((double)this.ThumbSize.Height / 2.0), this.ThumbSize.Width, this.ThumbSize.Height);
            G.DrawEllipse(new Pen(Color.FromArgb(181, 41, 42)), this.TrackThumb.X + (int)Math.Round(unchecked((double)this.TrackThumb.Width * ((double)this.Value / (double)this.Maximum))) - (int)Math.Round((double)this.ThumbSize.Width / 2.0), this.TrackThumb.Y + (int)Math.Round((double)this.TrackThumb.Height / 2.0) - (int)Math.Round((double)this.ThumbSize.Height / 2.0), this.ThumbSize.Width, this.ThumbSize.Height);
        }
    }

    #endregion
}