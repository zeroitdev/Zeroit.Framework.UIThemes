// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Perplex Theme.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Form.UIThemes.Perplex
{

    
    public enum MouseState : byte
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
    
    public class PerplexTheme : ContainerControl
    {
        public PerplexTheme()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.FromArgb(25, 25, 25);
            DoubleBuffered = true;
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle TopLeft = new Rectangle(0, 0, Width - 125, 28);
            Rectangle TopRight = new Rectangle(Width - 82, 0, 81, 28);
            Rectangle Body = new Rectangle(10, 10, Width - 21, Height - 16);
            Rectangle Body2 = new Rectangle(5, 5, Width - 11, Height - 6);

            base.OnPaint(e);

            G.Clear(Color.Fuchsia);

            LinearGradientBrush BodyBrush = new LinearGradientBrush(Body2, Color.FromArgb(26, 26, 26), Color.FromArgb(30, 35, 48), 90);
            G.FillPath(BodyBrush, Draw.RoundRect(Body2, 3));
            G.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(Body2, 3));

            LinearGradientBrush BodyBrush2 = new LinearGradientBrush(Body, Color.FromArgb(46, 46, 46), Color.FromArgb(50, 55, 58), 120);
            G.FillPath(BodyBrush2, Draw.RoundRect(Body, 3));
            G.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(Body, 3));

            LinearGradientBrush gloss = new LinearGradientBrush(new Rectangle(0, 0, Width - 125, 28 / 2), Color.FromArgb(240, Color.FromArgb(26, 26, 26)), Color.FromArgb(5, 255, 255, 255), 90);
            LinearGradientBrush mainbrush = new LinearGradientBrush(TopLeft, Color.FromArgb(26, 26, 26), Color.FromArgb(30, 30, 30), 90);
            G.FillPath(mainbrush, Draw.RoundRect(TopLeft, 3));
            G.FillPath(gloss, Draw.RoundRect(TopLeft, 3));
            G.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(TopLeft, 3));

            LinearGradientBrush gloss2 = new LinearGradientBrush(new Rectangle(Width - 82, 0, Width - 205, 28 / 2), Color.FromArgb(240, Color.FromArgb(26, 26, 26)), Color.FromArgb(5, 255, 255, 255), 90);
            LinearGradientBrush mainbrush2 = new LinearGradientBrush(TopRight, Color.FromArgb(26, 26, 26), Color.FromArgb(30, 30, 30), 90);
            G.FillPath(mainbrush, Draw.RoundRect(TopRight, 3));
            G.FillPath(gloss2, Draw.RoundRect(TopRight, 3));
            G.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(TopRight, 3));

            Pen p1 = new Pen(Color.FromArgb(174, 195, 30), 2);
            G.DrawLine(p1, 14, 9, 14, 22);
            Pen p2 = new Pen(Color.FromArgb(174, 195, 30), 2);
            G.DrawLine(p2, 17, 6, 17, 25);
            Pen p3 = new Pen(Color.FromArgb(174, 195, 30), 2);
            G.DrawLine(p3, 20, 9, 20, 22);

            Pen p4 = new Pen(Color.FromArgb(174, 195, 30), 2);
            G.DrawLine(p4, 11, 12, 11, 19);
            Pen p5 = new Pen(Color.FromArgb(174, 195, 30), 2);
            G.DrawLine(p4, 23, 12, 23, 19);

            Pen p6 = new Pen(Color.FromArgb(174, 195, 30), 2);
            G.DrawLine(p6, 8, 14, 8, 17);
            Pen p7 = new Pen(Color.FromArgb(174, 195, 30), 2);
            G.DrawLine(p7, 26, 14, 26, 17);


            Font drawFont = new Font("Tahoma", 10, FontStyle.Bold);
            G.DrawString(Text, drawFont, new SolidBrush(Color.WhiteSmoke), new Rectangle(32, 1, Width - 1, 27), new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            });

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }



        private Point MouseP = new Point(0, 0);
        private bool Cap = false;
        private int MoveHeight = 29;
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


