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
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Mystic
{
    [DefaultEvent("CheckedChanged")]
    public class MysticRadioButton : Control
    {

        #region " Variables "
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
                if (!object.ReferenceEquals(C, this) && C is MysticRadioButton)
                {
                    ((MysticRadioButton)C).Checked = false;
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

        #region " Mouse States "
        
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _State = MouseState.Down;
            if (!_Checked)
                Checked = true;
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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;
            G.SmoothingMode = (SmoothingMode)2;
            G.TextRenderingHint = (TextRenderingHint)5;
            G.Clear(Color.FromArgb(44, 51, 62));
            G.FillEllipse(new SolidBrush(Color.FromArgb(36, 39, 46)), new Rectangle(0, 0, 15, 15));
            G.DrawEllipse(new Pen(Color.FromArgb(26, 29, 33)), new Rectangle(0, 0, 15, 15));
            if (Checked)
            {
                G.FillEllipse(new LinearGradientBrush(new Point(3, 3), new Point(3, 12), Color.FromArgb(123, 255, 201), Color.FromArgb(41, 131, 113)), new Rectangle(3, 3, 9, 9));
                G.FillEllipse(new LinearGradientBrush(new Point(4, 4), new Point(4, 11), Color.FromArgb(9, 204, 157), Color.FromArgb(41, 131, 113)), new Rectangle(4, 4, 7, 7));
                G.DrawString(Text, new Font("Segoe UI", 9, FontStyle.Bold), Brushes.White, new Point(18, -1));
            }
            else
            {
                switch (_State)
                {
                    case MouseState.None:
                        G.DrawString(Text, new Font("Segoe UI", 9, FontStyle.Bold), new SolidBrush(Color.FromArgb(121, 131, 141)), new Point(18, -1));
                        break;
                    case MouseState.Over:
                        G.DrawEllipse(new Pen(Color.FromArgb(0, 205, 155), 2), new Rectangle(1, 1, 13, 13));
                        G.DrawString(Text, new Font("Segoe UI", 9, FontStyle.Bold), Brushes.White, new Point(18, -1));
                        break;
                    case MouseState.Down:
                        G.DrawString(Text, new Font("Segoe UI", 9, FontStyle.Bold), Brushes.White, new Point(18, -1));
                        break;
                }
            }
        }
    }

}

