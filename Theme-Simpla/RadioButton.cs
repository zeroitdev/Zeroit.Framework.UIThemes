// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="RadioButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Simpla
{

    [DefaultEvent("CheckedChanged")]
    public class SimplaRadioButton : Control
    {

        #region " Control Help - MouseState & Flicker Control"
        private Rectangle R1;

        private LinearGradientBrush G1;
        private MouseState State = MouseState.None;
        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            Height = 16;
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                InvalidateControls();
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }
                Invalidate();
            }
        }
        protected override void OnClick(EventArgs e)
        {
            if (!_Checked)
                Checked = true;
            base.OnClick(e);
        }
        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            InvalidateControls();
        }
        private void InvalidateControls()
        {
            if (!IsHandleCreated || !_Checked)
                return;

            foreach (Control C in Parent.Controls)
            {
                if (!object.ReferenceEquals(C, this) && C is SimplaRadioButton)
                {
                    ((SimplaRadioButton)C).Checked = false;
                }
            }
        }
        #endregion

        public enum ColorSchemes
        {
            Green,
            Blue,
            White,
            Red
        }
        private ColorSchemes _ColorScheme;
        public ColorSchemes ColorScheme
        {
            get { return _ColorScheme; }
            set
            {
                _ColorScheme = value;
                Invalidate();
            }
        }

        public SimplaRadioButton() : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = Color.Black;
            Size = new Size(150, 16);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle radioBtnRectangle = new Rectangle(0, 0, Height - 1, Height - 1);
            Rectangle InnerRect = new Rectangle(3, 3, Height - 7, Height - 7);

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.CompositingQuality = CompositingQuality.HighQuality;
            G.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            G.Clear(BackColor);

            LinearGradientBrush bgGrad = new LinearGradientBrush(radioBtnRectangle, Color.FromArgb(40, 40, 40), Color.FromArgb(30, 30, 30), 90);
            G.FillEllipse(bgGrad, radioBtnRectangle);
            G.DrawEllipse(new Pen(Color.FromArgb(56, 56, 56)), radioBtnRectangle);

            if (Checked)
            {
                switch (ColorScheme)
                {
                    case ColorSchemes.Green:
                        LinearGradientBrush fillGradient = new LinearGradientBrush(InnerRect, Color.FromArgb(121, 185, 0), Color.FromArgb(94, 165, 1), 90);
                        G.FillEllipse(fillGradient, InnerRect);
                        G.DrawEllipse(new Pen(Color.FromArgb(159, 207, 1)), InnerRect);
                        break;
                    case ColorSchemes.Blue:
                        LinearGradientBrush fillGradient1 = new LinearGradientBrush(InnerRect, Color.FromArgb(0, 124, 186), Color.FromArgb(0, 97, 166), 90);
                        G.FillEllipse(fillGradient1, InnerRect);
                        G.DrawEllipse(new Pen(Color.FromArgb(0, 161, 207)), InnerRect);
                        break;
                    case ColorSchemes.White:
                        LinearGradientBrush fillGradient2 = new LinearGradientBrush(InnerRect, Color.FromArgb(245, 245, 245), Color.FromArgb(246, 246, 246), 90);
                        G.FillEllipse(fillGradient2, InnerRect);
                        G.DrawEllipse(new Pen(Color.FromArgb(254, 254, 254)), InnerRect);
                        break;
                    case ColorSchemes.Red:
                        LinearGradientBrush fillGradient3 = new LinearGradientBrush(InnerRect, Color.FromArgb(185, 0, 0), Color.FromArgb(170, 0, 0), 90);
                        G.FillEllipse(fillGradient3, InnerRect);
                        G.DrawEllipse(new Pen(Color.FromArgb(209, 1, 1)), InnerRect);
                        break;
                }
            }

            Font drawFont = new Font("Tahoma", 10, FontStyle.Bold);
            Brush nb = new SolidBrush(Color.FromArgb(200, 200, 200));
            G.DrawString(Text, drawFont, nb, new Point(19, 8), new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            });

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }

    }

}

