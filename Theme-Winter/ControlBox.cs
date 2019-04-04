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

namespace Zeroit.Framework.UIThemes.Winter
{

    public class WinterControlBox : Control
    {

        #region " Declarations "
        private MouseState _State = MouseState.None;
        #endregion
        private int _MousePoint;

        #region " Mouse States "

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

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            _MousePoint = e.X;
            Invalidate();
        }

        #endregion
        
        #region " Properties "

        public WinterControlBox()
        {
            Size = new Size(60, 31);
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Size = new Size(60, 31);
            Invalidate();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Dock = DockStyle.Right;
            Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (_MousePoint > 30)
            {
                Parent.FindForm().Close();
            }
            else
            {
                Parent.FindForm().WindowState = FormWindowState.Minimized;
            }
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;
            G.Clear(Color.FromArgb(28, 28, 28));

            switch (_State)
            {
                case MouseState.Over:
                    if (_MousePoint > 30)
                    {
                        G.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), new Rectangle(30, 0, 30, 31));
                    }
                    else
                    {
                        G.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), new Rectangle(0, 0, 30, 31));
                    }

                    break;
                case MouseState.Down:
                    if (_MousePoint > 30)
                    {
                        G.FillRectangle(new SolidBrush(Color.FromArgb(70, Color.Black)), new Rectangle(30, 0, 30, 31));
                    }
                    else
                    {
                        G.FillRectangle(new SolidBrush(Color.FromArgb(70, Color.Black)), new Rectangle(0, 0, 30, 31));
                    }
                    break;
            }

            StringFormat _StringF = new StringFormat();
            _StringF.Alignment = StringAlignment.Center;
            _StringF.LineAlignment = StringAlignment.Center;
            G.DrawString("r", new Font("Marlett", 11), Brushes.White, new RectangleF(Width - 30, 0, 30, 30), _StringF);

            G.FillRectangle(Brushes.White, new Rectangle(Width - 50, 14, 10, 3));
            G.FillRectangle(Brushes.Fuchsia, new Rectangle(Width - 1, 0, 1, 1));
            G.FillRectangle(Brushes.Fuchsia, new Rectangle(Width - 2, 0, 1, 1));
            G.FillRectangle(Brushes.Fuchsia, new Rectangle(Width - 1, 1, 1, 1));
        }

    }

}

