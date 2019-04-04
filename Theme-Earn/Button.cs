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
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Earn
{
    public class EarnButton : ThemeControl154
    {

        Color ButtonColor;
        Color c1;
        Color c2;
        Brush TextColor;

        Pen Border;
        public EarnButton()
        {
            SetColor("c1", Color.FromArgb(125, 205, 71));
            SetColor("c2", Color.FromArgb(84, 181, 54));
            SetColor("Text", Color.White);
        }

        protected override void ColorHook()
        {
            c1 = GetColor("c1");
            c2 = GetColor("c2");
            TextColor = GetBrush("Text");
        }

        protected override void PaintHook()
        {
            Pen P1 = Pens.Green;
            G.Clear(c1);
            switch (State)
            {
                case MouseState.None:
                    DrawGradient(c1, c2, 0, 0, Width, Height, 90);
                    DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                    DrawCorners(Color.FromArgb(240, 240, 240));
                    break;
                case MouseState.Over:
                    DrawGradient(c2, c1, 0, 0, Width, Height, 90);
                    DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                    DrawCorners(Color.FromArgb(240, 240, 240));
                    break;
                case MouseState.Down:
                    DrawGradient(c2, c2, 0, 0, Width, Height, 90);
                    DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                    DrawCorners(Color.FromArgb(240, 240, 240));
                    break;
            }
        }
    }


}

