// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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

namespace Zeroit.Framework.UIThemes.Positron
{
    public class PositronComboBox : ComboBox
    {
        private int X;
        private int _StartIndex = 0;
        public int StartIndex
        {
            get { return _StartIndex; }
            set
            {
                _StartIndex = value;
                try
                {
                    base.SelectedIndex = value;
                }
                catch
                {
                }
                Invalidate();
            }
        }
        protected void DrawBorders(Pen p1, Graphics G)
        {
            DrawBorders(p1, 0, 0, Width, Height, G);
        }
        protected void DrawBorders(Pen p1, int offset, Graphics G)
        {
            DrawBorders(p1, 0, 0, Width, Height, offset, G);
        }
        protected void DrawBorders(Pen p1, int x, int y, int width, int height, Graphics G)
        {
            G.DrawRectangle(p1, x, y, width - 1, height - 1);
        }
        protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset, Graphics G)
        {
            DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2), G);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            X = e.X;
            base.OnMouseMove(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            X = 0;
            base.OnMouseLeave(e);
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                X = 0;
            }
            base.OnMouseClick(e);
        }

        private SolidBrush B1;
        private SolidBrush B2;

        private SolidBrush B3;
        public PositronComboBox()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);
            DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;

            BackColor = Color.FromArgb(225, 225, 225);
            DropDownStyle = ComboBoxStyle.DropDownList;

            Font = new Font("Verdana", 8);

            B1 = new SolidBrush(Color.FromArgb(230, 230, 230));
            B2 = new SolidBrush(Color.FromArgb(210, 210, 210));
            B3 = new SolidBrush(Color.FromArgb(100, 100, 100));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            Point[] points = new Point[] {
            new Point(Width - 15, 9),
            new Point(Width - 6, 9),
            new Point(Width - 11, 14)
        };
            G.Clear(BackColor);
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            LinearGradientBrush LGB1 = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(220, 220, 220), Color.FromArgb(200, 200, 200), 90f);

            G.FillRectangle(LGB1, new Rectangle(0, 0, Width, Height));

            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(150, 150, 150))), new Point(Width - 21, 2), new Point(Width - 21, Height));

            DrawBorders(new Pen(new SolidBrush(Color.FromArgb(200, 200, 200))), G);
            DrawBorders(new Pen(new SolidBrush(Color.FromArgb(150, 150, 150))), 1, G);

            try
            {
                G.DrawString((string)Items[SelectedIndex].ToString(), Font, new SolidBrush(Color.FromArgb(100, 100, 100)), new Point(3, 4));
            }
            catch
            {
                G.DrawString(" . . . ", Font, new SolidBrush(Color.FromArgb(100, 100, 100)), new Point(3, 4));
            }

            if (X >= 1)
            {
                LinearGradientBrush LGB3 = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(200, 200, 200), Color.FromArgb(220, 220, 220), 90f);
                G.FillRectangle(LGB3, new Rectangle(Width - 20, 2, 18, 17));
                G.FillPolygon(B3, points);
            }
            else
            {
                G.FillPolygon(B3, points);
            }
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            LinearGradientBrush LGB1 = new LinearGradientBrush(e.Bounds, Color.FromArgb(120, 120, 120), Color.FromArgb(100, 100, 100), 90);
            HatchBrush HB1 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(10, Color.White), Color.Transparent);

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(LGB1, new Rectangle(1, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
                e.Graphics.FillRectangle(HB1, e.Bounds);
                e.Graphics.DrawString(GetItemText(Items[e.Index]), e.Font, new SolidBrush(Color.FromArgb(200, 200, 200)), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(B2, e.Bounds);
                try
                {
                    e.Graphics.DrawString(GetItemText(Items[e.Index]), e.Font, new SolidBrush(Color.FromArgb(100, 100, 100)), e.Bounds);
                }
                catch
                {
                }
            }

        }
    }
}

