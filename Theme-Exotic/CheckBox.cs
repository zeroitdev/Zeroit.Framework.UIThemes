// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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
using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Exotic
{
    public class ExoticCheck : ThemeControl
    {
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
        public ExoticCheck()
        {
            Click += changeCheck;
            Size = new Size(90, 15);
            MinimumSize = new Size(16, 16);
            MaximumSize = new Size(600, 16);
            CheckedState = false;
        }
        public override void PaintHook()
        {
            int V = 0;
            G.Clear(Color.FromArgb(V, V, V));
            switch (CheckedState)
            {
                case true:
                    DrawGradient(Color.FromArgb(240, 248, 255), Color.FromArgb(0, 0, 0), 3, 3, 9, 9, 90);
                    DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(240, 248, 255), 4, 4, 7, 7, 90);
                    break;
                case false:
                    DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(0, 0, 0), 0, 0, 15, 15, 90);
                    break;
            }
            G.DrawRectangle(Pens.Black, 0, 0, 14, 14);
            G.DrawRectangle(Pens.AliceBlue, 1, 1, 12, 12);
            DrawText(HorizontalAlignment.Left, Color.AliceBlue, 17, 0);
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


