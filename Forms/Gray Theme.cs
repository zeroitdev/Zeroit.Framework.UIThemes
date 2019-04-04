// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Gray Theme.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Form.UIThemes.Gray
{
    static class DesignFunctions
    {
        public static Brush ToBrush(int A, int R, int G, int B)
        {
            return ToBrush(Color.FromArgb(A, R, G, B));
        }
        public static Brush ToBrush(int R, int G, int B)
        {
            return ToBrush(Color.FromArgb(R, G, B));
        }
        public static Brush ToBrush(int A, Color C)
        {
            return ToBrush(Color.FromArgb(A, C));
        }
        public static Brush ToBrush(Pen Pen)
        {
            return ToBrush(Pen.Color);
        }
        public static Brush ToBrush(Color Color)
        {
            return new SolidBrush(Color);
        }
        public static Pen ToPen(int A, int R, int G, int B)
        {
            return ToPen(Color.FromArgb(A, R, G, B));
        }
        public static Pen ToPen(int R, int G, int B)
        {
            return ToPen(Color.FromArgb(R, G, B));
        }
        public static Pen ToPen(int A, Color C)
        {
            return ToPen(Color.FromArgb(A, C));
        }
        public static Pen ToPen(Color Color)
        {
            return ToPen(new SolidBrush(Color));
        }
        public static Pen ToPen(SolidBrush Brush)
        {
            return new Pen(Brush);
        }

        public class CornerStyle
        {
            public bool TopLeft;
            public bool TopRight;
            public bool BottomLeft;
            public bool BottomRight;
        }

        public static GraphicsPath AdvRect(Rectangle Rectangle, CornerStyle CornerStyle, int Curve)
        {
            GraphicsPath functionReturnValue = default(GraphicsPath);
            functionReturnValue = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;

            if (CornerStyle.TopLeft)
            {
                functionReturnValue.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            }
            else
            {
                functionReturnValue.AddLine(Rectangle.X, Rectangle.Y, Rectangle.X + ArcRectangleWidth, Rectangle.Y);
            }

            if (CornerStyle.TopRight)
            {
                functionReturnValue.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            }
            else
            {
                functionReturnValue.AddLine(Rectangle.X + Rectangle.Width, Rectangle.Y, Rectangle.X + Rectangle.Width, Rectangle.Y + ArcRectangleWidth);
            }

            if (CornerStyle.BottomRight)
            {
                functionReturnValue.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            }
            else
            {
                functionReturnValue.AddLine(Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height, Rectangle.X + Rectangle.Width - ArcRectangleWidth, Rectangle.Y + Rectangle.Height);
            }

            if (CornerStyle.BottomLeft)
            {
                functionReturnValue.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            }
            else
            {
                functionReturnValue.AddLine(Rectangle.X, Rectangle.Y + Rectangle.Height, Rectangle.X, Rectangle.Y + Rectangle.Height - ArcRectangleWidth);
            }

            functionReturnValue.CloseAllFigures();

            return functionReturnValue;
            return functionReturnValue;
        }

        public static GraphicsPath RoundRect(Rectangle Rectangle, int Curve)
        {
            GraphicsPath functionReturnValue = default(GraphicsPath);
            functionReturnValue = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            functionReturnValue.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            functionReturnValue.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            functionReturnValue.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            functionReturnValue.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            functionReturnValue.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, ArcRectangleWidth + Rectangle.Y));
            functionReturnValue.CloseAllFigures();
            return functionReturnValue;
            return functionReturnValue;
        }

        public static GraphicsPath RoundRect(int X, int Y, int Width, int Height, int Curve)
        {
            return RoundRect(new Rectangle(X, Y, Width, Height), Curve);
        }

        public class PillStyle
        {
            public bool Left;
            public bool Right;
        }

        public static GraphicsPath Pill(Rectangle Rectangle, PillStyle PillStyle)
        {
            GraphicsPath functionReturnValue = default(GraphicsPath);
            functionReturnValue = new GraphicsPath();

            if (PillStyle.Left)
            {
                functionReturnValue.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, Rectangle.Height, Rectangle.Height), -270, 180);
            }
            else
            {
                functionReturnValue.AddLine(Rectangle.X, Rectangle.Y + Rectangle.Height, Rectangle.X, Rectangle.Y);
            }

            if (PillStyle.Right)
            {
                functionReturnValue.AddArc(new Rectangle(Rectangle.X + Rectangle.Width - Rectangle.Height, Rectangle.Y, Rectangle.Height, Rectangle.Height), -90, 180);
            }
            else
            {
                functionReturnValue.AddLine(Rectangle.X + Rectangle.Width, Rectangle.Y, Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height);
            }

            functionReturnValue.CloseAllFigures();

            return functionReturnValue;
            return functionReturnValue;
        }

        public static object Pill(int X, int Y, int Width, int Height, PillStyle PillStyle)
        {
            return Pill(new Rectangle(X, Y, Width, Height), PillStyle);
        }

    }

    

    public class GameBoosterTheme : ThemeContainer154
    {

        public GameBoosterTheme()
        {
            this.BackColor = Color.FromArgb(51, 51, 51);
            TransparencyKey = Color.Fuchsia;

            SetColor("Sides", 232, 232, 232);
            SetColor("Gradient1", 252, 252, 252);
            SetColor("Gradient2", 242, 242, 242);
            SetColor("TextShade", Color.White);
            SetColor("Text", 80, 80, 80);
            SetColor("Back", Color.White);
            SetColor("Border1", Color.Black);
            SetColor("Border2", Color.White);
            SetColor("Border3", Color.White);
            SetColor("Border4", 150, 150, 150);
        }

        private Color C1;
        private Color C2;
        private Color C3;
        private SolidBrush B1;
        private SolidBrush B2;
        private SolidBrush B3;
        private Pen P1;
        private Pen P2;
        private Pen P3;

        private Pen P4;
        protected override void ColorHook()
        {
            C1 = GetColor("Sides");
            C2 = GetColor("Gradient1");
            C3 = GetColor("Gradient2");

            B1 = new SolidBrush(GetColor("TextShade"));
            B2 = new SolidBrush(GetColor("Text"));
            B3 = new SolidBrush(GetColor("Back"));

            P1 = new Pen(Color.FromArgb(24, 24, 24));
            P2 = new Pen(Color.FromArgb(126, 126, 126));

            P3 = new Pen(Color.FromArgb(92, 92, 92));
            P4 = new Pen(Color.FromArgb(24, 24, 24));

            BackColor = B3.Color;
        }


        private Rectangle RT1;
        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(51, 51, 51));

            DrawGradient(C2, C3, 0, 0, Width, 15);

            DrawText(B2, HorizontalAlignment.Left, 12, 0);

            DrawGradient(Color.FromArgb(92, 92, 92), Color.FromArgb(49, 49, 49), 0, 0, Width, 26);
            G.DrawLine(new Pen(P1.Color), new Point(0, 26), new Point(Width, 26));
            G.DrawRectangle(P1, 0, 0, Width - 1, Height - 1);
            G.DrawRectangle(P2, 1, 1, Width - 3, Height - 3);
            DrawPixel(P1.Color, 1, 1);
            DrawPixel(P2.Color, 2, 2);
            DrawPixel(P1.Color, Width - 2, 1);
            DrawPixel(P2.Color, Width - 3, 2);
            DrawPixel(P1.Color, 1, Height - 2);
            DrawPixel(P2.Color, 2, Height - 3);
            DrawPixel(P1.Color, Width - 2, Height - 2);
            DrawPixel(P2.Color, Width - 3, Height - 3);
            DrawText(new SolidBrush(Color.FromArgb(61, 61, 61)), HorizontalAlignment.Center, 0, 1);
            DrawText(new SolidBrush(Color.White), HorizontalAlignment.Center, 0, 2);

        }

    }

    public class GrayContainer : ContainerControl
    {

        public GrayContainer()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;

            G.Clear(Parent.BackColor);

            G.SmoothingMode = SmoothingMode.AntiAlias;

            G.FillPath(DesignFunctions.ToBrush(10, Color.Black), DesignFunctions.RoundRect(0, 0, Width - 1, Height - 2, 5));
            G.DrawPath(DesignFunctions.ToPen(50, Color.White), DesignFunctions.RoundRect(-1, -4, Width + 1, Height + 3, 5));
            G.DrawPath(DesignFunctions.ToPen(50, Color.Black), DesignFunctions.RoundRect(0, 0, Width - 1, Height - 2, 5));

            for (int i = 0; i <= 10; i++)
            {
                G.DrawPath(DesignFunctions.ToPen(50 / (i + 1), Color.Black), DesignFunctions.RoundRect(i, i, Width - 1 - (i * 2), Height - 2 - (i * 2), 5));
            }
        }


    }


    

}


