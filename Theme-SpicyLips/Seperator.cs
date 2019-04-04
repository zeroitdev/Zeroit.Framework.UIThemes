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
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.SpicyLips
{
    public class BlackSeperator : ThemeControl154
    {
        private Orientation _Orientation;
        public Orientation Orientation
        {
            get { return _Orientation; }

            set
            {
                _Orientation = value;

                if (value == Orientation.Vertical)
                {
                    LockHeight = 0;
                    LockWidth = 12;
                }
                else
                {
                    LockHeight = 12;
                    LockWidth = 0;
                }

                Invalidate();
            }
        }
        public BlackSeperator()
        {
            LockHeight = 12;
        }


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(22, 22, 22));

            if (_Orientation == Orientation.Horizontal)
            {
                G.DrawLine(new Pen(Color.FromArgb(2, 2, 2)), 0, 6, Width, 6);
                G.DrawLine(new Pen(Color.FromArgb(22, 22, 22)), 0, 7, Width, 7);
            }
            else
            {
                G.DrawLine(new Pen(Color.FromArgb(2, 2, 2)), 6, 0, 6, Height);
                G.DrawLine(new Pen(Color.FromArgb(22, 22, 22)), 7, 0, 7, Height);
            }

        }
    }

}