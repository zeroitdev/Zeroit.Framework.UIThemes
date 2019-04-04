// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Max.cs" company="Zeroit Dev Technologies">
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
    public class ValleyMax : Control
    {
        #region  Variables
        private MouseState State = MouseState.None;
        #endregion

        #region  Properties

        #region  Mouse States

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if (FindForm().WindowState == FormWindowState.Maximized)
            {
                FindForm().WindowState = FormWindowState.Normal;
            }

            else if (FindForm().WindowState == FormWindowState.Normal)
            {
                FindForm().WindowState = FormWindowState.Maximized;
            }
        }

        #endregion

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Size = new Size(16, 16);
        }
        #endregion

        public ValleyMax()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, true);
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            var G = e.Graphics;
            G.Clear(Color.FromArgb(49, 49, 49));
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.FillEllipse(new SolidBrush(Color.FromArgb(39, 39, 39)), new Rectangle(0, 0, 15, 15));
            G.FillEllipse(new SolidBrush(Color.FromArgb(254, 190, 4)), new Rectangle(2, 2, 11, 11));

            switch (State)
            {
                case MouseState.Over:
                    G.FillEllipse(new SolidBrush(Color.FromArgb(40, Color.White)), new Rectangle(2, 2, 11, 11));
                    break;
                case MouseState.Down:
                    G.FillEllipse(new SolidBrush(Color.FromArgb(40, Color.Black)), new Rectangle(2, 2, 11, 11));

                    break;
            }
            base.OnPaint(e);


        }
    }
}


