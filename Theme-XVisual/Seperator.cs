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
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.XVisual
{

    public class xVisualSeperator : Control
    {

        public enum LineStyle
        {
            Horizontal,
            Vertical
        }
        private LineStyle _Style;
        public LineStyle Style
        {
            get { return _Style; }
            set
            {
                _Style = value;
                Invalidate();
            }
        }

        public xVisualSeperator()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(205, 205, 205);
            _Style = LineStyle.Horizontal;

            Size = new Size(174, 3);

            DoubleBuffered = true;
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            base.OnPaint(e);

            Size = Size;
            _Style = Style;

            G.Clear(BackColor);

            G.SmoothingMode = SmoothingMode.HighQuality;

            switch (_Style)
            {
                case LineStyle.Horizontal:
                    G.DrawLine(Draw.GetPen(Color.Black), 0, 0, Width - 1, Height - 3);
                    G.DrawLine(Draw.GetPen(Color.FromArgb(99, 97, 94)), 0, 1, Width - 1, Height - 2);
                    break;
                case LineStyle.Vertical:
                    G.DrawLine(Draw.GetPen(Color.Black), 0, 0, 0, Height - 1);
                    G.DrawLine(Draw.GetPen(Color.FromArgb(99, 97, 94)), 1, 0, 1, Height - 1);
                    break;
            }

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

}

