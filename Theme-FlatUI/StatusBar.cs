﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="StatusBar.cs" company="Zeroit Dev Technologies">
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
    public class FlatStatusBar : Control
    {

        #region " Variables"

        private int W;
        private int H;

        private bool _ShowTimeDate = false;
        #endregion

        #region " Properties"

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Dock = DockStyle.Bottom;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
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

        [Category("Colors")]
        public Color RectColor
        {
            get { return _RectColor; }
            set { _RectColor = value; }
        }

        #endregion

        public bool ShowTimeDate
        {
            get { return _ShowTimeDate; }
            set { _ShowTimeDate = value; }
        }

        public string GetTimeDate()
        {
            return DateTime.Now.Date + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute;
        }

        #endregion

        #region " Colors"

        private Color _BaseColor = Color.FromArgb(45, 47, 49);
        private Color _TextColor = Color.White;

        private Color _RectColor = _FlatColor;
        #endregion

        public FlatStatusBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 8);
            ForeColor = Color.White;
            Size = new Size(Width, 20);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);
            W = Width;
            H = Height;

            Rectangle Base = new Rectangle(0, 0, W, H);

            var _with21 = G;
            _with21.SmoothingMode = SmoothingMode.HighQuality;
            _with21.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with21.TextRenderingHint = TextRenderingHint.AntiAlias;
            _with21.Clear(BaseColor);

            //-- Base
            _with21.FillRectangle(new SolidBrush(BaseColor), Base);

            //-- Text
            _with21.DrawString(Text, Font, Brushes.White, new Rectangle(10, 4, W, H), NearSF);

            //-- Rectangle
            _with21.FillRectangle(new SolidBrush(_RectColor), new Rectangle(4, 4, 4, 14));

            //-- TimeDate
            if (ShowTimeDate)
            {
                _with21.DrawString(GetTimeDate(), Font, new SolidBrush(_TextColor), new Rectangle(-4, 2, W, H), new StringFormat
                {
                    Alignment = StringAlignment.Far,
                    LineAlignment = StringAlignment.Center
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

