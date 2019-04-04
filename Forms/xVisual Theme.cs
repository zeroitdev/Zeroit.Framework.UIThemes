// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="xVisual Theme.cs" company="Zeroit Dev Technologies">
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
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using static Zeroit.Framework.Form.UIThemes.XVisual.Draw;

namespace Zeroit.Framework.Form.UIThemes.XVisual
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

    #region Duplicate
    //public class xVisualControlBox : Control
    //{
    //    public xVisualControlBox()
    //    {
    //        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
    //        BackColor = Color.Transparent;
    //        ForeColor = Color.FromArgb(205, 205, 205);
    //        Size = new Size(83, 28);
    //        Location = new Point(12, 12);
    //        DoubleBuffered = true;
    //    }
    //    #region " MouseStates "
    //    MouseState State = MouseState.None;
    //    int X;
    //    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseDown(e);

    //        if (X > 10 & X < 25)
    //        {
    //            Parent.FindForm().Close();
    //        }
    //        else if (X > 33 & X < 48)
    //        {
    //            Parent.FindForm().WindowState = FormWindowState.Minimized;
    //        }
    //        else if (X > 56 & X < 71)
    //        {
    //            if (Parent.FindForm().WindowState == FormWindowState.Normal)
    //            {
    //                Parent.FindForm().WindowState = FormWindowState.Maximized;
    //            }
    //            else
    //            {
    //                Parent.FindForm().WindowState = FormWindowState.Normal;
    //            }
    //        }
    //        State = MouseState.Down;
    //        Invalidate();
    //    }
    //    protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseUp(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseEnter(System.EventArgs e)
    //    {
    //        base.OnMouseEnter(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseLeave(System.EventArgs e)
    //    {
    //        base.OnMouseLeave(e);
    //        State = MouseState.None;
    //        Invalidate();
    //    }
    //    protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseMove(e);
    //        X = e.Location.X;
    //        Invalidate();
    //    }
    //    #endregion
    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);

    //        base.OnPaint(e);

    //        G.Clear(BackColor);

    //        G.SmoothingMode = SmoothingMode.HighQuality;

    //        LinearGradientBrush ControlGradient = new LinearGradientBrush(new Rectangle(10, 2, 15, 16), Color.FromArgb(67, 67, 67), Color.FromArgb(80, 80, 81), 90);
    //        //// Control Box
    //        G.FillEllipse(ControlGradient, new Rectangle(10, 2, 15, 16));
    //        //Main Circle
    //        G.FillEllipse(ControlGradient, new Rectangle(33, 2, 15, 16));
    //        G.FillEllipse(ControlGradient, new Rectangle(56, 2, 15, 16));
    //        G.DrawEllipse(Pens.Black, new Rectangle(10, 2, 15, 16));
    //        G.DrawEllipse(Pens.Black, new Rectangle(33, 2, 15, 16));
    //        G.DrawEllipse(Pens.Black, new Rectangle(56, 2, 15, 16));

    //        LinearGradientBrush ControlTopCircle = new LinearGradientBrush(new Rectangle(13, 4, 9, 7), Color.FromArgb(193, 190, 176), Color.FromArgb(90, 91, 92), 90);
    //        G.FillEllipse(ControlTopCircle, new Rectangle(13, 4, 9, 7));
    //        //Top Circle
    //        G.FillEllipse(ControlTopCircle, new Rectangle(36, 4, 9, 7));
    //        //Top Circle
    //        G.FillEllipse(ControlTopCircle, new Rectangle(59, 4, 9, 7));
    //        //Top Circle

    //        LinearGradientBrush NControlBottomCircle = new LinearGradientBrush(new Rectangle(13, 12, 9, 5), Color.FromArgb(90, 91, 92), Color.FromArgb(155, 165, 174), 90);

    //        switch (State)
    //        {
    //            case MouseState.None:
    //                None:
    //                G.FillEllipse(NControlBottomCircle, new Rectangle(13, 12, 9, 5));
    //                //Bottom Circle
    //                G.FillEllipse(NControlBottomCircle, new Rectangle(36, 12, 9, 5));
    //                G.FillEllipse(NControlBottomCircle, new Rectangle(59, 12, 9, 5));
    //                break;
    //            case MouseState.Over:
    //                if (X > 10 & X < 25)
    //                {
    //                    LinearGradientBrush ControlBottomCircle = new LinearGradientBrush(new Rectangle(13, 12, 9, 5), Color.FromArgb(50, Color.Red), Color.FromArgb(10, Color.Red), 90);
    //                    G.FillEllipse(NControlBottomCircle, new Rectangle(13, 12, 9, 5));
    //                    //Bottom Circle
    //                    G.FillEllipse(ControlBottomCircle, new Rectangle(13, 12, 9, 5));
    //                    //Bottom Circle
    //                    G.FillEllipse(NControlBottomCircle, new Rectangle(36, 12, 9, 5));
    //                    G.FillEllipse(NControlBottomCircle, new Rectangle(59, 12, 9, 5));
    //                }
    //                else if (X > 33 & X < 48)
    //                {
    //                    LinearGradientBrush ControlBottomCircle = new LinearGradientBrush(new Rectangle(13, 12, 9, 5), Color.FromArgb(50, Color.Yellow), Color.FromArgb(10, Color.Yellow), 90);
    //                    G.FillEllipse(NControlBottomCircle, new Rectangle(13, 12, 9, 5));
    //                    //Bottom Circle
    //                    G.FillEllipse(NControlBottomCircle, new Rectangle(36, 12, 9, 5));
    //                    G.FillEllipse(ControlBottomCircle, new Rectangle(36, 12, 9, 5));
    //                    G.FillEllipse(NControlBottomCircle, new Rectangle(59, 12, 9, 5));
    //                }
    //                else if (X > 56 & X < 71)
    //                {
    //                    LinearGradientBrush ControlBottomCircle = new LinearGradientBrush(new Rectangle(13, 12, 9, 5), Color.FromArgb(50, Color.Green), Color.FromArgb(10, Color.Green), 90);
    //                    G.FillEllipse(NControlBottomCircle, new Rectangle(13, 12, 9, 5));
    //                    //Bottom Circle
    //                    G.FillEllipse(NControlBottomCircle, new Rectangle(36, 12, 9, 5));
    //                    G.FillEllipse(NControlBottomCircle, new Rectangle(59, 12, 9, 5));
    //                    G.FillEllipse(ControlBottomCircle, new Rectangle(59, 12, 9, 5));
    //                }
    //                else
    //                {
    //                    goto None;
    //                }
    //                break;
    //            case MouseState.Down:

    //                break;
    //        }


    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();
    //    }
    //}
    //public class xVisualButton : Control
    //{
    //    #region " MouseStates "
    //    MouseState State = MouseState.None;
    //    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseDown(e);
    //        State = MouseState.Down;
    //        Invalidate();
    //    }
    //    protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseUp(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseEnter(System.EventArgs e)
    //    {
    //        base.OnMouseEnter(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseLeave(System.EventArgs e)
    //    {
    //        base.OnMouseLeave(e);
    //        State = MouseState.None;
    //        Invalidate();
    //    }
    //    #endregion

    //    public enum InnerShade
    //    {
    //        Light,
    //        Dark
    //    }
    //    private InnerShade _Shade;
    //    public InnerShade Shade
    //    {
    //        get { return _Shade; }
    //        set
    //        {
    //            _Shade = value;
    //            Invalidate();
    //        }
    //    }

    //    public xVisualButton()
    //    {
    //        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
    //        BackColor = Color.Transparent;
    //        ForeColor = Color.FromArgb(205, 205, 205);
    //        _Shade = InnerShade.Dark;
    //        DoubleBuffered = true;
    //    }
    //    TextureBrush InnerTexture = Draw.NoiseBrush(new Color[]{
    //    Color.FromArgb(52, 48, 44),
    //    Color.FromArgb(54, 50, 46),
    //    Color.FromArgb(50, 46, 42)
    //});
    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);
    //        Rectangle ClientRectangle = new Rectangle(3, 3, Width - 7, Height - 7);

    //        base.OnPaint(e);

    //        G.Clear(BackColor);

    //        G.SmoothingMode = SmoothingMode.HighQuality;

    //        switch (_Shade)
    //        {
    //            case InnerShade.Dark:

    //                G.FillPath(InnerTexture, Draw.CreateRound(ClientRectangle, 3));

    //                G.DrawPath(Draw.GetPen(Color.FromArgb(40, 38, 36)), Draw.CreateRound(new Rectangle(3, 3, Width - 6, Height - 6), 3));
    //                G.DrawPath(Draw.GetPen(Color.FromArgb(45, 43, 41)), Draw.CreateRound(new Rectangle(3, 3, Width - 6, Height - 5), 3));
    //                G.DrawPath(Draw.GetPen(Color.FromArgb(50, 48, 46)), Draw.CreateRound(new Rectangle(2, 2, Width - 5, Height - 3), 3));

    //                LinearGradientBrush HighlightGradient = new LinearGradientBrush(new Rectangle(4, 4, Width - 8, Height - 8), Color.FromArgb(160, 158, 157), Color.FromArgb(61, 57, 54), 90);
    //                Pen hp = new Pen(HighlightGradient);
    //                G.DrawPath(hp, Draw.CreateRound(new Rectangle(4, 4, Width - 9, Height - 9), 3));

    //                LinearGradientBrush OutlineGradient = new LinearGradientBrush(new Rectangle(3, 3, Width - 7, Height - 6), Color.FromArgb(34, 32, 30), Color.Black, 90);
    //                Pen op = new Pen(OutlineGradient);
    //                G.DrawPath(op, Draw.CreateRound(new Rectangle(3, 3, Width - 7, Height - 7), 3));

    //                Font drawFont = new Font("Arial", 9, FontStyle.Bold);
    //                switch (State)
    //                {
    //                    case MouseState.None:
    //                        G.DrawString(Text, drawFont, Brushes.White, new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
    //                        {
    //                            Alignment = StringAlignment.Center,
    //                            LineAlignment = StringAlignment.Center
    //                        });
    //                        break;
    //                    case MouseState.Over:
    //                        G.DrawString(Text, drawFont, Brushes.White, new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
    //                        {
    //                            Alignment = StringAlignment.Center,
    //                            LineAlignment = StringAlignment.Center
    //                        });
    //                        break;
    //                    case MouseState.Down:
    //                        G.DrawString(Text, drawFont, Brushes.White, new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
    //                        {
    //                            Alignment = StringAlignment.Center,
    //                            LineAlignment = StringAlignment.Center
    //                        });
    //                        break;
    //                }

    //                break;
    //            case InnerShade.Light:

    //                LinearGradientBrush MainGradient = new LinearGradientBrush(ClientRectangle, Color.FromArgb(225, 227, 230), Color.FromArgb(199, 201, 204), 90);
    //                G.FillPath(MainGradient, Draw.CreateRound(ClientRectangle, 3));

    //                G.DrawPath(Draw.GetPen(Color.FromArgb(167, 168, 171)), Draw.CreateRound(new Rectangle(3, 3, Width - 6, Height - 6), 3));
    //                G.DrawPath(Draw.GetPen(Color.FromArgb(203, 205, 208)), Draw.CreateRound(new Rectangle(2, 2, Width - 5, Height - 4), 3));

    //                LinearGradientBrush HighlightGradient1 = new LinearGradientBrush(new Rectangle(4, 4, Width - 8, Height - 8), Color.FromArgb(255, 255, 255), Color.FromArgb(218, 219, 222), 90);
    //                Pen hp1 = new Pen(HighlightGradient1);
    //                G.DrawPath(hp1, Draw.CreateRound(new Rectangle(4, 4, Width - 9, Height - 9), 3));

    //                LinearGradientBrush OutlineGradient1 = new LinearGradientBrush(new Rectangle(3, 3, Width - 7, Height - 6), Color.FromArgb(173, 174, 177), Color.FromArgb(110, 111, 114), 90);
    //                Pen op1 = new Pen(OutlineGradient1);
    //                G.DrawPath(op1, Draw.CreateRound(new Rectangle(3, 3, Width - 7, Height - 7), 3));

    //                Font drawFont1 = new Font("Arial", 9, FontStyle.Bold);
    //                switch (State)
    //                {
    //                    case MouseState.None:
    //                        G.DrawString(Text, drawFont1, Draw.GetBrush(Color.FromArgb(109, 109, 110)), new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
    //                        {
    //                            Alignment = StringAlignment.Center,
    //                            LineAlignment = StringAlignment.Center
    //                        });
    //                        break;
    //                    case MouseState.Over:
    //                        G.DrawString(Text, drawFont1, Draw.GetBrush(Color.FromArgb(109, 109, 110)), new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
    //                        {
    //                            Alignment = StringAlignment.Center,
    //                            LineAlignment = StringAlignment.Center
    //                        });
    //                        break;
    //                    case MouseState.Down:
    //                        G.DrawString(Text, drawFont1, Draw.GetBrush(Color.FromArgb(109, 109, 110)), new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
    //                        {
    //                            Alignment = StringAlignment.Center,
    //                            LineAlignment = StringAlignment.Center
    //                        });
    //                        break;
    //                }

    //                break;
    //        }


    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();
    //    }
    //}
    //public class xVisualGroupBox : ContainerControl
    //{

    //    public enum InnerShade
    //    {
    //        Light,
    //        Dark
    //    }
    //    private InnerShade _Shade;
    //    public InnerShade Shade
    //    {
    //        get { return _Shade; }
    //        set
    //        {
    //            _Shade = value;
    //            Invalidate();
    //        }
    //    }

    //    public xVisualGroupBox()
    //    {
    //        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
    //        BackColor = Color.Transparent;
    //        ForeColor = Color.FromArgb(205, 205, 205);
    //        Size = new Size(174, 115);
    //        _Shade = InnerShade.Light;
    //        DoubleBuffered = true;
    //    }
    //    TextureBrush TopTexture = Draw.NoiseBrush(new Color[]{
    //    Color.FromArgb(49, 45, 41),
    //    Color.FromArgb(51, 47, 43),
    //    Color.FromArgb(47, 43, 39)
    //});
    //    TextureBrush InnerTexture = Draw.NoiseBrush(new Color[]{
    //    Color.FromArgb(55, 52, 48),
    //    Color.FromArgb(57, 50, 50),
    //    Color.FromArgb(53, 50, 46)
    //});
    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);
    //        Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
    //        Rectangle BarRect = new Rectangle(0, 0, Width - 1, 32);
    //        base.OnPaint(e);

    //        G.Clear(BackColor);

    //        G.SmoothingMode = SmoothingMode.HighQuality;

    //        switch (_Shade)
    //        {
    //            case InnerShade.Light:
    //                LinearGradientBrush mainGradient = new LinearGradientBrush(ClientRectangle, Color.FromArgb(228, 230, 232), Color.FromArgb(199, 201, 205), 90);
    //                G.FillRectangle(mainGradient, ClientRectangle);
    //                G.DrawRectangle(Pens.Black, ClientRectangle);
    //                break;
    //            case InnerShade.Dark:
    //                G.FillRectangle(InnerTexture, ClientRectangle);
    //                G.DrawRectangle(Pens.Black, ClientRectangle);
    //                break;
    //        }

    //        LinearGradientBrush TopOverlay = new LinearGradientBrush(ClientRectangle, Color.FromArgb(5, Color.White), Color.FromArgb(10, Color.White), 90);
    //        G.FillRectangle(TopTexture, BarRect);

    //        ColorBlend blend = new ColorBlend();

    //        //Add the Array of Color
    //        Color[] bColors = new Color[] {
    //        Color.FromArgb(20, Color.White),
    //        Color.FromArgb(10, Color.Black),
    //        Color.FromArgb(10, Color.White)
    //    };
    //        blend.Colors = bColors;

    //        //Add the Array Single (0-1) colorpoints to place each Color
    //        float[] bPts = new float[] {
    //        0,
    //        0.9f,
    //        1
    //    };
    //        blend.Positions = bPts;

    //        using (LinearGradientBrush br = new LinearGradientBrush(BarRect, Color.White, Color.Black, LinearGradientMode.Vertical))
    //        {

    //            //Blend the colors into the Brush
    //            br.InterpolationColors = blend;

    //            //Fill the rect with the blend
    //            G.FillRectangle(br, BarRect);

    //        }

    //        G.DrawRectangle(Pens.Black, BarRect);

    //        //// Top Bar Highlights
    //        G.DrawLine(Draw.GetPen(Color.FromArgb(112, 109, 107)), 1, 1, Width - 2, 1);
    //        G.DrawLine(Draw.GetPen(Color.FromArgb(67, 63, 60)), 1, BarRect.Height - 1, Width - 2, BarRect.Height - 1);

    //        switch (_Shade)
    //        {
    //            case InnerShade.Light:
    //                Color[] c = {
    //                Color.FromArgb(153, 153, 153),
    //                Color.FromArgb(173, 174, 177),
    //                Color.FromArgb(200, 201, 204)
    //            };
    //                Draw.InnerGlow(G, new Rectangle(1, 33, Width - 2, Height - 34), c);
    //                break;
    //            case InnerShade.Dark:
    //                Color[] c1 = {
    //                Color.FromArgb(43, 40, 38),
    //                Color.FromArgb(50, 47, 44),
    //                Color.FromArgb(55, 52, 49)
    //            };
    //                Draw.InnerGlow(G, new Rectangle(1, 33, Width - 2, Height - 34), c1);
    //                break;
    //        }

    //        Font drawFont = new Font("Arial", 9, FontStyle.Bold);
    //        G.DrawString(Text, drawFont, Brushes.White, new Rectangle(15, 3, Width - 1, 26), new StringFormat
    //        {
    //            Alignment = StringAlignment.Near,
    //            LineAlignment = StringAlignment.Center
    //        });

    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();
    //    }
    //}
    //public class xVisualHeader : ContainerControl
    //{
    //    protected override void OnResize(EventArgs e)
    //    {
    //        Height = 32;
    //        base.OnResize(e);
    //    }

    //    public xVisualHeader()
    //    {
    //        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
    //        BackColor = Color.Transparent;
    //        ForeColor = Color.FromArgb(205, 205, 205);
    //        Size = new Size(174, 32);
    //        DoubleBuffered = true;
    //    }
    //    TextureBrush TopTexture = Draw.NoiseBrush(new Color[]{
    //    Color.FromArgb(49, 45, 41),
    //    Color.FromArgb(51, 47, 43),
    //    Color.FromArgb(47, 43, 39)
    //});
    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);
    //        Rectangle BarRect = new Rectangle(0, 0, Width - 1, Height - 1);
    //        base.OnPaint(e);

    //        G.Clear(BackColor);

    //        G.SmoothingMode = SmoothingMode.HighQuality;

    //        LinearGradientBrush TopOverlay = new LinearGradientBrush(BarRect, Color.FromArgb(5, Color.White), Color.FromArgb(10, Color.White), 90);
    //        G.FillRectangle(TopTexture, BarRect);

    //        ColorBlend blend = new ColorBlend();

    //        //Add the Array of Color
    //        Color[] bColors = new Color[] {
    //        Color.FromArgb(20, Color.White),
    //        Color.FromArgb(10, Color.Black),
    //        Color.FromArgb(10, Color.White)
    //    };
    //        blend.Colors = bColors;

    //        //Add the Array Single (0-1) colorpoints to place each Color
    //        float[] bPts = new float[] {
    //        0,
    //        0.9f,
    //        1
    //    };
    //        blend.Positions = bPts;

    //        using (LinearGradientBrush br = new LinearGradientBrush(BarRect, Color.White, Color.Black, LinearGradientMode.Vertical))
    //        {

    //            //Blend the colors into the Brush
    //            br.InterpolationColors = blend;

    //            //Fill the rect with the blend
    //            G.FillRectangle(br, BarRect);

    //        }

    //        G.DrawRectangle(Pens.Black, BarRect);

    //        //// Top Bar Highlights
    //        G.DrawLine(Draw.GetPen(Color.FromArgb(112, 109, 107)), 1, 1, Width - 2, 1);
    //        G.DrawLine(Draw.GetPen(Color.FromArgb(67, 63, 60)), 1, BarRect.Height - 1, Width - 2, BarRect.Height - 1);


    //        Font drawFont = new Font("Arial", 9, FontStyle.Bold);
    //        G.DrawString(Text, drawFont, Brushes.White, new Rectangle(15, 3, Width - 1, 26), new StringFormat
    //        {
    //            Alignment = StringAlignment.Near,
    //            LineAlignment = StringAlignment.Center
    //        });

    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();
    //    }
    //}
    //public class xVisualSeperator : Control
    //{

    //    public enum LineStyle
    //    {
    //        Horizontal,
    //        Vertical
    //    }
    //    private LineStyle _Style;
    //    public LineStyle Style
    //    {
    //        get { return _Style; }
    //        set
    //        {
    //            _Style = value;
    //            Invalidate();
    //        }
    //    }

    //    public xVisualSeperator()
    //    {
    //        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
    //        BackColor = Color.Transparent;
    //        ForeColor = Color.FromArgb(205, 205, 205);
    //        _Style = LineStyle.Horizontal;

    //        Size = new Size(174, 3);

    //        DoubleBuffered = true;
    //    }
    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);
    //        base.OnPaint(e);

    //        Size = Size;
    //        _Style = Style;

    //        G.Clear(BackColor);

    //        G.SmoothingMode = SmoothingMode.HighQuality;

    //        switch (_Style)
    //        {
    //            case LineStyle.Horizontal:
    //                G.DrawLine(Draw.GetPen(Color.Black), 0, 0, Width - 1, Height - 3);
    //                G.DrawLine(Draw.GetPen(Color.FromArgb(99, 97, 94)), 0, 1, Width - 1, Height - 2);
    //                break;
    //            case LineStyle.Vertical:
    //                G.DrawLine(Draw.GetPen(Color.Black), 0, 0, 0, Height - 1);
    //                G.DrawLine(Draw.GetPen(Color.FromArgb(99, 97, 94)), 1, 0, 1, Height - 1);
    //                break;
    //        }

    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();
    //    }
    //}
    //[DefaultEvent("TextChanged")]
    //public class xVisualTextBox : Control
    //{

    //    #region " Variables"

    //    private int W;
    //    private int H;
    //    private MouseState State = MouseState.None;

    //    private TextBox TB;
    //    #endregion

    //    #region " Properties"

    //    #region " TextBox Properties"

    //    private HorizontalAlignment _TextAlign = HorizontalAlignment.Left;
    //    public enum RoundingStyle
    //    {
    //        Normal,
    //        Rounded
    //    }
    //    private RoundingStyle _Style;
    //    [Category("Options")]
    //    public RoundingStyle Style
    //    {
    //        get { return _Style; }
    //        set
    //        {
    //            _Style = value;
    //            if (TB != null)
    //            {
    //                TB.TextAlign = (HorizontalAlignment)value;
    //            }
    //        }
    //    }

    //    [Category("Options")]
    //    public HorizontalAlignment TextAlign
    //    {
    //        get { return _TextAlign; }
    //        set
    //        {
    //            _TextAlign = value;
    //            if (TB != null)
    //            {
    //                TB.TextAlign = value;
    //            }
    //        }
    //    }
    //    private int _MaxLength = 32767;
    //    [Category("Options")]
    //    public int MaxLength
    //    {
    //        get { return _MaxLength; }
    //        set
    //        {
    //            _MaxLength = value;
    //            if (TB != null)
    //            {
    //                TB.MaxLength = value;
    //            }
    //        }
    //    }
    //    private bool _ReadOnly;
    //    [Category("Options")]
    //    public bool ReadOnly
    //    {
    //        get { return _ReadOnly; }
    //        set
    //        {
    //            _ReadOnly = value;
    //            if (TB != null)
    //            {
    //                TB.ReadOnly = value;
    //            }
    //        }
    //    }
    //    private bool _UseSystemPasswordChar;
    //    [Category("Options")]
    //    public bool UseSystemPasswordChar
    //    {
    //        get { return _UseSystemPasswordChar; }
    //        set
    //        {
    //            _UseSystemPasswordChar = value;
    //            if (TB != null)
    //            {
    //                TB.UseSystemPasswordChar = value;
    //            }
    //        }
    //    }
    //    private bool _Multiline;
    //    [Category("Options")]
    //    public bool Multiline
    //    {
    //        get { return _Multiline; }
    //        set
    //        {
    //            _Multiline = value;
    //            if (TB != null)
    //            {
    //                TB.Multiline = value;

    //                if (value)
    //                {
    //                    TB.Height = Height - 11;
    //                }
    //                else
    //                {
    //                    Height = TB.Height + 11;
    //                }

    //            }
    //        }
    //    }
    //    [Category("Options")]
    //    public override string Text
    //    {
    //        get { return base.Text; }
    //        set
    //        {
    //            base.Text = value;
    //            if (TB != null)
    //            {
    //                TB.Text = value;
    //            }
    //        }
    //    }
    //    [Category("Options")]
    //    public override Font Font
    //    {
    //        get { return base.Font; }
    //        set
    //        {
    //            base.Font = value;
    //            if (TB != null)
    //            {
    //                TB.Font = value;
    //                TB.Location = new Point(3, 5);
    //                TB.Width = Width - 6;

    //                if (!_Multiline)
    //                {
    //                    Height = TB.Height + 11;
    //                }
    //            }
    //        }
    //    }

    //    protected override void OnCreateControl()
    //    {
    //        base.OnCreateControl();
    //        if (!Controls.Contains(TB))
    //        {
    //            Controls.Add(TB);
    //        }
    //    }
    //    private void OnBaseTextChanged(object s, EventArgs e)
    //    {
    //        Text = TB.Text;
    //    }
    //    private void OnBaseKeyDown(object s, KeyEventArgs e)
    //    {
    //        if (e.Control && e.KeyCode == Keys.A)
    //        {
    //            TB.SelectAll();
    //            e.SuppressKeyPress = true;
    //        }
    //        if (e.Control && e.KeyCode == Keys.C)
    //        {
    //            TB.Copy();
    //            e.SuppressKeyPress = true;
    //        }
    //    }
    //    protected override void OnResize(EventArgs e)
    //    {
    //        TB.Location = new Point(11, 5);
    //        TB.Width = Width - 14;

    //        if (_Multiline)
    //        {
    //            TB.Height = Height - 11;
    //        }
    //        else
    //        {
    //            Height = TB.Height + 11;
    //        }

    //        base.OnResize(e);
    //    }

    //    #endregion

    //    #region " Mouse States"

    //    protected override void OnMouseDown(MouseEventArgs e)
    //    {
    //        base.OnMouseDown(e);
    //        State = MouseState.Down;
    //        Invalidate();
    //    }
    //    protected override void OnMouseUp(MouseEventArgs e)
    //    {
    //        base.OnMouseUp(e);
    //        State = MouseState.Over;
    //        TB.Focus();
    //        Invalidate();
    //    }
    //    protected override void OnMouseEnter(EventArgs e)
    //    {
    //        base.OnMouseEnter(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseLeave(EventArgs e)
    //    {
    //        base.OnMouseLeave(e);
    //        State = MouseState.None;
    //        Invalidate();
    //    }

    //    #endregion

    //    #endregion

    //    #region " Colors"

    //    private Color _BaseColor = Color.FromArgb(242, 242, 242);

    //    private Color _TextColor = Color.FromArgb(30, 30, 30);
    //    #endregion

    //    public xVisualTextBox()
    //    {
    //        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
    //        DoubleBuffered = true;

    //        BackColor = Color.Transparent;

    //        TB = new TextBox();
    //        TB.Font = new Font("Arial", 8, FontStyle.Bold);
    //        TB.Text = Text;
    //        TB.BackColor = _BaseColor;
    //        TB.ForeColor = _TextColor;
    //        TB.MaxLength = _MaxLength;
    //        TB.Multiline = _Multiline;
    //        TB.ReadOnly = _ReadOnly;
    //        TB.UseSystemPasswordChar = _UseSystemPasswordChar;
    //        TB.BorderStyle = BorderStyle.None;
    //        TB.Location = new Point(11, 5);
    //        TB.Width = Width - 10;
    //        _Style = RoundingStyle.Normal;

    //        TB.Cursor = Cursors.IBeam;

    //        if (_Multiline)
    //        {
    //            TB.Height = Height - 11;
    //        }
    //        else
    //        {
    //            Height = TB.Height + 11;
    //        }

    //        TB.TextChanged += OnBaseTextChanged;
    //        TB.KeyDown += OnBaseKeyDown;
    //    }

    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);
    //        G = Graphics.FromImage(B);

    //        W = Width - 1;
    //        H = Height - 1;

    //        Rectangle Base = new Rectangle(0, 0, W, H);

    //        var _with1 = G;
    //        _with1.SmoothingMode = SmoothingMode.HighQuality;
    //        _with1.Clear(BackColor);

    //        TB.BackColor = _BaseColor;
    //        TB.ForeColor = _TextColor;

    //        switch (_Style)
    //        {
    //            case RoundingStyle.Normal:
    //                _with1.FillPath(new SolidBrush(_BaseColor), Draw.CreateRound(Base, 5));
    //                LinearGradientBrush tg = new LinearGradientBrush(Base, Color.FromArgb(186, 188, 191), Color.FromArgb(204, 205, 209), 90);
    //                _with1.DrawPath(new Pen(tg), Draw.CreateRound(Base, 5));
    //                break;
    //            case RoundingStyle.Rounded:
    //                _with1.DrawPath(new Pen(new SolidBrush(Color.FromArgb(132, 130, 128))), Draw.CreateRound(new Rectangle(Base.X, Base.Y + 1, Base.Width, Base.Height - 1), 20));

    //                _with1.FillPath(new SolidBrush(_BaseColor), Draw.CreateRound(new Rectangle(Base.X, Base.Y, Base.Width, Base.Height - 1), 20));
    //                LinearGradientBrush tg1 = new LinearGradientBrush(new Rectangle(Base.X, Base.Y, Base.Width, Base.Height - 1), Color.Black, Color.FromArgb(31, 28, 24), 90);
    //                _with1.DrawPath(new Pen(tg1), Draw.CreateRound(new Rectangle(Base.X, Base.Y, Base.Width, Base.Height - 1), 20));
    //                break;
    //        }

    //        base.OnPaint(e);
    //        G.Dispose();
    //        e.Graphics.InterpolationMode = (InterpolationMode)7;
    //        e.Graphics.DrawImageUnscaled(B, 0, 0);
    //        B.Dispose();
    //    }

    //}
    //public class xVisualProgressBar : Control
    //{

    //    #region " Control Help - Properties & Flicker Control "
    //    private int OFS = 0;
    //    private int Speed = 50;

    //    private int _Maximum = 100;
    //    public int Maximum
    //    {
    //        get { return _Maximum; }
    //        set
    //        {

    //            if (value == _Value)
    //            {
    //                _Value = value;
    //            }

    //            #region Old Code
    //            //			switch (value) {
    //            //				case  // ERROR: Case labels with binary operators are unsupported : LessThan
    //            //_Value:
    //            //					_Value = value;
    //            //					break;
    //            //			} 
    //            #endregion

    //            _Maximum = value;
    //            Invalidate();
    //        }
    //    }
    //    private int _Value = 0;
    //    public int Value
    //    {
    //        get
    //        {
    //            switch (_Value)
    //            {
    //                case 0:
    //                    return 0;
    //                default:
    //                    return _Value;
    //            }
    //        }
    //        set
    //        {

    //            if (value == _Maximum)
    //            {
    //                value = _Maximum;

    //            }

    //            #region Old Code
    //            //			switch (value) {
    //            //				case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
    //            //_Maximum:
    //            //					value = _Maximum;
    //            //					break;
    //            //			} 
    //            #endregion

    //            _Value = value;
    //            Invalidate();
    //        }
    //    }
    //    private bool _ShowPercentage = false;
    //    public bool ShowPercentage
    //    {
    //        get { return _ShowPercentage; }
    //        set
    //        {
    //            _ShowPercentage = value;
    //            Invalidate();
    //        }
    //    }

    //    protected override void CreateHandle()
    //    {
    //        base.CreateHandle();
    //    }
    //    public void Animate()
    //    {
    //        while (true)
    //        {
    //            if (OFS <= Width)
    //            {
    //                OFS += 1;
    //            }
    //            else
    //            {
    //                OFS = 0;
    //            }
    //            Invalidate();
    //            System.Threading.Thread.Sleep(Speed);
    //        }
    //    }
    //    #endregion

    //    public xVisualProgressBar() : base()
    //    {
    //        DoubleBuffered = true;
    //        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
    //        BackColor = Color.Transparent;
    //        Size = new Size(274, 30);
    //    }

    //    TextureBrush InnerTexture = Draw.NoiseBrush(new Color[]{
    //    Color.FromArgb(55, 52, 48),
    //    Color.FromArgb(57, 50, 50),
    //    Color.FromArgb(53, 50, 46)
    //});
    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);

    //        //G.SmoothingMode = SmoothingMode.HighQuality

    //        int intValue = Convert.ToInt32(_Value / _Maximum * Width);
    //        G.Clear(BackColor);

    //        SolidBrush percentColor = new SolidBrush(Color.White);

    //        G.FillRectangle(InnerTexture, new Rectangle(0, 0, Width - 1, Height - 1));

    //        ColorBlend blend = new ColorBlend();

    //        //Add the Array of Color
    //        Color[] bColors = new Color[] {
    //        Color.FromArgb(20, Color.White),
    //        Color.FromArgb(10, Color.Black),
    //        Color.FromArgb(10, Color.White)
    //    };
    //        blend.Colors = bColors;

    //        //Add the Array Single (0-1) colorpoints to place each Color
    //        float[] bPts = new float[] {
    //        0,
    //        0.8f,
    //        1
    //    };
    //        blend.Positions = bPts;

    //        using (LinearGradientBrush br = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.White, Color.Black, LinearGradientMode.Vertical))
    //        {

    //            //Blend the colors into the Brush
    //            br.InterpolationColors = blend;

    //            //Fill the rect with the blend
    //            G.FillRectangle(br, new Rectangle(0, 0, Width - 1, Height - 1));

    //        }

    //        G.DrawRectangle(Pens.Black, new Rectangle(0, 0, Width - 1, Height - 1));
    //        G.DrawLine(Draw.GetPen(Color.FromArgb(99, 97, 94)), 1, 1, Width - 3, 1);
    //        G.DrawLine(Draw.GetPen(Color.FromArgb(64, 60, 57)), 1, Height - 2, Width - 3, Height - 2);

    //        ////// Bar Fill
    //        if (!(intValue == 0))
    //        {
    //            G.FillRectangle(new LinearGradientBrush(new Rectangle(2, 2, intValue - 3, Height - 4), Color.FromArgb(114, 203, 232), Color.FromArgb(58, 118, 188), 90), new Rectangle(2, 2, intValue - 3, Height - 4));
    //            G.DrawLine(Draw.GetPen(Color.FromArgb(235, 255, 255)), 2, 2, intValue - 2, 2);
    //            //G.DrawLine(GetPen(Color.FromArgb(27, 25, 23)), 2, Height - 2, intValue + 1, Height - 2)
    //            percentColor = new SolidBrush(Color.White);
    //        }

    //        if (_ShowPercentage)
    //        {
    //            G.DrawString(Convert.ToString(string.Concat(Value, "%")), new Font("Arial", 10, FontStyle.Bold), Draw.GetBrush(Color.FromArgb(20, 20, 20)), new Rectangle(1, 2, Width - 1, Height - 1), new StringFormat
    //            {
    //                Alignment = StringAlignment.Center,
    //                LineAlignment = StringAlignment.Center
    //            });
    //            G.DrawString(Convert.ToString(string.Concat(Value, "%")), new Font("Arial", 10, FontStyle.Bold), percentColor, new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
    //            {
    //                Alignment = StringAlignment.Center,
    //                LineAlignment = StringAlignment.Center
    //            });
    //        }

    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();
    //    }
    //}
    //[DefaultEvent("CheckedChanged")]
    //public class xVisualRadioButton : Control
    //{

    //    #region " Control Help - MouseState & Flicker Control"
    //    private Rectangle R1;

    //    private LinearGradientBrush G1;
    //    private MouseState State = MouseState.None;
    //    protected override void OnMouseEnter(System.EventArgs e)
    //    {
    //        base.OnMouseEnter(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseDown(e);
    //        State = MouseState.Down;
    //        Invalidate();
    //    }
    //    protected override void OnMouseLeave(System.EventArgs e)
    //    {
    //        base.OnMouseLeave(e);
    //        State = MouseState.None;
    //        Invalidate();
    //    }
    //    protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseUp(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnResize(System.EventArgs e)
    //    {
    //        base.OnResize(e);
    //        Height = 21;
    //    }
    //    protected override void OnTextChanged(System.EventArgs e)
    //    {
    //        base.OnTextChanged(e);
    //        Invalidate();
    //    }
    //    private bool _Checked;
    //    public bool Checked
    //    {
    //        get { return _Checked; }
    //        set
    //        {
    //            _Checked = value;
    //            InvalidateControls();
    //            if (CheckedChanged != null)
    //            {
    //                CheckedChanged(this);
    //            }
    //            Invalidate();
    //        }
    //    }
    //    protected override void OnClick(EventArgs e)
    //    {
    //        if (!_Checked)
    //            Checked = true;
    //        base.OnClick(e);
    //    }
    //    public event CheckedChangedEventHandler CheckedChanged;
    //    public delegate void CheckedChangedEventHandler(object sender);
    //    protected override void OnCreateControl()
    //    {
    //        base.OnCreateControl();
    //        InvalidateControls();
    //    }
    //    private void InvalidateControls()
    //    {
    //        if (!IsHandleCreated || !_Checked)
    //            return;

    //        foreach (Control C in Parent.Controls)
    //        {
    //            if (!object.ReferenceEquals(C, this) && C is xVisualRadioButton)
    //            {
    //                ((xVisualRadioButton)C).Checked = false;
    //            }
    //        }
    //    }
    //    #endregion

    //    public xVisualRadioButton() : base()
    //    {
    //        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
    //        BackColor = Color.Transparent;
    //        ForeColor = Color.Black;
    //        Size = new Size(150, 21);
    //        DoubleBuffered = true;
    //    }

    //    TextureBrush InnerTexture = Draw.NoiseBrush(new Color[]{
    //    Color.FromArgb(55, 52, 48),
    //    Color.FromArgb(57, 50, 50),
    //    Color.FromArgb(53, 50, 46)
    //});
    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);
    //        Rectangle radioBtnRectangle = new Rectangle(0, 0, Height - 1, Height - 1);

    //        G.SmoothingMode = SmoothingMode.HighQuality;
    //        G.CompositingQuality = CompositingQuality.HighQuality;
    //        G.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

    //        G.Clear(BackColor);

    //        G.FillRectangle(InnerTexture, radioBtnRectangle);
    //        G.DrawRectangle(new Pen(Color.Black), radioBtnRectangle);
    //        G.DrawRectangle(new Pen(Color.FromArgb(99, 97, 94)), new Rectangle(1, 1, Height - 3, Height - 3));

    //        if (Checked)
    //        {
    //            G.DrawString("a", new Font("Marlett", 12, FontStyle.Regular), Brushes.White, new Point(1, 2));
    //        }

    //        Font drawFont = new Font("Arial", 10, FontStyle.Bold);
    //        Brush nb = new SolidBrush(Color.FromArgb(250, 250, 250));
    //        G.DrawString(Text, drawFont, nb, new Point(25, 10), new StringFormat
    //        {
    //            Alignment = StringAlignment.Near,
    //            LineAlignment = StringAlignment.Center
    //        });

    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();
    //    }

    //}
    //public class xVisualComboBox : ComboBox
    //{
    //    #region " Control Help - Properties & Flicker Control "
    //    private int _StartIndex = 0;
    //    public int StartIndex
    //    {
    //        get { return _StartIndex; }
    //        set
    //        {
    //            _StartIndex = value;
    //            try
    //            {
    //                base.SelectedIndex = value;
    //            }
    //            catch
    //            {
    //            }
    //            Invalidate();
    //        }
    //    }
    //    public override System.Drawing.Rectangle DisplayRectangle
    //    {
    //        get { return base.DisplayRectangle; }
    //    }
    //    public void ReplaceItem(System.Object sender, System.Windows.Forms.DrawItemEventArgs e)
    //    {
    //        e.DrawBackground();
    //        try
    //        {
    //            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
    //            {
    //                e.Graphics.FillRectangle(new SolidBrush(_highlightColor), e.Bounds);
    //                LinearGradientBrush gloss = new LinearGradientBrush(e.Bounds, Color.FromArgb(20, Color.White), Color.FromArgb(0, Color.White), 90);
    //                //Highlight Gloss/Color
    //                e.Graphics.FillRectangle(gloss, new Rectangle(new Point(e.Bounds.X, e.Bounds.Y), new Size(e.Bounds.Width, e.Bounds.Height)));
    //                //Drop Background
    //                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(90, Color.Black)) { DashStyle = DashStyle.Solid }, new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));
    //            }
    //            else
    //            {
    //                e.Graphics.FillRectangle(InnerTexture, e.Bounds);
    //            }
    //            using (SolidBrush b = new SolidBrush(Color.FromArgb(230, 230, 230)))
    //            {
    //                e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), e.Font, b, new Rectangle(e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width - 4, e.Bounds.Height));
    //            }
    //        }
    //        catch
    //        {
    //        }
    //        e.DrawFocusRectangle();
    //    }
    //    protected void DrawTriangle(Color Clr, Point FirstPoint, Point SecondPoint, Point ThirdPoint, Graphics G)
    //    {
    //        List<Point> points = new List<Point>();
    //        points.Add(FirstPoint);
    //        points.Add(SecondPoint);
    //        points.Add(ThirdPoint);
    //        G.FillPolygon(new SolidBrush(Clr), points.ToArray());
    //        G.DrawPolygon(new Pen(new SolidBrush(Color.Black)), points.ToArray());
    //    }
    //    private Color _highlightColor = Color.FromArgb(99, 97, 94);
    //    public Color ItemHighlightColor
    //    {
    //        get { return _highlightColor; }
    //        set
    //        {
    //            _highlightColor = value;
    //            Invalidate();
    //        }
    //    }
    //    #endregion

    //    public xVisualComboBox() : base()
    //    {
    //        DrawItem += ReplaceItem;
    //        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
    //        DrawMode = DrawMode.OwnerDrawFixed;
    //        BackColor = Color.Transparent;
    //        ForeColor = Color.Silver;
    //        Font = new Font("Arial", 9, FontStyle.Bold);
    //        DropDownStyle = ComboBoxStyle.DropDownList;
    //        DoubleBuffered = true;
    //        Size = new Size(Width + 1, 21);
    //        ItemHeight = 16;
    //    }

    //    TextureBrush InnerTexture = Draw.NoiseBrush(new Color[]{
    //    Color.FromArgb(55, 52, 48),
    //    Color.FromArgb(57, 50, 50),
    //    Color.FromArgb(53, 50, 46)
    //});
    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);
    //        G.SmoothingMode = SmoothingMode.HighQuality;


    //        G.Clear(BackColor);
    //        G.FillRectangle(InnerTexture, new Rectangle(0, 0, Width, Height - 1));
    //        G.DrawLine(new Pen(Color.FromArgb(99, 97, 94)), 1, 1, Width - 2, 1);
    //        G.DrawRectangle(new Pen(Color.FromArgb(99, 97, 94)), new Rectangle(1, 1, Width - 3, Height - 3));

    //        DrawTriangle(Color.FromArgb(99, 97, 94), new Point(Width - 14, 9), new Point(Width - 6, 9), new Point(Width - 10, 14), G);
    //        //Triangle Fill Color
    //        G.DrawRectangle(Pens.Black, new Rectangle(0, 0, Width - 1, Height - 1));

    //        //Draw Separator line
    //        G.DrawLine(new Pen(Color.FromArgb(99, 97, 94)), new Point(Width - 21, 1), new Point(Width - 21, Height - 3));
    //        G.DrawLine(new Pen(Color.Black), new Point(Width - 20, 2), new Point(Width - 20, Height - 3));
    //        G.DrawLine(new Pen(Color.FromArgb(99, 97, 94)), new Point(Width - 19, 1), new Point(Width - 19, Height - 3));

    //        ColorBlend blend = new ColorBlend();

    //        //Add the Array of Color
    //        Color[] bColors = new Color[] {
    //        Color.FromArgb(15, Color.White),
    //        Color.FromArgb(10, Color.Black),
    //        Color.FromArgb(10, Color.White)
    //    };
    //        blend.Colors = bColors;

    //        //Add the Array Single (0-1) colorpoints to place each Color
    //        float[] bPts = new float[] {
    //        0,
    //        0.75f,
    //        1
    //    };
    //        blend.Positions = bPts;

    //        using (LinearGradientBrush br = new LinearGradientBrush(new Rectangle(0, 0, Width, Height - 1), Color.White, Color.Black, LinearGradientMode.Vertical))
    //        {

    //            //Blend the colors into the Brush
    //            br.InterpolationColors = blend;

    //            //Fill the rect with the blend
    //            G.FillRectangle(br, new Rectangle(0, 0, Width, Height - 1));

    //        }
    //        try
    //        {
    //            G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(250, 250, 250)), new Rectangle(5, 0, Width - 20, Height), new StringFormat
    //            {
    //                LineAlignment = StringAlignment.Center,
    //                Alignment = StringAlignment.Near
    //            });
    //        }
    //        catch
    //        {
    //        }

    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();
    //    }
    //}
    //public class xVisualTabControl : TabControl
    //{

    //    protected override void OnResize(System.EventArgs e)
    //    {
    //        base.OnResize(e);
    //    }

    //    public xVisualTabControl()
    //    {
    //        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
    //        DoubleBuffered = true;
    //        SizeMode = TabSizeMode.Fixed;
    //        ItemSize = new Size(35, 122);
    //    }
    //    protected override void CreateHandle()
    //    {
    //        base.CreateHandle();
    //        Alignment = TabAlignment.Left;
    //    }

    //    public Pen ToPen(Color color)
    //    {
    //        return new Pen(color);
    //    }

    //    public Brush ToBrush(Color color)
    //    {
    //        return new SolidBrush(color);
    //    }
    //    TextureBrush InnerTexture = Draw.NoiseBrush(new Color[]{
    //    Color.FromArgb(45, 41, 37),
    //    Color.FromArgb(47, 43, 39),
    //    Color.FromArgb(43, 39, 35)
    //});
    //    TextureBrush TabBGTexture = Draw.NoiseBrush(new Color[]{
    //    Color.FromArgb(55, 51, 48),
    //    Color.FromArgb(57, 53, 50),
    //    Color.FromArgb(53, 49, 46)

    //});
    //    protected override void OnPaint(PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);
    //        Font FF = new Font("Arial", 9, FontStyle.Bold);

    //        try
    //        {
    //            SelectedTab.BackColor = Color.FromArgb(56, 52, 49);
    //        }
    //        catch
    //        {
    //        }
    //        G.Clear(Parent.FindForm().BackColor);

    //        G.FillRectangle(TabBGTexture, new Rectangle(0, 0, ItemSize.Height + 3, Height - 1));
    //        //Full Tab Background
    //        G.DrawLine(Draw.GetPen(Color.FromArgb(44, 42, 39)), 1, Height - 3, ItemSize.Height + 3, Height - 3);
    //        G.DrawLine(Draw.GetPen(Color.FromArgb(48, 45, 43)), 1, Height - 4, ItemSize.Height + 3, Height - 4);
    //        G.DrawLine(Draw.GetPen(Color.FromArgb(53, 50, 47)), 1, Height - 5, ItemSize.Height + 3, Height - 5);

    //        int y = GetTabRect(0).Height * 2;
    //        while (!(y >= Height - 1))
    //        {
    //            G.DrawLine(Pens.Black, 1, y, Width - 2, y);
    //            G.DrawLine(Draw.GetPen(Color.FromArgb(99, 97, 94)), 1, y + 1, Width - 2, y + 1);
    //            y = y + GetTabRect(0).Height;
    //        }

    //        for (int i = 0; i <= TabCount - 1; i++)
    //        {
    //            if (i == SelectedIndex)
    //            {
    //                Rectangle x2 = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2), new Size(GetTabRect(i).Width + 3, GetTabRect(i).Height - 1));

    //                if (SelectedIndex == 0)
    //                {
    //                    Rectangle tabRect = new Rectangle(GetTabRect(i).Location.X, GetTabRect(i).Location.Y - 1, GetTabRect(i).Size.Width - 1, GetTabRect(i).Size.Height - 1);
    //                    LinearGradientBrush TabOverlay = new LinearGradientBrush(tabRect, Color.FromArgb(114, 203, 232), Color.FromArgb(58, 118, 188), 90);
    //                    G.FillRectangle(TabOverlay, tabRect);

    //                    G.DrawLine(Draw.GetPen(Color.FromArgb(235, 255, 255)), GetTabRect(i).Location.X, GetTabRect(i).Location.Y - 1, GetTabRect(i).Size.Width, GetTabRect(i).Location.Y - 1);
    //                }
    //                else
    //                {
    //                    Rectangle tabRect = new Rectangle(GetTabRect(i).Location.X, GetTabRect(i).Location.Y - 2, GetTabRect(i).Size.Width - 1, GetTabRect(i).Size.Height);
    //                    LinearGradientBrush TabOverlay = new LinearGradientBrush(tabRect, Color.FromArgb(114, 203, 232), Color.FromArgb(58, 118, 188), 90);
    //                    G.FillRectangle(TabOverlay, tabRect);

    //                    G.DrawLine(Draw.GetPen(Color.FromArgb(235, 255, 255)), GetTabRect(i).Location.X, GetTabRect(i).Location.Y - 2, GetTabRect(i).Size.Width, GetTabRect(i).Location.Y - 2);
    //                }

    //                G.DrawLine(Pens.Black, GetTabRect(i).Location.X, GetTabRect(i).Location.Y + 33, GetTabRect(i).Size.Width, GetTabRect(i).Location.Y + 33);

    //                G.SmoothingMode = SmoothingMode.HighQuality;

    //                G.DrawString(TabPages[i].Text, FF, Draw.GetBrush(Color.FromArgb(20, 20, 20)), new Rectangle(x2.X, x2.Y - 1, x2.Width + 1, x2.Height + 2), new StringFormat
    //                {
    //                    LineAlignment = StringAlignment.Center,
    //                    Alignment = StringAlignment.Center
    //                });
    //                G.DrawString(TabPages[i].Text, FF, Brushes.White, new Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), new StringFormat
    //                {
    //                    LineAlignment = StringAlignment.Center,
    //                    Alignment = StringAlignment.Center
    //                });

    //                G.DrawLine(new Pen(Color.FromArgb(96, 110, 121)), new Point(x2.Location.X - 1, x2.Location.Y - 1), new Point(x2.Location.X, x2.Location.Y));
    //                G.DrawLine(new Pen(Color.FromArgb(96, 110, 121)), new Point(x2.Location.X - 1, x2.Bottom - 1), new Point(x2.Location.X, x2.Bottom));
    //            }
    //            else
    //            {
    //                Rectangle x2 = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2), new Size(GetTabRect(i).Width + 3, GetTabRect(i).Height - 1));
    //                Rectangle tabRect = new Rectangle(GetTabRect(i).Location.X, GetTabRect(i).Location.Y - 2, GetTabRect(i).Size.Width - 1, GetTabRect(i).Size.Height - 1);

    //                G.FillRectangle(InnerTexture, tabRect);
    //                //Highlight Fill Background
    //                LinearGradientBrush TabOverlay = new LinearGradientBrush(tabRect, Color.FromArgb(15, Color.White), Color.FromArgb(100, Color.FromArgb(43, 40, 38)), 90);
    //                G.FillRectangle(TabOverlay, tabRect);

    //                G.DrawLine(Draw.GetPen(Color.FromArgb(113, 110, 108)), GetTabRect(i).Location.X, GetTabRect(i).Location.Y - 1, GetTabRect(i).Size.Width, GetTabRect(i).Location.Y - 1);
    //                G.DrawLine(Pens.Black, GetTabRect(i).Location.X, GetTabRect(i).Location.Y + 32, GetTabRect(i).Size.Width, GetTabRect(i).Location.Y + 32);

    //                if (i == TabCount - 1)
    //                {
    //                    G.DrawLine(Draw.GetPen(Color.FromArgb(64, 60, 57)), GetTabRect(i).Location.X, GetTabRect(i).Location.Y + 31, GetTabRect(i).Size.Width, GetTabRect(i).Location.Y + 31);
    //                    G.DrawLine(Draw.GetPen(Color.FromArgb(35, 33, 31)), GetTabRect(i).Location.X, GetTabRect(i).Location.Y + 33, GetTabRect(i).Size.Width, GetTabRect(i).Location.Y + 33);
    //                    G.DrawLine(Draw.GetPen(Color.FromArgb(43, 41, 38)), GetTabRect(i).Location.X, GetTabRect(i).Location.Y + 34, GetTabRect(i).Size.Width, GetTabRect(i).Location.Y + 34);
    //                    G.DrawLine(Draw.GetPen(Color.FromArgb(53, 50, 47)), GetTabRect(i).Location.X, GetTabRect(i).Location.Y + 35, GetTabRect(i).Size.Width, GetTabRect(i).Location.Y + 35);
    //                    G.DrawLine(Draw.GetPen(Color.FromArgb(58, 55, 51)), GetTabRect(i).Location.X, GetTabRect(i).Location.Y + 36, GetTabRect(i).Size.Width, GetTabRect(i).Location.Y + 36);
    //                }

    //                G.DrawString(TabPages[i].Text, FF, new SolidBrush(Color.FromArgb(210, 220, 230)), new Rectangle(x2.X, x2.Y - 1, x2.Width, x2.Height), new StringFormat
    //                {
    //                    LineAlignment = StringAlignment.Center,
    //                    Alignment = StringAlignment.Center
    //                });
    //            }
    //            G.FillRectangle(new SolidBrush(Color.FromArgb(56, 52, 49)), new Rectangle(123, -1, Width - 123, Height + 1));
    //            //Page Fill Full

    //            G.DrawRectangle(Pens.Black, new Rectangle(123, 0, Width - 124, Height - 2));
    //            Color[] c = {
    //            Color.FromArgb(43, 40, 38),
    //            Color.FromArgb(50, 47, 44),
    //            Color.FromArgb(55, 52, 49)
    //        };
    //            Draw.InnerGlow(G, new Rectangle(124, 1, Width - 125, Height - 3), c);
    //        }

    //        G.DrawLine(Draw.GetPen(Color.FromArgb(56, 52, 49)), -1, Height - 1, ItemSize.Height + 1, Height - 1);
    //        G.DrawLine(Draw.GetPen(Color.FromArgb(56, 52, 49)), 0, -1, 0, Height - 1);
    //        G.DrawRectangle(new Pen(new SolidBrush(Color.Black)), new Rectangle(1, 0, ItemSize.Height, Height - 2));
    //        //Full Tab Inner Outline

    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();
    //    }
    //}
    //[DefaultEvent("CheckedChanged")]
    //public class xVisualCheckBox : Control
    //{

    //    #region " Control Help - MouseState & Flicker Control"
    //    private MouseState State = MouseState.None;
    //    protected override void OnMouseEnter(System.EventArgs e)
    //    {
    //        base.OnMouseEnter(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseDown(e);
    //        State = MouseState.Down;
    //        Invalidate();
    //    }
    //    protected override void OnMouseLeave(System.EventArgs e)
    //    {
    //        base.OnMouseLeave(e);
    //        State = MouseState.None;
    //        Invalidate();
    //    }
    //    protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
    //    {
    //        base.OnMouseUp(e);
    //        State = MouseState.Over;
    //        Invalidate();
    //    }
    //    protected override void OnTextChanged(System.EventArgs e)
    //    {
    //        base.OnTextChanged(e);
    //        Invalidate();
    //    }
    //    private bool _Checked;
    //    public bool Checked
    //    {
    //        get { return _Checked; }
    //        set
    //        {
    //            _Checked = value;
    //            Invalidate();
    //        }
    //    }
    //    protected override void OnResize(System.EventArgs e)
    //    {
    //        base.OnResize(e);
    //        Height = 21;
    //    }
    //    protected override void OnClick(System.EventArgs e)
    //    {
    //        _Checked = !_Checked;
    //        if (CheckedChanged != null)
    //        {
    //            CheckedChanged(this);
    //        }
    //        base.OnClick(e);
    //    }
    //    public event CheckedChangedEventHandler CheckedChanged;
    //    public delegate void CheckedChangedEventHandler(object sender);
    //    #endregion


    //    public xVisualCheckBox() : base()
    //    {
    //        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);
    //        BackColor = Color.Transparent;
    //        ForeColor = Color.Black;
    //        Size = new Size(250, 21);
    //        DoubleBuffered = true;
    //    }

    //    TextureBrush InnerTexture = Draw.NoiseBrush(new Color[]{
    //    Color.FromArgb(55, 52, 48),
    //    Color.FromArgb(57, 50, 50),
    //    Color.FromArgb(53, 50, 46)
    //});
    //    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    //    {
    //        Bitmap B = new Bitmap(Width, Height);
    //        Graphics G = Graphics.FromImage(B);
    //        Rectangle radioBtnRectangle = new Rectangle(0, 0, Height - 1, Height - 1);

    //        G.SmoothingMode = SmoothingMode.HighQuality;
    //        G.CompositingQuality = CompositingQuality.HighQuality;
    //        G.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

    //        G.Clear(BackColor);

    //        G.FillRectangle(InnerTexture, radioBtnRectangle);
    //        G.DrawRectangle(new Pen(Color.Black), radioBtnRectangle);
    //        G.DrawRectangle(new Pen(Color.FromArgb(99, 97, 94)), new Rectangle(1, 1, Height - 3, Height - 3));

    //        if (Checked)
    //        {
    //            G.DrawString("a", new Font("Marlett", 12, FontStyle.Regular), Brushes.White, new Point(1, 2));
    //        }

    //        Font drawFont = new Font("Arial", 10, FontStyle.Bold);
    //        Brush nb = new SolidBrush(Color.FromArgb(250, 250, 250));
    //        G.DrawString(Text, drawFont, nb, new Point(25, 10), new StringFormat
    //        {
    //            Alignment = StringAlignment.Near,
    //            LineAlignment = StringAlignment.Center
    //        });
    //        e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
    //        G.Dispose();
    //        B.Dispose();

    //    }

    //} 
    #endregion

}

