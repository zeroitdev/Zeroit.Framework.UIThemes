// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using static Zeroit.Framework.UIThemes.MetroDisk.Helpers;
using System.Drawing.Text;


namespace Zeroit.Framework.UIThemes.MetroDisk
{

    public class MetroDiskGroupBox : ContainerControl
    {

        #region " Variables"

        private int W;
        private int H;
        private bool _ShowText = true;
        private bool _Arrows = true;
        private bool _LightTheme;
        #endregion
        private int _Curve = 1;

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

        public bool Arrows
        {
            get { return _Arrows; }
            set { _Arrows = value; }
        }

        public bool LightTheme
        {
            get { return _LightTheme; }
            set { _LightTheme = value; }
        }

        public int Curve
        {
            get { return _Curve; }
            set { _Curve = value; }
        }

        #endregion

        #region " Colors"


        private Color _BaseColor = Color.FromArgb(60, 70, 73);
        #endregion

        public MetroDiskGroupBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Size = new Size(240, 180);
            Font = new Font("Segoe ui", 10);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_LightTheme)
            {
                //light
                _BaseColor = Color.FromArgb(240, 240, 240);
            }
            else
            {
                //dark
                _BaseColor = Color.FromArgb(20, 20, 20);
            }

            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);
            W = Width - 1;
            H = Height - 1;

            dynamic GP = default(GraphicsPath);
            dynamic GP2 = default(GraphicsPath);
            GraphicsPath GP3 = new GraphicsPath();
            Rectangle Base = new Rectangle(8, 8, W - 16, H - 16);

            var _with3 = G;
            _with3.SmoothingMode = (SmoothingMode)2;
            _with3.PixelOffsetMode = (PixelOffsetMode)2;
            _with3.TextRenderingHint = (TextRenderingHint)5;
            _with3.Clear(BackColor);

            //-- Base

            GP = Helpers.RoundRec(Base, _Curve);
            _with3.FillPath(new SolidBrush(_BaseColor), GP);
            //curve here


            if (_Arrows)
            {
                //-- Arrows
                GP2 = Helpers.DrawArrow(28, 2, false);
                _with3.FillPath(new SolidBrush(_BaseColor), GP2);
                GP3 = Helpers.DrawArrow(28, 8, true);
                if (_LightTheme)
                {
                    _with3.FillPath(new SolidBrush(Color.FromArgb(240, 240, 240)), GP3);
                }
                else
                {
                    _with3.FillPath(new SolidBrush(Color.FromArgb(20, 20, 20)), GP3);
                }

            }


            //-- if ShowText
            if (ShowText)
            {
                _with3.DrawString(Text, Font, new SolidBrush(_FlatColor), new Rectangle(16, 16, W, H), NearSF);
            }

            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }
    }
}