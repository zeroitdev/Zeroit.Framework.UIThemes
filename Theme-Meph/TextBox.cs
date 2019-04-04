// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Meph
{

    public class MephTextBox : Control
    {
        private TextBox withEventsField_txtbox = new TextBox();
        public TextBox txtbox
        {
            get { return withEventsField_txtbox; }
            set
            {
                if (withEventsField_txtbox != null)
                {
                    withEventsField_txtbox.TextChanged -= TextChngTxtBox;
                }
                withEventsField_txtbox = value;
                if (withEventsField_txtbox != null)
                {
                    withEventsField_txtbox.TextChanged += TextChngTxtBox;
                }
            }

        }
        #region " Control Help - Properties & Flicker Control "
        private bool _passmask = false;
        public new bool UseSystemPasswordChar
        {
            get { return _passmask; }
            set
            {
                txtbox.UseSystemPasswordChar = UseSystemPasswordChar;
                _passmask = value;
                Invalidate();
            }
        }
        private int _maxchars = 32767;
        public new int MaxLength
        {
            get { return _maxchars; }
            set
            {
                _maxchars = value;
                txtbox.MaxLength = MaxLength;
                Invalidate();
            }
        }
        private HorizontalAlignment _align;
        public new HorizontalAlignment TextAlignment
        {
            get { return _align; }
            set
            {
                _align = value;
                Invalidate();
            }
        }
        private bool _multiline = false;
        public new bool MultiLine
        {
            get { return _multiline; }
            set
            {
                _multiline = value;
                Invalidate();
            }
        }
        private bool _wordwrap = false;
        public new bool WordWrap
        {
            get { return _wordwrap; }
            set
            {
                _wordwrap = value;
                Invalidate();
            }
        }

        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        protected override void OnBackColorChanged(System.EventArgs e)
        {
            base.OnBackColorChanged(e);
            txtbox.BackColor = BackColor;
            Invalidate();
        }
        protected override void OnForeColorChanged(System.EventArgs e)
        {
            base.OnForeColorChanged(e);
            txtbox.ForeColor = ForeColor;
            Invalidate();
        }
        protected override void OnFontChanged(System.EventArgs e)
        {
            base.OnFontChanged(e);
            txtbox.Font = Font;
        }
        protected override void OnGotFocus(System.EventArgs e)
        {
            base.OnGotFocus(e);
            txtbox.Focus();
        }
        public void TextChngTxtBox(object sender, EventArgs e)
        {
            Text = txtbox.Text;
        }
        public void TextChng(object sender, EventArgs e)
        {
            txtbox.Text = Text;
        }
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            if (MultiLine == false)
            {
                Height = 24;
            }
        }
        public void NewTextBox()
        {
            var _with1 = txtbox;
            _with1.Multiline = MultiLine;
            _with1.BackColor = Color.FromArgb(50, 50, 50);
            _with1.ForeColor = ForeColor;
            _with1.Text = string.Empty;
            _with1.TextAlign = HorizontalAlignment.Center;
            _with1.BorderStyle = BorderStyle.None;
            _with1.Location = new Point(5, 4);
            _with1.Font = new Font("Verdana", 8, FontStyle.Regular);
            if (MultiLine == true)
            {
                if (WordWrap == true)
                {
                    _with1.WordWrap = true;
                }
                else
                {
                    _with1.WordWrap = false;
                }
            }
            else
            {
                if (WordWrap == true)
                {
                    _with1.WordWrap = true;
                }
                else
                {
                    _with1.WordWrap = false;
                }
            }
            _with1.Size = new Size(Width - 10, Height - 11);
            _with1.UseSystemPasswordChar = UseSystemPasswordChar;

        }
        #endregion

        public MephTextBox() : base()
        {
            TextChanged += TextChng;

            NewTextBox();
            Controls.Add(txtbox);
            Text = "";
            BackColor = Color.FromArgb(50, 50, 50);
            ForeColor = Color.Silver;
            Size = new Size(135, 24);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            G.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);

            var _with2 = txtbox;
            _with2.Multiline = MultiLine;
            if (MultiLine == false)
            {
                Height = txtbox.Height + 11;
                if (WordWrap == true)
                {
                    _with2.WordWrap = true;
                }
                else
                {
                    _with2.WordWrap = false;
                }
            }
            else
            {
                txtbox.Height = Height - 11;
                if (WordWrap == true)
                {
                    _with2.WordWrap = true;
                }
                else
                {
                    _with2.WordWrap = false;
                }
            }
            _with2.Width = Width - 10;
            _with2.TextAlign = TextAlignment;
            _with2.UseSystemPasswordChar = UseSystemPasswordChar;

            G.Clear(BackColor);

            Color[] c = new Color[] {
            Color.FromArgb(20, 20, 20),
            Color.FromArgb(40, 40, 40),
            Color.FromArgb(45, 45, 45),
            Color.FromArgb(46, 46, 46),
            Color.FromArgb(47, 47, 47),
            Color.FromArgb(48, 48, 48),
            Color.FromArgb(49, 49, 49),
            Color.FromArgb(50, 50, 50)
        };
            G.FillPath(new SolidBrush(Color.FromArgb(50, 50, 50)), Draw.RoundRect(ClientRectangle, 3));
            Draw.InnerGlowRounded(G, ClientRectangle, 3, c);

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

}


