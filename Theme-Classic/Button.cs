// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Classic
{
    public class ClassicButton : ThemeControl151
    {
        private Bloom[] Bloom;
        private LinearGradientBrush L1;
        private Rectangle R1;
        public ClassicButton()
        {
            Bloom = new Bloom[]{
            new Bloom("Border", Color.Black),
            new Bloom("Highlight", Color.FromArgb(35, 35, 35)),
            new Bloom("Background", Color.FromArgb(24, 24, 24)),
            new Bloom("Shadow", Color.FromArgb(100, Color.Black)),
            new Bloom("Text Color", Color.FromArgb(128, Color.White))
        };
            Font = new Font("Verdana", 7f);
            Size = new Size(97, 23);
        }


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.FillRectangle(Bloom[2].Brush, ClientRectangle);
            DrawBorders(Bloom[0].Pen, ClientRectangle);
            DrawBorders(Bloom[1].Pen, 1, 1, Width - 2, Height - 2);
            R1 = new Rectangle(2, 2, Width - 4, Height - 4);
            switch (State)
            {
                case MouseState.Over:
                    L1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(100, 0, 156, 255), Color.Transparent, 270);
                    G.FillRectangle(L1, R1);
                    G.FillRectangle(Bloom[3].Brush, 1, 7, Width - 2, Height - 7);
                    break;
                case MouseState.Down:
                    L1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(50, 0, 156, 255), Color.Transparent, 90);
                    G.FillRectangle(L1, R1);
                    G.FillRectangle(Bloom[3].Brush, 1, 7, Width - 2, Height - 7);
                    break;
                case MouseState.None:
                    G.FillRectangle(Bloom[3].Brush, 1, 8, Width - 2, Height - 8);
                    break;
            }
            DrawText(Bloom[4].Brush, HorizontalAlignment.Center, 0, 0);
        }
    }

}

