// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 08-12-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 02-24-2018
// ***********************************************************************
// <copyright file="Alpha Theme.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Alpha
{

    /// <summary>
    /// Class AlphaButton.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.UIThemes.Alpha.ThemeControl" />
    public class AlphaButton : ThemeControl
    {


        /// <summary>
        /// Paints the hook.
        /// </summary>
        public override void PaintHook()
        {
            switch (MouseState)
            {
                case State.MouseNone:
                    G.Clear(Color.DimGray);
                    break;
                case State.MouseOver:
                    G.Clear(Color.Gray);
                    break;
                case State.MouseDown:
                    G.Clear(Color.Green);
                    break;
            }



            DrawText(HorizontalAlignment.Center, Color.Lime, 0);

            DrawBorders(Pens.Lime, Pens.DimGray, ClientRectangle);
            DrawCorners(BackColor, ClientRectangle);
        }
    }

    

}


