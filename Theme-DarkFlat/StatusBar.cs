// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="StatusBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.DarkFlat
{
    public class DarkFlatStatusBar : Control
    {
        #region  Variables

        private int W;
        private int H;
        private bool _ShowTimeDate = false;

        #endregion

        #region  Properties

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

        #region  Colors

        [Category("Colors")]
        public Color BaseColor
        {
            get
            {
                return _BaseColor;
            }
            set
            {
                _BaseColor = value;
            }
        }

        [Category("Colors")]
        public Color TextColor
        {
            get
            {
                return _TextColor;
            }
            set
            {
                _TextColor = value;
            }
        }

        [Category("Colors")]
        public Color RectColor
        {
            get
            {
                return _RectColor;
            }
            set
            {
                _RectColor = value;
            }
        }

        #endregion

        public bool ShowTimeDate
        {
            get
            {
                return _ShowTimeDate;
            }
            set
            {
                _ShowTimeDate = value;
            }
        }

        public string GetTimeDate()
        {
            return DateTime.Now.Date + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute;
        }

        #endregion

        #region  Colors

        private Color _BaseColor = Color.FromArgb(50, 50, 50);
        private Color _TextColor = Color.White;
        private Color _RectColor = Color.FromArgb(0, 170, 220);

        #endregion

        public DarkFlatStatusBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 8);
            ForeColor = Color.White;
            Size = new Size(Width, 20);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(Width, Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            W = Width;
            H = Height;

            Rectangle Base = new Rectangle(0, 0, W, H);

            Helpers.G.SmoothingMode = (System.Drawing.Drawing2D.SmoothingMode)2;
            Helpers.G.PixelOffsetMode = (System.Drawing.Drawing2D.PixelOffsetMode)2;
            Helpers.G.TextRenderingHint = (System.Drawing.Text.TextRenderingHint)5;
            Helpers.G.Clear(BaseColor);

            //-- Base
            Helpers.G.FillRectangle(new SolidBrush(BaseColor), Base);

            //-- Text
            Helpers.G.DrawString(Text, Font, Brushes.White, new Rectangle(10, 4, W, H), Helpers.NearSF);

            //-- Rectangle
            Helpers.G.FillRectangle(new SolidBrush(_RectColor), new Rectangle(4, 4, 4, 14));

            //-- TimeDate
            if (ShowTimeDate)
            {
                Helpers.G.DrawString(GetTimeDate(), Font, new SolidBrush(_TextColor), new Rectangle(-4, 2, W, H), new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center });
            }

            base.OnPaint(e);
            Helpers.G.Dispose();
            e.Graphics.InterpolationMode = (System.Drawing.Drawing2D.InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
            Helpers.B.Dispose();
        }
    }


}



