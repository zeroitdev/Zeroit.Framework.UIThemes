// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TextBox.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using static Zeroit.Framework.UIThemes.MetroDisk.Helpers;
using System.Drawing.Text;


namespace Zeroit.Framework.UIThemes.MetroDisk
{
    [DefaultEvent("TextChanged")]
    public class MetroDiskTextBox : Control
    {

        #region " Variables"

        private int W;
        private int H;
        private MouseState State = MouseState.None;
        private TextBox TB;

        private bool _Theme;
        #endregion

        #region " Properties"

        #region " TextBox Properties"

        private HorizontalAlignment _TextAlign = HorizontalAlignment.Left;
        [Category("Options")]
        public HorizontalAlignment TextAlign
        {
            get { return _TextAlign; }
            set
            {
                _TextAlign = value;
                if (TB != null)
                {
                    TB.TextAlign = value;
                }
            }
        }
        private int _MaxLength = 32767;
        [Category("Options")]
        public int MaxLength
        {
            get { return _MaxLength; }
            set
            {
                _MaxLength = value;
                if (TB != null)
                {
                    TB.MaxLength = value;
                }
            }
        }
        private bool _ReadOnly;
        [Category("Options")]
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if (TB != null)
                {
                    TB.ReadOnly = value;
                }
            }
        }
        private bool _UseSystemPasswordChar;
        [Category("Options")]
        public bool UseSystemPasswordChar
        {
            get { return _UseSystemPasswordChar; }
            set
            {
                _UseSystemPasswordChar = value;
                if (TB != null)
                {
                    TB.UseSystemPasswordChar = value;
                }
            }
        }
        private bool _Multiline;
        [Category("Options")]
        public bool Multiline
        {
            get { return _Multiline; }
            set
            {
                _Multiline = value;
                if (TB != null)
                {
                    TB.Multiline = value;

                    if (value)
                    {
                        TB.Height = Height - 11;
                    }
                    else
                    {
                        Height = TB.Height + 11;
                    }

                }
            }
        }
        [Category("Options")]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                if (TB != null)
                {
                    TB.Text = value;
                }
            }
        }
        [Category("Options")]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                if (TB != null)
                {
                    TB.Font = value;
                    TB.Location = new Point(3, 5);
                    TB.Width = Width - 6;

                    if (!_Multiline)
                    {
                        Height = TB.Height + 11;
                    }
                }
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (!Controls.Contains(TB))
            {
                Controls.Add(TB);
            }
        }
        private void OnBaseTextChanged(object s, EventArgs e)
        {
            Text = TB.Text;
        }
        private void OnBaseKeyDown(object s, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                TB.SelectAll();
                e.SuppressKeyPress = true;
            }
            if (e.Control && e.KeyCode == Keys.C)
            {
                TB.Copy();
                e.SuppressKeyPress = true;
            }
        }
        protected override void OnResize(EventArgs e)
        {
            TB.Location = new Point(5, 5);
            TB.Width = Width - 10;

            if (_Multiline)
            {
                TB.Height = Height - 11;
            }
            else
            {
                Height = TB.Height + 11;
            }

            base.OnResize(e);
        }

        public bool LightTheme
        {
            get { return _Theme; }
            set { _Theme = value; }
        }

        #endregion

        #region " Colors"

        [Category("Colors")]
        public Color TextColor
        {
            get { return _TextColor; }
            set { _TextColor = value; }
        }

        public override Color ForeColor
        {
            get { return _TextColor; }
            set { _TextColor = value; }
        }

        #endregion

        #region " Mouse States"

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

        #region " Colors"

        //true = light | false = dark

        private Color _BaseColor = Color.FromArgb(200, 200, 200);
        private Color _TextColor = Color.FromArgb(192, 192, 192);

        private Color _BorderColor = _FlatColor;
        #endregion

        public MetroDiskTextBox()
        {
            if (_Theme == true)
            {
                _BaseColor = Color.FromArgb(200, 200, 200);
                _TextColor = Color.FromArgb(0, 0, 0);
                _BorderColor = Color.Black;

                SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
                DoubleBuffered = true;

                BackColor = Color.Transparent;

                TB = new TextBox();
                TB.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                TB.Text = Text;
                TB.BackColor = _BaseColor;
                TB.ForeColor = _TextColor;
                TB.MaxLength = _MaxLength;
                TB.Multiline = _Multiline;
                TB.ReadOnly = _ReadOnly;
                TB.UseSystemPasswordChar = _UseSystemPasswordChar;
                TB.BorderStyle = BorderStyle.None;
                TB.Location = new Point(5, 5);
                TB.Width = Width - 10;

                TB.Cursor = Cursors.IBeam;

                if (_Multiline)
                {
                    TB.Height = Height - 11;
                }
                else
                {
                    Height = TB.Height + 11;
                }

                TB.TextChanged += OnBaseTextChanged;
                TB.KeyDown += OnBaseKeyDown;
            }
            else
            {
                _BaseColor = Color.FromArgb(0, 0, 0);
                _TextColor = Color.FromArgb(200, 200, 200);

                SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
                DoubleBuffered = true;

                BackColor = Color.Transparent;

                TB = new TextBox();
                TB.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                TB.Text = Text;
                TB.BackColor = _BaseColor;
                TB.ForeColor = _TextColor;
                TB.MaxLength = _MaxLength;
                TB.Multiline = _Multiline;
                TB.ReadOnly = _ReadOnly;
                TB.UseSystemPasswordChar = _UseSystemPasswordChar;
                TB.BorderStyle = BorderStyle.None;
                TB.Location = new Point(5, 5);
                TB.Width = Width - 10;

                TB.Cursor = Cursors.IBeam;

                if (_Multiline)
                {
                    TB.Height = Height - 11;
                }
                else
                {
                    Height = TB.Height + 11;
                }

                TB.TextChanged += OnBaseTextChanged;
                TB.KeyDown += OnBaseKeyDown;
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            if (_Theme == true)
            {
                _BaseColor = Color.FromArgb(255, 255, 255);
                _TextColor = Color.FromArgb(175, 175, 175);
                _FlatColor = Color.FromArgb(0, 0, 0);
                B = new Bitmap(Width, Height);
                G = Graphics.FromImage(B);
                W = Width - 1;
                H = Height - 1;

                Rectangle Base = new Rectangle(0, 0, W, H);

                var _with8 = G;
                _with8.SmoothingMode = (SmoothingMode)2;
                _with8.PixelOffsetMode = (PixelOffsetMode)2;
                _with8.TextRenderingHint = (TextRenderingHint)5;
                _with8.Clear(BackColor);

                //-- Colors
                TB.BackColor = _BaseColor;
                TB.ForeColor = _TextColor;

                //-- Base
                _with8.FillRectangle(new SolidBrush(_BaseColor), Base);

                _with8.DrawRectangle(new Pen(Color.FromArgb(200, 200, 200)), new Rectangle(0, 0, W, H));

                base.OnPaint(e);
                G.Dispose();
                e.Graphics.InterpolationMode = (InterpolationMode)7;
                e.Graphics.DrawImageUnscaled(B, 0, 0);
                B.Dispose();
            }
            else
            {
                _BaseColor = Color.FromArgb(50, 50, 50);
                _TextColor = Color.FromArgb(200, 200, 200);
                B = new Bitmap(Width, Height);
                G = Graphics.FromImage(B);
                W = Width - 1;
                H = Height - 1;

                Rectangle Base = new Rectangle(0, 0, W, H);

                var _with9 = G;
                _with9.SmoothingMode = (SmoothingMode)2;
                _with9.PixelOffsetMode = (PixelOffsetMode)2;
                _with9.TextRenderingHint = (TextRenderingHint)5;
                _with9.Clear(BackColor);

                //-- Colors
                TB.BackColor = _BaseColor;
                TB.ForeColor = _TextColor;

                //-- Base
                _with9.FillRectangle(new SolidBrush(_BaseColor), Base);

                _with9.DrawRectangle(new Pen(Color.FromArgb(25, 25, 25)), new Rectangle(0, 0, W, H));

                base.OnPaint(e);
                G.Dispose();
                e.Graphics.InterpolationMode = (InterpolationMode)7;
                e.Graphics.DrawImageUnscaled(B, 0, 0);
                B.Dispose();
            }
        }

    }

}