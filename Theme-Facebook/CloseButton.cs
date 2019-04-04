// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="CloseButton.cs" company="Zeroit Dev Technologies">
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
    public class FacebookCloseButton : Control
    {

        #region "Declarations"
        private MouseState State = MouseState.None;
        private int x;
        #endregion
        private Color _BackColour = Color.FromArgb(67, 96, 156);

        #region "Mouse States"

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            x = e.X;
            Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Environment.Exit(0);
        }

        #endregion

        #region "Colour Properties"
        [Category("Colors")]
        public Color BaseColour
        {
            get { return _BackColour; }
            set { _BackColour = value; }
        }
        #endregion

        #region "Draw Control"
        public FacebookCloseButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.White;
            Size = new Size(20, 20);
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Font = new Font("Marlett", 20);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle Base = new Rectangle(0, 0, Width, Height);
            var _with5 = G;
            _with5.SmoothingMode = SmoothingMode.HighQuality;
            _with5.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with5.TextRenderingHint = TextRenderingHint.AntiAlias;
            _with5.Clear(BackColor);
            _with5.FillRectangle(new SolidBrush(_BackColour), Base);
            switch (State)
            {
                case MouseState.None:
                    _with5.DrawString("r", Font, new SolidBrush(Color.FromArgb(211, 218, 233)), new Rectangle(0, 0, Width, Height), new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Over:
                    _with5.DrawString("r", Font, new SolidBrush(Color.FromArgb(151, 158, 172)), new Rectangle(0, 0, Width, Height), new StringFormat
                    {
                        LineAlignment = StringAlignment.Near,
                        Alignment = StringAlignment.Center
                    });
                    break;
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

