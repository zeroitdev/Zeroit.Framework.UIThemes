// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
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
    public class DarkFlatButton : Control
    {
        #region  Variables

        private int W;
        private int H;
        private bool _Rounded = false;
        private MouseState State = MouseState.None;

        #endregion

        #region  Properties

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

        [Category("Options")]
        public bool Rounded
        {
            get
            {
                return _Rounded;
            }
            set
            {
                _Rounded = value;
            }
        }

        #endregion

        #region  Mouse States

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

        #region  Colors

        private Color _BaseColor = Color.FromArgb(0, 170, 220);
        private Color _TextColor = Color.FromArgb(243, 243, 243);

        #endregion

        public DarkFlatButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new Size(106, 32);
            BackColor = Color.Transparent;
            Font = new Font("Segoe UI", 10);
            Cursor = Cursors.Hand;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(Width, Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            W = Width - 1;
            H = Height - 1;

            GraphicsPath GP = new GraphicsPath();
            Rectangle Base = new Rectangle(0, 0, W, H);

            Helpers.G.SmoothingMode = (System.Drawing.Drawing2D.SmoothingMode)2;
            Helpers.G.PixelOffsetMode = (System.Drawing.Drawing2D.PixelOffsetMode)2;
            Helpers.G.TextRenderingHint = (System.Drawing.Text.TextRenderingHint)5;
            Helpers.G.Clear(BackColor);

            switch (State)
            {
                case MouseState.None:
                    if (Rounded)
                    {
                        //-- Base
                        GP = Helpers.RoundRec(Base, 6);
                        Helpers.G.FillPath(new SolidBrush(_BaseColor), GP);

                        //-- Text
                        Helpers.G.DrawString(Text, Font, new SolidBrush(_TextColor), Base, Helpers.CenterSF);
                    }
                    else
                    {
                        //-- Base
                        Helpers.G.FillRectangle(new SolidBrush(_BaseColor), Base);

                        //-- Text
                        Helpers.G.DrawString(Text, Font, new SolidBrush(_TextColor), Base, Helpers.CenterSF);
                    }
                    break;
                case MouseState.Over:
                    if (Rounded)
                    {
                        //-- Base
                        GP = Helpers.RoundRec(Base, 6);
                        Helpers.G.FillPath(new SolidBrush(_BaseColor), GP);
                        Helpers.G.FillPath(new SolidBrush(Color.FromArgb(20, Color.White)), GP);

                        //-- Text
                        Helpers.G.DrawString(Text, Font, new SolidBrush(_TextColor), Base, Helpers.CenterSF);
                    }
                    else
                    {
                        //-- Base
                        Helpers.G.FillRectangle(new SolidBrush(_BaseColor), Base);
                        Helpers.G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)), Base);

                        //-- Text
                        Helpers.G.DrawString(Text, Font, new SolidBrush(_TextColor), Base, Helpers.CenterSF);
                    }
                    break;
                case MouseState.Down:
                    if (Rounded)
                    {
                        //-- Base
                        GP = Helpers.RoundRec(Base, 6);
                        Helpers.G.FillPath(new SolidBrush(_BaseColor), GP);
                        Helpers.G.FillPath(new SolidBrush(Color.FromArgb(20, Color.Black)), GP);

                        //-- Text
                        Helpers.G.DrawString(Text, Font, new SolidBrush(_TextColor), Base, Helpers.CenterSF);
                    }
                    else
                    {
                        //-- Base
                        Helpers.G.FillRectangle(new SolidBrush(_BaseColor), Base);
                        Helpers.G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.Black)), Base);

                        //-- Text
                        Helpers.G.DrawString(Text, Font, new SolidBrush(_TextColor), Base, Helpers.CenterSF);
                    }
                    break;
            }

            base.OnPaint(e);
            Helpers.G.Dispose();
            e.Graphics.InterpolationMode = (System.Drawing.Drawing2D.InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
            Helpers.B.Dispose();
        }
    }


}



