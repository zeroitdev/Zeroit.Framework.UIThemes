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
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Purity
{
    public class PurityxButton : ThemeControl
    {

        public override void PaintHook()
        {
            switch (MouseState)
            {
                case State.MouseNone:
                    G.Clear(Color.Red);
                    DrawGradient(Color.FromArgb(62, 62, 62), Color.FromArgb(38, 38, 38), 0, 0, Width, Height, 90);
                    break;
                case State.MouseOver:
                    G.Clear(Color.Red);
                    DrawGradient(Color.FromArgb(62, 62, 62), Color.FromArgb(38, 38, 38), 0, 0, Width, Height, 90);
                    break;
                case State.MouseDown:
                    G.Clear(Color.DarkRed);
                    DrawGradient(Color.FromArgb(38, 38, 38), Color.FromArgb(62, 62, 62), 0, 0, Width, Height, 90);
                    break;
            }

            DrawBorders(Pens.Black, Pens.DimGray, ClientRectangle);
            // Form Border
            DrawCorners(Color.Black, ClientRectangle);
            // Clean Corners
            DrawText(HorizontalAlignment.Center, Color.Red, 0);
        }
    }

}

