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

namespace Zeroit.Framework.UIThemes.Adobe
{

    public class AdobeProgressBar : ThemeControl154
    {

        #region " Properties "

        private int Max;
        public int Maximum {
            get { return Max; }
            set {
                if (Max > 0)
                    Max = value;
                else
                    Max = 1;
                if (value > Max)
                    value = Max;
                Invalidate();
            }
        }

        private int Val;
        public int Value {
            get { return Val; }
            set {
                if (Val > -1) {

                    if(value == Max)
                    {
                        Val = Max;
                    }
                    else
                    {
                        Val = value;
                    }
                    #region Old Code
                    //				switch (value) {
                    //					case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
                    //Max:
                    //						Val = Max;
                    //						break;
                    //					default:
                    //						Val = value;
                    //						break;
                    //				} 
                    #endregion
                }

                else
                {
                    Val = 0;
                }
                Invalidate();
            }
        }

        #endregion

        public AdobeProgressBar()
        {
            Maximum = 100;
            Size = new Size(150, 16);
        }

        protected override void ColorHook()
        {
            //Void
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(68, 68, 68));

            //Fill
            switch (Val) {
                case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
                0:
                    DrawGradient(Color.FromArgb(132, 192, 240), Color.FromArgb(78, 123, 168), 3, 3, Convert.ToInt32((Val / Max) * Width - 8) + 2, Height - 6, 90);
                    DrawGradient(Color.FromArgb(98, 159, 220), Color.FromArgb(62, 102, 147), 4, 4, Convert.ToInt32((Val / Max) * Width - 8), Height - 8, 90);
                    break;
            }
            DrawGradient(Color.FromArgb(98, 159, 220), Color.FromArgb(62, 102, 147), 4, 4, Convert.ToInt32((Val / Max) * Width - 8), Height - 8, 90);

            DrawBorders(Pens.Black);
            DrawBorders(Pens.Gray, 1);
        }
    }

}
