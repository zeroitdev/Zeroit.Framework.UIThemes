// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Knight
{

    [DefaultEvent("CheckedChanged")]
    public class KnightCheckBox : Control
    {

        #region "Variables"
        #endregion
        private bool _Checked;

        #region " Properties"
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);
        protected override void OnClick(System.EventArgs e)
        {
            if (!_Checked)
            {
                Checked = true;
            }
            else
            {
                Checked = false;
            }
            if (CheckedChanged != null)
            {
                CheckedChanged(this);
            }
            base.OnClick(e);
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
            dynamic G = e.Graphics;
            G.Clear(BackColor);

            if (Parent.BackColor == Color.FromArgb(46, 49, 61))
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(37, 39, 48)), new Rectangle(0, 0, 15, 15));
            }
            else
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(24, 25, 31)), new Rectangle(0, 0, 15, 15));
            }
            if (Checked)
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(236, 73, 99)), new Rectangle(4, 4, 7, 7));
            }

            G.DrawString(Text, new Font("Segoe UI", 10), Brushes.White, new Point(18, -2));

        }
    }

}


