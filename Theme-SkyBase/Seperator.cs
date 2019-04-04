// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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

namespace Zeroit.Framework.UIThemes.SkyLimit
{
    public class SkyDarkSeperator : Control
    {

        public enum Alignment
        {
            Vertical,
            Horizontal
        }

        private Alignment al;
        public Alignment Align
        {
            get { return al; }
            set
            {
                al = value;
                Invalidate();
            }
        }

        Color C1 = Color.FromArgb(51, 49, 47);
        Color C2 = Color.FromArgb(90, 91, 90);
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            switch (Align)
            {
                case Alignment.Horizontal:
                    G.DrawLine(ConversionFunctions.ToPen(C1), new Point(0, Height / 2), new Point(Width, Height / 2));
                    G.DrawLine(ConversionFunctions.ToPen(C2), new Point(0, Height / 2 + 1), new Point(Width, Height / 2 + 1));
                    break;
                case Alignment.Vertical:
                    G.DrawLine(ConversionFunctions.ToPen(C1), new Point(Width / 2, 0), new Point(Width / 2, Height));
                    G.DrawLine(ConversionFunctions.ToPen(C2), new Point(Width / 2 + 1, 0), new Point(Width / 2 + 1, Height));
                    break;
            }

            e.Graphics.DrawImage(B, 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

}