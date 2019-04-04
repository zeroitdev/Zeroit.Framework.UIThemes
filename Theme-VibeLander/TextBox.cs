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
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.VibeLander
{

    public class VibeTxtBox : ThemeControl
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

        public VibeTxtBox() : base()
        {
            TextChanged += TextChng;

            Controls.Add(txtbox);
            var _with1 = txtbox;
            _with1.Multiline = false;
            _with1.BackColor = Color.FromArgb(0, 0, 0);
            _with1.ForeColor = ForeColor;
            _with1.Text = string.Empty;
            _with1.TextAlign = HorizontalAlignment.Center;
            _with1.BorderStyle = BorderStyle.None;
            _with1.Location = new Point(5, 8);
            _with1.Font = new Font("Arial", 8.25f, FontStyle.Bold);
            _with1.Size = new Size(Width - 8, Height - 11);
            _with1.UseSystemPasswordChar = UseSystemPasswordChar;

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
            Height = txtbox.Height + 16;
            Font drawFont = new Font("Tahoma", 9, FontStyle.Regular);
            var _with2 = txtbox;
            _with2.Width = Width - 12;
            _with2.ForeColor = Color.FromArgb(72, 72, 72);
            _with2.Font = drawFont;
            _with2.TextAlign = TextAlignment;
            _with2.UseSystemPasswordChar = UseSystemPasswordChar;
            DrawCorners(Parent.BackColor, ClientRectangle);
        }
    }

}

