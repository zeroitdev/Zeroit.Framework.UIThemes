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
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace Zeroit.Framework.UIThemes.Sasi
{
    public class SasisButton : ThemeControl154
    {
        Color Buttoncolor;
        Brush Textcolor;

        Pen Border;
        public SasisButton()
        {
            SetColor("Button", Color.FromArgb(218, 240, 139));
            SetColor("Text", Color.FromArgb(49, 51, 48));
            SetColor("Border", Color.White);

        }

        protected override void ColorHook()
        {
            Buttoncolor = GetColor("Button");
            Textcolor = GetBrush("Text");
            Border = GetPen("Border");

        }

        protected override void PaintHook()
        {
            G.Clear(Buttoncolor);


            DrawCorners(BackColor);
            switch (State)
            {
                case MouseState.None:

                    HatchBrush HB = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(30, Color.White), Color.Transparent);
                    G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                    G.FillRectangle(HB, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(Textcolor, HorizontalAlignment.Center, 0, 0);

                    break;
                case MouseState.Over:

                    HatchBrush HB1 = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(30, Color.White), Color.Transparent);
                    G.FillRectangle(new SolidBrush(Color.FromArgb(199, 211, 229)), new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                    G.FillRectangle(HB1, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(Textcolor, HorizontalAlignment.Center, 0, 0);
                    break;
                case MouseState.Down:

                    HatchBrush HB2 = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(30, Color.White), Color.Transparent);
                    G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Black)), new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                    G.FillRectangle(HB2, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(Textcolor, HorizontalAlignment.Center, 0, 0);
                    break;
            }
        }
    }


}

