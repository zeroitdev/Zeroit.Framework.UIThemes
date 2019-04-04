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

namespace Zeroit.Framework.UIThemes.Zeus
{
    public class ZeusButton : ThemeControl
    {

        #region " PaintHook "


        public override void PaintHook()
        {
            Color C1 = Color.FromArgb(38, 38, 38);
            Color C2 = Color.AliceBlue;
            Color C3 = Color.FromArgb(150, 255, 255);
            Pen P1 = Pens.Black;
            Pen P2 = Pens.AliceBlue;

            switch (MouseState)
            {

                case State.MouseNone:
                    G.Clear(C1);
                    DrawGradient(C2, C3, 0, 0, Width, Height, 90);
                    DrawText(HorizontalAlignment.Center, C1, 0);
                    DrawBorders(P1, P2, ClientRectangle);
                    break;
                case State.MouseOver:
                    G.Clear(C1);
                    DrawGradient(C2, C3, 0, 0, Width, Height, 90);
                    DrawText(HorizontalAlignment.Center, C1, 0);
                    DrawBorders(P2, P1, ClientRectangle);
                    break;
                case State.MouseDown:
                    G.Clear(C1);
                    DrawGradient(C2, C3, 0, 0, Width - 1, Height - 1, 90);
                    G.DrawRectangle(P1, 2, 2, Width - 5, Height - 5);
                    DrawText(HorizontalAlignment.Center, C1, 0);
                    DrawBorders(P1, P2, ClientRectangle);
                    break;
            }

        }

        #endregion

    }

}


