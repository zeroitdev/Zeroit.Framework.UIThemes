// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ControlButton.cs" company="Zeroit Dev Technologies">
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
    public class PaladinControlButton : ThemeControl154
    {
        public PaladinControlButton()
        {
            Size = new Size(22, 21);
            MinimumSize = new Size(19, 20);
            MaximumSize = new Size(24, 23);
        }


        protected override void ColorHook()
        {
        }


        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(180, Color.Gainsboro));

            LinearGradientBrush HeaderLGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height / 2), Color.FromArgb(220, 220, 220), Color.FromArgb(180, 180, 180), 90);
            G.FillRectangle(HeaderLGB, 0, 0, Width, Height / 2);

            DrawBorders(new Pen(new SolidBrush(Color.FromArgb(130, 130, 130))), 1, 1, Width - 2, Height - 3);
            // up


            if (State == MouseState.Over)
            {
                G.Clear(Color.FromArgb(190, Color.Gainsboro));

                LinearGradientBrush HeaderLGB1 = new LinearGradientBrush(new Rectangle(0, 0, Width, Height / 2), Color.FromArgb(230, 230, 230), Color.FromArgb(190, 190, 190), 90);
                G.FillRectangle(HeaderLGB1, 0, 0, Width, Height / 2);

                DrawBorders(new Pen(new SolidBrush(Color.FromArgb(140, 140, 140))), 1, 1, Width - 2, Height - 3);
                // up

            }
            else if (State == MouseState.Down)
            {
                G.Clear(Color.FromArgb(175, Color.Gainsboro));

                LinearGradientBrush HeaderLGB1 = new LinearGradientBrush(new Rectangle(0, 0, Width, Height / 2), Color.FromArgb(215, 215, 215), Color.FromArgb(175, 175, 175), 90);
                G.FillRectangle(HeaderLGB1, 0, 0, Width, Height / 2);

                DrawBorders(new Pen(new SolidBrush(Color.FromArgb(125, 125, 125))), 1, 1, Width - 2, Height - 3);
                // up


            }

            DrawCorners(Color.FromArgb(160, 160, 160), 1, 1, Width - 2, Height - 3);
            DrawCorners(Color.FromArgb(200, 200, 200), 0, 0, Width, Height - 1);

            DrawText(new SolidBrush(Color.White), HorizontalAlignment.Center, 1, 1);
            DrawText(new SolidBrush(Color.Black), HorizontalAlignment.Center, 0, 0);
        }
    }

}

