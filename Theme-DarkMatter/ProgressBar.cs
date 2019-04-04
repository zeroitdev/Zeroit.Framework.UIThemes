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

namespace Zeroit.Framework.UIThemes.DarkMatter
{
    public class DarkMatterProgressBar : ThemeControl152
    {

        #region " Properties "
        private int _Maximum;
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
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
                if (value > Maximum)
                    value = Maximum;
                _Value = value;
                Invalidate();
            }
        }
        #endregion

        public DarkMatterProgressBar()
        {
            //Defaults
            Maximum = 100;
            Value = 0;
            LockHeight = 20;
        }

        Color tColor;
        Color tGlow;
        Color tBorder;
        protected override void ColorHook()
        {
        }


        protected override void PaintHook()
        {
            switch (_ThemeColor)
            {
                case ColorTheme.GammaRay:
                    //GammaRay
                    tColor = Color.FromArgb(200, 255, 82);
                    tGlow = Color.FromArgb(123, 221, 42);
                    tBorder = Color.FromArgb(31, 91, 31);
                    break;
                case ColorTheme.RedShift:
                    //RedShift
                    tColor = Color.FromArgb(255, 45, 45);
                    tGlow = Color.FromArgb(255, 45, 45);
                    tBorder = Color.FromArgb(158, 7, 7);
                    break;
                case ColorTheme.Subspace:
                    //Subspace
                    tColor = Color.FromArgb(78, 203, 255);
                    tGlow = Color.FromArgb(0, 48, 255);
                    tBorder = Color.Empty;
                    break;
                case ColorTheme.SolarFlare:
                    //SolarFlare
                    tColor = Color.FromArgb(255, 238, 142);
                    tGlow = Color.FromArgb(255, 188, 74);
                    tBorder = Color.FromArgb(110, 61, 37);
                    break;
            }

            G.Clear(Color.FromArgb(31, 31, 31));

            #region Original Code
            //G.FillRectangle(new SolidBrush(Color.FromArgb(12, 12, 12)), new Rectangle(6, Height / 2 - 3, Width - 12, 5));
            //G.DrawRectangle(Pens.Black, new Rectangle(6, Height / 2 - 3, Width - 12, 5));

            #endregion

            G.FillRectangle(new SolidBrush(Color.FromArgb(12, 12, 12)), new Rectangle(6, Height / 2 - 10, Width - 12, 5));
            G.DrawRectangle(Pens.Black, new Rectangle(6, Height / 2 - 10, Width - 12, 5));


            switch (_Value)
            {
                case 0:
                    //DrawGradient(tGlow, tGlow, 6, Height / 2 - 3, Convert.ToInt32(_Value / _Maximum * (Width /*- 11*/)), 6, 90);
                    //DrawGradient(tColor, tColor, 6, Height / 2 - 2, Convert.ToInt32(_Value / _Maximum * (Width /*- 11*/)), 3, 90);
                    //G.DrawRectangle(new Pen(new SolidBrush(tBorder)), new Rectangle(6, Height / 2 - 3, Convert.ToInt32(_Value / _Maximum * (Width /*- 11*/)), 6));
                    //DrawCorners(Color.FromArgb(31, 31, 31), new Rectangle(6, Height / 2 - 3, Convert.ToInt32(_Value / _Maximum * (Width - 9)), 7));
                    //break;


                    //DrawGradient(tGlow, tGlow, 6, Height / 2 - 3, Convert.ToInt32(_Value / _Maximum * (Width /*- 11*/)), 6, 90);
                    //DrawGradient(tColor, tColor, 6, Height / 2 - 2, Convert.ToInt32(_Value / _Maximum * (Width /*- 11*/)), 3, 90);
                    //G.DrawRectangle(new Pen(new SolidBrush(tBorder)), new Rectangle(6, Height / 2 - 3, Convert.ToInt32(_Value / _Maximum * (Width /*- 11*/)), 6));
                    //DrawCorners(Color.FromArgb(31, 31, 31), new Rectangle(6, Height / 2 - 3, Convert.ToInt32(_Value / _Maximum * (Width - 9)), 7));


                    //-------------------------------Working------------------------------------------------------------------------------------//
                    DrawGradient(tGlow, tGlow, 6, Convert.ToInt32(_Value / _Maximum * (Height - 11)), Width / 2 - 3, 6, 90);
                    DrawGradient(tColor, tColor, 6, Convert.ToInt32(_Value / _Maximum * (Height - 11)), Width / 2 - 2, 3, 90);
                    G.DrawRectangle(new Pen(new SolidBrush(tBorder)), new Rectangle(6, Convert.ToInt32(_Value / _Maximum * (Height - 11)), Width / 2 - 3, 6));
                    DrawCorners(Color.FromArgb(31, 31, 31), new Rectangle(6, Convert.ToInt32(_Value / _Maximum * (Height - 9)), Width / 2 - 3, 7));
                    break;
                default:
                    break;
            }
            //switch (_Value)
            //{
            //    case 0:  // ERROR: Case labels with binary operators are unsupported : GreaterThan

            //        DrawGradient(tGlow, tGlow, 6, Height / 2 - 3, Convert.ToInt32(_Value / _Maximum * (Width /*- 11*/)), 6, 90);
            //        DrawGradient(tColor, tColor, 6, Height / 2 - 2, Convert.ToInt32(_Value / _Maximum * (Width /*- 11*/)), 3, 90);
            //        G.DrawRectangle(new Pen(new SolidBrush(tBorder)), new Rectangle(6, Height / 2 - 3, Convert.ToInt32(_Value / _Maximum * (Width /*- 11*/)), 6));
            //        DrawCorners(Color.FromArgb(31, 31, 31), new Rectangle(6, Height / 2 - 3, Convert.ToInt32(_Value / _Maximum * (Width - 9)), 7));

            //        break;
            //}
            DrawBorders(new Pen(new SolidBrush(Color.FromArgb(25, 25, 25))));
        }

        public void Increment(int Ammount)
        {
            if (Value < Maximum - Ammount)
            {
                Value = Ammount;
                Invalidate();
            }
            else if (Maximum < Value)
            {
                Value = Maximum;
            }
            else if (Ammount > Maximum)
            {
                Value = Maximum;
            }
        }

        public enum ColorTheme
        {
            GammaRay = 0,
            RedShift = 1,
            Subspace = 2,
            SolarFlare = 3
        }
        private ColorTheme _ThemeColor;
        public ColorTheme ThemeStyle
        {
            get { return _ThemeColor; }
            set
            {
                _ThemeColor = value;
                Invalidate();
            }
        }
    }

}
