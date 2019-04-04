// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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

namespace Zeroit.Framework.UIThemes.SubSpace
{
    public class Subspacegroupbox : ThemeContainer154
    {
        public Subspacegroupbox()
        {
            ControlMode = true;
            Header = 18;
        }

        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(30, 30, 30));
            DrawBorders(Pens.Black);


            G.FillRectangle(Brushes.Black, 2, 2, Width - 4, 18);
            G.DrawLine(new Pen(Color.FromArgb(60, 60, 60)), 2, 18, Width - 2, 18);
            G.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.White)), 2, 2, Width - 4, 7);

            DrawGradient(Color.Black, Color.FromArgb(30, 30, 30), 2, 19, Width - 4, 8);


            DrawGradient(Color.FromArgb(30, 30, 30), Color.Black, 7, Height - 16, Width - 14, 8);

            DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(57, 57, 58), 0, Height - 8, Width / 2, Height - 4, 360);
            DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(57, 57, 58), Width / 2, Height - 8, Width / 2, Height - 4, 180);
            G.DrawLine(new Pen(Color.FromArgb(57, 57, 58)), Width / 2, Height - 8, Width / 2, Height);

            DrawText(Brushes.DodgerBlue, HorizontalAlignment.Left, 8, 1);

            //SideBoxes
            G.FillRectangle(Brushes.Black, 2, 19, 5, Height - 4);
            G.DrawLine(new Pen(Color.FromArgb(60, 60, 60)), 5, 19, 5, Height - 2);

            G.FillRectangle(Brushes.Black, Width - 6, 19, 10, Height - 4);
            G.DrawLine(new Pen(Color.FromArgb(60, 60, 60)), Width - 6, 19, Width - 6, Height - 2);
            //EndofSideboxes

            DrawBorders(new Pen(Color.FromArgb(60, 60, 60)), 1);
        }
    }

}




