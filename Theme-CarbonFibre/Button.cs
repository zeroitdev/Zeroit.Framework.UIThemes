﻿// ***********************************************************************
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

namespace Zeroit.Framework.UIThemes.CarbonFibre
{
    public class CarbonFiberButton : ThemeControl154
    {
        #region "Properties"
        public CarbonFiberButton()
        {
            this.Size = new Size(142, 29);
        }
        protected override void ColorHook()
        {
            // blah blah blah waste of time !!
        }
        #endregion
        #region "Color Of Control"

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(22, 22, 22));

            LinearGradientBrush Header = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(25, 25, 25), Color.FromArgb(42, 42, 42), 270);
            G.FillRectangle(Header, new Rectangle(0, 0, Width - 1, Height - 1));


            HatchBrush HeaderHatch = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(35, Color.Black), Color.Transparent);
            G.FillRectangle(HeaderHatch, new Rectangle(0, 0, Width - 1, Height - 1));

            switch (State)
            {
                case MouseState.Over:
                    LinearGradientBrush Header1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(25, 25, 25), Color.FromArgb(50, 50, 50), 270);
                    G.FillRectangle(Header1, new Rectangle(0, 0, Width - 1, Height - 1));


                    HatchBrush HeaderHatch1 = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(35, Color.Black), Color.Transparent);
                    G.FillRectangle(HeaderHatch1, new Rectangle(0, 0, Width - 1, Height - 1));

                    break;
                case MouseState.Down:
                    LinearGradientBrush Header2 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(25, 25, 25), Color.FromArgb(35, 35, 35), 270);
                    G.FillRectangle(Header2, new Rectangle(0, 0, Width - 1, Height - 1));


                    HatchBrush HeaderHatch2 = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(35, Color.Black), Color.Transparent);
                    G.FillRectangle(HeaderHatch2, new Rectangle(0, 0, Width - 1, Height - 1));
                    break;
            }

            G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(6, 6, 6)), new Rectangle(-1, -1, Width - 1, Height - 1), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });
            G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(255, 150, 0)), new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });

            DrawBorders(Pens.Black);
            DrawBorders(new Pen(Color.FromArgb(32, 32, 32)), 1);

            DrawCorners(Color.FromArgb(22, 22, 22), 1);
            DrawCorners(Color.FromArgb(22, 22, 22));
        }
        #endregion
    }

}


