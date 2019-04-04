// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Label.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.CarbonFibre
{
    public class CarbonFiberLabel : ThemeControl154
    {
        #region "Properties"
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            int textSize = 0;
            int textSize1 = 0;
            textSize = Convert.ToInt32(CreateGraphics().MeasureString(Text, Font).Width);
            textSize1 = Convert.ToInt32(this.CreateGraphics().MeasureString(Text, Font).Height);

            this.Width = 5 + textSize;
            this.Height = textSize1;
        }
        public CarbonFiberLabel()
        {
            Transparent = true;
            BackColor = Color.Transparent;
            this.Size = new Size(50, 16);
            //MinimumSize = New Size(50, 16)
            //MaximumSize = New Size(600, 16)
        }
        protected override void ColorHook()
        {
            // bleh bleh bleh waste of time !!
        }
        #endregion
        #region "Color Of Control"
        protected override void PaintHook()
        {
            G.Clear(BackColor);

            G.DrawString(Text, Font, new SolidBrush(Color.Black), new Point(1, 0));
            // Text Shadow
            G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(255, 150, 0)), new Point(1, 1));
        }
        #endregion
    }

}


