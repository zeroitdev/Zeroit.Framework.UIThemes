// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
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
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.Mpontuo
{
    public class MpontuoGroupbox : ThemeContainerControl
    {
        public override void PaintHook()
        {
            G.Clear(Color.FromArgb(40, 40, 40));
            DrawGradient(Color.FromArgb(65, 65, 65), Color.FromArgb(42, 42, 42), 0, 0, Width, 15, 90);
            G.DrawRectangle(new Pen(Color.FromArgb(65, 65, 65)), 0, 0, Width - 1, Height - 1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), Width - 1, 0, 1, 1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), 0, Height - 1, 1, 1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), Width - 1, Height - 1, 1, 1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), 0, 0, 1, 1);
            G.DrawString(Text, Parent.Font, new SolidBrush(Parent.ForeColor), 5, 1);
            BackColor = Color.FromArgb(40, 40, 40);
        }
    }
}

