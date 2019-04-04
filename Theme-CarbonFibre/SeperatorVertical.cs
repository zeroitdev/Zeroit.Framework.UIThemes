// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="SeperatorVertical.cs" company="Zeroit Dev Technologies">
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
    public class CarbonFiberSeparatorVertical : ThemeControl154
    {
        #region "Properties"
        public CarbonFiberSeparatorVertical()
        {
            LockWidth = 10;
        }

        protected override void ColorHook()
        {

        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(22, 22, 22));

            G.FillRectangle(new SolidBrush(Color.FromArgb(6, 6, 6)), new Rectangle(4, 0, 1, Height - 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(32, 32, 32)), new Rectangle(5, 0, 1, Height - 1));
        }
        #endregion
    }
}


