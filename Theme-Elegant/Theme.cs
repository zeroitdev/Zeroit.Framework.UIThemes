// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Theme.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;
using static Zeroit.Framework.UIThemes.Elegant.DrawHelpers;

namespace Zeroit.Framework.UIThemes.Elegant
{

    
    static class DrawHelpers
    {

        #region "Functions"

        public static GraphicsPath RoundRectangle(Rectangle Rectangle, int Curve)
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

    [ToolboxItem(false)]
    public class ElegantThemeContainer : ContainerControl
    {

        #region "Declarations"

        private int _FontSize = 12;
        private MouseState State = MouseState.None;
        private int MouseXLoc;
        private int MouseYLoc;
        private bool CaptureMovement = false;
        private int MoveHeight = 26;
        private Point MouseP = new Point(0, 0);
        private Color _ControlBoxColour = Color.FromArgb(123, 150, 106);
        private Color _ControlBaseColour = Color.FromArgb(247, 249, 248);
        private Color _TopStripBorderColour = Color.FromArgb(183, 210, 166);
        private Color _TopStripColour = Color.FromArgb(240, 242, 241);
        private Color _BaseColour = Color.FromArgb(250, 250, 250);
        private Color _BorderColour = Color.FromArgb(10, 10, 10);
        private Color _ControlBoxButtonSplitColour = Color.FromArgb(210, 210, 210);
        private Color _IconColour = Color.FromArgb(90, 90, 90);
        private bool _AllowClose = true;
        private bool _AllowMinimize = true;
        private bool _AllowMaximize = true;

        private Font _Font;
        #endregion

        #region "Properties & Events"

        [Category("Colours")]
        public Color IconColour
        {
            get { return _IconColour; }
            set { _IconColour = value; }
        }
        [Category("Colours")]
        public Color ControlBoxButtonSplitColour
        {
            get { return _ControlBoxButtonSplitColour; }
            set { _ControlBoxButtonSplitColour = value; }
        }
        [Category("Colours")]
        public Color ControlBaseColour
        {
            get { return _ControlBaseColour; }
            set { _ControlBaseColour = value; }
        }
        [Category("Colours")]
        public Color ControlBoxColour
        {
            get { return _ControlBoxColour; }
            set { _ControlBoxColour = value; }
        }
        [Category("Colours")]
        public Color TopStripBorderColour
        {
            get { return _TopStripBorderColour; }
            set { _TopStripBorderColour = value; }
        }
        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }
        [Category("Colours")]
        public Color TopStripColour
        {
            get { return _TopStripColour; }
            set { _TopStripColour = value; }
        }
        [Category("Colours")]
        public Color BaseColour
        {
            get { return _BaseColour; }
            set { _BaseColour = value; }
        }
        public bool AllowClose
        {
            get { return _AllowClose; }
            set { _AllowClose = value; }
        }
        public bool AllowMinimize
        {
            get { return _AllowMinimize; }
            set { _AllowMinimize = value; }
        }
        public bool AllowMaximize
        {
            get { return _AllowMaximize; }
            set { _AllowMaximize = value; }
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            CaptureMovement = false;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            MouseXLoc = e.Location.X;
            MouseYLoc = e.Location.Y;
            Invalidate();
            if (CaptureMovement)
            {
                Parent.Location = new Point(MousePosition.X - MouseP.X, MousePosition.Y - MouseP.Y);
            }
            if (e.X < Width - 90 && e.Y > 28)
                Cursor = Cursors.Arrow;
            else
                Cursor = Cursors.Hand;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (MouseXLoc > Width - 26 && MouseYLoc < 25)
            {
                if (_AllowClose)
                {
                    Environment.Exit(0);
                }
            }
            else if (MouseXLoc > Width - 56 && MouseXLoc < Width - 26 && MouseYLoc < 25)
            {
                if (_AllowMaximize)
                {
                    switch (Parent.FindForm().WindowState)
                    {
                        case FormWindowState.Maximized:
                            Parent.FindForm().WindowState = FormWindowState.Normal;
                            break;
                        case FormWindowState.Normal:
                            Parent.FindForm().WindowState = FormWindowState.Maximized;
                            break;
                    }
                }
            }
            else if (MouseXLoc > Width - 84 && MouseXLoc < Width - 56 && MouseYLoc < 25)
            {
                if (_AllowMinimize)
                {
                    switch (Parent.FindForm().WindowState)
                    {
                        case FormWindowState.Normal:
                            Parent.FindForm().WindowState = FormWindowState.Minimized;
                            break;
                        case FormWindowState.Maximized:
                            Parent.FindForm().WindowState = FormWindowState.Minimized;
                            break;
                    }
                }
            }
            else if (e.Button == MouseButtons.Left & new Rectangle(0, 0, Width - 84, MoveHeight).Contains(e.Location))
            {
                CaptureMovement = true;
                MouseP = e.Location;
            }
            else
            {
                Focus();
            }
            Invalidate();
        }

        #endregion

        #region "Draw Control"

        public ElegantThemeContainer()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.BackColor = _BaseColour;
            this.Dock = DockStyle.Fill;

