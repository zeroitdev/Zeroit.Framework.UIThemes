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

namespace Zeroit.Framework.UIThemes.Steam
{
    public class SteamProgressBar : ThemeControl153
    {

        private int _Maximum;
        public int Maximum
        {
            get { return _Maximum; }
            set
            {

                if (value == _Value)
                {
                    _Value = value;
                }

                #region Old Code
                //			switch (value) {
                //				case  // ERROR: Case labels with binary operators are unsupported : LessThan
                //_Value:
                //					_Value = value;
                //					break;
                //			} 
                #endregion

                _Maximum = value;
                Invalidate();
            }
        }
        private int _Value;
        public int Value
        {
            get
            {
                switch (_Value)
                {
                    case 0:
                        return 1;
                    default:
                        return _Value;
                }
            }
            set
            {

                if (value == _Maximum)
                {
                    value = _Maximum;
                }

                #region Old Code
                //			switch (value) {
                //				case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
                //_Maximum:
                //					value = _Maximum;
                //					break;
                //			} 
                #endregion

                _Value = value;
                Invalidate();
            }
        }

        public SteamProgressBar()
        {
            Transparent = true;
            BackColor = Color.Transparent;
            LockHeight = 18;
            Value = 0;
            Maximum = 100;
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            //Fill
            switch (_Value)
            {
                case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
    2:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(166, 164, 161)), new Rectangle(4, 4, Convert.ToInt32(_Value / _Maximum * Width) - 8, Height - 8));
                    break;
                case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
    0:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(166, 164, 161)), new Rectangle(4, 4, Convert.ToInt32(_Value / _Maximum * Width) - 2, Height - 8));

                    break;
            }

            DrawBorders(new Pen(new SolidBrush(Color.FromArgb(128, 124, 120))));
            DrawCorners(BackColor);
        }


        protected override void ColorHook()
        {
        }
    }

}

