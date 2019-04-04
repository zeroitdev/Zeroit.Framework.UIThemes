// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="J Theme.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.Form.UIThemes.Jasta
{
    
    #region Theme Base

    #region Imports



    #endregion


    
    public enum MouseState : byte
    {
        None = 0,
        Over = 1,
        Down = 2,
        Block = 3
    }

    public class Bloom
    {

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private Color _Value;
        public Color Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        public Bloom()
        {
        }

        public Bloom(string name, Color value)
        {
            _Name = name;
            _Value = value;
        }
    }

    public abstract class ThemeContainer151 : ContainerControl
    {


        protected Graphics G;
        public ThemeContainer151()
        {
            SetStyle((ControlStyles)139270, true);
            _ImageSize = Size.Empty;

            MeasureBitmap = new Bitmap(1, 1);
            MeasureGraphics = Graphics.FromImage(MeasureBitmap);

            Font = new Font("Verdana", 8);

            InvalidateCustimization();
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (!(_LockWidth == 0))
                width = _LockWidth;
            if (!(_LockHeight == 0))
                height = _LockHeight;
            base.SetBoundsCore(x, y, width, height, specified);
        }

        private Rectangle Header;
        protected override sealed void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (_Movable && !_ControlMode)
                Header = new Rectangle(7, 7, Width - 14, _MoveHeight - 7);
            Invalidate();
        }

        protected override sealed void OnPaint(PaintEventArgs e)
        {
            if (Width == 0 || Height == 0)
                return;
            G = e.Graphics;
            PaintHook();
        }

        protected override sealed void OnHandleCreated(EventArgs e)
        {
            InitializeMessages();
            InvalidateCustimization();
            ColorHook();

            _IsParentForm = Parent is System.Windows.Forms.Form;
            if (!_ControlMode)
                Dock = DockStyle.Fill;

            if (!(_LockWidth == 0))
                Width = _LockWidth;
            if (!(_LockHeight == 0))
                Height = _LockHeight;
            if (!(BackColorWait == null))
                BackColor = BackColorWait;

            if (_IsParentForm && !_ControlMode)
            {
                ParentForm.FormBorderStyle = _BorderStyle;
                ParentForm.TransparencyKey = _TransparencyKey;
            }

            OnCreation();
            base.OnHandleCreated(e);
        }

        protected virtual void OnCreation()
        {
        }

        #region " Sizing and Movement "

        protected MouseState State;
        private void SetState(MouseState current)
        {
            State = current;
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_Sizable && !_ControlMode)
                InvalidateMouse();
            base.OnMouseMove(e);
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

            if (_Sizable && !_ControlMode && GetChildAtPoint(PointToClient(MousePosition)) != null)
            {
                Cursor = Cursors.Default;
                Previous = 0;
            }

            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (!(e.Button == System.Windows.Forms.MouseButtons.Left))
                return;
            SetState(MouseState.Down);

            if (_IsParentForm && ParentForm.WindowState == FormWindowState.Maximized || _ControlMode)
                return;

            if (_Movable && Header.Contains(e.Location))
            {
                Capture = false;
                DefWndProc(ref Messages[0]);
            }
            else if (_Sizable && !(Previous == 0))
            {
                Capture = false;
                DefWndProc(ref Messages[Previous]);
            }
        }

        private Point GetIndexPoint;
        private bool B1;
        private bool B2;
        private bool B3;
        private bool B4;
        private int GetIndex()
        {
            GetIndexPoint = PointToClient(MousePosition);
            B1 = GetIndexPoint.X < 7;
            B2 = GetIndexPoint.X > Width - 7;
            B3 = GetIndexPoint.Y < 7;
            B4 = GetIndexPoint.Y > Height - 7;

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
            Current = GetIndex();
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

        private Message[] Messages = new Message[9];
        private void InitializeMessages()
        {
            Messages[0] = Message.Create(Parent.Handle, 161, new IntPtr(2), IntPtr.Zero);
            for (int I = 1; I <= 8; I++)
            {
                Messages[I] = Message.Create(Parent.Handle, 161, new IntPtr(I + 9), IntPtr.Zero);
            }
        }

        #endregion


        #region " Property Overrides "

        private Color BackColorWait;
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                if (IsHandleCreated)
                {
                    if (!_ControlMode)
                        Parent.BackColor = value;
                    base.BackColor = value;
                }
                else
                {
                    BackColorWait = value;
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ForeColor
        {
            get { return Color.Empty; }
            set { }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Image BackgroundImage
        {
            get { return null; }
            set { }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ImageLayout BackgroundImageLayout
        {
            get { return ImageLayout.None; }
            set { }
        }

        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                Invalidate();
            }
        }

        #endregion

        #region " Properties "

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

        private int _MoveHeight = 24;
        protected int MoveHeight
        {
            get { return _MoveHeight; }
            set
            {
                if (value < 8)
                    return;
                Header = new Rectangle(7, 7, Width - 14, value - 7);
                _MoveHeight = value;
                Invalidate();
            }
        }

        private bool _ControlMode;
        protected bool ControlMode
        {
            get { return _ControlMode; }
            set { _ControlMode = value; }
        }

        private Color _TransparencyKey;
        public Color TransparencyKey
        {
            get
            {
                if (_IsParentForm && !_ControlMode)
                    return ParentForm.TransparencyKey;
                else
                    return _TransparencyKey;
            }
            set
            {
                if (_IsParentForm && !_ControlMode)
                    ParentForm.TransparencyKey = value;
                _TransparencyKey = value;
            }
        }

        private FormBorderStyle _BorderStyle;
        public FormBorderStyle BorderStyle
        {
            get
            {
                if (_IsParentForm && !_ControlMode)
                    return ParentForm.FormBorderStyle;
                else
                    return _BorderStyle;
            }
            set
            {
                if (_IsParentForm && !_ControlMode)
                    ParentForm.FormBorderStyle = value;
                _BorderStyle = value;
            }
        }

        private bool _NoRounding;
        public bool NoRounding
        {
            get { return _NoRounding; }
            set
            {
                _NoRounding = value;
                Invalidate();
            }
        }

        private Image _Image;
        public Image Image
        {
            get { return _Image; }
            set
            {
                if (value == null)
                {
                    _ImageSize = Size.Empty;
                }
                else
                {
                    _ImageSize = value.Size;
                }

                _Image = value;
                Invalidate();
            }
        }

        private Size _ImageSize;
        protected Size ImageSize
        {
            get
            {
                return _ImageSize;
            }
        }

        private bool _IsParentForm;
        protected bool IsParentForm
        {
            get { return _IsParentForm; }
        }

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

        private Dictionary<string, Color> Items = new Dictionary<string, Color>();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Bloom[] Colors
        {
            get
            {
                List<Bloom> T = new List<Bloom>();
                Dictionary<string, Color>.Enumerator E = Items.GetEnumerator();

                while (E.MoveNext())
                {
                    T.Add(new Bloom(E.Current.Key, E.Current.Value));
                }

                return T.ToArray();
            }
            set
            {
                foreach (Bloom B in value)
                {
                    if (Items.ContainsKey(B.Name))
                        Items[B.Name] = B.Value;
                }

                InvalidateCustimization();
                ColorHook();
                Invalidate();
            }
        }

        private string _Customization;
        public string Customization
        {
            get { return _Customization; }
            set
            {
                if (value == _Customization)
                    return;

                byte[] Data = null;
                Bloom[] Items = Colors;

                try
                {
                    Data = Convert.FromBase64String(value);
                    for (int I = 0; I <= Items.Length - 1; I++)
                    {
                        Items[I].Value = Color.FromArgb(BitConverter.ToInt32(Data, I * 4));
                    }
                }
                catch
                {
                    return;
                }

                _Customization = value;

                Colors = Items;
                ColorHook();
                Invalidate();
            }
        }

        #endregion

        #region " Property Helpers "

        protected Color GetColor(string name)
        {
            return Items[name];
        }

        protected void SetColor(string name, Color color)
        {
            if (Items.ContainsKey(name))
                Items[name] = color;
            else
                Items.Add(name, color);
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

        private void InvalidateCustimization()
        {
            MemoryStream M = new MemoryStream(Items.Count * 4);

            foreach (Bloom B in Colors)
            {
                M.Write(BitConverter.GetBytes(B.Value.ToArgb()), 0, 4);
            }

            M.Close();
            _Customization = Convert.ToBase64String(M.ToArray());
        }

        #endregion


        #region " User Hooks "

        protected abstract void ColorHook();
        protected abstract void PaintHook();

        #endregion


        #region " Center Overloads "


        private Point CenterReturn;
        protected Point Center(Rectangle r1, Size s1)
        {
            CenterReturn = new Point((r1.Width / 2 - s1.Width / 2) + r1.X, (r1.Height / 2 - s1.Height / 2) + r1.Y);
            return CenterReturn;
        }
        protected Point Center(Rectangle r1, Rectangle r2)
        {
            return Center(r1, r2.Size);
        }

        protected Point Center(int w1, int h1, int w2, int h2)
        {
            CenterReturn = new Point(w1 / 2 - w2 / 2, h1 / 2 - h2 / 2);
            return CenterReturn;
        }

        protected Point Center(Size s1, Size s2)
        {
            return Center(s1.Width, s1.Height, s2.Width, s2.Height);
        }

        protected Point Center(Rectangle r1)
        {
            return Center(ClientRectangle.Width, ClientRectangle.Height, r1.Width, r1.Height);
        }
        protected Point Center(Size s1)
        {
            return Center(Width, Height, s1.Width, s1.Height);
        }
        protected Point Center(int w1, int h1)
        {
            return Center(Width, Height, w1, h1);
        }

        #endregion

        #region " Measure Overloads "

        private Bitmap MeasureBitmap;

        private Graphics MeasureGraphics;
        protected Size Measure(string text)
        {
            return MeasureGraphics.MeasureString(text, Font, Width).ToSize();
        }
        protected Size Measure()
        {
            return MeasureGraphics.MeasureString(Text, Font).ToSize();
        }

        #endregion

        #region " DrawCorners Overloads "

        //TODO: Optimize by checking brush color


        private SolidBrush DrawCornersBrush;
        protected void DrawCorners(Color c1)
        {
            DrawCorners(c1, 0, 0, Width, Height);
        }
        protected void DrawCorners(Color c1, Rectangle r1)
        {
            DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height);
        }
        protected void DrawCorners(Color c1, int x, int y, int width, int height)
        {
            if (_NoRounding)
                return;

            DrawCornersBrush = new SolidBrush(c1);
            G.FillRectangle(DrawCornersBrush, x, y, 1, 1);
            G.FillRectangle(DrawCornersBrush, x + (width - 1), y, 1, 1);
            G.FillRectangle(DrawCornersBrush, x, y + (height - 1), 1, 1);
            G.FillRectangle(DrawCornersBrush, x + (width - 1), y + (height - 1), 1, 1);
        }

        #endregion

        #region " DrawBorders Overloads "

        //TODO: Remove triple overload?

        protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset)
        {
            DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
        }
        protected void DrawBorders(Pen p1, int offset)
        {
            DrawBorders(p1, 0, 0, Width, Height, offset);
        }
        protected void DrawBorders(Pen p1, Rectangle r, int offset)
        {
            DrawBorders(p1, r.X, r.Y, r.Width, r.Height, offset);
        }

        protected void DrawBorders(Pen p1, int x, int y, int width, int height)
        {
            G.DrawRectangle(p1, x, y, width - 1, height - 1);
        }
        protected void DrawBorders(Pen p1)
        {
            DrawBorders(p1, 0, 0, Width, Height);
        }
        protected void DrawBorders(Pen p1, Rectangle r)
        {
            DrawBorders(p1, r.X, r.Y, r.Width, r.Height);
        }

        #endregion

        #region " DrawText Overloads "

        //TODO: Remove triple overloads?

        private Point DrawTextPoint;

        private Size DrawTextSize;
        protected void DrawText(Brush b1, HorizontalAlignment a, int x, int y)
        {
            DrawText(b1, Text, a, x, y);
        }
        protected void DrawText(Brush b1, Point p1)
        {
            DrawText(b1, Text, p1.X, p1.Y);
        }
        protected void DrawText(Brush b1, int x, int y)
        {
            DrawText(b1, Text, x, y);
        }

        protected void DrawText(Brush b1, string text, HorizontalAlignment a, int x, int y)
        {
            if (text.Length == 0)
                return;
            DrawTextSize = Measure(text);
            DrawTextPoint = new Point(Width / 2 - DrawTextSize.Width / 2, MoveHeight / 2 - DrawTextSize.Height / 2);

            switch (a)
            {
                case HorizontalAlignment.Left:
                    DrawText(b1, text, x, DrawTextPoint.Y + y);
                    break;
                case HorizontalAlignment.Center:
                    DrawText(b1, text, DrawTextPoint.X + x, DrawTextPoint.Y + y);
                    break;
                case HorizontalAlignment.Right:
                    DrawText(b1, text, Width - DrawTextSize.Width - x, DrawTextPoint.Y + y);
                    break;
            }
        }
        protected void DrawText(Brush b1, string text, Point p1)
        {
            DrawText(b1, text, p1.X, p1.Y);
        }
        protected void DrawText(Brush b1, string text, int x, int y)
        {
            if (text.Length == 0)
                return;
            G.DrawString(text, Font, b1, x, y);
        }

        #endregion

        #region " DrawImage Overloads "

        //TODO: Remove triple overloads?


        private Point DrawImagePoint;
        protected void DrawImage(HorizontalAlignment a, int x, int y)
        {
            DrawImage(_Image, a, x, y);
        }
        protected void DrawImage(Point p1)
        {
            DrawImage(_Image, p1.X, p1.Y);
        }
        protected void DrawImage(int x, int y)
        {
            DrawImage(_Image, x, y);
        }

        protected void DrawImage(Image image, HorizontalAlignment a, int x, int y)
        {
            if (image == null)
                return;
            DrawImagePoint = new Point(Width / 2 - image.Width / 2, MoveHeight / 2 - image.Height / 2);

            switch (a)
            {
                case HorizontalAlignment.Left:
                    DrawImage(image, x, DrawImagePoint.Y + y);
                    break;
                case HorizontalAlignment.Center:
                    DrawImage(image, DrawImagePoint.X + x, DrawImagePoint.Y + y);
                    break;
                case HorizontalAlignment.Right:
                    DrawImage(image, Width - image.Width - x, DrawImagePoint.Y + y);
                    break;
            }
        }
        protected void DrawImage(Image image, Point p1)
        {
            DrawImage(image, p1.X, p1.Y);
        }
        protected void DrawImage(Image image, int x, int y)
        {
            if (image == null)
                return;
            G.DrawImage(image, x, y, image.Width, image.Height);
        }

        #endregion

        #region " DrawGradient Overloads "

        //TODO: Remove triple overload?

        private LinearGradientBrush DrawGradientBrush;

        private Rectangle DrawGradientRectangle;
        protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height)
        {
            DrawGradient(blend, x, y, width, height, 90);
        }
        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height)
        {
            DrawGradient(c1, c2, x, y, width, height, 90);
        }

        protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height, float angle)
        {
            DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradient(blend, DrawGradientRectangle, angle);
        }
        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradient(c1, c2, DrawGradientRectangle, angle);
        }

        protected void DrawGradient(ColorBlend blend, Rectangle r, float angle)
        {
            DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, angle);
            DrawGradientBrush.InterpolationColors = blend;
            G.FillRectangle(DrawGradientBrush, r);
        }
        protected void DrawGradient(Color c1, Color c2, Rectangle r, float angle)
        {
            DrawGradientBrush = new LinearGradientBrush(r, c1, c2, angle);
            G.FillRectangle(DrawGradientBrush, r);
        }

        #endregion

    }

    public abstract class ThemeControl151 : Control
    {

        protected Graphics G;

        protected Bitmap B;
        public ThemeControl151()
        {
            SetStyle((ControlStyles)139270, true);

            _ImageSize = Size.Empty;

            MeasureBitmap = new Bitmap(1, 1);
            MeasureGraphics = Graphics.FromImage(MeasureBitmap);

            Font = new Font("Verdana", 8);

            InvalidateCustimization();
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (!(_LockWidth == 0))
                width = _LockWidth;
            if (!(_LockHeight == 0))
                height = _LockHeight;
            base.SetBoundsCore(x, y, width, height, specified);
        }

        protected override sealed void OnSizeChanged(EventArgs e)
        {
            if (_Transparent && !(Width == 0 || Height == 0))
            {
                B = new Bitmap(Width, Height);
                G = Graphics.FromImage(B);
            }

            Invalidate();
            base.OnSizeChanged(e);
        }

        protected override sealed void OnPaint(PaintEventArgs e)
        {
            if (Width == 0 || Height == 0)
                return;

            if (_Transparent)
            {
                PaintHook();
                e.Graphics.DrawImage(B, 0, 0);
            }
            else
            {
                G = e.Graphics;
                PaintHook();
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            InvalidateCustimization();
            ColorHook();

            if (!(_LockWidth == 0))
                Width = _LockWidth;
            if (!(_LockHeight == 0))
                Height = _LockHeight;
            if (!(BackColorWait == null))
                BackColor = BackColorWait;

            OnCreation();
            base.OnHandleCreated(e);
        }

        protected virtual void OnCreation()
        {
        }

        #region " State Handling "

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

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                SetState(MouseState.Down);
            base.OnMouseDown(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            SetState(MouseState.None);
            base.OnMouseLeave(e);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (Enabled)
                SetState(MouseState.None);
            else
                SetState(MouseState.Block);
            base.OnEnabledChanged(e);
        }

        protected MouseState State;
        private void SetState(MouseState current)
        {
            State = current;
            Invalidate();
        }

        #endregion


        #region " Property Overrides "

        private Color BackColorWait;
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                if (IsHandleCreated)
                {
                    base.BackColor = value;
                }
                else
                {
                    BackColorWait = value;
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ForeColor
        {
            get { return Color.Empty; }
            set { }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Image BackgroundImage
        {
            get { return null; }
            set { }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ImageLayout BackgroundImageLayout
        {
            get { return ImageLayout.None; }
            set { }
        }

        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                Invalidate();
            }
        }

        #endregion

        #region " Properties "

        private bool _NoRounding;
        public bool NoRounding
        {
            get { return _NoRounding; }
            set
            {
                _NoRounding = value;
                Invalidate();
            }
        }

        private Image _Image;
        public Image Image
        {
            get { return _Image; }
            set
            {
                if (value == null)
                {
                    _ImageSize = Size.Empty;
                }
                else
                {
                    _ImageSize = value.Size;
                }

                _Image = value;
                Invalidate();
            }
        }

        private Size _ImageSize;
        protected Size ImageSize
        {
            get
            {
                return _ImageSize;
            }
        }

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

        private bool _Transparent;
        public bool Transparent
        {
            get { return _Transparent; }
            set
            {
                if (!value && !(BackColor.A == 255))
                {
                    throw new Exception("Unable to change value to false while a transparent BackColor is in use.");
                }

                SetStyle(ControlStyles.Opaque, !value);
                SetStyle(ControlStyles.SupportsTransparentBackColor, value);

                if (value)
                    InvalidateBitmap();
                else
                    B = null;

                _Transparent = value;
                Invalidate();
            }
        }

        private Dictionary<string, Color> Items = new Dictionary<string, Color>();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Bloom[] Colors
        {
            get
            {
                List<Bloom> T = new List<Bloom>();
                Dictionary<string, Color>.Enumerator E = Items.GetEnumerator();

                while (E.MoveNext())
                {
                    T.Add(new Bloom(E.Current.Key, E.Current.Value));
                }

                return T.ToArray();
            }
            set
            {
                foreach (Bloom B in value)
                {
                    if (Items.ContainsKey(B.Name))
                        Items[B.Name] = B.Value;
                }

                InvalidateCustimization();
                ColorHook();
                Invalidate();
            }
        }

        private string _Customization;
        public string Customization
        {
            get { return _Customization; }
            set
            {
                if (value == _Customization)
                    return;

                byte[] Data = null;
                Bloom[] Items = Colors;

                try
                {
                    Data = Convert.FromBase64String(value);
                    for (int I = 0; I <= Items.Length - 1; I++)
                    {
                        Items[I].Value = Color.FromArgb(BitConverter.ToInt32(Data, I * 4));
                    }
                }
                catch
                {
                    return;
                }

                _Customization = value;

                Colors = Items;
                ColorHook();
                Invalidate();
            }
        }

        #endregion

        #region " Property Helpers "

        private void InvalidateBitmap()
        {
            if (Width == 0 || Height == 0)
                return;
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);
        }

        protected Color GetColor(string name)
        {
            return Items[name];
        }

        protected void SetColor(string name, Color color)
        {
            if (Items.ContainsKey(name))
                Items[name] = color;
            else
                Items.Add(name, color);
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

        private void InvalidateCustimization()
        {
            MemoryStream M = new MemoryStream(Items.Count * 4);

            foreach (Bloom B in Colors)
            {
                M.Write(BitConverter.GetBytes(B.Value.ToArgb()), 0, 4);
            }

            M.Close();
            _Customization = Convert.ToBase64String(M.ToArray());
        }

        #endregion


        #region " User Hooks "

        protected abstract void ColorHook();
        protected abstract void PaintHook();

        #endregion


        #region " Center Overloads "


        private Point CenterReturn;
        protected Point Center(Rectangle r1, Size s1)
        {
            CenterReturn = new Point((r1.Width / 2 - s1.Width / 2) + r1.X, (r1.Height / 2 - s1.Height / 2) + r1.Y);
            return CenterReturn;
        }
        protected Point Center(Rectangle r1, Rectangle r2)
        {
            return Center(r1, r2.Size);
        }

        protected Point Center(int w1, int h1, int w2, int h2)
        {
            CenterReturn = new Point(w1 / 2 - w2 / 2, h1 / 2 - h2 / 2);
            return CenterReturn;
        }

        protected Point Center(Size s1, Size s2)
        {
            return Center(s1.Width, s1.Height, s2.Width, s2.Height);
        }

        protected Point Center(Rectangle r1)
        {
            return Center(ClientRectangle.Width, ClientRectangle.Height, r1.Width, r1.Height);
        }
        protected Point Center(Size s1)
        {
            return Center(Width, Height, s1.Width, s1.Height);
        }
        protected Point Center(int w1, int h1)
        {
            return Center(Width, Height, w1, h1);
        }

        #endregion

        #region " Measure Overloads "

        private Bitmap MeasureBitmap;

        private Graphics MeasureGraphics;
        protected Size Measure(string text)
        {
            return MeasureGraphics.MeasureString(text, Font, Width).ToSize();
        }
        protected Size Measure()
        {
            return MeasureGraphics.MeasureString(Text, Font, Width).ToSize();
        }

        #endregion

        #region " DrawCorners Overloads "

        //TODO: Optimize by checking brush color


        private SolidBrush DrawCornersBrush;
        protected void DrawCorners(Color c1)
        {
            DrawCorners(c1, 0, 0, Width, Height);
        }
        protected void DrawCorners(Color c1, Rectangle r1)
        {
            DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height);
        }
        protected void DrawCorners(Color c1, int x, int y, int width, int height)
        {
            if (_NoRounding)
                return;

            if (_Transparent)
            {
                B.SetPixel(x, y, c1);
                B.SetPixel(x + (width - 1), y, c1);
                B.SetPixel(x, y + (height - 1), c1);
                B.SetPixel(x + (width - 1), y + (height - 1), c1);
            }
            else
            {
                DrawCornersBrush = new SolidBrush(c1);
                G.FillRectangle(DrawCornersBrush, x, y, 1, 1);
                G.FillRectangle(DrawCornersBrush, x + (width - 1), y, 1, 1);
                G.FillRectangle(DrawCornersBrush, x, y + (height - 1), 1, 1);
                G.FillRectangle(DrawCornersBrush, x + (width - 1), y + (height - 1), 1, 1);
            }
        }

        #endregion

        #region " DrawBorders Overloads "

        //TODO: Remove triple overload?

        protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset)
        {
            DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
        }
        protected void DrawBorders(Pen p1, int offset)
        {
            DrawBorders(p1, 0, 0, Width, Height, offset);
        }
        protected void DrawBorders(Pen p1, Rectangle r, int offset)
        {
            DrawBorders(p1, r.X, r.Y, r.Width, r.Height, offset);
        }

        protected void DrawBorders(Pen p1, int x, int y, int width, int height)
        {
            G.DrawRectangle(p1, x, y, width - 1, height - 1);
        }
        protected void DrawBorders(Pen p1)
        {
            DrawBorders(p1, 0, 0, Width, Height);
        }
        protected void DrawBorders(Pen p1, Rectangle r)
        {
            DrawBorders(p1, r.X, r.Y, r.Width, r.Height);
        }

        #endregion

        #region " DrawText Overloads "

        //TODO: Remove triple overloads?

        private Point DrawTextPoint;

        private Size DrawTextSize;
        protected void DrawText(Brush b1, HorizontalAlignment a, int x, int y)
        {
            DrawText(b1, Text, a, x, y);
        }
        protected void DrawText(Brush b1, Point p1)
        {
            DrawText(b1, Text, p1.X, p1.Y);
        }
        protected void DrawText(Brush b1, int x, int y)
        {
            DrawText(b1, Text, x, y);
        }

        protected void DrawText(Brush b1, string text, HorizontalAlignment a, int x, int y)
        {
            if (text.Length == 0)
                return;
            DrawTextSize = Measure(text);
            DrawTextPoint = Center(DrawTextSize);

            switch (a)
            {
                case HorizontalAlignment.Left:
                    DrawText(b1, text, x, DrawTextPoint.Y + y);
                    break;
                case HorizontalAlignment.Center:
                    DrawText(b1, text, DrawTextPoint.X + x, DrawTextPoint.Y + y);
                    break;
                case HorizontalAlignment.Right:
                    DrawText(b1, text, Width - DrawTextSize.Width - x, DrawTextPoint.Y + y);
                    break;
            }
        }
        protected void DrawText(Brush b1, string text, Point p1)
        {
            DrawText(b1, text, p1.X, p1.Y);
        }
        protected void DrawText(Brush b1, string text, int x, int y)
        {
            if (text.Length == 0)
                return;
            G.DrawString(text, Font, b1, x, y);
        }

        #endregion

        #region " DrawImage Overloads "

        //TODO: Remove triple overloads?


        private Point DrawImagePoint;
        protected void DrawImage(HorizontalAlignment a, int x, int y)
        {
            DrawImage(_Image, a, x, y);
        }
        protected void DrawImage(Point p1)
        {
            DrawImage(_Image, p1.X, p1.Y);
        }
        protected void DrawImage(int x, int y)
        {
            DrawImage(_Image, x, y);
        }

        protected void DrawImage(Image image, HorizontalAlignment a, int x, int y)
        {
            if (image == null)
                return;
            DrawImagePoint = Center(image.Size);

            switch (a)
            {
                case HorizontalAlignment.Left:
                    DrawImage(image, x, DrawImagePoint.Y + y);
                    break;
                case HorizontalAlignment.Center:
                    DrawImage(image, DrawImagePoint.X + x, DrawImagePoint.Y + y);
                    break;
                case HorizontalAlignment.Right:
                    DrawImage(image, Width - image.Width - x, DrawImagePoint.Y + y);
                    break;
            }
        }
        protected void DrawImage(Image image, Point p1)
        {
            DrawImage(image, p1.X, p1.Y);
        }
        protected void DrawImage(Image image, int x, int y)
        {
            if (image == null)
                return;
            G.DrawImage(image, x, y, image.Width, image.Height);
        }

        #endregion

        #region " DrawGradient Overloads "

        //TODO: Remove triple overload?

        private LinearGradientBrush DrawGradientBrush;

        private Rectangle DrawGradientRectangle;
        protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height)
        {
            DrawGradient(blend, x, y, width, height, 90);
        }
        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height)
        {
            DrawGradient(c1, c2, x, y, width, height, 90);
        }

        protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height, float angle)
        {
            DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradient(blend, DrawGradientRectangle, angle);
        }
        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            DrawGradientRectangle = new Rectangle(x, y, width, height);
            DrawGradient(c1, c2, DrawGradientRectangle, angle);
        }

        protected void DrawGradient(ColorBlend blend, Rectangle r, float angle)
        {
            DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, angle);
            DrawGradientBrush.InterpolationColors = blend;
            G.FillRectangle(DrawGradientBrush, r);
        }
        protected void DrawGradient(Color c1, Color c2, Rectangle r, float angle)
        {
            DrawGradientBrush = new LinearGradientBrush(r, c1, c2, angle);
            G.FillRectangle(DrawGradientBrush, r);
        }

        #endregion

    }

    #endregion

    public class Jtheme : ThemeContainer151
    {
        Color Color1;
        Brush Color2;
        Color Color3;

        Brush Color4;
        public Jtheme()
        {
            SetColor("Border", Color.FromArgb(20, 20, 20));
            SetColor("BackColor", Color.FromArgb(50, 50, 50));
            SetColor("Text", Color.White);
        }

        protected override void ColorHook()
        {
            Color1 = GetColor("Border");
            Color2 = new SolidBrush(GetColor("BackColor"));
            Color3 = GetColor("BackColor");
            Color4 = new SolidBrush(GetColor("Text"));
        }

        protected override void PaintHook()
        {
            G.Clear(Color1);
            Rectangle rect = new Rectangle(10, 20, Width - 20, Height - 30);
            G.FillRectangle(Color2, rect);
            DrawBorders(Pens.Black, rect);
            DrawBorders(Pens.Black);
            DrawCorners(Color3);
            DrawText(Color4, HorizontalAlignment.Center, 0, 0);


        }
    }

    

}