            _Font = new Font("Segoe UI", _FontSize);
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
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G = Graphics.FromImage(B);
            Rectangle Base = new Rectangle(0, 0, Width, Height);
            var _with2 = G;
            Point[] LeftBorderPoints = {
            new Point(0, (int)_with2.MeasureString(Text, _Font).Height + 10),
            new Point((int)_with2.MeasureString(Text, _Font).Width + 3, (int)_with2.MeasureString(Text, _Font).Height + 10),
            new Point((int)_with2.MeasureString(Text, _Font).Width + 16, 0)
        };
            Point[] LeftBorderPoints1 = {
            new Point(0, 0),
            new Point(0, (int)_with2.MeasureString(Text, _Font).Height + 10),
            new Point((int)_with2.MeasureString(Text, _Font).Width + 3, (int)_with2.MeasureString(Text, _Font).Height + 10),
            new Point((int)_with2.MeasureString(Text, _Font).Width + 16, 0)
        };
            Point[] MiddleStripPoints = {
            new Point((int)_with2.MeasureString(Text, _Font).Width + 4, (int)_with2.MeasureString(Text, _Font).Height + 3),
            new Point((int)_with2.MeasureString(Text, _Font).Width + 16, 0),
            new Point(Width - 84, 0),
            new Point(Width - 84, (int)_with2.MeasureString(Text, _Font).Height + 3)
        };
            _with2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with2.SmoothingMode = SmoothingMode.HighQuality;
            _with2.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with2.FillRectangle(new SolidBrush(_BaseColour), new Rectangle(0, 0, Width, Height));
            _with2.FillPolygon(new SolidBrush(_TopStripBorderColour), MiddleStripPoints);
            _with2.FillPolygon(new SolidBrush(_TopStripColour), LeftBorderPoints1);
            _with2.FillRectangle(new SolidBrush(_ControlBaseColour), Width - 84, 0, Width, 25);
            _with2.DrawLine(new Pen(_IconColour, 2), Width - 19, 7, Width - 7, 19);
            _with2.DrawLine(new Pen(_IconColour, 2), Width - 19, 19, Width - 7, 7);
            _with2.DrawLine(new Pen(_IconColour, 2), Width - 76, 18, Width - 64, 18);
            _with2.DrawLine(new Pen(_IconColour, 2), Width - 48, 19, Width - 48, 6);
            _with2.DrawLine(new Pen(_IconColour, 2), Width - 48, 19, Width - 34, 19);
            _with2.DrawLine(new Pen(_IconColour, 4), Width - 48, 8, Width - 34, 8);
            _with2.DrawLine(new Pen(_IconColour, 2), Width - 34, 6, Width - 34, 19);
            _with2.DrawLine(new Pen(_ControlBoxColour), Width, 25, Width - 84, 25);
            _with2.DrawLine(new Pen(_TopStripBorderColour), Width - 84, 25, Width - 84, 0);
            _with2.DrawLine(new Pen(_ControlBoxButtonSplitColour), Width - 56, 25, Width - 56, 0);
            _with2.DrawLine(new Pen(_ControlBoxButtonSplitColour), Width - 26, 25, Width - 26, 0);
            _with2.DrawLines(new Pen(_TopStripBorderColour, 2), LeftBorderPoints);
            _with2.DrawRectangle(new Pen(_BorderColour), new Rectangle(0, 0, Width, Height));
            _with2.DrawString(Text, _Font, new SolidBrush(Color.FromArgb(120, 120, 120)), new Point(5, 5));
            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }

        #endregion

    }

    public class ElegantThemeColourTable : ProfessionalColorTable
    {

        #region "Declarations"

        private Color _BackColour = Color.FromArgb(220, 220, 220);
        private Color _BorderColour = Color.FromArgb(183, 210, 166);

        private Color _SelectedColour = Color.FromArgb(230, 230, 230);
        #endregion

        #region "Properties"

        [Category("Colours")]
        public Color SelectedColour
        {
            get { return _SelectedColour; }
            set { _SelectedColour = value; }
        }

        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }

        [Category("Colours")]
        public Color BackColour
        {
            get { return _BackColour; }
            set { _BackColour = value; }
        }

        public override Color ButtonSelectedBorder
        {
            get { return _BackColour; }
        }

        public override Color CheckBackground
        {
            get { return _BackColour; }
        }

        public override Color CheckPressedBackground
        {
            get { return _BackColour; }
        }

        public override Color CheckSelectedBackground
        {
            get { return _BackColour; }
        }

        public override Color ImageMarginGradientBegin
        {
            get { return _BackColour; }
        }

        public override Color ImageMarginGradientEnd
        {
            get { return _BackColour; }
        }

        public override Color ImageMarginGradientMiddle
        {
            get { return _BackColour; }
        }

        public override Color MenuBorder
        {
            get { return _BorderColour; }
        }

        public override Color MenuItemBorder
        {
            get { return _BackColour; }
        }

        public override Color MenuItemSelected
        {
            get { return _SelectedColour; }
        }

        public override Color SeparatorDark
        {
            get { return _BorderColour; }
        }

        public override Color ToolStripDropDownBackground
        {
            get { return _BackColour; }
        }

        #endregion

    }
        
    
}


