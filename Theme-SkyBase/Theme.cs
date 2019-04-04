// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Theme.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.SkyLimit
{

    

    static class ConversionFunctions
    {
        public static Brush ToBrush(int A, int R, int G, int B)
        {
            return new SolidBrush(Color.FromArgb(A, R, G, B));
        }
        public static Brush ToBrush(int R, int G, int B)
        {
            return new SolidBrush(Color.FromArgb(R, G, B));
        }
        public static Brush ToBrush(int A, Color C)
        {
            return new SolidBrush(Color.FromArgb(A, C));
        }
        public static Brush ToBrush(Pen Pen)
        {
            return new SolidBrush(Pen.Color);
        }
        public static Brush ToBrush(Color Color)
        {
            return new SolidBrush(Color);
        }
        public static Pen ToPen(int A, int R, int G, int B)
        {
            return new Pen(new SolidBrush(Color.FromArgb(A, R, G, B)));
        }
        public static Pen ToPen(int R, int G, int B)
        {
            return new Pen(new SolidBrush(Color.FromArgb(R, G, B)));
        }
        public static Pen ToPen(int A, Color C)
        {
            return new Pen(new SolidBrush(Color.FromArgb(A, C)));
        }
        public static Pen ToPen(SolidBrush Brush)
        {
            return new Pen(Brush);
        }
        public static Pen ToPen(Color Color)
        {
            return new Pen(new SolidBrush(Color));
        }
    }
    
    static class RRM
    {
        public static GraphicsPath RoundRect(Rectangle Rectangle, int Curve)
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
        public static GraphicsPath RoundRect(int X, int Y, int Width, int Height, int Curve)
        {
            Rectangle Rectangle = new Rectangle(X, Y, Width, Height);
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

    static class Shapes
    {
        public static Point[] Triangle(Point Location, Size Size)
        {
            Point[] ReturnPoints = new Point[4];
            ReturnPoints[0] = Location;
            ReturnPoints[1] = new Point(Location.X + Size.Width, Location.Y);
            ReturnPoints[2] = new Point(Location.X + Size.Width / 2, Location.Y + Size.Height);
            ReturnPoints[3] = Location;

            return ReturnPoints;
        }
    }

    
    [ToolboxItem(false)]
    public class SkyDarkForm : ContainerControl
    {
        private SkyDarkTop withEventsField_Maxim;
        public SkyDarkTop Maxim
        {
            get { return withEventsField_Maxim; }
            set
            {
                if (withEventsField_Maxim != null)
                {
                    withEventsField_Maxim.Click -= Maxim_Click;
                }
                withEventsField_Maxim = value;
                if (withEventsField_Maxim != null)
                {
                    withEventsField_Maxim.Click += Maxim_Click;
                }
            }
        }
        private SkyDarkTop withEventsField_Exim;
        public SkyDarkTop Exim
        {
            get { return withEventsField_Exim; }
            set
            {
                if (withEventsField_Exim != null)
                {
                    withEventsField_Exim.Click -= Exim_Click;
                }
                withEventsField_Exim = value;
                if (withEventsField_Exim != null)
                {
                    withEventsField_Exim.Click += Exim_Click;
                }
            }
        }
        private bool Locked = false;

        private Point Locked1;
        public SkyDarkForm()
        {
            Dock = DockStyle.Fill;
            SendToBack();
            BackColor = Color.FromArgb(62, 60, 58);
        }

        protected override void OnHandleCreated(System.EventArgs e)
        {
            Parent.FindForm().FormBorderStyle = FormBorderStyle.None;
            Maxim = new SkyDarkTop
            {
                Location = new Point(Width - 41, 3),
                Size = new Size(14, 14),
                Parent = this
            };
            Exim = new SkyDarkTop
            {
                Location = new Point(Width - 22, 3),
                Size = new Size(14, 14),
                Parent = this
            };
            this.Controls.Add(Maxim);
            this.Controls.Add(Exim);
            Maxim.Show();
            Exim.Show();
        }
        Rectangle T1;
        Color C1 = Color.FromArgb(62, 60, 58);
        Color C2 = Color.FromArgb(81, 79, 77);
        Color C3 = Color.FromArgb(71, 70, 69);

        Color C4 = Color.FromArgb(58, 56, 54);
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            T1 = new Rectangle(1, 1, Width - 3, 18);

            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            //Drawing
            G.Clear(C1);
            LinearGradientBrush G1 = new LinearGradientBrush(new Point(T1.X, T1.Y), new Point(T1.X, T1.Y + T1.Height), C3, C4);
            G.FillRectangle(G1, T1);
            G.DrawRectangle(ConversionFunctions.ToPen(C2), T1);
            G.DrawRectangle(ConversionFunctions.ToPen(C2), new Rectangle(T1.X, T1.Y + T1.Height + 2, T1.Width, Height - T1.Y - T1.Height - 4));

            G1.Dispose();

            G.DrawString(Text, Font, ConversionFunctions.ToBrush(113, 170, 186), new Rectangle(new Point(T1.X + 4, T1.Y), new Size(T1.Width - 40, T1.Height)), new StringFormat { LineAlignment = StringAlignment.Center });


            //Finish Up
            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }

        private void Exim_Click(object sender, System.EventArgs e)
        {
            Parent.FindForm().Close();
        }

        private void Maxim_Click(object sender, System.EventArgs e)
        {
            Parent.FindForm().WindowState = FormWindowState.Minimized;
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Locked = false;
            Locked1 = new Point(0, 0);
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (T1.Contains(e.Location))
            {
                Locked = true;
                Locked1 = e.Location;
            }
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Locked)
                Parent.Location = new Point(Cursor.Position.X - Locked1.X, Cursor.Position.Y - Locked1.Y);
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            T1 = new Rectangle(1, 1, Width - 3, 18);
        }
    }
    
}