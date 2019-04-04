// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Butter
{
    public class ButterscotchTabControl : TabControl
    {

        public ButterscotchTabControl()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            ItemSize = new Size(100, 35);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            try
            {
                SelectedTab.BackColor = Color.FromArgb(100, 90, 80);
            }
            catch
            {
            }
            base.OnPaint(e);
            g.Clear(BackColor);
            g.FillRectangle(new SolidBrush(Color.FromArgb(40, 37, 33)), rect);
            g.DrawRectangle(new Pen(Brushes.Black), rect);
            for (int i = 0; i <= TabCount - 1; i++)
            {
                Rectangle textRectangle = new Rectangle(new Point(GetTabRect(i).Location.X + 3, GetTabRect(i).Location.Y), new Size(GetTabRect(i).Width - 7, GetTabRect(i).Height));
                if (i == SelectedIndex)
                {
                    Rectangle tabrect = new Rectangle(new Point(GetTabRect(i).Location.X + 1, GetTabRect(i).Location.Y), new Size(GetTabRect(i).Width - 2, GetTabRect(i).Height));
                    LinearGradientBrush buttonrect = new LinearGradientBrush(tabrect, Color.FromArgb(100, 90, 80), Color.FromArgb(48, 43, 39), 90);
                    g.FillPath(buttonrect, Draw.RoundRect(tabrect, 5));
                    g.DrawString(TabPages[i].Text, new Font("Segoe UI", 10, FontStyle.Bold), new SolidBrush(Color.FromArgb(25, 23, 22)), textRectangle, new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Near
                    });
                }
                else
                {
                    Rectangle tabrect = new Rectangle(new Point(GetTabRect(i).Location.X + 1, GetTabRect(i).Location.Y), new Size(GetTabRect(i).Width - 2, GetTabRect(i).Height));
                    LinearGradientBrush buttonrect = new LinearGradientBrush(tabrect, Color.FromArgb(57, 52, 46), Color.FromArgb(92, 83, 74), 90);

                    g.FillPath(buttonrect, Draw.RoundRect(tabrect, 5));
                    g.DrawString(TabPages[i].Text, new Font("Segoe UI", 10, FontStyle.Regular), new SolidBrush(Color.FromArgb(255, 255, 255)), textRectangle, new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Near
                    });
                }
            }
            e.Graphics.DrawImage(b, new Point(0, 0));
            g.Dispose();
            b.Dispose();
        }
    }


}
