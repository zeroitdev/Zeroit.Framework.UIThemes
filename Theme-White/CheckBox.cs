// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
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
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.WhitePure
{
    public class WhiteCheckBox : ThemeControl153
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
        public WhiteCheckBox()
        {
            Click += changeCheck;
            BackColor = Color.FromArgb(255, 255, 255);
            Size = new Size(120, 16);
            MinimumSize = new Size(16, 16);
            MaximumSize = new Size(600, 16);

            SetColor("Text", Color.DarkBlue);

            SetColor("Border1", 225, 225, 225);
            SetColor("Border2", 150, 150, 150);

            SetColor("Grad1", 225, 225, 225);
            SetColor("Grad2", 185, 185, 185);
        }
        Pen P1;
        Pen P2;
        Brush B1;
        Color c1;
        Color c2;
        protected override void ColorHook()
        {
            P1 = new Pen(GetColor("Border1"));
            P2 = new Pen(GetColor("Border2"));
            B1 = new SolidBrush(GetColor("Text"));

            c1 = GetColor("Grad1");
            c2 = GetColor("Grad2");
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            switch (CheckedState)
            {
                case true:
                    DrawGradient(c2, c1, 0, 0, 14, 14);
                    break;
                case false:
                    G.FillRectangle(new SolidBrush(BackColor), 0, 0, 14, 14);
                    break;
            }
            G.DrawRectangle(P2, 0, 0, 14, 14);
            G.DrawRectangle(P1, 1, 1, 12, 12);
            DrawText(B1, HorizontalAlignment.Left, 17, 0);
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

