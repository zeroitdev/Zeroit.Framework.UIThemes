// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 08-12-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 02-24-2018
// ***********************************************************************
// <copyright file="Alpha Theme.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Alpha
{

    /// <summary>
    /// Class AlphaBar.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.UIThemes.Alpha.ThemeControl" />
    public class AlphaBar : ThemeControl
    {
        
        /// <summary>
        /// The maxiumum
        /// </summary>
        private int _Maxiumum = 100;
        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
        {
            get { return _Maxiumum; }
            set
            {
                if (value < 1)
                    value = 1;
                if (value < _Value)
                    _Value = value;

                _Maxiumum = value;
                Invalidate();
            }
        }


        /// <summary>
        /// The value
        /// </summary>
        private int _Value;
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value == _Maxiumum)
                    value = _Maxiumum;

                _Value = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Paints the hook.
        /// </summary>
        public override void PaintHook()
        {
            G.Clear(Color.DimGray);

            G.FillRectangle(Brushes.Green, 0, 0, Convert.ToInt32((_Value / _Maxiumum) * Width), Height);

            G.DrawRectangle(Pens.Lime, 0, 0, Width - 1, Height - 1);
        }
    }

}


