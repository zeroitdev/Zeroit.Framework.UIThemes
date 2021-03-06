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

namespace Zeroit.Framework.UIThemes.Crystal
{
    public class CrystalClearTabControl : TabControl
    {

        private Color _BG;
        public override Color BackColor
        {
            get { return _BG; }
            set { _BG = value; }
        }

        public CrystalClearTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(230, 230, 230);
        }
        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Top;
        }

        public Pen ToPen(Color color)
        {
            return new Pen(color);
        }

        public Brush ToBrush(Color color)
        {
            return new SolidBrush(color);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            try
            {
                SelectedTab.BackColor = BackColor;
            }
            catch
            {
            }
            G.Clear(BackColor);
            G.DrawRectangle(new Pen(Color.FromArgb(170, 170, 170)), new Rectangle(0, 21, Width - 1, Height - 22));
            for (int i = 0; i <= TabCount - 1; i++)
            {
                if (i == SelectedIndex)
                {
                    Rectangle x2 = new Rectangle(GetTabRect(i).X - 2, GetTabRect(i).Y, GetTabRect(i).Width, GetTabRect(i).Height - 2);
                    Rectangle x3 = new Rectangle(GetTabRect(i).X - 2, GetTabRect(i).Y, GetTabRect(i).Width, GetTabRect(i).Height - 1);
                    Rectangle x4 = new Rectangle(GetTabRect(i).X - 2, GetTabRect(i).Y, GetTabRect(i).Width, GetTabRect(i).Height);
                    LinearGradientBrush G1 = new LinearGradientBrush(x3, Color.FromArgb(10, 0, 0, 0), Color.FromArgb(230, 230, 230), 90f);
                    HatchBrush HB = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(10, Color.Black), Color.Transparent);

                    G.FillRectangle(HB, x3);
                    HB.Dispose();
                    G.FillRectangle(G1, x3);
                    G1.Dispose();
                    G.DrawLine(new Pen(Color.FromArgb(170, 170, 170)), x2.Location, new Point(x2.Location.X, x2.Location.Y + x2.Height));
                    G.DrawLine(new Pen(Color.FromArgb(170, 170, 170)), new Point(x2.Location.X + x2.Width, x2.Location.Y), new Point(x2.Location.X + x2.Width, x2.Location.Y + x2.Height));
                    G.DrawLine(new Pen(Color.FromArgb(170, 170, 170)), new Point(x2.Location.X, x2.Location.Y), new Point(x2.Location.X + x2.Width, x2.Location.Y));
                    G.DrawString(TabPages[i].Text, Font, new SolidBrush(Color.Black), x4, new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });
                }
                else
                {
                    Rectangle x2 = new Rectangle(GetTabRect(i).X - 2, GetTabRect(i).Y + 3, GetTabRect(i).Width, GetTabRect(i).Height - 5);
                    LinearGradientBrush G1 = new LinearGradientBrush(x2, Color.FromArgb(215, 215, 215), Color.FromArgb(230, 230, 230), -90f);
                    G.FillRectangle(G1, x2);
                    G1.Dispose();
                    G.DrawRectangle(new Pen(Color.FromArgb(170, 170, 170)), x2);
                    G.DrawString(TabPages[i].Text, Font, new SolidBrush(Color.Black), x2, new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });
                }
            }

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

}



