// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ControlBox.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.NYX
{
    public class NYXControlBox : ThemeControl154
    {
        //Coded by HΛWK

        int X;
        bool minOver;

        bool xOver;
        public NYXControlBox()
        {
            this.Size = new Size(44, 20);
            IsAnimated = true;
        }

        protected override void ColorHook()
        {
        }

        //Coded by HΛWK
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.X;
            Invalidate();
        }

        protected override void OnClick(System.EventArgs e)
        {
            base.OnClick(e);
            if (X <= 22)
            {
                Parent.FindForm().WindowState = FormWindowState.Minimized;
            }
            else
            {
                Parent.FindForm().Close();
            }
        }

        //Coded by HΛWK
        protected override void OnAnimation()
        {
            base.OnAnimation();
        }

        //Coded by HΛWK
        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(30, 30, 30));
            Rectangle minRect = new Rectangle(0, 0, (Width / 2), Height - 1);
            Rectangle xRect = new Rectangle((Width / 2), 0, (Width / 2) - 1, Height - 1);
            Rectangle allRect = new Rectangle(0, 0, Width - 1, Height - 1);
            //MousePosition
            LinearGradientBrush bgLGB = new LinearGradientBrush(allRect, Color.FromArgb(30, 30, 30), Color.FromArgb(35, 35, 35), 90f);
            switch (State)
            {
                case MouseState.Over:
                    if (X < 22)
                    {
                        G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.White)), minRect);
                    }
                    else if (X > 22)
                    {
                        G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.White)), xRect);
                    }
                    else if (X == 22)
                    {
                        X = -1;
                        G.FillRectangle(bgLGB, allRect);
                    }
                    break;
                case MouseState.None:
                    G.FillRectangle(bgLGB, allRect);
                    break;
            }
            //OuterRects
            G.DrawRectangles(Pens.Black, new RectangleF[]{
            minRect,
            xRect
        });
            //Characters
            G.DrawString("0", new Font("Marlett", 8.25f), Brushes.White, new Point(5, 5));
            G.DrawString("r", new Font("Marlett", 10), Brushes.White, new Point(26, 4));
        }
    }

}

