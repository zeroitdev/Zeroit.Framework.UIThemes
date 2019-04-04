// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Seperator.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Excision
{

    public class ExcisionSeparator : Control
    {
        #region " MouseStates "
        MouseState State = MouseState.None;
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        #endregion
        private bool _Horizontal = true;
        public bool Horizontal
        {
            get { return _Horizontal; }
            set
            {
                _Horizontal = value;
                Invalidate();
            }
        }
        public ExcisionSeparator()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.FixedHeight, true);
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(205, 205, 205);
            Height = 4;
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);


            base.OnPaint(e);

            G.Clear(BackColor);

            //G.CompositingQuality = CompositingQuality.HighQuality
            G.SmoothingMode = SmoothingMode.HighQuality;
            switch (_Horizontal)
            {
                case true:
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(26, 24, 25))), 0, 0, Width - 1, 0);
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(75, 73, 74))), 0, 1, Width - 1, 1);
                    break;
                case false:
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(26, 24, 25))), 0, 0, 0, Height - 1);
                    G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(75, 73, 74))), 1, 0, 1, Height - 1);
                    break;
            }


            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

}