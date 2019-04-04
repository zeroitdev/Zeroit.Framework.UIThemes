// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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

namespace Zeroit.Framework.UIThemes.Uplay
{
    public class UPlayTabControl : TabControl
    {

        private Color _BG;
        public override Color BackColor
        {
            get { return _BG; }
            set { _BG = value; }
        }

        public UPlayTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(50, 50, 50);
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
                SelectedTab.BackColor = Color.FromArgb(221, 221, 221);
            }
            catch
            {
            }
            G.Clear(BackColor);
            G.DrawRectangle(new Pen(Color.FromArgb(50, 50, 50)), new Rectangle(0, 10, Width - 1, Height - 2));

            G.Transform = new Matrix(1, 0, 0, 1, 4, 0);
            for (int i = 0; i <= TabCount - 1; i++)
            {
                if (i == SelectedIndex)
                {
                    Rectangle x2 = new Rectangle(GetTabRect(i).X - 1, GetTabRect(i).Y, GetTabRect(i).Width - 3, GetTabRect(i).Height - 2);
                    Rectangle x3 = new Rectangle(GetTabRect(i).X - 1, GetTabRect(i).Y, GetTabRect(i).Width - 3, GetTabRect(i).Height - 2);
                    Rectangle x4 = new Rectangle(GetTabRect(i).X - 1, GetTabRect(i).Y, GetTabRect(i).Width - 3, GetTabRect(i).Height - 2);
                    LinearGradientBrush G1 = new LinearGradientBrush(x3, Color.FromArgb(240, 240, 240), Color.FromArgb(190, 190, 190), 90f);
                    //Dim G2 As New LinearGradientBrush(x3, Color.FromArgb(220,220,220)), Color.FromArgb(220, 220, 230), 90.0F)



                    G.FillRectangle(G1, x3);
                    G1.Dispose();
                    G.DrawLine(new Pen(Color.FromArgb(80, 80, 80)), x2.Location, new Point(x2.Location.X, x2.Location.Y + x2.Height));
                    G.DrawLine(new Pen(Color.FromArgb(80, 80, 80)), new Point(x2.Location.X + x2.Width, x2.Location.Y), new Point(x2.Location.X + x2.Width, x2.Location.Y + x2.Height));
                    G.DrawLine(new Pen(Color.FromArgb(80, 80, 80)), new Point(x2.Location.X, x2.Location.Y), new Point(x2.Location.X + x2.Width, x2.Location.Y));
                    G.DrawString(TabPages[i].Text, Font, new SolidBrush(Color.Black), x4, new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });
                }
                else
                {
                    Rectangle x2 = new Rectangle(GetTabRect(i).X - 2, GetTabRect(i).Y + 3, GetTabRect(i).Width - 7, GetTabRect(i).Height - 5);
                    LinearGradientBrush G1 = new LinearGradientBrush(x2, Color.FromArgb(50, 50, 50), Color.FromArgb(50, 50, 50), -90f);
                    G.FillRectangle(G1, x2);
                    G1.Dispose();
                    G.DrawRectangle(new Pen(Color.FromArgb(50, 50, 50)), x2);
                    G.DrawString(TabPages[i].Text, Font, new SolidBrush(Color.White), x2, new StringFormat
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


