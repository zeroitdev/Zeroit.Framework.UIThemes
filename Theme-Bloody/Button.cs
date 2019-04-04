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

namespace Zeroit.Framework.UIThemes.Bloody
{



    public class BloodyButton : ThemeControl154
    {
        Color Buttoncolor;
        Brush textcolor;
        Pen Border;

        ColorBlend bicouleur = new ColorBlend(2);
        public BloodyButton()
        {
            SetColor("Button", Color.WhiteSmoke);
            SetColor("Text", Color.White);
            SetColor("Border", Color.Black);

        }

        protected override void ColorHook()
        {
            Buttoncolor = GetColor("Button");
            textcolor = GetBrush("Text");
            Border = GetPen("Border");
        }

        protected override void PaintHook()
        {
            G.Clear(Buttoncolor);
            switch (State)
            {
                case MouseState.None:


                    bicouleur.Colors[0] = Color.FromArgb(255, 40, 0, 0);
                    //Rouge foncé
                    bicouleur.Colors[1] = Color.FromArgb(240, 90, 0, 0);
                    //Rouge
                    bicouleur.Positions[0] = 0;
                    bicouleur.Positions[1] = 1;
                    DrawGradient(bicouleur, new Rectangle(0, 0, Width, Height));
                    bicouleur.Colors[0] = Color.FromArgb(0, 0, 0, 0);
                    bicouleur.Colors[1] = Color.FromArgb(40, Color.White);
                    G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(textcolor, HorizontalAlignment.Center, 0, 0);

                    break;


                case MouseState.Over:

                    bicouleur.Colors[0] = Color.FromArgb(235, 40, 0, 0);
                    //Rouge foncé
                    bicouleur.Colors[1] = Color.FromArgb(200, 90, 0, 0);
                    //Rouge
                    bicouleur.Positions[0] = 0;
                    bicouleur.Positions[1] = 1;
                    DrawGradient(bicouleur, new Rectangle(0, 0, Width, Height));
                    bicouleur.Colors[0] = Color.FromArgb(0, 0, 0, 0);
                    bicouleur.Colors[1] = Color.FromArgb(40, Color.White);
                    G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(textcolor, HorizontalAlignment.Center, 0, 0);

                    break;

                case MouseState.Down:

                    bicouleur.Colors[0] = Color.FromArgb(205, 40, 0, 0);
                    //Rouge foncé
                    bicouleur.Colors[1] = Color.FromArgb(185, 90, 0, 0);
                    //Rouge
                    bicouleur.Positions[0] = 0;
                    bicouleur.Positions[1] = 1;
                    DrawGradient(bicouleur, new Rectangle(0, 0, Width, Height));
                    bicouleur.Colors[0] = Color.FromArgb(0, 0, 0, 0);
                    bicouleur.Colors[1] = Color.FromArgb(40, Color.White);
                    G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(textcolor, HorizontalAlignment.Center, 0, 0);

                    break;
            }
        }
    }
    
}


