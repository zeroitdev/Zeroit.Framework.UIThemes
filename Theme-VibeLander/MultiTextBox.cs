// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="MultiTextBox.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.VibeLander
{
    public class VibeMultiTxtBox : ThemeControl
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
            #region "lol"
        }
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

        #endregion

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 15:
                    Invalidate();
                    base.WndProc(ref m);
                    this.PaintHook();
                    break; // TODO: might not be correct. Was : Exit Select

                    break;
                default:
                    base.WndProc(ref m);
                    break; // TODO: might not be correct. Was : Exit Select

                    break;
            }
        }

        public VibeMultiTxtBox() : base()
        {
            TextChanged += TextChng;

            Controls.Add(txtbox);
            var _with3 = txtbox;
            _with3.ScrollBars = ScrollBars.Vertical;
            _with3.Multiline = true;
            _with3.BackColor = Color.FromArgb(0, 0, 0);
            _with3.ForeColor = ForeColor;
            _with3.Text = string.Empty;
            _with3.TextAlign = HorizontalAlignment.Center;
            _with3.BorderStyle = BorderStyle.None;
            _with3.Location = new Point(5, 8);
            _with3.Font = new Font("Arial", 8.25f, FontStyle.Bold);
            _with3.Size = new Size(Width - 8, Height - 11);
            _with3.UseSystemPasswordChar = UseSystemPasswordChar;

            Text = "";

            DoubleBuffered = true;
        }

        public override void PaintHook()
        {
            this.BackColor = Color.White;
            G.Clear(Parent.BackColor);
            Pen p = new Pen(Color.FromArgb(204, 204, 204), 1);
            Pen o = new Pen(Color.FromArgb(252, 252, 252), 7);
            G.FillPath(Brushes.White, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));
            G.DrawPath(o, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));
            G.DrawPath(p, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));
            Font drawFont = new Font("Tahoma", 9, FontStyle.Regular);
            var _with4 = txtbox;
            _with4.Size = new Size(Width - 10, Height - 14);
            _with4.ForeColor = Color.FromArgb(72, 72, 72);
            _with4.Font = drawFont;
            _with4.TextAlign = TextAlignment;
            _with4.UseSystemPasswordChar = UseSystemPasswordChar;
            DrawCorners(Parent.BackColor, ClientRectangle);
        }
    }

}

