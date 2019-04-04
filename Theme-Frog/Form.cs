// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Form.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Frog
{
    [ToolboxItem(false)]
    public class FrogForm : ThemeContainer154
    {

        protected override void ColorHook()
        {
            SetColor("Border", Color.FromArgb(255, 200, 200, 200));
        }

        protected override void PaintHook()
        {
            G.SmoothingMode = SmoothingMode.AntiAlias;

            int BarHeight = 20;

            Point[] Polygon = null;
            Point[] Polygon2 = null;

            Color Color2 = default(Color);
            Color Color = default(Color);
            Color DOES = default(Color);
            Color Border = default(Color);

            Border = Color.FromArgb(160, GetColor("Border"));

            Polygon = new Point[] {
            new Point(50, 2),
            new Point(Width - 51, 2),
            new Point(Width - 56, 18),
            new Point(55, 18)
        };
            Polygon2 = new Point[] {
            new Point((int)51.5, 3),
            new Point(Width - 52, 3),
            new Point(Width - 57, 17),
            new Point(56, 17)
        };

            DOES = Color.FromArgb(255, 60, 60, 60);
            Color = Color.FromArgb(255, 90, 90, 90);
            Color2 = Color.FromArgb(255, 100, 100, 100);

            LinearGradientBrush LGB = new LinearGradientBrush(new Point(0, 0), new Point(0, BarHeight), Color2, DOES);

            G.FillRectangle(new SolidBrush(DOES), new Rectangle(0, 0, Width, Height));
            G.FillRectangle(LGB, new Rectangle(0, 0, Width, BarHeight));
            G.DrawRectangle(Pens.Black, new Rectangle(0, 0, Width - 1, Height - 1));
            G.FillPolygon(new SolidBrush(DOES), Polygon);
            G.DrawPolygon(Pens.Black, Polygon);
            G.DrawPolygon(new Pen(Border), Polygon2);
            G.DrawRectangle(Pens.Black, new Rectangle(3, 20, Width - 7, Height - 24));
            G.DrawRectangle(new Pen(Border), new Rectangle(4, 21, Width - 9, Height - 26));
            Font TextFont = default(Font);
            TextFont = new Font("Verdana", 8);
            //G.DrawString(Text, TextFont, Brushes.Black, New Point((Width / 2) - (G.MeasureString(Text, TextFont).Width / 2), 3))
            G.DrawString(Text, TextFont, new SolidBrush(GetColor("Border")), new Point((int)(Width / 2) - (int)(G.MeasureString(Text, TextFont).Width / 2) + 1, 4));
        }
    }


}

