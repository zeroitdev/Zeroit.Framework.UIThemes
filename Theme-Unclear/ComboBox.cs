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

namespace Zeroit.Framework.UIThemes.UClear
{
    public class UnClearComboBox : ComboBox
    {
        public UnClearComboBox() : base()
        {
            DrawItem += ReplaceItem;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DrawMode = DrawMode.OwnerDrawFixed;
            BackColor = Color.FromArgb(235, 235, 235);
            ForeColor = Color.FromArgb(31, 31, 31);
            DropDownStyle = ComboBoxStyle.DropDownList;
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

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!(DropDownStyle == ComboBoxStyle.DropDownList))
                DropDownStyle = ComboBoxStyle.DropDownList;
            base.OnPaint(e);
            Graphics G = e.Graphics;
            LinearGradientBrush T = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(0, Color.Black), Color.FromArgb(22, Color.Black), 90);
            SolidBrush DrawCornersBrush = new SolidBrush(Color.FromArgb(20, 20, 20));
            DrawCornersBrush = (SolidBrush)ConversionFunctions.ToBrush(20, 20, 20);
            try
            {
                var _with1 = G;
                G.SmoothingMode = SmoothingMode.HighQuality;
                _with1.Clear(Color.FromArgb(20, 20, 20));
                _with1.FillRectangle(T, new Rectangle(0, 0, Width, Height));
                _with1.DrawLine(ConversionFunctions.ToPen(20, 20, 20), 0, 0, 0, 0);
                _with1.DrawRectangle(ConversionFunctions.ToPen(70, 70, 70), new Rectangle(1, 1, Width - 3, Height - 3));

                _with1.DrawLine(ConversionFunctions.ToPen(80, Color.White), new Point(Width - 22, 4), new Point(Width - 22, Height - 5));

                GraphicsPath K = new GraphicsPath();
                K.AddEllipse(-Width / 2, -Height, Width * 2, Convert.ToInt32(Height * 1.55));

                PathGradientBrush kK = new PathGradientBrush(K);
                kK.CenterColor = Color.Transparent;
                kK.SurroundColors = new Color[] { Color.FromArgb(30, Color.DimGray) };
                _with1.FillPath(kK, K);

                try
                {
                    if (_with1.MeasureString(Text, Font).Width > Width - 29)
                    {
                        _with1.DrawString(Items[SelectedIndex].ToString(), Font, ConversionFunctions.ToBrush(71, 71, 71), new RectangleF(3, 3, Width - 35, Height - 7));
                        _with1.DrawString("...", Font, ConversionFunctions.ToBrush(230, 230, 230), new Point(Width - 38, 3));
                    }
                    else
                    {
                        _with1.DrawString(Items[SelectedIndex].ToString(), Font, ConversionFunctions.ToBrush(71, 71, 71), new RectangleF(3, 3, Width - 35, Height - 7));
                    }
                }
                catch
                {
                    _with1.DrawString("...", Font, ConversionFunctions.ToBrush(230, 230, 230), new Point(3, 3));
                }

                DrawTriangle(Color.FromArgb(230, 230, 230), new Point(Width - 15, Height - 10), new Point(Width - 12, Height - 7), new Point(Width - 9, Height - 10), G);
                DrawTriangle(Color.FromArgb(60, 60, 60), new Point(Width - 15, Height - 12), new Point(Width - 12, Height - 8), new Point(Width - 9, Height - 12), G);
                DrawTriangle(Color.FromArgb(230, 230, 230), new Point(Width - 15, 9), new Point(Width - 12, 6), new Point(Width - 9, 9), G);
                DrawTriangle(Color.FromArgb(60, 60, 60), new Point(Width - 15, 11), new Point(Width - 12, 7), new Point(Width - 9, 11), G);

                _with1.DrawPath(ConversionFunctions.ToPen(120, Color.Black), RRM.RoundRect(0, 0, Width - 1, Height - 1, 2));
            }
            catch
            {
            }
        }
        public void ReplaceItem(System.Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            e.DrawBackground();
            try
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(ConversionFunctions.ToBrush(200, 200, 200), e.Bounds);
                }
                e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), e.Font, ConversionFunctions.ToBrush(71, 71, 71), e.Bounds);
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
    }

}


