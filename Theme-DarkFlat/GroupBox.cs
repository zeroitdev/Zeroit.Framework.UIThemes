// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
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
    public class DarkFlatGroupBox : ContainerControl
    {
        #region  Variables

        private int W;
        private int H;
        private bool _ShowText = true;

        #endregion

        #region  Properties

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

        public bool ShowText
        {
            get
            {
                return _ShowText;
            }
            set
            {
                _ShowText = value;
            }
        }

        #endregion

        #region  Colors

        private Color _BaseColor = Color.FromArgb(60, 60, 60);

        #endregion

        public DarkFlatGroupBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Size = new Size(240, 180);
            Font = new Font("Segoe ui", 10);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(Width, Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            W = Width - 1;
            H = Height - 1;

            GraphicsPath GP = new GraphicsPath();
            GraphicsPath GP2 = new GraphicsPath();
            GraphicsPath GP3 = new GraphicsPath();
            Rectangle Base = new Rectangle(8, 8, W - 16, H - 16);

            Helpers.G.SmoothingMode = (System.Drawing.Drawing2D.SmoothingMode)2;
            Helpers.G.PixelOffsetMode = (System.Drawing.Drawing2D.PixelOffsetMode)2;
            Helpers.G.TextRenderingHint = (System.Drawing.Text.TextRenderingHint)5;
            Helpers.G.Clear(BackColor);

            //-- Base
            GP = Helpers.RoundRec(Base, 8);
            Helpers.G.FillPath(new SolidBrush(_BaseColor), GP);

            //-- Arrows
            GP2 = Helpers.DrawArrow(28, 2, false);
            Helpers.G.FillPath(new SolidBrush(_BaseColor), GP2);
            GP3 = Helpers.DrawArrow(28, 8, true);
            Helpers.G.FillPath(new SolidBrush(Color.FromArgb(60, 70, 73)), GP3);

            //-- if ShowText
            if (ShowText)
            {
                Helpers.G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(0, 170, 220)), new Rectangle(16, 16, W, H), Helpers.NearSF);
            }

            base.OnPaint(e);
            Helpers.G.Dispose();
            e.Graphics.InterpolationMode = (System.Drawing.Drawing2D.InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
            Helpers.B.Dispose();
        }
    }


}



