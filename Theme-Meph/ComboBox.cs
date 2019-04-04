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
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Meph
{

    public class MephComboBox : ComboBox
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
        public override System.Drawing.Rectangle DisplayRectangle
        {
            get { return base.DisplayRectangle; }
        }
        public void ReplaceItem(System.Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            e.DrawBackground();
            try
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(_highlightColor), e.Bounds);
                    LinearGradientBrush gloss = new LinearGradientBrush(e.Bounds, Color.FromArgb(30, Color.White), Color.FromArgb(0, Color.White), 90);
                    //Highlight Gloss/Color
                    e.Graphics.FillRectangle(gloss, new Rectangle(new Point(e.Bounds.X, e.Bounds.Y), new Size(e.Bounds.Width, e.Bounds.Height)));
                    //Drop Background
                    e.Graphics.DrawRectangle(new Pen(Color.FromArgb(90, Color.Black)) { DashStyle = DashStyle.Solid }, new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), e.Bounds);
                }
                using (SolidBrush b = new SolidBrush(Color.Silver))
                {
                    e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), e.Font, b, new Rectangle(e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width - 4, e.Bounds.Height));
                }
            }
            catch
            {
            }
            e.DrawFocusRectangle();
        }
        protected void DrawTriangle(Color Clr, Point FirstPoint, Point SecondPoint, Point ThirdPoint, Point FirstPoint2, Point SecondPoint2, Point ThirdPoint2, Graphics G)
        {
            List<Point> points = new List<Point>();
            points.Add(FirstPoint);
            points.Add(SecondPoint);
            points.Add(ThirdPoint);
            G.FillPolygon(new SolidBrush(Clr), points.ToArray());
            G.DrawPolygon(new Pen(new SolidBrush(Color.FromArgb(25, 25, 25))), points.ToArray());

            List<Point> points2 = new List<Point>();
            points2.Add(FirstPoint2);
            points2.Add(SecondPoint2);
            points2.Add(ThirdPoint2);
            G.FillPolygon(new SolidBrush(Clr), points2.ToArray());
            G.DrawPolygon(new Pen(new SolidBrush(Color.FromArgb(25, 25, 25))), points2.ToArray());
        }
        private Color _highlightColor = Color.FromArgb(55, 55, 55);
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

        public MephComboBox() : base()
        {
            DrawItem += ReplaceItem;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DrawMode = DrawMode.OwnerDrawFixed;
            BackColor = Color.Transparent;
            ForeColor = Color.Silver;
            Font = new Font("Verdana", 8, FontStyle.Regular);
            DropDownStyle = ComboBoxStyle.DropDownList;
            DoubleBuffered = true;
            Size = new Size(Width, 21);
            ItemHeight = 16;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            G.SmoothingMode = SmoothingMode.HighQuality;


            G.Clear(BackColor);
            LinearGradientBrush bodyGradNone = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 2), Color.FromArgb(40, 40, 40), Color.FromArgb(40, 40, 40), 90);
            G.FillPath(bodyGradNone, Draw.RoundRect(new Rectangle((int)bodyGradNone.Rectangle.X, (int)bodyGradNone.Rectangle.Y, (int)bodyGradNone.Rectangle.Width, (int)bodyGradNone.Rectangle.Height), 3));
            LinearGradientBrush bodyInBorderNone = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 3), Color.FromArgb(40, 40, 40), Color.FromArgb(40, 40, 40), 90);
            G.DrawPath(new Pen(bodyInBorderNone), Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 4), 3));
            G.DrawPath(new Pen(Color.FromArgb(20, 20, 20)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 3));
            //Outer Line
            G.DrawPath(new Pen(Color.FromArgb(55, 55, 55)), Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), 3));
            //Inner Line
            DrawTriangle(Color.FromArgb(60, 60, 60), new Point(Width - 14, 12), new Point(Width - 7, 12), new Point(Width - 11, 16), new Point(Width - 14, 10), new Point(Width - 7, 10), new Point(Width - 11, 5), G);
            //Triangle Fill Color

            //Draw Separator line
            G.DrawLine(new Pen(Color.FromArgb(45, 45, 45)), new Point(Width - 21, 2), new Point(Width - 21, Height - 3));
            G.DrawLine(new Pen(Color.FromArgb(55, 55, 55)), new Point(Width - 20, 1), new Point(Width - 20, Height - 3));
            G.DrawLine(new Pen(Color.FromArgb(45, 45, 45)), new Point(Width - 19, 2), new Point(Width - 19, Height - 3));
            try
            {
                G.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(5, 0, Width - 20, Height), new StringFormat
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


