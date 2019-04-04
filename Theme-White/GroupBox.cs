// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.WhitePure
{
    public class WhiteGroupBox : ThemeContainer153
    {

        public WhiteGroupBox()
        {
            ControlMode = true;
            BackColor = Color.FromArgb(225, 225, 225);

            SetColor("Grad1", 225, 225, 225);
            SetColor("Grad2", 185, 185, 185);
            SetColor("Grad3", 80, Color.White);
            SetColor("Transp", Color.Transparent);
            SetColor("Text", Color.FromArgb(0, 133, 157));
            SetColor("BG", Color.FromArgb(41, 41, 41));
            SetColor("Border1", 225, 225, 225);
            SetColor("Border2", 150, 150, 150);


            this.Size = new Size(200, 150);

        }

        Color C1;
        Color C2;
        Color C4;
        Pen P1;
        Pen P2;

        Brush B1;
        protected override void ColorHook()
        {
            C1 = GetColor("Grad1");
            C2 = GetColor("Grad2");
            C4 = GetColor("Transp");

            B1 = new SolidBrush(GetColor("Text"));

            P1 = new Pen(GetColor("Border1"));
            P2 = new Pen(GetColor("Border2"));
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);

            DrawGradient(C2, C1, 0, 0, Width, 20);
            HatchBrush DarkUp = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.Transparent, Color.FromArgb(50, Color.FromArgb(75, 75, 75)));
            G.FillRectangle(DarkUp, new Rectangle(0, 0, ClientRectangle.Width, 20));

            G.DrawLine(P1, 0, 20, Width, 20);
            G.DrawLine(P2, 0, 21, Width, 21);

            DrawBorders(P1);
            DrawBorders(P2, 1);


            DrawText(Brushes.DarkBlue, HorizontalAlignment.Center, 0, 0);
        }
    }

}

