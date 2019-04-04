// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Frog
{

    public class FrogButton : ThemeControl154
    {

        protected override void ColorHook()
        {
            SetColor("Border", Color.FromArgb(255, 200, 200, 200));
        }

        protected override void PaintHook()
        {
            Color Border = default(Color);
            Border = Color.FromArgb(160, GetColor("Border"));

            G.SmoothingMode = SmoothingMode.AntiAlias;
            G.Clear(Color.FromArgb(255, 60, 60, 60));
            LinearGradientBrush LGBNone = new LinearGradientBrush(new Point(0, 0), new Point(0, Height - 1), Color.FromArgb(255, 65, 65, 65), Color.FromArgb(255, 50, 50, 50));
            LinearGradientBrush LGBOver = new LinearGradientBrush(new Point(0, 0), new Point(0, Height - 1), Color.FromArgb(255, 65, 65, 65), Color.FromArgb(255, 40, 40, 40));
            LinearGradientBrush LGBDown = new LinearGradientBrush(new Point(0, 0), new Point(0, Height - 1), Color.FromArgb(255, 65, 65, 65), Color.FromArgb(255, 30, 30, 30));
            Point[] Polygon = null;
            Point[] Polygon2 = null;
            Polygon = new Point[] {
            new Point(0, 0),
            new Point(Width - 1, 0),
            new Point(Width - 1, Height - 7),
            new Point(Width - 2, Height - 6),
            new Point(Width - 3, Height - 5),
            new Point(Width - 4, Height - 4),
            new Point(Width - 5, Height - 3),
            new Point(Width - 6, Height - 2),
            new Point(Width - 7, Height - 1),
            new Point(0, Height - 1)
        };
            Polygon2 = new Point[] {
            new Point(1, 1),
            new Point(Width - 2, 1),
            new Point(Width - 2, Height - 7),
            new Point(Width - 8, Height - 2),
            new Point(1, Height - 2)
        };
            switch (State)
            {
                case MouseState.Down:
                    G.FillPolygon(LGBDown, Polygon);
                    break;
                case MouseState.None:
                    G.FillPolygon(LGBNone, Polygon);
                    break;
                case MouseState.Over:
                    G.FillPolygon(LGBOver, Polygon);
                    break;
            }
            G.DrawPolygon(Pens.Black, Polygon);
            G.DrawPolygon(new Pen(Border), Polygon2);
            DrawText(new SolidBrush(GetColor("Border")), HorizontalAlignment.Center, -2, 0);
        }
    }


}

