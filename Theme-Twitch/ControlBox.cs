// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ControlBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Twitch
{
    public class TwitchControlBox : Control
    {

        public TwitchControlBox() : base()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            ForeColor = Color.White;
            BackColor = Color.Transparent;
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Size = new Size(60, 25);
        }
        public enum ButtonHover
        {
            Minimize,
            Maximize,
            Close,
            None
        }
        ButtonHover ButtonState = ButtonHover.None;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            int X = e.Location.X;
            int Y = e.Location.Y;
            if (Y > 0 && Y < (Height - 2))
            {
                if (X > 0 && X < 30)
                {
                    ButtonState = ButtonHover.Minimize;
                }
                else if (X > 31 && X < Width)
                {
                    ButtonState = ButtonHover.Close;
                }
                else
                {
                    ButtonState = ButtonHover.None;
                }
            }
            else
            {
                ButtonState = ButtonHover.None;
            }
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            base.OnPaint(e);

            G.Clear(BackColor);
            Font ButtonFont = new Font("Marlett", 10f);
            G.DrawString("r", ButtonFont, new SolidBrush(Color.FromArgb(200, 200, 200)), new Point(Width - 16, 7), new StringFormat { Alignment = StringAlignment.Center });
            G.DrawString("0", ButtonFont, new SolidBrush(Color.FromArgb(200, 200, 200)), new Point(20, 7), new StringFormat { Alignment = StringAlignment.Center });

            switch (ButtonState)
            {
                case ButtonHover.Minimize:
                    G.DrawString("0", ButtonFont, new SolidBrush(Color.White), new Point(20, 7), new StringFormat { Alignment = StringAlignment.Center });
                    break;
                case ButtonHover.Close:
                    G.DrawString("r", ButtonFont, new SolidBrush(Color.White), new Point(Width - 16, 7), new StringFormat { Alignment = StringAlignment.Center });
                    break;
            }



            e.Graphics.DrawImage(B, new Point(0, 0));
            G.Dispose();
            B.Dispose();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            switch (ButtonState)
            {
                case ButtonHover.Close:
                    Parent.FindForm().Close();
                    break;
                case ButtonHover.Minimize:
                    Parent.FindForm().WindowState = FormWindowState.Minimized;
                    break;
                case ButtonHover.Maximize:
                    Parent.FindForm().WindowState = FormWindowState.Maximized;
                    break;
            }
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            ButtonState = ButtonHover.None;
            Invalidate();
        }
    }


}

