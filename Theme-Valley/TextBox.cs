﻿// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="TextBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Valley
{
    [DefaultEvent("TextChanged")]
    public class ValleyTextBox : Control
    {
        #region  Variables

        private MouseState State = MouseState.None;
        private TextBox TB;

        #endregion

        #region  Properties

        #region  TextBox Properties

        private HorizontalAlignment _TextAlign = HorizontalAlignment.Left;
        [Category("Options")]
        public HorizontalAlignment TextAlign
        {
            get
            {
                return _TextAlign;
            }
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
            get
            {
                return _MaxLength;
            }
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
            get
            {
                return _ReadOnly;
            }
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
            get
            {
                return _UseSystemPasswordChar;
            }
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
            get
            {
                return _Multiline;
            }
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
            get
            {
                return base.Text;
            }
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
            get
            {
                return base.Font;
            }
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
            if (!(Controls.Contains(TB)))
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

        #endregion

        #region  Colors

        [Category("Colors")]
        public Color TextColor
        {
            get
            {
                return _TextColor;
            }
            set
            {
                _TextColor = value;
            }
        }

        public override Color ForeColor
        {
            get
            {
                return _TextColor;
            }
            set
            {
                _TextColor = value;
            }
        }

        #endregion

        #region  Mouse States

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
            TB.Focus();
            Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            TB.Focus();
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

        #region  Colors

        private Color _BaseColor;
        private Color _TextColor = Color.FromArgb(131, 131, 131);
        private Color _BorderColor = Color.FromArgb(191, 191, 191);

        #endregion

        public ValleyTextBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;

            BackColor = Color.Transparent;
            _BaseColor = BackColor;
            TB = new TextBox();
            TB.Font = Font;
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

        protected override void OnPaint(PaintEventArgs e)
        {
            var G = e.Graphics;
            G.Clear(Color.FromArgb(242, 242, 242));
            G.DrawRectangle(new Pen(_BorderColor), new Rectangle(0, 0, Width - 1, Height - 1));
            base.OnPaint(e);


        }

    }
}

