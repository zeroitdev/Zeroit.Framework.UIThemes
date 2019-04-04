// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="StatusBar.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.VibeLander
{
    public class VibeStatusBar : ThemeControl
    {
        public VibeStatusBar()
        {
            this.Dock = DockStyle.Bottom;
            this.Size = new Size(Width, 20);
        }
        public override void PaintHook()
        {
            this.Font = new Font("Arial", 10);
            G.Clear(this.BackColor);
            G.SmoothingMode = SmoothingMode.HighQuality;

            switch (MouseState)
            {
                case State.MouseNone:
                    DrawGradient(Color.FromArgb(20, 82, 179), Color.FromArgb(58, 110, 195), 0, 0, Width, Height, 270);
                    G.DrawRectangle(new Pen(Color.FromArgb(12, 69, 180)), 0, 0, Width - 1, Height - 1);
                    DrawText(HorizontalAlignment.Left, Color.FromArgb(240, 240, 240), +1);
                    break;
                case State.MouseDown:
                    DrawGradient(Color.FromArgb(19, 75, 172), Color.FromArgb(70, 110, 198), 0, 0, Width, Height, 270);
                    G.DrawRectangle(new Pen(Color.FromArgb(12, 69, 180)), 0, 0, Width - 1, Height - 1);
                    DrawText(HorizontalAlignment.Left, Color.FromArgb(232, 232, 232), +1);
                    break;
                case State.MouseOver:
                    DrawGradient(Color.FromArgb(21, 79, 177), Color.FromArgb(76, 128, 218), 0, 0, Width, Height, 270);
                    G.DrawRectangle(new Pen(Color.FromArgb(12, 69, 180)), 0, 0, Width - 1, Height - 1);
                    DrawText(HorizontalAlignment.Left, Color.FromArgb(250, 250, 250), +1);
                    break;
            }
            G.DrawLine(new Pen(Color.FromArgb(50, 255, 255, 255)), 1, 1, Width - 3, 1);

        }
    }
}

