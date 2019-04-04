// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TabLagFree.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Ghost
{

    public class GhostTabControlLagFree : TabControl
    {
        private Color _Forecolor = Color.White;
        public Color ForeColor
        {
            get { return _Forecolor; }
            set { _Forecolor = value; }
        }

        public GhostTabControlLagFree()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DoubleBuffered = true;
            foreach (TabPage p in TabPages)
            {
                try
                {
                    p.BackColor = Color.Black;
                    p.BackColor = Color.Transparent;
                }
                catch (Exception ex)
                {
                }
            }
        }
        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Top;
            foreach (TabPage p in TabPages)
            {
                try
                {
                    p.BackColor = Color.Black;
                    p.BackColor = Color.Transparent;
                }
                catch (Exception ex)
                {
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            G.Clear(Color.FromArgb(60, 60, 60));

            HatchBrush asdf = default(HatchBrush);
            asdf = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(35, Color.Black), Color.FromArgb(0, Color.Gray));
            G.FillRectangle(new SolidBrush(Color.FromArgb(60, 60, 60)), new Rectangle(0, 0, Width, Height));
            asdf = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.DimGray);
            G.FillRectangle(asdf, 0, 0, Width, Height);
            G.FillRectangle(new SolidBrush(Color.FromArgb(230, 20, 20, 20)), 0, 0, Width, Height);

            G.FillRectangle(Brushes.Black, new Rectangle(new Point(0, 4), new Size(Width - 2, 20)));

            G.DrawRectangle(Pens.Black, new Rectangle(new Point(0, 3), new Size(Width - 1, Height - 4)));
            G.DrawRectangle(new Pen(Color.FromArgb(90, 90, 90)), new Rectangle(new Point(1, 4), new Size(Width - 3, Height - 6)));

            for (int i = 0; i <= TabCount - 1; i++)
            {
                if (i == SelectedIndex)
                {
                    Rectangle x2 = new Rectangle(GetTabRect(i).X, GetTabRect(i).Y + 2, GetTabRect(i).Width + 2, GetTabRect(i).Height - 1);

                    asdf = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(35, Color.Black), Color.FromArgb(0, Color.Gray));
                    G.FillRectangle(new SolidBrush(Color.FromArgb(60, 60, 60)), new Rectangle(GetTabRect(i).X, GetTabRect(i).Y + 3, GetTabRect(i).Width + 1, GetTabRect(i).Height - 2));
                    asdf = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.DimGray);
                    G.FillRectangle(asdf, new Rectangle(GetTabRect(i).X, GetTabRect(i).Y + 3, GetTabRect(i).Width + 1, GetTabRect(i).Height - 2));
                    G.FillRectangle(new SolidBrush(Color.FromArgb(230, 20, 20, 20)), new Rectangle(GetTabRect(i).X, GetTabRect(i).Y + 3, GetTabRect(i).Width + 1, GetTabRect(i).Height - 2));

                    LinearGradientBrush gradient = new LinearGradientBrush(new Rectangle(GetTabRect(i).X, GetTabRect(i).Y + 2, GetTabRect(i).Width + 2, GetTabRect(i).Height - 1), Color.FromArgb(15, Color.White), Color.Transparent, 90f);
                    G.FillRectangle(gradient, new Rectangle(GetTabRect(i).X, GetTabRect(i).Y + 2, GetTabRect(i).Width + 2, GetTabRect(i).Height - 1));
                    G.DrawLine(new Pen(Color.FromArgb(90, 90, 90)), new Point(GetTabRect(i).Right, 4), new Point(GetTabRect(i).Right, GetTabRect(i).Height + 3));
                    if (!(SelectedIndex == 0))
                    {
                        G.DrawLine(new Pen(Color.FromArgb(90, 90, 90)), new Point(GetTabRect(i).X, 4), new Point(GetTabRect(i).X, GetTabRect(i).Height + 3));
                        G.DrawLine(new Pen(Color.FromArgb(90, 90, 90)), new Point(1, GetTabRect(i).Height + 3), new Point(GetTabRect(i).X, GetTabRect(i).Height + 3));
                    }
                    G.DrawLine(new Pen(Color.FromArgb(90, 90, 90)), new Point(GetTabRect(i).Right, GetTabRect(i).Height + 3), new Point(Width - 2, GetTabRect(i).Height + 3));
                    G.DrawString(TabPages[i].Text, Font, new SolidBrush(_Forecolor), x2, new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });
                }
                else
                {
                    Rectangle x2 = new Rectangle(GetTabRect(i).X, GetTabRect(i).Y + 2, GetTabRect(i).Width + 2, GetTabRect(i).Height - 1);
                    G.DrawString(TabPages[i].Text, Font, new SolidBrush(_Forecolor), x2, new StringFormat
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
