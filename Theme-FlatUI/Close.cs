﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Close.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
    public class FlatClose : Control
    {

        #region " Variables"

        private MouseState State = MouseState.None;

        private int x;
        #endregion

        #region " Properties"

        #region " Mouse States"

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

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Size = new Size(18, 18);
        }

        #region " Colors"

        [Category("Colors")]
        public Color BaseColor
        {
            get { return _BaseColor; }
            set { _BaseColor = value; }
        }

        [Category("Colors")]
        public Color TextColor
        {
            get { return _TextColor; }
            set { _TextColor = value; }
        }

        #endregion

        #endregion

        #region " Colors"

        private Color _BaseColor = Color.FromArgb(168, 35, 35);

        private Color _TextColor = Color.FromArgb(243, 243, 243);
        #endregion

        public FlatClose()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.White;
            Size = new Size(18, 18);
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Font = new Font("Marlett", 10);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            Rectangle Base = new Rectangle(0, 0, Width, Height);

            var _with3 = G;
            _with3.SmoothingMode = SmoothingMode.HighQuality;
            _with3.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with3.TextRenderingHint = TextRenderingHint.AntiAlias;
            _with3.Clear(BackColor);

            //-- Base
            _with3.FillRectangle(new SolidBrush(_BaseColor), Base);

            //-- X
            _with3.DrawString("r", Font, new SolidBrush(TextColor), new Rectangle(0, 0, Width, Height), CenterSF);

            //-- Hover/down
            switch (State)
            {
                case MouseState.Over:
                    _with3.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), Base);
                    break;
                case MouseState.Down:
                    _with3.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Black)), Base);
                    break;
            }

            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
    }


}

