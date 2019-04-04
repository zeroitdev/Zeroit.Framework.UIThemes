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
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.SimpleGray
{

    public class SimplyGrayButton : ThemeControl
    {

        Color Gr = Color.Gray;
        Color LG = Color.LightGray;
        Color O = Color.FromArgb(244, 244, 244);
        Color D = Color.FromArgb(183, 183, 183);
        Pen P = Pens.DarkGray;

        Pen PG = Pens.Gray;
        public SimplyGrayButton()
        {
            ForeColor = Color.Black;
        }


        public override void PaintHook()
        {
            G.Clear(Color.DarkGray);

            if (MouseState == State.MouseNone)
            {
                DrawGradient(LG, Gr, 0, 0, Width, Height, 90);
            }
            else if (MouseState == State.MouseOver)
            {
                DrawGradient(O, Gr, 0, 0, Width, Height, 90);
            }
            else if (MouseState == State.MouseDown)
            {
                DrawGradient(D, Gr, 0, 0, Width, Height, 90);
            }

            DrawText(HorizontalAlignment.Center, ForeColor, 0);

            DrawBorders(P, PG, ClientRectangle);
            DrawCorners(BackColor, ClientRectangle);
        }
    }

}

