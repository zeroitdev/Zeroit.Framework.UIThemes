﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static Zeroit.Framework.UIThemes.FlatUI.Helpers;
using System.ComponentModel;
//using System.Threading;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.FlatUI
{
    public class FlatGroupBox : ContainerControl
    {

        #region " Variables"

        private int W;
        private int H;

        private bool _ShowText = true;
        #endregion

        #region " Properties"

        [Category("Colors")]
        public Color BaseColor
        {
            get { return _BaseColor; }
            set { _BaseColor = value; }
        }

        public bool ShowText
        {
            get { return _ShowText; }
            set { _ShowText = value; }
        }

        #endregion

        #region " Colors"


        private Color _BaseColor = Color.FromArgb(60, 70, 73);
        #endregion

        public FlatGroupBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Size = new Size(240, 180);
            Font = new Font("Segoe ui", 10);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);
            W = Width - 1;
            H = Height - 1;

            dynamic GP = default(GraphicsPath);
            dynamic GP2 = default(GraphicsPath);
            GraphicsPath GP3 = new GraphicsPath();
            Rectangle Base = new Rectangle(8, 8, W - 16, H - 16);

            var _with7 = G;
            _with7.SmoothingMode = SmoothingMode.HighQuality;
            _with7.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with7.TextRenderingHint = TextRenderingHint.AntiAlias;
            _with7.Clear(BackColor);

            //-- Base
            GP = Helpers.RoundRec(Base, 8);
            _with7.FillPath(new SolidBrush(_BaseColor), GP);

            //-- Arrows
            GP2 = Helpers.DrawArrow(28, 2, false);
            _with7.FillPath(new SolidBrush(_BaseColor), GP2);
            GP3 = Helpers.DrawArrow(28, 8, true);
            _with7.FillPath(new SolidBrush(Color.FromArgb(60, 70, 73)), GP3);

            //-- if ShowText
            if (ShowText)
            {
                _with7.DrawString(Text, Font, new SolidBrush(_FlatColor), new Rectangle(16, 16, W, H), NearSF);
            }

            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
    }


}

