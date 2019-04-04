// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TextBox.cs" company="Zeroit Dev Technologies">
//     Copyright � Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Ubuntu
{
    public class UbuntuTextBox : Control
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
            var _with1 = txtbox;
            _with1.Multiline = false;
            _with1.BackColor = Color.FromArgb(43, 43, 43);
            _with1.ForeColor = ForeColor;
            _with1.Text = string.Empty;
            _with1.TextAlign = HorizontalAlignment.Center;
            _with1.BorderStyle = BorderStyle.None;
            _with1.Location = new Point(5, 4);
            _with1.Font = new Font("Trebuchet MS", 8.25f, FontStyle.Bold);
            _with1.Size = new Size(Width - 10, Height - 11);
            _with1.UseSystemPasswordChar = UseSystemPasswordChar;

        }
        #endregion

        public UbuntuTextBox() : base()
        {
            TextChanged += TextChng;

            NewTextBox();
            Controls.Add(txtbox);

            Text = "";
            BackColor = Color.White;
            ForeColor = Color.FromArgb(102, 102, 102);
            Size = new Size(135, 35);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);

            Height = txtbox.Height + 11;
            Font drawFont = new Font("Tahoma", 9, FontStyle.Regular);
            var _with2 = txtbox;
            _with2.Width = Width - 12;
            _with2.ForeColor = Color.FromArgb(102, 102, 102);
            _with2.Font = drawFont;
            _with2.TextAlign = TextAlignment;
            _with2.UseSystemPasswordChar = UseSystemPasswordChar;

            G.Clear(BackColor);

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.CompositingQuality = CompositingQuality.HighQuality;

            G.FillRectangle(new SolidBrush(Color.White), ClientRectangle);
            G.DrawPath(new Pen(Color.FromArgb(255, 207, 188)), Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), 1));
            G.DrawPath(new Pen(Color.FromArgb(255, 207, 188)), Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), 2));
            G.DrawPath(new Pen(Color.FromArgb(205, 87, 40)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));
            G.DrawPath(new Pen(Color.FromArgb(205, 87, 40)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 3));


            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

}


