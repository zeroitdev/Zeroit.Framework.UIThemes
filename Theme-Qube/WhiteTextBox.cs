// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="WhiteTextBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Qube
{
    public class QubeWhiteTextbox : Control
    {
        private TextBox withEventsField__tb = new TextBox();
        public TextBox _tb
        {
            get { return withEventsField__tb; }
            set
            {
                if (withEventsField__tb != null)
                {
                    withEventsField__tb.TextChanged -= TextChangeTb;
                }
                withEventsField__tb = value;
                if (withEventsField__tb != null)
                {
                    withEventsField__tb.TextChanged += TextChangeTb;
                }
            }

        }
        #region "Declaration and shits"
        public GraphicsPath RoundRect(Rectangle rectangle, int curve)
        {
            GraphicsPath p = new GraphicsPath();
            int arcRectangleWidth = curve * 2;
            p.AddArc(new Rectangle(rectangle.X, rectangle.Y, arcRectangleWidth, arcRectangleWidth), -180, 90);
            p.AddArc(new Rectangle(rectangle.Width - arcRectangleWidth + rectangle.X, rectangle.Y, arcRectangleWidth, arcRectangleWidth), -90, 90);
            p.AddArc(new Rectangle(rectangle.Width - arcRectangleWidth + rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y, arcRectangleWidth, arcRectangleWidth), 0, 90);
            p.AddArc(new Rectangle(rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y, arcRectangleWidth, arcRectangleWidth), 90, 90);
            p.AddLine(new Point(rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y), new Point(rectangle.X, curve + rectangle.Y));
            return p;
        }
        public GraphicsPath RoundRect(int x, int y, int width, int height, int curve)
        {
            Rectangle rectangle = new Rectangle(x, y, width, height);
            GraphicsPath p = new GraphicsPath();
            int arcRectangleWidth = curve * 2;
            p.AddArc(new Rectangle(rectangle.X, rectangle.Y, arcRectangleWidth, arcRectangleWidth), -180, 90);
            p.AddArc(new Rectangle(rectangle.Width - arcRectangleWidth + rectangle.X, rectangle.Y, arcRectangleWidth, arcRectangleWidth), -90, 90);
            p.AddArc(new Rectangle(rectangle.Width - arcRectangleWidth + rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y, arcRectangleWidth, arcRectangleWidth), 0, 90);
            p.AddArc(new Rectangle(rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y, arcRectangleWidth, arcRectangleWidth), 90, 90);
            p.AddLine(new Point(rectangle.X, rectangle.Height - arcRectangleWidth + rectangle.Y), new Point(rectangle.X, curve + rectangle.Y));
            return p;
        }

        private bool _allowpassword = false;
        public new bool UseSystemPasswordChar
        {
            get { return _allowpassword; }
            set
            {
                _tb.UseSystemPasswordChar = UseSystemPasswordChar;
                _allowpassword = value;
                Invalidate();
            }
        }

        private int _maxChars = 32767;
        public new int MaxLength
        {
            get { return _maxChars; }
            set
            {
                _maxChars = value;
                _tb.MaxLength = MaxLength;
                Invalidate();
            }
        }

        private HorizontalAlignment _textAlignment;
        public new HorizontalAlignment TextAlign
        {
            get { return _textAlignment; }
            set
            {
                _textAlignment = value;
                Invalidate();
            }
        }

        private bool _multiLine = false;
        public new bool MultiLine
        {
            get { return _multiLine; }
            set
            {
                _multiLine = value;
                _tb.Multiline = value;
                OnResize(EventArgs.Empty);
                Invalidate();
            }
        }

        private bool _readOnly = false;
        public new bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                if (_tb != null)
                {
                    _tb.ReadOnly = value;
                }
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            Invalidate();
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            _tb.ForeColor = ForeColor;
            Invalidate();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            _tb.Font = Font;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            _tb.Focus();
        }

        private void TextChangeTb(object sender, EventArgs e)
        {
            Text = _tb.Text;
        }

        private void TextChng(object sender, EventArgs e)
        {
            _tb.Text = Text;
        }

        #endregion

        public void NewTextBox()
        {
            var _with1 = _tb;
            _with1.Text = string.Empty;
            _with1.BackColor = Color.FromArgb(68, 76, 99);
            _with1.ForeColor = ForeColor;
            _with1.TextAlign = HorizontalAlignment.Center;
            _with1.BorderStyle = BorderStyle.None;
            _with1.Location = new Point(3, 3);
            _with1.Font = new Font("Verdana", 10, FontStyle.Regular);
            _with1.Size = new Size(Width - 3, Height - 3);
            _with1.UseSystemPasswordChar = UseSystemPasswordChar;
        }

        public QubeWhiteTextbox()
            : base()
        {
            TextChanged += TextChng;
            NewTextBox();
            Controls.Add(_tb);
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            TextAlign = HorizontalAlignment.Center;
            BackColor = Color.FromArgb(255, 255, 255);
            ForeColor = Color.FromArgb(255, 255, 251);
            Font = new Font("Verdana", 10, FontStyle.Regular);
            Size = new Size(132, 29);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            base.OnPaint(e);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            var _with2 = _tb;
            _with2.TextAlign = TextAlign;
            _with2.UseSystemPasswordChar = UseSystemPasswordChar;
            g.FillPath(new SolidBrush(Color.FromArgb(68, 76, 99)), RoundRect(rect, 3));
            g.DrawPath(new Pen(Color.FromArgb(0, 182, 248)), RoundRect(rect, 3));
            e.Graphics.DrawImage(b, new Point(0, 0));
            g.Dispose();
            b.Dispose();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (!MultiLine)
            {
                int tbheight = _tb.Height;
                _tb.Location = new Point(10, Convert.ToInt32(((Height / 2) - (tbheight / 2) - 0)));
                _tb.Size = new Size(Width - 20, tbheight);
            }
            else
            {
                _tb.Location = new Point(10, 10);
                _tb.Size = new Size(Width - 20, Height - 20);
            }
        }
    }

}
