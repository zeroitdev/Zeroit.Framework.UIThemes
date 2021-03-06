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
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Zeus
{

    public class ZeusProgressBar : ThemeControl
    {

        #region " Properties "


        private int _Maximum;
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
                Maximum = 100;
                _Value = value;
                Invalidate();
            }
        }


        private bool _ShowText;
        public bool ShowText
        {
            get { return _ShowText; }
            set
            {
                _ShowText = value;
                Invalidate();
            }
        }




        #endregion

        #region " PaintHook "


        public override void PaintHook()
        {
            Color C1 = Color.FromArgb(38, 38, 38);
            Color C2 = Color.AliceBlue;
            Color C3 = Color.FromArgb(150, 255, 255);
            Pen P1 = Pens.Black;
            Pen P2 = Pens.AliceBlue;

            G.Clear(C1);

            switch (_Value)
            {
                case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
    2:
                    DrawGradient(C2, C3, 3, 3, Convert.ToInt32((_Value / _Maximum) * Width) - 6, Height - 6, 90);
                    switch (ShowText)
                    {
                        case true:
                            DrawText(HorizontalAlignment.Center, C1, 0);
                            break;
                    }
                    break;
                case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
    0:
                    DrawGradient(C1, C1, 3, 3, Convert.ToInt32((_Value / _Maximum) * Width) - 6, Height - 6, 90);
                    break;
            }

            G.DrawRectangle(P2, 0, 0, Width - 1, Height - 1);

        }

        #endregion

    }

}


