// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ButtonWhite.cs" company="Zeroit Dev Technologies">
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
    public class Kaspersky2014WhiteButton : Button
    {

        public void DrawRoundRect(Graphics g, Pen p, float X, float Y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(X + radius, Y, X + width - (radius * 2), Y);
            gp.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
            gp.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
            gp.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            gp.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
            gp.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            gp.AddLine(X, Y + height - (radius * 2), X, Y + radius);
            gp.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
            g.DrawPath(p, gp);
            gp.Dispose();
        }

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

            LinearGradientBrush bg = new LinearGradientBrush(this.ClientRectangle, Color.White, Color.FromArgb(220, 220, 220), LinearGradientMode.Vertical);
            g.FillRectangle(bg, this.ClientRectangle);

            switch (state)
            {
                case MouseState.Over:
                    g.FillRectangle(new SolidBrush(Color.FromArgb(10, Color.Black)), this.ClientRectangle);
                    break; // TODO: might not be correct. Was : Exit Select


                    break;
                case MouseState.Down:
                    g.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.Black)), this.ClientRectangle);
                    break; // TODO: might not be correct. Was : Exit Select

                    break;
            }

            DrawRoundRect(g, Pens.Gray, 0, 0, this.Width - 1, this.Height - 1, 3);

            TextRenderer.DrawText(g, this.Text, this.Font, this.ClientRectangle, this.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }

    }
}