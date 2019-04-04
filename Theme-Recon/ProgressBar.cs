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

namespace Zeroit.Framework.UIThemes.Recon
{
    public class ReconBar : ThemeControl
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
            get { return _Value; }
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

        public override void PaintHook()
        {
            G.Clear(Color.FromArgb(49, 49, 49));
            DrawGradient(Color.FromArgb(18, 18, 18), Color.FromArgb(28, 28, 28), 1, 1, ClientRectangle.Width, ClientRectangle.Height, 90);

            //Fill
            switch (_Value)
            {
                case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
    6:
                    int x = Convert.ToInt32(_Value / _Maximum * Width);
                    int z = ClientRectangle.Height - 7;

                    DrawGradient(Color.FromArgb(28, 28, 28), Color.FromArgb(38, 38, 38), 1, 1, Convert.ToInt32(_Value / _Maximum * Width), ClientRectangle.Height, 270);
                    DrawGradient(Color.FromArgb(100, 50, 50, 50), Color.Transparent, 1, 1, Convert.ToInt32(_Value / _Maximum * Width), ClientRectangle.Height / 2, 90);

                    DrawGradient(Color.FromArgb(5, this.ForeColor), Color.Transparent, 1, 1, Convert.ToInt32(_Value / _Maximum * Width), ClientRectangle.Height / 4, 90);
                    DrawGradient(Color.FromArgb(9, this.ForeColor), Color.Transparent, 1, Convert.ToInt32(_Value / _Maximum * Width) / 2, ClientRectangle.Width, ClientRectangle.Height / 2, 270);


                    G.DrawRectangle(new Pen(Color.FromArgb(50, 50, 50)), 1, 1, x, z + 4);

                    G.DrawRectangle(Pens.Black, 2, 2, x, z + 2);

                    break;
                case  // ERROR: Case labels with binary operators are unsupported : GreaterThan
    1:
                    DrawGradient(Color.FromArgb(109, 183, 255), Color.FromArgb(40, 154, 255), 3, 3, Convert.ToInt32(_Value / _Maximum * Width), Height / 2 - 3, 90);
                    DrawGradient(Color.FromArgb(30, 130, 245), Color.FromArgb(15, 100, 170), 3, Height / 2 - 1, Convert.ToInt32(_Value / _Maximum * Width), Height / 2 - 2, 90);
                    break;
            }

            //Borders
            DrawBorders(Pens.Black, new Pen(Color.FromArgb(52, 52, 52)), ClientRectangle);

        }
        public void Increment(int Amount)
        {
            if (this.Value + Amount > Maximum)
            {
                this.Value = Maximum;
            }
            else
            {
                this.Value += Amount;
            }
        }
    }


}


