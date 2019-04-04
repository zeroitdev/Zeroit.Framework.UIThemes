// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ControlPanel.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Booster
{
    public class BoosterControlpanel : ThemeContainer154
    {

        public BoosterControlpanel()
        {
            ControlMode = true;
            Transparent = true;
            BackColor = Color.Transparent;
            Header = 20;
        }

        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(51, 51, 51));
            DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(52, 0, 0), 0, 0, Width, 20);

            G.DrawLine(new Pen(Color.FromArgb(92, 92, 92)), 0, 21, Width, 21);
            G.DrawLine(Pens.Black, 0, 20, Width, 20);
            DrawBorders(Pens.Black);

            DrawText(Brushes.White, HorizontalAlignment.Left, 8, 3);

            DrawBorders(new Pen(Color.FromArgb(92, 92, 92)), 1);
        }
    }


}

