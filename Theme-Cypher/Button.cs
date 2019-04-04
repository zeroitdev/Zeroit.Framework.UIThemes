// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
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
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Cypher
{
    public class CypherxButton : Control
    {

        public CypherxButton()
        {
            Font = new Font("Arial", 8);
            ForeColor = Color.White;
        }

        private enum State
        {
            MouseDown,
            MouseEnter,
            MouseLeft
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            MouseState = State.MouseLeft;
            Invalidate();
        }

        protected override void OnMouseEnter(System.EventArgs e)
        {
            MouseState = State.MouseEnter;
            Invalidate();
        }

        protected override void OnMouseClick(System.Windows.Forms.MouseEventArgs e)
        {
            MouseState = State.MouseLeft;
            Invalidate();
            base.OnMouseClick(e);
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            Invalidate();
        }

        State MouseState = State.MouseLeft;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            using (Bitmap b = new Bitmap(Width, Height))
            {
                using (Graphics g = Graphics.FromImage(b))
                {
                    Rectangle OuterR = new Rectangle(0, 0, Width - 1, Height - 1);
                    Rectangle InnerR = new Rectangle(1, 1, Width - 3, Height - 3);
                    Rectangle UpHalf = new Rectangle(2, 2, Width - 3, (Height - 1) / 2);
                    Rectangle DownHalf = new Rectangle(2, (Height - 1) / 2, Width - 3, (Height - 1) / 2);

                    switch (MouseState)
                    {
                        case State.MouseLeft:
                            Draw.Gradient(g, Color.FromArgb(88, 79, 72), Color.FromArgb(76, 69, 61), UpHalf);
                            Draw.Gradient(g, Color.FromArgb(56, 46, 36), Color.FromArgb(66, 56, 46), DownHalf);
                            g.DrawRectangle(Pens.Black, OuterR);
                            g.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(75, 66, 60))), InnerR);
                            ForeColor = Color.White;
                            break;
                        case State.MouseEnter:
                            Draw.Gradient(g, Color.FromArgb(234, 236, 241), Color.FromArgb(215, 219, 225), UpHalf);
                            Draw.Gradient(g, Color.FromArgb(189, 193, 198), Color.FromArgb(195, 198, 201), DownHalf);
                            ForeColor = Color.FromArgb(23, 32, 37);
                            break;
                    }
                    SizeF S = g.MeasureString(Text, Font);
                    g.DrawString(Text, Font, new SolidBrush(ForeColor), Convert.ToInt32(Width / 2 - S.Width / 2), Convert.ToInt32(Height / 2 - S.Height / 2));

                    e.Graphics.DrawImage((Bitmap)b.Clone(), 0, 0);
                }
            }
            base.OnPaint(e);
        }

        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
    }


}
