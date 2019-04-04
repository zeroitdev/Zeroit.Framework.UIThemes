// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TopButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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


