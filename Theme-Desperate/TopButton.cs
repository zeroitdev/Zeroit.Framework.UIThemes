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


namespace Zeroit.Framework.UIThemes.Desperate
{

    public class DesperateTopButton : ThemeControl
    {
        private Color _aColor;
        public Color AccentColor
        {
            get { return _aColor; }
            set
            {
                _aColor = value;
                Invalidate();
            }
        }
        private bool _cStyle;
        public bool DarkTheme
        {
            get { return _cStyle; }
            set
            {
                _cStyle = value;
                Invalidate();
            }
        }
        public DesperateTopButton()
        {
            Size = new Size(11, 5);
            AccentColor = Color.DodgerBlue;
            DarkTheme = true;
        }
        public override void PaintHook()
        {
            G.Clear(Color.FromArgb(102, 102, 102));
            int GradA = 0;
            int GradB = 0;
            int GradC = 0;
            switch (DarkTheme)
            {
                case true:
                    GradA = 61;
                    GradB = 49;
                    GradC = 51;
                    break;
                case false:
                    GradA = 200;
                    GradB = 155;
                    GradC = 155;
                    break;
            }
            switch (MouseState)
            {
                case State.MouseNone:
                    DrawGradient(Color.FromArgb(GradA, GradA, GradA), Color.FromArgb(GradB, GradB, GradB), 0, 0, Width, Height, 90);
                    break;
                case State.MouseOver:
                    DrawGradient(Color.FromArgb(GradA, GradA, GradA), Color.FromArgb(GradB, GradB, GradB), 0, 0, Width, Height, 90);
                    break;
                case State.MouseDown:
                    DrawGradient(Color.FromArgb(GradB, GradB, GradB), Color.FromArgb(GradA, GradA, GradA), 0, 0, Width, Height, 90);
                    break;
            }
            DrawBorders(new Pen(new SolidBrush(AccentColor)), Pens.Transparent, ClientRectangle);
            DrawCorners(Color.FromArgb(GradC, GradC, GradC), ClientRectangle);
        }
    }

}


