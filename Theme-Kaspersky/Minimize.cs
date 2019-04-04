// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Minimize.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Kaspersky
{

    public class Kaspersky2014MinimizeButton : Button
    {

        // x-coordinate of upper-left corner
        // y-coordinate of upper-left corner
        // x-coordinate of lower-right corner
        // y-coordinate of lower-right corner
        // height of ellipse
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        // width of ellipse

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

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            ((System.Windows.Forms.Form)this.Parent).WindowState = FormWindowState.Minimized;
        }


        private Font font = new Font("Marlett", 11f);
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Region = Region.FromHrgn(CreateRoundRectRgn(1, -5, this.Width + 5, this.Height - 1, 12, 12));
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            g.FillRectangle(new SolidBrush(Color.FromArgb(56, 143, 133)), this.ClientRectangle);
            g.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)), new Rectangle(0, 0, this.Width, this.Height / 2));

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

            TextRenderer.DrawText(g, "0", font, this.ClientRectangle, Color.WhiteSmoke, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

            DrawRoundRect(g, new Pen(Color.Teal), 1, -5, this.Width + 5, this.Height + 2, 8);
        }

    }

}