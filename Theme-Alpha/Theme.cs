// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 08-12-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 02-24-2018
// ***********************************************************************
// <copyright file="Alpha Theme.cs" company="Zeroit Dev Technologies">
//    This program is for creating Theme controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Alpha
{

    /// <summary>
    /// Class Theme.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ContainerControl" />
    public abstract class Theme : ContainerControl
    {

        #region " Initialization "

        /// <summary>
        /// The g
        /// </summary>
        protected Graphics G;
        /// <summary>
        /// Initializes a new instance of the <see cref="Theme"/> class.
        /// </summary>
        public Theme()
        {
            SetStyle((ControlStyles)139270, true);
        }

        /// <summary>
        /// The parent is form
        /// </summary>
        private bool ParentIsForm;
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.HandleCreated" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            Dock = DockStyle.Fill;
            ParentIsForm = Parent is System.Windows.Forms.Form;
            if (ParentIsForm)
            {
                if (!(_TransparencyKey == Color.Empty))
                    ParentForm.TransparencyKey = _TransparencyKey;
                ParentForm.FormBorderStyle = FormBorderStyle.None;
            }
            base.OnHandleCreated(e);
        }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value>The text.</value>
        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }
        #endregion

        #region " Sizing and Movement "

        /// <summary>
        /// The resizable
        /// </summary>
        private bool _Resizable = true;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Theme"/> is resizable.
        /// </summary>
        /// <value><c>true</c> if resizable; otherwise, <c>false</c>.</value>
        public bool Resizable
        {
            get { return _Resizable; }
            set { _Resizable = value; }
        }

        /// <summary>
        /// The move height
        /// </summary>
        private int _MoveHeight = 24;
        /// <summary>
        /// Gets or sets the height of the move.
        /// </summary>
        /// <value>The height of the move.</value>
        public int MoveHeight
        {
            get { return _MoveHeight; }
            set
            {
                _MoveHeight = value;
                Header = new Rectangle(7, 7, Width - 14, _MoveHeight - 7);
            }
        }

        /// <summary>
        /// The flag
        /// </summary>
        private IntPtr Flag;
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!(e.Button == MouseButtons.Left))
                return;
            if (ParentIsForm)
                if (ParentForm.WindowState == FormWindowState.Maximized)
                    return;

            if (Header.Contains(e.Location))
            {
                Flag = new IntPtr(2);
            }
            else if (Current.Position == 0 | !_Resizable)
            {
                return;
            }
            else
            {
                Flag = new IntPtr(Current.Position);
            }

            Capture = false;
            Message mes = Message.Create(Parent.Handle, 161, Flag, IntPtr.Zero);

            DefWndProc(ref mes);

            base.OnMouseDown(e);
        }

        /// <summary>
        /// Struct Pointer
        /// </summary>
        private struct Pointer
        {
            /// <summary>
            /// The cursor
            /// </summary>
            public readonly Cursor Cursor;
            /// <summary>
            /// The position
            /// </summary>
            public readonly byte Position;
            /// <summary>
            /// Initializes a new instance of the <see cref="Pointer"/> struct.
            /// </summary>
            /// <param name="c">The c.</param>
            /// <param name="p">The p.</param>
            public Pointer(Cursor c, byte p)
            {
                Cursor = c;
                Position = p;
            }
        }

        /// <summary>
        /// The f1
        /// </summary>
        private bool F1;
        /// <summary>
        /// The f2
        /// </summary>
        private bool F2;
        /// <summary>
        /// The f3
        /// </summary>
        private bool F3;
        /// <summary>
        /// The f4
        /// </summary>
        private bool F4;
        /// <summary>
        /// The PTC
        /// </summary>
        private Point PTC;
        /// <summary>
        /// Gets the pointer.
        /// </summary>
        /// <returns>Pointer.</returns>
        private Pointer GetPointer()
        {
            PTC = PointToClient(MousePosition);
            F1 = PTC.X < 7;
            F2 = PTC.X > Width - 7;
            F3 = PTC.Y < 7;
            F4 = PTC.Y > Height - 7;

            if (F1 & F3)
                return new Pointer(Cursors.SizeNWSE, 13);
            if (F1 & F4)
                return new Pointer(Cursors.SizeNESW, 16);
            if (F2 & F3)
                return new Pointer(Cursors.SizeNESW, 14);
            if (F2 & F4)
                return new Pointer(Cursors.SizeNWSE, 17);
            if (F1)
                return new Pointer(Cursors.SizeWE, 10);
            if (F2)
                return new Pointer(Cursors.SizeWE, 11);
            if (F3)
                return new Pointer(Cursors.SizeNS, 12);
            if (F4)
                return new Pointer(Cursors.SizeNS, 15);
            return new Pointer(Cursors.Default, 0);
        }

        /// <summary>
        /// The current
        /// </summary>
        private Pointer Current;
        /// <summary>
        /// The pending
        /// </summary>
        private Pointer Pending;
        /// <summary>
        /// Sets the current.
        /// </summary>
        private void SetCurrent()
        {
            Pending = GetPointer();
            if (Current.Position == Pending.Position)
                return;
            Current = GetPointer();
            Cursor = Current.Cursor;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_Resizable)
                SetCurrent();
            base.OnMouseMove(e);
        }

        /// <summary>
        /// The header
        /// </summary>
        protected Rectangle Header;
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            if (Width == 0 || Height == 0)
                return;
            Header = new Rectangle(7, 7, Width - 14, _MoveHeight - 7);
            Invalidate();
            base.OnSizeChanged(e);
        }

        #endregion

        #region " Convienence "

        /// <summary>
        /// Paints the hook.
        /// </summary>
        public abstract void PaintHook();
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override sealed void OnPaint(PaintEventArgs e)
        {
            if (Width == 0 || Height == 0)
                return;
            G = e.Graphics;
            PaintHook();
        }

        /// <summary>
        /// The transparency key
        /// </summary>
        private Color _TransparencyKey;
        /// <summary>
        /// Gets or sets the transparency key.
        /// </summary>
        /// <value>The transparency key.</value>
        public Color TransparencyKey
        {
            get { return _TransparencyKey; }
            set
            {
                _TransparencyKey = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The image
        /// </summary>
        private Image _Image;
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public Image Image
        {
            get { return _Image; }
            set
            {
                _Image = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets the width of the image.
        /// </summary>
        /// <value>The width of the image.</value>
        public int ImageWidth
        {
            get
            {
                if (_Image == null)
                    return 0;
                return _Image.Width;
            }
        }

        /// <summary>
        /// The size
        /// </summary>
        private Size _Size;
        /// <summary>
        /// The rectangle
        /// </summary>
        private Rectangle _Rectangle;
        /// <summary>
        /// The gradient
        /// </summary>
        private LinearGradientBrush _Gradient;

        /// <summary>
        /// The brush
        /// </summary>
        private SolidBrush _Brush;
        /// <summary>
        /// Draws the corners.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="rect">The rect.</param>
        protected void DrawCorners(Color c, Rectangle rect)
        {
            _Brush = new SolidBrush(c);
            G.FillRectangle(_Brush, rect.X, rect.Y, 1, 1);
            G.FillRectangle(_Brush, rect.X + (rect.Width - 1), rect.Y, 1, 1);
            G.FillRectangle(_Brush, rect.X, rect.Y + (rect.Height - 1), 1, 1);
            G.FillRectangle(_Brush, rect.X + (rect.Width - 1), rect.Y + (rect.Height - 1), 1, 1);
        }

        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="p2">The p2.</param>
        /// <param name="rect">The rect.</param>
        protected void DrawBorders(Pen p1, Pen p2, Rectangle rect)
        {
            G.DrawRectangle(p1, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
            G.DrawRectangle(p2, rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3);
        }

        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="c">The c.</param>
        /// <param name="x">The x.</param>
        protected void DrawText(HorizontalAlignment a, Color c, int x)
        {
            DrawText(a, c, x, 0);
        }
        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="c">The c.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        protected void DrawText(HorizontalAlignment a, Color c, int x, int y)
        {
            if (string.IsNullOrEmpty(Text))
                return;
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
                    G.DrawString(Text, Font, _Brush, Width / 2 - _Size.Width / 2 + x, _MoveHeight / 2 - _Size.Height / 2 + y);
                    break;
            }
        }

        /// <summary>
        /// Draws the icon.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="x">The x.</param>
        protected void DrawIcon(HorizontalAlignment a, int x)
        {
            DrawIcon(a, x, 0);
        }
        /// <summary>
        /// Draws the icon.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        protected void DrawIcon(HorizontalAlignment a, int x, int y)
        {
            if (_Image == null)
                return;
            switch (a)
            {
                case HorizontalAlignment.Left:
                    G.DrawImage(_Image, x, _MoveHeight / 2 - _Image.Height / 2 + y);
                    break;
                case HorizontalAlignment.Right:
                    G.DrawImage(_Image, Width - _Image.Width - x, _MoveHeight / 2 - _Image.Height / 2 + y);
                    break;
                case HorizontalAlignment.Center:
                    G.DrawImage(_Image, Width / 2 - _Image.Width / 2, _MoveHeight / 2 - _Image.Height / 2);
                    break;
            }
        }

        /// <summary>
        /// Draws the gradient.
        /// </summary>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="angle">The angle.</param>
        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            _Rectangle = new Rectangle(x, y, width, height);
            _Gradient = new LinearGradientBrush(_Rectangle, c1, c2, angle);
            G.FillRectangle(_Gradient, _Rectangle);
        }

        #endregion

    }
    /// <summary>
    /// Class ThemeControl.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public abstract class ThemeControl : Control
    {

        #region " Initialization "

        /// <summary>
        /// The g
        /// </summary>
        protected Graphics G;
        /// <summary>
        /// The b
        /// </summary>
        protected Bitmap B;
        /// <summary>
        /// Initializes a new instance of the <see cref="ThemeControl"/> class.
        /// </summary>
        public ThemeControl()
        {
            SetStyle((ControlStyles)139270, true);
            B = new Bitmap(1, 1);
            G = Graphics.FromImage(B);
        }

        /// <summary>
        /// Allows the transparent.
        /// </summary>
        public void AllowTransparent()
        {
            SetStyle(ControlStyles.Opaque, false);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value>The text.</value>
        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }
        #endregion

        #region " Mouse Handling "

        /// <summary>
        /// Enum State
        /// </summary>
        protected enum State : byte
        {
            /// <summary>
            /// The mouse none
            /// </summary>
            MouseNone = 0,
            /// <summary>
            /// The mouse over
            /// </summary>
            MouseOver = 1,
            /// <summary>
            /// The mouse down
            /// </summary>
            MouseDown = 2
        }

        /// <summary>
        /// The mouse state
        /// </summary>
        protected State MouseState;
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            ChangeMouseState(State.MouseNone);
            base.OnMouseLeave(e);
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            ChangeMouseState(State.MouseOver);
            base.OnMouseEnter(e);
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            ChangeMouseState(State.MouseOver);
            base.OnMouseUp(e);
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                ChangeMouseState(State.MouseDown);
            base.OnMouseDown(e);
        }

        /// <summary>
        /// Changes the state of the mouse.
        /// </summary>
        /// <param name="e">The e.</param>
        private void ChangeMouseState(State e)
        {
            MouseState = e;
            Invalidate();
        }

        #endregion

        #region " Convienence "

        /// <summary>
        /// Paints the hook.
        /// </summary>
        public abstract void PaintHook();
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override sealed void OnPaint(PaintEventArgs e)
        {
            if (Width == 0 || Height == 0)
                return;
            PaintHook();
            e.Graphics.DrawImage(B, 0, 0);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
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

        /// <summary>
        /// The no rounding
        /// </summary>
        private bool _NoRounding;
        /// <summary>
        /// Gets or sets a value indicating whether [no rounding].
        /// </summary>
        /// <value><c>true</c> if [no rounding]; otherwise, <c>false</c>.</value>
        public bool NoRounding
        {
            get { return _NoRounding; }
            set
            {
                _NoRounding = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The image
        /// </summary>
        private Image _Image;
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public Image Image
        {
            get { return _Image; }
            set
            {
                _Image = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets the width of the image.
        /// </summary>
        /// <value>The width of the image.</value>
        public int ImageWidth
        {
            get
            {
                if (_Image == null)
                    return 0;
                return _Image.Width;
            }
        }
        /// <summary>
        /// Gets the image top.
        /// </summary>
        /// <value>The image top.</value>
        public int ImageTop
        {
            get
            {
                if (_Image == null)
                    return 0;
                return Height / 2 - _Image.Height / 2;
            }
        }

        /// <summary>
        /// The size
        /// </summary>
        private Size _Size;
        /// <summary>
        /// The rectangle
        /// </summary>
        private Rectangle _Rectangle;
        /// <summary>
        /// The gradient
        /// </summary>
        private LinearGradientBrush _Gradient;

        /// <summary>
        /// The brush
        /// </summary>
        private SolidBrush _Brush;
        /// <summary>
        /// Draws the corners.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="rect">The rect.</param>
        protected void DrawCorners(Color c, Rectangle rect)
        {
            if (_NoRounding)
                return;

            B.SetPixel(rect.X, rect.Y, c);
            B.SetPixel(rect.X + (rect.Width - 1), rect.Y, c);
            B.SetPixel(rect.X, rect.Y + (rect.Height - 1), c);
            B.SetPixel(rect.X + (rect.Width - 1), rect.Y + (rect.Height - 1), c);
        }

        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="p2">The p2.</param>
        /// <param name="rect">The rect.</param>
        protected void DrawBorders(Pen p1, Pen p2, Rectangle rect)
        {
            G.DrawRectangle(p1, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
            G.DrawRectangle(p2, rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3);
        }

        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="c">The c.</param>
        /// <param name="x">The x.</param>
        protected void DrawText(HorizontalAlignment a, Color c, int x)
        {
            DrawText(a, c, x, 0);
        }
        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="c">The c.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        protected void DrawText(HorizontalAlignment a, Color c, int x, int y)
        {
            if (string.IsNullOrEmpty(Text))
                return;
            _Size = G.MeasureString(Text, Font).ToSize();
            _Brush = new SolidBrush(c);

            switch (a)
            {
                case HorizontalAlignment.Left:
                    G.DrawString(Text, Font, _Brush, x, Height / 2 - _Size.Height / 2 + y);
                    break;
                case HorizontalAlignment.Right:
                    G.DrawString(Text, Font, _Brush, Width - _Size.Width - x, Height / 2 - _Size.Height / 2 + y);
                    break;
                case HorizontalAlignment.Center:
                    G.DrawString(Text, Font, _Brush, Width / 2 - _Size.Width / 2 + x, Height / 2 - _Size.Height / 2 + y);
                    break;
            }
        }

        /// <summary>
        /// Draws the icon.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="x">The x.</param>
        protected void DrawIcon(HorizontalAlignment a, int x)
        {
            DrawIcon(a, x, 0);
        }
        /// <summary>
        /// Draws the icon.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        protected void DrawIcon(HorizontalAlignment a, int x, int y)
        {
            if (_Image == null)
                return;
            switch (a)
            {
                case HorizontalAlignment.Left:
                    G.DrawImage(_Image, x, Height / 2 - _Image.Height / 2 + y);
                    break;
                case HorizontalAlignment.Right:
                    G.DrawImage(_Image, Width - _Image.Width - x, Height / 2 - _Image.Height / 2 + y);
                    break;
                case HorizontalAlignment.Center:
                    G.DrawImage(_Image, Width / 2 - _Image.Width / 2, Height / 2 - _Image.Height / 2);
                    break;
            }
        }

        /// <summary>
        /// Draws the gradient.
        /// </summary>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="angle">The angle.</param>
        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            _Rectangle = new Rectangle(x, y, width, height);
            _Gradient = new LinearGradientBrush(_Rectangle, c1, c2, angle);
            G.FillRectangle(_Gradient, _Rectangle);
        }
        #endregion

    }
    /// <summary>
    /// Class ThemeContainerControl.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ContainerControl" />
    public abstract class ThemeContainerControl : ContainerControl
    {

        #region " Initialization "

        /// <summary>
        /// The g
        /// </summary>
        protected Graphics G;
        /// <summary>
        /// The b
        /// </summary>
        protected Bitmap B;
        /// <summary>
        /// Initializes a new instance of the <see cref="ThemeContainerControl"/> class.
        /// </summary>
        public ThemeContainerControl()
        {
            SetStyle((ControlStyles)139270, true);
            B = new Bitmap(1, 1);
            G = Graphics.FromImage(B);
        }

        /// <summary>
        /// Allows the transparent.
        /// </summary>
        public void AllowTransparent()
        {
            SetStyle(ControlStyles.Opaque, false);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        #endregion

        #region " Convienence "

        /// <summary>
        /// Paints the hook.
        /// </summary>
        public abstract void PaintHook();
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override sealed void OnPaint(PaintEventArgs e)
        {
            if (Width == 0 || Height == 0)
                return;
            PaintHook();
            e.Graphics.DrawImage(B, 0, 0);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
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

        /// <summary>
        /// The no rounding
        /// </summary>
        private bool _NoRounding;
        /// <summary>
        /// Gets or sets a value indicating whether [no rounding].
        /// </summary>
        /// <value><c>true</c> if [no rounding]; otherwise, <c>false</c>.</value>
        public bool NoRounding
        {
            get { return _NoRounding; }
            set
            {
                _NoRounding = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The rectangle
        /// </summary>
        private Rectangle _Rectangle;

        /// <summary>
        /// The gradient
        /// </summary>
        private LinearGradientBrush _Gradient;
        /// <summary>
        /// Draws the corners.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="rect">The rect.</param>
        protected void DrawCorners(Color c, Rectangle rect)
        {
            if (_NoRounding)
                return;
            B.SetPixel(rect.X, rect.Y, c);
            B.SetPixel(rect.X + (rect.Width - 1), rect.Y, c);
            B.SetPixel(rect.X, rect.Y + (rect.Height - 1), c);
            B.SetPixel(rect.X + (rect.Width - 1), rect.Y + (rect.Height - 1), c);
        }

        /// <summary>
        /// Draws the borders.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="p2">The p2.</param>
        /// <param name="rect">The rect.</param>
        protected void DrawBorders(Pen p1, Pen p2, Rectangle rect)
        {
            G.DrawRectangle(p1, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
            G.DrawRectangle(p2, rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3);
        }

        /// <summary>
        /// Draws the gradient.
        /// </summary>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="angle">The angle.</param>
        protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
        {
            _Rectangle = new Rectangle(x, y, width, height);
            _Gradient = new LinearGradientBrush(_Rectangle, c1, c2, angle);
            G.FillRectangle(_Gradient, _Rectangle);
        }
        #endregion

    }

    /// <summary>
    /// Class AlphaTheme.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.UIThemes.Alpha.Theme" />
    [ToolboxItem(false)]
    public class AlphaTheme : Theme
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlphaTheme"/> class.
        /// </summary>
        public AlphaTheme()
        {
            BackColor = Color.DimGray;
            MoveHeight = 20;
            TransparencyKey = Color.Lime;
        }

        /// <summary>
        /// Paints the hook.
        /// </summary>
        public override void PaintHook()
        {
            G.Clear(BackColor);

            DrawGradient(Color.LightGray, Color.Gray, 0, 0, Width, 25, 90);
            G.DrawLine(Pens.Lime, 0, 25, Width, 25);

            DrawBorders(Pens.Lime, Pens.DimGray, ClientRectangle);
            DrawCorners(Color.Blue, ClientRectangle);
        }
    }
    
}


