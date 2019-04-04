// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Close.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Knight
{
    public class KnightClose : Control
    {

        #region " Declarations "
        #endregion
        private MouseState _State;

        #region " MouseStates "
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _State = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _State = MouseState.None;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _State = MouseState.Down;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _State = MouseState.Over;
            Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Environment.Exit(0);
        }
        #endregion

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Size = new Size(12, 12);
        }

        public KnightClose()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            Size = new Size(12, 12);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;

            G.Clear(Color.FromArgb(236, 73, 99));

            StringFormat _StringF = new StringFormat();
            _StringF.Alignment = StringAlignment.Center;
            _StringF.LineAlignment = StringAlignment.Center;

            G.DrawString("r", new Font("Marlett", 11), Brushes.White, new RectangleF(0, 0, Width, Height), _StringF);

            switch (_State)
            {
                case MouseState.Over:
                    G.DrawString("r", new Font("Marlett", 11), new SolidBrush(Color.FromArgb(25, Color.White)), new RectangleF(0, 0, Width, Height), _StringF);

                    break;
                case MouseState.Down:
                    G.DrawString("r", new Font("Marlett", 11), new SolidBrush(Color.FromArgb(40, Color.Black)), new RectangleF(0, 0, Width, Height), _StringF);

                    break;
            }

        }

    }

}


