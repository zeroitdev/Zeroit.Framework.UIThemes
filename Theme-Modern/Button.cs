// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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


namespace Zeroit.Framework.UIThemes.Modern
{
    public class ModernButton : Control
    {
        public ModernButton()
        {
            ForeColor = C3;
        }
        private int State;
        protected override void OnMouseEnter(System.EventArgs e)
        {
            State = 1;
            Invalidate();
            base.OnMouseEnter(e);
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            State = 2;
            Invalidate();
            base.OnMouseDown(e);
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            State = 0;
            Invalidate();
            base.OnMouseLeave(e);
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            State = 1;
            Invalidate();
            base.OnMouseUp(e);
        }
        Color C1 = Color.FromArgb(240, 240, 240);
        Color C2 = Color.FromArgb(230, 230, 230);
        Color C3 = Color.FromArgb(190, 190, 190);
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            using (Bitmap B = new Bitmap(Width, Height))
            {
                using (Graphics G = Graphics.FromImage(B))
                {
                    if (State == 2)
                    {
                        Draw.Gradient(G, C2, Color.WhiteSmoke, 1, 1, Width, Height);
                    }
                    else
                    {
                        Draw.Gradient(G, Color.WhiteSmoke, C2, 1, 1, Width, Height);
                    }

                    if (State < 2)
                        G.FillRectangle(new SolidBrush(Color.FromArgb(80, 255, 255, 255)), 0, 0, Width, Convert.ToInt32(Height * 0.3));

                    dynamic S = G.MeasureString(Text, Font);
                    G.DrawString(Text, Font, new SolidBrush(ForeColor), Width / 2 - S.Width / 2, Height / 2 - S.Height / 2);
                    G.DrawRectangle(new Pen(C3), 0, 0, Width - 1, Height - 1);

                    e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
                }
            }
        }
    }


}


