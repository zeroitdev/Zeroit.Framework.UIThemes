// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Valley
{
    public class ValleyButton : Control
    {
        #region Variables
        private MouseState State = MouseState.None;
        #endregion

        #region Properties

        #region  Mouse States

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }

        #endregion

        #endregion

        public ValleyButton()
        {
            Size = new Size(150, 50);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var G = e.Graphics;

            G.Clear(Color.FromArgb(34, 122, 247));
            G.DrawRectangle(new Pen(Color.FromArgb(42, 59, 252)), new Rectangle(0, 0, Width - 1, Height - 1));

            switch (State)
            {
                case MouseState.Over:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)), new Rectangle(1, 1, Width - 2, Height - 2));
                    break;
                case MouseState.Down:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.Black)), new Rectangle(1, 1, Width - 2, Height - 2));
                    break;
            }

            G.FillRectangle(new SolidBrush(BackColor), new Rectangle(0, 0, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(134, 144, 253)), new Rectangle(0, 1, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(134, 144, 253)), new Rectangle(1, 0, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(56, 72, 251)), new Rectangle(0, 2, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(56, 72, 251)), new Rectangle(2, 0, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(62, 107, 249)), new Rectangle(1, 1, 1, 1));
            G.FillRectangle(new SolidBrush(BackColor), new Rectangle(Width - 1, 0, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(134, 144, 253)), new Rectangle(Width - 1, 1, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(134, 144, 253)), new Rectangle(Width - 2, 0, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(56, 72, 251)), new Rectangle(Width - 1, 2, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(56, 72, 251)), new Rectangle(Width - 3, 0, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(62, 107, 249)), new Rectangle(Width - 2, 1, 1, 1));
            G.FillRectangle(new SolidBrush(BackColor), new Rectangle(0, Height - 1, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(134, 144, 253)), new Rectangle(0, Height - 2, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(134, 144, 253)), new Rectangle(1, Height - 1, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(56, 72, 251)), new Rectangle(0, Height - 3, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(56, 72, 251)), new Rectangle(2, Height - 1, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(62, 107, 249)), new Rectangle(1, Height - 2, 1, 1));
            G.FillRectangle(new SolidBrush(BackColor), new Rectangle(Width - 1, Height - 1, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(134, 144, 253)), new Rectangle(Width - 1, Height - 2, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(134, 144, 253)), new Rectangle(Width - 2, Height - 1, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(56, 72, 251)), new Rectangle(Width - 1, Height - 3, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(56, 72, 251)), new Rectangle(Width - 3, Height - 1, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(62, 107, 249)), new Rectangle(Width - 2, Height - 2, 1, 1));

            G.DrawString(Text, Font, Brushes.White, new Point(Convert.ToInt32((Width / 2) - (TextRenderer.MeasureText(Text, Font).Width / 2.0)), Convert.ToInt32((Height / 2) - (TextRenderer.MeasureText(Text, Font).Height / 2.0))));

            base.OnPaint(e);


        }

    }
}


