// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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

namespace Zeroit.Framework.UIThemes.Cola
{
    public class CCProgressBar : ThemeControl151
    {

        public CCProgressBar()
        {
        }
        private int _maximum;
        public int maximum
        {
            get { return _maximum; }
            set
            {
                if (value < 1)
                    value = 1;
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


        protected override void ColorHook()
        {
        }


        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(192, 0, 0));
            DrawBorders(new Pen(new SolidBrush(Color.RosyBrown)));
            DrawBorders(new Pen(new SolidBrush(Color.RosyBrown)), 1);

            G.FillRectangle(Brushes.White, 0, 0, Convert.ToInt32((_value / _maximum) * Width), Height);
            G.FillRectangle(Brushes.WhiteSmoke, 0, Convert.ToInt32((Height / 4)), Convert.ToInt32((_value / _maximum) * Width), Height);
            G.FillRectangle(Brushes.LightGray, 0, Convert.ToInt32((Height / 3)), Convert.ToInt32((_value / _maximum) * Width), Height);
            G.FillRectangle(Brushes.LightGray, 0, Convert.ToInt32((Height / 3)), Convert.ToInt32((_value / _maximum) * Width), Height);
            G.FillRectangle(Brushes.Silver, 0, Convert.ToInt32((Height / 2)), Convert.ToInt32((_value / _maximum) * Width), Height);
            G.DrawRectangle(Pens.RosyBrown, 0, 0, Width - 1, Height - 1);

        }
    }


}

