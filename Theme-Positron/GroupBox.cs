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
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Positron
{
    public class PositronGroupBox : ThemeContainer154
    {
        private Pen PB;
        private Pen IB;
        private Brush BT;
        private Color BG;
        public PositronGroupBox()
        {
            ControlMode = true;
            SetColor("Border", Color.FromArgb(150, 150, 150));
            SetColor("Text", Color.FromArgb(100, 100, 100));
            SetColor("BG", Color.FromArgb(208, 208, 208));
            SetColor("Inside", Color.FromArgb(200, 200, 200));
            Size = new Size(160, 80);
        }
        protected override void ColorHook()
        {
            PB = GetPen("Border");
            BT = GetBrush("Text");
            BG = GetColor("BG");
            IB = GetPen("Inside");
        }
        protected override void PaintHook()
        {
            HatchBrush HBM = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(30, Color.White), Color.Transparent);
            G.Clear(BG);
            G.FillRectangle(HBM, new Rectangle(0, 0, Width - 1, Height - 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(220, 220, 220)), new Rectangle(5, 20, Width - 10, Height - 25));
            DrawBorders(IB);
            DrawBorders(PB, 1);
            G.DrawString(Text, Font, BT, new Point(6, 3));
        }
    }
}

