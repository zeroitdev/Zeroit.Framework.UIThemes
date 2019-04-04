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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Loyal
{

    [DefaultEvent("CheckedChanged")]
    public class LoyalRadioButton : Control
    {

        #region " Back End "

        #region " Declarations "
        private MouseState _State = MouseState.None;
        #endregion
        private bool _Checked;

        #region " Properties "
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
                if (!object.ReferenceEquals(C, this) && C is LoyalRadioButton)
                {
                    ((LoyalRadioButton)C).Checked = false;
                    Invalidate();
                }
            }
        }
        
        private Color _CheckedColor = Color.FromArgb(102, 51, 153);
        [Category("Colors Settings")]
        public Color CheckedColor
        {
            get { return _CheckedColor; }
            set
            {
                _CheckedColor = value;
                Invalidate();
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

        #endregion

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;
            G.SmoothingMode = SmoothingMode.AntiAlias;
            G.Clear(Parent.BackColor);
            if (Parent.BackColor == Color.FromArgb(40, 40, 40))
            {
                G.FillEllipse(new SolidBrush(Color.FromArgb(35, 35, 35)), new Rectangle(0, 0, 13, 13));
            }
            else
            {
                G.FillEllipse(new SolidBrush(Color.FromArgb(40, 40, 40)), new Rectangle(0, 0, 13, 13));
            }
            G.DrawEllipse(new Pen(Color.FromArgb(18, 18, 18)), new Rectangle(0, 0, 13, 13));

            if (Checked)
            {
                G.FillEllipse(new SolidBrush(_CheckedColor), new Rectangle(3, 3, 7, 7));
            }
            G.DrawString(Text, new Font("Arial", 9), Brushes.White, new Point(18, 0));
        }
    }

}


