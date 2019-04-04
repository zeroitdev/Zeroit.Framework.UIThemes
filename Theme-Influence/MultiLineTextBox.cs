// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="MultiLineTextBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Influence
{
    public class InfluenceMultiLineTextBox : Control
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
        private int _maxchars = 32767;
        public int MaxCharacters
        {
            get { return _maxchars; }
            set
            {
                _maxchars = value;
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
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        protected override void OnBackColorChanged(System.EventArgs e)
        {
            base.OnBackColorChanged(e);
            txtbox.BackColor = Color.FromArgb(43, 43, 43);
            Invalidate();
        }
        protected override void OnForeColorChanged(System.EventArgs e)
        {
            base.OnForeColorChanged(e);
            txtbox.ForeColor = ForeColor;
            Invalidate();
        }
        protected override void OnSizeChanged(System.EventArgs e)
        {
            base.OnSizeChanged(e);
            txtbox.Size = new Size(Width - 10, Height - 11);
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
            _with1.Multiline = true;
            _with1.BackColor = BackColor;
            _with1.ForeColor = ForeColor;
            _with1.Text = string.Empty;
            _with1.TextAlign = HorizontalAlignment.Center;
            _with1.BorderStyle = BorderStyle.None;
            _with1.Location = new Point(3, 4);
            _with1.Font = new Font("Verdana", 8.25f);
            _with1.Size = new Size(Width - 10, Height - 10);
            txtbox.Font = new Font("Verdana", 8.25f);
        }
        #endregion

        public InfluenceMultiLineTextBox()
            : base()
        {
            TextChanged += TextChng;

            NewTextBox();
            Controls.Add(txtbox);

            Text = string.Empty;
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = Color.White;
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

            txtbox.TextAlign = TextAlignment;

            G.Clear(BackColor);

            LinearGradientBrush g1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height / 2), Color.FromArgb(40, 40, 40), Color.FromArgb(45, 45, 45), 90);
            G.FillPath(g1, d.RoundRect(new Rectangle(0, 0, Width - 1, Height / 2), 2));
            LinearGradientBrush g2 = new LinearGradientBrush(new Rectangle(0, Height / 2, Width - 1, Height / 2), Color.FromArgb(45, 45, 45), Color.FromArgb(40, 40, 40), 90);
            G.FillPath(g2, d.RoundRect(new Rectangle(0, Height / 2 - 3, Width - 1, Height / 2 + 2), 2));

            G.DrawPath(new Pen(Color.FromArgb(150, 97, 94, 90)), d.RoundRect(new Rectangle(0, 1, Width - 1, Height - 3), 2));
            G.DrawPath(new Pen(Color.FromArgb(10, 10, 10)), d.RoundRect(ClientRectangle, 2));

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

}

