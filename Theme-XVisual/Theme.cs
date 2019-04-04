// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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
using static Zeroit.Framework.UIThemes.XVisual.Draw;

namespace Zeroit.Framework.UIThemes.XVisual
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
        public static SolidBrush GetBrush(Color c)
        {
            return new SolidBrush(c);
        }
        public static Pen GetPen(Color c)
        {
            return new Pen(new SolidBrush(c));
        }
        public static TextureBrush NoiseBrush(Color[] colors)
        {
            Bitmap B = new Bitmap(128, 128);
            Random R = new Random(128);

            //colors = new Color[]
            //{
            //    Color.DarkSlateGray,
            //    Color.Orange,
            //    Color.Blue,
            //    Color.Cyan,
            //    Color.DeepPink,
            //    Color.Gainsboro,
            //    Color.Red,
            //    Color.Yellow

            //};

            for (int X = 0; X <= B.Width - 1; X++)
            {
                for (int Y = 0; Y <= B.Height - 1; Y++)
                {
                    B.SetPixel(X, Y, colors[R.Next(0, colors.Length)]);
                }
            }

            TextureBrush T = new TextureBrush(B);
            B.Dispose();

            return T;
        }
        private static GraphicsPath CreateRoundPath;

        private static Rectangle CreateCreateRoundangle;
        public static GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
        {
            CreateCreateRoundangle = new Rectangle(x, y, width, height);
            return CreateRound(CreateCreateRoundangle, slope);
        }

        public static GraphicsPath CreateRound(Rectangle r, int slope)
        {
            CreateRoundPath = new GraphicsPath(FillMode.Winding);
            CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
            CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270f, 90f);
            CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0f, 90f);
            CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90f, 90f);
            CreateRoundPath.CloseFigure();
            return CreateRoundPath;
        }

        public static void InnerGlow(Graphics G, Rectangle Rectangle, Color[] Colors)
        {
            int SubtractTwo = 1;
            int AddOne = 0;
            foreach (Color c_loopVariable in Colors)
            {
                Color c = c_loopVariable;
                G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(c.R, c.B, c.G))), Rectangle.X + AddOne, Rectangle.Y + AddOne, Rectangle.Width - SubtractTwo, Rectangle.Height - SubtractTwo);
                SubtractTwo += 2;
                AddOne += 1;
            }
        }
        public static void InnerGlowRounded(Graphics G, Rectangle Rectangle, int Degree, Color[] Colors)
        {
            int SubtractTwo = 1;
            int AddOne = 0;
            foreach (Color c_loopVariable in Colors)
            {
                Color c = c_loopVariable;
                G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(c.R, c.B, c.G))), Draw.CreateRound(Rectangle.X + AddOne, Rectangle.Y + AddOne, Rectangle.Width - SubtractTwo, Rectangle.Height - SubtractTwo, Degree));
                SubtractTwo += 2;
                AddOne += 1;
            }
        }
    }

    [ToolboxItem(false)]
    public class xVisualTheme : ContainerControl
    {

        public xVisualTheme()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.FromArgb(46, 43, 40);
            DoubleBuffered = true;
        }

        TextureBrush TopTexture = NoiseBrush(new Color[]{
        Color.FromArgb(66, 64, 62),
        Color.FromArgb(63, 61, 59),
        Color.FromArgb(69, 67, 65)
    });

        TextureBrush InnerTexture = Draw.NoiseBrush(new Color[]{
        Color.FromArgb(57, 53, 50),
        Color.FromArgb(56, 52, 49),
        Color.FromArgb(58, 55, 51)
    });

        Font drawFont = new Font("Arial", 11, FontStyle.Bold);

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);
            G.Clear(Color.Fuchsia);

            Rectangle mainRect = new Rectangle(0, 0, Width, Height);
            LinearGradientBrush LeftHighlight = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(66, 64, 63), Color.FromArgb(56, 54, 53), 90);
            LinearGradientBrush RightHighlight = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(80, 78, 77), Color.FromArgb(70, 68, 67), 90);
            LinearGradientBrush TopOverlay = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, 53), Color.FromArgb(15, Color.White), Color.FromArgb(100, Color.FromArgb(43, 40, 38)), 90);

            LinearGradientBrush mainGradient = new LinearGradientBrush(mainRect, Color.FromArgb(73, 71, 69), Color.FromArgb(69, 67, 64), 90);
            G.FillRectangle(mainGradient, mainRect);
            //Outside Rectangle
            G.DrawRectangle(Pens.Black, new Rectangle(0, 0, Width - 1, Height - 1));

            G.FillRectangle(InnerTexture, new Rectangle(10, 53, Width - 21, Height - 84));
            //Inner Rectangle
            G.DrawRectangle(Pens.Black, new Rectangle(10, 53, Width - 21, Height - 84));

            G.FillRectangle(TopTexture, new Rectangle(0, 0, Width - 1, 53));
            //Top Bar Rectangle
            G.FillRectangle(TopOverlay, new Rectangle(0, 0, Width - 1, 53));
            G.DrawRectangle(Pens.Black, new Rectangle(0, 0, Width - 1, 53));

            ColorBlend blend = new ColorBlend();

            //Add the Array of Color
            Color[] bColors = new Color[] {
            Color.FromArgb(10, Color.White),
            Color.FromArgb(10, Color.Black),
            Color.FromArgb(10, Color.White)
        };
            blend.Colors = bColors;

            //Add the Array Single (0-1) colorpoints to place each Color
            float[] bPts = new float[] {
            0,
            0.7f,
            1
        };
            blend.Positions = bPts;

            Rectangle rect = new Rectangle(0, 0, Width - 1, 53);
            using (LinearGradientBrush br = new LinearGradientBrush(rect, Color.White, Color.Black, LinearGradientMode.Vertical))
            {

                //Blend the colors into the Brush
                br.InterpolationColors = blend;

                //Fill the rect with the blend
                G.FillRectangle(br, rect);

            }

            G.DrawLine(Draw.GetPen(Color.FromArgb(173, 172, 172)), 4, 1, Width - 5, 1);
            //Top Middle Highlight
            G.DrawLine(Draw.GetPen(Color.FromArgb(110, 109, 107)), 11, Height - 30, Width - 12, Height - 30);
            //Bottom Middle Highlight

            G.FillRectangle(Draw.GetBrush(Color.FromArgb(173, 172, 172)), 3, 2, 1, 1);
            //Top Left Corner Highlight
            G.FillRectangle(Draw.GetBrush(Color.FromArgb(133, 132, 132)), 2, 2, 1, 1);
            G.FillRectangle(Draw.GetBrush(Color.FromArgb(113, 112, 112)), 2, 3, 1, 1);
            G.FillRectangle(Draw.GetBrush(Color.FromArgb(83, 82, 82)), 1, 4, 1, 1);

            G.FillRectangle(Draw.GetBrush(Color.FromArgb(173, 172, 172)), Width - 4, 2, 1, 1);
            //Top Right Corner Highlight
            G.FillRectangle(Draw.GetBrush(Color.FromArgb(133, 132, 132)), Width - 3, 2, 1, 1);
            G.FillRectangle(Draw.GetBrush(Color.FromArgb(113, 112, 112)), Width - 3, 3, 1, 1);
            G.FillRectangle(Draw.GetBrush(Color.FromArgb(83, 82, 82)), Width - 2, 4, 1, 1);

            //// Shadows
            G.DrawLine(Draw.GetPen(Color.FromArgb(91, 90, 89)), 1, 52, Width - 2, 52);
            //Middle Top Horizontal
            G.DrawLine(Draw.GetPen(Color.FromArgb(40, 37, 34)), 11, 54, Width - 12, 54);
            G.DrawLine(Draw.GetPen(Color.FromArgb(45, 42, 39)), 11, 55, Width - 12, 55);
            G.DrawLine(Draw.GetPen(Color.FromArgb(50, 47, 44)), 11, 56, Width - 12, 56);

            G.DrawLine(Draw.GetPen(Color.FromArgb(50, 47, 44)), 11, Height - 32, Width - 12, Height - 32);
            //Middle Bottom Horizontal
            G.DrawLine(Draw.GetPen(Color.FromArgb(52, 49, 46)), 11, Height - 33, Width - 12, Height - 33);
            G.DrawLine(Draw.GetPen(Color.FromArgb(54, 51, 48)), 11, Height - 34, Width - 12, Height - 34);


            G.DrawLine(Draw.GetPen(Color.FromArgb(59, 57, 55)), 1, 54, 9, 54);
            //Left Horizontal
            G.DrawLine(Draw.GetPen(Color.FromArgb(64, 62, 60)), 1, 55, 9, 55);
            G.DrawLine(Draw.GetPen(Color.FromArgb(73, 71, 69)), 1, 56, 9, 56);

            G.DrawLine(Draw.GetPen(Color.FromArgb(59, 57, 55)), Width - 10, 54, Width - 2, 54);
            //Right Horizontal
            G.DrawLine(Draw.GetPen(Color.FromArgb(64, 62, 60)), Width - 10, 55, Width - 2, 55);
            G.DrawLine(Draw.GetPen(Color.FromArgb(73, 71, 69)), Width - 10, 56, Width - 2, 56);

            G.DrawLine(Draw.GetPen(Color.FromArgb(59, 57, 55)), 1, 54, 1, Height - 5);
            //Left Vertical
            G.DrawLine(Draw.GetPen(Color.FromArgb(64, 62, 60)), 2, 55, 2, Height - 4);
            G.DrawLine(Draw.GetPen(Color.FromArgb(73, 71, 69)), 3, 56, 3, Height - 3);
            G.DrawLine(new Pen(LeftHighlight), 1, 5, 1, 51);
            G.DrawLine(new Pen(RightHighlight), 2, 5, 2, 51);
            G.DrawLine(Draw.GetPen(Color.FromArgb(69, 67, 65)), 9, 56, 9, Height - 31);

            G.DrawLine(Draw.GetPen(Color.FromArgb(59, 57, 55)), Width - 2, 54, Width - 2, Height - 5);
            //Right Vertical
            G.DrawLine(Draw.GetPen(Color.FromArgb(64, 62, 60)), Width - 3, 55, Width - 3, Height - 4);
            G.DrawLine(Draw.GetPen(Color.FromArgb(73, 71, 69)), Width - 4, 56, Width - 4, Height - 3);
            G.DrawLine(new Pen(LeftHighlight), Width - 2, 5, Width - 2, 51);
            G.DrawLine(new Pen(RightHighlight), Width - 3, 5, Width - 3, 51);
            G.DrawLine(Draw.GetPen(Color.FromArgb(69, 67, 65)), Width - 10, 56, Width - 10, Height - 31);

            G.DrawString(Text, drawFont, new SolidBrush(Color.FromArgb(255, 255, 255)), new Rectangle(0, 0, Width, 37), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });

            //////left upper corner
            G.FillRectangle(Brushes.Fuchsia, 0, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 1, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 2, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 3, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, 2, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, 3, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 1, 1, 1, 1);

            G.FillRectangle(Brushes.Black, 1, 3, 1, 1);
            G.FillRectangle(Brushes.Black, 1, 2, 1, 1);
            G.FillRectangle(Brushes.Black, 2, 1, 1, 1);
            G.FillRectangle(Brushes.Black, 3, 1, 1, 1);
            //'////right upper corner
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 2, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 3, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 4, 0, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 2, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, 3, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 2, 1, 1, 1);

            G.FillRectangle(Brushes.Black, Width - 2, 3, 1, 1);
            G.FillRectangle(Brushes.Black, Width - 2, 2, 1, 1);
            G.FillRectangle(Brushes.Black, Width - 3, 1, 1, 1);
            G.FillRectangle(Brushes.Black, Width - 4, 1, 1, 1);
            //'////left bottom corner
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 2, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 3, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 0, Height - 4, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 1, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 2, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 3, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 1, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, 1, Height - 2, 1, 1);

            G.FillRectangle(Brushes.Black, 1, Height - 3, 1, 1);
            G.FillRectangle(Brushes.Black, 1, Height - 4, 1, 1);
            G.FillRectangle(Brushes.Black, 3, Height - 2, 1, 1);
            G.FillRectangle(Brushes.Black, 2, Height - 2, 1, 1);
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
            G.FillRectangle(Brushes.Fuchsia, Width - 4, Height - 1, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 1, Height - 4, 1, 1);
            G.FillRectangle(Brushes.Fuchsia, Width - 2, Height - 2, 1, 1);

            G.FillRectangle(Brushes.Black, Width - 2, Height - 3, 1, 1);
            G.FillRectangle(Brushes.Black, Width - 2, Height - 4, 1, 1);
            G.FillRectangle(Brushes.Black, Width - 4, Height - 2, 1, 1);
            G.FillRectangle(Brushes.Black, Width - 3, Height - 2, 1, 1);

        }
        private Point MouseP = new Point(0, 0);
        private bool Cap = false;
        private int MoveHeight = 53;
        private int pos = 0;
        MouseState State = MouseState.None;
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left & new Rectangle(0, 0, Width, MoveHeight).Contains(e.Location))
            {
                Cap = true;
                MouseP = e.Location;
            }
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cap = false;
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Cap)
            {
                Parent.Location = new Point(MousePosition.X - MouseP.X, MousePosition.Y - MouseP.Y);
            }
            Invalidate();
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

