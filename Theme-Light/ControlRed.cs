// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ControlRed.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Light
{
    public class LightControlRed : ThemeControl
    {
        public LightControlRed()
        {
            Size = new Size(90, 15);
            MinimumSize = new Size(14, 14);
            MaximumSize = new Size(15, 15);
        }

        public override void PaintHook()
        {

            switch (MouseState)
            {
                case State.MouseNone:
                    DrawGradient(Color.FromArgb(160, 0, 0), Color.FromArgb(109, 16, 16), 0, 0, 15, 15, 90);
                    DrawGradient(Color.FromArgb(109, 16, 16), Color.FromArgb(212, 20, 20), 3, 3, 9, 9, 90);
                    DrawGradient(Color.FromArgb(212, 20, 20), Color.FromArgb(109, 16, 16), 4, 4, 7, 7, 90);
                    DrawBorders(Pens.Gray, Pens.LightGray, new Rectangle(0, 0, 15, 15));
                    break;
                case State.MouseDown:
                    DrawGradient(Color.FromArgb(160, 0, 0), Color.FromArgb(109, 16, 16), 0, 0, 15, 15, 90);
                    DrawGradient(Color.FromArgb(109, 16, 16), Color.FromArgb(212, 20, 20), 3, 3, 9, 9, 90);
                    DrawGradient(Color.FromArgb(212, 20, 20), Color.FromArgb(109, 16, 16), 4, 4, 7, 7, 90);
                    DrawBorders(Pens.Gray, Pens.LightGray, new Rectangle(0, 0, 15, 15));
                    break;
                case State.MouseOver:
                    DrawGradient(Color.FromArgb(160, 0, 0), Color.FromArgb(249, 50, 50), 0, 0, 15, 15, 90);
                    DrawGradient(Color.FromArgb(249, 50, 50), Color.FromArgb(212, 20, 20), 3, 3, 9, 9, 90);
                    DrawGradient(Color.FromArgb(212, 20, 20), Color.FromArgb(249, 50, 50), 4, 4, 7, 7, 90);
                    DrawBorders(Pens.Gray, Pens.LightGray, new Rectangle(0, 0, 15, 15));
                    break;
            }
            this.Cursor = Cursors.Hand;

        }
    }

}


