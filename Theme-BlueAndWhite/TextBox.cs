// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="TextBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.BlueWhite
{

    [DefaultEvent("TextChanged")]
    public class BaWGUITextBox : Control
    {
        #region " Declarations "
        private GraphicsPath Side;
        private GraphicsPath Button;
        private LinearGradientBrush ButtonOGB;
        private LinearGradientBrush ButtonGB;
        private Pen P1;
        private Pen P2;

        private SolidBrush B1;
        private TextBox withEventsField_TBox;
        private TextBox TBox
        {
            get { return withEventsField_TBox; }
            set
            {
                if (withEventsField_TBox != null)
                {
                    withEventsField_TBox.KeyDown -= OnBaseKeyDown;
                    withEventsField_TBox.TextChanged -= OnBaseTextChanged;
                }
                withEventsField_TBox = value;
                if (withEventsField_TBox != null)
                {
                    withEventsField_TBox.KeyDown += OnBaseKeyDown;
                    withEventsField_TBox.TextChanged += OnBaseTextChanged;
                }
            }

        }
        private int _MaxLength = 32767;
        private bool _ReadOnly;
        private bool _UseSystemPasswordChar;
        private bool _Multiline;
        #endregion
        private Image _Image;

        #region " Properties "
        [Category("Options")]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                if (TBox != null)
                {
                    TBox.Font = value;
                    TBox.Location = new Point(3, 5);
                    TBox.Width = Width - 6;

                    if (!_Multiline)
                    {
                        Height = TBox.Height + 11;
                    }
                }
            }
        }

        [Category("Appearance")]
        public Image Image
        {
            get { return _Image; }
            set { _Image = value; }
        }

        [Category("Options")]
        public int MaxLength
        {
            get { return _MaxLength; }
            set
            {
                _MaxLength = value;
                if (TBox != null)
                {
                    TBox.MaxLength = value;
                }
            }
        }

        [Category("Options")]
        public bool Multiline
        {
            get { return _Multiline; }
            set
            {
                _Multiline = value;
                if (TBox != null)
                {
                    TBox.Multiline = value;

                    if (value)
                    {
                        TBox.Height = Height - 11;
                    }
                    else
                    {
                        Height = TBox.Height + 11;
                    }

                }
            }
        }

        [Category("Options")]
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if (TBox != null)
                {
                    TBox.ReadOnly = value;
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
                if (TBox != null)
                {
                    TBox.Text = value;
                }
            }
        }

        [Category("Options")]
        public bool UseSystemPasswordChar
        {
            get { return _UseSystemPasswordChar; }
            set
            {
                _UseSystemPasswordChar = value;
                if (TBox != null)
                {
                    TBox.UseSystemPasswordChar = value;
                }
            }
        }
        #endregion

        public BaWGUITextBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Font = new Font("Arial", 16);
            Size = new Size(125, 53);

            TBox = new TextBox();
            var _with1 = TBox;
            _with1.BackColor = Color.FromArgb(245, 245, 245);
            _with1.BorderStyle = BorderStyle.None;
            _with1.Cursor = Cursors.IBeam;
            _with1.Font = Font;
            _with1.ForeColor = Color.FromArgb(185, 185, 185);
            _with1.Height = Height - 11;
            _with1.Location = new Point(5, 5);
            _with1.MaxLength = _MaxLength;
            _with1.Multiline = _Multiline;
            _with1.ReadOnly = _ReadOnly;
            _with1.Text = Text;
            _with1.UseSystemPasswordChar = _UseSystemPasswordChar;
            _with1.Width = Width - 10;

            P1 = new Pen(Color.FromArgb(180, 180, 180));
            B1 = new SolidBrush(Color.FromArgb(245, 245, 245));
        }

        private void OnBaseKeyDown(object s, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                TBox.SelectAll();
                e.SuppressKeyPress = true;
            }
            if (e.Control && e.KeyCode == Keys.C)
            {
                TBox.Copy();
                e.SuppressKeyPress = true;
            }
        }

        private void OnBaseTextChanged(object s, EventArgs e)
        {
            Text = TBox.Text;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (!Controls.Contains(TBox))
            {
                Controls.Add(TBox);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            if (Width > 0 && Height > 0)
            {
                if (Controls.Contains(TBox) && !_Multiline && _Image != null)
                {
                    TBox.Location = new Point(20, 14);
                    TBox.Width = Width - 81;
                    Height = 53;
                }
                else if (Controls.Contains(TBox) && _Multiline)
                {
                    TBox.Location = new Point(5, 5);
                    TBox.Width = Width - 10;
                    TBox.Height = Height - 11;
                }
                else if (Controls.Contains(TBox) && !_Multiline)
                {
                    TBox.Location = new Point(5, 5);
                    TBox.Width = Width - 10;
                    TBox.Height = Height - 11;
                    Height = 53;
                }


                Side = new GraphicsPath();
                Button = new GraphicsPath();

                ButtonOGB = new LinearGradientBrush(new Rectangle(Width - 51, 0, Width, Height), Color.FromArgb(125, 180, 235), Color.FromArgb(45, 125, 200), 90);
                ButtonGB = new LinearGradientBrush(new Rectangle(Width - 50, 0, Width, Height), Color.FromArgb(175, 215, 240), Color.FromArgb(70, 145, 215), 90);

                P2 = new Pen(ButtonOGB);

                var _with2 = Side;
                _with2.AddArc(0, 0, 10, 10, 180, 90);
                _with2.AddArc(Width - 11, 0, 10, 10, -90, 90);
                _with2.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
                _with2.AddArc(0, Height - 11, 10, 10, 90, 90);
                _with2.CloseFigure();
                var _with3 = Button;
                _with3.AddLine(Width - 51, Height - 1, Width - 51, 0);
                _with3.AddArc(Width - 11, 0, 10, 10, -90, 90);
                _with3.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
                _with3.CloseFigure();
            }

            Invalidate();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var _with4 = e.Graphics;
            _with4.SmoothingMode = SmoothingMode.HighQuality;

            _with4.FillPath(B1, Side);
            _with4.DrawPath(P1, Side);

            if (!_Multiline && _Image != null)
            {
                _with4.FillPath(ButtonGB, Button);
                _with4.DrawPath(P2, Button);

                _with4.DrawImage(_Image, Width - 42, 11, 32, 32);
            }

            base.OnPaint(e);
        }
    }

}


