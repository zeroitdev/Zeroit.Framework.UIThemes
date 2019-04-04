// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Theme.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using static Zeroit.Framework.UIThemes.Login.DrawHelpers;

namespace Zeroit.Framework.UIThemes.Login
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
    public class LogInThemeContainer : ContainerControl
    {

        #region "Declarations"
        private __CloseChoice _CloseChoice = __CloseChoice.Form;
        private int _FontSize = 12;
        private readonly Font _Font;
        private int MouseXLoc;
        private int MouseYLoc;
        private bool CaptureMovement = false;
        private const int MoveHeight = 35;
        private Point MouseP = new Point(0, 0);
        private Color _FontColour = Color.FromArgb(255, 255, 255);
        private Color _BaseColour = Color.FromArgb(35, 35, 35);
        private Color _ContainerColour = Color.FromArgb(54, 54, 54);
        private Color _BorderColour = Color.FromArgb(60, 60, 60);
        #endregion
        private Color _HoverColour = Color.FromArgb(42, 42, 42);

        #region "Size Handling"

        private int _LockWidth;
        protected int LockWidth
        {
            get { return _LockWidth; }
            set
            {
                _LockWidth = value;
                if (!(LockWidth == 0) && IsHandleCreated)
                    Width = LockWidth;
            }
        }

        private int _LockHeight;
        protected int LockHeight
        {
            get { return _LockHeight; }
            set
            {
                _LockHeight = value;
                if (!(LockHeight == 0) && IsHandleCreated)
                    Height = LockHeight;
            }
        }

        private Rectangle Frame;
        protected override sealed void OnSizeChanged(EventArgs e)
        {
            if (_Movable && !_ControlMode)
            {
                Frame = new Rectangle(7, 7, Width - 14, 35);
            }

            Invalidate();

            base.OnSizeChanged(e);
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (!(_LockWidth == 0))
                width = _LockWidth;
            if (!(_LockHeight == 0))
                height = _LockHeight;
            base.SetBoundsCore(x, y, width, height, specified);
        }

        #endregion

        #region "State Handling"

        private MouseState State = MouseState.None;
        private void SetState(MouseState current)
        {
            State = current;
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!(_IsParentForm && ParentForm.WindowState == FormWindowState.Maximized))
            {
                if (_Sizable && !_ControlMode)
                    InvalidateMouse();
            }
            base.OnMouseMove(e);
            SetState(MouseState.Over);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (Enabled)
                SetState(MouseState.None);
            else
                SetState(MouseState.Block);
            base.OnEnabledChanged(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            SetState(MouseState.Over);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            SetState(MouseState.Over);
            base.OnMouseUp(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            SetState(MouseState.None);
            if (GetChildAtPoint(PointToClient(MousePosition)) != null)
            {
                if (_Sizable && !_ControlMode)
                {
                    Cursor = Cursors.Default;
                    Previous = 0;
                }
            }
            base.OnMouseLeave(e);
        }

        private Point GetMouseLocation;
        private Size OldSize;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                SetState(MouseState.Down);
            if (!(_IsParentForm && ParentForm.WindowState == FormWindowState.Maximized || _ControlMode))
            {
                if (_Movable && Frame.Contains(e.Location))
                {
                    Capture = false;
                    WM_LMBUTTONDOWN = true;
                    DefWndProc(ref Messages[0]);
                }
                else if (_Sizable && !(Previous == 0))
                {
                    Capture = false;
                    WM_LMBUTTONDOWN = true;
                    DefWndProc(ref Messages[Previous]);
                }
            }
            GetMouseLocation = PointToClient(MousePosition);
            if (GetMouseLocation.X > Width - 39 && GetMouseLocation.X < Width - 16 && GetMouseLocation.Y < 22)
            {
                if (_AllowClose)
                {
                    if (_CloseChoice == __CloseChoice.Application)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        ParentForm.Close();
                    }
                }
            }
            else if (GetMouseLocation.X > Width - 64 && GetMouseLocation.X < Width - 41 && GetMouseLocation.Y < 22)
            {
                if (_AllowMaximize)
                {
                    switch (Parent.FindForm().WindowState)
                    {
                        case FormWindowState.Maximized:
                            Parent.FindForm().WindowState = FormWindowState.Normal;
                            break;
                        case FormWindowState.Normal:
                            OldSize = Size;
                            Parent.FindForm().WindowState = FormWindowState.Maximized;
                            break;
                    }
                }
            }
            else if (GetMouseLocation.X > Width - 89 && GetMouseLocation.X < Width - 66 && GetMouseLocation.Y < 22)
            {
                if (_AllowMinimize)
                {
                    switch (Parent.FindForm().WindowState)
                    {
                        case FormWindowState.Normal:
                            OldSize = Size;
                            Parent.FindForm().WindowState = FormWindowState.Minimized;
                            break;
                        case FormWindowState.Maximized:
                            Parent.FindForm().WindowState = FormWindowState.Minimized;
                            break;
                    }
                }
            }
            base.OnMouseDown(e);
        }

        private Message[] Messages = new Message[9];
        private void InitializeMessages()
        {
            Messages[0] = Message.Create(Parent.Handle, 161, new IntPtr(2), IntPtr.Zero);
            for (int I = 1; I <= 8; I++)
            {
                Messages[I] = Message.Create(Parent.Handle, 161, new IntPtr(I + 9), IntPtr.Zero);
            }
        }

        private Point GetIndexPoint;
        private bool B1;
        private bool B2;
        private bool B3;
        private bool B4;
        private int GetMouseIndex()
        {
            GetIndexPoint = PointToClient(MousePosition);
            B1 = GetIndexPoint.X < 6;
            B2 = GetIndexPoint.X > Width - 6;
            B3 = GetIndexPoint.Y < 6;
            B4 = GetIndexPoint.Y > Height - 6;
            if (B1 && B3)
                return 4;
            if (B1 && B4)
                return 7;
            if (B2 && B3)
                return 5;
            if (B2 && B4)
                return 8;
            if (B1)
                return 1;
            if (B2)
                return 2;
            if (B3)
                return 3;
            if (B4)
                return 6;
            return 0;
        }

        private int Current;
        private int Previous;
        private void InvalidateMouse()
        {
            Current = GetMouseIndex();
            if (Current == Previous)
                return;
            Previous = Current;
            switch (Previous)
            {
                case 0:
                    Cursor = Cursors.Default;
                    break;
                case 1:
                case 2:
                    Cursor = Cursors.SizeWE;
                    break;
                case 3:
                case 6:
                    Cursor = Cursors.SizeNS;
                    break;
                case 4:
                case 8:
                    Cursor = Cursors.SizeNWSE;
                    break;
                case 5:
                case 7:
                    Cursor = Cursors.SizeNESW;
                    break;
            }
        }

        private bool WM_LMBUTTONDOWN;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (WM_LMBUTTONDOWN && m.Msg == 513)
            {
                WM_LMBUTTONDOWN = false;

                SetState(MouseState.Over);
                if (!_SmartBounds)
                    return;

                if (IsParentMdi)
                {
                    CorrectBounds(new Rectangle(Point.Empty, Parent.Parent.Size));
                }
                else
                {
                    try
                    {
                        CorrectBounds(Screen.FromControl(Parent).WorkingArea);
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void CorrectBounds(Rectangle bounds)
        {
            if (Parent.Width > bounds.Width)
                Parent.Width = bounds.Width;
            if (Parent.Height > bounds.Height)
                Parent.Height = bounds.Height;
            int X = Parent.Location.X;
            int Y = Parent.Location.Y;
            if (X < bounds.X)
                X = bounds.X;
            if (Y < bounds.Y)
                Y = bounds.Y;
            int Width = bounds.X + bounds.Width;
            int Height = bounds.Y + bounds.Height;
            if (X + Parent.Width > Width)
                X = Width - Parent.Width;
            if (Y + Parent.Height > Height)
                Y = Height - Parent.Height;
            //'Weird allows proper full screen
            //  Parent.Size = New Size(Width, Height)
            if (Parent.FindForm().WindowState == FormWindowState.Maximized | Parent.FindForm().WindowState == FormWindowState.Minimized)
            {
                Parent.Size = OldSize;
            }
        }

        protected override sealed void OnHandleCreated(EventArgs e)
        {
            if (!(_LockWidth == 0))
                Width = _LockWidth;
            if (!(_LockHeight == 0))
                Height = _LockHeight;
            if (!_ControlMode)
                base.Dock = DockStyle.Fill;
        }

        protected override sealed void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (Parent == null)
                return;
            _IsParentForm = Parent is System.Windows.Forms.Form;
            if (!_ControlMode)
            {
                InitializeMessages();
                Parent.BackColor = BackColor;
            }
        }

        #endregion

        #region "Properties"

        public enum __CloseChoice
        {
            Form,
            Application
        }
        public __CloseChoice CloseChoice
        {
            get { return _CloseChoice; }
            set { _CloseChoice = value; }
        }

        private bool _Movable = true;
        public bool Movable
        {
            get { return _Movable; }
            set { _Movable = value; }
        }

        private bool _Sizable = true;
        public bool Sizable
        {
            get { return _Sizable; }
            set { _Sizable = value; }
        }

        private bool _ControlMode;
        protected bool ControlMode
        {
            get { return _ControlMode; }
            set
            {
                _ControlMode = value;

                Invalidate();
            }
        }

        private bool _SmartBounds = true;
        public bool SmartBounds
        {
            get { return _SmartBounds; }
            set { _SmartBounds = value; }
        }

        private bool _IsParentForm;
        protected bool IsParentForm
        {
            get { return _IsParentForm; }
        }

        protected bool IsParentMdi
        {
            get
            {
                if (Parent == null)
                    return false;
                return Parent.Parent != null;
            }
        }

        [Category("Control")]
        public int FontSize
        {
            get { return _FontSize; }
            set { _FontSize = value; }
        }

        private bool _AllowMinimize = true;
        [Category("Control")]
        public bool AllowMinimize
        {
            get { return _AllowMinimize; }
            set { _AllowMinimize = value; }
        }

        private bool _AllowMaximize = true;
        [Category("Control")]
        public bool AllowMaximize
        {
            get { return _AllowMaximize; }
            set { _AllowMaximize = value; }
        }

        private bool _ShowIcon = true;
        [Category("Control")]
        public bool ShowIcon
        {
            get { return _ShowIcon; }
            set
            {
                _ShowIcon = value;
                Invalidate();
            }
        }

        private bool _AllowClose = true;
        [Category("Control")]
        public bool AllowClose
        {
            get { return _AllowClose; }
            set { _AllowClose = value; }
        }

        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }

        [Category("Colours")]
        public Color HoverColour
        {
            get { return _HoverColour; }
            set { _HoverColour = value; }
        }

        [Category("Colours")]
        public Color BaseColour
        {
            get { return _BaseColour; }
            set { _BaseColour = value; }
        }

        [Category("Colours")]
        public Color ContainerColour
        {
            get { return _ContainerColour; }
            set { _ContainerColour = value; }
        }

        [Category("Colours")]
        public Color FontColour
        {
            get { return _FontColour; }
            set { _FontColour = value; }
        }

        #endregion

        #region "Draw Control"

        public LogInThemeContainer()
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
            Graphics G = e.Graphics;
            var _with2 = G;
            _with2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with2.SmoothingMode = SmoothingMode.HighQuality;
            _with2.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with2.FillRectangle(new SolidBrush(_BaseColour), new Rectangle(0, 0, Width, Height));
            _with2.FillRectangle(new SolidBrush(_ContainerColour), new Rectangle(2, 35, Width - 4, Height - 37));
            _with2.DrawRectangle(new Pen(_BorderColour), new Rectangle(0, 0, Width, Height));
            Point[] ControlBoxPoints = {
            new Point(Width - 90, 0),
            new Point(Width - 90, 22),
            new Point(Width - 15, 22),
            new Point(Width - 15, 0)
        };
            _with2.DrawLines(new Pen(_BorderColour), ControlBoxPoints);
            _with2.DrawLine(new Pen(_BorderColour), Width - 65, 0, Width - 65, 22);
            GetMouseLocation = PointToClient(MousePosition);
            switch (State)
            {
                case MouseState.Over:
                    if (GetMouseLocation.X > Width - 39 && GetMouseLocation.X < Width - 16 && GetMouseLocation.Y < 22)
                    {
                        _with2.FillRectangle(new SolidBrush(_HoverColour), new Rectangle(Width - 39, 0, 23, 22));
                    }
                    else if (GetMouseLocation.X > Width - 64 && GetMouseLocation.X < Width - 41 && GetMouseLocation.Y < 22)
                    {
                        _with2.FillRectangle(new SolidBrush(_HoverColour), new Rectangle(Width - 64, 0, 23, 22));
                    }
                    else if (GetMouseLocation.X > Width - 89 && GetMouseLocation.X < Width - 66 && GetMouseLocation.Y < 22)
                    {
                        _with2.FillRectangle(new SolidBrush(_HoverColour), new Rectangle(Width - 89, 0, 23, 22));
                    }
                    break;
            }
            _with2.DrawLine(new Pen(_BorderColour), Width - 40, 0, Width - 40, 22);
            //'Close Button
            _with2.DrawLine(new Pen(_FontColour, 2), Width - 33, 6, Width - 22, 16);
            _with2.DrawLine(new Pen(_FontColour, 2), Width - 33, 16, Width - 22, 6);
            //'Minimize Button
            _with2.DrawLine(new Pen(_FontColour), Width - 83, 16, Width - 72, 16);
            //'Maximize Button
            _with2.DrawLine(new Pen(_FontColour), Width - 58, 16, Width - 47, 16);
            _with2.DrawLine(new Pen(_FontColour), Width - 58, 16, Width - 58, 6);
            _with2.DrawLine(new Pen(_FontColour), Width - 47, 16, Width - 47, 6);
            _with2.DrawLine(new Pen(_FontColour), Width - 58, 6, Width - 47, 6);
            _with2.DrawLine(new Pen(_FontColour), Width - 58, 7, Width - 47, 7);
            if (_ShowIcon)
            {
                _with2.DrawIcon(Parent.FindForm().Icon, new Rectangle(6, 6, 22, 22));
                _with2.DrawString(Text, _Font, new SolidBrush(_FontColour), new RectangleF(31, 0, Width - 110, 35), new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Near
                });
            }
            else
            {
                _with2.DrawString(Text, _Font, new SolidBrush(_FontColour), new RectangleF(4, 0, Width - 110, 35), new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Near
                });
            }
            _with2.InterpolationMode = (InterpolationMode)7;
        }

        #endregion

    }
    
        

}


