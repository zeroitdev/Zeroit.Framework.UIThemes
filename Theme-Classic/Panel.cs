// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Panel.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Classic
{
    public class ClassicPanel : ThemeContainerControl
    {
        private Bloom[] Bloom;
        private LinearGradientBrush L1;
        private LinearGradientBrush L2;
        private LinearGradientBrush L3;
        private Rectangle R1;
        private Rectangle R2;
        private Rectangle R3;
        public ClassicPanel()
        {
            Bloom = new Bloom[]{
            new Bloom("Border", Color.FromArgb(87, 87, 87)),
            new Bloom("Border #2", Color.Black),
            new Bloom("Color #1", Color.FromArgb(49, 49, 49)),
            new Bloom("Color #2", Color.FromArgb(35, 35, 35)),
            new Bloom("Shadow", Color.FromArgb(31, 31, 31))
        };
        }

        protected override void PaintHook()
        {
            G.Clear(Color.White);
            DrawBorders(Bloom[0].Pen, Bloom[1].Pen, ClientRectangle);
            DrawCorners(BackColor, ClientRectangle);
            R1 = new Rectangle(2, 2, Width - 4, Height - 4);
            R2 = new Rectangle(2, 2, 15, Height - 4);
            R3 = new Rectangle(2, 2, Width - 4, 15);
            L1 = new LinearGradientBrush(R1, Bloom[2].Value, Bloom[3].Value, 90);
            L2 = new LinearGradientBrush(R2, Bloom[4].Value, Color.Transparent, 0f);
            L3 = new LinearGradientBrush(R3, Bloom[4].Value, Color.Transparent, 90);
            G.FillRectangle(L1, R1);
            G.FillRectangle(L2, R2);
            G.FillRectangle(L3, R3);
        }
    }

}

