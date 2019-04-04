// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Mini.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.GreyWash
{
    public class GreywashMini : Control
    {
        #region  Declarations 
        private MouseState State = MouseState.None;
        #endregion

        #region  MouseStates

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
            switch (FindForm().WindowState)
            {
                case FormWindowState.Normal:
                    FindForm().WindowState = FormWindowState.Minimized;
                    break;
                case FormWindowState.Maximized:
                    FindForm().WindowState = FormWindowState.Minimized;
                    break;
            }
        }

        #endregion

        #region  Properties 

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Size = new Size(16, 16);
        }

        #endregion

        public GreywashMini()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, true);
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var G = e.Graphics;
            G.Clear(Color.LightGray);
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.FillEllipse(new SolidBrush(Color.DarkGray), new Rectangle(2, 2, 11, 11));

            switch (State)
            {
                case MouseState.Over:
                    G.FillEllipse(new SolidBrush(Color.FromArgb(80, Color.White)), new Rectangle(2, 2, 11, 11));
                    break;
                case MouseState.Down:
                    G.FillEllipse(new SolidBrush(Color.FromArgb(80, Color.Black)), new Rectangle(2, 2, 11, 11));
                    break;
            }

            base.OnPaint(e);
            G.Dispose();
        }
    }

}
