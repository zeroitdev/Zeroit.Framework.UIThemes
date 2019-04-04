// ***********************************************************************
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
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.Mpontuo
{
    [DefaultEvent("Scroll"), DefaultProperty("Value")]
    public class MpontuoTrackBar : Control
    {
        private bool InstanceFieldsInitialized = false;

        private void InitializeInstanceFields()
        {
            _orientation = Orientation.Horizontal;
        }

        public MpontuoTrackBar() : base()
        {
            if (!InstanceFieldsInitialized)
            {
                InitializeInstanceFields();
                InstanceFieldsInitialized = true;
            }
            this.Size = new Size(145, 11);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.Selectable | ControlStyles.UserMouse, true);
            this.Thumb = new Rectangle();
            this.LayoutTrackBarParts();
        }
        public event EventHandler Scroll;
        public event EventHandler ValueChanged;
        private Orientation _orientation;
        private Int32 _minimum;
        private Int32 _maximum = 100;
        //Private _smallChange As Int32 = 1
        private Int32 _largeChange = 5;
        private Int32 _value;
        private Int32 _tickFrequency = 1;
        private bool _thumbDragging;
        private bool _scrollUp;
        private Rectangle Thumb;
        private bool _thumbFocused;
        private Timer scrollTimer;
        [DefaultValue(typeof(Orientation), "Horizontal")]
        public Orientation Orientation
        {
            get
            {
                return _orientation;
            }
            set
            {
                if (_orientation != value)
                {
                    _orientation = value;
                    Int32 w = 0;
                    Int32 h = 0;
                    w = this.Height;
                    h = this.Width;
                    this.Size = new Size(w, h);
                    this.LayoutTrackBarParts();
                    this.Invalidate();
                }
            }
        }
        [DefaultValue(0), RefreshProperties(RefreshProperties.All)]
        public Int32 Minimum
        {
            get
            {
                return _minimum;
            }
            set
            {
                if (_minimum != value)
                {
                    _minimum = value;
                    if (_maximum <= value)
                    {
                        _maximum = value;
                    }
                    this.LayoutTrackBarParts();
                    this.Invalidate();
                }
            }
        }
        [DefaultValue(100)]
        public Int32 Maximum
        {
            get
            {
                return _maximum;
            }
            set
            {
                if (_maximum != value)
                {
                    _maximum = value;
                    if (Minimum >= value)
                    {
                        Minimum = value;
                    }
                    this.LayoutTrackBarParts();
                    this.Invalidate();
                }
            }
        }
        public Int32 Value
        {
            get
            {
                if (_value < this.Minimum)
                {
                    return this.Minimum;
                }
                return _value;
            }
            set
            {
                if (value < this.Minimum)
                {
                    value = _minimum;
                }
                if (value > _maximum)
                {
                    value = _maximum;
                }
                if (value != _value)
                {
                    _value = value;
                    this.LayoutTrackBarParts();
                    this.OnValueChanged(EventArgs.Empty);
                }
            }
        }
        private bool Horizontal
        {
            get
            {
                return _orientation == Orientation.Horizontal;
            }
        }
        private bool ThumbDragging
        {
            get
            {
                return _thumbDragging;
            }
            set
            {
                if (_thumbDragging != value)
                {
                    _thumbDragging = value;
                    this.Invalidate();
                }
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Rectangle channelBounds = new Rectangle();
            if (this.Horizontal)
            {
                channelBounds = new Rectangle(6, (int)(this.Height / 2.0 - 2), this.Width - 16, 4);
            }
            else
            {
                channelBounds = new Rectangle((int)(this.Width / 2.0 - 2), 6, 4, this.Height - 16);
            }
            ControlPaint.DrawBorder3D(e.Graphics, channelBounds, Border3DStyle.Sunken);
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(60, 60, 60)))
            {
                if (ThumbDragging)
                {
                    brush.Color = Color.FromArgb(75, 75, 75);
                }
                e.Graphics.FillRectangle(brush, this.Thumb);
                e.Graphics.DrawRectangle(Pens.Black, this.Thumb);
            }
            if (this.Focused && this.ShowFocusCues)
            {
                ControlPaint.DrawFocusRectangle(e.Graphics, this.ClientRectangle);
            }
        }
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            _thumbFocused = (this.Focused && this.ShowFocusCues);
            this.Invalidate();
        }
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            _thumbFocused = (this.Focused && this.ShowFocusCues);
            this.Invalidate();
        }
        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    return true;
                default:
                    return base.IsInputKey(keyData);
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                ThumbDragging = Thumb.Contains(e.Location);
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            ThumbDragging = false;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (ThumbDragging)
            {
                this.Value = ValueFromPoint(e.Location);
            }
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                this.LayoutTrackBarParts();
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.LayoutTrackBarParts();
        }
        protected virtual void OnScroll(EventArgs e)
        {
            if (Scroll != null)
                Scroll(this, e);
        }
        protected virtual void OnValueChanged(EventArgs eventArgs)
        {
            if (ValueChanged != null)
                ValueChanged(this, eventArgs);
            this.LayoutTrackBarParts();
            this.OnScroll(eventArgs);
            this.Invalidate();
        }
        private void LayoutTrackBarParts()
        {
            if (this.Horizontal)
            {
                Thumb.Size = new Size(14, 28);
            }
            else
            {
                Thumb.Size = new Size(28, 14);
            }
            float channelLength = 0F;
            if (this.Horizontal)
            {
                channelLength = this.Width - 26;
            }
            else
            {
                channelLength = this.Height - 26;
            }
            float stepCount = (this.Maximum - this.Minimum);
            float stepSize = 0F;
            if (stepCount > 0)
            {
                stepSize = channelLength / stepCount;
            }
            else
            {
                stepSize = 0F;
            }
            float thumbOffset = (stepSize) * (this.Value - this.Minimum);
            if (this.Horizontal)
            {
                Thumb.Location = Point.Round(new PointF(6 + thumbOffset, (int)(this.Height / 2.0 - 14)));
            }
            else
            {
                Thumb.Location = Point.Round(new PointF((int)(this.Width / 2.0 - 14), channelLength - thumbOffset + 6));
            }
        }
        private Int32 ValueFromPoint(Point point)
        {
            float channelLength = 0F;
            if (this.Horizontal)
            {
                channelLength = this.Width - 26; // Channel Left margin + Channel Right margin + Thumb.Width
            }
            else
            {
                channelLength = this.Height - 26; // Channel Top margin + Channel Bottom margin + Thumb.Height
            }
            float stepCount = (this.Maximum - this.Minimum);
            float stepSize = 0F;
            if (stepCount > 0)
            {
                stepSize = channelLength / stepCount;
            }
            if (this.Horizontal)
            {
                point.Offset(-7, 0);
                return Convert.ToInt32((point.X / stepSize) + this.Minimum);
            }
            point.Offset(0, -7);
            return Convert.ToInt32(this.Maximum - (point.Y / stepSize) + this.Minimum);
        }
    }
}

