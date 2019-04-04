// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TextBox.cs" company="Zeroit Dev Technologies">
//    This program is for creating Theme controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Butter
{
    public class ButterscotchTextBox : Control
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

        public void NewTextBox()
        {
            var _with1 = _tb;
            _with1.Text = string.Empty;
            _with1.BackColor = Color.FromArgb(48, 43, 39);
            _with1.ForeColor = ForeColor;
            _with1.TextAlign = HorizontalAlignment.Center;
            _with1.BorderStyle = BorderStyle.None;
            _with1.Location = new Point(3, 3);
            _with1.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            _with1.Size = new Size(Width - 3, Height - 3);
            _with1.UseSystemPasswordChar = UseSystemPasswordChar;
        }

        public ButterscotchTextBox()
            : base()
        {
            TextChanged += TextChng;
            NewTextBox();
            Controls.Add(_tb);
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(48, 43, 39);
            ForeColor = Color.FromArgb(255, 255, 255);
            Font = new Font("Segoe UI", 11, FontStyle.Regular);
            Size = new Size(200, 30);
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
            g.FillPath(new SolidBrush(Color.FromArgb(48, 43, 39)), Draw.RoundRect(rect, 1));
            g.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(rect, 1));
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
                _tb.Location = new Point(10, Convert.ToInt32(((Height / 2) - (tbheight / 2) - 1)));
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
