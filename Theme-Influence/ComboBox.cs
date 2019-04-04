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
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Influence
{
    public class InfluenceComboBox : ComboBox
    {
        #region " Control Help - Properties & Flicker Control "
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
        public void ReplaceItem(System.Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            e.DrawBackground();
            try
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(_highlightColor), e.Bounds);
                    //37 37 37
                }
                using (SolidBrush b = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), e.Font, b, e.Bounds);
                }
            }
            catch
            {
            }
            e.DrawFocusRectangle();
            Invalidate();
        }
        protected void DrawTriangle(Color Clr, Point FirstPoint, Point SecondPoint, Point ThirdPoint, Graphics G)
        {
            List<Point> points = new List<Point>();
            points.Add(FirstPoint);
            points.Add(SecondPoint);
            points.Add(ThirdPoint);
            G.FillPolygon(new SolidBrush(Clr), points.ToArray());
        }
        private Color _highlightColor = Color.FromArgb(128, 128, 128);
        public Color ItemHighlightColor
        {
            get { return _highlightColor; }
            set
            {
                _highlightColor = value;
                Invalidate();
            }
        }

        #endregion

        public InfluenceComboBox()
            : base()
        {
            DrawItem += ReplaceItem;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DrawMode = DrawMode.OwnerDrawFixed;
            BackColor = Color.Transparent;
            ForeColor = Color.White;
            DropDownStyle = ComboBoxStyle.DropDownList;
            DoubleBuffered = true;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Draw d = new Draw();

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.Clear(BackColor);

            LinearGradientBrush g1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(125, 78, 75, 73), Color.FromArgb(125, 61, 59, 55), 90);
            G.FillPath(g1, d.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), 2));
            //G.FillRectangle(g1, ClientRectangle)
            HatchBrush h1 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(100, 31, 31, 31), Color.FromArgb(100, 36, 36, 36));
            G.FillPath(h1, d.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), 2));
            //G.FillRectangle(h1, New Rectangle(0, 0, Width - 1, Height - 2))
            LinearGradientBrush s1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height / 2), Color.FromArgb(35, Color.White), Color.FromArgb(0, Color.White), 90);
            G.FillPath(s1, d.RoundRect(new Rectangle(0, 0, Width - 1, Height / 2 - 1), 2));
            G.DrawLine(new Pen(Color.FromArgb(85, 83, 80)), Width - 18, 0, Width - 18, Height - 1);
            G.DrawLine(new Pen(Color.FromArgb(15, 13, 10)), Width - 19, 0, Width - 19, Height - 1);
            G.DrawPath(new Pen(Color.FromArgb(150, 97, 94, 90)), d.RoundRect(new Rectangle(0, 1, Width - 1, Height - 3), 2));
            G.DrawPath(new Pen(Color.FromArgb(0, 0, 0)), d.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 2));
            //                                      Far Point                Near Point                Middle Point
            DrawTriangle(Color.White, new Point(Width - 14, 12), new Point(Width - 7, 12), new Point(Width - 11, 15), G);
            DrawTriangle(Color.White, new Point(Width - 14, 9), new Point(Width - 7, 9), new Point(Width - 11, 6), G);

            try
            {
                G.DrawString(Text, Font, Brushes.White, new Rectangle(3, 0, Width - 20, Height), new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Near
                });
            }
            catch
            {
            }

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }


}

