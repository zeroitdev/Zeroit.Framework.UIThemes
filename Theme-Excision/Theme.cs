// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Theme.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Excision
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
    public class ImageToCodeClass
    {
        public string ImageToCode(Bitmap Img)
        {
            return Convert.ToBase64String((byte[])System.ComponentModel.TypeDescriptor.GetConverter(Img).ConvertTo(Img, typeof(byte[])));
        }

        public Image CodeToImage(string Code)
        {
            return Image.FromStream(new System.IO.MemoryStream(Convert.FromBase64String(Code)));
        }
    }

    [ToolboxItem(false)]
    public class ExcisionTheme : ContainerControl
    {
        private GraphicsPath CreateRoundPath;

        private Rectangle CreateRoundRectangle;
        public GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
        {
            CreateRoundRectangle = new Rectangle(x, y, width, height);
            return CreateRound(CreateRoundRectangle, slope);
        }

        public GraphicsPath CreateRound(Rectangle r, int slope)
        {
            CreateRoundPath = new GraphicsPath(FillMode.Winding);
            CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
            CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270f, 90f);
            CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0f, 90f);
            CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90f, 90f);
            CreateRoundPath.CloseFigure();
            return CreateRoundPath;
        }
        public ExcisionTheme()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.FromArgb(25, 25, 25);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            Rectangle CR = new Rectangle(0, 0, Width - 1, 35);
            Rectangle Main = new Rectangle(0, 35, Width, Height - 35);

            base.OnPaint(e);

            G.Clear(Color.Fuchsia);

            G.CompositingQuality = CompositingQuality.HighQuality;

            ImageToCodeClass itc = new ImageToCodeClass();
            Bitmap BG = (Bitmap)itc.CodeToImage("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");
            TextureBrush BGT = new TextureBrush(BG, WrapMode.TileFlipXY);
            G.FillRectangle(BGT, Main);


            LinearGradientBrush lbb = new LinearGradientBrush(CR, Color.FromArgb(68, 68, 68), Color.FromArgb(45, 45, 45), 90);
            G.FillRectangle(lbb, CR);
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(26, 26, 26))), CR);

            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(70, 70, 70))), 0, 36, Width - 1, 36);

            G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(15, 15, 15))), CreateRound(new Rectangle(0, 0, Width - 1, Height - 1), 10));
            G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(88, 88, 88))), CreateRound(new Rectangle(1, 1, Width - 3, Height - 3), 10));

            Font drawFont = new Font("Tahoma", 10, FontStyle.Bold);
            G.DrawString(Parent.FindForm().Text, drawFont, Brushes.WhiteSmoke, 12, 10);

            //////left upper corner
            G.FillRectangle(Brushes.Fuchsia, 0, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 1, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 2, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 3, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, 2, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, 3, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 1, 1, 1, 1);
            //'////right upper corner
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 2, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 3, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 4, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 2, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 3, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 2, 1, 1, 1);
            //'////left bottom corner
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 2, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 3, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 4, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 1, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 2, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 3, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 1, Height - 1, 1, 1);
            //G.FillRectangle(Brushes.Fuchsia, 2, Height - 2, 1, 1)
            //'////right bottom corner
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 2, Height, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 3, Height, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 4, Height, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 2, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 3, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 2, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 3, Height - 1, 1, 1);


            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
        private Point MouseP = new Point(0, 0);
        private bool Cap = false;
        private int MoveHeight = 35;
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