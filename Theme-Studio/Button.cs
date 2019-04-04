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
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Studio
{
    public class StudioButton : ThemeControl152
    {

        public StudioButton()
        {
            Transparent = true;
            BackColor = Color.Transparent;

            SetColor("DownGradient1", 45, 65, 95);
            SetColor("DownGradient2", 65, 85, 115);
            SetColor("NoneGradient1", 65, 85, 115);
            SetColor("NoneGradient2", 45, 65, 95);
            SetColor("Shine1", 30, Color.White);
            SetColor("Shine2A", 30, Color.White);
            SetColor("Shine2B", Color.Transparent);
            SetColor("Shine3", 20, Color.White);
            SetColor("TextShade", 50, Color.Black);
            SetColor("Text", Color.White);
            SetColor("Glow", 10, Color.White);
            SetColor("Border", 20, 40, 70);
            SetColor("Corners", 20, 40, 70);
        }

        private Color C1;
        private Color C2;
        private Color C3;
        private Color C4;
        private Color C5;
        private Color C6;
        private Color C7;
        private Pen P1;
        private Pen P2;
        private Pen P3;
        private SolidBrush B1;
        private SolidBrush B2;

        private SolidBrush B3;
        protected override void ColorHook()
        {
            C1 = GetColor("DownGradient1");
            C2 = GetColor("DownGradient2");
            C3 = GetColor("NoneGradient1");
            C4 = GetColor("NoneGradient2");
            C5 = GetColor("Shine2A");
            C6 = GetColor("Shine2B");
            C7 = GetColor("Corners");

            P1 = new Pen(GetColor("Shine1"));
            P2 = new Pen(GetColor("Shine3"));
            P3 = new Pen(GetColor("Border"));

            B1 = new SolidBrush(GetColor("TextShade"));
            B2 = new SolidBrush(GetColor("Text"));
            B3 = new SolidBrush(GetColor("Glow"));
        }


        protected override void PaintHook()
        {
            if (State == MouseState.Down)
            {
                DrawGradient(C1, C2, ClientRectangle, 90f);
            }
            else
            {
                DrawGradient(C3, C4, ClientRectangle, 90f);
            }

            G.DrawLine(P1, 1, 1, Width, 1);
            DrawGradient(C5, C6, 1, 1, 1, Height);
            DrawGradient(C5, C6, Width - 2, 1, 1, Height);
            G.DrawLine(P2, 1, Height - 2, Width, Height - 2);

            if (State == MouseState.Down)
            {
                DrawText(B1, HorizontalAlignment.Center, 2, 2);
                DrawText(B2, HorizontalAlignment.Center, 1, 1);
            }
            else
            {
                DrawText(B1, HorizontalAlignment.Center, 1, 1);
                DrawText(B2, HorizontalAlignment.Center, 0, 0);
            }

            if (State == MouseState.Over)
            {
                G.FillRectangle(B3, ClientRectangle);
            }

            DrawBorders(P3);
            DrawCorners(C7, 1, 1, Width - 2, Height - 2);

            DrawCorners(BackColor);
        }
    }

}


