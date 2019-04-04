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
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.BlackShades
{

    public class BlackShadesNetTextBox : Control
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
        public void NewTextBox()
        {
            var _with2 = txtbox;
            _with2.Multiline = false;
            _with2.BackColor = Color.FromArgb(43, 43, 43);
            _with2.ForeColor = ForeColor;
            _with2.Text = string.Empty;
            _with2.TextAlign = HorizontalAlignment.Center;
            _with2.BorderStyle = BorderStyle.None;
            _with2.Location = new Point(5, 4);
            _with2.Font = new Font("Trebuchet MS", 8.25f, FontStyle.Bold);
            _with2.Size = new Size(Width - 10, Height - 11);
            _with2.UseSystemPasswordChar = UseSystemPasswordChar;

        }
        #endregion

        public BlackShadesNetTextBox() : base()
        {
            TextChanged += TextChng;

            NewTextBox();
            Controls.Add(txtbox);

            Text = "";
            BackColor = Color.FromArgb(36, 40, 42);
            ForeColor = Color.FromArgb(142, 152, 156);
            Size = new Size(135, 35);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            G.SmoothingMode = SmoothingMode.HighQuality;
            Draw d = new Draw();
            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);

            Height = txtbox.Height + 11;
            var _with3 = txtbox;
            _with3.Width = Width - 10;
            _with3.TextAlign = TextAlignment;
            _with3.UseSystemPasswordChar = UseSystemPasswordChar;

            G.Clear(Color.FromArgb(36, 40, 42));

            G.FillRectangle(new SolidBrush(Color.FromArgb(36, 40, 42)), ClientRectangle);
            G.DrawRectangle(new Pen(Color.FromArgb(53, 57, 60)), ClientRectangle);

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }
    
}
