// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
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
using System.Windows.Forms;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Knight
{
    [DefaultEvent("CheckedChanged")]
    public class KnightRadioButton : Control
    {

        #region " Variables"
        #endregion
        private bool _Checked;

        #region " Properties"
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
        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);
        protected override void OnClick(EventArgs e)
        {
            if (!_Checked)
                Checked = true;
            base.OnClick(e);
        }
        private void InvalidateControls()
        {
            if (!IsHandleCreated || !_Checked)
                return;
            foreach (Control C in Parent.Controls)
            {
                if (!object.ReferenceEquals(C, this) && C is KnightRadioButton)
                {
                    ((KnightRadioButton)C).Checked = false;
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

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;
            G.SmoothingMode = (SmoothingMode)2;
            G.TextRenderingHint = (TextRenderingHint)5;
            G.Clear(Parent.BackColor);
            if (Parent.BackColor == Color.FromArgb(46, 49, 61))
            {
                G.FillEllipse(new SolidBrush(Color.FromArgb(37, 39, 48)), new Rectangle(0, 0, 15, 15));
            }
            else
            {
                G.FillEllipse(new SolidBrush(Color.FromArgb(24, 25, 31)), new Rectangle(0, 0, 15, 15));
            }
            if (Checked)
            {
                G.FillEllipse(new SolidBrush(Color.FromArgb(236, 73, 99)), new Rectangle(4, 4, 7, 7));
            }
            G.DrawString(Text, new Font("Segoe UI", 10), Brushes.White, new Point(18, -2));
        }

    }

}


