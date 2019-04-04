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

namespace Zeroit.Framework.UIThemes.Avatar
{


    public class AvatarButton : ThemeControl154
    {

        Color ButtonColorTop;
        Color ButtonColorBottom;
        Brush TextColor;

        Pen Border;
        public AvatarButton()
        {
            SetColor("Button Top", Color.FromArgb(255, 48, 48, 48));
            SetColor("Button Bottom", Color.FromArgb(200, 24, 24, 24));
            SetColor("Text", Color.DeepSkyBlue);
            SetColor("Border", Color.Black);
        }

        protected override void ColorHook()
        {
            ButtonColorTop = GetColor("Button Top");
            ButtonColorBottom = GetColor("Button Bottom");
            TextColor = GetBrush("Text");
            Border = GetPen("Border");
        }

        protected override void PaintHook()
        {
            G.Clear(ButtonColorTop);
            G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
            switch (State)
            {
                case MouseState.None:
                    LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(1, 1, Width - 2, Height - 2), ButtonColorTop, ButtonColorBottom, 90f);
                    G.FillRectangle(LGB, new Rectangle(1, 1, Width - 2, Height - 2));
                    DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                    break;
                case MouseState.Over:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(125, Color.Black)), new Rectangle(0, 0, Width, Height));
                    DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                    break;
                case MouseState.Down:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(200, Color.Black)), new Rectangle(0, 0, Width, Height));
                    DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                    break;
            }
        }
    }
    
}

