// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Facebook Theme.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Text;

namespace Zeroit.Framework.Form.UIThemes.Facebook
{

    
    static class DrawHelpers
    {

        #region "Functions"

        static int Height;

        static int Width;
        public static GraphicsPath RoundRec(Rectangle Rectangle, int Curve)
        {
            GraphicsPath P = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return P;
        }

        public static GraphicsPath RoundRect(dynamic x, dynamic y, dynamic w, dynamic h, dynamic r, bool TL = true, bool TR = true, bool BR = true, bool BL = true)
        {
            r = 0.3;

            GraphicsPath functionReturnValue = default(GraphicsPath);
            dynamic d = Math.Min(w, h) * r;
            dynamic xw = x + w;
            dynamic yh = y + h;
            functionReturnValue = new GraphicsPath();

            var _with1 = functionReturnValue;
            if (TL)
                _with1.AddArc(x, y, d, d, 180, 90);
            else
                _with1.AddLine(x, y, x, y);
            if (TR)
                _with1.AddArc(xw - d, y, d, d, 270, 90);
            else
                _with1.AddLine(xw, y, xw, y);
            if (BR)
                _with1.AddArc(xw - d, yh - d, d, d, 0, 90);
            else
                _with1.AddLine(xw, yh, xw, yh);
            if (BL)
                _with1.AddArc(x, yh - d, d, d, 90, 90);
            else
                _with1.AddLine(x, yh, x, yh);

            _with1.CloseFigure();
            return functionReturnValue;
        }

        public enum MouseState : byte
        {
            None = 0,
            Over = 1,
            Down = 2,
            Block = 3
        }

        #endregion

    }

    public class FacebookThemeContainer : ContainerControl
    {

        #region "Declarations"
        private Color _MainColour = Color.FromArgb(252, 252, 252);
        private Color _HeaderColour = Color.FromArgb(67, 96, 156);
        private Color _BorderColour = Color.DarkGray;
        private SolidBrush _MainBrushColour;
        private SolidBrush _HeaderBrushColour;
        private Font F = new Font("Tahoma", 13, FontStyle.Bold);


        private bool Cap = false;
        private int MoveHeight = 45;
        #endregion
        private Point MouseP = new Point(0, 0);

        #region "Mouse States"
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left & new Rectangle(0, 0, Width, MoveHeight).Contains(e.Location))
            {
                Cap = true;
                MouseP = e.Location;
            }
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cap = false;
        }
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Cap)
            {
                Parent.Location = new Point(MousePosition.X - MouseP.X, MousePosition.Y - MouseP.Y);
            }
        }
        #endregion

        #region "Colour Properties"
        [Category("Colours")]
        public Color BaseColour
        {
            get { return _MainColour; }
            set { _MainColour = value; }
        }

        [Category("Colours")]
        public Color HeaderColour
        {
            get { return _HeaderColour; }
            set { _HeaderColour = value; }
        }

        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }

        #endregion

        #region "Draw Control"

        public FacebookThemeContainer()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);

            this.DoubleBuffered = true;
            this.BackColor = _MainColour;
            this.Dock = DockStyle.Fill;
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

        protected override void OnPaint(PaintEventArgs e)
        {
            _MainBrushColour = new SolidBrush(_MainColour);
            _HeaderBrushColour = new SolidBrush(_HeaderColour);

            Graphics G = default(Graphics);
            G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.FillRectangle(_HeaderBrushColour, new Rectangle(-1, -1, this.Width + 1, 45));
            G.DrawLine(new Pen(new SolidBrush(_BorderColour)), new Point(-1, 45), new Point(this.Width - 1, 45));
            G.DrawRectangle(new Pen(new SolidBrush(_BorderColour)), new Rectangle(0, 0, Width - 1, Height - 1));
            Bitmap I = this.ParentForm.Icon.ToBitmap();
            Image IM = I;
            string FormText = this.ParentForm.Text;
            G.TextRenderingHint = TextRenderingHint.AntiAlias;
            G.DrawString(FormText, F, new SolidBrush(Color.FromArgb(220, 220, 220)), new Point(43, 11));
            G.DrawImage(IM, new Rectangle(8, 6, 32, 32));
            base.OnPaint(e);
            I.Dispose();
            IM.Dispose();
        }
        
        
        #endregion

    }

    
}

