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
using System.Drawing.Drawing2D;
using System.Windows.Forms;




namespace Zeroit.Framework.UIThemes.BasicCode
{

    public class BCEvoGroupBox : ThemeContainer154
    {

        public BCEvoGroupBox()
        {
            ControlMode = true;
            Header = 26;
            TextColor = Color.Gray;
            Size = new Size(205, 120);
        }

        protected override void ColorHook()
        {
        }
        private Color _ForeColor;
        public Color TextColor
        {
            get { return _ForeColor; }
            set { _ForeColor = value; }
        }
        private ColorBlend LBlend = new ColorBlend();

        private ColorBlend LBlend2 = new ColorBlend();
        protected override void PaintHook()
        {
            LBlend.Positions = new float[] {
            0f,
            0.15f,
            0.85f,
            1f
        };
            LBlend2.Positions = new float[] {
            0f,
            0.15f,
            0.5f,
            0.85f,
            1f
        };
            LBlend.Colors = new Color[] {
            Color.Transparent,
            Color.Black,
            Color.Black,
            Color.Transparent
        };
            LBlend2.Colors = new Color[] {
            Color.Transparent,
            Color.FromArgb(35, 35, 35),
            Color.FromArgb(45, 45, 45),
            Color.FromArgb(35, 35, 35),
            Color.Transparent
        };

            G.Clear(Color.FromArgb(24, 24, 24));

            if (Text == null)
            {
            }
            else
            {
                DrawGradient(LBlend, 0, 23, Width, 1, 0f);
                DrawGradient(LBlend2, 0, 24, Width, 1, 0f);
            }

            DrawBorders(Pens.Black, 3);
            DrawBorders(Pens.Black);

            G.DrawLine(new Pen(Color.FromArgb(48, 48, 48)), 1, 1, Width - 2, 1);

            DrawText(new SolidBrush(TextColor), HorizontalAlignment.Center, 0, 0);
        }
    }
    
}
