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
using System;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Tech
{
    public class TLFButton : ThemeControl
    {

        public TLFButton()
        {
            AllowTransparent();
        }

        public override void PaintHook()
        {
            G.Clear(Color.FromArgb(26, 92, 152));
            Pen bC1 = new Pen(Color.FromArgb(31, 52, 73));
            Pen bC2 = new Pen(Color.FromArgb(16, 90, 156));
            SolidBrush bBC = new SolidBrush(Color.FromArgb(14, 66, 112));
            G.FillRectangle(bBC, ClientRectangle);
            DrawText(HorizontalAlignment.Center, Color.FromArgb(7, 38, 81), 1, 1);

            DrawText(HorizontalAlignment.Center, Color.FromArgb(182, 217, 244), 0);


            DrawText(HorizontalAlignment.Center, Color.FromArgb(7, 38, 81), 1, 1);

            DrawText(HorizontalAlignment.Center, Color.FromArgb(182, 217, 244), 0);

            if (MouseState == State.MouseNone)
            {
                DrawGradient(Color.FromArgb(100, 255, 255, 255), Color.FromArgb(50, 255, 255, 255), 0, 0, Width, Convert.ToInt32(Height / 2), 90);
            }
            else if (MouseState == State.MouseDown)
            {
                DrawGradient(Color.FromArgb(75, 255, 255, 255), Color.FromArgb(25, 255, 255, 255), 0, 0, Width, Convert.ToInt32(Height / 2), 90);
            }
            else if (MouseState == State.MouseOver)
            {
                DrawGradient(Color.FromArgb(125, 255, 255, 255), Color.FromArgb(75, 255, 255, 255), 0, 0, Width, Convert.ToInt32(Height / 2), 90);
            }

            DrawBorders(bC1, bC2, ClientRectangle);
        }
    }

}

