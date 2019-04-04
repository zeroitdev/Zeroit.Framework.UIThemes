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
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Influx
{
    public class InfluxButton : ThemeControl154
    {

        Color ButtonColor;
        Brush TextBrush;

        Pen Border;
        public InfluxButton()
        {
            Width = 120;
            Height = 22;
            SetColor("Button", Color.FromArgb(77, 77, 77));
            SetColor("Text", Color.FromArgb(229, 229, 229));
            SetColor("Border", Color.FromArgb(60, 60, 60));
        }

        protected override void ColorHook()
        {
            ButtonColor = GetColor("Button");
            TextBrush = GetBrush("Text");
            Border = GetPen("Border");
        }

        protected override void PaintHook()
        {
            G.Clear(ButtonColor);
            G.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle ButtonTop = new Rectangle(1, 1, Width - 2, Convert.ToInt32((Height / 2) - 1));
            Rectangle ButtonBottom = new Rectangle(1, Convert.ToInt32(Height / 2), Width - 2, Convert.ToInt32((Height / 2) - 1));
            Pen BorderPen = null;
            Color TopGradient1 = default(Color);
            Color TopGradient2 = default(Color);
            Color Bottomgradient1 = default(Color);
            Color BottomGradient2 = default(Color);
            switch (State)
            {
                case MouseState.None:
                    BorderPen = new Pen(new SolidBrush(Color.FromArgb(60, 60, 60)));
                    TopGradient1 = Color.FromArgb(82, 82, 82);
                    TopGradient2 = Color.FromArgb(78, 78, 78);
                    Bottomgradient1 = Color.FromArgb(66, 66, 66);
                    BottomGradient2 = Color.FromArgb(73, 73, 73);
                    break;
                case MouseState.Over:
                    BorderPen = new Pen(new SolidBrush(Color.FromArgb(62, 62, 62)));
                    TopGradient1 = Color.FromArgb(93, 93, 93);
                    TopGradient2 = Color.FromArgb(84, 84, 84);
                    Bottomgradient1 = Color.FromArgb(71, 71, 71);
                    BottomGradient2 = Color.FromArgb(77, 77, 77);
                    break;
                case MouseState.Down:
                    BorderPen = new Pen(new SolidBrush(Color.FromArgb(67, 67, 67)));
                    TopGradient1 = Color.FromArgb(111, 111, 111);
                    TopGradient2 = Color.FromArgb(101, 101, 101);
                    Bottomgradient1 = Color.FromArgb(84, 84, 84);
                    BottomGradient2 = Color.FromArgb(90, 90, 90);
                    break;
            }
            LinearGradientBrush TopGradient = new LinearGradientBrush(ButtonTop, TopGradient1, TopGradient2, 90);
            G.FillRectangle(TopGradient, ButtonTop);
            LinearGradientBrush BottomGradient = new LinearGradientBrush(ButtonBottom, Bottomgradient1, BottomGradient2, 90);
            G.FillRectangle(BottomGradient, ButtonBottom);
            //Draw border
            G.DrawPath(BorderPen, CreateRound(new Rectangle(0, 0, Width - 1, Height - 1), 2));
            G.DrawPath(new Pen(Color.FromArgb(84, 84, 84)), CreateRound(new Rectangle(1, 1, Width - 3, Height - 3), 2));
            //Draw text
            DrawText(TextBrush, HorizontalAlignment.Center, 0, 0);
        }
    }


}


