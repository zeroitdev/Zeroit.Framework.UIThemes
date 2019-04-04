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
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;
using static Zeroit.Framework.UIThemes.Elegant.DrawHelpers;

namespace Zeroit.Framework.UIThemes.Elegant
{

    [DefaultEvent("CheckedChanged")]
    public class ElegantThemeCheckBox : Control
    {

        #region "Declarations"

        private bool _Checked = false;
        private MouseState State = MouseState.None;
        private Font _Font = new Font("Segoe UI", 9);
        private Color _CheckedColour = Color.FromArgb(173, 173, 174);
        private Color _BorderColour = Color.FromArgb(193, 210, 176);
        private Color _BackColour = Color.Transparent;
        private Color _TextColour = Color.FromArgb(163, 163, 163);
        private Color _DefaultSqaureColour = Color.FromArgb(230, 230, 230);

        private Color _HoverSqaureColour = Color.FromArgb(220, 220, 220);
        #endregion

        #region "Colour & Other Properties"

        [Category("Colours")]
        public Color DefaultSqaureColour
        {
            get { return _DefaultSqaureColour; }
            set { _DefaultSqaureColour = value; }
        }

        [Category("Colours")]
        public Color HoverSqaureColour
        {
            get { return _HoverSqaureColour; }
            set { _HoverSqaureColour = value; }
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

        public ElegantThemeCheckBox()
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
            Rectangle Base = new Rectangle(0, 0, 22, 22);
            var _with6 = G;
            _with6.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            _with6.SmoothingMode = SmoothingMode.HighQuality;
            _with6.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with6.Clear(Color.FromArgb(250, 250, 250));
            _with6.FillRectangle(new SolidBrush(_BackColour), Base);
            _with6.FillRectangle(new SolidBrush(_DefaultSqaureColour), new Rectangle(0, 0, 22, 22));
            _with6.DrawRectangle(new Pen(_BorderColour), new Rectangle(1, 1, 22, 20));
            switch (State)
            {
                case MouseState.Over:
                    if (Checked)
                    {
                        _with6.FillRectangle(new SolidBrush(_HoverSqaureColour), new Rectangle(0, 0, 22, 22));
                        _with6.DrawLine(new Pen(_BorderColour, 2), 1, 1, 22, 20);
                        _with6.DrawLine(new Pen(_BorderColour, 2), 2, 20, 21, 2);
                        _with6.DrawRectangle(new Pen(_BorderColour, 2), new Rectangle(1, 1, 22, 20));
                    }
                    else
                    {
                        _with6.FillRectangle(new SolidBrush(_HoverSqaureColour), new Rectangle(0, 0, 22, 22));
                        _with6.DrawRectangle(new Pen(_BorderColour), new Rectangle(1, 1, 22, 20));
                    }
                    break;
            }
            if (Checked)
            {
                _with6.DrawLine(new Pen(_BorderColour, 2), 1, 1, 22, 20);
                _with6.DrawLine(new Pen(_BorderColour, 2), 2, 20, 22, 2);
                _with6.DrawRectangle(new Pen(_BorderColour, 2), new Rectangle(1, 1, 22, 20));
                _with6.FillRectangle(new SolidBrush(_BorderColour), new Rectangle(7, 6, 10, 10));
                _with6.DrawString(Text, _Font, new SolidBrush(Color.FromArgb(45, 45, 45)), new Rectangle(27, 0, Width, Height), new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center
                });
            }
            else
            {
                _with6.DrawString(Text, _Font, new SolidBrush(_TextColour), new Rectangle(27, 0, Width, Height), new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center
                });
            }
            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }

        #endregion

    }

}


