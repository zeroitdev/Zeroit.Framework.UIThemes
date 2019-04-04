// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ComboBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Influx
{
    public class InfluxComboBox : ComboBox
    {
        private int X;

        private bool Over;
        public InfluxComboBox()
            : base()
        {
            TextChanged += InfluxComboBox_TextChanged;
            DropDownClosed += InfluxComboBox_DropDownClosed;
            Font = new Font("Verdana", 8);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 18;
            DropDownStyle = ComboBoxStyle.DropDownList;
            BackColor = Color.FromArgb(77, 77, 77);
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.Location.X;
            Invalidate();
        }

        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            Over = true;
            Invalidate();
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            Over = false;
            Invalidate();
        }

        SolidBrush TextBrush = new SolidBrush(Color.FromArgb(229, 229, 229));
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!(DropDownStyle == ComboBoxStyle.DropDownList))
                DropDownStyle = ComboBoxStyle.DropDownList;
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            G.Clear(Color.FromArgb(77, 77, 77));

            //Draw background
            if (Over)
            {
                Rectangle TopRectangle = new Rectangle(2, 2, Width - 4, Convert.ToInt32(Height / 2));
                Rectangle BottomRectangle = new Rectangle(2, Convert.ToInt32(Height / 2), Width - 4, Convert.ToInt32(Height / 2));
                LinearGradientBrush TopGradient = new LinearGradientBrush(TopRectangle, Color.FromArgb(78, 78, 78), Color.FromArgb(82, 82, 82), 90);
                G.FillRectangle(TopGradient, TopRectangle);
                LinearGradientBrush BottomGradient = new LinearGradientBrush(BottomRectangle, Color.FromArgb(70, 70, 70), Color.FromArgb(75, 75, 75), 90);
                G.FillRectangle(BottomGradient, BottomRectangle);
            }
            else
            {
                Rectangle TopRectangle = new Rectangle(2, 2, Width - 4, Convert.ToInt32(Height / 2));
                Rectangle BottomRectangle = new Rectangle(2, Convert.ToInt32(Height / 2), Width - 4, Convert.ToInt32(Height / 2));
                LinearGradientBrush TopGradient = new LinearGradientBrush(TopRectangle, Color.FromArgb(73, 73, 73), Color.FromArgb(74, 74, 74), 90);
                G.FillRectangle(TopGradient, TopRectangle);
                LinearGradientBrush BottomGradient = new LinearGradientBrush(BottomRectangle, Color.FromArgb(68, 68, 68), Color.FromArgb(72, 72, 72), 90);
                G.FillRectangle(BottomGradient, BottomRectangle);
            }

            //Draw border
            Pen p = new Pen(Color.FromArgb(60, 60, 60));
            G.DrawPath(p, RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));
            G.DrawPath(new Pen(Color.FromArgb(84, 84, 84)), RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), 2));

            //Draw dropdown triangle
            G.SmoothingMode = SmoothingMode.HighQuality;
            Point pntCheckPointOne = new Point(Width - 16, Convert.ToInt32(Height / 2) - 3);
            Point[] CheckPoints = {
            pntCheckPointOne,
            new Point(pntCheckPointOne.X + 4, pntCheckPointOne.Y + 4),
            new Point(pntCheckPointOne.X + 8, pntCheckPointOne.Y)
        };
            if (X >= Width - 23)
            {
                //Hover triangle
                G.DrawLines(new Pen(Color.White, 2), CheckPoints);
            }
            else
            {
                G.DrawLines(new Pen(Color.FromArgb(220, 220, 220), 2), CheckPoints);
            }

            //Draw text
            int S1 = Convert.ToInt32(G.MeasureString(" ... ", Font).Height);
            if (SelectedIndex != -1)
            {
                G.DrawString(Items[SelectedIndex].ToString(), Font, TextBrush, 4, Convert.ToInt32(Height / 2 - S1 / 2));
            }
            else
            {
                if ((Items != null) & Items.Count > 0)
                {
                    G.DrawString(Items[0].ToString(), Font, TextBrush, 4, Height / 2 - S1 / 2);
                }
                else
                {
                    G.DrawString(" ... ", Font, TextBrush, 4, Height / 2 - S1 / 2);
                }
            }

            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                Rectangle ItemBounds = e.Bounds;
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 255, 255)), ItemBounds);
                if (e.State == DrawItemState.Selected | e.State == DrawItemState.Focus)
                {
                    //Draw item backcolor
                    if (IsEven(e.Index))
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(75, 75, 75)), ItemBounds);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(72, 72, 72)), ItemBounds);
                    }
                    Rectangle ItemBoundsTop = new Rectangle(ItemBounds.X + 2, ItemBounds.Y + 1, ItemBounds.Width - 5, Convert.ToInt32(ItemBounds.Height / 2) - 1);
                    Rectangle ItemBoundsBottom = new Rectangle(ItemBounds.X + 2, ItemBounds.Y + Convert.ToInt32(ItemBounds.Height / 2), ItemBounds.Width - 5, Convert.ToInt32(ItemBounds.Height / 2));
                    LinearGradientBrush TopGradient = new LinearGradientBrush(ItemBoundsTop, Color.FromArgb(150, 115, 115, 115), Color.FromArgb(150, 120, 120, 120), 90);
                    e.Graphics.FillRectangle(TopGradient, ItemBoundsTop);
                    LinearGradientBrush BottomGradient = new LinearGradientBrush(ItemBoundsBottom, Color.FromArgb(150, 90, 90, 90), Color.FromArgb(150, 85, 85, 85), 90);
                    e.Graphics.FillRectangle(BottomGradient, ItemBoundsBottom);
                    //Draw selected item bounds
                    Rectangle SelectedRectangle = new Rectangle(ItemBounds.X + 2, ItemBounds.Y, ItemBounds.Width - 5, ItemBounds.Height - 1);
                    e.Graphics.DrawRectangle(new Pen(Color.FromArgb(200, 60, 60, 60)), SelectedRectangle);
                    //Draw text
                    e.Graphics.DrawString(" " + Items[e.Index].ToString(), Font, new SolidBrush(Color.FromArgb(229, 229, 229)), 5, Convert.ToInt32(e.Bounds.Y + (e.Bounds.Height / 2) - 8));
                }
                else
                {
                    //Draw item backcolor
                    if (IsEven(e.Index))
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(77, 77, 77)), ItemBounds);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(73, 73, 73)), ItemBounds);
                    }
                    //Draw item border
                    e.Graphics.DrawLine(new Pen(Color.FromArgb(65, 65, 65)), ItemBounds.X, ItemBounds.Y, ItemBounds.X + ItemBounds.Width - 1, ItemBounds.Y);
                    //Draw text
                    e.Graphics.DrawString(" " + Items[e.Index].ToString(), Font, new SolidBrush(Color.FromArgb(229, 229, 229)), 5, Convert.ToInt32(e.Bounds.Y + (e.Bounds.Height / 2) - 8));
                }
            }
            base.OnDrawItem(e);
        }

        private void InfluxComboBox_DropDownClosed(object sender, System.EventArgs e)
        {
            DropDownStyle = ComboBoxStyle.Simple;
            Application.DoEvents();
            DropDownStyle = ComboBoxStyle.DropDownList;
            Invalidate();
        }

        private void InfluxComboBox_TextChanged(object sender, System.EventArgs e)
        {
            Invalidate();
        }

        private bool IsEven(int intNumber)
        {
            return (intNumber % 2 == 0);
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


