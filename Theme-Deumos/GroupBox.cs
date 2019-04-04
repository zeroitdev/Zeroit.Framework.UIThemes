// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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
using System.Drawing;


namespace Zeroit.Framework.UIThemes.Deumos
{
    public class DeumosGroupBox : ThemeContainer153
    {

        public DeumosGroupBox()
        {
            ControlMode = true;

            SetColor("Back", 14, 14, 14);
            SetColor("MainFill", 20, 20, 20);
            SetColor("MainOutline1", 32, 32, 32);
            SetColor("MainOutline2", Color.Black);
            SetColor("TitleShadow", 50, Color.Black);
            SetColor("TitleFill", 20, 20, 20);
            SetColor("Text", Color.White);
            SetColor("TitleOutline1", 32, 32, 32);
            SetColor("TitleOutline2", Color.Black);

            BackColor = Color.FromArgb(20, 20, 20);
        }

        protected override void ColorHook()
        {
            C1 = GetColor("Back");

            B1 = new SolidBrush(GetColor("MainFill"));
            B2 = new SolidBrush(GetColor("TitleFill"));
            B3 = new SolidBrush(GetColor("Text"));

            P1 = new Pen(GetColor("MainOutline1"));
            P2 = new Pen(GetColor("MainOutline2"));
            P3 = new Pen(GetColor("TitleShadow"));
            P4 = new Pen(GetColor("TitleOutline1"));
            P5 = new Pen(GetColor("TitleOutline2"));

            BackColor = GetColor("MainFill");
        }

        private Color C1;
        private SolidBrush B1;
        private SolidBrush B2;
        private SolidBrush B3;
        private Pen P1;
        private Pen P2;
        private Pen P3;
        private Pen P4;

        private Pen P5;
        private Size S1;

        private Rectangle R1;
        protected override void PaintHook()
        {
            G.Clear(C1);

            if (this.Text.Length == 0)
            {
                G.FillRectangle(B1, ClientRectangle);
                DrawBorders(P1, 1);
                DrawBorders(P2);
            }
            else
            {
                G.FillRectangle(B1, 0, 13, Width, Height - 13);
                DrawBorders(P1, 0, 13, Width, Height - 13, 1);
                DrawBorders(P2, 0, 13, Width, Height - 13);


                S1 = Measure();
                R1 = new Rectangle(8, 0, S1.Width + 16, 26);

                DrawBorders(P3, 7, 0, R1.Width + 1, 27);

                G.FillRectangle(B2, R1);

                DrawText(B3, Center(R1, S1));

                DrawBorders(P4, R1, 1);
                DrawBorders(P5, R1);

                DrawCorners(C1, 0, 13, Width, Height - 13);
            }

        }

    }


}


