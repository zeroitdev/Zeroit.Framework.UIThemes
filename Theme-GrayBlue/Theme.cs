// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Theme.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.GrayBlue
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
            GraphicsPath tempAdvRect = null;
            tempAdvRect = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;

            if (CornerStyle.TopLeft)
            {
                tempAdvRect.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180F, 90F);
            }
            else
            {
                tempAdvRect.AddLine(Rectangle.X, Rectangle.Y, Rectangle.X + ArcRectangleWidth, Rectangle.Y);
            }

            if (CornerStyle.TopRight)
            {
                tempAdvRect.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90F, 90F);
            }
            else
            {
                tempAdvRect.AddLine(Rectangle.X + Rectangle.Width, Rectangle.Y, Rectangle.X + Rectangle.Width, Rectangle.Y + ArcRectangleWidth);
            }

            if (CornerStyle.BottomRight)
            {
                tempAdvRect.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0F, 90F);
            }
            else
            {
                tempAdvRect.AddLine(Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height, Rectangle.X + Rectangle.Width - ArcRectangleWidth, Rectangle.Y + Rectangle.Height);
            }

            if (CornerStyle.BottomLeft)
            {
                tempAdvRect.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90F, 90F);
            }
            else
            {
                tempAdvRect.AddLine(Rectangle.X, Rectangle.Y + Rectangle.Height, Rectangle.X, Rectangle.Y + Rectangle.Height - ArcRectangleWidth);
            }

            tempAdvRect.CloseAllFigures();

            return tempAdvRect;
        }

        public static GraphicsPath RoundRect(Rectangle Rectangle, int Curve)
        {
            GraphicsPath tempRoundRect = null;
            tempRoundRect = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            tempRoundRect.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180F, 90F);
            tempRoundRect.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90F, 90F);
            tempRoundRect.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0F, 90F);
            tempRoundRect.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90F, 90F);
            tempRoundRect.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, ArcRectangleWidth + Rectangle.Y));
            tempRoundRect.CloseAllFigures();
            return tempRoundRect;
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
            GraphicsPath tempPill = null;
            tempPill = new GraphicsPath();

            if (PillStyle.Left)
            {
                tempPill.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, Rectangle.Height, Rectangle.Height), -270F, 180F);
            }
            else
            {
                tempPill.AddLine(Rectangle.X, Rectangle.Y + Rectangle.Height, Rectangle.X, Rectangle.Y);
            }

            if (PillStyle.Right)
            {
                tempPill.AddArc(new Rectangle(Rectangle.X + Rectangle.Width - Rectangle.Height, Rectangle.Y, Rectangle.Height, Rectangle.Height), -90F, 180F);
            }
            else
            {
                tempPill.AddLine(Rectangle.X + Rectangle.Width, Rectangle.Y, Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height);
            }

            tempPill.CloseAllFigures();

            return tempPill;
        }

        public static object Pill(int X, int Y, int Width, int Height, PillStyle PillStyle)
        {
            return Pill(new Rectangle(X, Y, Width, Height), PillStyle);
        }

    }

    [ToolboxItem(false)]
    public class GrayForm : ContainerControl
    {
        public GrayForm()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);

            Dock = DockStyle.Fill;
            BackColor = Color.FromArgb(108, 108, 108);
            ForeColor = Color.White;
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            SendToBack();
            Parent.FindForm().TransparencyKey = Color.Fuchsia;
            Parent.FindForm().FormBorderStyle = FormBorderStyle.None;
        }

        private Icon _ico;
        public Icon Icon
        {
            get
            {
                return _ico;
            }
            set
            {
                _ico = value;
                Invalidate();
            }
        }

        #region  Movement and Control Buttons
        private bool Cap = false;
        private Point CapL = new Point();

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if ((new Rectangle(0, 0, Width - 40, 25)).Contains(e.Location))
            {
                Cap = true;
                CapL = e.Location;
            }
            Invalidate();
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cap = false;
            Invalidate();
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Cap)
            {
                Parent.Location = new Point(MousePosition.X - CapL.X, MousePosition.Y - CapL.Y);
            }
            Invalidate();
        }
        protected override void OnClick(System.EventArgs e)
        {
            base.OnClick(e);
            if ((new Rectangle(Width - 20, 5, 10, 10)).Contains(PointToClient(MousePosition)))
            {
                Application.Exit();
            }
        }
        #endregion

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;
            G.Clear(BackColor);

            //Border
            G.DrawRectangle(Pens.DimGray, new Rectangle(1, 1, Width - 3, Height - 3));
            G.DrawPath(Pens.Black, DesignFunctions.RoundRect(0, 0, Width - 1, Height - 1, 2));

            //Title
            G.FillRectangle(DesignFunctions.ToBrush(78, 78, 78), new Rectangle(1, 1, Width - 2, 19));
            G.FillRectangle(DesignFunctions.ToBrush(20, Color.White), new Rectangle(1, 1, Width - 2, 10));

            G.DrawLine(DesignFunctions.ToPen(150, Color.Black), new Point(1, 19), new Point(Width - 2, 19));
            G.DrawLine(DesignFunctions.ToPen(50, Color.White), new Point(1, 20), new Point(Width - 2, 20));

            //Title Icon
            try
            {
                G.DrawIcon(_ico, new Rectangle(3, 3, 16, 16));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Title Text
            G.DrawString(Text, Font, DesignFunctions.ToBrush(120, Color.Black), new Rectangle(1, 0, Width - 2, 19), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            G.DrawString(Text, Font, DesignFunctions.ToBrush(ForeColor), new Rectangle(1, 1, Width - 2, 19), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            try
            {
                G.DrawRectangle(DesignFunctions.ToPen(Parent.FindForm().TransparencyKey), new Rectangle(0, 0, 1, 1));
                G.DrawRectangle(DesignFunctions.ToPen(Parent.FindForm().TransparencyKey), new Rectangle(Width - 1, 0, 1, 1));
                G.DrawRectangle(DesignFunctions.ToPen(Parent.FindForm().TransparencyKey), new Rectangle(0, Height - 1, 1, 1));
                G.DrawRectangle(DesignFunctions.ToPen(Parent.FindForm().TransparencyKey), new Rectangle(Width - 1, Height - 1, 1, 1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            G.SmoothingMode = SmoothingMode.AntiAlias;
            if ((new Rectangle(Width - 20, 5, 10, 10)).Contains(PointToClient(MousePosition)))
            {
                G.DrawLine(new Pen(Brushes.White, 2F), new Point(Width - 20, 7), new Point(Width - 13, 13));
                G.DrawLine(new Pen(Brushes.White, 2F), new Point(Width - 20, 13), new Point(Width - 13, 7));
                if (MouseButtons == MouseButtons.Left)
                {
                    G.DrawLine(new Pen(Brushes.DarkGray, 2F), new Point(Width - 20, 7), new Point(Width - 13, 13));
                    G.DrawLine(new Pen(Brushes.DarkGray, 2F), new Point(Width - 20, 13), new Point(Width - 13, 7));
                }
            }
            else
            {
                G.DrawLine(new Pen(Brushes.Gray, 2F), new Point(Width - 20, 7), new Point(Width - 13, 13));
                G.DrawLine(new Pen(Brushes.Gray, 2F), new Point(Width - 20, 13), new Point(Width - 13, 7));
            }
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

            for (var i = 0; i <= 10; i++)
            {
                G.DrawPath(DesignFunctions.ToPen(50 / (i + 1), Color.Black), DesignFunctions.RoundRect(i, i, Width - 1 - (i * 2), Height - 2 - (i * 2), 5));
            }
        }
    }
    
}
