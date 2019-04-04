// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Gray
{
    public class GrayButton : Control
    {

        public enum State
        {
            None,
            Over,
            Down
        }


        private State MouseState;
        public GrayButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);

            MouseState = State.None;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;

            G.Clear(Parent.BackColor);

            LinearGradientBrush BackgroundGradient = new LinearGradientBrush(new Point(0, 0), new Point(0, Height), Color.Transparent, Color.Transparent);

            switch (MouseState)
            {
                case State.None:
                    BackgroundGradient.LinearColors = new Color[] {
                    Color.FromArgb(127, 127, 127),
                    Color.FromArgb(93, 93, 93)
                };
                    break;
                case State.Over:
                    BackgroundGradient.LinearColors = new Color[] {
                    Color.FromArgb(75, 130, 195),
                    Color.FromArgb(40, 80, 135)
                };
                    break;
                case State.Down:
                    BackgroundGradient.LinearColors = new Color[] {
                    Color.FromArgb(55, 110, 175),
                    Color.FromArgb(40, 80, 135)
                };
                    break;
            }

            G.FillPath(BackgroundGradient, DesignFunctions.RoundRect(0, 0, Width - 1, Height - 1, 3));
            G.DrawLine(DesignFunctions.ToPen(100, Color.White), new Point(2, 1), new Point(Width - 3, 1));
            G.DrawPath(Pens.Gray, DesignFunctions.RoundRect(0, 0, Width - 1, Height - 1, 3));
            G.DrawPath(Pens.Black, DesignFunctions.RoundRect(0, 0, Width - 1, Height - 2, 3));

            BackgroundGradient.Dispose();

            G.DrawString(Text, new Font(Font.Name, Font.Size, FontStyle.Bold), Brushes.Black, new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            });
            G.DrawString(Text, new Font(Font.Name, Font.Size, FontStyle.Bold), Brushes.White, new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            });
        }

        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            MouseState = State.Over;
            Invalidate();
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            MouseState = State.None;
            Invalidate();
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            MouseState = State.Down;
            Invalidate();
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            MouseState = State.Over;
            Invalidate();
        }
    }


}


