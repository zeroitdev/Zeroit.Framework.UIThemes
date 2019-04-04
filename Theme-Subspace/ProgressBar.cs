// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.SubSpace
{
    public class SubspaceProgressbar : ThemeControl154
    {

        private int _Value;
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum)
                    value = _Maximum;
                if (value < 0)
                    value = 0;

                _Value = value;
                Invalidate();
            }
        }

        private int _Maximum = 100;
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 1)
                    value = 1;
                if (_Value > value)
                    _Value = value;

                _Maximum = value;
                Invalidate();
            }
        }


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            DrawGradient(Color.Black, Color.FromArgb(40, 40, 40), 0, 0, Width, Height, 2);

            DrawGradient(Color.FromArgb(84, 182, 255), Color.FromArgb(45, 134, 255), 0, 0, Convert.ToInt32((_Value / _Maximum) * Width - 1), Height);
            G.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), 0, 0, Convert.ToInt32((_Value / _Maximum) * Width - 1), Height / 2);

            DrawBorders(Pens.Black);
            DrawBorders(Pens.Black, 2);
            DrawBorders(new Pen(Color.FromArgb(69, 71, 70)), 1);
            DrawGradient(Color.White, Color.Black, 0, 0, Width / 4, 1, 360);
            DrawGradient(Color.White, Color.Black, 0, 0, 1, Height / 2);
        }
    }

}




