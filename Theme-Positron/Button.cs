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

namespace Zeroit.Framework.UIThemes.Positron
{

    public class PositronButton : ThemeControl154
    {
        private Color TG;
        private Color BG;
        private Brush TC;
        private Brush H;
        private Pen B;
        private Pen IB;
        public PositronButton()
        {
            SetColor("TopG", Color.FromArgb(220, 220, 220));
            SetColor("BottomG", Color.FromArgb(200, 200, 200));
            SetColor("Text", Color.FromArgb(100, 100, 100));
            SetColor("Border", Color.FromArgb(150, 150, 150));
            SetColor("Inside", Color.FromArgb(200, 200, 200));
            SetColor("Hover", Color.FromArgb(210, 210, 210));
            Size = new Size(100, 30);
        }
        protected override void ColorHook()
        {
            TG = GetColor("TopG");
            BG = GetColor("BottomG");
            TC = GetBrush("Text");
            B = GetPen("Border");
            IB = GetPen("Inside");
            H = GetBrush("Hover");
        }
        protected override void PaintHook()
        {
            G.Clear(TG);
            switch (State)
            {
                case MouseState.None:
                    LinearGradientBrush LGB1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), TG, BG, 90f);
                    G.FillRectangle(LGB1, new Rectangle(2, 2, Width - 4, Height - 4));
                    break; // TODO: might not be correct. Was : Exit Select

                    break;
                case MouseState.Over:
                    G.FillRectangle(H, new Rectangle(2, 2, Width - 4, Height - 4));
                    break; // TODO: might not be correct. Was : Exit Select

                    break;
                case MouseState.Down:
                    LinearGradientBrush LGB3 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), BG, TG, 90f);
                    G.FillRectangle(LGB3, new Rectangle(2, 2, Width - 4, Height - 4));
                    break; // TODO: might not be correct. Was : Exit Select

                    break;
            }
            DrawBorders(IB);
            DrawText(TC, HorizontalAlignment.Center, 0, 0);
            G.DrawRectangle(B, new Rectangle(1, 1, Width - 3, Height - 3));
        }
    }
}

