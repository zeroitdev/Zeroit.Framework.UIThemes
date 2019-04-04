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
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Thirteen
{
    public class ThirteenComboBox : ComboBox
    {
        #region " Control Help - Properties & Flicker Control "
        public enum ColorSchemes
        {
            Light,
            Dark
        }
        private ColorSchemes _ColorScheme;
        public ColorSchemes ColorScheme
        {
            get { return _ColorScheme; }
            set
            {
                _ColorScheme = value;
                Invalidate();
            }
        }

        private Color _AccentColor;
        public Color AccentColor
        {
            get { return _AccentColor; }
            set
            {
                _AccentColor = value;
                Invalidate();
            }
        }

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
                    e.Graphics.FillRectangle(new SolidBrush(_AccentColor), e.Bounds);
                }
                else
                {
                    switch (ColorScheme)
                    {
                        case ColorSchemes.Dark:
                            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), e.Bounds);
                            break;
                        case ColorSchemes.Light:
                            e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
                            break;
                    }
                }
                switch (ColorScheme)
                {
                    case ColorSchemes.Dark:
                        e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), e.Font, Brushes.White, e.Bounds);
                        break;
                    case ColorSchemes.Light:
                        e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), e.Font, Brushes.Black, e.Bounds);
                        break;
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

        public ThirteenComboBox() : base()
        {
            DrawItem += ReplaceItem;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            DrawMode = DrawMode.OwnerDrawFixed;
            BackColor = Color.FromArgb(50, 50, 50);
            ForeColor = Color.White;
            AccentColor = Color.DodgerBlue;
            ColorScheme = ColorSchemes.Dark;
            DropDownStyle = ComboBoxStyle.DropDownList;
            Font = new Font("Segoe UI Semilight", 9.75f);
            StartIndex = 0;
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            int Curve = 2;

            G.SmoothingMode = SmoothingMode.HighQuality;

            switch (ColorScheme)
            {
                case ColorSchemes.Dark:
                    G.Clear(Color.FromArgb(50, 50, 50));
                    G.DrawLine(new Pen(Color.White, 2), new Point(Width - 18, 10), new Point(Width - 14, 14));
                    G.DrawLine(new Pen(Color.White, 2), new Point(Width - 14, 14), new Point(Width - 10, 10));
                    G.DrawLine(new Pen(Color.White), new Point(Width - 14, 15), new Point(Width - 14, 14));
                    break;
                case ColorSchemes.Light:
                    G.Clear(Color.White);
                    G.DrawLine(new Pen(Color.FromArgb(100, 100, 100), 2), new Point(Width - 18, 10), new Point(Width - 14, 14));
                    G.DrawLine(new Pen(Color.FromArgb(100, 100, 100), 2), new Point(Width - 14, 14), new Point(Width - 10, 10));
                    G.DrawLine(new Pen(Color.FromArgb(100, 100, 100)), new Point(Width - 14, 15), new Point(Width - 14, 14));
                    break;
            }
            G.DrawRectangle(new Pen(Color.FromArgb(100, 100, 100)), new Rectangle(0, 0, Width - 1, Height - 1));


            try
            {
                switch (ColorScheme)
                {
                    case ColorSchemes.Dark:
                        G.DrawString(Text, Font, Brushes.White, new Rectangle(7, 0, Width - 1, Height - 1), new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Near
                        });
                        break;
                    case ColorSchemes.Light:
                        G.DrawString(Text, Font, Brushes.Black, new Rectangle(7, 0, Width - 1, Height - 1), new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Near
                        });
                        break;
                }
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

