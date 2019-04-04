// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button2.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Origin
{
    public class SecondOriginButton : ThemeControl154
    {

        Color ButtonColorTop;
        Color ButtonColorBottom;
        Brush TextColor;

        Pen Border;
        public SecondOriginButton()
        {
            SetColor("Button Top", Color.Silver);
            SetColor("Button Bottom", Color.Gray);
            SetColor("Text", Color.White);
            SetColor("BorderColor", Color.White);
        }

        protected override void ColorHook()
        {
            ButtonColorTop = GetColor("Button Top");
            ButtonColorBottom = GetColor("Button Bottom");
            TextColor = GetBrush("Text");
            Border = GetPen("BorderColor");
        }

        protected override void PaintHook()
        {
            G.Clear(ButtonColorTop);
            switch (State)
            {
                case MouseState.None:
                    LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), ButtonColorTop, ButtonColorBottom, 90f);
                    G.FillRectangle(LGB, new Rectangle(0, 0, Width - 1, Height - 1));
                    G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Black)), new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                    DrawCorners(Color.White);
                    break;
                case MouseState.Over:
                    LinearGradientBrush LGB1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), ButtonColorTop, ButtonColorBottom, 90f);
                    G.FillRectangle(LGB1, new Rectangle(0, 0, Width - 1, Height - 1));
                    G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.White)), new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                    DrawCorners(Color.White);
                    break;
                case MouseState.Down:
                    //Dim LGB As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), ButtonColorTop, ButtonColorBottom, 90.0F)
                    //G.FillRectangle(LGB, New Rectangle(0, 0, Width - 1, Height - 1))
                    G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.White)), new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                    DrawCorners(Color.White);
                    break;
            }
        }
    }

}


