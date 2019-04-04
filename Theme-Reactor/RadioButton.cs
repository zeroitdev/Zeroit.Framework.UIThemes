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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Reactor
{
    [DefaultEvent("CheckedChanged")]
    public class ReactorRadioButton : Control
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
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
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
                if (!object.ReferenceEquals(C, this) && C is ReactorRadioButton)
                {
                    ((ReactorRadioButton)C).Checked = false;
                }
            }
        }
        #endregion

        public ReactorRadioButton()
            : base()
        {
            BackColor = Color.FromArgb(38, 38, 38);
            ForeColor = Color.White;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;

            Height = 16;
            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.HighQuality;
            R1 = new Rectangle(2, 0, 13, 13);
            if (_Checked)
            {
                G1 = new LinearGradientBrush(R1, Color.FromArgb(220, 209, 68, 0), Color.FromArgb(220, 210, 75, 0), 90);
            }
            else
            {
                G1 = new LinearGradientBrush(R1, Color.FromArgb(24, 24, 24), Color.FromArgb(30, 30, 30), 90);
            }
            G.FillEllipse(G1, R1);
            if (State == MouseState.Over)
            {
                R1 = new Rectangle(2, 0, 13, 13);
                G.FillEllipse(new SolidBrush(Color.FromArgb(5, Color.White)), R1);
            }
            if (_Checked)
            {
                R1 = new Rectangle(4, 1, 9, 6);
                G1 = new LinearGradientBrush(R1, Color.FromArgb(80, 255, 255, 255), Color.FromArgb(30, 255, 255, 255), 90);
                G.FillEllipse(G1, R1);
                G.DrawEllipse(new Pen(new SolidBrush(Color.FromArgb(225, 110, 30))), 3, 1, 11, 11);
            }
            G.DrawString(Text, Font, new SolidBrush(ForeColor), 18, 1);
            G.DrawEllipse(Pens.Black, 2, 0, 13, 13);
            G.DrawEllipse(new Pen(Color.FromArgb(15, Color.White)), 1, -1, 15, 15);
        }

    }

}


