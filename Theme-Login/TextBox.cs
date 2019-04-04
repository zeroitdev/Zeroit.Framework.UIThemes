// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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

using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using static Zeroit.Framework.UIThemes.Login.DrawHelpers;

namespace Zeroit.Framework.UIThemes.Login
{

    [DefaultEvent("TextChanged")]
    public class LogInUserTextBox : Control
    {

        #region "Declarations"
        private MouseState State = MouseState.None;
        private TextBox TB;
        private Color _BaseColour = Color.FromArgb(42, 42, 42);
        private Color _TextColour = Color.FromArgb(255, 255, 255);
        #endregion
        private Color _BorderColour = Color.FromArgb(35, 35, 35);

        #region "TextBox Properties"

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
                    TB.Width = Width - 35;

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
            TB.Width = Width - 35;

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

        #region "Colour Properties"

        [Category("Colours")]
        public Color BackgroundColour
        {
            get { return _BaseColour; }
            set { _BaseColour = value; }
        }

        [Category("Colours")]
        public Color TextColour
        {
            get { return _TextColour; }
            set { _TextColour = value; }
        }

        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }

        #endregion

        #region "Mouse States"

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
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }

        #endregion

        #region "Draw Control"
        public LogInUserTextBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            TB = new TextBox();
            TB.Height = 190;
            TB.Font = new Font("Segoe UI", 10);
            TB.Text = Text;
            TB.BackColor = Color.FromArgb(42, 42, 42);
            TB.ForeColor = Color.FromArgb(255, 255, 255);
            TB.MaxLength = _MaxLength;
            TB.Multiline = false;
            TB.ReadOnly = _ReadOnly;
            TB.UseSystemPasswordChar = _UseSystemPasswordChar;
            TB.BorderStyle = BorderStyle.None;
            TB.Location = new Point(5, 5);
            TB.Width = Width - 35;
            TB.TextChanged += OnBaseTextChanged;
            TB.KeyDown += OnBaseKeyDown;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            GraphicsPath GP = default(GraphicsPath);
            Rectangle Base = new Rectangle(0, 0, Width, Height);
            var _with3 = G;
            _with3.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with3.SmoothingMode = SmoothingMode.HighQuality;
            _with3.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with3.Clear(BackColor);
            TB.BackColor = Color.FromArgb(42, 42, 42);
            TB.ForeColor = Color.FromArgb(255, 255, 255);
            GP = DrawHelpers.RoundRectangle(Base, 6);
            _with3.FillPath(new SolidBrush(Color.FromArgb(42, 42, 42)), GP);
            _with3.DrawPath(new Pen(new SolidBrush(Color.FromArgb(35, 35, 35)), 2), GP);
            GP.Dispose();
            _with3.FillPie(new SolidBrush(Parent.FindForm().BackColor), new Rectangle(Width - 25, Height - 23, Height + 25, Height + 25), 180, 90);
            _with3.DrawPie(new Pen(Color.FromArgb(35, 35, 35), 2), new Rectangle(Width - 25, Height - 23, Height + 25, Height + 25), 180, 90);
            _with3.InterpolationMode = (InterpolationMode)7;
        }



        #endregion

    }

}


