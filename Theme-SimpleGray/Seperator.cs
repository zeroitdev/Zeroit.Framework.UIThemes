// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Seperator.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.SimpleGray
{
    public class SimplyGraySeperator : ThemeControl
    {

        private Color _Color1 = Color.DarkGray;
        public Color Color1
        {
            get { return _Color1; }
            set { _Color1 = value; }
        }

        private Color _Color2 = Color.FromArgb(50, 50, 50);
        public Color Color2
        {
            get { return _Color2; }
            set { _Color2 = value; }
        }

        public SimplyGraySeperator()
        {
            AllowTransparent();
            BackColor = Color.Transparent;
            Size S = new Size(150, 10);
            Size = S;
        }

        Color Gr = Color.Gray;
        Color DGr = Color.DarkGray;
        Color T = Color.Transparent;

        Pen PDGr = Pens.DarkGray;
        public override void PaintHook()
        {
            G.Clear(Gr);

            G.DrawLine(new Pen(_Color1), 0, Height / 2, Width, Height / 2);
            G.DrawLine(new Pen(_Color2), 0, Height / 2 + 1, Width, Height / 2 + 1);
        }
    }

}

