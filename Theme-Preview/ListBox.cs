// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="ListBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
    public class PVListbox : ThemedListControl
    {
        private HorizontalAlignment _TextAlignment = HorizontalAlignment.Center;
        public HorizontalAlignment TextAlignment
        {
            get
            {
                return _TextAlignment;
            }
            set
            {
                _TextAlignment = value;
            }
        }
        public PVListbox() : base()
        {
            IntegralHeight = false;
            ItemHeight = 24;
            Font = new Font("Segoe UI Semilight", 12.0F);
            ForeColor = Pal.ColHighest;
            DrawMode = DrawMode.OwnerDrawVariable;
            BorderStyle = BorderStyle.None;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }

        protected void OnItemPaint(Graphics G, int i)
        {
            int FirstItemOffset = 0;
            int RectOffset = 1;
            if (i == 0)
            {
                FirstItemOffset = 3;
            }
            Rectangle ItemRect = new Rectangle(4, RectOffset + FirstItemOffset + i * ItemHeight, Width - 10, ItemHeight - (RectOffset * 2) - (FirstItemOffset) - 0);
            GraphicsPath ButtonPath = D.RoundRect(ItemRect, 4);
            GraphicsPath ButtonInnerPath = D.RoundRect(new Rectangle(ItemRect.X, ItemRect.Y, ItemRect.Width, ItemRect.Height), 4);
            GraphicsPath ButtonHighlightPath = D.RoundRect(new Rectangle(ItemRect.X, ItemRect.Y + 1, ItemRect.Width, ItemRect.Height - 2), 4);

            G.FillPath(new SolidBrush(Color.FromArgb(100, Pal.ColDim)), ButtonPath);
            G.FillPath(new SolidBrush(Pal.ColDim), ButtonInnerPath);
            if (i == SelectedIndex)
            {
                G.FillPath(new SolidBrush(Color.FromArgb(50, 50, 170, 250)), ButtonInnerPath);
            }

            if (i == SelectedIndex)
            {
                G.DrawPath(new Pen(Color.FromArgb(160, Pal.ColHighest)), ButtonHighlightPath);
                G.DrawPath(Pens.Black, ButtonPath);
                D.FillGradientBeam(G, Color.FromArgb(40, Color.Black), Color.FromArgb(30, Pal.ColHighest), ItemRect, GradientAlignment.Vertical);
            }
            else
            {
                G.DrawPath(new Pen(Color.FromArgb(60, Pal.ColHighest)), ButtonHighlightPath);
                G.DrawPath(Pens.Black, ButtonPath);
                D.FillGradientBeam(G, Color.FromArgb(20, Color.Black), Color.FromArgb(20, Pal.ColHighest), ItemRect, GradientAlignment.Vertical);
            }

            Color TextCol = Color.WhiteSmoke;
            if (i == SelectedIndex)
            {
                TextCol = Color.FromArgb(50, 170, 250);
            }
            D.DrawTextWithShadow(G, ItemRect, Items[i].ToString(), Font, TextAlignment, TextCol, Color.Black);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);
            G.Clear(this.Parent.BackColor);
            G.SmoothingMode = SmoothingMode.HighQuality;
            BorderStyle = BorderStyle.None;



            Rectangle BorderRect = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle BorderInnerRect = new Rectangle(1, 1, Width - 3, Height - 3);
            Rectangle ButtonRect = new Rectangle(3, 1, Width - 7, Height - 3);


            //| Drawing the button's hole into the form (Whats the whole that a button goes into? There even a name for that???)
            GraphicsPath Out1Path = D.RoundRect(BorderRect, 3);
            GraphicsPath Out2Path = D.RoundRect(BorderInnerRect, 5);
            LinearGradientBrush Out2LGB = new LinearGradientBrush(new Point(0, 0), new Point(0, Height), Color.FromArgb(150, Color.Black), Color.FromArgb(60, Pal.ColDim));
            G.FillRectangle(new SolidBrush(Color.FromArgb(35, Color.Black)), BorderInnerRect);
            G.DrawPath(new Pen(Out2LGB, 3F), Out2Path);
            G.DrawPath(new Pen(Color.FromArgb(100, Pal.ColHighest)), Out1Path);

            //| Drawing the button
            GraphicsPath ButtonPath = D.RoundRect(ButtonRect, 4);
            GraphicsPath ButtonInnerPath = D.RoundRect(new Rectangle(ButtonRect.X, ButtonRect.Y, ButtonRect.Width, ButtonRect.Height), 4);
            GraphicsPath ButtonHighlightPath = D.RoundRect(new Rectangle(ButtonRect.X, ButtonRect.Y + 1, ButtonRect.Width, ButtonRect.Height - 2), 4);
            if (false)
            {
                G.FillPath(new SolidBrush(Color.FromArgb(100, Pal.ColDim)), ButtonPath);
                G.FillPath(new SolidBrush(Pal.ColDim), ButtonInnerPath);
                D.FillGradientBeam(G, Color.FromArgb(20, Color.Black), Color.FromArgb(20, Pal.ColHighest), ButtonRect, GradientAlignment.Vertical);

                G.DrawPath(new Pen(Color.FromArgb(60, Pal.ColHighest)), ButtonHighlightPath);
                G.DrawPath(Pens.Black, ButtonPath);
            }



            int x = 0;
            foreach (object i in Items)
            {
                OnItemPaint(G, x);
                x += 1;
            }
        }
    }
}
