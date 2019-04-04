// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Box.cs" company="Zeroit Dev Technologies">
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

    public class AdobeBox : ThemeContainer154
    {

        #region " Properties "

        private Color fc;
        public override Color ForeColor {
            get { return fc; }
            set {
                fc = value;
                Invalidate();
            }
        }

        #endregion

        public AdobeBox()
        {
            ControlMode = true;
            ForeColor = Color.White;
        }


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            Pen P1 = default(Pen);
            Pen P2 = default(Pen);
            P1 = new Pen(new SolidBrush(Color.FromArgb(31, 31, 31)));
            P2 = new Pen(new SolidBrush(Color.FromArgb(131, 131, 131)));

            G.Clear(BackColor);

            DrawBorders(P1, new Rectangle(0, 10, Width, Height - 10));
            DrawBorders(P2, new Rectangle(0, 10, Width, Height - 10), 1);
            DrawBorders(P1, new Rectangle(10, 0, Convert.ToInt32(G.MeasureString(Text, Font).Width + 10), 20));
            DrawBorders(P2, new Rectangle(10, 0, Convert.ToInt32(G.MeasureString(Text, Font).Width + 10), 20), 1);

            G.FillRectangle(new SolidBrush(BackColor), new Rectangle(12, 2, Convert.ToInt32(G.MeasureString(Text, Font).Width + 6), 20));
            G.DrawString(Text, Font, new SolidBrush(ForeColor), 14, 4);
            G.DrawString(Text, Font, ConversionFunctions.ConvertToBrush(Color.FromArgb(50, Color.Black)), 16, 6);
        }
    }

}
