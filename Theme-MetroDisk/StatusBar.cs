// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="StatusBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using static Zeroit.Framework.UIThemes.MetroDisk.Helpers;
using System.Drawing.Text;


namespace Zeroit.Framework.UIThemes.MetroDisk
{
    public class MetroDiskStatusBar : Control
    {

        #region " Variables"

        private int W;
        private int H;
        private bool _ShowTimeDate = false;

        private bool _LightTheme = false;
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

        public bool LightTheme
        {
            get { return _LightTheme; }
            set { _LightTheme = value; }
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

        public MetroDiskStatusBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 8);
            ForeColor = Color.White;
            Size = new Size(Width, 20);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_LightTheme)
            {
                //light
                _BaseColor = Color.FromArgb(255, 255, 255);
                _TextColor = Color.FromArgb(0, 0, 0);
                ForeColor = Color.FromArgb(0, 0, 0);
            }
            else
            {
                //dark
                _BaseColor = Color.FromArgb(0, 0, 0);
                _TextColor = Color.FromArgb(255, 255, 255);
                ForeColor = Color.FromArgb(255, 255, 255);
            }
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);
            W = Width;
            H = Height;

            Rectangle Base = new Rectangle(2, 2, W - 10, H - 10);

            var _with18 = G;
            _with18.SmoothingMode = (SmoothingMode)2;
            _with18.PixelOffsetMode = (PixelOffsetMode)2;
            _with18.TextRenderingHint = (TextRenderingHint)5;
            _with18.Clear(BaseColor);

            //-- Base
            _with18.FillRectangle(new SolidBrush(BaseColor), Base);

            //-- Text
            _with18.DrawString(Text, Font, Brushes.White, new Rectangle(10, 4, W, H), NearSF);

            //-- Rectangle
            _with18.FillRectangle(new SolidBrush(_RectColor), new Rectangle(4, 4, 4, 14));

            //-- TimeDate
            if (ShowTimeDate)
            {
                _with18.DrawString(GetTimeDate(), Font, new SolidBrush(_TextColor), new Rectangle(-4, 2, W, H), new StringFormat
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