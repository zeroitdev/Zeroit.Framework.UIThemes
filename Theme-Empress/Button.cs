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

namespace Zeroit.Framework.UIThemes.Empress
{
    public class EmpressButton : ThemeControl154
    {

        Color ButtonColor;
        Color InnerBorder;
        Brush TextColor;

        Pen border;
        public EmpressButton()
        {
            SetColor("ButtonColor", ColorConverter.HexToColor("#A12F35"));
            SetColor("Text", Color.Black);
            SetColor("InnerBorder", Color.FromArgb(55, Color.White));
        }
        protected override void ColorHook()
        {
            ButtonColor = GetColor("ButtonColor");
            TextColor = GetBrush("Text");
            InnerBorder = GetColor("InnerBorder");
            border = Pens.Black;
        }

        protected override void PaintHook()
        {
            G.Clear(ButtonColor);
            switch (State)
            {
                case MouseState.None:
                    LinearGradientBrush ButtonDefinition = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(5, Color.White), Color.FromArgb(55, Color.Black), 90);
                    G.FillRectangle(new SolidBrush(ButtonColor), new Rectangle(0, 0, Width - 1, Height - 1));
                    G.FillRectangle(ButtonDefinition, ButtonDefinition.Rectangle);
                    G.DrawRectangle(border, new Rectangle(0, 0, Width - 1, Height - 1));
                    break;
                case MouseState.Over:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.PeachPuff)), new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawRectangle(border, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                    break;
                case MouseState.Down:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Violet)), new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawRectangle(border, new Rectangle(0, 0, Width - 1, Height - 1));
                    break;
            }
            G.DrawRectangle(new Pen(InnerBorder), new Rectangle(1, 1, Width - 3, Height - 3));
            DrawText(TextColor, HorizontalAlignment.Center, 0, 0);


            HatchBrush BodyHatch = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(20, Color.Black), Color.Transparent);
            G.FillRectangle(BodyHatch, new Rectangle(0, 0, Width - 1, Height - 1));
        }
    }


}


