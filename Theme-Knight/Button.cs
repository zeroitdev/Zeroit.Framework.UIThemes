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
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Knight
{

    public class KnightButton : Control
    {

        #region " Declarations "
        #endregion
        private MouseState _State = MouseState.None;

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

        #endregion
        
        #region " Properties "
        private bool _Rounded;
        public bool RoundedCorners
        {
            get { return _Rounded; }
            set { _Rounded = value; }
        }
        #endregion

        public KnightButton()
        {
            Size = new Size(90, 30);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;
            G.Clear(Color.FromArgb(236, 73, 99));
            switch (_State)
            {
                case MouseState.Over:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(0, 0, Width, Height));

                    break;
                case MouseState.Down:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(25, Color.Black)), new Rectangle(0, 0, Width, Height));
                    break;
            }
            if (_Rounded)
            {
                G.FillRectangle(new SolidBrush(Parent.BackColor), new Rectangle(0, 0, 1, 1));
                G.FillRectangle(new SolidBrush(Parent.BackColor), new Rectangle(Width - 1, 0, 1, 1));
                G.FillRectangle(new SolidBrush(Parent.BackColor), new Rectangle(0, Height - 1, 1, 1));
                G.FillRectangle(new SolidBrush(Parent.BackColor), new Rectangle(Width - 1, Height - 1, 1, 1));
            }
            StringFormat _StringF = new StringFormat();
            _StringF.Alignment = StringAlignment.Center;
            _StringF.LineAlignment = StringAlignment.Center;
            G.DrawString(Text, new Font("Segoe UI", 10), Brushes.White, new RectangleF(0, 0, Width - 1, Height - 1), _StringF);
        }

    }


}


