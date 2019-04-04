// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="MiddleBar.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.GameBooster
{
    public class GameBoosterMiddleBar : ThemeControl154
    {

        public GameBoosterMiddleBar()
        {
            LockHeight = 31;
            Height = 31;
        }
        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(54, 54, 54));
            G.DrawLine(new Pen(Color.FromArgb(24, 24, 24)), 0, 0, Width, 0);
            G.DrawLine(new Pen(Color.FromArgb(69, 69, 69)), 0, 1, Width, 1);
            G.DrawLine(new Pen(Color.FromArgb(24, 24, 24)), 0, Height - 2, Width, Height - 2);
            G.DrawLine(new Pen(Color.FromArgb(69, 69, 69)), 0, Height - 1, Width, Height - 1);
        }
    }


}


