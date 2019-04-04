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
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.GTheme
{
    public class GButton : ThemeControl
    {

        private Pen P1;
        private Pen P3;
        private Color C1;
        private Color C2;

        private Color B1;
        public GButton()
        {
            P3 = new Pen(Color.FromArgb(92, 92, 92));
            P1 = new Pen(Color.FromArgb(31, 31, 31));
            C1 = Color.FromArgb(25, 25, 25);
            C2 = Color.FromArgb(43, 43, 43);
            //above
            B1 = Color.FromArgb(204, 204, 204);
        }


        public override void PaintHook()
        {
            if (MouseState == State.MouseDown)
            {
                DrawGradient(C1, C2, 0, 0, Width, Height, 90);
            }
            else
            {
                DrawGradient(C2, C1, 0, 0, Width, Height, 90);
            }
            DrawText(HorizontalAlignment.Center, B1, 0);
            DrawIcon(HorizontalAlignment.Left, 0);

            DrawBorders(P1, P3, ClientRectangle);
            DrawCorners(Color.FromArgb(25, 25, 25), ClientRectangle);
        }

    }


}


