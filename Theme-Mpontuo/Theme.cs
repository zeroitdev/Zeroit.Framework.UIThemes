﻿// ***********************************************************************
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
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.Mpontuo
{
    public abstract class Theme : ContainerControl
    {
        #region  Initialization 

        protected Graphics G;
        public Theme()
        {
            SetStyle((ControlStyles)139270, true);
        }

        private bool ParentIsForm;
        protected override void OnHandleCreated(EventArgs e)
        {
            Dock = DockStyle.Fill;
            ParentIsForm = Parent is System.Windows.Forms.Form;
            if (ParentIsForm)
            {
                if (!(_TransparencyKey == Color.Empty))
                {
                    ParentForm.TransparencyKey = _TransparencyKey;
                }
                ParentForm.FormBorderStyle = FormBorderStyle.None;
            }
            base.OnHandleCreated(e);
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }
        #endregion

        #region  Sizing and Movement 

        private bool _Resizable = true;
        public bool Resizable
        {
            get
            {
                return _Resizable;
            }
            set
            {
                _Resizable = value;
            }
        }

        private int _MoveHeight = 24;
        public int MoveHeight
        {
            get
            {
                return _MoveHeight;
            }
            set
            {
                _MoveHeight = value;
                Header = new Rectangle(7, 7, Width - 14, _MoveHeight - 7);
            }
        }

        private IntPtr Flag;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!(e.Button == MouseButtons.Left))
            {
                return;
            }
            if (ParentIsForm)
            {
                if (ParentForm.WindowState == FormWindowState.Maximized)
                {
                    return;
                }
            }

            if (Header.Contains(e.Location))
            {
                Flag = new IntPtr(2);
            }
            else if (Current.Position == 0 || !_Resizable)
            {
                return;
            }
            else
            {
                Flag = new IntPtr(Current.Position);
            }

            Capture = false;
            var m = Message.Create(Parent.Handle, 161, Flag, IntPtr.Zero);

            DefWndProc(ref m);

            base.OnMouseDown(e);
        }

        private struct Pointer
        {
            public readonly Cursor Cursor;
            public readonly byte Position;
            public Pointer(Cursor c, byte p) : this()
            {
                Cursor = c;
                Position = p;
            }
        }

        private bool F1;
        private bool F2;
        private bool F3;
        private bool F4;
        private Point PTC;
        private Pointer GetPointer()
        {
            PTC = PointToClient(MousePosition);
            F1 = PTC.X < 7;
            F2 = PTC.X > Width - 7;
            F3 = PTC.Y < 7;
            F4 = PTC.Y > Height - 7;

            if (F1 && F3)
            {
                return new Pointer(Cursors.SizeNWSE, 13);
            }
            if (F1 && F4)
            {
                return new Pointer(Cursors.SizeNESW, 16);
            }
            if (F2 && F3)
            {
                return new Pointer(Cursors.SizeNESW, 14);
            }
            if (F2 && F4)
            {
                return new Pointer(Cursors.SizeNWSE, 17);
            }
            if (F1)
            {
                return new Pointer(Cursors.SizeWE, 10);
            }
            if (F2)
            {
                return new Pointer(Cursors.SizeWE, 11);
            }
            if (F3)
            {
                return new Pointer(Cursors.SizeNS, 12);
            }
            if (F4)
            {
                return new Pointer(Cursors.SizeNS, 15);
            }
            return new Pointer(Cursors.Default, 0);
        }

        private Pointer Current;
        private Pointer Pending;
        private void SetCurrent()
        {
            Pending = GetPointer();
            if (Current.Position == Pending.Position)
            {
                return;
            }
            Current = GetPointer();
            Cursor = Current.Cursor;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_Resizable)
            {
                SetCurrent();
            }
            base.OnMouseMove(e);
        }

        protected Rectangle Header;
        protected override void OnSizeChanged(EventArgs e)
        {
            if (Width == 0 || Height == 0)
            {
                return;
            }
            Header = new Rectangle(7, 7, Width - 14, _MoveHeight - 7);
            Invalidate();
            base.OnSizeChanged(e);
        }

        #endregion

        #region  Convienence 

        public abstract void PaintHook();
        protected sealed override void OnPaint(PaintEventArgs e)
        {
            if (Width == 0 || Height == 0)
            {
                return;
            }
            G = e.Graphics;
            PaintHook();
        }

        private Color _TransparencyKey;
        public Color TransparencyKey
        {
            get
            {
                return _TransparencyKey;
            }
            set
            {
                _TransparencyKey = value;
                Invalidate();
            }
        }

        private Image _Image;
        public Image Image
        {
            get
            {
                return _Image;
            }
            set
            {
                _Image = value;
                Invalidate();
            }
        }
        public int ImageWidth
        {
            get
            {
                if (_Image == null)
                {
                    return 0;
                }
                return _Image.Width;
            }
        }

        private Size _Size;
        private Rectangle _Rectangle;
        private LinearGradientBrush _Gradient;
        private SolidBrush _Brush;

        protected void DrawCorners(Color c, Rectangle rect)
        {
            _Brush = new SolidBrush(c);
            G.FillRectangle(_Brush, rect.X, rect.Y, 1, 1);
            G.FillRectangle(_Brush, rect.X + (rect.Width - 1), rect.Y, 1, 1);
            G.FillRectangle(_Brush, rect.X, rect.Y + (rect.Height - 1), 1, 1);
            G.FillRectangle(_Brush, rect.X + (rect.Width - 1), rect.Y + (rect.Height - 1), 1, 1);
        }

        protected void DrawBorders(Pen p1, Pen p2, Rectangle rect)
        {
            G.DrawRectangle(p1, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
            G.DrawRectangle(p2, rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3);
        }

        protected void DrawText(HorizontalAlignment a, Color c, int x)
        {
            DrawText(a, c, x, 0);
        }
        protected void DrawText(HorizontalAlignment a, Color c, int x, int y)
        {
            if (string.IsNullOrEmpty(Text))
            {
                return;
            }
            _Size = G.MeasureString(Text, Font).ToSize();
            _Brush = new SolidBrush(c);

            switch (a)
            {
                case HorizontalAlignment.Left:
                    G.DrawString(Text, Font, _Brush, x, _MoveHeight / 2 - _Size.Height / 2 + y);
                    break;
                case HorizontalAlignment.Right:
                    G.DrawString(Text, Font, _Brush, Width - _Size.Width - x, _MoveHeight / 2 - _Size.Height / 2 + y);
                    break;
                case HorizontalAlignment.Center:
                    G.DrawString(Text, Font, _Brush, Convert.ToInt32(System.Math.Truncate((double)Width / (double)2) - _Size.Width / 2 + x), _MoveHeight / 2 - _Size.Height / 2 + y);
                    break;
            }
        }

        protected void DrawIcon(HorizontalAlignment a, int x)
        {
            DrawIcon(a, x, 0);
        }
        protected void DrawIcon(HorizontalAlignment a, int x, int y)
        {
            if (_Image == null)
            {
                return;
            }
            switch (a)
            {
                case HorizontalAlignment.Left:
                    G.DrawImage(_Image, x, _MoveHeight / 2 - _Image.Height / 2 + y);
                    break;
                case HorizontalAlignment.Right:
                    G.DrawImage(_Image, Width - _Image.Width - x, _MoveHeight / 2 - _Image.Height / 2 + y);
                    break;
                case HorizontalAlignment.Center:
                    G.DrawImage(_Image, Convert.ToInt32(Math.Truncate((double)Width / (double)2) - _Image.Width / 2), _MoveHeight / 2 - _Image.Height / 2);
                    break;
            }
        }

        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            _Rectangle = new Rectangle(x, y, width, height);
            _Gradient = new LinearGradientBrush(_Rectangle, c1, c2, angle);
            G.FillRectangle(_Gradient, _Rectangle);
        }

        #endregion

    }
    public abstract class ThemeControl : Control
    {
        private Dictionary<string, Color> Items = new Dictionary<string, Color>();
        #region  Initialization 
        public const string UITypeEditor = "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";
        public const string MultilineEditor = "System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";
        protected Graphics G;
        protected Bitmap B;
        public ThemeControl()
        {
            SetStyle((ControlStyles)139270, true);
            B = new Bitmap(1, 1);
            G = Graphics.FromImage(B);
        }

        public void AllowTransparent()
        {
            SetStyle(ControlStyles.Opaque, false);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }
        #endregion

        #region  Mouse Handling 

        protected enum State : byte
        {
            MouseNone = 0,
            MouseOver = 1,
            MouseDown = 2
        }

        protected State MouseState;
        protected override void OnMouseLeave(EventArgs e)
        {
            ChangeMouseState(State.MouseNone);
            base.OnMouseLeave(e);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            ChangeMouseState(State.MouseOver);
            base.OnMouseEnter(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            ChangeMouseState(State.MouseOver);
            base.OnMouseUp(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ChangeMouseState(State.MouseDown);
            }
            base.OnMouseDown(e);
        }

        protected Color GetColor(string name)
        {
            return Items[name];
        }

        protected void SetColor(string name, Color color)
        {
            if (Items.ContainsKey(name))
            {
                Items[name] = color;
            }
            else
            {
                Items.Add(name, color);
            }
        }
        protected void SetColor(string name, byte r, byte g, byte b)
        {
            SetColor(name, Color.FromArgb(r, g, b));
        }
        protected void SetColor(string name, byte a, byte r, byte g, byte b)
        {
            SetColor(name, Color.FromArgb(a, r, g, b));
        }
        protected void SetColor(string name, byte a, Color color)
        {
            SetColor(name, Color.FromArgb(a, color));
        }

        private void ChangeMouseState(State e)
        {
            MouseState = e;
            Invalidate();
        }

        #endregion

        #region  Convienence 

        public abstract void PaintHook();
        protected sealed override void OnPaint(PaintEventArgs e)
        {
            if (Width == 0 || Height == 0)
            {
                return;
            }
            PaintHook();
            e.Graphics.DrawImage(B, 0, 0);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!(Width == 0) && !(Height == 0))
            {
                B = new Bitmap(Width, Height);
                G = Graphics.FromImage(B);
                Invalidate();
            }
            base.OnSizeChanged(e);
        }

        private bool _NoRounding;
        public bool NoRounding
        {
            get
            {
                return _NoRounding;
            }
            set
            {
                _NoRounding = value;
                Invalidate();
            }
        }

        private Image _Image;
        public Image Image
        {
            get
            {
                return _Image;
            }
            set
            {
                _Image = value;
                Invalidate();
            }
        }
        public int ImageWidth
        {
            get
            {
                if (_Image == null)
                {
                    return 0;
                }
                return _Image.Width;
            }
        }
        public int ImageTop
        {
            get
            {
                if (_Image == null)
                {
                    return 0;
                }
                return Convert.ToInt32(Math.Truncate((double)Height / 2) - _Image.Height / 2);
            }
        }

        private Size _Size;
        private Rectangle _Rectangle;
        private LinearGradientBrush _Gradient;
        private SolidBrush _Brush;

        protected void DrawCorners(Color c, Rectangle rect)
        {
            if (_NoRounding)
            {
                return;
            }

            B.SetPixel(rect.X, rect.Y, c);
            B.SetPixel(rect.X + (rect.Width - 1), rect.Y, c);
            B.SetPixel(rect.X, rect.Y + (rect.Height - 1), c);
            B.SetPixel(rect.X + (rect.Width - 1), rect.Y + (rect.Height - 1), c);
        }

        protected void DrawBorders(Pen p1, Pen p2, Rectangle rect)
        {
            G.DrawRectangle(p1, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
            G.DrawRectangle(p2, rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3);
        }

        protected void DrawText(HorizontalAlignment a, Color c, int x)
        {
            DrawText(a, c, x, 0);
        }
        protected void DrawText(HorizontalAlignment a, Color c, int x, int y)
        {
            if (string.IsNullOrEmpty(Text))
            {
                return;
            }
            _Size = G.MeasureString(Text, Font).ToSize();
            _Brush = new SolidBrush(c);

            switch (a)
            {
                case HorizontalAlignment.Left:
                    G.DrawString(Text, Font, _Brush, x, Convert.ToInt32(Math.Truncate((double)Height / 2) - _Size.Height / 2 + y));
                    break;
                case HorizontalAlignment.Right:
                    G.DrawString(Text, Font, _Brush, Width - _Size.Width - x, (int)(Math.Truncate((double)Height / 2) - _Size.Height / 2 + y));
                    break;
                case HorizontalAlignment.Center:
                    G.DrawString(Text, Font, _Brush, (int)(Math.Truncate((double)Width / 2) - _Size.Width / 2 + x), (int)(Math.Truncate((double)Height / 2) - _Size.Height / 2 + y));
                    break;
            }
        }

        protected void DrawIcon(HorizontalAlignment a, int x)
        {
            DrawIcon(a, x, 0);
        }
        protected void DrawIcon(HorizontalAlignment a, int x, int y)
        {
            if (_Image == null)
            {
                return;
            }
            switch (a)
            {
                case HorizontalAlignment.Left:
                    G.DrawImage(_Image, x, (int)(Math.Truncate((double)Height / 2) - _Image.Height / 2 + y));
                    break;
                case HorizontalAlignment.Right:
                    G.DrawImage(_Image, Width - _Image.Width - x, (int)(Math.Truncate((double)Height / 2) - _Image.Height / 2 + y));
                    break;
                case HorizontalAlignment.Center:
                    G.DrawImage(_Image, (int)(Math.Truncate((double)Width / 2) - _Image.Width / 2), (int)(Math.Truncate((double)Height / 2) - _Image.Height / 2));
                    break;
            }
        }

        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            _Rectangle = new Rectangle(x, y, width - 2, height);
            _Gradient = new LinearGradientBrush(_Rectangle, c1, c2, angle);
            G.FillRectangle(_Gradient, _Rectangle);
        }
        #endregion

    }
    public abstract class ThemeContainerControl : ContainerControl
    {
        #region  Initialization 

        protected Graphics G;
        protected Bitmap B;
        public ThemeContainerControl()
        {
            SetStyle((ControlStyles)139270, true);
            B = new Bitmap(1, 1);
            G = Graphics.FromImage(B);
        }

        public void AllowTransparent()
        {
            SetStyle(ControlStyles.Opaque, false);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        #endregion

        #region  Convienence 

        public abstract void PaintHook();
        protected sealed override void OnPaint(PaintEventArgs e)
        {
            if (Width == 0 || Height == 0)
            {
                return;
            }
            PaintHook();
            e.Graphics.DrawImage(B, 0, 0);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!(Width == 0) && !(Height == 0))
            {
                B = new Bitmap(Width, Height);
                G = Graphics.FromImage(B);
                Invalidate();
            }
            base.OnSizeChanged(e);
        }

        private bool _NoRounding;
        public bool NoRounding
        {
            get
            {
                return _NoRounding;
            }
            set
            {
                _NoRounding = value;
                Invalidate();
            }
        }

        private Rectangle _Rectangle;
        private LinearGradientBrush _Gradient;

        protected void DrawCorners(Color c, Rectangle rect)
        {
            if (_NoRounding)
            {
                return;
            }
            B.SetPixel(rect.X, rect.Y, c);
            B.SetPixel(rect.X + (rect.Width - 1), rect.Y, c);
            B.SetPixel(rect.X, rect.Y + (rect.Height - 1), c);
            B.SetPixel(rect.X + (rect.Width - 1), rect.Y + (rect.Height - 1), c);
        }

        protected void DrawBorders(Pen p1, Pen p2, Rectangle rect)
        {

            G.DrawRectangle(p2, rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3);
        }

        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            _Rectangle = new Rectangle(x, y, width, height);
            _Gradient = new LinearGradientBrush(_Rectangle, c1, c2, angle);
            G.FillRectangle(_Gradient, _Rectangle);
        }
        #endregion

    }

    [DefaultEvent("Load")]
    public class MpontuoTheme : Theme
    {
        public MpontuoTheme()
        {
            MoveHeight = 20;
            TransparencyKey = Color.Fuchsia;
            ForeColor = Color.FromArgb(66, 130, 181);
            BackColor = Color.FromArgb(40, 40, 40);
            Font F = new Font("Verdana", 8);
            Font = F;
            this.Resizable = true;
            SubscribeToEvents();
        }
        public delegate void LoadEventHandler();
        public event LoadEventHandler Load;
        public delegate void ClosingEventHandler();
        public event ClosingEventHandler Closing;
        private MpontuoMenuButton Close = new MpontuoMenuButton();
        private MpontuoMenuButton Minimise = new MpontuoMenuButton();
        private Color BGColor = Color.FromArgb(40, 40, 40);
        private Color G1 = Color.FromArgb(65, 65, 65);
        private Color G2 = Color.FromArgb(30, 30, 30);
        private Color F = Color.Fuchsia;
        private Pen Seperator = new Pen(Color.Black);
        private Pen B = Pens.Black;
        private Bitmap i = new Bitmap(20, 20);
        private Icon j;
        private bool[] Bools = new bool[] { false, true, true, true, true }; //Icon (once), Icon (multi), Load (once), minimise, close
        public override void PaintHook()
        {
            
    
        G.Clear(BGColor); //Background
            if (Bools[1])
            {
                j = ParentForm.Icon;
                Bools[0] = true;
                Bools[1] = false;
            }
            DrawGradient(G1, G2, 0, 0, Width, 20, 90); //Menu Bar
            G.DrawLine(Seperator, 0, 20, Width, 20); //Menu bar seperator line
            if (Bools[0])
            {
                var a = Graphics.FromImage(i);
                Rectangle fh = new Rectangle(0, 0, 20, 20);
                LinearGradientBrush gr = new LinearGradientBrush(fh, G1, G2, 90);
                a.FillRectangle(gr, fh);
                a.DrawImage(j.ToBitmap(), 0, 0, 18, 18);
                Bools[0] = false;
                ParentForm.Icon = j;
            }
            G.DrawImage(Image.FromHbitmap(i.GetHbitmap()), 0, 0);
            G.DrawRectangle(B, ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1); //Border
            DrawCorners(F, ClientRectangle); //Form corners
            DrawText(HorizontalAlignment.Left, ForeColor, 20); //Menu bar's text
            Parent.Text = this.Text;
            if (Bools[4])
            {
                Close.Show();
                Close.Size = new Size(20, 20);
                Close.Location = new Point(Width - 23, 0);
                Close.Text = "X";
                Close.Parent = this;
            }
            else
            {
                Close.Hide();
            }
            if (Bools[3])
            {
                Minimise.Show();
                Minimise.Size = new Size(20, 20);
                Minimise.Location = new Point(Width - 42, 0);
                Minimise.Text = "_";
                Minimise.Parent = this;
            }
            else
            {
                Minimise.Hide();
            }
        }


        public Icon icon
        {
            get
            {
                return j;
            }
            set
            {
                j = value;
                Bools[0] = true;
                Invalidate();
            }
        }

        public bool minimisebutton
        {
            get
            {
                return Bools[3];
            }
            set
            {
                Bools[3] = value;
                Invalidate();
            }
        }

        public bool closebutton
        {
            get
            {
                return Bools[4];
            }
            set
            {
                Bools[4] = value;
                Invalidate();
            }
        }

        private void a(object sender, EventArgs e)
        {
            if (Bools[2])
            {
                if (Load != null)
                    Load();
                Bools[2] = false;
            }
        }

        private void c(object sender, EventArgs e)
        {
            if (Closing != null)
                Closing();
            System.Environment.Exit(1);
        }

        private void d(object sender, EventArgs e)
        {
            ParentForm.WindowState = FormWindowState.Minimized;
        }


        
        private bool EventsSubscribed = false;
        private void SubscribeToEvents()
        {
            if (EventsSubscribed)
                return;
            else
                EventsSubscribed = true;

            this.Invalidated += a;
            Close.Click += c;
            Minimise.Click += d;
        }

    }
    
    
}

