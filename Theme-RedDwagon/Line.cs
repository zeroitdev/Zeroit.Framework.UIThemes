// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Line.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.RedDwagon
{
    public class RedDwagonLine : Control
    {
        public RedDwagonLine()
        {
            if (Parent is RedDwagonTheme)
            {
                var _with1 = (RedDwagonTheme)Parent;
                BackgroundImage = _with1.BackgroundImage;
            }
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            using (Bitmap b = new Bitmap(Width, Height))
            {
                using (Graphics g = Graphics.FromImage(b))
                {
                    g.Clear(BackColor);

                    Color P1 = Color.FromArgb(255, 0, 0);
                    Color P2 = Color.FromArgb(153, 0, 0);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(34, 34, 34)), new Rectangle(0, 0, Width, Height));
                    Rectangle GRec = new Rectangle(0, Height / 2, Width / 5, 2);
                    using (LinearGradientBrush GBrush = new LinearGradientBrush(GRec, Color.Transparent, P2, LinearGradientMode.Horizontal))
                    {
                        g.FillRectangle(GBrush, GRec);
                    }
                    g.DrawLine(new Pen(P2, 2), new Point(GRec.Width, GRec.Y + 1), new Point(Width - GRec.Width + 1, GRec.Y + 1));

                    GRec = new Rectangle(Width - (Width / 5), Height / 2, Width / 5, 2);
                    using (LinearGradientBrush GBrush = new LinearGradientBrush(GRec, P2, Color.Transparent, LinearGradientMode.Horizontal))
                    {
                        g.FillRectangle(GBrush, GRec);
                    }
                    e.Graphics.DrawImage(b, 0, 0);
                }
            }
            base.OnPaint(e);
        }
    }
}

