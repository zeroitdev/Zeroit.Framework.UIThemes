// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TextBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Knight
{

    [DefaultEvent("TextChanged")]
    public class KnightTextBox : Control
    {

        #region " Variables"
        #endregion
        private TextBox _TextBox;

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

        #endregion
        #endregion
        public KnightTextBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;

            BackColor = Color.Transparent;

            _TextBox = new TextBox();
            _TextBox.Font = new Font("Segoe UI", 10);
            _TextBox.Text = Text;
            _TextBox.BackColor = Color.FromArgb(37, 39, 48);
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
            G.Clear(Color.FromArgb(37, 39, 48));
            G.DrawRectangle(new Pen(Color.FromArgb(236, 73, 99)), new Rectangle(0, 0, Width - 1, Height - 1));
        }
    }

}


