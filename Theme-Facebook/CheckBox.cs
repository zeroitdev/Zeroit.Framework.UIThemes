// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using static Zeroit.Framework.UIThemes.Facebook.DrawHelpers;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Facebook
{
    [DefaultEvent("CheckedChanged")]
    public class FacebookCheckBox : Control
    {

        #region "Declarations"
        private bool _Checked;
        private MouseState State = MouseState.None;
        private Color _HighColour = Color.FromArgb(125, 200, 255);
        private Color _CheckedColour = Color.FromArgb(103, 215, 243);
        private Color _BorderColour = Color.FromArgb(207, 211, 220);
        private Color _BackColour = Color.FromArgb(237, 239, 244);
        #endregion
        private Color _TextColour = Color.FromArgb(65, 73, 80);

        #region "Colour & Other Properties"

        [Category("Colours")]
        public Color HighlightColour
        {
            get { return _HighColour; }
            set { _HighColour = value; }
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

        protected override void OnTextChanged(System.EventArgs e)
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
        protected override void OnClick(System.EventArgs e)
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
        public FacebookCheckBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            Cursor = Cursors.Hand;
            Size = new Size(100, 22);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            dynamic G = Graphics.FromImage(B);
            Rectangle Base = new Rectangle(0, 0, 22, 22);
            var _with10 = G;
            _with10.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with10.SmoothingMode = SmoothingMode.HighQuality;
            _with10.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with10.Clear(BackColor);
            _with10.FillRectangle(new SolidBrush(_BackColour), Base);
            _with10.DrawRectangle(new Pen(_BorderColour), new Rectangle(1, 1, 20, 20));
            switch (State)
            {
                case MouseState.Over:
                    _with10.DrawRectangle(new Pen(_HighColour), new Rectangle(1, 1, 20, 20));
                    break;
                case MouseState.Down:
                    _with10.DrawRectangle(new Pen(_HighColour), new Rectangle(1, 1, 20, 20));
                    break;
            }
            if (Checked)
            {
                _with10.FillRectangle(new SolidBrush(_CheckedColour), new Rectangle(3, 3, 16, 16));
                _with10.DrawRectangle(new Pen(_HighColour), new Rectangle(1, 1, 20, 20));
            }
            _with10.DrawString(Text, Font, new SolidBrush(_TextColour), new Rectangle(24, 4, Width, Height), new StringFormat
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

