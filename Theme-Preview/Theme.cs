// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
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
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Preview
{

    
    #region Base Classes
    public class ThemedControl : Control
    {
        public DrawUtils D = new DrawUtils();
        public MouseState State = MouseState.None;
        public Palette Pal;
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
        {
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        public ThemedControl() : base()
        {
            MinimumSize = new Size(20, 20);
            ForeColor = Color.FromArgb(146, 149, 152);
            Font = new Font("Segoe UI", 10.0F);
            DoubleBuffered = true;
            Pal = new Palette();
            Pal.ColHighest = Color.FromArgb(100, 110, 120);
            Pal.ColHigh = Color.FromArgb(65, 70, 75);
            Pal.ColMed = Color.FromArgb(40, 42, 45);
            Pal.ColDim = Color.FromArgb(30, 32, 35);
            Pal.ColDark = Color.FromArgb(15, 17, 19);
            BackColor = Pal.ColDim;
        }
    }
    public class ThemedTrackbar : TrackBar
    {
        public DrawUtils D = new DrawUtils();
        public MouseState State = MouseState.None;
        public Palette Pal;
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
        {
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        public ThemedTrackbar() : base()
        {
            MinimumSize = new Size(20, 20);
            ForeColor = Color.FromArgb(146, 149, 152);
            Font = new Font("Segoe UI", 10.0F);
            DoubleBuffered = true;
            Pal = new Palette();
            Pal.ColHighest = Color.FromArgb(100, 110, 120);
            Pal.ColHigh = Color.FromArgb(65, 70, 75);
            Pal.ColMed = Color.FromArgb(40, 42, 45);
            Pal.ColDim = Color.FromArgb(30, 32, 35);
            Pal.ColDark = Color.FromArgb(15, 17, 19);
            BackColor = Pal.ColDim;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }
    }
    public class ThemedTextbox : TextBox
    {
        public DrawUtils D = new DrawUtils();
        public MouseState State = MouseState.None;
        public Palette Pal;
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
        {
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        public ThemedTextbox() : base()
        {
            MinimumSize = new Size(20, 20);
            ForeColor = Color.FromArgb(146, 149, 152);
            Font = new Font("Segoe UI", 10.0F);
            DoubleBuffered = true;
            Pal = new Palette();
            Pal.ColHighest = Color.FromArgb(100, 110, 120);
            Pal.ColHigh = Color.FromArgb(65, 70, 75);
            Pal.ColMed = Color.FromArgb(40, 42, 45);
            Pal.ColDim = Color.FromArgb(30, 32, 35);
            Pal.ColDark = Color.FromArgb(15, 17, 19);
            BackColor = Pal.ColDim;
        }
    }
    public class ThemedContainer : ContainerControl
    {
        public DrawUtils D = new DrawUtils();
        protected bool Drag = true;
        public MouseState State = MouseState.None;
        protected bool TopCap = false;
        protected bool SizeCap = false;
        public Palette Pal;
        protected Point MouseP = new Point(0, 0);
        protected int TopGrip;
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
        {
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            if (e.Button == MouseButtons.Left)
            {
                if ((new Rectangle(0, 0, Width, TopGrip)).Contains(e.Location))
                {
                    TopCap = true;
                    MouseP = e.Location;
                }
                else if (Drag && (new Rectangle(Width - 15, Height - 15, 15, 15)).Contains(e.Location))
                {
                    SizeCap = true;
                    MouseP = e.Location;
                }
            }
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            TopCap = false;
            if (Drag)
            {
                SizeCap = false;
            }

        }
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (TopCap)
            {
                Parent.Location = new Point(MousePosition.X - MouseP.X, MousePosition.Y - MouseP.Y);
            }
            if (Drag && SizeCap)
            {
                MouseP = e.Location;
                Parent.Size = new Size(MouseP);
                Invalidate();
            }

        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        public ThemedContainer() : base()
        {
            MinimumSize = new Size(20, 20);
            ForeColor = Color.FromArgb(146, 149, 152);
            Font = new Font("Trebuchet MS", 10.0F);
            DoubleBuffered = true;
            Pal = new Palette();
            Pal.ColHighest = Color.FromArgb(100, 110, 120);
            Pal.ColHigh = Color.FromArgb(65, 70, 75);
            Pal.ColMed = Color.FromArgb(40, 42, 45);
            Pal.ColDim = Color.FromArgb(30, 32, 35);
            Pal.ColDark = Color.FromArgb(15, 17, 19);
            BackColor = Pal.ColDim;
        }
    }
    public class ThemedTabControl : TabControl
    {
        public DrawUtils D = new DrawUtils();
        public MouseState State = MouseState.None;
        public Palette Pal;
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
        {
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        public ThemedTabControl() : base()
        {
            MinimumSize = new Size(20, 20);
            ForeColor = Color.FromArgb(146, 149, 152);
            Font = new Font("Segoe UI", 10.0F);
            DoubleBuffered = true;
            Pal = new Palette();
            Pal.ColHighest = Color.FromArgb(100, 110, 120);
            Pal.ColHigh = Color.FromArgb(65, 70, 75);
            Pal.ColMed = Color.FromArgb(40, 42, 45);
            Pal.ColDim = Color.FromArgb(30, 32, 35);
            Pal.ColDark = Color.FromArgb(15, 17, 19);
            BackColor = Pal.ColDim;
            Alignment = TabAlignment.Top;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }
    }
    public class ThemedListControl : ListBox
    {
        public DrawUtils D = new DrawUtils();
        public MouseState State = MouseState.None;
        public Palette Pal;
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
        {
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        public ThemedListControl() : base()
        {
            MinimumSize = new Size(20, 20);
            ForeColor = Color.FromArgb(146, 149, 152);
            Font = new Font("Segoe UI", 10.0F);
            DoubleBuffered = true;
            Pal = new Palette();
            Pal.ColHighest = Color.FromArgb(100, 110, 120);
            Pal.ColHigh = Color.FromArgb(65, 70, 75);
            Pal.ColMed = Color.FromArgb(40, 42, 45);
            Pal.ColDim = Color.FromArgb(30, 32, 35);
            Pal.ColDark = Color.FromArgb(15, 17, 19);
            BackColor = Pal.ColDim;
        }
    }
    #endregion

    #region Theme Utility Stuff
    public class Palette
    {
        public Color ColHighest;
        public Color ColHigh;
        public Color ColMed;
        public Color ColDim;
        public Color ColDark;
    }
    public enum MouseState : byte
    {
        None = 0,
        Over = 1,
        Down = 2,
        Block = 3
    }
    public enum GradientAlignment : byte
    {
        Vertical = 0,
        Horizontal = 1
    }
    public class DrawUtils
    {
        public void FillGradientBeam(Graphics g, Color Col1, Color Col2, Rectangle rect, GradientAlignment align)
        {
            SmoothingMode stored = g.SmoothingMode;
            ColorBlend Blend = new ColorBlend();
            g.SmoothingMode = SmoothingMode.HighQuality;
            switch (align)
            {
                case GradientAlignment.Vertical:
                    {
                        LinearGradientBrush PathGradient = new LinearGradientBrush(new Point(rect.X, rect.Y), new Point(rect.X + rect.Width - 1, rect.Y), Color.Black, Color.Black);
                        Blend.Positions = new[] { 0, 1 / 2.0f, 1 };
                        Blend.Colors = new[] { Col1, Col2, Col1 };
                        PathGradient.InterpolationColors = Blend;
                        g.FillRectangle(PathGradient, rect);
                        break;
                    }
                case GradientAlignment.Horizontal:
                    {
                        LinearGradientBrush PathGradient = new LinearGradientBrush(new Point(rect.X, rect.Y), new Point(rect.X, rect.Y + rect.Height), Color.Black, Color.Black);
                        Blend.Positions = new[] { 0, 1 / 2.0f, 1 };
                        Blend.Colors = new[] { Col1, Col2, Col1 };
                        PathGradient.InterpolationColors = Blend;
                        PathGradient.RotateTransform(0F);
                        g.FillRectangle(PathGradient, rect);
                        break;
                    }
            }
            g.SmoothingMode = stored;
        }
        public void DrawTextWithShadow(Graphics G, Rectangle ContRect, string Text, Font TFont, HorizontalAlignment TAlign, Color TColor, Color BColor)
        {
            DrawText(G, new Rectangle(ContRect.X + 1, ContRect.Y + 1, ContRect.Width, ContRect.Height), Text, TFont, TAlign, BColor);
            DrawText(G, ContRect, Text, TFont, TAlign, TColor);
        }
        public void FillDualGradPath(Graphics g, Color Col1, Color Col2, Rectangle rect, GraphicsPath gp, GradientAlignment align)
        {
            SmoothingMode stored = g.SmoothingMode;
            ColorBlend Blend = new ColorBlend();
            g.SmoothingMode = SmoothingMode.HighQuality;
            switch (align)
            {
                case GradientAlignment.Vertical:
                    {
                        LinearGradientBrush PathGradient = new LinearGradientBrush(new Point(rect.X, rect.Y), new Point(rect.X + rect.Width - 1, rect.Y), Color.Black, Color.Black);
                        Blend.Positions = new[] { 0, 1 / 2.0f, 1 };
                        Blend.Colors = new[] { Col1, Col2, Col1 };
                        PathGradient.InterpolationColors = Blend;
                        g.FillPath(PathGradient, gp);
                        break;
                    }
                case GradientAlignment.Horizontal:
                    {
                        LinearGradientBrush PathGradient = new LinearGradientBrush(new Point(rect.X, rect.Y), new Point(rect.X, rect.Y + rect.Height), Color.Black, Color.Black);
                        Blend.Positions = new[] { 0, 1 / 2.0f, 1 };
                        Blend.Colors = new[] { Col1, Col2, Col1 };
                        PathGradient.InterpolationColors = Blend;
                        PathGradient.RotateTransform(0F);
                        g.FillPath(PathGradient, gp);
                        break;
                    }
            }
            g.SmoothingMode = stored;
        }
        public void DrawText(Graphics G, Rectangle ContRect, string Text, Font TFont, HorizontalAlignment TAlign, Color TColor)
        {
            if (string.IsNullOrEmpty(Text))
            {
                return;
            }
            Size TextSize = G.MeasureString(Text, TFont).ToSize();
            int CenteredY = ContRect.Height / 2 - TextSize.Height / 2;
            switch (TAlign)
            {
                case HorizontalAlignment.Left:
                    {
                        StringFormat sf = new StringFormat();
                        sf.LineAlignment = StringAlignment.Near;
                        sf.Alignment = StringAlignment.Near;
                        G.DrawString(Text, TFont, new SolidBrush(TColor), new Rectangle(ContRect.X, Convert.ToInt32(ContRect.Y + ContRect.Height / 2.0 - TextSize.Height / 2.0), ContRect.Width, ContRect.Height), sf);
                        break;
                    }
                case HorizontalAlignment.Right:
                    {
                        StringFormat sf = new StringFormat();
                        sf.LineAlignment = StringAlignment.Far;
                        sf.Alignment = StringAlignment.Far;
                        G.DrawString(Text, TFont, new SolidBrush(TColor), new Rectangle(ContRect.X, ContRect.Y, ContRect.Width, Convert.ToInt32(ContRect.Height / 2.0 + TextSize.Height / 2.0)), sf);
                        break;
                    }
                case HorizontalAlignment.Center:
                    {
                        StringFormat sf = new StringFormat();
                        sf.LineAlignment = StringAlignment.Center;
                        sf.Alignment = StringAlignment.Center;
                        G.DrawString(Text, TFont, new SolidBrush(TColor), ContRect, sf);
                        break;
                    }
            }
        }
        public GraphicsPath RoundRect(Rectangle Rectangle, int Curve)
        {
            GraphicsPath Path = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            Path.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180F, 90F);
            Path.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90F, 90F);
            Path.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0F, 90F);
            Path.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90F, 90F);
            Path.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return Path;
        }
        public GraphicsPath RoundedTopRect(Rectangle Rectangle, int Curve)
        {
            GraphicsPath Path = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            Path.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180F, 90F);
            Path.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90F, 90F);
            Path.AddLine(new Point(Rectangle.X + Rectangle.Width, Rectangle.Y + ArcRectangleWidth), new Point(Rectangle.X + Rectangle.Width, Rectangle.Y + Rectangle.Height));
            Path.AddLine(new Point(Rectangle.X, Rectangle.Height + Rectangle.Y), new Point(Rectangle.X, Rectangle.Y + Curve));
            return Path;
        }
    }

    #endregion

    public class PVForm : ThemedContainer
    {
        public PVForm() : base()
        {
            MinimumSize = new Size(305, 150);
            Dock = DockStyle.Fill;
            TopGrip = 30;
            Font = new Font("Segoe UI", 10.0F);
            BackColor = Color.FromArgb(21, 23, 25);
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);
            try
            {
                this.ParentForm.TransparencyKey = Color.Fuchsia;
                this.ParentForm.MinimumSize = MinimumSize;
                if (!(this.ParentForm.FormBorderStyle == FormBorderStyle.None))
                {
                    this.ParentForm.FormBorderStyle = FormBorderStyle.None;
                }
            }
            catch (Exception ex)
            {
            }
            G.Clear(this.ParentForm.TransparencyKey);

            //| Main drawing
            Rectangle BorderRect = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle BorderInnerRect = new Rectangle(1, 1, Width - 3, Height - 3);
            G.FillRectangle(new SolidBrush(Pal.ColDim), BorderRect);

            //|=========================|
            //| The top textured bit of the theme is 'first'
            //| The second area for menu objects is 'second'
            //|=========================|
            //| Top Rect
            Rectangle FirstTexturedRect = new Rectangle(0, 0, Width - 1, TopGrip);
            HatchBrush FirstDiagonalHatch = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Pal.ColDim, Color.Transparent);
            LinearGradientBrush FirstLGB = new LinearGradientBrush(new Point(0, 0), new Point(0, TopGrip), Pal.ColHigh, Pal.ColDim);
            Rectangle FirstShineRect = new Rectangle(0, 0, Width - 1, (int)(TopGrip / 2.0));
            LinearGradientBrush FirstShineLGB = new LinearGradientBrush(new Point(0, 0), new Point(0, (int)(TopGrip * (3 / 5.0))), Color.FromArgb(120, Pal.ColHighest), Color.FromArgb(10, Pal.ColHighest));
            LinearGradientBrush test = new LinearGradientBrush(new Point(0, 0), new Point(0, (int)(TopGrip * (3 / 5.0))), Color.FromArgb(60, Pal.ColDim), Color.FromArgb(10, Pal.ColDim));
            G.FillRectangle(FirstLGB, FirstTexturedRect);
            G.FillRectangle(FirstDiagonalHatch, FirstTexturedRect);
            G.FillRectangle(test, FirstShineRect);
            G.FillRectangle(FirstShineLGB, FirstShineRect);
            G.DrawLine(new Pen(Color.FromArgb(150, Color.Black)), new Point(0, TopGrip), new Point(Width - 1, TopGrip));
            G.DrawLine(new Pen(Color.FromArgb(60, Pal.ColHighest)), new Point(0, TopGrip + 1), new Point(Width - 1, TopGrip + 1));


            //| Second Top Rect
            int SecondMenuHeight = Convert.ToInt32(TopGrip * 2.4);
            Rectangle SecondMenuRect = new Rectangle(0, TopGrip, Width - 1, SecondMenuHeight);
            Rectangle BlahRect = new Rectangle(0, SecondMenuHeight - 20, Width - 1, 22);
            LinearGradientBrush SecondLGB = new LinearGradientBrush(new Point(0, SecondMenuHeight - 20), new Point(0, SecondMenuHeight - 10 + 22), Pal.ColDim, Pal.ColDark);
            G.FillRectangle(SecondLGB, BlahRect);
            G.DrawLine(new Pen(Color.FromArgb(150, Color.Black)), new Point(0, SecondMenuHeight), new Point(Width - 1, SecondMenuHeight));
            G.DrawLine(new Pen(Color.FromArgb(60, Pal.ColHighest)), new Point(0, SecondMenuHeight + 1), new Point(Width - 1, SecondMenuHeight + 1));

            //| Below Second Top Rect
            G.FillRectangle(new SolidBrush(Color.FromArgb(150, Pal.ColDark)), new Rectangle(0, SecondMenuHeight, Width - 1, Height - SecondMenuHeight));

            //| Borders and finalizations
            G.DrawRectangle(Pens.Black, BorderRect);
            G.DrawRectangle(new Pen(Color.FromArgb(60, Pal.ColHighest)), BorderInnerRect);
            D.DrawTextWithShadow(G, new Rectangle(5, 0, Width - 31, TopGrip), Text, Font, HorizontalAlignment.Left, Color.FromArgb(120, Color.WhiteSmoke), Color.Black);
        }
    }
    
    
}
