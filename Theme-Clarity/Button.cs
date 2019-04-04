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

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Clarity
{
    public class iClarityButton : Control
    {

        #region "Properties"
        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }
        #endregion

        public iClarityButton()
        {
            DoubleBuffered = true;
        }

        Color C1 = Color.FromArgb(51, 49, 47);
        Color C2 = Color.FromArgb(90, 91, 90);
        Color C3 = Color.FromArgb(0, 0, 0);

        Color C4 = Color.FromArgb(41, 39, 35);

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            LinearGradientBrush G1 = new LinearGradientBrush(new Point(0, 0), new Point(0, Height), C3, C4);
            G.FillRectangle(G1, 0, 0, Width, Height);
            G1.Dispose();

            if (Enabled)
            {
                switch (State)
                {
                    case MouseState.Over:
                        G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)), new Rectangle(0, 0, Width, Height));
                        break;
                    case MouseState.Down:
                        G.FillRectangle(new SolidBrush(Color.FromArgb(10, Color.White)), new Rectangle(0, 0, Width, Height));
                        break;
                }
            }

            StringFormat S1 = new StringFormat();
            S1.LineAlignment = StringAlignment.Center;
            S1.Alignment = StringAlignment.Center;

            switch (Enabled)
            {
                case true:
                    G.DrawString(Text, Font, Brushes.White, new Rectangle(0, 0, Width - 1, Height - 1), S1);

                    break;
                case false:
                    G.DrawString(Text, Font, Brushes.Black, new Rectangle(0, 0, Width - 1, Height - 1), S1);
                    break;
            }

            S1.Dispose();

            G.DrawRectangle(new Pen(C1), 0, 0, Width - 1, Height - 1);
            G.DrawRectangle(new Pen(C2), 1, 1, Width - 3, Height - 3);

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }

        #region "Mouse States"
        public enum MouseState
        {
            None,
            Over,
            Down
        }
        private MouseState ms;
        private MouseState State
        {
            get { return ms; }
            set
            {
                ms = value;
                Invalidate();
            }
        }
        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
        }
        #endregion
    }
}


