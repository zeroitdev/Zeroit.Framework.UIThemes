// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="RichTextBox.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Elegant
{

    public class ElegantThemeRichTextBox : Control
    {

        #region "Declarations"
        private RichTextBox TB = new RichTextBox();
        private Color _BaseColour = Color.FromArgb(255, 255, 255);
        private Color _TextColour = Color.FromArgb(163, 163, 163);
        #endregion
        private Color _BorderColour = Color.FromArgb(183, 210, 166);

        #region "Properties"

        [Category("Colours")]
        public Color BaseColour
        {
            get { return _BaseColour; }
            set { _BaseColour = value; }
        }

        [Category("Colours")]
        public Color BorderColour
        {
            get { return _BorderColour; }
            set { _BorderColour = value; }
        }

        [Category("Colours")]
        public Color TextColour
        {
            get { return _TextColour; }
            set { _TextColour = value; }
        }

        #endregion

        #region "Events"

        public override string Text
        {
            get { return TB.Text; }
            set
            {
                TB.Text = value;
                Invalidate();
            }
        }

        protected override void OnBackColorChanged(System.EventArgs e)
        {
            base.OnBackColorChanged(e);
            TB.BackColor = _BaseColour;
            Invalidate();
        }

        protected override void OnForeColorChanged(System.EventArgs e)
        {
            base.OnForeColorChanged(e);
            TB.ForeColor = ForeColor;
            Invalidate();
        }

        protected override void OnSizeChanged(System.EventArgs e)
        {
            base.OnSizeChanged(e);
            TB.Size = new Size(Width - 10, Height - 11);
        }

        protected override void OnFontChanged(System.EventArgs e)
        {
            base.OnFontChanged(e);
            TB.Font = Font;
        }

        public void TextChanges(object sender, EventArgs e)
        {
            TB.Text = Text;
        }

        public void AppendText(string Text)
        {
            TB.Focus();
            TB.AppendText(Text);
            Invalidate();
        }

        #endregion

        #region "Draw Control"

        public ElegantThemeRichTextBox()
        {
            TextChanged += TextChanges;
            var _with14 = TB;
            _with14.Multiline = true;
            _with14.ForeColor = _TextColour;
            _with14.Text = string.Empty;
            _with14.BorderStyle = BorderStyle.None;
            _with14.Location = new Point(5, 5);
            _with14.Font = new Font("Segeo UI", 9);
            _with14.Size = new Size(Width - 10, Height - 10);
            Controls.Add(TB);
            Size = new Size(135, 35);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            G = Graphics.FromImage(B);
            Rectangle Base = new Rectangle(0, 0, Width - 1, Height - 1);
            var _with15 = G;
            _with15.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with15.SmoothingMode = SmoothingMode.HighQuality;
            _with15.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with15.Clear(_BaseColour);
            _with15.DrawRectangle(new Pen(_BorderColour, 1), ClientRectangle);
            base.OnPaint(e);
            G.Dispose();
            e.Graphics.InterpolationMode = (InterpolationMode)7;
            e.Graphics.DrawImageUnscaled(B, 0, 0);
            B.Dispose();
        }

        #endregion

    }


}


