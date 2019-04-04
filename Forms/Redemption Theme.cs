// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Redemption Theme.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;

namespace Zeroit.Framework.Form.UIThemes.Redemption
{

    public enum MouseState : byte
    {
        None = 0,
        Over = 1,
        Down = 2
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


        private static Image ImageFromCode(ref String str)
        {
            byte[] imageBytes = Convert.FromBase64String(str);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image i = Image.FromStream(ms, true);
            return i;
        }
        public static TextureBrush TiledTextureFromCode(string str)
        {
            return new TextureBrush(Draw.ImageFromCode(ref str), WrapMode.Tile);
        }
    }

    public class RedemptionForm : ContainerControl
    {
        #region " Control Help - Movement & Flicker Control "
        private Color TransparentColor = Color.Fuchsia;
        private Point MouseP = new Point(0, 0);
        private bool Cap = false;
        private int MoveHeight;
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
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Cap)
            {
                Parent.Location = new Point(MousePosition.X - MouseP.X, MousePosition.Y - MouseP.Y);
            }
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cap = false;
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.ParentForm.FormBorderStyle = FormBorderStyle.None;
        }
        protected override void CreateHandle()
        {
            base.CreateHandle();
            ParentForm.FindForm().TransparencyKey = TransparentColor;
        }

        private bool _BackgroundNoise = true;
        public bool BackgroundNoise
        {
            get { return _BackgroundNoise; }
            set
            {
                _BackgroundNoise = value;
                Invalidate();
            }
        }


        #endregion

        public RedemptionForm() : base()
        {
            Dock = DockStyle.Fill;
            MoveHeight = 29;
            Font = new Font("Verdana", 8.25f);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
            base.OnPaint(e);
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.TextRenderingHint = TextRenderingHint.AntiAlias;

            //G.FillRectangle(MatteNoise, ClientRectangle)
            G.FillRectangle(new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(0, 0, Width - 1, 28));
            G.FillRectangle(new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(0, 28, 6, Height - 35));
            G.FillRectangle(new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(Width - 7, 28, 7, Height - 35));
            G.FillRectangle(new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(0, Height - 7, Width - 1, 7));
            G.FillRectangle(new SolidBrush(Color.FromArgb(15, Color.White)), new Rectangle(6, 28, Width - 13, Height - 35));
            G.DrawLine(new Pen(Color.FromArgb(44, 45, 48)), new Point(6, 29), new Point(Width - 7, 29));
            G.DrawLine(new Pen(Color.FromArgb(37, 38, 40)), new Point(6, 30), new Point(Width - 7, 30));
            G.DrawLine(new Pen(Color.FromArgb(75, 60, 61, 62)), new Point(6, 31), new Point(Width - 7, 31));
            G.DrawLine(new Pen(Color.FromArgb(56, 57, 60)), new Point(5, 31), new Point(5, Height - 7));
            G.DrawLine(new Pen(Color.FromArgb(77, 78, 79)), new Point(6, 31), new Point(6, Height - 7));
            G.DrawLine(new Pen(Color.FromArgb(56, 57, 60)), new Point(Width - 7, 31), new Point(Width - 7, Height - 7));
            G.DrawLine(new Pen(Color.FromArgb(77, 78, 79)), new Point(Width - 8, 31), new Point(Width - 8, Height - 7));
            G.DrawLine(new Pen(Color.FromArgb(63, 64, 65)), new Point(6, Height - 8), new Point(Width - 7, Height - 8));
            G.DrawLine(new Pen(Color.FromArgb(63, 63, 63)), new Point(5, Height - 7), new Point(Width - 6, Height - 7));
            G.DrawLine(new Pen(Color.FromArgb(85, 86, 88)), new Point(0, 1), new Point(Width - 1, 1));
            G.DrawRectangle(new Pen(Color.FromArgb(21, 23, 25)), ClientRectangle);

            Color[] ColorList = {
            Color.FromArgb(200, 34, 36, 39),
            Color.FromArgb(200, 5, 185, 238),
            Color.FromArgb(200, 34, 36, 39)
        };
            float[] PointList = {
            0 / 2,
            1 / 2,
            2 / 2
        };
            LinearGradientBrush AccentBrush = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.Black, Color.White, 90);
            ColorBlend AccentBlend = new ColorBlend
            {
                Colors = ColorList,
                Positions = PointList
            };
            AccentBrush.InterpolationColors = AccentBlend;
            G.DrawRectangle(new Pen(AccentBrush), new Rectangle(0, 0, Width - 1, Height - 1));

            StringFormat TextFormat = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };
            G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(200, Color.Black)), new Rectangle(8, 1, Width - 1, 28), TextFormat);
            G.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(8, 2, Width - 1, 28), TextFormat);


            e.Graphics.DrawImage(B, new Point(0, 0));
            G.Dispose();
            B.Dispose();
        }

    }
        

}

