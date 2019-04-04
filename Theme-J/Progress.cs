// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Progress.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Jasta
{
    public class Jprogress : ThemeControl151
    {
        Color Color1;
        Pen Color2;

        Brush Color3;
        private int _max = 100;
        public int Max
        {
            get { return _max; }
            set
            {
                if (value < 1)
                    value = 1;
                if (_v < value)
                    _v = value;

                _max = value;
                Invalidate();
            }
        }


        private int _v;
        public int Value
        {
            get { return _v; }
            set
            {
                if (value > _max)
                    value = _max;

                _v = value;
                Invalidate();
            }
        }

        public Jprogress()
        {
            SetColor("BackColor", Color.FromArgb(15, 15, 15));
            SetColor("Border", Color.Black);
            SetColor("FillInStuff", Color.FromArgb(50, 50, 50));
        }

        protected override void ColorHook()
        {
            Color1 = GetColor("BackColor");
            Color2 = new Pen(GetColor("Border"));
            Color3 = new SolidBrush(GetColor("FillInStuff"));
        }

        protected override void PaintHook()
        {
            G.Clear(Color1);
            G.FillRectangle(Color3, 0, 0, Convert.ToInt32((_v / _max) * Width), Height);
            DrawBorders(Color2);

        }
    }


}


