// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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

namespace Zeroit.Framework.UIThemes.Paladin
{
    public class PaladinButton : ThemeControl154
    {


        protected override void ColorHook()
        {
        }


        protected override void PaintHook()
        {


            G.Clear(Color.FromArgb(205, Color.Gainsboro));

            LinearGradientBrush HeaderLGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height / 2), Color.FromArgb(230, 230, 230), Color.FromArgb(210, 210, 210), 90);
            G.FillRectangle(HeaderLGB, 0, 0, Width, Height / 2);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(215, 215, 215))), 1, Height - 1, Width - 2, Height - 1);



            DrawBorders(new Pen(new SolidBrush(Color.FromArgb(222, 222, 222))), 1, 1, Width - 2, Height - 3);
            // up
            DrawBorders(new Pen(new SolidBrush(Color.FromArgb(140, 140, 140))), 0, 0, Width, Height - 1);
            // sous


            DrawCorners(Color.FromArgb(180, 180, 180), 1, 1, Width - 2, Height - 3);
            DrawCorners(Color.FromArgb(200, 200, 200), 0, 0, Width, Height - 1);

            DrawText(new SolidBrush(Color.Silver), HorizontalAlignment.Center, 1, 1);
            DrawText(new SolidBrush(Color.Black), HorizontalAlignment.Center, 0, 0);

            if (State == MouseState.Over)
            {
                G.Clear(Color.FromArgb(210, Color.Gainsboro));
                LinearGradientBrush HeaderLGB1 = new LinearGradientBrush(new Rectangle(0, 0, Width, Height / 2), Color.FromArgb(235, 235, 235), Color.FromArgb(215, 215, 215), 90);
                G.FillRectangle(HeaderLGB1, 0, 0, Width, Height / 2);
                G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(222, 222, 222))), 1, Height - 1, Width - 2, Height - 1);
                DrawBorders(new Pen(new SolidBrush(Color.FromArgb(230, 230, 230))), 1, 1, Width - 2, Height - 3);
                // up
                DrawBorders(new Pen(new SolidBrush(Color.FromArgb(140, 140, 140))), 0, 0, Width, Height - 1);
                // sous


                DrawCorners(Color.FromArgb(180, 180, 180), 1, 1, Width - 2, Height - 3);
                DrawCorners(Color.FromArgb(200, 200, 200), 0, 0, Width, Height - 1);

                DrawText(new SolidBrush(Color.White), HorizontalAlignment.Center, 1, 1);
                DrawText(new SolidBrush(Color.Black), HorizontalAlignment.Center, 0, 0);


            }
            else if (State == MouseState.Down)
            {
                G.Clear(Color.FromArgb(200, Color.Gainsboro));
                LinearGradientBrush HeaderLGB1 = new LinearGradientBrush(new Rectangle(0, 0, Width, Height / 2), Color.FromArgb(225, 225, 225), Color.FromArgb(205, 205, 205), 90);
                G.FillRectangle(HeaderLGB1, 0, 0, Width, Height / 2);
                G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(210, 210, 210))), 1, Height - 1, Width - 2, Height - 1);


                DrawBorders(new Pen(new SolidBrush(Color.FromArgb(217, 217, 217))), 1, 1, Width - 2, Height - 3);
                // up
                DrawBorders(new Pen(new SolidBrush(Color.FromArgb(140, 140, 140))), 0, 0, Width, Height - 1);
                // sous


                DrawCorners(Color.FromArgb(180, 180, 180), 1, 1, Width - 2, Height - 3);
                DrawCorners(Color.FromArgb(200, 200, 200), 0, 0, Width, Height - 1);

                DrawText(new SolidBrush(Color.Silver), HorizontalAlignment.Center, 1, 1);
                DrawText(new SolidBrush(Color.Black), HorizontalAlignment.Center, 0, 0);

            }
        }
    }

}

