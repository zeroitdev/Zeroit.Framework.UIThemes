// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 08-12-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 08-16-2017
// ***********************************************************************
// <copyright file="Angel Theme.cs" company="Zeroit Dev Technologies">
//    This program is for creating Theme controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Angel
{


    /// <summary>
    /// Class AngelControlBox.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class AngelControlBox : Control
    {

        #region " Back End "

        #region " Declarations "
        /// <summary>
        /// The s
        /// </summary>
        private MouseState S = MouseState.None;
        /// <summary>
        /// The c
        /// </summary>
        private State C = State.Enabled;
        /// <summary>
        /// The m
        /// </summary>
        private State M = State.Enabled;
        #endregion
        /// <summary>
        /// The x
        /// </summary>
        private int X;

        #region " Mouse States "

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            S = MouseState.Over;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            S = MouseState.None;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            S = MouseState.Down;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            S = MouseState.Over;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.X;
            Invalidate();
        }
        
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Click" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (X <= 24)
            {
                Parent.FindForm().WindowState = FormWindowState.Minimized;
            }
            else
            {
                Application.Exit();
            }
        }

        #endregion

        #region " Misc "

        /// <summary>
        /// Initializes a new instance of the <see cref="AngelControlBox"/> class.
        /// </summary>
        public AngelControlBox()
        {
            Size = new Size(52, 23);
            DoubleBuffered = true;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Size = new Size(52, 23);
        }

        #endregion

        #endregion

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;
            G.Clear(Color.Black);
            G.FillRectangle(new LinearGradientBrush(new Point(1, 1), new Point(1, Height - 1), Color.FromArgb(53, 79, 109), Color.FromArgb(24, 46, 69)), new Rectangle(1, 1, Width - 2, Height - 2));
            G.DrawRectangle(new Pen(Color.FromArgb(30, Color.White)), new Rectangle(1, 1, Width - 3, Height - 3));
            G.DrawLine(Pens.Black, new Point(25, 0), new Point(25, Height));
            G.DrawLine(new Pen(Color.FromArgb(30, Color.White)), new Point(26, 2), new Point(26, Height - 3));
            G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.White)), new Rectangle(0, 0, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.White)), new Rectangle(Width - 1, 0, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.White)), new Rectangle(0, Height - 1, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.White)), new Rectangle(Width - 1, Height - 1, 1, 1));
            switch (S)
            {
                case MouseState.Over:
                    if (X <= 24)
                    {
                        G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)), new Rectangle(1, 1, 24, Height - 2));
                    }
                    else
                    {
                        G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)), new Rectangle(26, 1, 25, Height - 2));
                    }
                    break;
                case MouseState.Down:
                    if (X <= 24)
                    {
                        G.FillRectangle(new SolidBrush(Color.FromArgb(75, Color.Black)), new Rectangle(1, 1, 24, Height - 2));
                    }
                    else
                    {
                        G.FillRectangle(new SolidBrush(Color.FromArgb(75, Color.Black)), new Rectangle(26, 1, 25, Height - 2));
                    }
                    break;
            }
            StringFormat F = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            G.DrawString("r", new Font("Marlett", 9), Brushes.White, new Rectangle(27, 1, 25, Height - 2), F);
            G.DrawString("0", new Font("Marlett", 9), Brushes.White, new Rectangle(3, 1, 24, Height - 3), F);
        }
    }
    
}