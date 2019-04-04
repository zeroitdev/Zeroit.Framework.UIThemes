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
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Nameless
{
    public class NamelessGroupBox : ThemeContainer154
    {
        public NamelessGroupBox()
        {
            ControlMode = true;
            Header = 22;
        }
        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(30, Color.DimGray));
            G.SmoothingMode = SmoothingMode.HighQuality;

            G.DrawLine(new Pen(Color.FromArgb(120, 120, 120)), 0, 23, Width, 23);



            G.DrawRectangle((new Pen(new SolidBrush(Color.FromArgb(120, 120, 120)))), new Rectangle(0, 0, Width - 1, Height - 1));


            LinearGradientBrush HeaderLGB = new LinearGradientBrush(new Rectangle(2, 2, Width - 5, 11), Color.FromArgb(150, 150, 150), Color.FromArgb(50, 50, 50), 90);
            G.FillRectangle(HeaderLGB, new Rectangle(2, 2, Width - 5, 8));

            //'

            DrawBorders(new Pen(Color.FromArgb(130, 130, 130)), new Rectangle(3, 3, Width - 6, 18));


            DrawText(new SolidBrush(Color.White), HorizontalAlignment.Center, 0, 0);

        }
    }


}