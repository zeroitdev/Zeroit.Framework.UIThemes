// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="RadioButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Valley
{
    [DefaultEvent("CheckedChanged")]
    public class ValleyRadioButton : Control
    {
        #region  Variables

        private MouseState State = MouseState.None;
        private bool _Checked;

        #endregion

        #region  Properties
        public bool Checked
        {
            get
            {
                return _Checked;
            }
            set
            {
                _Checked = value;
                InvalidateControls();
                if (CheckedChanged != null)
                    CheckedChanged(this);
                Invalidate();
            }
        }
        public delegate void CheckedChangedEventHandler(object sender);
        public event CheckedChangedEventHandler CheckedChanged;
        protected override void OnClick(EventArgs e)
        {
            if (!_Checked)
            {
                Checked = true;
            }
            base.OnClick(e);
        }
        private void InvalidateControls()
        {
            if (!IsHandleCreated || !_Checked)
            {
                return;
            }
            foreach (Control C in Parent.Controls)
            {
                if (C != this && C is ValleyRadioButton)
                {
                    ((ValleyRadioButton)C).Checked = false;
                    Invalidate();
                }
            }
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            InvalidateControls();
        }


        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 16;
        }

        #region  Mouse States

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }

        #endregion
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            var G = e.Graphics;

            G.SmoothingMode = (SmoothingMode)2;
            G.TextRenderingHint = (TextRenderingHint)5;
            G.Clear(BackColor);

            G.DrawEllipse(new Pen(Color.FromArgb(191, 191, 191)), new Rectangle(0, 0, 15, 15));

            switch (State)
            {
                case MouseState.Over:
                    G.DrawEllipse(new Pen(Color.FromArgb(160, 160, 160)), new Rectangle(0, 0, 15, 15));
                    break;
            }

            if (Checked)
            {
                G.FillEllipse(new SolidBrush(Color.FromArgb(56, 56, 56)), new Rectangle(4, 4, 7, 7));
            }

            G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(131, 131, 131)), new Point(18, -3));
            base.OnPaint(e);


        }

    }
}


