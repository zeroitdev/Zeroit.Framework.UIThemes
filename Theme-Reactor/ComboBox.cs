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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Reactor
{
    public class ReactorComboBox : ComboBox
    {

        #region " Control Help - Properties & Flicker Control "
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
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
        private Color LightBlack = Color.FromArgb(37, 37, 37);
        private Color LighterBlack = Color.FromArgb(60, 60, 60);
        public void ReplaceItem(System.Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            e.DrawBackground();
            try
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(229, 88, 0)), e.Bounds);
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
        }
        protected void DrawTriangle(Color Clr, Point FirstPoint, Point SecondPoint, Point ThirdPoint, Graphics G)
        {
            List<Point> points = new List<Point>();
            points.Add(FirstPoint);
            points.Add(SecondPoint);
            points.Add(ThirdPoint);
            G.FillPolygon(new SolidBrush(Clr), points.ToArray());
        }
        #endregion

        public ReactorComboBox()
            : base()
        {
            DrawItem += ReplaceItem;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DrawMode = DrawMode.OwnerDrawFixed;
            BackColor = Color.FromArgb(45, 45, 45);
            ForeColor = Color.White;
            DropDownStyle = ComboBoxStyle.DropDownList;
            DoubleBuffered = true;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;
            LinearGradientBrush T = new LinearGradientBrush(new Rectangle(0, 0, Width, 10), Color.FromArgb(62, Color.White), Color.FromArgb(30, Color.White), 90);
            SolidBrush DrawCornersBrush = default(SolidBrush);
            DrawCornersBrush = new SolidBrush(Color.FromArgb(37, 37, 37));
            try
            {
                var _with4 = G;
                _with4.SmoothingMode = SmoothingMode.HighQuality;
                _with4.Clear(Color.FromArgb(37, 37, 37));
                _with4.FillRectangle(T, new Rectangle(Width - 20, 0, Width, 9));
                _with4.DrawLine(Pens.Black, Width - 20, 0, Width - 20, Height);
                try
                {
                    //.DrawString(Items(SelectedIndex).ToString, Font, Brushes.White, New Rectangle(New Point(3, 3), New Size(Width - 18, Height)))
                    _with4.DrawString(Text, Font, Brushes.White, new Rectangle(3, 0, Width - 20, Height), new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Near
                    });
                }
                catch
                {
                }

                _with4.DrawLine(new Pen(new SolidBrush(Color.FromArgb(37, 37, 37))), 0, 0, 0, 0);
                _with4.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(0, 0, 0))), new Rectangle(1, 1, Width - 3, Height - 3));

                _with4.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, Width, 0);
                _with4.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, 0, Height);
                _with4.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), Width - 1, 0, Width - 1, Height);
                _with4.DrawLine(new Pen(new SolidBrush(Color.FromArgb(70, 70, 70))), 0, Height - 1, Width, Height - 1);

                DrawTriangle(Color.White, new Point(Width - 14, 8), new Point(Width - 7, 8), new Point(Width - 11, 11), G);
            }
            catch
            {
            }
        }
    }

}


