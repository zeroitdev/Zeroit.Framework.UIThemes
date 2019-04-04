// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using static Zeroit.Framework.UIThemes.Login.DrawHelpers;

namespace Zeroit.Framework.UIThemes.Login
{

    [DefaultEvent("CheckedChanged")]
    public class LogInCheckBox : Control
    {

        #region "Declarations"
        private bool _Checked;
        private MouseState State = MouseState.None;
        private Color _CheckedColour = Color.FromArgb(173, 173, 174);
        private Color _BorderColour = Color.FromArgb(35, 35, 35);
        private Color _BackColour = Color.FromArgb(42, 42, 42);
        #endregion
        private Color _TextColour = Color.FromArgb(255, 255, 255);

        #region "Colour & Other Properties"

        [Category("Colours")]
        public Color BaseColour
        {
            get { return _BackColour; }
            set { _BackColour = value; }
        }

        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }

        [Category("Colours")]
        public Color CheckedColour
        {
            get { return _CheckedColour; }
            set { _CheckedColour = value; }
        }

        [Category("Colours")]
        public Color FontColour
        {
            get { return _TextColour; }
            set { _TextColour = value; }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);
        protected override void OnClick(EventArgs e)
        {
            _Checked = !_Checked;
            if (CheckedChanged != null)
            {
                CheckedChanged(this);
            }
            base.OnClick(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 22;
        }
        #endregion

        #region "Mouse States"

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }

        #endregion

        #region "Draw Control"
        public LogInCheckBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Cursor = Cursors.Hand;
            Size = new Size(100, 22);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle Base = new Rectangle(0, 0, 20, 20);
            var _with6 = g;
            _with6.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with6.SmoothingMode = SmoothingMode.HighQuality;
            _with6.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with6.Clear(Color.FromArgb(54, 54, 54));
            _with6.FillRectangle(new SolidBrush(_BackColour), Base);
            _with6.DrawRectangle(new Pen(_BorderColour), new Rectangle(1, 1, 18, 18));
            switch (State)
            {
                case MouseState.Over:
                    _with6.FillRectangle(new SolidBrush(Color.FromArgb(50, 49, 51)), Base);
                    _with6.DrawRectangle(new Pen(_BorderColour), new Rectangle(1, 1, 18, 18));
                    break;
            }
            if (Checked)
            {
                Point[] P = {
                new Point(4, 11),
                new Point(6, 8),
                new Point(9, 12),
                new Point(15, 3),
                new Point(17, 6),
                new Point(9, 16)
            };
                _with6.FillPolygon(new SolidBrush(_CheckedColour), P);
            }
            _with6.DrawString(Text, Font, new SolidBrush(_TextColour), new Rectangle(24, 1, Width, Height - 2), new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            });
            _with6.InterpolationMode = (InterpolationMode)7;
        }
        #endregion

    }

}


