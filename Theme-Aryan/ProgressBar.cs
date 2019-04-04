// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
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

namespace Zeroit.Framework.UIThemes.Aryan
{


    public class AryanProgessBar : ThemeControl151
    {
        private int _maximum;
        public int maximum
        {
            get { return _maximum; }
            set
            {
                if (value < 100)
                    value = 100;
                if (value < _value)
                    _value = value;


                _maximum = value;
                Invalidate();
            }
        }
        private int _value;
        public int value
        {
            get { return _value; }
            set
            {
                if (value > _maximum)
                    value = maximum;
                _value = value;
                Invalidate();
            }
        }
        public AryanProgessBar()
        {
            SetColor("BackColor", Color.FromArgb(25, 25, 25));
        }
        Color c1;
        protected override void ColorHook()
        {
            c1 = GetColor("BackColor");
            BackColor = c1;
        }


        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(25, 25, 25));

            G.FillRectangle(Brushes.Red, 0, 0, Convert.ToInt32((_value / _maximum) * Width), Convert.ToInt32((Height / 3)));
            G.FillRectangle(Brushes.Red, 0, Convert.ToInt32((Height / 3)), Convert.ToInt32((_value / _maximum) * Width), Height);
            G.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);

        }
    }

}


