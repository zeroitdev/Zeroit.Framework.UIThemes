// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Tab.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.SLC
{
    #region "SLCTabControl"
    public class SLCTabControl : TabControl
    {

        public SLCTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(30, 120);

        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Left;
        }

        public GraphicsPath Borderpts()
        {
            GraphicsPath P = new GraphicsPath();
            List<Point> PS = new List<Point>();

            PS.Add(new Point(0, 0));
            PS.Add(new Point(Width - 1, 0));
            PS.Add(new Point(Width - 1, Height - 1));
            PS.Add(new Point(0, Height - 1));



            P.AddPolygon(PS.ToArray());
            return P;
        }

        public GraphicsPath BorderptsInside()
        {
            GraphicsPath P = new GraphicsPath();
            List<Point> PS = new List<Point>();

            PS.Add(new Point(1, 1));
            PS.Add(new Point(122, 1));
            PS.Add(new Point(122, Height - 2));
            PS.Add(new Point(1, Height - 2));



            P.AddPolygon(PS.ToArray());
            return P;
        }

        public GraphicsPath BigBorder()
        {
            GraphicsPath P = new GraphicsPath();
            List<Point> PS = new List<Point>();

            PS.Add(new Point(50, 1));
            PS.Add(new Point(349, 50));
            PS.Add(new Point(349, 50));
            PS.Add(new Point(50, 349));

            P.AddPolygon(PS.ToArray());
            return P;
        }


        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {


            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            g.Clear(Color.White);




            ////Big square shadow







            GraphicsPath GP1 = Borderpts();
            g.DrawPath(Pens.LightGray, GP1);


            //// small border
            GraphicsPath tmp1 = BorderptsInside();

            PathGradientBrush PB2 = default(PathGradientBrush);
            PB2 = new PathGradientBrush(tmp1);
            PB2.CenterColor = Color.FromArgb(250, 250, 250);
            PB2.SurroundColors = new Color[] { Color.FromArgb(237, 237, 237) };
            PB2.FocusScales = new PointF(0.9f, 0.9f);

            g.FillPath(PB2, tmp1);
            g.DrawPath(Pens.Gray, tmp1);




            //// items







            for (int i = 0; i <= TabCount - 1; i++)
            {
                Rectangle rec = GetTabRect(i);
                Rectangle rec2 = rec;


                ////inside small 
                rec2.Width -= 3;
                rec2.Height -= 3;
                rec2.Y += 1;
                rec2.X += 1;





                if (i == SelectedIndex)
                {


                    LinearGradientBrush linear = new LinearGradientBrush(new Rectangle(rec2.X + 108, rec2.Y + 1, 10, rec2.Height - 1), Color.FromArgb(227, 227, 227), Color.Transparent, 180f);
                    LinearGradientBrush linear3 = new LinearGradientBrush(new Rectangle(rec2.X, rec2.Y + 1, 10, rec2.Height - 1), Color.FromArgb(227, 227, 227), Color.Transparent, 180f);


                    g.FillRectangle(new SolidBrush(Color.FromArgb(242, 242, 242)), rec2);
                    g.DrawRectangle(Pens.White, rec2);
                    g.DrawRectangle(new Pen(Color.FromArgb(70, Color.FromArgb(39, 93, 127)), 2), rec);
                    g.FillRectangle(linear, new Rectangle(rec2.X + 113, rec2.Y + 1, 6, rec2.Height - 1));
                    g.FillRectangle(linear3, new Rectangle(rec2.X, rec2.Y + 1, 6, rec2.Height - 1));
                    //// circle


                    g.SmoothingMode = SmoothingMode.HighQuality;
                    //    g.DrawEllipse(New Pen(Color.FromArgb(200, 200, 200), 3), New Rectangle(rec2.X + 6.5, rec2.Y + 7, 14, 14))
                    // g.DrawEllipse(New Pen(Color.FromArgb(150, 150, 150), 1), New Rectangle(rec2.X + 6.5, rec2.Y + 7, 14, 14))


                    GraphicsPath GPF = new GraphicsPath();
                    GPF.AddEllipse(new Rectangle(rec2.X + 8, rec2.Y + 8, 12, 12));
                    PathGradientBrush PB3 = default(PathGradientBrush);
                    PB3 = new PathGradientBrush(GPF);
                    PB3.CenterPoint = new Point(rec2.X - 10, rec2.Y - 10);
                    PB3.CenterColor = Color.FromArgb(56, 142, 196);
                    PB3.SurroundColors = new Color[] { Color.FromArgb(64, 106, 140) };
                    PB3.FocusScales = new PointF(0.9f, 0.9f);


                    g.FillPath(PB3, GPF);

                    g.DrawPath(new Pen(Color.FromArgb(49, 63, 86)), GPF);
                    g.SetClip(GPF);
                    g.FillEllipse(new SolidBrush(Color.FromArgb(40, Color.WhiteSmoke)), new Rectangle((int)(rec2.X + 10.5f), rec2.Y + 11, 6, 6));
                    g.ResetClip();



                    g.SmoothingMode = SmoothingMode.None;


                }
                else
                {
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    LinearGradientBrush linear = new LinearGradientBrush(new Rectangle(rec2.X + 108, rec2.Y + 1, 10, rec2.Height - 1), Color.FromArgb(227, 227, 227), Color.Transparent, 180f);
                    LinearGradientBrush linear3 = new LinearGradientBrush(new Rectangle(rec2.X, rec2.Y + 1, 10, rec2.Height - 1), Color.FromArgb(227, 227, 227), Color.Transparent, 180f);


                    g.FillRectangle(new SolidBrush(Color.FromArgb(242, 242, 242)), rec2);
                    g.DrawRectangle(Pens.White, rec2);
                    g.DrawRectangle(new Pen(Color.FromArgb(70, Color.FromArgb(39, 93, 127)), 2), rec);
                    g.FillRectangle(linear, new Rectangle(rec2.X + 113, rec2.Y + 1, 6, rec2.Height - 1));
                    g.FillRectangle(linear3, new Rectangle(rec2.X, rec2.Y + 1, 6, rec2.Height - 1));


                    g.FillEllipse(Brushes.LightGray, new Rectangle(rec2.X + 8, rec2.Y + 8, 12, 12));
                    g.DrawEllipse(new Pen(Color.FromArgb(100, 100, 100), 1), new Rectangle(rec2.X + 8, rec2.Y + 8, 12, 12));
                    g.SmoothingMode = SmoothingMode.None;

                }

                g.DrawString(TabPages[i].Text, Font, new SolidBrush(Color.FromArgb(56, 106, 137)), rec, new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }




            e.Graphics.DrawImage((Bitmap)b.Clone(), 0, 0);
            g.Dispose();
            b.Dispose();
            base.OnPaint(e);
        }



    }
    #endregion

}

