// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Theme.cs" company="Zeroit Dev Technologies">
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
    static class Helpers
    {

        #region  Variables
        internal static Graphics G;
        internal static Bitmap B;
        internal static Color _FlatColor = Color.FromArgb(35, 168, 109);
        internal static StringFormat NearSF = new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near };
        internal static StringFormat CenterSF = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
        #endregion

        #region  Functions

        public static GraphicsPath RoundRec(Rectangle Rectangle, int Curve)
        {
            GraphicsPath P = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180F, 90F);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90F, 90F);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0F, 90F);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90F, 90F);
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return P;
        }

        public static GraphicsPath RoundRect(float x, float y, float w, float h, float r = 0.3F, bool TL = true, bool TR = true, bool BR = true, bool BL = true)
        {
            GraphicsPath tempRoundRect = null;
            float d = Math.Min(w, h) * r;
            var xw = x + w;
            var yh = y + h;
            tempRoundRect = new GraphicsPath();

            if (TL)
            {
                tempRoundRect.AddArc(x, y, d, d, 180, 90);
            }
            else
            {
                tempRoundRect.AddLine(x, y, x, y);
            }
            if (TR)
            {
                tempRoundRect.AddArc(xw - d, y, d, d, 270, 90);
            }
            else
            {
                tempRoundRect.AddLine(xw, y, xw, y);
            }
            if (BR)
            {
                tempRoundRect.AddArc(xw - d, yh - d, d, d, 0, 90);
            }
            else
            {
                tempRoundRect.AddLine(xw, yh, xw, yh);
            }
            if (BL)
            {
                tempRoundRect.AddArc(x, yh - d, d, d, 90, 90);
            }
            else
            {
                tempRoundRect.AddLine(x, yh, x, yh);
            }

            tempRoundRect.CloseFigure();
            return tempRoundRect;
        }

        
        public static GraphicsPath DrawArrow(int x, int y, bool flip)
        {
            GraphicsPath GP = new GraphicsPath();

            int W = 12;
            int H = 6;

            if (flip)
            {
                GP.AddLine(x + 1, y, x + W + 1, y);
                GP.AddLine(x + W, y, x + H, y + H - 1);
            }
            else
            {
                GP.AddLine(x, y + H, x + W, y + H);
                GP.AddLine(x + W, y + H, x + H, y);
            }

            GP.CloseFigure();
            return GP;
        }

        #endregion

    }

    #region  Mouse States
    internal enum MouseState : byte
    {
        None = 0,
        Over = 1,
        Down = 2,
        Block = 3
    }
    #endregion

    public class FormSkin : ContainerControl
    {
        #region  Variables

        private int W;
        private int H;
        private bool Cap = false;
        private bool _HeaderMaximize = false;
        private Point MousePoint = new Point(0, 0);
        private object MoveHeight = 50;

        #endregion

        #region  Properties

        #region  Colors

        [Category("Colors")]
        public Color HeaderColor
        {
            get
            {
                return _HeaderColor;
            }
            set
            {
                _HeaderColor = value;
            }
        }
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
        public Color BorderColor
        {
            get
            {
                return _BorderColor;
            }
            set
            {
                _BorderColor = value;
            }
        }
        [Category("Colors")]
        public Color FlatColor
        {
            get
            {
                return Helpers._FlatColor;
            }
            set
            {
                Helpers._FlatColor = value;
            }
        }

        #endregion

        #region  Options

        [Category("Options")]
        public bool HeaderMaximize
        {
            get
            {
                return _HeaderMaximize;
            }
            set
            {
                _HeaderMaximize = value;
            }
        }

        #endregion

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left && (new Rectangle(0, 0, Width, Convert.ToInt32(MoveHeight))).Contains(e.Location))
            {
                Cap = true;
                MousePoint = e.Location;
            }
        }

        private void FormSkin_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (HeaderMaximize)
            {
                if (e.Button == MouseButtons.Left && (new Rectangle(0, 0, Width, Convert.ToInt32(MoveHeight))).Contains(e.Location))
                {
                    if (FindForm().WindowState == FormWindowState.Normal)
                    {
                        FindForm().WindowState = FormWindowState.Maximized;
                        FindForm().Refresh();
                    }
                    else if (FindForm().WindowState == FormWindowState.Maximized)
                    {
                        FindForm().WindowState = FormWindowState.Normal;
                        FindForm().Refresh();
                    }
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cap = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Cap)
            {
                Parent.Location = new Point(MousePosition.X - MousePoint.X, MousePosition.Y - MousePoint.Y);
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            ParentForm.FormBorderStyle = FormBorderStyle.None;
            ParentForm.AllowTransparency = false;
            ParentForm.TransparencyKey = Color.Fuchsia;
            ParentForm.FindForm().StartPosition = FormStartPosition.CenterScreen;
            Dock = DockStyle.Fill;
            Invalidate();
        }

        #endregion

        #region  Colors

        #region  Dark Colors

        private Color _HeaderColor = Color.FromArgb(50, 50, 50);
        private Color _BaseColor = Color.FromArgb(50, 50, 50);
        private Color _BorderColor = Color.FromArgb(0, 170, 220);
        private Color TextColor = Color.FromArgb(212, 198, 209);

        #endregion

        #region  Light Colors

        private Color _HeaderLight = Color.FromArgb(171, 171, 172);
        private Color _BaseLight = Color.FromArgb(196, 199, 200);
        public Color TextLight = Color.FromArgb(45, 47, 49);

        #endregion

        #endregion

        public FormSkin()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 12);
            SubscribeToEvents();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Helpers.B = new Bitmap(Width, Height);
            Helpers.G = Graphics.FromImage(Helpers.B);
            W = Width;
            H = Height;

            Rectangle Base = new Rectangle(0, 0, W, H);
            Rectangle Header = new Rectangle(0, 0, W, 50);

            Helpers.G.SmoothingMode = (System.Drawing.Drawing2D.SmoothingMode)2;
            Helpers.G.PixelOffsetMode = (System.Drawing.Drawing2D.PixelOffsetMode)2;
            Helpers.G.TextRenderingHint = (System.Drawing.Text.TextRenderingHint)5;
            Helpers.G.Clear(BackColor);

            //-- Base
            Helpers.G.FillRectangle(new SolidBrush(_BaseColor), Base);

            //-- Header
            Helpers.G.FillRectangle(new SolidBrush(_HeaderColor), Header);

            //-- Logo
            Helpers.G.FillRectangle(new SolidBrush(Color.FromArgb(243, 243, 243)), new Rectangle(8, 16, 4, 18));
            Helpers.G.FillRectangle(new SolidBrush(Color.FromArgb(0, 170, 220)), 16, 16, 4, 18);
            Helpers.G.DrawString(Text, Font, new SolidBrush(TextColor), new Rectangle(26, 15, W, H), Helpers.NearSF);

            //-- Border
            Helpers.G.DrawRectangle(new Pen(_BorderColor), Base);

            base.OnPaint(e);
            Helpers.G.Dispose();
            e.Graphics.InterpolationMode = (System.Drawing.Drawing2D.InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(Helpers.B, 0, 0);
            Helpers.B.Dispose();
        }

        private bool EventsSubscribed = false;
        private void SubscribeToEvents()
        {
            if (EventsSubscribed)
                return;
            else
                EventsSubscribed = true;

            this.MouseDoubleClick += FormSkin_MouseDoubleClick;
        }

    }
    

}



