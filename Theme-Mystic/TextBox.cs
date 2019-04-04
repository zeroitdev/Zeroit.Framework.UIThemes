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
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Mystic
{
    [DefaultEvent("TextChanged")]
    public class MysticTextBox : Control
    {

        #region " Variables "

        private MouseState _State = MouseState.None;
        private TextBox _TextBox;
        #endregion
        private bool _Focus = false;

        #region " Properties "

        #region " TextBox Properties "

        private HorizontalAlignment _TextAlign = HorizontalAlignment.Left;
        [Category("Options")]
        public HorizontalAlignment TextAlign
        {
            get { return _TextAlign; }
            set
            {
                _TextAlign = value;
                if (_TextBox != null)
                {
                    _TextBox.TextAlign = value;
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
                if (_TextBox != null)
                {
                    _TextBox.MaxLength = value;
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
                if (_TextBox != null)
                {
                    _TextBox.ReadOnly = value;
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
                if (_TextBox != null)
                {
                    _TextBox.UseSystemPasswordChar = value;
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
                if (_TextBox != null)
                {
                    _TextBox.Multiline = value;

                    if (value)
                    {
                        _TextBox.Height = Height - 11;
                    }
                    else
                    {
                        Height = _TextBox.Height + 11;
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
                if (_TextBox != null)
                {
                    _TextBox.Text = value;
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
                if (_TextBox != null)
                {
                    _TextBox.Font = value;
                    _TextBox.Location = new Point(3, 5);
                    _TextBox.Width = Width - 6;

                    if (!_Multiline)
                    {
                        Height = _TextBox.Height + 11;
                    }
                }
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (!Controls.Contains(_TextBox))
            {
                Controls.Add(_TextBox);
            }
        }
        private void OnBaseTextChanged(object s, EventArgs e)
        {
            Text = _TextBox.Text;
        }
        private void OnBaseKeyDown(object s, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                _TextBox.SelectAll();
                e.SuppressKeyPress = true;
            }
            if (e.Control && e.KeyCode == Keys.C)
            {
                _TextBox.Copy();
                e.SuppressKeyPress = true;
            }
        }
        protected override void OnResize(EventArgs e)
        {
            _TextBox.Location = new Point(5, 5);
            _TextBox.Width = Width - 10;

            if (_Multiline)
            {
                _TextBox.Height = Height - 11;
            }
            else
            {
                Height = _TextBox.Height + 11;
            }

            base.OnResize(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            _Focus = true;
            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            _Focus = false;
            Invalidate();
        }

        #endregion

        #region " Mouse States "

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _State = MouseState.Over;
            _TextBox.Focus();
            Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _State = MouseState.Over;
            _TextBox.Focus();
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _State = MouseState.None;
            Invalidate();
        }

        #endregion

        #endregion

        public MysticTextBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;

            BackColor = Color.Transparent;

            _TextBox = new TextBox();
            _TextBox.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            _TextBox.Text = Text;
            _TextBox.BackColor = Color.FromArgb(34, 37, 44);
            _TextBox.ForeColor = Color.White;
            _TextBox.MaxLength = _MaxLength;
            _TextBox.Multiline = _Multiline;
            _TextBox.ReadOnly = _ReadOnly;
            _TextBox.UseSystemPasswordChar = _UseSystemPasswordChar;
            _TextBox.BorderStyle = BorderStyle.None;
            _TextBox.Location = new Point(5, 5);
            _TextBox.Width = Width - 10;

            _TextBox.Cursor = Cursors.IBeam;

            if (_Multiline)
            {
                _TextBox.Height = Height - 11;
            }
            else
            {
                Height = _TextBox.Height + 11;
            }

            _TextBox.TextChanged += OnBaseTextChanged;
            _TextBox.KeyDown += OnBaseKeyDown;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;
            G.Clear(Color.FromArgb(34, 37, 44));

            G.DrawRectangle(new Pen(Color.FromArgb(0, 206, 153), 2), new Rectangle(1, 1, Width - 2, Height - 2));

            G.FillRectangle(new SolidBrush(Color.FromArgb(44, 51, 62)), new Rectangle(0, 0, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(44, 51, 62)), new Rectangle(Width - 1, 0, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(44, 51, 62)), new Rectangle(0, Height - 1, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(44, 51, 62)), new Rectangle(Width - 1, Height - 1, 1, 1));
        }

    }

}

