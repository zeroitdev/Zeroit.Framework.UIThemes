// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-19-2019
// ***********************************************************************
// <copyright file="Elegant Theme.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.Form.UIThemes.Elegant
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

    #region Duplicate
    //public class ElegantThemeTextBox : Control
    //{

    //    #region "Declarations"
    //    private Color _BaseColour = Color.FromArgb(255, 255, 255);
    //    private Color _BorderColour = Color.FromArgb(163, 190, 146);
    //    private Color _LineColour = Color.FromArgb(221, 221, 221);
    //    private Color _TextColour = Color.FromArgb(163, 163, 163);
    //    private Color _LeftPolygonColour = Color.FromArgb(248, 250, 249);
    //    private TextBox TB;
    //    private HorizontalAlignment _TextAlign = HorizontalAlignment.Left;
    //    private int _MaxLength = 32767;
    //    private bool _ReadOnly;
    //    private bool _UseSystemPasswordChar;
    //    private bool _Multiline;
    //    private MouseState State = MouseState.None;
    //    #endregion
    //    private Pictures _Pictures = Pictures.Username;

    //    #region "Properties & Events"

    //    public void SelectAll()
    //    {
    //        TB.Focus();
    //        TB.SelectAll();
    //        Invalidate();
    //    }

    //    [Category("Control")]
    //    public Color BaseColour
    //    {
    //        get { return _BaseColour; }
    //        set { _BaseColour = value; }
    //    }

    //    [Category("Control")]
    //    public Color BorderColour
    //    {
    //        get { return _BorderColour; }
    //        set { _BorderColour = value; }
    //    }

    //    [Category("Control")]
    //    public Color LineColour
    //    {
    //        get { return _LineColour; }
    //        set { _LineColour = value; }
    //    }

    //    [Category("Control")]
    //    public Color TextColour
    //    {
    //        get { return _TextColour; }
    //        set { _TextColour = value; }
    //    }

    //    [Category("Control")]
    //    public Color LeftPolygonColour
    //    {
    //        get { return _LeftPolygonColour; }
    //        set { _LeftPolygonColour = value; }
    //    }

    //    public Pictures Picture
    //    {
    //        get { return _Pictures; }
    //        set { _Pictures = value; }
    //    }

    //    [Category("Control")]
    //    public enum Pictures
    //    {
    //        Username,
    //        Password,
    //        None
    //    }

    //    [Category("Control")]
    //    public HorizontalAlignment TextAlign
    //    {
    //        get { return _TextAlign; }
    //        set
    //        {
    //            _TextAlign = value;
    //            if (TB != null)
    //            {
    //                TB.TextAlign = value;
    //            }
    //        }
    //    }

    //    [Category("Control")]
    //    public int MaxLength
    //    {
    //        get { return _MaxLength; }
    //        set
    //        {
    //            _MaxLength = value;
    //            if (TB != null)
    //            {
    //                TB.MaxLength = value;
    //            }
    //        }
    //    }

    //    [Category("Control")]
    //    public bool ReadOnly
    //    {
    //        get { return _ReadOnly; }
    //        set
    //        {
    //            _ReadOnly = value;
    //            if (TB != null)
    //            {
    //                TB.ReadOnly = value;
    //            }
    //        }
    //    }

    //    [Category("Control")]
    //    public bool UseSystemPasswordChar
    //    {
    //        get { return _UseSystemPasswordChar; }
    //        set
    //        {
    //            _UseSystemPasswordChar = value;
    //            if (TB != null)
    //            {
    //                TB.UseSystemPasswordChar = value;
    //            }
    //        }
    //    }

    //    [Category("Control")]
    //    public bool Multiline
    //    {
    //        get { return _Multiline; }
    //        set
    //        {
    //            _Multiline = value;
    //            if (TB != null)
    //            {
    //                TB.Multiline = value;

    //                if (value)
    //                {
    //                    TB.Height = Height - 11;
    //                }
    //                else
    //                {
    //                    Height = TB.Height + 11;
    //                }

    //            }
    //        }
    //    }

    //    [Category("Control")]
    //    public override string Text
    //    {
    //        get { return base.Text; }
    //        set
    //        {
    //            base.Text = value;
    //            if (TB != null)
    //            {
    //                TB.Text = value;
    //            }
    //        }
    //    }

    //    [Category("Control")]
    //    public override Font Font
    //    {
    //        get { return base.Font; }
    //        set
    //        {
    //            base.Font = value;
    //            if (TB != null)
    //            {
    //                TB.Font = value;
    //                TB.Location = new Point(3, 5);
    //                TB.Width = Width - 6;

    //                if (!_Multiline)
    //                {
    //                    Height = TB.Height + 11;
    //                }
    //            }
    //        }
    //    }

    //    protected override void OnCreateControl()
    //    {
    //        base.OnCreateControl();
    //        if (!Controls.Contains(TB))
    //        {
    //            Controls.Add(TB);
    //        }
    //    }

    //    private void OnBaseTextChanged(object s, EventArgs e)
    //    {
    //        Text = TB.Text;
    //    }

    //    private void OnBaseKeyDown(object s, KeyEventArgs e)
    //    {
    //        if (e.Control && e.KeyCode == Keys.A)
    //        {
    //            TB.SelectAll();
    //            e.SuppressKeyPress = true;
    //        }
    //        if (e.Control && e.KeyCode == Keys.C)
    //        {
    //            TB.Copy();
    //            e.SuppressKeyPress = true;
    //        }
    //    }

    //    protected override void OnResize(EventArgs e)
    //    {
    //        if (_Pictures == Pictures.Password | _Pictures == Pictures.Username)
    //        {
    //            TB.Location = new Point(40, 6);
    //            TB.Width = Width - 45;
    //        }
    //        else
    //        {
    //            TB.Location = new Point(5, 6);
    //            TB.Width = Width - 10;
    //        }
    //        if (_Multiline)
    //        {
    //            TB.Height = Height - 11;
    //        }
    //        else
    //        {
    //            Height = TB.Height + 11;
    //        }
    //        base.OnResize(e);
    //    }

    //    #endregion

    //    #region "Mouse States"

    //    protected override void OnMouseDown(MouseEventArgs e)
    //    {
    //        base.OnMouseDown(e);
    //        State = MouseState.Down;
    //        Invalidate();
    //    }
    //    protected override void OnMouseUp(MouseEventArgs e)
    //    {
    //        base.OnMouseUp(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseLeave(EventArgs e)
    //    {
    //        base.OnMouseLeave(e);
    //        State = MouseState.None;
    //        Invalidate();
    //    }

    //    #endregion

    //    #region "Draw Control"

    //    public ElegantThemeTextBox()
    //    {
    //        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
    //        DoubleBuffered = true;
    //        BackColor = Color.Transparent;
    //        TB = new TextBox();
    //        TB.Height = 190;
    //        TB.Font = new Font("Segoe UI", 9);
    //        TB.Text = Text;
    //        TB.BackColor = _BaseColour;
    //        TB.ForeColor = _TextColour;
    //        TB.MaxLength = _MaxLength;
    //        TB.Multiline = false;
    //        TB.ReadOnly = _ReadOnly;
    //        TB.UseSystemPasswordChar = _UseSystemPasswordChar;
    //        TB.BorderStyle = BorderStyle.None;
    //        TB.Location = new Point(40, 6);
    //        TB.Width = Width - 45;
    //        TB.TextChanged += OnBaseTextChanged;
    //        TB.KeyDown += OnBaseKeyDown;
    //    }

    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = e.Graphics;
    //        G = Graphics.FromImage(B);
    //        GraphicsPath GP = default(GraphicsPath);
    //        Rectangle Base = new Rectangle(0, 0, Width, Height);
    //        var _with3 = G;
    //        _with3.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
    //        _with3.SmoothingMode = SmoothingMode.HighQuality;
    //        _with3.PixelOffsetMode = PixelOffsetMode.HighQuality;
    //        _with3.Clear(BackColor);
    //        Point[] P = {
    //        new Point(0, 0),
    //        new Point(28, 0),
    //        new Point(28, Height / 2 - 6),
    //        new Point(34, Height / 2),
    //        new Point(28, Height / 2 + 6),
    //        new Point(28, Height),
    //        new Point(0, Height)
    //    };
    //        Point[] P1 = {
    //        new Point(28, 0),
    //        new Point(28, Height / 2 - 6),
    //        new Point(34, Height / 2),
    //        new Point(28, Height / 2 + 6),
    //        new Point(28, Height)
    //    };
    //        GP = DrawHelpers.RoundRectangle(Base, 1);
    //        if (_Pictures == Pictures.Username)
    //        {
    //            TB.Location = new Point(40, 6);
    //            TB.Width = Width - 45;
    //            _with3.FillPath(new SolidBrush(_BaseColour), GP);
    //            _with3.FillPolygon(new SolidBrush(_LeftPolygonColour), P);
    //            _with3.DrawLines(new Pen(_LineColour, 1), P1);
    //            _with3.DrawPath(new Pen((_BorderColour), 2), GP);
    //            _with3.FillEllipse(new SolidBrush(_TextColour), new Rectangle(10, 5, 8, 10));
    //            Point[] P2 = {
    //            new Point(5, 22),
    //            new Point(9, 17)
    //        };
    //            Point[] SecondLine = {
    //            new Point(19, 17),
    //            new Point(23, 22)
    //        };
    //            _with3.DrawLines(new Pen(_TextColour), P2);
    //            _with3.DrawLines(new Pen(_TextColour), SecondLine);
    //            PointF[] CurvePoints = {
    //            new Point(9, 17),
    //            new Point(14, 19),
    //            new Point(19, 17)
    //        };
    //            _with3.DrawCurve(new Pen(_TextColour), CurvePoints);
    //        }
    //        else if (_Pictures == Pictures.Password)
    //        {
    //            TB.Location = new Point(40, 6);
    //            TB.Width = Width - 45;
    //            _with3.FillPath(new SolidBrush(_BaseColour), GP);
    //            _with3.FillPolygon(new SolidBrush(_LeftPolygonColour), P);
    //            _with3.DrawLines(new Pen(_LineColour, 1), P1);
    //            _with3.DrawPath(new Pen((_BorderColour), 2), GP);
    //            _with3.FillEllipse(new SolidBrush(_TextColour), new Rectangle(14, 5, 9, 9));
    //            _with3.FillEllipse(new SolidBrush(_LeftPolygonColour), new Rectangle(18, 7, 3, 3));
    //            Point[] BaseKey = {
    //            new Point(18, 7),
    //            new Point(6, 18),
    //            new Point(6, 21),
    //            new Point(9, 21),
    //            new Point(9, 18),
    //            new Point(11, 19),
    //            new Point(10, 18),
    //            new Point(12, 18),
    //            new Point(11, 17),
    //            new Point(13, 17),
    //            new Point(12, 16),
    //            new Point(14, 16),
    //            new Point(13, 15),
    //            new Point(15, 15),
    //            new Point(15, 14),
    //            new Point(16, 14),
    //            new Point(15, 13)
    //        };
    //            _with3.DrawLines(new Pen(_TextColour), BaseKey);
    //        }
    //        else
    //        {
    //            _with3.FillPath(new SolidBrush(_BaseColour), GP);
    //            _with3.DrawPath(new Pen((_BorderColour), 2), GP);
    //            TB.Location = new Point(5, 6);
    //            TB.Width = Width - 10;
    //        }
    //        base.OnPaint(e);
    //        G.Dispose();
    //        e.Graphics.InterpolationMode = (InterpolationMode)7;
    //        e.Graphics.DrawImageUnscaled(B, 0, 0);
    //        B.Dispose();
    //    }

    //    #endregion

    //}

    //public class ElegantThemeButton : Control
    //{

    //    #region "Declarations"
    //    private MouseState State = MouseState.None;
    //    private Font _Font = new Font("Segoe UI", 9);
    //    private Color _BaseColour = Color.FromArgb(245, 245, 245);
    //    private Color _TextColour = Color.FromArgb(163, 163, 163);
    //    private Color _PressedTextColour = Color.FromArgb(42, 42, 42);
    //    #endregion
    //    private Color _BorderColour = Color.FromArgb(163, 190, 146);

    //    #region "Properties"

    //    [Category("Colours")]
    //    public Color BaseColour
    //    {
    //        get { return _BaseColour; }
    //        set { _BaseColour = value; }
    //    }
    //    [Category("Colours")]
    //    public Color TextColour
    //    {
    //        get { return _TextColour; }
    //        set { _TextColour = value; }
    //    }
    //    [Category("Colours")]
    //    public Color PressedTextColour
    //    {
    //        get { return _PressedTextColour; }
    //        set { _PressedTextColour = value; }
    //    }
    //    [Category("Colours")]
    //    public Color BorderColour
    //    {
    //        get { return _BorderColour; }
    //        set { _BorderColour = value; }
    //    }
    //    public override Font Font
    //    {
    //        get { return _Font; }
    //        set { _Font = value; }
    //    }

    //    #endregion

    //    #region "Mouse States"

    //    protected override void OnMouseDown(MouseEventArgs e)
    //    {
    //        base.OnMouseDown(e);
    //        State = MouseState.Down;
    //        Invalidate();
    //    }
    //    protected override void OnMouseUp(MouseEventArgs e)
    //    {
    //        base.OnMouseUp(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseEnter(EventArgs e)
    //    {
    //        base.OnMouseEnter(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseLeave(EventArgs e)
    //    {
    //        base.OnMouseLeave(e);
    //        State = MouseState.None;
    //        Invalidate();
    //    }

    //    #endregion

    //    #region "Draw Control"

    //    public ElegantThemeButton()
    //    {
    //        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
    //        DoubleBuffered = true;
    //        Size = new Size(75, 30);
    //        BackColor = Color.Transparent;
    //    }

    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = e.Graphics;
    //        G = Graphics.FromImage(B);
    //        GraphicsPath GP = default(GraphicsPath);
    //        GraphicsPath GP1 = new GraphicsPath();
    //        var _with4 = G;
    //        _with4.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
    //        _with4.SmoothingMode = SmoothingMode.HighQuality;
    //        _with4.PixelOffsetMode = PixelOffsetMode.HighQuality;
    //        _with4.Clear(BackColor);
    //        switch (State)
    //        {
    //            case MouseState.None:
    //                _with4.FillRectangle(new SolidBrush(_BaseColour), new Rectangle(0, 0, Width, Height));
    //                _with4.DrawRectangle(new Pen(_BorderColour, 1), new Rectangle(0, 0, Width, Height));
    //                _with4.DrawString(Text, _Font, new SolidBrush(_TextColour), new Rectangle(0, 0, Width, Height), new StringFormat
    //                {
    //                    Alignment = StringAlignment.Center,
    //                    LineAlignment = StringAlignment.Center
    //                });
    //                break;
    //            case MouseState.Over:
    //                _with4.FillRectangle(new SolidBrush(_BaseColour), new Rectangle(0, 0, Width, Height));
    //                _with4.DrawRectangle(new Pen(_BorderColour, 2), new Rectangle(0, 0, Width, Height));
    //                _with4.DrawString(Text, _Font, new SolidBrush(_TextColour), new Rectangle(0, 0, Width, Height), new StringFormat
    //                {
    //                    Alignment = StringAlignment.Center,
    //                    LineAlignment = StringAlignment.Center
    //                });
    //                break;
    //            case MouseState.Down:
    //                _with4.FillRectangle(new SolidBrush(_BaseColour), new Rectangle(0, 0, Width, Height));
    //                _with4.DrawRectangle(new Pen(_BorderColour, 2), new Rectangle(0, 0, Width, Height));
    //                _with4.DrawString(Text, _Font, new SolidBrush(_PressedTextColour), new Rectangle(0, 0, Width, Height), new StringFormat
    //                {
    //                    Alignment = StringAlignment.Center,
    //                    LineAlignment = StringAlignment.Center
    //                });
    //                break;
    //        }
    //        base.OnPaint(e);
    //        e.Graphics.InterpolationMode = (InterpolationMode)7;
    //        e.Graphics.DrawImageUnscaled(B, 0, 0);
    //        B.Dispose();
    //    }

    //    #endregion

    //}

    //public class ElegantThemeSeperator : Control
    //{

    //    #region "Declarations"
    //    private Color _SeperatorColour = Color.FromArgb(163, 190, 146);
    //    private int _FontSize = 11;
    //    private Font _Font;
    //    private Color _TextColour = Color.FromArgb(163, 163, 163);
    //    private Style _Alignment = Style.Horizontal;
    //    private float _Thickness = 1;
    //    #endregion
    //    private bool _ShowText = true;

    //    #region "Properties"

    //    public enum Style
    //    {
    //        Horizontal,
    //        Verticle
    //    }

    //    [Category("Control")]
    //    public float Thickness
    //    {
    //        get { return _Thickness; }
    //        set { _Thickness = value; }
    //    }

    //    [Category("Control")]
    //    public Style Alignment
    //    {
    //        get { return _Alignment; }
    //        set { _Alignment = value; }
    //    }

    //    [Category("Colours")]
    //    public Color SeperatorColour
    //    {
    //        get { return _SeperatorColour; }
    //        set { _SeperatorColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color TextColour
    //    {
    //        get { return _TextColour; }
    //        set { _TextColour = value; }
    //    }

    //    [Category("Control")]
    //    public bool ShowText
    //    {
    //        get { return _ShowText; }
    //        set { _ShowText = value; }
    //    }

    //    #endregion

    //    #region "Draw Control"

    //    public ElegantThemeSeperator()
    //    {
    //        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
    //        DoubleBuffered = true;
    //        BackColor = Color.Transparent;
    //        Size = new Size(20, 40);

    //        _Font = new Font("Tahoma", _FontSize);
    //    }

    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = e.Graphics;
    //        G = Graphics.FromImage(B);
    //        Rectangle Base = new Rectangle(0, 0, Width - 1, Height - 1);
    //        var _with5 = G;
    //        _with5.SmoothingMode = SmoothingMode.HighQuality;
    //        _with5.PixelOffsetMode = PixelOffsetMode.HighQuality;
    //        _with5.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
    //        _with5.Clear(Color.FromArgb(250, 250, 250));
    //        switch (_Alignment)
    //        {
    //            case Style.Horizontal:
    //                if (_ShowText == true)
    //                {
    //                    _with5.DrawString(Text, _Font, new SolidBrush(_TextColour), 0, Height / 2 - _FontSize + 1);
    //                    _with5.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point((int)_with5.MeasureString(Text, _Font).Width + 2, Height / 2), new Point(Width, Height / 2));
    //                }
    //                else
    //                {
    //                    _with5.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point(0, Height / 2), new Point(Width, Height / 2));
    //                }
    //                break;
    //            case Style.Verticle:
    //                _with5.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point(Width / 2, 0), new Point(Width / 2, Height));
    //                break;
    //        }
    //        base.OnPaint(e);
    //        G.Dispose();
    //        e.Graphics.InterpolationMode = (InterpolationMode)7;
    //        e.Graphics.DrawImageUnscaled(B, 0, 0);
    //        B.Dispose();
    //    }

    //    #endregion

    //}

    //[DefaultEvent("CheckedChanged")]
    //public class ElegantThemeCheckBox : Control
    //{

    //    #region "Declarations"

    //    private bool _Checked = false;
    //    private MouseState State = MouseState.None;
    //    private Font _Font = new Font("Segoe UI", 9);
    //    private Color _CheckedColour = Color.FromArgb(173, 173, 174);
    //    private Color _BorderColour = Color.FromArgb(193, 210, 176);
    //    private Color _BackColour = Color.Transparent;
    //    private Color _TextColour = Color.FromArgb(163, 163, 163);
    //    private Color _DefaultSqaureColour = Color.FromArgb(230, 230, 230);

    //    private Color _HoverSqaureColour = Color.FromArgb(220, 220, 220);
    //    #endregion

    //    #region "Colour & Other Properties"

    //    [Category("Colours")]
    //    public Color DefaultSqaureColour
    //    {
    //        get { return _DefaultSqaureColour; }
    //        set { _DefaultSqaureColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color HoverSqaureColour
    //    {
    //        get { return _HoverSqaureColour; }
    //        set { _HoverSqaureColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color BaseColour
    //    {
    //        get { return _BackColour; }
    //        set { _BackColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color BorderColour
    //    {
    //        get { return _BorderColour; }
    //        set { _BorderColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color CheckedColour
    //    {
    //        get { return _CheckedColour; }
    //        set { _CheckedColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color FontColour
    //    {
    //        get { return _TextColour; }
    //        set { _TextColour = value; }
    //    }

    //    protected override void OnTextChanged(System.EventArgs e)
    //    {
    //        base.OnTextChanged(e);
    //        Invalidate();
    //    }

    //    public bool Checked
    //    {
    //        get { return _Checked; }
    //        set
    //        {
    //            _Checked = value;
    //            Invalidate();
    //        }
    //    }

    //    public event CheckedChangedEventHandler CheckedChanged;
    //    public delegate void CheckedChangedEventHandler(object sender);
    //    protected override void OnClick(System.EventArgs e)
    //    {
    //        _Checked = !_Checked;
    //        if (CheckedChanged != null)
    //        {
    //            CheckedChanged(this);
    //        }
    //        base.OnClick(e);
    //    }

    //    protected override void OnResize(EventArgs e)
    //    {
    //        base.OnResize(e);
    //        Height = 22;
    //    }

    //    #endregion

    //    #region "Mouse States"

    //    protected override void OnMouseDown(MouseEventArgs e)
    //    {
    //        base.OnMouseDown(e);
    //        State = MouseState.Down;
    //        Invalidate();
    //    }
    //    protected override void OnMouseUp(MouseEventArgs e)
    //    {
    //        base.OnMouseUp(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseEnter(EventArgs e)
    //    {
    //        base.OnMouseEnter(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseLeave(EventArgs e)
    //    {
    //        base.OnMouseLeave(e);
    //        State = MouseState.None;
    //        Invalidate();
    //    }

    //    #endregion

    //    #region "Draw Control"

    //    public ElegantThemeCheckBox()
    //    {
    //        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
    //        DoubleBuffered = true;
    //        Cursor = Cursors.Hand;
    //        Size = new Size(100, 22);
    //    }

    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = e.Graphics;
    //        G = Graphics.FromImage(B);
    //        Rectangle Base = new Rectangle(0, 0, 22, 22);
    //        var _with6 = G;
    //        _with6.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
    //        _with6.SmoothingMode = SmoothingMode.HighQuality;
    //        _with6.PixelOffsetMode = PixelOffsetMode.HighQuality;
    //        _with6.Clear(Color.FromArgb(250, 250, 250));
    //        _with6.FillRectangle(new SolidBrush(_BackColour), Base);
    //        _with6.FillRectangle(new SolidBrush(_DefaultSqaureColour), new Rectangle(0, 0, 22, 22));
    //        _with6.DrawRectangle(new Pen(_BorderColour), new Rectangle(1, 1, 22, 20));
    //        switch (State)
    //        {
    //            case MouseState.Over:
    //                if (Checked)
    //                {
    //                    _with6.FillRectangle(new SolidBrush(_HoverSqaureColour), new Rectangle(0, 0, 22, 22));
    //                    _with6.DrawLine(new Pen(_BorderColour, 2), 1, 1, 22, 20);
    //                    _with6.DrawLine(new Pen(_BorderColour, 2), 2, 20, 21, 2);
    //                    _with6.DrawRectangle(new Pen(_BorderColour, 2), new Rectangle(1, 1, 22, 20));
    //                }
    //                else
    //                {
    //                    _with6.FillRectangle(new SolidBrush(_HoverSqaureColour), new Rectangle(0, 0, 22, 22));
    //                    _with6.DrawRectangle(new Pen(_BorderColour), new Rectangle(1, 1, 22, 20));
    //                }
    //                break;
    //        }
    //        if (Checked)
    //        {
    //            _with6.DrawLine(new Pen(_BorderColour, 2), 1, 1, 22, 20);
    //            _with6.DrawLine(new Pen(_BorderColour, 2), 2, 20, 22, 2);
    //            _with6.DrawRectangle(new Pen(_BorderColour, 2), new Rectangle(1, 1, 22, 20));
    //            _with6.FillRectangle(new SolidBrush(_BorderColour), new Rectangle(7, 6, 10, 10));
    //            _with6.DrawString(Text, _Font, new SolidBrush(Color.FromArgb(45, 45, 45)), new Rectangle(27, 0, Width, Height), new StringFormat
    //            {
    //                Alignment = StringAlignment.Near,
    //                LineAlignment = StringAlignment.Center
    //            });
    //        }
    //        else
    //        {
    //            _with6.DrawString(Text, _Font, new SolidBrush(_TextColour), new Rectangle(27, 0, Width, Height), new StringFormat
    //            {
    //                Alignment = StringAlignment.Near,
    //                LineAlignment = StringAlignment.Center
    //            });
    //        }
    //        base.OnPaint(e);
    //        G.Dispose();
    //        e.Graphics.InterpolationMode = (InterpolationMode)7;
    //        e.Graphics.DrawImageUnscaled(B, 0, 0);
    //        B.Dispose();
    //    }

    //    #endregion

    //}

    //public class ElegantThemeGroupBox : ContainerControl
    //{

    //    #region "Declarations"
    //    private Color _MainColour = Color.FromArgb(255, 255, 255);
    //    private Color _HeaderColour = Color.FromArgb(248, 250, 249);
    //    private Color _TextColour = Color.FromArgb(163, 163, 163);
    //    #endregion
    //    private Color _BorderColour = Color.FromArgb(163, 190, 146);

    //    #region "Properties"

    //    [Category("Colours")]
    //    public Color BorderColour
    //    {
    //        get { return _BorderColour; }
    //        set { _BorderColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color TextColour
    //    {
    //        get { return _TextColour; }
    //        set { _TextColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color HeaderColour
    //    {
    //        get { return _HeaderColour; }
    //        set { _HeaderColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color MainColour
    //    {
    //        get { return _MainColour; }
    //        set { _MainColour = value; }
    //    }

    //    #endregion

    //    #region "Draw Control"
    //    public ElegantThemeGroupBox()
    //    {
    //        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
    //        DoubleBuffered = true;
    //        Size = new Size(160, 110);
    //        Font = new Font("Segoe UI", 10, FontStyle.Bold);
    //    }

    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = e.Graphics;
    //        G = Graphics.FromImage(B);
    //        Rectangle Base = new Rectangle(0, 0, Width - 1, Height - 1);
    //        Rectangle Circle = new Rectangle(8, 8, 10, 10);
    //        var _with7 = G;
    //        _with7.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
    //        _with7.SmoothingMode = SmoothingMode.HighQuality;
    //        _with7.PixelOffsetMode = PixelOffsetMode.HighQuality;
    //        _with7.Clear(BackColor);
    //        _with7.FillRectangle(new SolidBrush(_MainColour), new Rectangle(0, 28, Width, Height));
    //        _with7.FillRectangle(new SolidBrush(_HeaderColour), new Rectangle(0, 0, Width, 28));
    //        _with7.DrawString(Text, Font, new SolidBrush(_TextColour), new Point(5, 5));
    //        _with7.DrawRectangle(new Pen(_BorderColour), new Rectangle(0, 0, Width, Height));
    //        _with7.DrawLine(new Pen(_BorderColour), 0, 28, Width, 28);
    //        _with7.DrawLine(new Pen(_BorderColour, 3), new Point(0, 27), new Point((int)_with7.MeasureString(Text, Font).Width + 7, 27));
    //        base.OnPaint(e);
    //        G.Dispose();
    //        e.Graphics.InterpolationMode = (InterpolationMode)7;
    //        e.Graphics.DrawImageUnscaled(B, 0, 0);
    //        B.Dispose();
    //    }
    //    #endregion

    //}

    //public class ElegantThemeDropDownSeperator : ContainerControl
    //{

    //    #region "Declaration"

    //    private bool _Checked;
    //    private int X;
    //    private int Y;
    //    private bool Up;
    //    private int SpecifiedHeight;
    //    private int _OpenHeight = 200;
    //    private int _ClosedHeight = 30;
    //    private int _OpenWidth = 160;
    //    private bool _CaptureHeightChange = false;
    //    private Color _SeperatorColour = Color.FromArgb(163, 190, 146);
    //    private int _FontSize = 11;
    //    private Font _Font;
    //    private Color _TextColour = Color.FromArgb(163, 163, 163);
    //    private float _Thickness = 1;

    //    private bool _Animate = false;
    //    #endregion

    //    #region "Properties & Events"

    //    [Category("Colours")]
    //    public Color SeperatorColour
    //    {
    //        get { return _SeperatorColour; }
    //        set { _SeperatorColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color TextColour
    //    {
    //        get { return _TextColour; }
    //        set { _TextColour = value; }
    //    }

    //    public int OpenHeight
    //    {
    //        get { return _OpenHeight; }
    //        set { _OpenHeight = value; }
    //    }

    //    public float Thickness
    //    {
    //        get { return _Thickness; }
    //        set { _Thickness = value; }
    //    }

    //    public bool Animation
    //    {
    //        get { return _Animate; }
    //        set
    //        {
    //            _Animate = value;
    //            Invalidate();
    //        }
    //    }

    //    public bool Checked
    //    {
    //        get { return _Checked; }
    //        set
    //        {
    //            _Checked = value;
    //            Invalidate();
    //        }
    //    }

    //    public bool CaptureHeightChange
    //    {
    //        get { return _CaptureHeightChange; }
    //        set
    //        {
    //            _CaptureHeightChange = value;
    //            Invalidate();
    //        }
    //    }

    //    protected override void OnResize(EventArgs e)
    //    {
    //        if (_CaptureHeightChange == true)
    //        {
    //            _OpenHeight = Height;
    //        }
    //        base.OnResize(e);
    //    }

    //    protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseMove(e);
    //        X = e.X;
    //        Y = e.Y;
    //        Invalidate();
    //    }

    //    public void Animate(bool Closing)
    //    {
    //        switch (Closing)
    //        {
    //            case true:
    //                int HT = _OpenHeight;
    //                while (!(HT == 30))
    //                {
    //                    this.Height -= 1;
    //                    HT -= 1;
    //                }
    //                Up = true;
    //                _Checked = false;
    //                break;
    //            case false:
    //                while (!(this.Height == _OpenHeight))
    //                {
    //                    this.Height += 1;
    //                    Update();
    //                }
    //                Up = false;
    //                _Checked = true;
    //                break;
    //        }
    //    }

    //    public void ChangeCheck(object sender, MouseEventArgs e)
    //    {
    //        if (X >= Width - 22)
    //        {
    //            if (Y <= 30)
    //            {
    //                switch (Checked)
    //                {
    //                    case true:
    //                        if (_Animate)
    //                        {
    //                            Animate(true);
    //                        }
    //                        else
    //                        {
    //                            this.Height = 30;
    //                            Up = true;
    //                            _Checked = false;
    //                        }
    //                        break;
    //                    case false:
    //                        if (_Animate)
    //                        {
    //                            Animate(false);
    //                        }
    //                        else
    //                        {
    //                            this.Height = _OpenHeight;
    //                            Up = false;
    //                            _Checked = true;
    //                        }
    //                        break;
    //                }
    //            }
    //        }
    //    }

    //    #endregion

    //    #region "Draw Control"

    //    public ElegantThemeDropDownSeperator()
    //    {
    //        MouseDown += ChangeCheck;
    //        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
    //        DoubleBuffered = true;
    //        Size = new Size(90, 30);
    //        MinimumSize = new Size(5, 30);
    //        this.Font = new Font("Tahoma", 10);
    //        this.ForeColor = Color.FromArgb(40, 40, 40);
    //        _Checked = true;

    //        _Font = new Font("Tahoma", _FontSize);
    //    }

    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        base.OnPaint(e);
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = e.Graphics;
    //        G = Graphics.FromImage(B);
    //        var _with8 = G;
    //        _with8.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
    //        _with8.SmoothingMode = SmoothingMode.HighQuality;
    //        _with8.PixelOffsetMode = PixelOffsetMode.HighQuality;
    //        if (_Checked == true)
    //        {
    //            _with8.Clear(Color.FromArgb(250, 250, 250));
    //            _with8.DrawString(Text, _Font, new SolidBrush(_TextColour), 13, 30 / 2 - _FontSize + 1);
    //            _with8.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point(0, 30 / 2), new Point(10, 30 / 2));
    //            _with8.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point((int)_with8.MeasureString(Text, _Font).Width + 13, 30 / 2), new Point(Width - 25, 30 / 2));
    //            _with8.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point(Width - 7, 30 / 2), new Point(Width, 30 / 2));
    //            _with8.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point(1, 30 / 2), new Point(1, Height));
    //            _with8.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point(Width - 1, 30 / 2), new Point(Width - 1, Height));
    //            _with8.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point(1, Height - 1), new Point(Width, Height - 1));
    //        }
    //        else
    //        {
    //            _with8.Clear(Color.FromArgb(250, 250, 250));
    //            _with8.DrawString(Text, _Font, new SolidBrush(_TextColour), 13, 30 / 2 - _FontSize + 1);
    //            _with8.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point(0, 30 / 2), new Point(10, 30 / 2));
    //            _with8.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point((int)_with8.MeasureString(Text, _Font).Width + 13, 30 / 2), new Point(Width - 25, 30 / 2));
    //            _with8.DrawLine(new Pen(_SeperatorColour, _Thickness), new Point(Width - 7, 30 / 2), new Point(Width, 30 / 2));
    //        }
    //        switch (_Checked)
    //        {
    //            case false:
    //                _with8.DrawLine(new Pen(Color.DarkGray, 2), new Point(Width - 21, 11), new Point(Width - 16, 19));
    //                _with8.DrawLine(new Pen(Color.DarkGray, 2), new Point(Width - 16, 19), new Point(Width - 11, 11));
    //                break;
    //            case true:
    //                _with8.DrawLine(new Pen(Color.DarkGray, 2), new Point(Width - 21, 19), new Point(Width - 16, 11));
    //                _with8.DrawLine(new Pen(Color.DarkGray, 2), new Point(Width - 16, 11), new Point(Width - 11, 19));
    //                break;
    //        }
    //        base.OnPaint(e);
    //        G.Dispose();
    //        e.Graphics.InterpolationMode = (InterpolationMode)7;
    //        e.Graphics.DrawImageUnscaled(B, 0, 0);
    //        B.Dispose();
    //    }

    //    #endregion

    //}

    //public class ElegantThemeStatusBar : Control
    //{

    //    #region "Variables"
    //    private Color _BaseColour = Color.FromArgb(240, 242, 241);
    //    private Color _BorderColour = Color.FromArgb(183, 210, 166);
    //    private Color _TextColour = Color.FromArgb(120, 120, 120);
    //    private Color _RectColour = Color.FromArgb(21, 117, 149);
    //    private Color _SeperatorColour = Color.FromArgb(110, 110, 110);
    //    private bool _ShowLine = true;
    //    private LinesCount _LinesToShow = LinesCount.One;
    //    private AmountOfStrings _NumberOfStrings = AmountOfStrings.One;
    //    private bool _ShowBorder = true;
    //    private StringFormat _FirstLabelStringFormat;
    //    private string _FirstLabelText = "Label1";
    //    private Alignments _FirstLabelAlignment = Alignments.Center;
    //    private StringFormat _SecondLabelStringFormat;
    //    private string _SecondLabelText = "Label2";
    //    private Alignments _SecondLabelAlignment = Alignments.Center;
    //    private StringFormat _ThirdLabelStringFormat;
    //    private string _ThirdLabelText = "Label3";
    //    #endregion
    //    private Alignments _ThirdLabelAlignment = Alignments.Center;

    //    #region "Properties"

    //    [Category("First Label Options")]
    //    public string FirstLabelText
    //    {
    //        get { return _FirstLabelText; }
    //        set { _FirstLabelText = value; }
    //    }

    //    [Category("First Label Options")]
    //    public Alignments FirstLabelAlignment
    //    {
    //        get { return _FirstLabelAlignment; }
    //        set
    //        {
    //            switch (value)
    //            {
    //                case Alignments.Left:
    //                    _FirstLabelStringFormat = new StringFormat
    //                    {
    //                        Alignment = StringAlignment.Near,
    //                        LineAlignment = StringAlignment.Center
    //                    };
    //                    _FirstLabelAlignment = value;
    //                    break;
    //                case Alignments.Center:
    //                    _FirstLabelStringFormat = new StringFormat
    //                    {
    //                        Alignment = StringAlignment.Center,
    //                        LineAlignment = StringAlignment.Center
    //                    };
    //                    _FirstLabelAlignment = value;
    //                    break;
    //                case Alignments.Right:
    //                    _FirstLabelStringFormat = new StringFormat
    //                    {
    //                        Alignment = StringAlignment.Far,
    //                        LineAlignment = StringAlignment.Center
    //                    };
    //                    _FirstLabelAlignment = value;
    //                    break;
    //            }
    //        }
    //    }

    //    [Category("Second Label Options")]
    //    public string SecondLabelText
    //    {
    //        get { return _SecondLabelText; }
    //        set { _SecondLabelText = value; }
    //    }

    //    [Category("Second Label Options")]
    //    public Alignments SecondLabelAlignment
    //    {
    //        get { return _SecondLabelAlignment; }
    //        set
    //        {
    //            switch (value)
    //            {
    //                case Alignments.Left:
    //                    _SecondLabelStringFormat = new StringFormat
    //                    {
    //                        Alignment = StringAlignment.Near,
    //                        LineAlignment = StringAlignment.Center
    //                    };
    //                    _SecondLabelAlignment = value;
    //                    break;
    //                case Alignments.Center:
    //                    _SecondLabelStringFormat = new StringFormat
    //                    {
    //                        Alignment = StringAlignment.Center,
    //                        LineAlignment = StringAlignment.Center
    //                    };
    //                    _SecondLabelAlignment = value;
    //                    break;
    //                case Alignments.Right:
    //                    _SecondLabelStringFormat = new StringFormat
    //                    {
    //                        Alignment = StringAlignment.Far,
    //                        LineAlignment = StringAlignment.Center
    //                    };
    //                    _SecondLabelAlignment = value;
    //                    break;
    //            }
    //        }
    //    }

    //    [Category("Third Label Options")]
    //    public string ThirdLabelText
    //    {
    //        get { return _ThirdLabelText; }
    //        set { _ThirdLabelText = value; }
    //    }

    //    [Category("Third Label Options")]
    //    public Alignments ThirdLabelAlignment
    //    {
    //        get { return _ThirdLabelAlignment; }
    //        set
    //        {
    //            switch (value)
    //            {
    //                case Alignments.Left:
    //                    _ThirdLabelStringFormat = new StringFormat
    //                    {
    //                        Alignment = StringAlignment.Near,
    //                        LineAlignment = StringAlignment.Center
    //                    };
    //                    _ThirdLabelAlignment = value;
    //                    break;
    //                case Alignments.Center:
    //                    _ThirdLabelStringFormat = new StringFormat
    //                    {
    //                        Alignment = StringAlignment.Center,
    //                        LineAlignment = StringAlignment.Center
    //                    };
    //                    _ThirdLabelAlignment = value;
    //                    break;
    //                case Alignments.Right:
    //                    _ThirdLabelStringFormat = new StringFormat
    //                    {
    //                        Alignment = StringAlignment.Far,
    //                        LineAlignment = StringAlignment.Center
    //                    };
    //                    _ThirdLabelAlignment = value;
    //                    break;
    //            }
    //        }
    //    }

    //    [Category("Colours")]
    //    public Color BaseColour
    //    {
    //        get { return _BaseColour; }
    //        set { _BaseColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color BorderColour
    //    {
    //        get { return _BorderColour; }
    //        set { _BorderColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color TextColour
    //    {
    //        get { return _TextColour; }
    //        set { _TextColour = value; }
    //    }

    //    public enum LinesCount : int
    //    {
    //        None = 0,
    //        One = 1,
    //        Two = 2
    //    }

    //    public enum AmountOfStrings
    //    {
    //        One,
    //        Two,
    //        Three
    //    }

    //    public enum Alignments
    //    {
    //        Left,
    //        Center,
    //        Right
    //    }

    //    [Category("Control")]
    //    public AmountOfStrings AmountOfString
    //    {
    //        get { return _NumberOfStrings; }
    //        set { _NumberOfStrings = value; }
    //    }

    //    [Category("Control")]
    //    public LinesCount LinesToShow
    //    {
    //        get { return _LinesToShow; }
    //        set { _LinesToShow = value; }
    //    }

    //    public bool ShowBorder
    //    {
    //        get { return _ShowBorder; }
    //        set { _ShowBorder = value; }
    //    }

    //    protected override void CreateHandle()
    //    {
    //        base.CreateHandle();
    //        Dock = DockStyle.Bottom;
    //    }

    //    protected override void OnTextChanged(EventArgs e)
    //    {
    //        base.OnTextChanged(e);
    //        Invalidate();
    //    }

    //    [Category("Colours")]
    //    public Color RectangleColor
    //    {
    //        get { return _RectColour; }
    //        set { _RectColour = value; }
    //    }

    //    public bool ShowLine
    //    {
    //        get { return _ShowLine; }
    //        set { _ShowLine = value; }
    //    }

    //    #endregion

    //    #region "Draw Control"

    //    public ElegantThemeStatusBar()
    //    {
    //        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
    //        DoubleBuffered = true;
    //        Font = new Font("Segoe UI", 9);
    //        ForeColor = Color.White;
    //        Size = new Size(Width, 20);
    //    }

    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = e.Graphics;
    //        G = Graphics.FromImage(B);
    //        Rectangle Base = new Rectangle(0, 0, Width, Height);
    //        var _with9 = G;
    //        _with9.SmoothingMode = SmoothingMode.HighQuality;
    //        _with9.PixelOffsetMode = PixelOffsetMode.HighQuality;
    //        _with9.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
    //        _with9.Clear(BaseColour);
    //        _with9.FillRectangle(new SolidBrush(BaseColour), Base);
    //        switch (_LinesToShow)
    //        {
    //            case LinesCount.None:
    //                if (_NumberOfStrings == AmountOfStrings.One)
    //                {
    //                    _with9.DrawString(_FirstLabelText, Font, new SolidBrush(_TextColour), new Rectangle(5, 1, Width - 5, Height), _FirstLabelStringFormat);
    //                }
    //                else if (_NumberOfStrings == AmountOfStrings.Two)
    //                {
    //                    _with9.DrawString(_FirstLabelText, Font, new SolidBrush(_TextColour), new Rectangle(5, 1, (Width / 2 - 6), Height), _FirstLabelStringFormat);
    //                    _with9.DrawString(_SecondLabelText, Font, new SolidBrush(_TextColour), new Rectangle(Width - (Width / 2 + 5), 1, Width / 2 - 4, Height), _SecondLabelStringFormat);
    //                    _with9.DrawLine(new Pen(_SeperatorColour, 1), new Point(Width / 2, 6), new Point(Width / 2, Height - 6));
    //                }
    //                else
    //                {
    //                    _with9.DrawString(_FirstLabelText, Font, new SolidBrush(_TextColour), new Rectangle(5, 1, (Width - (Width / 3) * 2) - 6, Height), _FirstLabelStringFormat);
    //                    _with9.DrawString(_SecondLabelText, Font, new SolidBrush(_TextColour), new Rectangle(Width - (Width / 3) * 2 + 5, 1, Width - (Width / 3) * 2 - 6, Height), _SecondLabelStringFormat);
    //                    _with9.DrawString(_ThirdLabelText, Font, new SolidBrush(_TextColour), new Rectangle(Width - (Width / 3) + 5, 1, Width / 3 - 6, Height), _ThirdLabelStringFormat);
    //                    _with9.DrawLine(new Pen(_SeperatorColour, 1), new Point(Width - (Width / 3) * 2, 6), new Point(Width - (Width / 3) * 2, Height - 6));
    //                    _with9.DrawLine(new Pen(_SeperatorColour, 1), new Point(Width - (Width / 3), 6), new Point(Width - (Width / 3), Height - 6));
    //                }
    //                break;
    //            case LinesCount.One:
    //                if (_NumberOfStrings == AmountOfStrings.One)
    //                {
    //                    _with9.DrawString(_FirstLabelText, Font, new SolidBrush(_TextColour), new Rectangle(22, 1, Width, Height), _FirstLabelStringFormat);
    //                    _with9.FillRectangle(new SolidBrush(_RectColour), new Rectangle(5, 9, 14, 3));
    //                }
    //                else if (_NumberOfStrings == AmountOfStrings.Two)
    //                {
    //                    _with9.DrawString(_FirstLabelText, Font, new SolidBrush(_TextColour), new Rectangle(22, 1, (Width / 2 - 24), Height), _FirstLabelStringFormat);
    //                    _with9.DrawString(_SecondLabelText, Font, new SolidBrush(_TextColour), new Rectangle((Width / 2 + 5), 1, Width / 2 - 10, Height), _SecondLabelStringFormat);
    //                    _with9.DrawLine(new Pen(_SeperatorColour, 1), new Point(Width / 2, 6), new Point(Width / 2, Height - 6));
    //                }
    //                else
    //                {
    //                }
    //                _with9.FillRectangle(new SolidBrush(_SeperatorColour), new Rectangle(5, 10, 14, 3));
    //                break;
    //            case LinesCount.Two:
    //                if (_NumberOfStrings == AmountOfStrings.One)
    //                {
    //                    _with9.DrawString(_FirstLabelText, Font, new SolidBrush(_TextColour), new Rectangle(22, 1, Width - 44, Height), _FirstLabelStringFormat);
    //                }
    //                else if (_NumberOfStrings == AmountOfStrings.Two)
    //                {
    //                    _with9.DrawString(_FirstLabelText, Font, new SolidBrush(_TextColour), new Rectangle(22, 1, (Width - 46) / 2, Height), _FirstLabelStringFormat);
    //                    _with9.DrawString(_SecondLabelText, Font, new SolidBrush(_TextColour), new Rectangle((Width / 2 + 5), 1, Width / 2 - 28, Height), _SecondLabelStringFormat);
    //                    _with9.DrawLine(new Pen(_SeperatorColour, 1), new Point(Width / 2, 6), new Point(Width / 2, Height - 6));
    //                }
    //                else
    //                {
    //                    _with9.DrawString(_FirstLabelText, Font, new SolidBrush(_TextColour), new Rectangle(22, 1, (Width - 78) / 3, Height), _FirstLabelStringFormat);
    //                    _with9.DrawString(_SecondLabelText, Font, new SolidBrush(_TextColour), new Rectangle(Width - (Width / 3) * 2 + 5, 1, Width - (Width / 3) * 2 - 12, Height), _SecondLabelStringFormat);
    //                    _with9.DrawString(_ThirdLabelText, Font, new SolidBrush(_TextColour), new Rectangle(Width - (Width / 3) + 6, 1, Width / 3 - 22, Height), _ThirdLabelStringFormat);
    //                    _with9.DrawLine(new Pen(_SeperatorColour, 1), new Point(Width - (Width / 3) * 2, 6), new Point(Width - (Width / 3) * 2, Height - 6));
    //                    _with9.DrawLine(new Pen(_SeperatorColour, 1), new Point(Width - (Width / 3), 6), new Point(Width - (Width / 3), Height - 6));

    //                }
    //                _with9.FillRectangle(new SolidBrush(_SeperatorColour), new Rectangle(5, 10, 14, 3));
    //                _with9.FillRectangle(new SolidBrush(_SeperatorColour), new Rectangle(Width - 20, 10, 14, 3));
    //                break;
    //        }
    //        if (_ShowBorder)
    //        {
    //            _with9.DrawRectangle(new Pen(_BorderColour, 2), new Rectangle(0, 0, Width, Height));
    //        }
    //        else
    //        {
    //        }
    //        base.OnPaint(e);
    //        G.Dispose();
    //        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
    //        e.Graphics.DrawImageUnscaled(B, 0, 0);
    //        B.Dispose();
    //    }

    //    #endregion

    //}

    //public class ElegantThemeTitledListBox : Control
    //{

    //    #region "Variables"

    //    private ListBox withEventsField_ListB = new ListBox();
    //    private ListBox ListB
    //    {
    //        get { return withEventsField_ListB; }
    //        set
    //        {
    //            if (withEventsField_ListB != null)
    //            {
    //                withEventsField_ListB.DrawItem -= Drawitem;
    //            }
    //            withEventsField_ListB = value;
    //            if (withEventsField_ListB != null)
    //            {
    //                withEventsField_ListB.DrawItem += Drawitem;
    //            }
    //        }
    //    }
    //    private string[] _Items = { "" };
    //    private Color _BaseColour = Color.FromArgb(255, 255, 255);
    //    private Color _SelectedColour = Color.FromArgb(55, 55, 55);
    //    private Color _TextColour = Color.FromArgb(163, 163, 163);
    //    private Color _BorderColour = Color.FromArgb(183, 210, 166);

    //    private Font _TitleFont = new Font("Segeo UI", 10, FontStyle.Bold);
    //    #endregion

    //    #region "Properties"

    //    [Category("Control")]
    //    public Font TitleFont
    //    {
    //        get { return _TitleFont; }
    //        set { _TitleFont = value; }
    //    }

    //    [Category("Control")]
    //    public string[] Items
    //    {
    //        get { return _Items; }
    //        set
    //        {
    //            _Items = value;
    //            ListB.Items.Clear();
    //            ListB.Items.AddRange(value);
    //            Invalidate();
    //        }
    //    }

    //    [Category("Colours")]
    //    public Color BorderColour
    //    {
    //        get { return _BorderColour; }
    //        set { _BorderColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color SelectedColour
    //    {
    //        get { return _SelectedColour; }
    //        set { _SelectedColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color BaseColour
    //    {
    //        get { return _BaseColour; }
    //        set { _BaseColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color TextColour
    //    {
    //        get { return _TextColour; }
    //        set { _TextColour = value; }
    //    }

    //    public string SelectedItem
    //    {
    //        get { return ListB.GetItemText(SelectedItem); }
    //    }

    //    public int SelectedIndex
    //    {
    //        get
    //        {
    //            int functionReturnValue = 0;
    //            return ListB.SelectedIndex;
    //            if (ListB.SelectedIndex < 0)
    //                return functionReturnValue;
    //            return functionReturnValue;
    //        }
    //    }

    //    public void Clear()
    //    {
    //        ListB.Items.Clear();
    //    }

    //    public void ClearSelected()
    //    {
    //        for (int i = (ListB.SelectedItems.Count - 1); i >= 0; i += -1)
    //        {
    //            ListB.Items.Remove(ListB.SelectedItems[i]);
    //        }
    //    }

    //    protected override void OnCreateControl()
    //    {
    //        base.OnCreateControl();
    //        if (!Controls.Contains(ListB))
    //        {
    //            Controls.Add(ListB);
    //        }
    //    }

    //    public void AddRange(object[] items)
    //    {
    //        ListB.Items.Remove("");
    //        ListB.Items.AddRange(items);
    //    }

    //    public void AddItem(object item)
    //    {
    //        ListB.Items.Remove("");
    //        ListB.Items.Add(item);
    //    }

    //    #endregion

    //    #region "Draw Control"

    //    public void Drawitem(object sender, DrawItemEventArgs e)
    //    {
    //        if (e.Index < 0)
    //            return;
    //        e.DrawBackground();
    //        e.DrawFocusRectangle();
    //        var _with10 = e.Graphics;
    //        _with10.SmoothingMode = SmoothingMode.HighQuality;
    //        _with10.PixelOffsetMode = PixelOffsetMode.HighQuality;
    //        _with10.InterpolationMode = InterpolationMode.HighQualityBicubic;
    //        _with10.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
    //        if (String.Compare(e.State.ToString(), "Selected,") > 0)
    //        {
    //            _with10.FillRectangle(new SolidBrush(_BaseColour), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
    //            _with10.DrawLine(new Pen(_BorderColour), e.Bounds.X, e.Bounds.Y + e.Bounds.Height, e.Bounds.Width, e.Bounds.Y + e.Bounds.Height);
    //            _with10.DrawString(" " + ListB.GetItemText(Items[e.Index]), new Font("Segoe UI", 9, FontStyle.Bold), new SolidBrush(_TextColour), e.Bounds.X, e.Bounds.Y + 2);
    //        }
    //        else
    //        {
    //            _with10.FillRectangle(new SolidBrush(_BaseColour), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
    //            _with10.DrawString(" " + ListB.GetItemText(Items[e.Index]), new Font("Segoe UI", 8), new SolidBrush(_TextColour), e.Bounds.X, e.Bounds.Y + 2);
    //        }
    //        _with10.Dispose();
    //    }

    //    public ElegantThemeTitledListBox()
    //    {
    //        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
    //        DoubleBuffered = true;
    //        ListB.DrawMode = DrawMode.OwnerDrawFixed;
    //        ListB.ScrollAlwaysVisible = false;
    //        ListB.HorizontalScrollbar = false;
    //        ListB.BorderStyle = BorderStyle.None;
    //        ListB.BackColor = _BaseColour;
    //        ListB.Location = new Point(3, 30);
    //        ListB.Font = new Font("Segoe UI", 8);
    //        ListB.ItemHeight = 20;
    //        ListB.Items.Clear();
    //        ListB.IntegralHeight = false;
    //        Size = new Size(130, 100);
    //    }

    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = e.Graphics;
    //        G = Graphics.FromImage(B);
    //        Rectangle Base = new Rectangle(0, 28, Width, Height);
    //        var _with11 = G;
    //        _with11.SmoothingMode = SmoothingMode.HighQuality;
    //        _with11.PixelOffsetMode = PixelOffsetMode.HighQuality;
    //        _with11.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
    //        _with11.Clear(Color.FromArgb(248, 250, 249));
    //        ListB.Size = new Size(Width - 6, Height - 32);
    //        _with11.FillRectangle(new SolidBrush(BaseColour), Base);
    //        _with11.DrawRectangle(new Pen((_BorderColour), 1), new Rectangle(0, 0, Width, Height - 1));
    //        _with11.DrawLine(new Pen((_BorderColour), 2), new Point(0, 27), new Point(Width - 1, 27));
    //        _with11.DrawString(Text, _TitleFont, new SolidBrush(_TextColour), new Rectangle(2, 5, Width - 5, 20), new StringFormat
    //        {
    //            Alignment = StringAlignment.Near,
    //            LineAlignment = StringAlignment.Center
    //        });
    //        _with11.DrawLine(new Pen(_BorderColour, 3), new Point(0, 26), new Point((int)_with11.MeasureString(Text, _TitleFont).Width + 10, 26));

    //        base.OnPaint(e);
    //        G.Dispose();
    //        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
    //        e.Graphics.DrawImageUnscaled(B, 0, 0);
    //        B.Dispose();
    //    }

    //    #endregion

    //}

    //public class ElegantThemeListBox : Control
    //{

    //    #region "Declarations"

    //    private ListBox withEventsField_ListB = new ListBox();
    //    private ListBox ListB
    //    {
    //        get { return withEventsField_ListB; }
    //        set
    //        {
    //            if (withEventsField_ListB != null)
    //            {
    //                withEventsField_ListB.DrawItem -= Drawitem;
    //            }
    //            withEventsField_ListB = value;
    //            if (withEventsField_ListB != null)
    //            {
    //                withEventsField_ListB.DrawItem += Drawitem;
    //            }
    //        }
    //    }
    //    private string[] _Items = { "" };
    //    private Color _BaseColour = Color.FromArgb(255, 255, 255);
    //    private Color _SelectedColour = Color.FromArgb(55, 55, 55);
    //    private Color _TextColour = Color.FromArgb(163, 163, 163);

    //    private Color _BorderColour = Color.FromArgb(183, 210, 166);
    //    #endregion

    //    #region "Properties"

    //    [Category("Control")]
    //    public string[] Items
    //    {
    //        get { return _Items; }
    //        set
    //        {
    //            _Items = value;
    //            ListB.Items.Clear();
    //            ListB.Items.AddRange(value);
    //            Invalidate();
    //        }
    //    }

    //    [Category("Colours")]
    //    public Color BorderColour
    //    {
    //        get { return _BorderColour; }
    //        set { _BorderColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color SelectedColour
    //    {
    //        get { return _SelectedColour; }
    //        set { _SelectedColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color BaseColour
    //    {
    //        get { return _BaseColour; }
    //        set { _BaseColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color TextColour
    //    {
    //        get { return _TextColour; }
    //        set { _TextColour = value; }
    //    }

    //    public string SelectedItem
    //    {
    //        get { return ListB.GetItemText(SelectedItem); }
    //    }

    //    public int SelectedIndex
    //    {
    //        get
    //        {
    //            int functionReturnValue = 0;
    //            return ListB.SelectedIndex;
    //            if (ListB.SelectedIndex < 0)
    //                return functionReturnValue;
    //            return functionReturnValue;
    //        }
    //    }

    //    public void Clear()
    //    {
    //        ListB.Items.Clear();
    //    }

    //    public void ClearSelected()
    //    {
    //        for (int i = (ListB.SelectedItems.Count - 1); i >= 0; i += -1)
    //        {
    //            ListB.Items.Remove(ListB.SelectedItems[i]);
    //        }
    //    }

    //    protected override void OnCreateControl()
    //    {
    //        base.OnCreateControl();
    //        if (!Controls.Contains(ListB))
    //        {
    //            Controls.Add(ListB);
    //        }
    //    }

    //    public void AddRange(object[] items)
    //    {
    //        ListB.Items.Remove("");
    //        ListB.Items.AddRange(items);
    //    }

    //    public void AddItem(object item)
    //    {
    //        ListB.Items.Remove("");
    //        ListB.Items.Add(item);
    //    }

    //    #endregion

    //    #region "Draw Control"

    //    public void Drawitem(object sender, DrawItemEventArgs e)
    //    {
    //        if (e.Index < 0)
    //            return;
    //        e.DrawBackground();
    //        e.DrawFocusRectangle();
    //        var _with12 = e.Graphics;
    //        _with12.SmoothingMode = SmoothingMode.HighQuality;
    //        _with12.PixelOffsetMode = PixelOffsetMode.HighQuality;
    //        _with12.InterpolationMode = InterpolationMode.HighQualityBicubic;
    //        _with12.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
    //        if (String.Compare(e.State.ToString(), "Selected,") > 0)
    //        {
    //            _with12.FillRectangle(new SolidBrush(_BaseColour), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
    //            _with12.DrawLine(new Pen(_BorderColour), e.Bounds.X, e.Bounds.Y + e.Bounds.Height, e.Bounds.Width, e.Bounds.Y + e.Bounds.Height);
    //            _with12.DrawString(" " + ListB.GetItemText(Items[e.Index]), new Font("Segoe UI", 9, FontStyle.Bold), new SolidBrush(_TextColour), e.Bounds.X, e.Bounds.Y + 2);
    //        }
    //        else
    //        {
    //            _with12.FillRectangle(new SolidBrush(_BaseColour), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
    //            _with12.DrawString(" " + ListB.GetItemText(Items[e.Index]), new Font("Segoe UI", 8), new SolidBrush(_TextColour), e.Bounds.X, e.Bounds.Y + 2);
    //        }
    //        _with12.Dispose();
    //    }

    //    public ElegantThemeListBox()
    //    {
    //        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
    //        DoubleBuffered = true;
    //        ListB.DrawMode = DrawMode.OwnerDrawFixed;
    //        ListB.ScrollAlwaysVisible = false;
    //        ListB.HorizontalScrollbar = false;
    //        ListB.BorderStyle = BorderStyle.None;
    //        ListB.BackColor = _BaseColour;
    //        ListB.Location = new Point(3, 3);
    //        ListB.Font = new Font("Segoe UI", 8);
    //        ListB.ItemHeight = 20;
    //        ListB.Items.Clear();
    //        ListB.IntegralHeight = false;
    //        Size = new Size(130, 100);
    //    }

    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(1, 1);
    //        Graphics G = e.Graphics;
    //        G = Graphics.FromImage(B);
    //        Rectangle Base = new Rectangle(0, 0, Width, Height);
    //        var _with13 = G;
    //        _with13.SmoothingMode = SmoothingMode.HighQuality;
    //        _with13.PixelOffsetMode = PixelOffsetMode.HighQuality;
    //        _with13.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
    //        _with13.Clear(Color.FromArgb(248, 250, 249));
    //        ListB.Size = new Size(Width - 6, Height - 7);
    //        _with13.FillRectangle(new SolidBrush(BaseColour), Base);
    //        _with13.DrawRectangle(new Pen((_BorderColour), 1), new Rectangle(0, 0, Width, Height - 1));
    //        base.OnPaint(e);
    //        G.Dispose();
    //        e.Graphics.InterpolationMode = (InterpolationMode)7;
    //        e.Graphics.DrawImageUnscaled(B, 0, 0);
    //        B.Dispose();
    //    }

    //    #endregion

    //}

    //public class ElegantThemeLabel : Label
    //{

    //    #region "Declaration"
    //    #endregion
    //    private Color _FontColour = Color.FromArgb(163, 163, 163);

    //    #region "Property & Event"

    //    [Category("Colours")]
    //    public Color FontColour
    //    {
    //        get { return _FontColour; }
    //        set { _FontColour = value; }
    //    }

    //    protected override void OnTextChanged(EventArgs e)
    //    {
    //        base.OnTextChanged(e);
    //        Invalidate();
    //    }

    //    #endregion

    //    #region "Draw Control"

    //    public ElegantThemeLabel()
    //    {
    //        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
    //        Font = new Font("Segoe UI", 9);
    //        ForeColor = _FontColour;
    //        BackColor = Color.Transparent;
    //        Text = Text;
    //    }

    //    #endregion

    //}

    //public class ElegantThemeRichTextBox : Control
    //{

    //    #region "Declarations"
    //    private RichTextBox TB = new RichTextBox();
    //    private Color _BaseColour = Color.FromArgb(255, 255, 255);
    //    private Color _TextColour = Color.FromArgb(163, 163, 163);
    //    #endregion
    //    private Color _BorderColour = Color.FromArgb(183, 210, 166);

    //    #region "Properties"

    //    [Category("Colours")]
    //    public Color BaseColour
    //    {
    //        get { return _BaseColour; }
    //        set { _BaseColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color BorderColour
    //    {
    //        get { return _BorderColour; }
    //        set { _BorderColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color TextColour
    //    {
    //        get { return _TextColour; }
    //        set { _TextColour = value; }
    //    }

    //    #endregion

    //    #region "Events"

    //    public override string Text
    //    {
    //        get { return TB.Text; }
    //        set
    //        {
    //            TB.Text = value;
    //            Invalidate();
    //        }
    //    }

    //    protected override void OnBackColorChanged(System.EventArgs e)
    //    {
    //        base.OnBackColorChanged(e);
    //        TB.BackColor = _BaseColour;
    //        Invalidate();
    //    }

    //    protected override void OnForeColorChanged(System.EventArgs e)
    //    {
    //        base.OnForeColorChanged(e);
    //        TB.ForeColor = ForeColor;
    //        Invalidate();
    //    }

    //    protected override void OnSizeChanged(System.EventArgs e)
    //    {
    //        base.OnSizeChanged(e);
    //        TB.Size = new Size(Width - 10, Height - 11);
    //    }

    //    protected override void OnFontChanged(System.EventArgs e)
    //    {
    //        base.OnFontChanged(e);
    //        TB.Font = Font;
    //    }

    //    public void TextChanges(object sender, EventArgs e)
    //    {
    //        TB.Text = Text;
    //    }

    //    public void AppendText(string Text)
    //    {
    //        TB.Focus();
    //        TB.AppendText(Text);
    //        Invalidate();
    //    }

    //    #endregion

    //    #region "Draw Control"

    //    public ElegantThemeRichTextBox()
    //    {
    //        TextChanged += TextChanges;
    //        var _with14 = TB;
    //        _with14.Multiline = true;
    //        _with14.ForeColor = _TextColour;
    //        _with14.Text = string.Empty;
    //        _with14.BorderStyle = BorderStyle.None;
    //        _with14.Location = new Point(5, 5);
    //        _with14.Font = new Font("Segeo UI", 9);
    //        _with14.Size = new Size(Width - 10, Height - 10);
    //        Controls.Add(TB);
    //        Size = new Size(135, 35);
    //        DoubleBuffered = true;
    //    }

    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = e.Graphics;
    //        G = Graphics.FromImage(B);
    //        Rectangle Base = new Rectangle(0, 0, Width - 1, Height - 1);
    //        var _with15 = G;
    //        _with15.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
    //        _with15.SmoothingMode = SmoothingMode.HighQuality;
    //        _with15.PixelOffsetMode = PixelOffsetMode.HighQuality;
    //        _with15.Clear(_BaseColour);
    //        _with15.DrawRectangle(new Pen(_BorderColour, 1), ClientRectangle);
    //        base.OnPaint(e);
    //        G.Dispose();
    //        e.Graphics.InterpolationMode = (InterpolationMode)7;
    //        e.Graphics.DrawImageUnscaled(B, 0, 0);
    //        B.Dispose();
    //    }

    //    #endregion

    //}

    //public class ElegantThemeColourTable : ProfessionalColorTable
    //{

    //    #region "Declarations"

    //    private Color _BackColour = Color.FromArgb(220, 220, 220);
    //    private Color _BorderColour = Color.FromArgb(183, 210, 166);

    //    private Color _SelectedColour = Color.FromArgb(230, 230, 230);
    //    #endregion

    //    #region "Properties"

    //    [Category("Colours")]
    //    public Color SelectedColour
    //    {
    //        get { return _SelectedColour; }
    //        set { _SelectedColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color BorderColour
    //    {
    //        get { return _BorderColour; }
    //        set { _BorderColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color BackColour
    //    {
    //        get { return _BackColour; }
    //        set { _BackColour = value; }
    //    }

    //    public override Color ButtonSelectedBorder
    //    {
    //        get { return _BackColour; }
    //    }

    //    public override Color CheckBackground
    //    {
    //        get { return _BackColour; }
    //    }

    //    public override Color CheckPressedBackground
    //    {
    //        get { return _BackColour; }
    //    }

    //    public override Color CheckSelectedBackground
    //    {
    //        get { return _BackColour; }
    //    }

    //    public override Color ImageMarginGradientBegin
    //    {
    //        get { return _BackColour; }
    //    }

    //    public override Color ImageMarginGradientEnd
    //    {
    //        get { return _BackColour; }
    //    }

    //    public override Color ImageMarginGradientMiddle
    //    {
    //        get { return _BackColour; }
    //    }

    //    public override Color MenuBorder
    //    {
    //        get { return _BorderColour; }
    //    }

    //    public override Color MenuItemBorder
    //    {
    //        get { return _BackColour; }
    //    }

    //    public override Color MenuItemSelected
    //    {
    //        get { return _SelectedColour; }
    //    }

    //    public override Color SeparatorDark
    //    {
    //        get { return _BorderColour; }
    //    }

    //    public override Color ToolStripDropDownBackground
    //    {
    //        get { return _BackColour; }
    //    }

    //    #endregion

    //}

    //public class ElegantThemeContextMenu : ContextMenuStrip
    //{

    //    #region "Draw Control"

    //    public ElegantThemeContextMenu()
    //    {
    //        Renderer = new ToolStripProfessionalRenderer(new ElegantThemeColourTable());
    //        ShowCheckMargin = false;
    //        ShowImageMargin = false;
    //    }

    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
    //        base.OnPaint(e);
    //    }

    //    #endregion

    //}

    //public class ElegantThemeTabControlVertical : TabControl
    //{

    //    #region "Declarations"
    //    private Color _PressedTabColour = Color.FromArgb(238, 240, 239);
    //    private Color _HoverColour = Color.FromArgb(230, 230, 230);
    //    private Color _NormalColour = Color.FromArgb(250, 249, 251);
    //    private Color _BorderColour = Color.FromArgb(163, 190, 146);
    //    private Color _TextColour = Color.FromArgb(163, 163, 163);
    //    #endregion
    //    private int HoverIndex = -1;

    //    #region "Colour & Other Properties"
    //    [Category("Colours")]
    //    public Color NormalColour
    //    {
    //        get { return _NormalColour; }
    //        set { _NormalColour = value; }
    //    }
    //    [Category("Colours")]
    //    public Color HoverColour
    //    {
    //        get { return _HoverColour; }
    //        set { _HoverColour = value; }
    //    }
    //    [Category("Colours")]
    //    public Color PressedTabColour
    //    {
    //        get { return _PressedTabColour; }
    //        set { _PressedTabColour = value; }
    //    }
    //    [Category("Colours")]
    //    public Color BorderColour
    //    {
    //        get { return _BorderColour; }
    //        set { _BorderColour = value; }
    //    }
    //    [Category("Colours")]
    //    public Color TextColour
    //    {
    //        get { return _TextColour; }
    //        set { _TextColour = value; }
    //    }
    //    #endregion

    //    #region "Draw Control"
    //    public ElegantThemeTabControlVertical()
    //    {
    //        DoubleBuffered = true;
    //        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
    //        SizeMode = TabSizeMode.Fixed;
    //        ItemSize = new Size(45, 95);
    //        Font = new Font("Segoe UI", 9, FontStyle.Bold);
    //        DrawMode = TabDrawMode.OwnerDrawFixed;
    //    }

    //    protected override void CreateHandle()
    //    {
    //        base.CreateHandle();
    //        Alignment = TabAlignment.Left;
    //    }

    //    protected override void OnControlAdded(ControlEventArgs e)
    //    {
    //        if (e.Control is TabPage)
    //        {
    //            foreach (TabPage i in Controls)
    //            {

    //                Controls.Add(i);
    //                //i = new TabPage();
    //            }
    //            e.Control.BackColor = Color.FromArgb(255, 255, 255);
    //        }
    //        base.OnControlAdded(e);
    //    }

    //    protected override void OnMouseMove(MouseEventArgs e)
    //    {
    //        for (int I = 0; I <= TabPages.Count - 1; I++)
    //        {
    //            if (GetTabRect(I).Contains(e.Location))
    //            {
    //                HoverIndex = I;
    //                break; // TODO: might not be correct. Was : Exit For
    //            }
    //        }
    //        Invalidate();
    //        base.OnMouseMove(e);
    //    }

    //    protected override void OnMouseLeave(EventArgs e)
    //    {
    //        HoverIndex = -1;
    //        Invalidate();
    //        base.OnMouseLeave(e);

    //    }

    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = e.Graphics;
    //        G = Graphics.FromImage(B);
    //        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
    //        G.SmoothingMode = SmoothingMode.HighQuality;
    //        G.PixelOffsetMode = PixelOffsetMode.HighQuality;
    //        G.Clear(BackColor);
    //        try
    //        {
    //            SelectedTab.BackColor = _NormalColour;
    //        }
    //        catch
    //        {
    //        }
    //        var _with16 = G;
    //        _with16.FillRectangle(new SolidBrush(_NormalColour), new Rectangle(-2, 0, ItemSize.Height + 4, Height + 22));
    //        for (int i = 0; i <= TabCount - 1; i++)
    //        {
    //            Rectangle tabRect1 = new Rectangle(GetTabRect(i).Location.X + 5, GetTabRect(i).Location.Y + 2, GetTabRect(i).Size.Width - 20, GetTabRect(i).Size.Height - 11);
    //            if (i == SelectedIndex)
    //            {
    //                Rectangle tabRect = new Rectangle(GetTabRect(i).Location.X + 5, GetTabRect(i).Location.Y + 2, GetTabRect(i).Size.Width + 10, GetTabRect(i).Size.Height - 11);
    //                _with16.FillRectangle(new SolidBrush(_PressedTabColour), new Rectangle(tabRect.X + 1, tabRect.Y + 1, tabRect.Width - 1, tabRect.Height - 2));
    //                _with16.DrawRectangle(new Pen(_BorderColour), tabRect);
    //                _with16.FillRectangle(new SolidBrush(_BorderColour), GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y + 1, GetTabRect(i).Location.X + 2, GetTabRect(i).Size.Height - 10);
    //                _with16.FillRectangle(new SolidBrush(_BorderColour), GetTabRect(i).Location.X + 2, GetTabRect(i).Location.Y + 6, GetTabRect(i).Location.X + 2, GetTabRect(i).Size.Height - 19);
    //                _with16.SmoothingMode = SmoothingMode.AntiAlias;
    //                _with16.DrawString(TabPages[i].Text, new Font("Segoe UI", 9, FontStyle.Bold), new SolidBrush(_TextColour), tabRect1, new StringFormat
    //                {
    //                    LineAlignment = StringAlignment.Center,
    //                    Alignment = StringAlignment.Center
    //                });
    //            }
    //            else
    //            {
    //                if (HoverIndex == i)
    //                {
    //                    Rectangle x21 = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y + 2), new Size(GetTabRect(i).Width, GetTabRect(i).Height - 11));
    //                    _with16.FillRectangle(new SolidBrush(_HoverColour), x21);
    //                }
    //                _with16.DrawString(TabPages[i].Text, new Font("Segoe UI", 9, FontStyle.Regular), new SolidBrush(_TextColour), tabRect1, new StringFormat
    //                {
    //                    LineAlignment = StringAlignment.Center,
    //                    Alignment = StringAlignment.Center
    //                });

    //            }
    //            _with16.FillRectangle(new SolidBrush(_NormalColour), new Rectangle(97, 0, Width - 97, Height));
    //            _with16.DrawLine(new Pen((_BorderColour), 1), new Point(96, 0), new Point(96, Height));
    //        }
    //        G.Dispose();
    //        e.Graphics.InterpolationMode = (InterpolationMode)7;
    //        e.Graphics.DrawImageUnscaled(B, 0, 0);
    //        B.Dispose();
    //    }
    //    #endregion

    //}

    //public class ElegantThemeProgressBar : Control
    //{

    //    #region "Declarations"

    //    private Color _ProgressColour = Color.FromArgb(163, 190, 146);
    //    private Color _BorderColour = Color.FromArgb(210, 210, 210);
    //    private Color _BaseColour = Color.FromArgb(255, 255, 255);
    //    private Color _SecondColour = Color.FromArgb(148, 190, 131);
    //    private int _Value = 0;
    //    private int _Maximum = 100;

    //    private bool _TwoColour = true;
    //    #endregion

    //    #region "Properties"

    //    [Category("Colours")]
    //    public Color SecondColour
    //    {
    //        get { return _SecondColour; }
    //        set { _SecondColour = value; }
    //    }

    //    [Category("Control")]
    //    public bool TwoColour
    //    {
    //        get { return _TwoColour; }
    //        set { _TwoColour = value; }
    //    }

    //    [Category("Control")]
    //    public int Maximum
    //    {
    //        get { return _Maximum; }
    //        set
    //        {
    //            if (value == _Value)
    //            {
    //                _Value = value;
    //            }

    //            #region Old Code

    //            //			switch (value) {
    //            //				case  // ERROR: Case labels with binary operators are unsupported : LessThan
    //            //_Value:
    //            //					_Value = value;
    //            //					break;
    //            //			} 
    //            #endregion

    //            _Maximum = value;
    //            Invalidate();
    //        }
    //    }

    //    [Category("Control")]
    //    public int Value
    //    {
    //        get
    //        {
    //            switch (_Value)
    //            {
    //                case 0:
    //                    return 0;
    //                    Invalidate();
    //                    break;
    //                default:
    //                    return _Value;
    //                    Invalidate();
    //                    break;
    //            }
    //        }
    //        set
    //        {

    //            if (value == _Maximum)
    //            {
    //                value = _Maximum;
    //                Invalidate();
    //            }

    //            #region Old Code
    //            //			switch (value) {
    //            //				case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
    //            //_Maximum:
    //            //					value = _Maximum;
    //            //					Invalidate();
    //            //					break;
    //            //			} 
    //            #endregion

    //            _Value = value;
    //            Invalidate();
    //        }
    //    }

    //    [Category("Colours")]
    //    public Color ProgressColour
    //    {
    //        get { return _ProgressColour; }
    //        set { _ProgressColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color BaseColour
    //    {
    //        get { return _BaseColour; }
    //        set { _BaseColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color BorderColour
    //    {
    //        get { return _BorderColour; }
    //        set { _BorderColour = value; }
    //    }


    //    #endregion

    //    #region "Events"

    //    protected override void OnResize(EventArgs e)
    //    {
    //        base.OnResize(e);
    //        if (Height < 25)
    //        {
    //            Height = 25;
    //        }
    //    }

    //    protected override void CreateHandle()
    //    {
    //        base.CreateHandle();
    //        Height = 25;
    //    }

    //    public void Increment(int Amount)
    //    {
    //        Value += Amount;
    //    }

    //    #endregion

    //    #region "Draw Control"

    //    public ElegantThemeProgressBar()
    //    {
    //        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
    //        DoubleBuffered = true;
    //    }

    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = e.Graphics;
    //        G = Graphics.FromImage(B);
    //        Rectangle Base = new Rectangle(0, 0, Width, Height);
    //        var _with17 = G;
    //        _with17.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
    //        _with17.SmoothingMode = SmoothingMode.HighQuality;
    //        _with17.PixelOffsetMode = PixelOffsetMode.HighQuality;
    //        _with17.Clear(BackColor);
    //        int ProgVal = Convert.ToInt32(_Value / _Maximum * Width);

    //        if (_Value == 0)
    //        {
    //            _with17.FillRectangle(new SolidBrush(_BaseColour), Base);
    //            _with17.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
    //            _with17.DrawRectangle(new Pen(_BorderColour, 3), Base);
    //        }
    //        else if (_Value == _Maximum)
    //        {
    //            _with17.FillRectangle(new SolidBrush(_BaseColour), Base);
    //            _with17.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
    //            if (_TwoColour)
    //            {
    //                G.SetClip(new Rectangle(0, -10, Width * _Value / _Maximum - 1, Height - 5));
    //                for (int i = 0; i <= (Width - 1) * _Maximum / _Value; i += 20)
    //                {
    //                    G.DrawLine(new Pen(new SolidBrush(_SecondColour), 7), new Point(i, 0), new Point(i - 15, Height));
    //                }
    //                G.ResetClip();
    //            }
    //            else
    //            {
    //            }
    //            _with17.DrawRectangle(new Pen(_BorderColour, 3), Base);
    //        }
    //        else
    //        {
    //            _with17.FillRectangle(new SolidBrush(_BaseColour), Base);
    //            _with17.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
    //            if (_TwoColour)
    //            {
    //                _with17.SetClip(new Rectangle(0, 0, Width * _Value / _Maximum - 1, Height - 1));
    //                for (int i = 0; i <= (Width - 1) * _Maximum / _Value; i += 20)
    //                {
    //                    _with17.DrawLine(new Pen(new SolidBrush(_SecondColour), 7), new Point(i, 0), new Point(i - 10, Height));
    //                }
    //                _with17.ResetClip();
    //            }
    //            else
    //            {
    //            }
    //            _with17.DrawRectangle(new Pen(_BorderColour, 3), Base);
    //        }

    //        #region Old Code
    //        //switch (Value) {
    //        //	case 0:
    //        //		_with17.FillRectangle(new SolidBrush(_BaseColour), Base);
    //        //		_with17.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
    //        //		_with17.DrawRectangle(new Pen(_BorderColour, 3), Base);
    //        //		break;
    //        //	case _Maximum:
    //        //		_with17.FillRectangle(new SolidBrush(_BaseColour), Base);
    //        //		_with17.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
    //        //		if (_TwoColour) {
    //        //			G.SetClip(new Rectangle(0, -10, Width * _Value / _Maximum - 1, Height - 5));
    //        //			for (int i = 0; i <= (Width - 1) * _Maximum / _Value; i += 20) {
    //        //				G.DrawLine(new Pen(new SolidBrush(_SecondColour), 7), new Point(i, 0), new Point(i - 15, Height));
    //        //			}
    //        //			G.ResetClip();
    //        //		} else {
    //        //		}
    //        //		_with17.DrawRectangle(new Pen(_BorderColour, 3), Base);
    //        //		break;
    //        //	default:
    //        //		_with17.FillRectangle(new SolidBrush(_BaseColour), Base);
    //        //		_with17.FillRectangle(new SolidBrush(_ProgressColour), new Rectangle(0, 0, ProgVal - 1, Height));
    //        //		if (_TwoColour) {
    //        //			_with17.SetClip(new Rectangle(0, 0, Width * _Value / _Maximum - 1, Height - 1));
    //        //			for (i = 0; i <= (Width - 1) * _Maximum / _Value; i += 20) {
    //        //				_with17.DrawLine(new Pen(new SolidBrush(_SecondColour), 7), new Point(i, 0), new Point(i - 10, Height));
    //        //			}
    //        //			_with17.ResetClip();
    //        //		} else {
    //        //		}
    //        //		_with17.DrawRectangle(new Pen(_BorderColour, 3), Base);
    //        //		break;
    //        //} 
    //        #endregion

    //        base.OnPaint(e);
    //        G.Dispose();
    //        e.Graphics.InterpolationMode = (InterpolationMode)7;
    //        e.Graphics.DrawImageUnscaled(B, 0, 0);
    //        B.Dispose();
    //    }

    //    #endregion

    //}

    //[DefaultEvent("CheckedChanged")]
    //public class ElegantRadioButton : Control
    //{

    //    #region "Declarations"
    //    private bool _Checked;
    //    private MouseState State = MouseState.None;
    //    private Color _HoverColour = Color.FromArgb(240, 240, 240);
    //    private Color _CheckedColour = Color.FromArgb(163, 190, 146);
    //    private Color _BorderColour = Color.FromArgb(210, 210, 210);
    //    private Color _BackColour = Color.FromArgb(255, 255, 255);
    //    #endregion
    //    private Color _TextColour = Color.FromArgb(163, 163, 163);

    //    #region "Colour & Other Properties"

    //    [Category("Colours")]
    //    public Color HighlightColour
    //    {
    //        get { return _HoverColour; }
    //        set { _HoverColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color BaseColour
    //    {
    //        get { return _BackColour; }
    //        set { _BackColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color BorderColour
    //    {
    //        get { return _BorderColour; }
    //        set { _BorderColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color CheckedColour
    //    {
    //        get { return _CheckedColour; }
    //        set { _CheckedColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color FontColour
    //    {
    //        get { return _TextColour; }
    //        set { _TextColour = value; }
    //    }

    //    public event CheckedChangedEventHandler CheckedChanged;
    //    public delegate void CheckedChangedEventHandler(object sender);
    //    public bool Checked
    //    {
    //        get { return _Checked; }
    //        set
    //        {
    //            _Checked = value;
    //            InvalidateControls();
    //            if (CheckedChanged != null)
    //            {
    //                CheckedChanged(this);
    //            }
    //            Invalidate();
    //        }
    //    }

    //    protected override void OnClick(EventArgs e)
    //    {
    //        if (!_Checked)
    //            Checked = true;
    //        base.OnClick(e);
    //    }
    //    private void InvalidateControls()
    //    {
    //        if (!IsHandleCreated || !_Checked)
    //            return;
    //        foreach (Control C in Parent.Controls)
    //        {
    //            if (!object.ReferenceEquals(C, this) && C is ElegantRadioButton)
    //            {
    //                ((ElegantRadioButton)C).Checked = false;
    //                Invalidate();
    //            }
    //        }
    //    }
    //    protected override void OnCreateControl()
    //    {
    //        base.OnCreateControl();
    //        InvalidateControls();
    //    }
    //    protected override void OnResize(EventArgs e)
    //    {
    //        base.OnResize(e);
    //        Height = 22;
    //    }
    //    #endregion

    //    #region "Mouse States"

    //    protected override void OnMouseDown(MouseEventArgs e)
    //    {
    //        base.OnMouseDown(e);
    //        State = MouseState.Down;
    //        Invalidate();
    //    }
    //    protected override void OnMouseUp(MouseEventArgs e)
    //    {
    //        base.OnMouseUp(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseEnter(EventArgs e)
    //    {
    //        base.OnMouseEnter(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseLeave(EventArgs e)
    //    {
    //        base.OnMouseLeave(e);
    //        State = MouseState.None;
    //        Invalidate();
    //    }

    //    #endregion

    //    #region "Draw Control"
    //    public ElegantRadioButton()
    //    {
    //        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
    //        DoubleBuffered = true;
    //        Cursor = Cursors.Hand;
    //        Size = new Size(100, 22);
    //    }

    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = e.Graphics;
    //        G = Graphics.FromImage(B);
    //        Rectangle Base = new Rectangle(1, 1, Height - 2, Height - 2);
    //        Rectangle Circle = new Rectangle(6, 6, Height - 12, Height - 12);
    //        Rectangle SecondBorder = new Rectangle(4, 3, 14, 14);
    //        var _with18 = G;
    //        _with18.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
    //        _with18.SmoothingMode = SmoothingMode.HighQuality;
    //        _with18.PixelOffsetMode = PixelOffsetMode.HighQuality;
    //        _with18.Clear(Color.Transparent);
    //        _with18.FillEllipse(new SolidBrush(_BackColour), Base);
    //        _with18.DrawEllipse(new Pen(_BorderColour, 2), Base);
    //        if (Checked)
    //        {
    //            switch (State)
    //            {
    //                case MouseState.Over:
    //                    _with18.FillEllipse(new SolidBrush(_HoverColour), new Rectangle(2, 2, Height - 4, Height - 4));
    //                    break;
    //            }
    //            _with18.FillEllipse(new SolidBrush(_CheckedColour), Circle);
    //        }
    //        else
    //        {
    //            switch (State)
    //            {
    //                case MouseState.Over:
    //                    _with18.FillEllipse(new SolidBrush(_HoverColour), new Rectangle(2, 2, Height - 4, Height - 4));
    //                    break;
    //            }
    //        }
    //        _with18.DrawString(Text, Font, new SolidBrush(_TextColour), new Rectangle(24, 3, Width, Height), new StringFormat
    //        {
    //            Alignment = StringAlignment.Near,
    //            LineAlignment = StringAlignment.Near
    //        });
    //        base.OnPaint(e);
    //        G.Dispose();
    //        e.Graphics.InterpolationMode = (InterpolationMode)7;
    //        e.Graphics.DrawImageUnscaled(B, 0, 0);
    //        B.Dispose();
    //    }
    //    #endregion

    //}

    //public class ElegantThemeRadialProgressBar : Control
    //{

    //    #region "Declarations"
    //    private Color _BorderColour = Color.FromArgb(210, 210, 210);
    //    private Color _BaseColour = Color.FromArgb(255, 255, 255);
    //    private Color _ProgressColour = Color.FromArgb(163, 190, 146);
    //    private Color _TextColour = Color.FromArgb(163, 163, 163);
    //    private int _Value = 0;
    //    private int _Maximum = 100;
    //    private int _StartingAngle = 110;
    //    private int _RotationAngle = 255;
    //    #endregion
    //    private Font _Font = new Font("Segoe UI", 20);

    //    #region "Properties"

    //    [Category("Control")]
    //    public int Maximum
    //    {
    //        get { return _Maximum; }
    //        set
    //        {

    //            if (value == _Value)
    //            {
    //                _Value = value;
    //            }

    //            #region Old Code
    //            //			switch (value) {
    //            //				case  // ERROR: Case labels with binary operators are unsupported : LessThan
    //            //_Value:
    //            //					_Value = value;
    //            //					break;
    //            //			} 
    //            #endregion

    //            _Maximum = value;
    //            Invalidate();
    //        }
    //    }

    //    [Category("Control")]
    //    public int Value
    //    {
    //        get
    //        {
    //            switch (_Value)
    //            {
    //                case 0:
    //                    return 0;
    //                    Invalidate();
    //                    break;
    //                default:
    //                    return _Value;
    //                    Invalidate();
    //                    break;
    //            }
    //        }

    //        set
    //        {

    //            if (value == _Maximum)
    //            {
    //                value = _Maximum;
    //                Invalidate();
    //            }

    //            #region Old Code
    //            //			switch (value) {
    //            //				case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
    //            //_Maximum:
    //            //					value = _Maximum;
    //            //					Invalidate();
    //            //					break;
    //            //			} 
    //            #endregion

    //            _Value = value;
    //            Invalidate();
    //        }
    //    }

    //    public void Increment(int Amount)
    //    {
    //        Value += Amount;
    //    }

    //    [Category("Colours")]
    //    public Color BorderColour
    //    {
    //        get { return _BorderColour; }
    //        set { _BorderColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color TextColour
    //    {
    //        get { return _TextColour; }
    //        set { _TextColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color ProgressColour
    //    {
    //        get { return _ProgressColour; }
    //        set { _ProgressColour = value; }
    //    }

    //    [Category("Colours")]
    //    public Color BaseColour
    //    {
    //        get { return _BaseColour; }
    //        set { _BaseColour = value; }
    //    }

    //    [Category("Control")]
    //    public int StartingAngle
    //    {
    //        get { return _StartingAngle; }
    //        set { _StartingAngle = value; }
    //    }

    //    [Category("Control")]
    //    public int RotationAngle
    //    {
    //        get { return _RotationAngle; }
    //        set { _RotationAngle = value; }
    //    }

    //    #endregion

    //    #region "Draw Control"
    //    public ElegantThemeRadialProgressBar()
    //    {
    //        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
    //        DoubleBuffered = true;
    //        Size = new Size(78, 78);
    //        BackColor = Color.Transparent;
    //    }

    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = e.Graphics;
    //        G = Graphics.FromImage(B);
    //        var _with19 = G;
    //        _with19.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
    //        _with19.SmoothingMode = SmoothingMode.HighQuality;
    //        _with19.PixelOffsetMode = PixelOffsetMode.HighQuality;
    //        _with19.Clear(BackColor);

    //        if (_Value == 0)
    //        {
    //            _with19.DrawArc(new Pen(new SolidBrush(_BorderColour), 1 + 6), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5);
    //            _with19.DrawArc(new Pen(new SolidBrush(_BaseColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle);
    //            _with19.DrawString(_Value.ToString(), _Font, new SolidBrush(_TextColour), new Point(Width / 2, Height / 2 - 1), new StringFormat
    //            {
    //                Alignment = StringAlignment.Center,
    //                LineAlignment = StringAlignment.Center
    //            });
    //        }
    //        else if (_Value == _Maximum)
    //        {
    //            _with19.DrawArc(new Pen(new SolidBrush(_BorderColour), 1 + 6), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5);
    //            _with19.DrawArc(new Pen(new SolidBrush(_BaseColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle);
    //            _with19.DrawArc(new Pen(new SolidBrush(_ProgressColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle);
    //            _with19.DrawString(_Value.ToString(), _Font, new SolidBrush(_TextColour), new Point(Width / 2, Height / 2 - 1), new StringFormat
    //            {
    //                Alignment = StringAlignment.Center,
    //                LineAlignment = StringAlignment.Center
    //            });
    //        }
    //        else
    //        {
    //            _with19.DrawArc(new Pen(new SolidBrush(_BorderColour), 1 + 6), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5);
    //            _with19.DrawArc(new Pen(new SolidBrush(_BaseColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle);
    //            _with19.DrawArc(new Pen(new SolidBrush(_ProgressColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, Convert.ToInt32((_RotationAngle / _Maximum) * _Value));
    //            _with19.DrawString(_Value.ToString(), _Font, new SolidBrush(_TextColour), new Point(Width / 2, Height / 2 - 1), new StringFormat
    //            {
    //                Alignment = StringAlignment.Center,
    //                LineAlignment = StringAlignment.Center
    //            });
    //        }

    //        #region Old Code
    //        //switch (_Value) {
    //        //	case 0:
    //        //		_with19.DrawArc(new Pen(new SolidBrush(_BorderColour), 1 + 6), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5);
    //        //		_with19.DrawArc(new Pen(new SolidBrush(_BaseColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle);
    //        //		_with19.DrawString(_Value, _Font, new SolidBrush(_TextColour), new Point(Width / 2, Height / 2 - 1), new StringFormat {
    //        //			Alignment = StringAlignment.Center,
    //        //			LineAlignment = StringAlignment.Center
    //        //		});
    //        //		break;
    //        //	case _Maximum:
    //        //		_with19.DrawArc(new Pen(new SolidBrush(_BorderColour), 1 + 6), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5);
    //        //		_with19.DrawArc(new Pen(new SolidBrush(_BaseColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle);
    //        //		_with19.DrawArc(new Pen(new SolidBrush(_ProgressColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle);
    //        //		_with19.DrawString(_Value, _Font, new SolidBrush(_TextColour), new Point(Width / 2, Height / 2 - 1), new StringFormat {
    //        //			Alignment = StringAlignment.Center,
    //        //			LineAlignment = StringAlignment.Center
    //        //		});
    //        //		break;
    //        //	default:
    //        //		_with19.DrawArc(new Pen(new SolidBrush(_BorderColour), 1 + 6), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle - 3, _RotationAngle + 5);
    //        //		_with19.DrawArc(new Pen(new SolidBrush(_BaseColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, _RotationAngle);
    //        //		_with19.DrawArc(new Pen(new SolidBrush(_ProgressColour), 1 + 3), Convert.ToInt32(3 / 2) + 1, Convert.ToInt32(3 / 2) + 1, Width - 3 - 4, Height - 3 - 3, _StartingAngle, Convert.ToInt32((_RotationAngle / _Maximum) * _Value));
    //        //		_with19.DrawString(_Value, _Font, new SolidBrush(_TextColour), new Point(Width / 2, Height / 2 - 1), new StringFormat {
    //        //			Alignment = StringAlignment.Center,
    //        //			LineAlignment = StringAlignment.Center
    //        //		});
    //        //		break;
    //        //} 
    //        #endregion

    //        base.OnPaint(e);
    //        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
    //        e.Graphics.DrawImageUnscaled(B, 0, 0);
    //        B.Dispose();
    //    }
    //    #endregion

    //} 
    #endregion

}


