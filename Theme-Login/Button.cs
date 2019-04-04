// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
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

    public class LogInButton : Control
    {

        #region "Declarations"
        private readonly Font _Font = new Font("Segoe UI", 9);
        private Color _ProgressColour = Color.FromArgb(0, 191, 255);
        private Color _BorderColour = Color.FromArgb(25, 25, 25);
        private Color _FontColour = Color.FromArgb(255, 255, 255);
        private Color _MainColour = Color.FromArgb(42, 42, 42);
        private Color _HoverColour = Color.FromArgb(52, 52, 52);
        private Color _PressedColour = Color.FromArgb(47, 47, 47);
        #endregion
        private MouseState State = new MouseState();

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

        #region "Properties"

        [Category("Colours")]
        public Color ProgressColour
        {
            get { return _ProgressColour; }
            set { _ProgressColour = value; }
        }

        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }

        [Category("Colours")]
        public Color FontColour
        {
            get { return _FontColour; }
            set { _FontColour = value; }
        }

        [Category("Colours")]
        public Color BaseColour
        {
            get { return _MainColour; }
            set { _MainColour = value; }
        }

        [Category("Colours")]
        public Color HoverColour
        {
            get { return _HoverColour; }
            set { _HoverColour = value; }
        }

        [Category("Colours")]
        public Color PressedColour
        {
            get { return _PressedColour; }
            set { _PressedColour = value; }
        }

        #endregion

        #region "Draw Control"
        public LogInButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new Size(75, 30);
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            var _with10 = G;
            _with10.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with10.SmoothingMode = SmoothingMode.HighQuality;
            _with10.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with10.InterpolationMode = (InterpolationMode)7;
            _with10.Clear(BackColor);
            switch (State)
            {
                case MouseState.None:
                    _with10.FillRectangle(new SolidBrush(_MainColour), new Rectangle(0, 0, Width, Height));
                    _with10.DrawRectangle(new Pen(_BorderColour, 2), new Rectangle(0, 0, Width, Height));
                    _with10.DrawString(Text, _Font, Brushes.White, new Point(Convert.ToInt32(Width / 2), Convert.ToInt32(Height / 2)), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Over:
                    _with10.FillRectangle(new SolidBrush(_HoverColour), new Rectangle(0, 0, Width, Height));
                    _with10.DrawRectangle(new Pen(_BorderColour, 1), new Rectangle(1, 1, Width - 2, Height - 2));
                    _with10.DrawString(Text, _Font, Brushes.White, new Point(Convert.ToInt32(Width / 2), Convert.ToInt32(Height / 2)), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Down:
                    _with10.FillRectangle(new SolidBrush(_PressedColour), new Rectangle(0, 0, Width, Height));
                    _with10.DrawRectangle(new Pen(_BorderColour, 1), new Rectangle(1, 1, Width - 2, Height - 2));
                    _with10.DrawString(Text, _Font, Brushes.White, new Point(Convert.ToInt32(Width / 2), Convert.ToInt32(Height / 2)), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
            }
        }

        #endregion

    }

}


