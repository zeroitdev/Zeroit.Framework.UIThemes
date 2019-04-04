// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Close.cs" company="Zeroit Dev Technologies">
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


namespace Zeroit.Framework.UIThemes.Metro
{
    public class MetroUIClose : ThemeControl154
    {
        public MetroUIClose()
        {
            LockHeight = 20;
            LockWidth = 20;
            SetColor("buttonc", Color.White);
            SetColor("textc", Color.Black);
            Font = new Font("Segoe UI", 12);
        }

        private Color buttonc;
        private Brush textc;
        protected override void ColorHook()
        {
            buttonc = GetColor("buttonc");
            textc = GetBrush("textc");
        }

        protected override void PaintHook()
        {
            G.Clear(buttonc);

            switch (State)
            {
                case MouseState.None:
                    G.DrawString("r", new Font("Marlett", 10), new SolidBrush(Color.Black), new Point(2, 2));

                    break;
                case MouseState.Over:
                    G.DrawString("r", new Font("Marlett", 10), new SolidBrush(Color.Red), new Point(2, 2));
                    break;
                case MouseState.Down:
                    G.DrawString("r", new Font("Marlett", 10), new SolidBrush(Color.DarkRed), new Point(2, 2));
                    break;
                case MouseState.Block:
                    break;
                default:
                    break;
            }

        }
    }

}


