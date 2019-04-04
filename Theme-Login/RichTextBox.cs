// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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

using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Login
{

    public class LogInRichTextBox : Control
    {

        #region "Declarations"
        private RichTextBox TB = new RichTextBox();
        private Color _BaseColour = Color.FromArgb(42, 42, 42);
        private Color _TextColour = Color.FromArgb(255, 255, 255);
        #endregion
        private Color _BorderColour = Color.FromArgb(35, 35, 35);

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

        public void AppendText(string AppendingText)
        {
            TB.Focus();
            TB.AppendText(AppendingText);
            Invalidate();
        }

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
            TB.BackColor = BackColor;
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

        #endregion

        #region "Draw Control"

        public LogInRichTextBox()
        {
            TextChanged += TextChanges;
            var _with20 = TB;
            _with20.Multiline = true;
            _with20.BackColor = _BaseColour;
            _with20.ForeColor = _TextColour;
            _with20.Text = string.Empty;
            _with20.BorderStyle = BorderStyle.None;
            _with20.Location = new Point(5, 5);
            _with20.Font = new Font("Segeo UI", 9);
            _with20.Size = new Size(Width - 10, Height - 10);
            Controls.Add(TB);
            Size = new Size(135, 35);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle Base = new Rectangle(0, 0, Width - 1, Height - 1);
            var _with21 = g;
            _with21.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with21.SmoothingMode = SmoothingMode.HighQuality;
            _with21.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with21.Clear(_BaseColour);
            _with21.DrawRectangle(new Pen(_BorderColour, 2), ClientRectangle);
            _with21.InterpolationMode = (InterpolationMode)7;
        }

        #endregion

    }

}


