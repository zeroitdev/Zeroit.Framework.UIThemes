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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.NeSeal
{
    [DefaultEvent("TextChanged")]
    public class NSTextBox : Control
    {

        private HorizontalAlignment _TextAlign = HorizontalAlignment.Left;
        public HorizontalAlignment TextAlign
        {
            get { return _TextAlign; }
            set
            {
                _TextAlign = value;
                if (Base != null)
                {
                    Base.TextAlign = value;
                }
            }
        }

        private int _MaxLength = 32767;
        public int MaxLength
        {
            get { return _MaxLength; }
            set
            {
                _MaxLength = value;
                if (Base != null)
                {
                    Base.MaxLength = value;
                }
            }
        }

        private bool _ReadOnly;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if (Base != null)
                {
                    Base.ReadOnly = value;
                }
            }
        }

        private bool _UseSystemPasswordChar;
        public bool UseSystemPasswordChar
        {
            get { return _UseSystemPasswordChar; }
            set
            {
                _UseSystemPasswordChar = value;
                if (Base != null)
                {
                    Base.UseSystemPasswordChar = value;
                }
            }
        }

        private bool _Multiline;
        public bool Multiline
        {
            get { return _Multiline; }
            set
            {
                _Multiline = value;
                if (Base != null)
                {
                    Base.Multiline = value;

                    if (value)
                    {
                        Base.Height = Height - 11;
                    }
                    else
                    {
                        Height = Base.Height + 11;
                    }
                }
            }
        }

        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                if (Base != null)
                {
                    Base.Text = value;
                }
            }
        }

        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                if (Base != null)
                {
                    Base.Font = value;
                    Base.Location = new Point(5, 5);
                    Base.Width = Width - 8;

                    if (!_Multiline)
                    {
                        Height = Base.Height + 11;
                    }
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            if (!Controls.Contains(Base))
            {
                Controls.Add(Base);
            }

            base.OnHandleCreated(e);
        }

        private TextBox Base;
        public NSTextBox()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, true);

            Cursor = Cursors.IBeam;

            Base = new TextBox();
            Base.Font = Font;
            Base.Text = Text;
            Base.MaxLength = _MaxLength;
            Base.Multiline = _Multiline;
            Base.ReadOnly = _ReadOnly;
            Base.UseSystemPasswordChar = _UseSystemPasswordChar;

            Base.ForeColor = Color.FromArgb(235, 235, 235);
            Base.BackColor = Color.FromArgb(50, 50, 50);

            Base.BorderStyle = BorderStyle.None;

            Base.Location = new Point(5, 5);
            Base.Width = Width - 14;

            if (_Multiline)
            {
                Base.Height = Height - 11;
            }
            else
            {
                Height = Base.Height + 11;
            }

            Base.TextChanged += OnBaseTextChanged;
            Base.KeyDown += OnBaseKeyDown;

            P1 = new Pen(Color.FromArgb(24, 24, 24));
            P2 = new Pen(Color.FromArgb(55, 55, 55));
        }

        private GraphicsPath GP1;

        private GraphicsPath GP2;
        private Pen P1;
        private Pen P2;

        private PathGradientBrush PB1;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            ThemeModule theme = new ThemeModule();
            var G = theme.G;

            G = e.Graphics;

            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = theme.CreateRound(0, 0, Width - 1, Height - 1, 7);
            GP2 = theme.CreateRound(1, 1, Width - 3, Height - 3, 7);

            PB1 = new PathGradientBrush(GP1);
            PB1.CenterColor = Color.FromArgb(50, 50, 50);
            PB1.SurroundColors = new Color[] { Color.FromArgb(45, 45, 45) };
            PB1.FocusScales = new PointF(0.9f, 0.5f);

            G.FillPath(PB1, GP1);

            G.DrawPath(P2, GP1);
            G.DrawPath(P1, GP2);
        }

        private void OnBaseTextChanged(object s, EventArgs e)
        {
            Text = Base.Text;
        }

        private void OnBaseKeyDown(object s, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                Base.SelectAll();
                e.SuppressKeyPress = true;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            Base.Location = new Point(5, 5);

            Base.Width = Width - 10;
            Base.Height = Height - 11;

            base.OnResize(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Base.Focus();
            base.OnMouseDown(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            Base.Focus();
            Invalidate();
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            Invalidate();
            base.OnLeave(e);
        }

    }

}


