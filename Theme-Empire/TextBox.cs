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
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Empire
{
    [DefaultEvent("TextChanged")]
    public class TheEmpireTextBox : Control
    {

        #region "CreateRound"
        private GraphicsPath CreateRoundPath;

        private Rectangle CreateRoundRectangle;
        public GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
        {
            CreateRoundRectangle = new Rectangle(x, y, width, height);
            return CreateRound(CreateRoundRectangle, slope);
        }

        public GraphicsPath CreateRound(Rectangle r, int slope)
        {
            CreateRoundPath = new GraphicsPath(FillMode.Winding);
            CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
            CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270f, 90f);
            CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0f, 90f);
            CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90f, 90f);
            CreateRoundPath.CloseFigure();
            return CreateRoundPath;
        }
        #endregion

        #region "Properties"
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
                        Base.Height = Height - 7;
                        Base.Location = new Point(3, 3);
                    }
                    else
                    {
                        Height = Base.Height + 7;
                        Base.Location = new Point(6, 3);
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
                    Base.Location = new Point(6, 3);
                    Base.Width = Width - 12;

                    if (!_Multiline)
                    {
                        Height = Base.Height + 7;
                    }
                }
            }
        }

        public int SelectionStart
        {
            get { return Base.SelectionStart; }
            set
            {
                Base.SelectionStart = value;
                Invalidate();
            }
        }

        public int SelectionLength
        {
            get { return Base.SelectionLength; }
            set
            {
                Base.SelectionLength = value;
                Invalidate();
            }
        }

        public int TextLength
        {
            get { return Base.TextLength; }
        }

        public void ScrollToCaret()
        {
            Base.ScrollToCaret();
        }

        public void Clear()
        {
            Base.Text = string.Empty;
        }

        #endregion

        #region "Mouse events"

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            Invalidate();
            base.OnMouseDown(e);
        }

        #endregion

        protected override void InitLayout()
        {
            if (!Controls.Contains(Base))
            {
                Controls.Add(Base);
            }
            base.InitLayout();
        }

        private TextBox Base;
        public TheEmpireTextBox()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Font = new Font("Segoe UI", 9);

            Base = new TextBox();

            Base.Font = Font;
            Base.Text = Text;
            Base.ForeColor = Color.Black;
            Base.BackColor = Color.LightGray;
            Base.MaxLength = _MaxLength;
            Base.Multiline = _Multiline;
            Base.ReadOnly = _ReadOnly;
            Base.UseSystemPasswordChar = _UseSystemPasswordChar;
            Base.BorderStyle = BorderStyle.None;
            Base.Location = new Point(6, 3);
            Base.Width = Width - 12;

            if (_Multiline)
            {
                Base.Height = Height - 7;
            }
            else
            {
                Height = Base.Height + 7;
            }

            Base.TextChanged += OnBaseTextChanged;
            Base.KeyDown += OnBaseKeyDown;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.FillPath(new SolidBrush(Color.LightGray), CreateRound(0, 0, Width - 1, Height - 1, 6));
            e.Graphics.DrawPath(new Pen(Color.FromArgb(100, 100, 100)), CreateRound(0, 0, Width - 1, Height - 1, 6));

            base.OnPaint(e);
        }

        private void OnBaseTextChanged(object s, EventArgs e)
        {
            Text = Base.Text;
            Base.BringToFront();
            if (Text.Length == 0)
            {
                Base.Focus();
                Base.SelectionStart = 0;
                Base.SelectionLength = 0;
                Base.Select();
            }
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
            Base.Location = new Point(6, 3);
            Base.Width = Width - 12;

            if (_Multiline)
            {
                Base.Height = Height - 7;
                Base.Location = new Point(3, 3);
            }
            else
            {
                Base.Location = new Point(6, 3);
            }
            base.OnResize(e);
        }

    }


}