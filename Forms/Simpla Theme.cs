// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Simpla Theme.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.Form.UIThemes.Simpla
{

    
    enum MouseState : byte
    {
        None = 0,
        Over = 1,
        Down = 2,
        Block = 3
    }
    static class Draw
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
    public class SimplaTheme : ContainerControl
    {

        public SimplaTheme()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.FromArgb(25, 25, 25);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            Rectangle mainTop = new Rectangle(0, 0, Width - 1, 40);
            Rectangle mainBottom = new Rectangle(0, 40, Width, Height);

            base.OnPaint(e);


            G.Clear(Color.Fuchsia);
            G.SetClip(Draw.RoundRect(new Rectangle(0, 0, Width, Height), 9));

            SolidBrush gradientBackground = new SolidBrush(Color.FromArgb(34, 34, 34));
            G.FillRectangle(gradientBackground, mainBottom);

            LinearGradientBrush gradientBackground2 = new LinearGradientBrush(mainTop, Color.FromArgb(23, 23, 23), Color.FromArgb(17, 17, 17), 90);
            G.FillRectangle(gradientBackground2, mainTop);

            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(56, 56, 56))), 0, 40, Width - 1, 40);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(42, 42, 42))), 0, 41, Width - 1, 41);

            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(12, 12, 12))), new Rectangle(0, 0, Width - 1, Height - 1));

            Font drawFont = new Font("Calibri (Body)", 15, FontStyle.Bold);
            G.DrawString(Parent.FindForm().Text, drawFont, new SolidBrush(Color.FromArgb(225, 225, 225)), 3, 18);

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }


        private Point MouseP = new Point(0, 0);
        private bool Cap = false;
        private int MoveHeight = 40;
        private int pos = 0;
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left & new Rectangle(0, 0, Width, MoveHeight).Contains(e.Location))
            {
                Cap = true;
                MouseP = e.Location;
            }
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cap = false;
        }
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Cap)
            {
                Parent.Location = new Point(MousePosition.X - MouseP.X, MousePosition.Y - MouseP.Y);
            }
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.ParentForm.FormBorderStyle = FormBorderStyle.None;
            this.ParentForm.TransparencyKey = Color.Fuchsia;
            Dock = DockStyle.Fill;
        }
    }

    
}

