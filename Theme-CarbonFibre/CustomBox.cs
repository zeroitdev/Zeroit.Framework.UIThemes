// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="CustomBox.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.CarbonFibre
{
    public class CarbonFiberCustomBox : ThemeContainer154
    {
        #region "Properties"
        public CarbonFiberCustomBox()
        {
            ControlMode = true;
            Size = new Size(150, 100);
            BackColor = Color.FromArgb(22, 22, 22);
        }



        protected override void ColorHook()
        {
        }
        #endregion
        #region "Color of Control"
        protected override void PaintHook()
        {
            G.Clear(BackColor);
            G.FillRectangle(new SolidBrush(Color.FromArgb(22, 22, 22)), ClientRectangle);
            DrawBorders(new Pen(Color.FromArgb(6, 6, 6)), 1);
            DrawBorders(new Pen(Color.FromArgb(32, 32, 32)));
        }
        #endregion

    }
}


