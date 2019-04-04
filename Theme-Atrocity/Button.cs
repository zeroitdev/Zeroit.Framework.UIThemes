// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
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


namespace Zeroit.Framework.UIThemes.Atrocity
{


    public class aButton : ThemeControl153
    {


        public aButton()
        {
            this.Size = new Size(102, 23);

            //BEGIN BUTTON-STATE GRADIENTS
            SetColor("DownGradient2", 72, 69, 75);
            SetColor("DownGradient1", 24, 23, 26);

            SetColor("NoneGradient2", 24, 23, 26);
            SetColor("NoneGradient1", 72, 69, 75);
            //END BUTTON-STATE GRADIENTS


            SetColor("Text", 0, 133, 157);
            SetColor("Border1", 65, 65, 65);
            SetColor("Border2", 75, 75, 75);
        }

        private Color C1;
        private Color C2;
        private Color C3;
        private Color C4;
        private SolidBrush B1;
        private Pen P1;

        private Pen P2;
        protected override void ColorHook()
        {
            C1 = GetColor("DownGradient1");
            C2 = GetColor("DownGradient2");
            C3 = GetColor("NoneGradient1");
            C4 = GetColor("NoneGradient2");

            B1 = new SolidBrush(GetColor("Text"));

            P1 = new Pen(GetColor("Border1"));
            P2 = new Pen(GetColor("Border2"));
        }

        protected override void PaintHook()
        {
            switch (State)
            {
                case MouseState.None:
                    DrawGradient(C3, C4, ClientRectangle, 90f);
                    break;
                case MouseState.Over:
                    break;
                //DrawGradient(C5, C6, ClientRectangle, 90.0F)
                case MouseState.Down:
                    DrawGradient(C1, C2, ClientRectangle, 90f);
                    break;
            }

            DrawText(B1, HorizontalAlignment.Center, 0, 0);

            DrawBorders(P1, 1);
            DrawBorders(P2);

            DrawCorners(BackColor);
        }
    }
    
}

