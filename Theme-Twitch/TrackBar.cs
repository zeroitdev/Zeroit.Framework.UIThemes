// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TrackBar.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Twitch
{
    public class TwitchTrackBar : ThemeControl154
    {

        public TwitchTrackBar()
        {
            Width = 100;
            Height = 10;
            Transparent = true;
            BackColor = Color.Transparent;
            Cursor = Cursors.Hand;
            Size = new Size(125, 30);
        }


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            switch (State)
            {
                case MouseState.Over:
                    DrawGradient(Color.FromArgb(222, 209, 246), Color.FromArgb(171, 134, 231), new Rectangle(0, 10, Width, 10));
                    G.DrawRectangle(Pens.Black, new Rectangle(0, 10, Width, 10));
                    DrawGradient(Color.FromArgb(245, 245, 245), Color.FromArgb(206, 206, 206), new Rectangle(Width - 7, 6, 7, 17));
                    G.DrawRectangle(Pens.Black, new Rectangle(Width - 7, 6, 7, 17));
                    break;
                case MouseState.None:
                    DrawGradient(Color.FromArgb(222, 209, 246), Color.FromArgb(171, 134, 231), new Rectangle(0, 10, Width, 10));
                    G.DrawRectangle(Pens.Black, new Rectangle(0, 10, Width, 10));
                    DrawGradient(Color.FromArgb(207, 207, 207), Color.FromArgb(150, 150, 150), new Rectangle(Width - 7, 6, 7, 17));
                    G.DrawRectangle(Pens.Black, new Rectangle(Width - 7, 6, 7, 17));
                    break;
                case MouseState.Down:
                    DrawGradient(Color.FromArgb(222, 209, 246), Color.FromArgb(171, 134, 231), new Rectangle(0, 10, Width, 10));
                    G.DrawRectangle(Pens.Black, new Rectangle(0, 10, Width, 10));
                    DrawGradient(Color.FromArgb(144, 144, 144), Color.FromArgb(100, 100, 100), new Rectangle(Width - 7, 6, 7, 17));
                    G.DrawRectangle(Pens.Black, new Rectangle(Width - 7, 6, 7, 17));
                    break;
                default:
                    DrawGradient(Color.FromArgb(222, 209, 246), Color.FromArgb(171, 134, 231), new Rectangle(0, 10, Width, 10));
                    G.DrawRectangle(Pens.Black, new Rectangle(0, 10, Width, 10));
                    DrawGradient(Color.FromArgb(207, 207, 207), Color.FromArgb(150, 150, 150), new Rectangle(Width - 7, 6, 7, 17));
                    G.DrawRectangle(Pens.Black, new Rectangle(Width - 7, 6, 7, 17));
                    break;
            }

        }
    }

}

