// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Seperator.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Xbox
{
    public class XboxSeperator : ThemeControl
    {
        private Orientation _Direction;
        public Orientation Direction
        {
            get { return _Direction; }
            set
            {
                _Direction = value;
                Invalidate();
            }
        }

        public override void PaintHook()
        {
            G.Clear(Color.LightGray);
            DrawGradient(Color.GhostWhite, Color.LightGray, 0, 0, Width, 5, 90);
            if (_Direction == Orientation.Horizontal)
            {
                G.DrawLine(new Pen(Color.FromArgb(190, 190, 190)), 0, Height / 2, Width, Height / 2);
                G.DrawLine(Pens.LightGray, 0, Height / 2 + 1, Width, Height / 2 + 1);
            }
            else
            {
                G.DrawLine(Pens.LightGray, Width / 2, 0, Width / 2, Height);
                G.DrawLine(new Pen(Color.FromArgb(190, 190, 190)), Width / 2 + 1, 0, Width / 2 + 1, Height);
                DrawGradient(Color.FromArgb(52, 18, 150), Color.FromArgb(32, 32, 32), 0, 0, Width, 10, 90);
            }
        }
    }

}


