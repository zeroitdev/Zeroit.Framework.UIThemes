// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Butter
{
    public class ButterscotchComboBox : ComboBox
    {
        private int _startIndex = 0;
        private int StartIndex
        {
            get { return _startIndex; }
            set
            {
                _startIndex = value;
                try
                {
                    SelectedIndex = value;
                }
                catch
                {
                }
                Invalidate();
            }
        }

        public void ReplaceItem(System.Object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            LinearGradientBrush sitemrect = new LinearGradientBrush(new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), Color.FromArgb(100, 90, 80), Color.FromArgb(48, 43, 39), 90);
            LinearGradientBrush itemrect = new LinearGradientBrush(new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), Color.FromArgb(57, 52, 46), Color.FromArgb(92, 83, 74), 90);
            try
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillPath(sitemrect, Draw.RoundRect(new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), 3));
                    e.Graphics.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), 3));
                }
                else
                {
                    e.Graphics.FillPath(itemrect, Draw.RoundRect(new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), 3));
                    e.Graphics.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), 3));
                }
                e.Graphics.DrawString(GetItemText(Items[e.Index]), e.Font, new SolidBrush(Color.FromArgb(212, 212, 212)), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }
            catch
            {
            }
        }

        public ButterscotchComboBox()
            : base()
        {
            DrawItem += ReplaceItem;
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            DrawMode = DrawMode.OwnerDrawFixed;
            BackColor = Color.Transparent;
            DropDownStyle = ComboBoxStyle.DropDownList;
            StartIndex = 0;
            ItemHeight = 25;
            DoubleBuffered = true;
            Width = 200;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 20;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            Rectangle outerrect = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle innerrect = new Rectangle(2, 2, Width - 5, Height - 5);
            base.OnPaint(e);
            g.Clear(BackColor);
            g.FillPath(new SolidBrush(Color.FromArgb(26, 25, 21)), Draw.RoundRect(outerrect, 3));
            g.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(outerrect, 3));
            LinearGradientBrush rectgb = new LinearGradientBrush(innerrect, Color.FromArgb(100, 90, 80), Color.FromArgb(48, 43, 39), 90);
            g.FillPath(rectgb, Draw.RoundRect(innerrect, 3));
            g.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(innerrect, 3));
            g.SetClip(Draw.RoundRect(innerrect, 3));
            g.FillPath(rectgb, Draw.RoundRect(innerrect, 3));
            g.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(innerrect, 3));
            g.ResetClip();
            g.DrawLine(new Pen(Color.FromArgb(246, 180, 12)), Width - 9, 10, Width - 22, 10);
            g.DrawLine(new Pen(Color.FromArgb(246, 180, 12)), Width - 9, 11, Width - 22, 11);
            g.DrawLine(new Pen(Color.FromArgb(246, 180, 12)), Width - 9, 15, Width - 22, 15);
            g.DrawLine(new Pen(Color.FromArgb(246, 180, 12)), Width - 9, 16, Width - 22, 16);
            g.DrawLine(new Pen(Color.FromArgb(246, 180, 12)), Width - 9, 20, Width - 22, 20);
            g.DrawLine(new Pen(Color.FromArgb(246, 180, 12)), Width - 9, 21, Width - 22, 21);
            g.DrawLine(new Pen(Color.FromArgb(246, 180, 12)), new Point(Width - 29, 7), new Point(Width - 29, Height - 7));
            g.DrawLine(new Pen(Color.FromArgb(246, 180, 12)), new Point(Width - 30, 7), new Point(Width - 30, Height - 7));
            try
            {
                g.DrawString(Text, new Font("Segoe UI", 11, FontStyle.Bold), new SolidBrush(Color.FromArgb(212, 212, 212)), innerrect, new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });
            }
            catch
            {
            }
            e.Graphics.DrawImage(b, new Point(0, 0));
            g.Dispose();
            b.Dispose();
        }
    }


}
