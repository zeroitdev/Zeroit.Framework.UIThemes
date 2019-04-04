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
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Jasta
{
    public class Jbutton : ThemeControl151
    {

        Color Color1;
        Brush Color2;
        Pen Color3;
        Color Color4;
        public Jbutton()
        {
            SetColor("BackColor", Color.FromArgb(15, 15, 15));
            SetColor("Text", Color.White);
            SetColor("Border", Color.FromArgb(30, 30, 30));
            SetColor("MouseOverBack", Color.FromArgb(20, 20, 20));
        }

        protected override void ColorHook()
        {
            Color1 = GetColor("BackColor");
            Color2 = new SolidBrush(GetColor("Text"));
            Color3 = new Pen(GetColor("Border"));
            Color4 = GetColor("MouseOverBack");
        }

        protected override void PaintHook()
        {
            G.Clear(Color1);
            DrawText(Color2, HorizontalAlignment.Center, 0, 0);
            DrawBorders(Color3);

            switch (State)
            {
                case MouseState.Over:
                    G.Clear(Color4);
                    DrawText(Color2, HorizontalAlignment.Center, 0, 0);
                    DrawBorders(Color3);

                    break;
            }

        }
    }

}


