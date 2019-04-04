// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ComboBox.cs" company="Zeroit Dev Technologies">
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
    public class BonfireCombo : ComboBox
    {
        public BonfireCombo()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            Font = new Font("Verdana", 8);
            SubscribeToEvents();
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();

            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
            DoubleBuffered = true;
            ItemHeight = 20;

        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics G = e.Graphics;

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.Clear(Parent.BackColor);

            Rectangle mainRect = new Rectangle(0, 0, Width - 1, Height - 1);
            G.FillRectangle(Brushes.White, mainRect);
            G.DrawRectangle(new Pen(Color.FromArgb(225, 225, 225)), mainRect);

            Point[] triangle = new Point[] {
            new Point(Width - 14, 16),
            new Point(Width - 18, 10),
            new Point(Width - 10, 10)
        };
            G.FillPolygon(Brushes.DarkGray, triangle);
            G.DrawLine(new Pen(Color.FromArgb(225, 225, 225)), new Point(Width - 27, 0), new Point(Width - 27, Height - 1));

            try
            {
                if (Items.Count > 0)
                {
                    if (!(SelectedIndex == -1))
                    {
                        int textX = 6;
                        int textY = Convert.ToInt32(((this.Height - 1) / 2.0) - (G.MeasureString(Items[SelectedIndex].ToString(), Font).Height / 2.0) + 1);
                        G.DrawString(Items[SelectedIndex].ToString(), Font, Brushes.Gray, new Point(textX, textY));
                    }
                    else
                    {
                        int textX = 6;
                        int textY = (int)(((this.Height - 1) / 2.0) - (G.MeasureString(Items[0].ToString(), Font).Height / 2.0) + 1);
                        G.DrawString(Items[0].ToString(), Font, Brushes.Gray, new Point(textX, textY));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void replaceItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            e.DrawBackground();

            Graphics G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;

            Rectangle rect = new Rectangle(e.Bounds.X - 1, e.Bounds.Y - 1, e.Bounds.Width + 1, e.Bounds.Height + 1);

            try
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    G.FillRectangle(new SolidBrush(Color.FromArgb(20, 160, 230)), rect);
                    G.DrawString(base.GetItemText(base.Items[e.Index]), Font, Brushes.White, new Rectangle(e.Bounds.X + 6, e.Bounds.Y + 3, e.Bounds.Width, e.Bounds.Height));
                    G.DrawRectangle(new Pen(Color.FromArgb(20, 160, 230)), rect);
                }
                else
                {
                    G.FillRectangle(Brushes.White, rect);
                    G.DrawString(base.GetItemText(base.Items[e.Index]), Font, Brushes.DarkGray, new Rectangle(e.Bounds.X + 6, e.Bounds.Y + 3, e.Bounds.Width, e.Bounds.Height));
                    G.DrawRectangle(new Pen(Color.FromArgb(20, 160, 230)), rect);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        protected override void OnSelectedItemChanged(System.EventArgs e)
        {
            base.OnSelectedItemChanged(e);
            Invalidate();
        }


        
        private bool EventsSubscribed = false;
        private void SubscribeToEvents()
        {
            if (EventsSubscribed)
                return;
            else
                EventsSubscribed = true;

            this.DrawItem += replaceItem;
        }

    }
}
