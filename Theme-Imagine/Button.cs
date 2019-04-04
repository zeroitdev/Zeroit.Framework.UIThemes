// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Newer
{
    public class ImagineButton : ThemeControl154
    {

        Color BG;
        public ImagineButton()
        {
            SetColor("BG", 12, 27, 74);
            BackColor = GetColor("BG");
        }

        protected override void ColorHook()
        {
            BG = GetColor("BG");
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            if (State == MouseState.Down)
            {
                DrawGradient(Color.FromArgb(25, Color.Black), Color.FromArgb(5, Color.White), ClientRectangle);
                DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
                DrawBorders(Pens.Black, ClientRectangle);
            }
            else if (State == MouseState.None)
            {
                DrawGradient(Color.FromArgb(25, Color.White), Color.FromArgb(5, Color.White), ClientRectangle);
                DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
                DrawBorders(Pens.Black, ClientRectangle);
            }
            else if (State == MouseState.Over)
            {
                DrawGradient(Color.FromArgb(40, Color.White), Color.FromArgb(10, Color.White), ClientRectangle);
                DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
                DrawBorders(Pens.Black, ClientRectangle);
            }
        }
    }

}

