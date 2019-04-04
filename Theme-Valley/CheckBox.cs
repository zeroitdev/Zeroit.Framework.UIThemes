// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
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
    public class ValleyCheckBox : Control
    {
        #region Variables
        private MouseState State = MouseState.None;
        private bool _Checked;
        #endregion

        #region  Properties
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        public bool Checked
        {
            get
            {
                return _Checked;
            }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }

        public delegate void CheckedChangedEventHandler(object sender);
        public event CheckedChangedEventHandler CheckedChanged;
        protected override void OnClick(System.EventArgs e)
        {
            _Checked = !_Checked;
            if (CheckedChanged != null)
                CheckedChanged(this);
            base.OnClick(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 16;
        }

        #endregion

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

        protected override void OnPaint(PaintEventArgs e)
        {
            var G = e.Graphics;
            G.Clear(BackColor);

            G.DrawRectangle(new Pen(Color.FromArgb(192, 192, 192)), new Rectangle(0, 0, 15, 15));

            switch (State)
            {
                case MouseState.Over:
                    G.DrawRectangle(new Pen(Color.FromArgb(160, 160, 160)), new Rectangle(0, 0, 15, 15));
                    break;
            }

            if (Checked)
            {
                G.DrawString("�", new Font("Wingdings", 9), new SolidBrush(Color.FromArgb(56, 56, 56)), new Point(0, 2));
            }

            G.FillRectangle(new SolidBrush(BackColor), new Rectangle(0, 0, 1, 1));
            G.FillRectangle(new SolidBrush(BackColor), new Rectangle(15, 15, 1, 1));
            G.FillRectangle(new SolidBrush(BackColor), new Rectangle(0, 15, 1, 1));
            G.FillRectangle(new SolidBrush(BackColor), new Rectangle(15, 0, 1, 1));

            G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(131, 131, 131)), new Point(18, -3));

            base.OnPaint(e);


        }
    }
}


