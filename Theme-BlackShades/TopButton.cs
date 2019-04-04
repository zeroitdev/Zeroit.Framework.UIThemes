// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TopButton.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.BlackShades
{

    public class BlackShadesNetTopButton : Control
    {
        #region " Control Help - MouseState & Flicker Control"


        private MouseState State = MouseState.None;
        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        #endregion

        public BlackShadesNetTopButton() : base()
        {
            BackColor = Color.FromArgb(38, 38, 38);
            Font = new Font("Verdana", 8.25f);
            Size = new Size(15, 11);
            DoubleBuffered = true;
            Focus();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Draw d = new Draw();

            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);

            Size = new Size(15, 11);
            G.Clear(Color.FromArgb(49, 53, 55));

            switch (State)
            {
                case MouseState.None:
                    //Mouse None
                    LinearGradientBrush border = new LinearGradientBrush(ClientRectangle, Color.FromArgb(200, 44, 47, 51), Color.FromArgb(80, 64, 69, 71), 90);
                    G.FillPath(border, d.RoundRect(ClientRectangle, 1));
                    LinearGradientBrush bodyGrad = new LinearGradientBrush(new Rectangle(2, 2, Width - 6, Height - 6), Color.FromArgb(90, 97, 101), Color.FromArgb(63, 69, 73), 90);
                    G.FillPath(bodyGrad, d.RoundRect(new Rectangle(2, 2, Width - 6, Height - 6), 1));
                    G.DrawPath(new Pen(Color.FromArgb(30, 32, 35)), d.RoundRect(new Rectangle(2, 2, Width - 6, Height - 6), 1));
                    break;
                case MouseState.Over:
                    LinearGradientBrush border1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(200, 44, 47, 51), Color.FromArgb(80, 64, 69, 71), 90);
                    G.FillPath(border1, d.RoundRect(ClientRectangle, 1));
                    LinearGradientBrush bodyGrad1 = new LinearGradientBrush(new Rectangle(2, 2, Width - 6, Height - 6), Color.FromArgb(90, 97, 101), Color.FromArgb(63, 69, 73), 90);
                    G.FillPath(bodyGrad1, d.RoundRect(new Rectangle(2, 2, Width - 6, Height - 6), 1));
                    G.DrawPath(new Pen(Color.FromArgb(30, 32, 35)), d.RoundRect(new Rectangle(2, 2, Width - 6, Height - 6), 1));
                    G.DrawPath(new Pen(Color.FromArgb(200, 0, 186, 255)), d.RoundRect(new Rectangle(2, 2, Width - 6, Height - 6), 1));
                    break;
                case MouseState.Down:
                    LinearGradientBrush border2 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(200, 44, 47, 51), Color.FromArgb(80, 64, 69, 71), 90);
                    G.FillPath(border2, d.RoundRect(ClientRectangle, 1));
                    LinearGradientBrush bodyGrad2 = new LinearGradientBrush(new Rectangle(2, 2, Width - 6, Height - 6), Color.FromArgb(90, 97, 101), Color.FromArgb(63, 69, 73), 135);
                    G.FillPath(bodyGrad2, d.RoundRect(new Rectangle(2, 2, Width - 6, Height - 6), 1));
                    G.DrawPath(new Pen(Color.FromArgb(30, 32, 35)), d.RoundRect(new Rectangle(2, 2, Width - 6, Height - 6), 1));
                    break;
            }

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }
    
}
