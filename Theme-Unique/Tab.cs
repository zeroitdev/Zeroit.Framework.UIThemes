// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 06-04-2018
// ***********************************************************************
// <copyright file="Tab.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Text;


namespace Zeroit.Framework.UIThemes.Unique
{

    public class UniqueTabControl : TabControl
    {
        public UniqueTabControl()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            ItemSize = new Size(80, 35);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            try
            {
                SelectedTab.BackColor = Color.FromArgb(72, 72, 72);
            }
            catch (Exception ex)
            {
            }
            base.OnPaint(e);
            g.Clear(BackColor);
            g.FillRectangle(new SolidBrush(Color.FromArgb(52, 52, 52)), rect);
            g.DrawRectangle(new Pen(Brushes.Black), rect);
            for (var i = 0; i < TabCount; i++)
            {
                Rectangle textRectangle = new Rectangle(new Point(GetTabRect(i).Location.X + 5, GetTabRect(i).Location.Y + 1), new Size(GetTabRect(i).Width, GetTabRect(i).Height - 5));
                if (i == SelectedIndex)
                {
                    Rectangle tabrect = new Rectangle(new Point(GetTabRect(i).Location.X + 3, GetTabRect(i).Location.Y + 3), new Size(GetTabRect(i).Width - 6, GetTabRect(i).Height - 9));
                    LinearGradientBrush buttonrect = new LinearGradientBrush(rect, Color.FromArgb(56, 68, 85), Color.FromArgb(41, 42, 46), 90);
                    g.FillPath(buttonrect, Draw.RoundRect(tabrect, 3));
                    g.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(tabrect, 3));
                    g.DrawString(TabPages[i].Text, new Font("Verdana", 8F, FontStyle.Bold), new SolidBrush(Color.FromArgb(255, 255, 255)), textRectangle, new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });
                }
                else
                {
                    g.DrawString(TabPages[i].Text, new Font("Verdana", 8F, FontStyle.Regular), new SolidBrush(Color.FromArgb(255, 255, 255)), textRectangle, new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });
                }
            }
            e.Graphics.DrawImage(b, new Point(0, 0));
            g.Dispose();
            b.Dispose();
        }
    }

}