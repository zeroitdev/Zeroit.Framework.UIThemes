// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ComboBox.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.SLC
{
    #region "SLCComboBox"
    public class SLCComboBox : ComboBox
    {

        public SLCComboBox()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;


            DrawMode = DrawMode.OwnerDrawFixed;


        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            G.Clear(Color.White);





            //inside borders



            GraphicsPath GP = RoundRec(new Rectangle(0, 0, Width - 1, Height - 1), 5);
            GraphicsPath GP2 = RoundRec(new Rectangle(1, 1, Width - 3, Height - 3), 5);
            GraphicsPath GP3 = RoundRec(new Rectangle(2, 2, Width - 5, Height - 5), 5);


            G.SmoothingMode = SmoothingMode.HighQuality;

            G.FillPath(new SolidBrush(Color.FromArgb(250, 250, 250)), GP3);
            G.DrawPath(new Pen(Color.FromArgb(60, Color.LightGray), 4), GP2);
            G.DrawPath(new Pen(Color.FromArgb(100, Color.FromArgb(15, 15, 15))), GP);
            // G.DrawPath(New Pen(Color.FromArgb(60, Color.LightGray), 4), GP3)
            G.SmoothingMode = SmoothingMode.None;

            Rectangle rect1 = new Rectangle(Width - 26, 0, 1, Height);
            Rectangle rect2 = new Rectangle(Width - 27, 0, 2, Height);
            G.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.FromArgb(1, 75, 124))), rect1);
            G.DrawRectangle(new Pen(Color.FromArgb(60, Color.FromArgb(61, 113, 153))), rect1);



            //little arrow shit

            G.SmoothingMode = SmoothingMode.HighQuality;


            G.DrawArc(new Pen(Color.FromArgb(97, 152, 195)), new Rectangle(Width - 18, Height - 19, 8, 8), 20, 140);

            G.DrawArc(new Pen(Color.LightGray), new Rectangle(Width - 18, Height - 18, 8, 8), 10, 160);
            G.DrawArc(new Pen(Color.FromArgb(78, 121, 154), (float)1.5), new Rectangle(Width - 18, Height - 20, 8, 8), 20, 140);



            G.DrawArc(new Pen(Color.FromArgb(97, 152, 195)), new Rectangle(Width - 19, Height - 16, 10, 10), 20, 140);

            G.DrawArc(new Pen(Color.LightGray), new Rectangle(Width - 19, Height - 15, 10, 10), 10, 160);
            G.DrawArc(new Pen(Color.FromArgb(78, 121, 154), (float)1.5), new Rectangle(Width - 19, Height - 17, 10, 10), 20, 140);
            G.SmoothingMode = SmoothingMode.None;


            PointF PT1 = new PointF(3, Height - 18);

            G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(1, 75, 124)), PT1);
        }


        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(250, 250, 250)), e.Bounds);
            }

            if (!(e.Index == -1))
            {
                e.Graphics.DrawString(GetItemText(Items[e.Index]), e.Font, new SolidBrush(Color.FromArgb(1, 75, 124)), e.Bounds);
            }
        }

        public GraphicsPath RoundRec(Rectangle Rectangle, int Curve)
        {
            GraphicsPath P = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return P;
        }
    }
    #endregion

}

