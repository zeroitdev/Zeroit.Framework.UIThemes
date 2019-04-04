// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ButtonA.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Storm
{

    public class StormButtonA : ThemeControl
    {


        private ColorBlend Blend = new ColorBlend();

        public StormButtonA()
        {
            Blend = new ColorBlend();


            SetColor("Blend1", 150, 150, 165);
            SetColor("Blend2", 120, 120, 140);
            SetColor("Blend3", 150, 150, 165);
            SetColor("Shine", 20, Color.White);
            SetColor("Glow", 30, Color.White);
            SetColor("Text", Color.White);
            SetColor("Light", 150, 150, 165);
            SetColor("Border", 70, 70, 90);

        }

        protected override void ColorHook()
        {
            B1 = new SolidBrush(GetColor("Shine"));
            B2 = new SolidBrush(GetColor("Glow"));
            B3 = new SolidBrush(GetColor("Text"));

            P1 = new Pen(GetColor("Light"));
            P2 = new Pen(GetColor("Border"));


        }

        private SolidBrush B1;
        private SolidBrush B2;
        private SolidBrush B3;
        private Pen P1;

        private Pen P2;
        protected override void PaintHook()
        {
            G.Clear(BackColor);

            Blend.Positions = new float[] { 0, 0.2f, 1.0f };
            Blend.Colors = new Color[]
            {

            };
            DrawGradient(Blend, ClientRectangle, 90);

            G.FillRectangle(B1, 0, 0, Width, Height / 2);

            if (State == MouseState.Over)
            {
                G.FillRectangle(B2, ClientRectangle);
            }

            DrawText(B3, HorizontalAlignment.Center, 0, 0);

            DrawBorders(P1, 1);
            DrawBorders(P2);
        }
    }

}
