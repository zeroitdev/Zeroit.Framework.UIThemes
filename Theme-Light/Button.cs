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

namespace Zeroit.Framework.UIThemes.Light
{

    public class LightButton : ThemeControl
    {
        public override void PaintHook()
        {
            DrawText(HorizontalAlignment.Center, Color.Lime, 0);
            this.ForeColor = Color.FromArgb(45, 45, 45);
            switch (MouseState)
            {
                case State.MouseNone:
                    HatchBrush hb = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(20, Color.White), Color.Transparent);
                    HatchBrush hb2 = new HatchBrush(HatchStyle.BackwardDiagonal, Color.FromArgb(35, Color.White), Color.Transparent);
                    G.FillRectangle(new SolidBrush(Color.FromArgb(196, 196, 196)), 0, 0, Width, Height);
                    DrawGradient(Color.FromArgb(196, 196, 196), Color.FromArgb(230, 230, 230), 0, 0, Width, 30, 270);
                    G.FillRectangle(hb, 1, 1, Width, Height);
                    DrawBorders(Pens.Gray, Pens.White, ClientRectangle);
                    DrawGradient(Color.FromArgb(50, Color.White), Color.Transparent, 1, 1, Width - 2, Height / 2 - 3, 270);
                    DrawText(HorizontalAlignment.Center, this.ForeColor, 0);
                    DrawCorners(this.Parent.BackColor, ClientRectangle);
                    break;
                case State.MouseDown:
                    HatchBrush hb1 = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(20, Color.White), Color.Transparent);
                    HatchBrush hb21 = new HatchBrush(HatchStyle.BackwardDiagonal, Color.FromArgb(35, Color.White), Color.Transparent);
                    G.FillRectangle(new SolidBrush(Color.FromArgb(196, 196, 196)), 0, 0, Width, Height);
                    DrawGradient(Color.FromArgb(196, 196, 196), Color.FromArgb(230, 230, 230), 0, 0, Width, 30, 270);
                    G.FillRectangle(hb1, 1, 1, Width, Height);
                    DrawBorders(Pens.Gray, Pens.LightGray, ClientRectangle);
                    DrawText(HorizontalAlignment.Center, this.ForeColor, 1);
                    DrawGradient(Color.FromArgb(60, Color.RoyalBlue), Color.Transparent, 0, 0, Width, Height, 90);
                    DrawGradient(Color.FromArgb(25, Color.Black), Color.Transparent, 0, 0, Width, Height, 270);
                    DrawGradient(Color.FromArgb(20, Color.White), Color.Transparent, 1, 1, Width - 2, Height / 2, 270);
                    DrawCorners(this.Parent.BackColor, ClientRectangle);
                    break;
                case State.MouseOver:
                    HatchBrush hb24 = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(20, Color.White), Color.Transparent);
                    HatchBrush hb22 = new HatchBrush(HatchStyle.BackwardDiagonal, Color.FromArgb(35, Color.White), Color.Transparent);
                    G.FillRectangle(new SolidBrush(Color.FromArgb(196, 196, 196)), 0, 0, Width, Height);
                    DrawGradient(Color.FromArgb(196, 196, 196), Color.FromArgb(230, 230, 230), 0, 0, Width, 30, 270);
                    G.FillRectangle(hb24, 1, 1, Width, Height);
                    DrawBorders(Pens.Gray, Pens.LightGray, ClientRectangle);
                    DrawText(HorizontalAlignment.Center, this.ForeColor, -1);
                    DrawGradient(Color.FromArgb(35, Color.RoyalBlue), Color.Transparent, 0, 0, Width, Height, 90);
                    DrawGradient(Color.FromArgb(35, Color.White), Color.Transparent, 1, 1, Width - 2, Height / 2 - 5, 270);
                    DrawCorners(this.Parent.BackColor, ClientRectangle);
                    break;
            }
            this.Cursor = Cursors.Hand;
            DrawCorners(this.Parent.BackColor, ClientRectangle);
        }
    }

}


