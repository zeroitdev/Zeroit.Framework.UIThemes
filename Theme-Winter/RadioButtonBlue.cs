// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="RadioButtonBlue.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Winter
{

    [DefaultEvent("CheckedChanged")]
    public class WinterRadioButtonBlue : Control
    {

        #region " Declarations "
        private bool _Checked;
        #endregion
        private MouseState _State = MouseState.None;

        #region " Mouse States "

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

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _State = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _State = MouseState.Down;
            Invalidate();
        }

        #endregion

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
                if (!object.ReferenceEquals(C, this) && C is WinterRadioButtonBlue)
                {
                    ((WinterRadioButtonBlue)C).Checked = false;
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

            G.Clear(Color.FromArgb(211, 222, 228));


            G.FillEllipse(new SolidBrush(Color.FromArgb(61, 132, 221)), new Rectangle(0, 0, 15, 15));

            switch (_State)
            {
                case MouseState.Over:
                    G.FillEllipse(new SolidBrush(Color.FromArgb(78, 148, 235)), new Rectangle(0, 0, 15, 15));
                    break;
                case MouseState.Down:
                    G.FillEllipse(new SolidBrush(Color.FromArgb(15, Color.Black)), new Rectangle(0, 0, 15, 15));
                    break;
            }

            if (Checked)
            {
                G.FillEllipse(new SolidBrush(Color.FromArgb(45, 47, 49)), new Rectangle(4, 4, 7, 7));

            }
            G.DrawString(Text, new Font("Segoe UI", 10), new SolidBrush(Color.FromArgb(45, 47, 49)), new Point(18, -2));
        }

    }

}

