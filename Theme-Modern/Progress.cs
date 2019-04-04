// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Progress.cs" company="Zeroit Dev Technologies">
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


namespace Zeroit.Framework.UIThemes.Modern
{
    public class ModernProgress : Control
    {
        private int _Value;
        public int Value
        {
            get { return _Value; }
            set
            {
                _Value = value;
                Invalidate();
            }
        }
        private int _Maximum = 100;
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value == 0)
                    value = 1;
                _Maximum = value;
                Invalidate();
            }
        }
        Color C1 = Color.FromArgb(240, 240, 240);
        Color C2 = Color.FromArgb(230, 230, 230);
        Color C3 = Color.FromArgb(190, 190, 190);
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            int V = Width * _Value / _Maximum;
            using (Bitmap B = new Bitmap(Width, Height))
            {
                using (Graphics G = Graphics.FromImage(B))
                {
                    Draw.Gradient(G, C2, C1, 1, 1, Width - 2, Height - 2);
                    G.DrawRectangle(new Pen(C2), 1, 1, V - 3, Height - 3);
                    Draw.Gradient(G, C1, C2, 2, 2, V - 4, Height - 4);

                    G.FillRectangle(new SolidBrush(Color.FromArgb(50, 255, 255, 255)), 2, 2, V - 4, Convert.ToInt32(Height / 2) - 2);
                    G.DrawRectangle(new Pen(C3), 0, 0, Width - 1, Height - 1);

                    e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
                }
            }
        }
    }


}


