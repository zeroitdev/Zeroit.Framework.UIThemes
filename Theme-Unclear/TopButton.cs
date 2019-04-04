// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.UClear
{
    public class UnCleartopbuttons : Control
    {
        public enum MouseState
        {
            None = 0,
            Over = 1,
            Down = 2
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {


            base.OnPaint(e);
            Brush p = new SolidBrush(Color.FromArgb(156, 200, 205));
            Brush pa = new SolidBrush(Color.FromArgb(35, 35, 35));
            Pen ps = new Pen(Color.FromArgb(156, 200, 205));
            Pen pss = new Pen(Color.FromArgb(35, 35, 35));
            Graphics G = e.Graphics;
            G.Clear(Color.FromArgb(50, 50, 50));
            G.DrawEllipse(ps, 40, 4, 4, 4);
            G.FillEllipse(p, 40, 4, 4, 4);
            G.DrawEllipse(ps, 25, 4, 4, 4);
            G.FillEllipse(p, 25, 4, 4, 4);
            G.DrawEllipse(ps, 10, 4, 4, 4);
            G.FillEllipse(p, 10, 4, 4, 4);
            ///''
            G.DrawEllipse(pss, 41, 5, 2, 2);
            G.FillEllipse(pa, 41, 5, 2, 2);
            G.DrawEllipse(pss, 26, 5, 2, 2);
            G.FillEllipse(pa, 26, 5, 2, 2);
            G.DrawEllipse(pss, 11, 5, 2, 2);
            G.FillEllipse(pa, 11, 5, 2, 2);




            base.Size = new Size(52, 12);





        }

        //close handle fully coded by korezn..not fun

        public void Form1_Mouseclick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            CoordinateSpace posX = new CoordinateSpace();
            CoordinateSpace posY = new CoordinateSpace();

            posX = (CoordinateSpace)e.X;
            Rectangle CloseArea = new Rectangle(Width - 12, 3, 6, 6);
            // close area

            posY = (CoordinateSpace)e.Y;

            Graphics g = this.CreateGraphics();
            // I give it drawing object which is aform


            if (CloseArea.Contains((int)posX, (int)posY))
            {
                Application.Exit();




            }
            // minimize
            CoordinateSpace posXx = new CoordinateSpace();
            CoordinateSpace posYy = new CoordinateSpace();

            posXx = (CoordinateSpace)e.X;
            Rectangle min = new Rectangle(Width - 42, 3, 6, 6);
            // min

            posYy = (CoordinateSpace)e.Y;

            g = this.CreateGraphics();
            // I give it drawing object which is aform


            if (min.Contains((int)posXx, (int)posYy))
            {
                Parent.FindForm().WindowState = FormWindowState.Minimized;
            }


            //max
            CoordinateSpace posXxx = new CoordinateSpace();
            CoordinateSpace posYyy = new CoordinateSpace();

            posXxx = (CoordinateSpace)e.X;
            Rectangle max = new Rectangle(Width - 27, 3, 6, 6);
            // min

            posYyy = (CoordinateSpace)e.Y;

            g = this.CreateGraphics();
            // I give it drawing object which is aform


            if (max.Contains((int)posXxx, (int)posYyy))
            {
                Parent.FindForm().WindowState = FormWindowState.Maximized;
            }


        }




        public UnCleartopbuttons()
        {
            MouseClick += Form1_Mouseclick;
        }



    }

}


