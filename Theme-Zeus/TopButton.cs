// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TopButton.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Zeus
{
    public class ZeusTopButton : ThemeControl
    {


        #region " Options "

        public ZeusTopButton()
        {
            this.Size = new Size(15, 15);
            this.MinimumSize = new Size(15, 15);
            this.Text = "X";
        }

        #endregion

        #region " PaintHook "


        public override void PaintHook()
        {
            Brush B1 = Brushes.Black;
            Brush B2 = Brushes.LightCyan;
            Brush B3 = Brushes.AliceBlue;
            Color C1 = Color.FromArgb(45, 45, 45);
            Color C2 = Color.FromArgb(150, 255, 255);
            Color C3 = Color.AliceBlue;
            Pen P1 = Pens.Black;
            Pen P2 = Pens.LightCyan;
            Pen P3 = Pens.AliceBlue;


            G.Clear(C1);

            switch (MouseState)
            {
                case State.MouseNone:
                    G.DrawEllipse(P3, 0, 0, Width - 1, Height - 1);
                    this.Font = new Font("Cambria", 8, FontStyle.Bold);
                    DrawText(HorizontalAlignment.Center, C3, 0);
                    break;
                case State.MouseOver:
                    G.DrawEllipse(P3, 0, 0, Width - 1, Height - 1);
                    this.Font = new Font("Cambria", 8, FontStyle.Bold);
                    DrawText(HorizontalAlignment.Center, C3, 0);
                    break;
                case State.MouseDown:
                    G.DrawEllipse(P3, 1, 1, Width - 3, Height - 3);
                    this.Font = new Font("Cambria", 6, FontStyle.Bold);
                    DrawText(HorizontalAlignment.Center, C3, 0);
                    break;
            }



        }

        #endregion

    }

}


