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
using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;
using static Zeroit.Framework.UIThemes.Elegant.DrawHelpers;

namespace Zeroit.Framework.UIThemes.Elegant
{

    public class ElegantThemeTextBox : Control
    {

        #region "Declarations"
        private Color _BaseColour = Color.FromArgb(255, 255, 255);
        private Color _BorderColour = Color.FromArgb(163, 190, 146);
        private Color _LineColour = Color.FromArgb(221, 221, 221);
        private Color _TextColour = Color.FromArgb(163, 163, 163);
        private Color _LeftPolygonColour = Color.FromArgb(248, 250, 249);
        private TextBox TB;
        private HorizontalAlignment _TextAlign = HorizontalAlignment.Left;
        private int _MaxLength = 32767;
        private bool _ReadOnly;
        private bool _UseSystemPasswordChar;
        private bool _Multiline;
        private MouseState State = MouseState.None;
        #endregion
        private Pictures _Pictures = Pictures.Username;

        #region "Properties & Events"

        public void SelectAll()
        {
            TB.Focus();
            TB.SelectAll();
            Invalidate();
        }

        [Category("Control")]
        public Color BaseColour
        {
            get { return _BaseColour; }
            set { _BaseColour = value; }
        }

        [Category("Control")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }

        [Category("Control")]
        public Color LineColour
        {
            get { return _LineColour; }
            set { _LineColour = value; }
        }

        [Category("Control")]
        public Color TextColour
        {
            get { return _TextColour; }
            set { _TextColour = value; }
        }

        [Category("Control")]
        public Color LeftPolygonColour
        {
            get { return _LeftPolygonColour; }
            set { _LeftPolygonColour = value; }
        }

        public Pictures Picture
        {
            get { return _Pictures; }
            set { _Pictures = value; }
        }

        [Category("Control")]
        public enum Pictures
        {
            Username,
            Password,
            None
        }

        [Category("Control")]
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

        [Category("Control")]
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

        [Category("Control")]
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

        [Category("Control")]
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

        [Category("Control")]
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

        [Category("Control")]
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

        [Category("Control")]
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
            if (_Pictures == Pictures.Password | _Pictures == Pictures.Username)
            {
                TB.Location = new Point(40, 6);
                TB.Width = Width - 45;
            }
            else
            {
                TB.Location = new Point(5, 6);
                TB.Width = Width - 10;
            }
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

        public ElegantThemeTextBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            TB = new TextBox();
            TB.Height = 190;
            TB.Font = new Font("Segoe UI", 9);
            TB.Text = Text;
            TB.BackColor = _BaseColour;
            TB.ForeColor = _TextColour;
            TB.MaxLength = _MaxLength;
            TB.Multiline = false;
            TB.ReadOnly = _ReadOnly;
            TB.UseSystemPasswordChar = _UseSystemPasswordChar;
            TB.BorderStyle = BorderStyle.None;
            TB.Location = new Point(40, 6);
            TB.Width = Width - 45;
            TB.TextChanged += OnBaseTextChanged;
            TB.KeyDown += OnBaseKeyDown;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G = Graphics.FromImage(B);
            GraphicsPath GP = default(GraphicsPath);
            Rectangle Base = new Rectangle(0, 0, Width, Height);
            var _with3 = G;
            _with3.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with3.SmoothingMode = SmoothingMode.HighQuality;
            _with3.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with3.Clear(BackColor);
            Point[] P = {
            new Point(0, 0),
            new Point(28, 0),
            new Point(28, Height / 2 - 6),
            new Point(34, Height / 2),
            new Point(28, Height / 2 + 6),
            new Point(28, Height),
            new Point(0, Height)
        };
            Point[] P1 = {
            new Point(28, 0),
            new Point(28, Height / 2 - 6),
            new Point(34, Height / 2),
            new Point(28, Height / 2 + 6),
            new Point(28, Height)
        };
            GP = DrawHelpers.RoundRectangle(Base, 1);
            if (_Pictures == Pictures.Username)
            {
                TB.Location = new Point(40, 6);
                TB.Width = Width - 45;
                _with3.FillPath(new SolidBrush(_BaseColour), GP);
                _with3.FillPolygon(new SolidBrush(_LeftPolygonColour), P);
                _with3.DrawLines(new Pen(_LineColour, 1), P1);
                _with3.DrawPath(new Pen((_BorderColour), 2), GP);
                _with3.FillEllipse(new SolidBrush(_TextColour), new Rectangle(10, 5, 8, 10));
                Point[] P2 = {
                new Point(5, 22),
                new Point(9, 17)
            };
                Point[] SecondLine = {
                new Point(19, 17),
                new Point(23, 22)
            };
                _with3.DrawLines(new Pen(_TextColour), P2);
                _with3.DrawLines(new Pen(_TextColour), SecondLine);
                PointF[] CurvePoints = {
                new Point(9, 17),
                new Point(14, 19),
                new Point(19, 17)
            };
                _with3.DrawCurve(new Pen(_TextColour), CurvePoints);
            }
            else if (_Pictures == Pictures.Password)
            {
                TB.Location = new Point(40, 6);
                TB.Width = Width - 45;
                _with3.FillPath(new SolidBrush(_BaseColour), GP);
                _with3.FillPolygon(new SolidBrush(_LeftPolygonColour), P);
                _with3.DrawLines(new Pen(_LineColour, 1), P1);
                _with3.DrawPath(new Pen((_BorderColour), 2), GP);
                _with3.FillEllipse(new SolidBrush(_TextColour), new Rectangle(14, 5, 9, 9));
                _with3.FillEllipse(new SolidBrush(_LeftPolygonColour), new Rectangle(18, 7, 3, 3));
                Point[] BaseKey = {
                new Point(18, 7),
                new Point(6, 18),
                new Point(6, 21),
                new Point(9, 21),
                new Point(9, 18),
                new Point(11, 19),
                new Point(10, 18),
                new Point(12, 18),
                new Point(11, 17),
                new Point(13, 17),
                new Point(12, 16),
                new Point(14, 16),
                new Point(13, 15),
                new Point(15, 15),
                new Point(15, 14),
                new Point(16, 14),
                new Point(15, 13)
            };
                _with3.DrawLines(new Pen(_TextColour), BaseKey);
            }
            else
            {
                _with3.FillPath(new SolidBrush(_BaseColour), GP);
                _with3.DrawPath(new Pen((_BorderColour), 2), GP);
                TB.Location = new Point(5, 6);
                TB.Width = Width - 10;
            }
            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }

        #endregion

    }


}


