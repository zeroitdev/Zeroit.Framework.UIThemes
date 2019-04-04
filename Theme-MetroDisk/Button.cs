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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using static Zeroit.Framework.UIThemes.MetroDisk.Helpers;
using System.Drawing.Text;


namespace Zeroit.Framework.UIThemes.MetroDisk
{
    public class MetroDiskButton : Control
    {

        #region " Variables"

        private int W;
        private int H;
        private bool _Rounded = false;

        private MouseState State = MouseState.None;
        #endregion

        #region " Properties"

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

        [Category("Options")]
        public bool Rounded
        {
            get { return _Rounded; }
            set { _Rounded = value; }
        }

        #endregion

        #region " Mouse States"

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

        #endregion

        #region " Colors"

        private Color _BaseColor = _FlatColor;

        private Color _TextColor = Color.FromArgb(243, 243, 243);
        #endregion

        public MetroDiskButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new Size(106, 32);
            BackColor = Color.Transparent;
            Font = new Font("Segoe UI", 12);
            Cursor = Cursors.Hand;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);
            W = Width - 1;
            H = Height - 1;

            GraphicsPath GP = new GraphicsPath();
            Rectangle Base = new Rectangle(0, 0, W, H);

            var _with4 = G;
            _with4.SmoothingMode = (SmoothingMode)2;
            _with4.PixelOffsetMode = (PixelOffsetMode)2;
            _with4.TextRenderingHint = (TextRenderingHint)5;
            _with4.Clear(BackColor);

            switch (State)
            {
                case MouseState.None:
                    if (Rounded)
                    {
                        //-- Base
                        GP = Helpers.RoundRec(Base, 6);
                        _with4.FillPath(new SolidBrush(_BaseColor), GP);

                        //-- Text
                        _with4.DrawString(Text, Font, new SolidBrush(_TextColor), Base, CenterSF);
                    }
                    else
                    {
                        //-- Base
                        _with4.FillRectangle(new SolidBrush(_BaseColor), Base);

                        //-- Text
                        _with4.DrawString(Text, Font, new SolidBrush(_TextColor), Base, CenterSF);
                    }
                    break;
                case MouseState.Over:
                    if (Rounded)
                    {
                        //-- Base
                        GP = Helpers.RoundRec(Base, 6);
                        _with4.FillPath(new SolidBrush(_BaseColor), GP);
                        _with4.FillPath(new SolidBrush(Color.FromArgb(20, Color.White)), GP);

                        //-- Text
                        _with4.DrawString(Text, Font, new SolidBrush(_TextColor), Base, CenterSF);
                    }
                    else
                    {
                        //-- Base
                        _with4.FillRectangle(new SolidBrush(_BaseColor), Base);
                        _with4.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)), Base);

                        //-- Text
                        _with4.DrawString(Text, Font, new SolidBrush(_TextColor), Base, CenterSF);
                    }
                    break;
                case MouseState.Down:
                    if (Rounded)
                    {
                        //-- Base
                        GP = Helpers.RoundRec(Base, 6);
                        _with4.FillPath(new SolidBrush(_BaseColor), GP);
                        _with4.FillPath(new SolidBrush(Color.FromArgb(20, Color.Black)), GP);

                        //-- Text
                        _with4.DrawString(Text, Font, new SolidBrush(_TextColor), Base, CenterSF);
                    }
                    else
                    {
                        //-- Base
                        _with4.FillRectangle(new SolidBrush(_BaseColor), Base);
                        _with4.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.Black)), Base);

                        //-- Text
                        _with4.DrawString(Text, Font, new SolidBrush(_TextColor), Base, CenterSF);
                    }
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