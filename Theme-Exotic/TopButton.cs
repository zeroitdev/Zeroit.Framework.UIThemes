// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TopButton.cs" company="Zeroit Dev Technologies">
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


namespace Zeroit.Framework.UIThemes.Exotic
{
    public class ExoticTopButton : ThemeControl
    {
        public ExoticTopButton()
        {
            Size = new Size(11, 5);
        }
        public override void PaintHook()
        {
            switch (MouseState)
            {
                case State.MouseNone:
                    DrawGradient(Color.FromArgb(240, 248, 250), Color.FromArgb(0, 0, 0), 0, 0, Width, Height, 90);
                    break;
                case State.MouseOver:
                    DrawGradient(Color.FromArgb(240, 248, 250), Color.FromArgb(0, 0, 0), 0, 0, Width, Height, 90);
                    break;
                case State.MouseDown:
                    DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(0, 0, 0), 0, 0, Width, Height, 90);
                    break;
            }
            DrawCorners(Color.FromArgb(240, 248, 250), ClientRectangle);
            DrawBorders(Pens.Black, Pens.AliceBlue, ClientRectangle);
        }
    }


}


