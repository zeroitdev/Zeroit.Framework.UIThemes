// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
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

namespace Zeroit.Framework.UIThemes.Cypher
{
    public class CypherxGroupBox : Panel
    {
        Color Stroke = Color.FromArgb(80, 71, 62);
        public CypherxGroupBox()
        {
            BackColor = Color.Transparent;
        }
        string _t = "";
        public string Header
        {
            get { return _t; }
            set
            {
                _t = value;
                Invalidate();
            }
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            using (Bitmap b = new Bitmap(Width, Height))
            {
                using (Graphics g = Graphics.FromImage(b))
                {
                    SizeF M = g.MeasureString(_t, Font);
                    GraphicsPath Outline = Draw.RoundedRectangle(0, (int)(M.Height / 2), Width - 1, Height - 1, 10, 1);
                    g.Clear(BackColor);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(25, 18, 12)), new Rectangle(0, (int)(M.Height / 2), Width - 1, Height - 1));
                    g.DrawPath(new Pen(Stroke), Outline);

                    g.FillRectangle(new SolidBrush(Color.FromArgb(25, 18, 12)), new Rectangle(10, (int)(M.Height / 2) - 2, (int)(M.Width + 10), (int)M.Height));
                    g.DrawString(_t, Font, new SolidBrush(Stroke), 12, 2);
                    e.Graphics.DrawImage(b, 0, 0);
                }
            }
            base.OnPaint(e);
        }
    }


}
