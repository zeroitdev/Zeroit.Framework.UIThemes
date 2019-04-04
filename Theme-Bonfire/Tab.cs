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
using System;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Bonfire
{
    public class BonfireTabControl : TabControl
    {
        public BonfireTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            ItemSize = new Size(0, 30);
            Font = new Font("Verdana", 8);
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Top;
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            Graphics G = e.Graphics;

            Pen borderPen = new Pen(Color.FromArgb(225, 225, 225));

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.Clear(Parent.BackColor);

            Rectangle fillRect = new Rectangle(2, ItemSize.Height + 2, Width - 6, Height - ItemSize.Height - 3);
            G.FillRectangle(Brushes.White, fillRect);
            G.DrawRectangle(borderPen, fillRect);

            Color FontColor = new Color();

            for (var i = 0; i < TabCount; i++)
            {

                Rectangle mainRect = GetTabRect(i);

                if (i == SelectedIndex)
                {

                    G.FillRectangle(new SolidBrush(Color.White), mainRect);
                    G.DrawRectangle(borderPen, mainRect);
                    G.DrawLine(new Pen(Color.FromArgb(20, 160, 230)), new Point(mainRect.X + 1, mainRect.Y), new Point(mainRect.X + mainRect.Width - 1, mainRect.Y));
                    G.DrawLine(Pens.White, new Point(mainRect.X + 1, mainRect.Y + mainRect.Height), new Point(mainRect.X + mainRect.Width - 1, mainRect.Y + mainRect.Height));
                    FontColor = Color.FromArgb(20, 160, 230);

                }
                else
                {

                    G.FillRectangle(new SolidBrush(Color.FromArgb(245, 245, 245)), mainRect);
                    G.DrawRectangle(borderPen, mainRect);
                    FontColor = Color.FromArgb(160, 160, 160);

                }

                int titleX = Convert.ToInt32((mainRect.Location.X + mainRect.Width / 2.0) - (G.MeasureString(TabPages[i].Text, Font).Width / 2.0));
                int titleY = Convert.ToInt32((mainRect.Location.Y + mainRect.Height / 2.0) - (G.MeasureString(TabPages[i].Text, Font).Height / 2.0));
                G.DrawString(TabPages[i].Text, Font, new SolidBrush(FontColor), new Point(titleX, titleY));

                try
                {
                    TabPages[i].BackColor = Color.White;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }


            }

        }

    }
}
