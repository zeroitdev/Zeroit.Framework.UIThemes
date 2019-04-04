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
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Element
{

    public class ElementCheckBox : Control
    {

        #region " Variables "

        private MouseState _State;

        private bool _Checked;
        #endregion

        #region " Properties "
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }
                Invalidate();
            }
        }

        private Color _CheckedColor = Color.FromArgb(231, 75, 60);
        public Color CheckedColor
        {
            get { return _CheckedColor; }
            set { _CheckedColor = value; }
        }
        #endregion

        #region " Events "
        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);
        protected override void OnClick(EventArgs e)
        {
            if (!_Checked)
                Checked = true;
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
            G.TextRenderingHint = TextRenderingHint.AntiAlias;
            G.Clear(Parent.BackColor);
            G.FillRectangle(Brushes.White, new Rectangle(0, 0, 15, 15));
            if (Checked == true)
            {
                G.FillRectangle(new SolidBrush(_CheckedColor), new Rectangle(2, 2, 11, 11));
            }
            G.DrawString(Text, new Font("Arial", 9), Brushes.White, new Point(20, 0));
        }
    }


}


