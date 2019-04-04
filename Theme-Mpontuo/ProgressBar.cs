// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
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
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Zeroit.Framework.UIThemes.Mpontuo
{
    public class MpontuoProgressBar : ThemeControl
    {
        private int _Maximum = 100;
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                if (value < _Value)
                {
                    _Value = value;
                }

                _Maximum = value;
                Invalidate();
            }
        }

        private int _Value;
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value > _Maximum)
                {
                    value = _Maximum;
                }

                _Value = value;
                Invalidate();
            }
        }

        public MpontuoProgressBar()
        {
            AllowTransparent();
            ForeColor = Color.FromArgb(66, 130, 181);
        }

        private Pen Border = new Pen(Color.Black);
        private Color T = Color.Transparent;
        private Color BackClr = Color.FromArgb(30, 30, 30);
        private SolidBrush UpperColor = new SolidBrush(Color.FromArgb(50, 50, 50));
        private SolidBrush LowerColor = new SolidBrush(Color.FromArgb(42, 42, 42));

        public override void PaintHook()
        {
            G.Clear(BackClr); //Background color of the control

            G.FillRectangle(LowerColor, 1, 1, Convert.ToInt32((_Value / (double)_Maximum) * Width), Height - 2); // \
            G.FillRectangle(UpperColor, 1, 1, Convert.ToInt32((_Value / (double)_Maximum) * Width), (int)(Math.Truncate((double)(Height - 2) / 2))); // > Draw the colors and the border
            G.DrawRectangle(Border, 0, 0, Width - 1, Height - 1); // /

            DrawText(HorizontalAlignment.Center, ForeColor, 0); //Text

            DrawCorners(BackClr, ClientRectangle); //Corners..
        }
    }
}

