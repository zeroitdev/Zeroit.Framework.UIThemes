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

namespace Zeroit.Framework.UIThemes.Fetus
{
    public class YoutubeCheckbox : ThemeControl
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
        public YoutubeCheckbox()
        {
            Click += changeCheck;
            Size = new Size(90, 15);
            MinimumSize = new Size(16, 16);
            MaximumSize = new Size(600, 16);
            CheckedState = false;
        }
        private Pen P1;
        private Pen P2;
        public override void PaintHook()
        {
            P1 = new Pen(Color.FromArgb(250, 250, 250));
            P2 = new Pen(Color.FromArgb(160, 160, 160));

            G.Clear(Color.FromArgb(224, 224, 224));

            switch (CheckedState)
            {
                case true:
                    DrawGradient(Color.FromArgb(160, 26, 26), Color.FromArgb(143, 16, 16), 3, 3, 9, 9, 90);

                    break;
                case false:
                    DrawGradient(Color.FromArgb(215, 215, 215), Color.FromArgb(220, 220, 220), 0, 0, 15, 15, 90);

                    break;
            }
            G.DrawRectangle(P2, 0, 0, 14, 14);
            G.DrawRectangle(P1, 1, 1, 12, 12);
            DrawText(HorizontalAlignment.Left, Color.Black, 17, 0);

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

