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

namespace Zeroit.Framework.UIThemes.ETheme
{

    public class eButton : ThemeControl
    {
        public override void PaintHook()
        {
            switch (MouseState)
            {
                case State.MouseNone:
                    G.Clear(Color.FromArgb(49, 49, 49));
                    DrawGradient(Color.FromArgb(50, 50, 50), Color.FromArgb(40, 40, 40), ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height, 90);
                    break;
                case State.MouseDown:
                    G.Clear(Color.FromArgb(49, 49, 49));
                    DrawGradient(Color.FromArgb(40, 40, 40), Color.FromArgb(50, 50, 50), ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height, 90);
                    break;
                case State.MouseOver:
                    G.Clear(Color.FromArgb(49, 49, 49));
                    DrawGradient(Color.FromArgb(60, 60, 60), Color.FromArgb(50, 50, 50), ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height, 90);
                    break;
            }
            DrawText(HorizontalAlignment.Center, Color.Gray, 0);
            DrawBorders(Pens.Black, Pens.DimGray, ClientRectangle);
            DrawCorners(Color.FromArgb(53, 53, 53), ClientRectangle);

        }
    }


}

