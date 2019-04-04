// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Aryan
{


    //Button
    public class AryanButton : ThemeControl151
    {

        public AryanButton()
        {
            SetColor("BackColor", Color.FromArgb(25, 25, 25));
            SetColor("TextColor", Color.Red);
        }


        Color C1;
        Color T1;
        protected override void ColorHook()
        {
            C1 = GetColor("BackColor");
            T1 = GetColor("TextColor");
        }


        protected override void PaintHook()
        {
            G.Clear(C1);
            switch (State)
            {
                case MouseState.None:
                    //None
                    DrawGradient(Color.FromArgb(25, 25, 25), Color.FromArgb(50, 50, 50), ClientRectangle, 90);
                    Cursor = Cursors.Arrow;
                    break;
                case MouseState.Down:
                    //Down
                    DrawGradient(Color.FromArgb(50, 50, 50), Color.FromArgb(42, 42, 42), ClientRectangle, 90);
                    Cursor = Cursors.Hand;
                    break;
                case MouseState.Over:
                    //Over
                    DrawGradient(Color.FromArgb(42, 42, 42), Color.FromArgb(50, 50, 50), ClientRectangle, 90);
                    Cursor = Cursors.Hand;
                    break;
            }
            DrawBorders(new Pen(new SolidBrush(Color.FromArgb(59, 59, 59))), 1);
            DrawBorders(new Pen(new SolidBrush(Color.FromArgb(25, 25, 25))));
            DrawCorners(Color.FromArgb(35, 35, 35));
            DrawText(new SolidBrush(T1), HorizontalAlignment.Center, 0, 0);
        }
    }
    
}


