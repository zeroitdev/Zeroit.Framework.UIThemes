// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;



namespace Zeroit.Framework.UIThemes.Atrocity
{

    public class aGroupBox : ThemeContainer153
    {

        public aGroupBox()
        {
            ControlMode = true;
            BackColor = Color.FromArgb(41, 41, 41);

            SetColor("Grad1", 60, 60, 60);
            SetColor("Grad2", 20, Color.White);
            SetColor("Grad3", 80, Color.White);
            SetColor("Transp", Color.Transparent);
            SetColor("Text", Color.FromArgb(0, 133, 157));
            SetColor("BG", Color.FromArgb(41, 41, 41));
            SetColor("Border1", Color.FromArgb(25, 25, 25));
            SetColor("Border2", Color.FromArgb(58, 58, 58));


            this.Size = new Size(200, 100);

        }

        Color C1;
        Color C2;
        Color C3;
        Color C4;
        Pen P1;
        Pen P2;

        Brush B1;
        protected override void ColorHook()
        {
            C1 = GetColor("Grad1");
            C2 = GetColor("Grad2");
            C3 = GetColor("Grad3");
            C4 = GetColor("Transp");

            B1 = new SolidBrush(GetColor("Text"));

            P1 = new Pen(GetColor("Border1"));
            P2 = new Pen(GetColor("Border2"));
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            DrawGradient(C1, BackColor, 0, 0, Width, 20);
            G.DrawLine(P2, 0, 20, Width + 2, 20);
            HatchBrush DarkDown = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.Transparent, Color.FromArgb(50, Color.Black));
            HatchBrush DarkUp = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.Transparent, Color.FromArgb(50, Color.Black));
            G.FillRectangle(DarkDown, new Rectangle(0, 0, ClientRectangle.Width, 20));
            G.FillRectangle(DarkUp, new Rectangle(0, 0, ClientRectangle.Width, 20));
            //DrawGradient(C3, C4, 0, -75, Width, 100)
            DrawText(B1, HorizontalAlignment.Center, 0, 0);
            DrawBorders(P2, 0);
            DrawBorders(P1, 1);
            DrawBorders(P2, 2);
        }
    }

}

