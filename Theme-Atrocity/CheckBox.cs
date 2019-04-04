// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;



namespace Zeroit.Framework.UIThemes.Atrocity
{

    public class cBox : ThemeControl153
    {

        #region " Properties "
        private bool _CheckedState;
        public bool CheckedState
        {
            get { return _CheckedState; }
            set
            {
                _CheckedState = value;
                Invalidate();
            }
        }
        #endregion
        public cBox()
        {
            Click += changeCheck;
            Size = new Size(90, 15);
            MinimumSize = new Size(16, 16);
            MaximumSize = new Size(600, 16);
            CheckedState = false;

            SetColor("bg", 41, 41, 41);
            SetColor("Text", 0, 133, 157);

            SetColor("g1", 132, 192, 240);
            SetColor("g2", 78, 123, 168);
            SetColor("g3", 98, 159, 220);
            SetColor("g4", 62, 102, 147);

            SetColor("g5", 80, 80, 80);
        }

        Color g1;
        Color g2;
        Color g3;
        Color g4;

        Color g5;
        protected override void ColorHook()
        {
            g1 = GetColor("g1");
            g2 = GetColor("g2");
            g3 = GetColor("g3");
            g4 = GetColor("g4");
            g5 = GetColor("g5");
        }

        protected override void PaintHook()
        {
            G.Clear(GetColor("bg"));


            switch (CheckedState)
            {
                case true:
                    DrawGradient(g1, g2, 3, 3, 9, 9, 90);
                    DrawGradient(g3, g4, 4, 4, 7, 7, 90);
                    break;
                case false:
                    DrawGradient(g5, g5, 0, 0, 15, 15, 90);
                    break;
            }


            G.DrawRectangle(new Pen(GetColor("Text")), 0, 0, 14, 14);
            G.DrawRectangle(Pens.Black, 1, 1, 12, 12);
            DrawText(new SolidBrush(GetColor("Text")), HorizontalAlignment.Left, 17, 0);
        }

        public void changeCheck(object sender, EventArgs e)
        {
            switch (CheckedState)
            {
                case true:
                    CheckedState = false;
                    break;
                case false:
                    CheckedState = true;
                    break;
            }
        }
    }

    
}

