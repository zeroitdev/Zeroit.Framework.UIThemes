﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="StickyButton.cs" company="Zeroit Dev Technologies">
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

    public class FlatStickyButton : Control
    {

        #region " Variables"

        private int W;
        private int H;
        private MouseState State = MouseState.None;

        private bool _Rounded = false;
        #endregion

        #region " Properties"

        #region " MouseStates"

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

        #region " Function"

        private bool[] GetConnectedSides()
        {
            bool[] Bool = new bool[] {
            false,
            false,
            false,
            false
        };

            foreach (Control B in Parent.Controls)
            {
                if (B is FlatStickyButton)
                {
                    if (object.ReferenceEquals(B, this) | !Rect.IntersectsWith(Rect))
                        continue;
                    dynamic A = Math.Atan2(this.Left - B.Left, Top - B.Top) * 2 / Math.PI;
                    if (A / 1 == A)
                        Bool[A + 1] = true;
                }
            }

            return Bool;
        }

        private Rectangle Rect
        {
            get { return new Rectangle(Left, Top, Width, Height); }
        }

        #endregion

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

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            //Height = 32
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            //Size = New Size(112, 32)
        }

        #endregion

        #region " Colors"

        private Color _BaseColor = _FlatColor;

        private Color _TextColor = Color.FromArgb(243, 243, 243);
        #endregion

        public FlatStickyButton()
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
            W = Width;
            H = Height;

            GraphicsPath GP = new GraphicsPath();

            dynamic GCS = GetConnectedSides();
            dynamic RoundedBase = Helpers.RoundRect(0, 0, W, H, !(GCS(2) | GCS(1)), !(GCS(1) | GCS(0)), !(GCS(3) | GCS(0)), !(GCS(3) | GCS(2)));
            Rectangle Base = new Rectangle(0, 0, W, H);

            var _with17 = G;
            _with17.SmoothingMode = SmoothingMode.HighQuality;
            _with17.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with17.TextRenderingHint = TextRenderingHint.AntiAlias;
            _with17.Clear(BackColor);

            switch (State)
            {
                case MouseState.None:
                    if (Rounded)
                    {
                        //-- Base
                        GP = RoundedBase;
                        _with17.FillPath(new SolidBrush(_BaseColor), GP);

                        //-- Text
                        _with17.DrawString(Text, Font, new SolidBrush(_TextColor), Base, CenterSF);
                    }
                    else
                    {
                        //-- Base
                        _with17.FillRectangle(new SolidBrush(_BaseColor), Base);

                        //-- Text
                        _with17.DrawString(Text, Font, new SolidBrush(_TextColor), Base, CenterSF);
                    }
                    break;
                case MouseState.Over:
                    if (Rounded)
                    {
                        //-- Base
                        GP = RoundedBase;
                        _with17.FillPath(new SolidBrush(_BaseColor), GP);
                        _with17.FillPath(new SolidBrush(Color.FromArgb(20, Color.White)), GP);

                        //-- Text
                        _with17.DrawString(Text, Font, new SolidBrush(_TextColor), Base, CenterSF);
                    }
                    else
                    {
                        //-- Base
                        _with17.FillRectangle(new SolidBrush(_BaseColor), Base);
                        _with17.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)), Base);

                        //-- Text
                        _with17.DrawString(Text, Font, new SolidBrush(_TextColor), Base, CenterSF);
                    }
                    break;
                case MouseState.Down:
                    if (Rounded)
                    {
                        //-- Base
                        GP = RoundedBase;
                        _with17.FillPath(new SolidBrush(_BaseColor), GP);
                        _with17.FillPath(new SolidBrush(Color.FromArgb(20, Color.Black)), GP);

                        //-- Text
                        _with17.DrawString(Text, Font, new SolidBrush(_TextColor), Base, CenterSF);
                    }
                    else
                    {
                        //-- Base
                        _with17.FillRectangle(new SolidBrush(_BaseColor), Base);
                        _with17.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.Black)), Base);

                        //-- Text
                        _with17.DrawString(Text, Font, new SolidBrush(_TextColor), Base, CenterSF);
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

