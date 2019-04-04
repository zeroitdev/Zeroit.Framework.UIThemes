// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="RedProgressBar.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Booster
{
    public class BoosterRedProgressbar : ThemeControl154
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

        public BoosterRedProgressbar()
        {
            Transparent = true;
            BackColor = Color.Transparent;
        }


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(66, 0, 0));

            G.FillRectangle(new SolidBrush(Color.FromArgb(204, 0, 0)), 0, 0, Convert.ToInt32((_Value / _Maximum) * Width - 1), Height);

            CreateRound(0, 0, Width, Height, 5);
            G.DrawLine(new Pen(Color.FromArgb(32, 32, 32)), 0, 1, Width, 1);
            DrawBorders(new Pen(Color.FromArgb(70, 70, 70)), 0);
            G.DrawLine(new Pen(Color.FromArgb(138, 139, 138)), 0, Height - 1, Width, Height - 1);
            DrawGradient(Color.FromArgb(70, 70, 70), Color.FromArgb(138, 139, 138), 0, 0, 1, Height);
            DrawGradient(Color.FromArgb(70, 70, 70), Color.FromArgb(138, 139, 138), Width - 1, 0, Width, Height);
        }
    }


}

