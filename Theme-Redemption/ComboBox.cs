// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ComboBox.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Redemption
{
    public class RedemptionComboBox : ComboBox
    {
        #region " Control Help - Properties & Flicker Control "
        private int _StartIndex = 0;
        private int StartIndex
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
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(59, 60, 64)), e.Bounds);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(49, 50, 54)), e.Bounds);
                }
                using (SolidBrush b = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), e.Font, b, new Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height));
                }
            }
            catch
            {
            }
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

        public RedemptionComboBox() : base()
        {
            DrawItem += ReplaceItem;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            DrawMode = DrawMode.OwnerDrawFixed;
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(182, 179, 171);
            DropDownStyle = ComboBoxStyle.DropDownList;
            StartIndex = 0;
            ItemHeight = 18;
            DoubleBuffered = true;
            Font = new Font("Arial", 8.25f, FontStyle.Bold);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 26;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            int Curve = 4;
            G.Clear(BackColor);

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.TextRenderingHint = TextRenderingHint.AntiAlias;
            G.FillPath(new SolidBrush(Color.FromArgb(49, 50, 54)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), Curve));

            LinearGradientBrush BodyGradient = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(57, 62, 68), Color.FromArgb(42, 43, 47), 90);
            G.FillPath(BodyGradient, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), Curve));


            G.SetClip(Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), Curve));
            LinearGradientBrush ButtonBackground = new LinearGradientBrush(new Rectangle(Width - 17, 0, 17, Height - 2), Color.FromArgb(75, 78, 87), Color.FromArgb(50, 51, 55), 90);
            G.FillRectangle(ButtonBackground, ButtonBackground.Rectangle);
            G.ResetClip();


            LinearGradientBrush BorderPen = new LinearGradientBrush(new Rectangle(0, 1, Width - 1, Height - 2), Color.FromArgb(92, 97, 103), Color.Transparent, 90);
            G.DrawPath(new Pen(BorderPen), Draw.RoundRect(new Rectangle(0, 1, Width - 1, Height - 2), Curve));
            G.DrawPath(new Pen(Color.FromArgb(32, 33, 37)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), Curve));


            DrawTriangle(Color.FromArgb(22, 23, 28), new Point(Width - 12, 8), new Point(Width - 6, 8), new Point(Width - 9, 5), G);
            DrawTriangle(Color.FromArgb(22, 23, 28), new Point(Width - 12, 14), new Point(Width - 6, 14), new Point(Width - 9, 17), G);
            G.SetClip(Draw.RoundRect(new Rectangle(Width - 17, 0, 17, Height), Curve));
            LinearGradientBrush ButtonPen = new LinearGradientBrush(new Rectangle(1, 1, Width - 3, Height - 3), Color.FromArgb(82, 85, 92), Color.FromArgb(66, 67, 72), 90);
            G.DrawPath(new Pen(ButtonPen), Draw.RoundRect(new Rectangle(1, 1, Width - 3, Height - 3), Curve));
            G.ResetClip();
            G.DrawLine(new Pen(Color.FromArgb(29, 37, 40)), new Point(Width - 17, 0), new Point(Width - 17, Height - 2));
            G.DrawLine(new Pen(Color.FromArgb(85, 92, 98)), new Point(Width - 16, 1), new Point(Width - 16, Height - 3));

            try
            {
                G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(16, 20, 21)), new Rectangle(7, 0, Width - 1, Height - 1), new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Near
                });
                G.DrawString(Text, Font, new SolidBrush(Color.White), new Rectangle(7, 1, Width - 1, Height - 1), new StringFormat
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

