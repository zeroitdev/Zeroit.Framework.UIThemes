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
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.VisualStudio
{
    public class VisualStudioNormalTextBox : Control
    {
        #region Declarations
        private MouseState State = MouseState.None;
        private TextBox TB;
        private Color _BaseColour = Color.FromArgb(51, 51, 55);
        private Color _TextColour = Color.FromArgb(153, 153, 153);
        private Color _BorderColour = Color.FromArgb(35, 35, 35);
        private Styles _Style = Styles.NotRounded;
        private HorizontalAlignment _TextAlign = HorizontalAlignment.Left;
        private int _MaxLength = 32767;
        private bool _ReadOnly;
        private bool _UseSystemPasswordChar;
        private bool _Multiline;
        #endregion

        #region TextBox Properties

        public enum Styles
        {
            Rounded,
            NotRounded
        }

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
                        TB.Height = Height - 7;
                    }
                    else
                    {
                        Height = TB.Height + 7;
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
                        Height = TB.Height + 7;
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
                TB.Height = Height - 7;
            }
            else
            {
                Height = TB.Height + 7;
            }

            base.OnResize(e);
        }

        public Styles Style
        {
            get
            {
                return _Style;
            }
            set
            {
                _Style = value;
                Invalidate();
            }
        }

        public void SelectAll()
        {
            TB.Focus();
            TB.SelectAll();
        }


        #endregion

        #region Colour Properties

        [Category("Colours")]
        public Color BackgroundColour
        {
            get
            {
                return _BaseColour;
            }
            set
            {
                _BaseColour = value;
            }
        }

        [Category("Colours")]
        public Color TextColour
        {
            get
            {
                return _TextColour;
            }
            set
            {
                _TextColour = value;
            }
        }

        [Category("Colours")]
        public Color BorderColour
        {
            get
            {
                return _BorderColour;
            }
            set
            {
                _BorderColour = value;
            }
        }

        #endregion

        #region Mouse States

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

        #region Draw Control
        public VisualStudioNormalTextBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            TB = new TextBox();
            TB.Height = 20;
            TB.Font = new Font("Segoe UI", 10);
            TB.Text = Text;
            TB.BackColor = _BaseColour;
            TB.ForeColor = _TextColour;
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
            var g = e.Graphics;
            GraphicsPath GP = null;
            Rectangle Base = new Rectangle(0, 0, Width, Height);
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.Clear(BackColor);
            TB.BackColor = _BaseColour;
            TB.ForeColor = _TextColour;
            switch (_Style)
            {
                case Styles.Rounded:
                    GP = DrawHelpers.RoundRectangle(Base, 6);
                    g.FillPath(new SolidBrush(Color.FromArgb(42, 42, 42)), GP);
                    g.DrawPath(new Pen(new SolidBrush(Color.FromArgb(35, 35, 35)), 2F), GP);
                    GP.Dispose();
                    break;
                case Styles.NotRounded:
                    g.FillRectangle(new SolidBrush(_BaseColour), new Rectangle(0, 0, Width - 1, Height - 1));
                    g.DrawRectangle(new Pen(Color.FromArgb(63, 63, 70), 2F), new Rectangle(0, 0, Width, Height));
                    break;
            }
            g.InterpolationMode = (InterpolationMode)7;
        }

        #endregion

    }

}
