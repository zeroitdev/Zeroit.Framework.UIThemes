// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Redirect.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;
using static Zeroit.Framework.UIThemes.FireFox.Helpers;

namespace Zeroit.Framework.UIThemes.FireFox
{

    public class FirefoxRedirect : Control
    {

        #region " Private "
        private MouseState State;

        private Graphics G;
        private Color FC;
        #endregion
        private Font FF = null;

        #region " Control "

        public FirefoxRedirect()
        {
            DoubleBuffered = true;
            Cursor = Cursors.Hand;
            BackColor = Color.White;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            base.OnPaint(e);

            switch (State)
            {

                case MouseState.Over:
                    FC = Color.FromArgb(23, 140, 229);
                    FF = new Font("Segoe UI", 10f, FontStyle.Underline);

                    break;
                case MouseState.Down:
                    FC = Color.FromArgb(255, 149, 0);
                    FF = new Font("Segoe UI", 10f, FontStyle.Regular);

                    break;
                default:
                    FC = Color.FromArgb(0, 149, 221);
                    FF = new Font("Segoe UI", 10f, FontStyle.Underline);

                    break;
            }

            using (SolidBrush B = new SolidBrush(FC))
            {
                G.DrawString(Text, FF, B, new Point(0, 0));
            }

        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Down;
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
            base.OnMouseEnter(e);
            State = MouseState.None;
            Invalidate();
        }

        #endregion

    }


}


