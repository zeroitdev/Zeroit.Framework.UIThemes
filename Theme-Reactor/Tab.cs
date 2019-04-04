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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Reactor
{
    public class ReactorTabControl : TabControl
    {

        #region " Control Help - Properties & Flicker Control "
        private LinearGradientBrush DrawGradientBrush;
        private LinearGradientBrush DrawGradientBrush2;
        private Color _TabBrColor;
        public Color TabBorderColor
        {
            get { return _TabBrColor; }
            set
            {
                _TabBrColor = value;
                Invalidate();
            }
        }
        private Color _ControlBColor;
        public Color TabTextColor
        {
            get { return _ControlBColor; }
            set
            {
                _ControlBColor = value;
                Invalidate();
            }
        }
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
        #endregion

        public ReactorTabControl()
            : base()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

            TabBorderColor = Color.White;
            TabTextColor = Color.White;

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            base.OnPaint(e);

            Rectangle r2 = new Rectangle(0, 0, Width - 1, 25);
            Rectangle r3 = new Rectangle(0, 0, Width - 1, 25);
            Rectangle r4 = new Rectangle(2, 0, Width - 1, 13);
            Rectangle ItemBounds = new Rectangle();
            SolidBrush TextBrush = new SolidBrush(Color.Empty);
            SolidBrush TabBrush = new SolidBrush(Color.DimGray);
            LinearGradientBrush dgb2 = new LinearGradientBrush(r4, Color.FromArgb(50, Color.White), Color.FromArgb(25, Color.White), 90);

            G.Clear(Color.FromArgb(32, 32, 32));
            DrawGradientBrush2 = new LinearGradientBrush(r3, Color.FromArgb(10, 10, 10), Color.FromArgb(50, 50, 50), 90);
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(28, 28, 28))), new Rectangle(1, 1, Width - 3, Height - 3));

            G.FillRectangle(DrawGradientBrush2, r2);
            G.FillRectangle(dgb2, r4);

            for (int TabItemIndex = 0; TabItemIndex <= this.TabCount - 1; TabItemIndex++)
            {
                ItemBounds = this.GetTabRect(TabItemIndex);

                if (Convert.ToBoolean(TabItemIndex & 1))
                {
                    TabBrush.Color = Color.Transparent;
                }
                else
                {
                    TabBrush.Color = Color.Transparent;
                }
                G.FillRectangle(TabBrush, ItemBounds);
                Pen BorderPen = default(Pen);
                if (TabItemIndex == SelectedIndex)
                {
                    BorderPen = new Pen(Color.Transparent, 1);
                    LinearGradientBrush dgb = new LinearGradientBrush(new Rectangle(ItemBounds.Location.X + 3, ItemBounds.Location.Y + 3, ItemBounds.Width - 8, ItemBounds.Height - 6), Color.FromArgb(175, 219, 78, 0), Color.FromArgb(175, 229, 98, 0), 90);
                    LinearGradientBrush gloss = new LinearGradientBrush(new Rectangle(ItemBounds.Location.X + 3, ItemBounds.Location.Y + 3, ItemBounds.Width - 8, ItemBounds.Height / 2 - 5), Color.FromArgb(80, Color.White), Color.FromArgb(20, Color.White), 90);
                    G.FillRectangle(dgb, new Rectangle(ItemBounds.Location.X + 3, ItemBounds.Location.Y + 3, ItemBounds.Width - 8, ItemBounds.Height - 6));
                    G.FillRectangle(gloss, new Rectangle(ItemBounds.Location.X + 3, ItemBounds.Location.Y + 3, ItemBounds.Width - 8, ItemBounds.Height / 2 - 4));
                    G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(10, 10, 10))), new Rectangle(ItemBounds.Location.X + 3, ItemBounds.Location.Y + 3, ItemBounds.Width - 8, ItemBounds.Height - 6));
                    G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(100, 230, 90, 0))), new Rectangle(ItemBounds.Location.X + 4, ItemBounds.Location.Y + 4, ItemBounds.Width - 10, ItemBounds.Height - 8));
                    Rectangle r1 = new Rectangle(1, 1, Width - 1, 3);
                }
                else
                {
                    BorderPen = new Pen(Color.Transparent, 1);
                }

                G.DrawRectangle(BorderPen, new Rectangle(ItemBounds.Location.X + 3, ItemBounds.Location.Y + 1, ItemBounds.Width - 8, ItemBounds.Height - 4));

                BorderPen.Dispose();

                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;

                if (this.SelectedIndex == TabItemIndex)
                {
                    TextBrush.Color = TabTextColor;
                }
                else
                {
                    TextBrush.Color = Color.DimGray;
                }
                G.DrawString(this.TabPages[TabItemIndex].Text, this.Font, TextBrush, new RectangleF(this.GetTabRect(TabItemIndex).Location.X, this.GetTabRect(TabItemIndex).Location.Y + 2, 80, 15), sf);
                try
                {
                    this.TabPages[TabItemIndex].BackColor = Color.FromArgb(32, 32, 32);
                }
                catch
                {
                }
            }
            try
            {
                foreach (TabPage tabpg in this.TabPages)
                {
                    tabpg.BorderStyle = BorderStyle.None;
                }
            }
            catch
            {
            }

            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(10, 10, 10))), 2, 24, Width - 2, 24);
            G.DrawRectangle((new Pen(new SolidBrush(Color.Black))), new Rectangle(1, 1, Width - 3, Height - 3));
            G.DrawRectangle((new Pen(new SolidBrush(Color.FromArgb(70, 70, 70)))), new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, Width, 0);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, 0, Height);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), Width - 1, 0, Width - 1, Height);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(31, 31, 31))), 2, 2, Width - 3, 2);
        }
    }

}


