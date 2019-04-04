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

namespace Zeroit.Framework.UIThemes.Hex
{
    [DefaultEvent("CheckedChanged")]
    public class HexCheckBox : Control
    {

        #region " Variables "
        private MouseState _State = MouseState.None;
        #endregion
        private bool _Checked;

        #region " Properties "
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
            _Checked = !_Checked;
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

        #region " Mouse States "

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _State = MouseState.None;
            Invalidate();
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;
            G.Clear(Color.FromArgb(30, 33, 40));

            G.FillRectangle(new SolidBrush(Color.FromArgb(47, 51, 60)), new Rectangle(0, 0, 15, 15));
            if (Checked)
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(236, 95, 75)), new Rectangle(4, 4, 7, 7));
            }
            G.DrawString(Text, new Font("Segoe UI", 9), Brushes.White, new Point(18, -1));
        }
    }

}


