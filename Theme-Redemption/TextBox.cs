﻿// ***********************************************************************
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Redemption
{
    public class RedemptionTextBox : Control
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
            #region " Control Help - Properties & Flicker Control "
        }
        private bool _UsePassword = false;
        public new bool UseSystemPasswordChar
        {
            get { return _UsePassword; }
            set
            {
                txtbox.UseSystemPasswordChar = UseSystemPasswordChar;
                _UsePassword = value;
                Invalidate();
            }
        }
        private int _MaxCharacters = 32767;
        public new int MaxLength
        {
            get { return _MaxCharacters; }
            set
            {
                _MaxCharacters = value;
                txtbox.MaxLength = MaxLength;
                Invalidate();
            }
        }
        private HorizontalAlignment _TextAlignment;
        public new HorizontalAlignment TextAlign
        {
            get { return _TextAlignment; }
            set
            {
                _TextAlignment = value;
                Invalidate();
            }
        }
        private bool _MultiLine = false;
        public new bool MultiLine
        {
            get { return _MultiLine; }
            set
            {
                _MultiLine = value;
                txtbox.Multiline = value;
                OnResize(EventArgs.Empty);
                Invalidate();
            }
        }


        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        protected override void OnBackColorChanged(System.EventArgs e)
        {
            base.OnBackColorChanged(e);
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
        private void TextChngTxtBox(object sender, EventArgs e)
        {
            Text = txtbox.Text;
        }
        private void TextChng(object sender, EventArgs e)
        {
            txtbox.Text = Text;
        }
        public void NewTextBox()
        {
            var _with1 = txtbox;
            _with1.Multiline = false;
            _with1.BackColor = Color.FromArgb(49, 50, 54);
            _with1.ForeColor = ForeColor;
            _with1.Text = string.Empty;
            _with1.TextAlign = HorizontalAlignment.Center;
            _with1.BorderStyle = BorderStyle.None;
            _with1.Location = new Point(5, 4);
            _with1.Font = new Font("Arial", 8.25f, FontStyle.Bold);
            _with1.Size = new Size(Width - 10, Height - 11);
            _with1.UseSystemPasswordChar = UseSystemPasswordChar;

        }
        #endregion

        public RedemptionTextBox() : base()
        {
            TextChanged += TextChng;

            NewTextBox();
            Controls.Add(txtbox);

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            Text = "";
            BackColor = Color.Transparent;
            ForeColor = Color.White;
            Font = new Font("Arial", 8.25f, FontStyle.Bold);
            Size = new Size(135, 24);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            int Curve = 4;
            G.SmoothingMode = SmoothingMode.HighQuality;

            var _with2 = txtbox;
            _with2.TextAlign = TextAlign;
            _with2.UseSystemPasswordChar = UseSystemPasswordChar;

            G.Clear(Color.Transparent);
            G.FillPath(new SolidBrush(Color.FromArgb(49, 50, 54)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), Curve));
            Color[] GradientPen = {
            Color.FromArgb(43, 44, 48),
            Color.FromArgb(44, 45, 49),
            Color.FromArgb(45, 46, 50),
            Color.FromArgb(46, 47, 51),
            Color.FromArgb(47, 48, 52),
            Color.FromArgb(48, 49, 53)
        };
            for (int i = 0; i <= 5; i++)
            {
                G.DrawPath(new Pen(GradientPen[i]), Draw.RoundRect(new Rectangle(i + 1, i + 1, Width - ((2 * i) + 3), Height - ((2 * i) + 3)), Curve));
            }
            LinearGradientBrush BorderPen = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.Transparent, Color.FromArgb(87, 88, 92), 90);
            G.DrawPath(new Pen(BorderPen), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), Curve));
            G.DrawPath(new Pen(Color.FromArgb(32, 33, 37)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), Curve));

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (!MultiLine)
            {
                int TextBoxHeight = txtbox.Height;
                txtbox.Location = new Point(10, (Height / 2) - (TextBoxHeight / 2) - 1);
                txtbox.Size = new Size(Width - 20, TextBoxHeight);
            }
            else
            {
                int TextBoxHeight = txtbox.Height;
                txtbox.Location = new Point(10, 10);
                txtbox.Size = new Size(Width - 20, Height - 20);
            }
        }
    }


}
