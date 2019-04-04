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

namespace Zeroit.Framework.UIThemes.Recon
{
    public class ReconGroupBox : ThemeContainerControl
    {
        public ReconGroupBox()
        {
            AllowTransparent();
        }
        public override void PaintHook()
        {
            G.Clear(Color.FromArgb(25, 25, 25));
            this.BackColor = Color.FromArgb(25, 25, 25);
            DrawGradient(Color.FromArgb(11, 11, 11), Color.FromArgb(26, 26, 26), 1, 1, ClientRectangle.Width, ClientRectangle.Height, 270);
            DrawBorders(Pens.Black, new Pen(Color.FromArgb(52, 52, 52)), ClientRectangle);

            DrawGradient(Color.FromArgb(150, 32, 32, 32), Color.FromArgb(150, 31, 31, 31), 5, 23, Width - 10, Height - 28, 90);
            G.DrawRectangle(new Pen(Color.FromArgb(130, 13, 13, 13)), 5, 23, Width - 10, Height - 28);

            G.DrawString(Text, Font, new SolidBrush(this.ForeColor), 4, 6);

            DrawCorners(Color.Transparent, ClientRectangle);
        }
    }

}


