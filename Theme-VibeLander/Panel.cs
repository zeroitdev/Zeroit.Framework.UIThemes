// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Panel.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.VibeLander
{

    public class VibePanelBox : ThemeContainerControl
    {
        private bool _Checked;
        public VibePanelBox()
        {
            AllowTransparent();
        }
        public override void PaintHook()
        {
            this.Font = new Font("Tahoma", 10);
            this.ForeColor = Color.FromArgb(40, 40, 40);
            G.SmoothingMode = SmoothingMode.AntiAlias;
            G.FillRectangle(new SolidBrush(Color.FromArgb(235, 235, 235)), new Rectangle(2, 0, Width, Height));
            G.FillRectangle(new SolidBrush(Color.FromArgb(249, 249, 249)), new Rectangle(1, 0, Width - 3, Height - 4));
            G.DrawRectangle(new Pen(Color.FromArgb(214, 214, 214)), 0, 0, Width - 2, Height - 3);
        }
    }

}

