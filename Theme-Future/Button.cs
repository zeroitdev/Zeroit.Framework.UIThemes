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

namespace Zeroit.Framework.UIThemes.Future
{

    public class FutureButton : ThemeControl152
    {


        private ColorBlend Blend;
        public FutureButton()
        {
            SetColor("Blend1", 28, 28, 28);
            SetColor("Blend2", 32, 32, 32);
            SetColor("Blend3", 24, 24, 24);
            SetColor("Border1A", 40, 40, 40);
            SetColor("Border1B", 48, 48, 48);
            SetColor("Border2", Color.Black);
            SetColor("Border3", 24, 24, 24);
            SetColor("Line1", 44, 44, 44);
            SetColor("TextShade", Color.Black);
            SetColor("Text", Color.White);
            SetColor("Corners", 40, 40, 40);

            Blend = new ColorBlend();
            Blend.Positions = new float[] {
            0f,
            0.5f,
            1f
        };
        }

        private Pen P1;
        private Pen P2;
        private Pen P3;
        private Pen P4;
        private SolidBrush B1;
        private SolidBrush B2;
        private Color C1;
        private Color C2;

        private Color C3;
        protected override void ColorHook()
        {
            C1 = GetColor("Border1A");
            C2 = GetColor("Border1B");
            C3 = GetColor("Corners");

            P2 = new Pen(GetColor("Border2"));
            P3 = new Pen(GetColor("Border3"));
            P4 = new Pen(GetColor("Line1"));

            B1 = new SolidBrush(GetColor("TextShade"));
            B2 = new SolidBrush(GetColor("Text"));

            Blend.Colors = new Color[] {
            GetColor("Blend1"),
            GetColor("Blend2"),
            GetColor("Blend3")
        };
        }


        private LinearGradientBrush GB1;
        protected override void PaintHook()
        {
            DrawGradient(Blend, ClientRectangle, 90f);

            GB1 = new LinearGradientBrush(ClientRectangle, C1, C2, 90f);
            P1 = new Pen(GB1);

            DrawBorders(P1);
            DrawBorders(P2, 1);

            if (State == MouseState.Down)
            {
                DrawBorders(P3, 2);

                DrawText(B1, HorizontalAlignment.Center, 2, 2);
                DrawText(B2, HorizontalAlignment.Center, 1, 1);
            }
            else
            {
                G.DrawLine(P4, 2, 2, Width - 3, 2);

                DrawText(B1, HorizontalAlignment.Center, 1, 1);
                DrawText(B2, HorizontalAlignment.Center, 0, 0);
            }

            DrawCorners(C3, 1, 1, Width - 2, Height - 2);
            DrawCorners(BackColor);
        }

    }


}
