// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Drone
{
    public class DroneGroupBox : ThemeContainer153
    {

        public DroneGroupBox()
        {
            ControlMode = true;
            Header = 26;
        }


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(24, 24, 24));

            DrawGradient(Color.FromArgb(0, 55, 90), Color.FromArgb(0, 70, 128), 5, 5, Width - 10, 26);
            G.DrawLine(new Pen(Color.FromArgb(20, Color.White)), 7, 7, Width - 8, 7);

            DrawBorders(Pens.Black, 5, 5, Width - 10, 26, 1);
            DrawBorders(new Pen(Color.FromArgb(36, 36, 36)), 5, 5, Width - 10, 26);

            //???
            DrawBorders(new Pen(Color.FromArgb(8, 8, 8)), 5, 34, Width - 10, Height - 39, 1);
            DrawBorders(new Pen(Color.FromArgb(36, 36, 36)), 5, 34, Width - 10, Height - 39);

            DrawBorders(new Pen(Color.FromArgb(36, 36, 36)), 1);
            DrawBorders(Pens.Black);

            G.DrawLine(new Pen(Color.FromArgb(48, 48, 48)), 1, 1, Width - 2, 1);

            DrawText(Brushes.White, HorizontalAlignment.Left, 9, 5);
        }
    }


}


