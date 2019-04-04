// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Tab.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Influx
{
    public class InfluxTabControl : TabControl
    {

        private Color _BG;
        private bool _TabCloseButton;
        private bool _BackgroundPattern;
        public override Color BackColor
        {
            get { return _BG; }
            set { _BG = value; }
        }

        public bool TabCloseButton
        {
            get { return _TabCloseButton; }
            set
            {
                _TabCloseButton = value;
                InvokePaint(this, new PaintEventArgs(base.CreateGraphics(), base.Bounds));
            }
        }

        public bool BackgroundPattern
        {
            get { return _BackgroundPattern; }
            set { _BackgroundPattern = value; }
        }

        public InfluxTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            //DoubleBuffered = true;
            BackColor = Color.FromArgb(77, 77, 77);
            _TabCloseButton = false;
            _BackgroundPattern = true;
            try
            {
                SelectedTab = TabPages[0];
            }
            catch
            {
            }
            InvokePaint(this, new PaintEventArgs(base.CreateGraphics(), base.Bounds));
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Top;
        }

        public Pen ToPen(Color color)
        {
            return new Pen(color);
        }

        public Brush ToBrush(Color color)
        {
            return new SolidBrush(color);
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            if (_TabCloseButton & TabCount > 1)
            {
                int intOldIndex = intHoveredIndex;
                intHoveredIndex = GetHoveredCloseButtonIndex(e.Location);
                if (intHoveredIndex != intOldIndex)
                {
                    //Repaint
                    InvokePaint(this, new PaintEventArgs(base.CreateGraphics(), base.Bounds));
                }
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseClick(System.Windows.Forms.MouseEventArgs e)
        {
            if (_TabCloseButton & TabCount > 1)
            {
                int intHoveredIndex = GetHoveredCloseButtonIndex(e.Location);
                if (intHoveredIndex != -1)
                {
                    TabPages.RemoveAt(intHoveredIndex);
                }
            }
            base.OnMouseClick(e);
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            InvokePaint(this, new PaintEventArgs(base.CreateGraphics(), base.Bounds));
            base.OnMouseDown(e);
        }

        private Point GetCloseButtonPositionByIndex(int intIndex)
        {
            return GetCloseButtonBoundsByIndex(intIndex).Location;
        }

        private Rectangle GetCloseButtonBoundsByIndex(int intTabIndex)
        {
            Rectangle TabTopBounds = GetTabRect(intTabIndex);
            return new Rectangle(TabTopBounds.X + TabTopBounds.Width - 1 - 7, 3, 7, 7);
        }

        private bool MouseIsOverCloseButton(int intTabIndex, Point pntMouseLocation)
        {
            return GetCloseButtonBoundsByIndex(intTabIndex).Contains(pntMouseLocation);
        }

        private int GetHoveredCloseButtonIndex(Point pntMouseLocation)
        {
            for (int i = 0; i <= TabCount - 1; i++)
            {
                if (MouseIsOverCloseButton(i, pntMouseLocation))
                {
                    return i;
                }
            }
            return -1;
        }

        int intHoveredIndex = -1;
        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            if (!_BackgroundPattern)
                try
                {
                    SelectedTab.BackColor = BackColor;
                }
                catch
                {
                }
            G.Clear(Color.FromArgb(77, 77, 77));

            //HatchBrush
            HatchBrush HB_Container = new HatchBrush(HatchStyle.Percent20, Color.FromArgb(83, 83, 83), BackColor);
            G.FillRectangle(HB_Container, new Rectangle(0, 0, Width, Height));
            //Selected panel hatchbrush
            if ((SelectedTab != null) & _BackgroundPattern)
            {
                Bitmap ST_B = new Bitmap(SelectedTab.Width, SelectedTab.Height);
                Graphics ST_G = Graphics.FromImage(ST_B);
                ST_G.FillRectangle(HB_Container, new Rectangle(0, 0, SelectedTab.Width, SelectedTab.Height));
                SelectedTab.CreateGraphics().DrawImage(ST_B, 0, 0);
            }
            //Draw panel borders
            Rectangle TopHorizontal = new Rectangle(3, 24, Width - 6, 1);
            Rectangle BottomHorizontal = new Rectangle(3, Height - 4, Width - 6, 1);
            Rectangle LeftVertical = new Rectangle(3, 24, 1, Height - 27);
            Rectangle RightVertical = new Rectangle(Width - 4, 24, 1, Height - 27);
            G.FillRectangle(new SolidBrush(Color.FromArgb(65, 65, 65)), TopHorizontal);
            G.FillRectangle(new SolidBrush(Color.FromArgb(65, 65, 65)), BottomHorizontal);
            G.FillRectangle(new SolidBrush(Color.FromArgb(65, 65, 65)), LeftVertical);
            G.FillRectangle(new SolidBrush(Color.FromArgb(65, 65, 65)), RightVertical);

            for (int i = 0; i <= TabCount - 1; i++)
            {
                Rectangle TabTopBounds = GetTabRect(i);
                if (i == SelectedIndex)
                {
                    if (i == 0)
                    {
                        //Gradient
                        TabTopBounds = new Rectangle(TabTopBounds.X + 1, TabTopBounds.Y + 1, TabTopBounds.Width - 1, TabTopBounds.Height);
                        Rectangle GradientBounds = new Rectangle(TabTopBounds.X + 1, TabTopBounds.Y, TabTopBounds.Width - 2, TabTopBounds.Height - 1);
                        LinearGradientBrush SelectedGradient = new LinearGradientBrush(GradientBounds, Color.FromArgb(100, 111, 111, 111), Color.Transparent, 90);
                        G.FillRectangle(SelectedGradient, GradientBounds);
                        //Tab top border
                        G.DrawPath(ToPen(Color.FromArgb(65, 65, 65)), RoundRect(TabTopBounds, 2));
                        Rectangle BottomLine = new Rectangle(TabTopBounds.X + 1, TabTopBounds.Y + TabTopBounds.Height - 1, TabTopBounds.Width, 1);
                        G.DrawRectangle(ToPen(Color.FromArgb(77, 77, 77)), BottomLine);
                    }
                    else
                    {
                        //Gradient
                        TabTopBounds = new Rectangle(TabTopBounds.X, TabTopBounds.Y + 1, TabTopBounds.Width, TabTopBounds.Height);
                        Rectangle GradientBounds = new Rectangle(TabTopBounds.X + 1, TabTopBounds.Y, TabTopBounds.Width - 2, TabTopBounds.Height - 1);
                        LinearGradientBrush SelectedGradient = new LinearGradientBrush(GradientBounds, Color.FromArgb(100, 111, 111, 111), Color.Transparent, 90);
                        G.FillRectangle(SelectedGradient, GradientBounds);
                        //Top border
                        G.DrawPath(ToPen(Color.FromArgb(65, 65, 65)), RoundRect(TabTopBounds, 2));
                        Rectangle BottomLine = new Rectangle(TabTopBounds.X + 1, TabTopBounds.Y + TabTopBounds.Height - 1, TabTopBounds.Width - 2, 1);
                        G.DrawRectangle(ToPen(Color.FromArgb(77, 77, 77)), BottomLine);
                    }
                    if (_TabCloseButton & TabCount > 1)
                    {
                        if (intHoveredIndex == i)
                        {
                            G.DrawString("x", new Font("Segoe UI", 6), new SolidBrush(Color.White), new Point((TabTopBounds.X + TabTopBounds.Width - 1) - 5));
                        }
                        else
                        {
                            G.DrawString("x", new Font("Segoe UI", 6), new SolidBrush(Color.FromArgb(200, 200, 200)), new Point((TabTopBounds.X + TabTopBounds.Width - 1) - 5));
                        }
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        TabTopBounds = new Rectangle(TabTopBounds.X + 1, TabTopBounds.Y + 1, TabTopBounds.Width - 1, TabTopBounds.Height);
                        G.DrawPath(ToPen(Color.FromArgb(65, 65, 65)), RoundRect(TabTopBounds, 2));
                    }
                    else
                    {
                        TabTopBounds = new Rectangle(TabTopBounds.X, TabTopBounds.Y + 1, TabTopBounds.Width, TabTopBounds.Height);
                        G.DrawPath(ToPen(Color.FromArgb(65, 65, 65)), RoundRect(TabTopBounds, 2));
                    }
                    if (_TabCloseButton & TabCount > 1)
                    {
                        if (intHoveredIndex == i)
                        {
                            G.DrawString("x", new Font("Segoe UI", 6), new SolidBrush(Color.White), new Point((TabTopBounds.X + TabTopBounds.Width - 1) - 5));
                        }
                        else
                        {
                            G.DrawString("x", new Font("Segoe UI", 6), new SolidBrush(Color.FromArgb(150, 150, 150)), new Point((TabTopBounds.X + TabTopBounds.Width - 1) - 5));
                        }
                    }
                }
                if (_TabCloseButton)
                {
                    G.DrawString(TabPages[i].Text, Font, ToBrush(Color.FromArgb(229, 229, 229)), new Point(Convert.ToInt32(TabTopBounds.X + (TabTopBounds.Width / 2)) - 2, Convert.ToInt32(TabTopBounds.Y + (TabTopBounds.Height / 2))), new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });
                }
                else
                {
                    G.DrawString(TabPages[i].Text, Font, ToBrush(Color.FromArgb(229, 229, 229)), new Point(Convert.ToInt32(TabTopBounds.X + (TabTopBounds.Width / 2)), Convert.ToInt32(TabTopBounds.Y + (TabTopBounds.Height / 2))), new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });
                }

            }

            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
        public GraphicsPath RoundRect(Rectangle Rectangle, int Curve)
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
    }


}


