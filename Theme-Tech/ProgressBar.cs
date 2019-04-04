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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Tech
{
    public class TLFProgressBar : ThemeControl
    {
        private int _Maximum = 100;
        public int Maximum
        {
            get { return _Maximum; }

            set
            {
                if (value < 1)
                    value = 1;
                if (value > _Value)
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

                _Value = value;
                Invalidate();
            }
        }




        public override void PaintHook()
        {
            Pen bC = new Pen(Color.FromArgb(26, 92, 152));
            HatchBrush ba = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(0, 255, 255, 255));

            Pen pe = new Pen(ba);
            G.Clear(Color.FromArgb(26, 92, 152));
            //G.FillRectangle(ba, ClientRectangle)
            G.FillRectangle(ba, 0, 0, Convert.ToInt32(_Value / _Maximum * Width), Height);

            DrawText(HorizontalAlignment.Center, Color.FromArgb(7, 38, 81), 1, 1);
            DrawText(HorizontalAlignment.Center, Color.FromArgb(204, 231, 250), 0);

            DrawGradient(Color.FromArgb(100, 255, 255, 255), Color.FromArgb(15, 255, 255, 255), 0, 0, Width, Convert.ToInt32(Height / 2), 90);
            DrawBorders(Pens.Black, bC, ClientRectangle);
        }
    }

}

