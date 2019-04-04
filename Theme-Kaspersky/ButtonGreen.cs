// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ButtonGreen.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Kaspersky
{
    public class Kaspersky2014GreenButton : Button
    {

        private enum MouseState
        {
            None,
            Over,
            Down
        }


        private MouseState state = MouseState.None;
        protected override void OnMouseEnter(EventArgs e)
        {
            state = MouseState.Over;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            state = MouseState.None;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            state = MouseState.Down;
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            state = MouseState.Over;
            base.OnMouseUp(mevent);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.Clear(Color.White);

            LinearGradientBrush bg = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(0, 161, 137), Color.FromArgb(0, 130, 110), LinearGradientMode.Vertical);

            g.FillRectangle(bg, this.ClientRectangle);

            switch (state)
            {
                case MouseState.Over:
                    g.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.White)), this.ClientRectangle);
                    break; // TODO: might not be correct. Was : Exit Select


                    break;
                case MouseState.Down:
                    g.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.Black)), this.ClientRectangle);
                    break; // TODO: might not be correct. Was : Exit Select

                    break;
            }

            g.DrawLine(new Pen(Color.FromArgb(0, 191, 167)), 1, 1, this.Width, 1);

            g.DrawRectangle(new Pen(Color.FromArgb(0, 141, 117)), new Rectangle(0, 0, this.Width - 1, this.Height - 1));

            TextRenderer.DrawText(g, this.Text, this.Font, this.ClientRectangle, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

    }
}