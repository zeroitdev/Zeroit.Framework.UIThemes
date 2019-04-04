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
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Metro
{
    public class MetroUIGroup : ThemeContainer154
    {

        public MetroUIGroup()
        {
            ControlMode = true;

            SetColor("background", Color.FromArgb(53, 157, 181));
            SetColor("inside", Color.White);
            SetColor("txt", Color.White);
        }

        Color bg;
        Color inside;
        Brush txt;
        protected override void ColorHook()
        {
            bg = GetColor("background");
            inside = GetColor("inside");
            txt = GetBrush("txt");
        }

        protected override void PaintHook()
        {
            G.Clear(bg);
            G.FillRectangle(new SolidBrush(inside), new Rectangle(1, 25, Width - 2, Height - 26));
            DrawText(txt, HorizontalAlignment.Left, 2, 0);
        }
    }
    
}


