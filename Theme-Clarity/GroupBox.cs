// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Clarity
{
    public class ClarityGroupBox : ThemeContainer154
    {
        #region "Properties"
        public ClarityGroupBox()
        {
            ControlMode = true;
            TransparencyKey = Color.Fuchsia;
            Font = new Font("Microsoft Sans Serif", 8);
            this.Size = new Size(172, 105);
        }


        protected override void ColorHook()
        {
        }
        #endregion
        #region "Color of Control"

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(22, 22, 22));



            G.DrawRectangle(new Pen(Color.FromArgb(32, 32, 32)), new Rectangle(1, 1, Width - 3, Height - 3));

            LinearGradientBrush Header = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, 26), Color.FromArgb(25, 25, 25), Color.FromArgb(40, 40, 40), 270);
            G.FillRectangle(Header, new Rectangle(0, 0, Width - 1, 26));

            HatchBrush HeaderHatch = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(35, Color.Black), Color.Transparent);
            G.FillRectangle(HeaderHatch, new Rectangle(0, 0, Width - 1, 26));
            G.FillRectangle(new SolidBrush(Color.FromArgb(13, Color.White)), 0, 0, Width - 1, 13);

            G.DrawLine(new Pen(Color.FromArgb(42, 42, 42)), 0, 13, Width - 1, 13);

            G.DrawRectangle(new Pen(Color.FromArgb(6, 6, 6)), new Rectangle(0, 0, Width - 1, Height - 1));



            G.DrawRectangle(new Pen(Color.FromArgb(6, 6, 6)), new Rectangle(1, 1, Width - 3, 25));
            G.DrawRectangle(new Pen(Color.FromArgb(32, 32, 32)), new Rectangle(1, 1, Width - 3, 24));


            DrawText(new SolidBrush(Color.Black), HorizontalAlignment.Center, 1, 1);
            DrawText(new SolidBrush(Color.FromArgb(255, 255, 255)), HorizontalAlignment.Center, 2, 2);


        }
        #endregion

    }
}


