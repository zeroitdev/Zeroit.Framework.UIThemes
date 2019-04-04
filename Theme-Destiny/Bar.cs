// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Bar.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Destiny
{
    public class Destiny_Bar : ThemeControl
    {

        private int _Maximum = 100;
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 1)
                    value = 1;
                if (value < _Value)
                    _Value = value;

                _Maximum = value;
                Invalidate();
            }
        }

        private int _Value;
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum)
                    value = _Maximum;

                _Value = value;
                Invalidate();
            }
        }

        public Destiny_Bar()
        {
            AllowTransparent();
        }

        Pen Border = new Pen(Color.FromArgb(82, 128, 145));
        Color T = Color.Transparent;
        Color BackClr = Color.Black;
        SolidBrush UpperColor = new SolidBrush(Color.Teal);

        SolidBrush LowerColor = new SolidBrush(Color.DarkCyan);
        public override void PaintHook()
        {
            G.Clear(BackClr);

            G.FillRectangle(LowerColor, 1, 1, Convert.ToInt32((_Value / _Maximum) * Width), Height - 2);
            G.FillRectangle(UpperColor, 1, 1, Convert.ToInt32((_Value / _Maximum) * Width), (Height - 2) / 2);
            G.DrawRectangle(Border, 0, 0, Width - 1, Height - 1);

            DrawText(HorizontalAlignment.Center, ForeColor, 0);

            DrawCorners(BackClr, ClientRectangle);
        }
    }

}


