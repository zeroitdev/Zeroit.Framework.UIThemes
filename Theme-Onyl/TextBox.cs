// ***********************************************************************
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
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Onyl
{
    public class OnylTextBox : Control
    {
        private TextBox @base;

        private int _maxLength;
        private bool _readOnly;
        private bool _useSystemPasswordChar;
        private Image _image;

        public int MaxLength
        {
            get
            {
                return _maxLength;
            }
            set
            {
                _maxLength = value;
                if (@base != null)
                {
                    @base.MaxLength = value;
                }
            }
        }

        public bool ReadOnyl
        {
            get
            {
                return _readOnly;
            }
            set
            {
                _readOnly = value;
                if (@base != null)
                {
                    @base.ReadOnly = value;
                }
            }
        }

        public bool UseSystemPasswordChar
        {
            get
            {
                return _useSystemPasswordChar;
            }
            set
            {
                _useSystemPasswordChar = value;
                if (@base != null)
                {
                    @base.UseSystemPasswordChar = value;
                }
            }
        }

        public Image Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                ApplySizing();
                Invalidate();
            }
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
                if (@base != null)
                {
                    @base.Text = value;
                }
            }
        }

        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                if (@base != null)
                {
                    @base.Font = value;
                    @base.Location = new Point(3, 5);
                    @base.Width = Width - 6;
                }
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (!(Controls.Contains(@base)))
            {
                Controls.Add(@base);
            }
        }

        public OnylTextBox()
        {

            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            Cursor = Cursors.IBeam;
            Font = new Font("Arial", 10);

            MaxLength = 32767;

            @base = new TextBox();
            @base.BackColor = Color.FromArgb(10, 75, 95);
            @base.Font = Font;
            @base.Text = Text;
            @base.ForeColor = Color.WhiteSmoke;
            @base.MaxLength = _maxLength;
            @base.ReadOnly = _readOnly;
            @base.UseSystemPasswordChar = _useSystemPasswordChar;
            @base.BorderStyle = BorderStyle.None;
            @base.Location = new Point(10, 8);
            @base.Width = Width - 10;

            Height = @base.Height + 13;

            backBrush = new SolidBrush(Color.FromArgb(10, 75, 95));
            borderPen = new Pen(Color.FromArgb(70, 120, 135));

            @base.TextChanged += OnBaseTextChanged;
            @base.KeyDown += OnBaseKeyDown;

        }

        private Rectangle boundsRect;
        private Rectangle imageRect;

        private SolidBrush backBrush;
        private Pen borderPen;

        protected override void OnPaint(PaintEventArgs e)
        {

            ThemeModule.g = e.Graphics;
            ThemeModule.g.Clear(Parent.BackColor);
            ThemeModule.g.SmoothingMode = SmoothingMode.AntiAlias;

            boundsRect = new Rectangle(0, 0, Width - 1, Height - 1);
            ThemeModule.g.FillRectangle(backBrush, boundsRect);
            ThemeModule.g.DrawRectangle(borderPen, boundsRect);

            if (_image != null)
            {
                imageRect = new Rectangle(Width - 27, 6, 20, 20);
                ThemeModule.g.DrawImage(_image, imageRect);
            }

        }

        private void OnBaseTextChanged(object s, EventArgs e)
        {
            Text = @base.Text;
        }

        private void OnBaseKeyDown(object s, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                @base.SelectAll();
                e.SuppressKeyPress = true;
            }
        }

        private void ApplySizing()
        {
            @base.Location = new Point(10, 8);
            if (_image != null)
            {
                @base.Width = Width - 44;
            }
            else
            {
                @base.Width = Width - 20;
            }
            Height = @base.Height + 16;
        }

        protected override void OnResize(EventArgs e)
        {
            ApplySizing();
            base.OnResize(e);
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            @base.SelectionStart = @base.TextLength;
            @base.Focus();
            base.OnMouseDown(e);
        }

    }
}
