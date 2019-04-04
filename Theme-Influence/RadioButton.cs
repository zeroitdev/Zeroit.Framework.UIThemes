// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Influence
{
    [DefaultEvent("CheckedChanged")]
    public class InfluenceRadioButton : Control
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
                if (!object.ReferenceEquals(C, this) && C is InfluenceRadioButton)
                {
                    ((InfluenceRadioButton)C).Checked = false;
                }
            }
        }
        #endregion

        public InfluenceRadioButton()
            : base()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = Color.White;
            Size = new Size(150, 16);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Draw d = new Draw();
            dynamic radioBtnRectangle = new Rectangle(0, 0, Height - 1, Height - 1);

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.Clear(BackColor);

            switch (Checked)
            {
                case false:
                    LinearGradientBrush g1 = new LinearGradientBrush(radioBtnRectangle, Color.FromArgb(10, 10, 10), Color.FromArgb(16, 16, 16), 90);
                    G.FillEllipse(g1, radioBtnRectangle);
                    G.DrawEllipse(new Pen(Color.FromArgb(80, 97, 94, 90)), new Rectangle(1, 1, Height - 3, Height - 3));
                    G.DrawEllipse(Pens.Black, radioBtnRectangle);
                    break;
                case true:
                    LinearGradientBrush g11 = new LinearGradientBrush(radioBtnRectangle, Color.FromArgb(10, 10, 10), Color.FromArgb(16, 16, 16), 90);
                    G.FillEllipse(g11, radioBtnRectangle);
                    HatchBrush h1 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(100, 31, 31, 31), Color.FromArgb(100, 36, 36, 36));
                    G.FillEllipse(h1, radioBtnRectangle);
                    LinearGradientBrush s1 = new LinearGradientBrush(new Rectangle(0, 1, Height - 1, Height / 2 - 1), Color.FromArgb(35, Color.White), Color.FromArgb(0, Color.White), 90);
                    G.FillEllipse(s1, s1.Rectangle);

                    G.FillEllipse(new SolidBrush(Color.FromArgb(15, 15, 15)), new Rectangle(4, 4, Height - 9, Height - 9));
                    G.FillEllipse(new SolidBrush(Color.FromArgb(250, 255, 255, 255)), new Rectangle(5, 5, Height - 11, Height - 11));

                    G.DrawEllipse(new Pen(Color.FromArgb(80, 97, 94, 90)), new Rectangle(1, 1, Height - 3, Height - 3));
                    G.DrawEllipse(Pens.Black, radioBtnRectangle);
                    break;
            }

            G.DrawString(Text, Font, Brushes.White, new Point(16, 0), new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near
            });

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }

    }
}

