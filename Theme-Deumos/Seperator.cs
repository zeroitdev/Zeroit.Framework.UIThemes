// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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

namespace Zeroit.Framework.UIThemes.Deumos
{
    public class DeumosSeperator : ThemeControl153
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
                    LockWidth = 14;
                }
                else
                {
                    LockHeight = 14;
                    LockWidth = 0;
                }

                Invalidate();
            }
        }


        public DeumosSeperator()
        {
            LockHeight = 14;

            SetColor("Line1", Color.Black);
            SetColor("Line2", 22, 22, 22);
        }

        private Pen P1;

        private Pen P2;
        protected override void ColorHook()
        {
            P1 = GetPen("Line1");
            P2 = GetPen("Line2");
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);

            if (_Orientation == Orientation.Vertical)
            {
                G.DrawLine(P1, 6, 0, 6, Height);
                G.DrawLine(P2, 7, 0, 7, Height);
            }
            else
            {
                G.DrawLine(P1, 0, 6, Width, 6);
                G.DrawLine(P2, 0, 7, Width, 7);
            }

        }
    }


}


