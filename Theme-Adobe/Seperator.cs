// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
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
using System;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Adobe
{

    public class AdobeSeperator : ThemeControl154
    {

        #region " Properties "

        private bool vert;
        public bool Vertical {
            get { return vert; }
            set {
                vert = value;
                Invalidate();
            }
        }

        #endregion

        public AdobeSeperator()
        {
            Vertical = false;
            Size = new Size(100, 15);
            BackColor = Color.FromArgb(68, 68, 68);
        }

        protected override void ColorHook()
        {
            //Void
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            Pen P1 = ConversionFunctions.ConvertToPen(Color.FromArgb(40, Color.White));
            Pen P2 = ConversionFunctions.ConvertToPen(Color.FromArgb(170, Color.Black));
            switch (vert) {
                case true:
                    G.DrawLine(P1, Convert.ToInt32(this.Width / 2) - 1, 0, Convert.ToInt32(this.Width / 2) - 1, Height);
                    G.DrawLine(P2, Convert.ToInt32(this.Width / 2), 0, Convert.ToInt32(this.Width / 2), Height);
                    G.DrawLine(P1, Convert.ToInt32(this.Width / 2) + 1, 0, Convert.ToInt32(this.Width / 2) + 1, Height);
                    break;
                case false:
                    G.DrawLine(P1, 0, Convert.ToInt32(this.Height / 2) - 1, Width, Convert.ToInt32(this.Height / 2) - 1);
                    G.DrawLine(P2, 0, Convert.ToInt32(this.Height / 2), Width, Convert.ToInt32(this.Height / 2));
                    G.DrawLine(P1, 0, Convert.ToInt32(this.Height / 2) + 1, Width, Convert.ToInt32(this.Height / 2) + 1);
                    break;
                default:
                    break;
            }
        }
    }

}
