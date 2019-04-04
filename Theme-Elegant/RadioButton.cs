// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="RadioButton.cs" company="Zeroit Dev Technologies">
//     Copyright � Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;
using static Zeroit.Framework.UIThemes.Elegant.DrawHelpers;

namespace Zeroit.Framework.UIThemes.Elegant
{

    [DefaultEvent("CheckedChanged")]
    public class ElegantRadioButton : Control
    {

        #region "Declarations"
        private bool _Checked;
        private MouseState State = MouseState.None;
        private Color _HoverColour = Color.FromArgb(240, 240, 240);
        private Color _CheckedColour = Color.FromArgb(163, 190, 146);
        private Color _BorderColour = Color.FromArgb(210, 210, 210);
        private Color _BackColour = Color.FromArgb(255, 255, 255);
        #endregion
        private Color _TextColour = Color.FromArgb(163, 163, 163);

        #region "Colour & Other Properties"

        [Category("Colours")]
        public Color HighlightColour
        {
            get { return _HoverColour; }
            set { _HoverColour = value; }
        }

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

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                InvalidateControls();
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }
                Invalidate();
            }
        }

        protected override void OnClick(EventArgs e)
        {
            if (!_Checked)
                Checked = true;
            base.OnClick(e);
        }
        private void InvalidateControls()
        {
            if (!IsHandleCreated || !_Checked)
                return;
            foreach (Control C in Parent.Controls)
            {
                if (!object.ReferenceEquals(C, this) && C is ElegantRadioButton)
                {
                    ((ElegantRadioButton)C).Checked = false;
                    Invalidate();
                }
            }
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            InvalidateControls();
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
        public ElegantRadioButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Cursor = Cursors.Hand;
            Size = new Size(100, 22);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G = Graphics.FromImage(B);
            Rectangle Base = new Rectangle(1, 1, Height - 2, Height - 2);
            Rectangle Circle = new Rectangle(6, 6, Height - 12, Height - 12);
            Rectangle SecondBorder = new Rectangle(4, 3, 14, 14);
            var _with18 = G;
            _with18.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            _with18.SmoothingMode = SmoothingMode.HighQuality;
            _with18.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with18.Clear(Color.Transparent);
            _with18.FillEllipse(new SolidBrush(_BackColour), Base);
            _with18.DrawEllipse(new Pen(_BorderColour, 2), Base);
            if (Checked)
            {
                switch (State)
                {
                    case MouseState.Over:
                        _with18.FillEllipse(new SolidBrush(_HoverColour), new Rectangle(2, 2, Height - 4, Height - 4));
                        break;
                }
                _with18.FillEllipse(new SolidBrush(_CheckedColour), Circle);
            }
            else
            {
                switch (State)
                {
                    case MouseState.Over:
                        _with18.FillEllipse(new SolidBrush(_HoverColour), new Rectangle(2, 2, Height - 4, Height - 4));
                        break;
                }
            }
            _with18.DrawString(Text, Font, new SolidBrush(_TextColour), new Rectangle(24, 3, Width, Height), new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near
            });
            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
        #endregion

    }

}

