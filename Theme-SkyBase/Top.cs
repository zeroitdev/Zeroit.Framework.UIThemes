// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Top.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.SkyLimit
{
    public class SkyDarkTop : Control
    {

        public SkyDarkTop()
        {
            DoubleBuffered = true;
            Size = new Size(10, 10);
        }
        Color C1 = Color.FromArgb(94, 103, 106);
        Color C2 = Color.FromArgb(152, 182, 192);
        Color CD = Color.FromArgb(86, 94, 96);
        Color C3 = Color.FromArgb(71, 70, 69);
        Color C4 = Color.FromArgb(58, 56, 54);
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            LinearGradientBrush G1 = new LinearGradientBrush(new Point(0, 0), new Point(0, Height), C3, C4);
            G.FillRectangle(G1, ClientRectangle);
            G1.Dispose();
            G.SmoothingMode = SmoothingMode.HighQuality;
            switch (State)
            {
                case MouseState.None:
                    G.DrawEllipse(new Pen(C1, 2), new Rectangle(2, 2, Width - 5, Height - 5));
                    break;
                case MouseState.Over:
                    G.DrawEllipse(new Pen(C2, 2), new Rectangle(2, 2, Width - 5, Height - 5));
                    break;
                case MouseState.Down:
                    G.DrawEllipse(new Pen(CD, 2), new Rectangle(2, 2, Width - 5, Height - 5));
                    break;
            }

            G.FillEllipse(ConversionFunctions.ToBrush(C2), new Rectangle(5, 5, Width - 11, Height - 11));

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