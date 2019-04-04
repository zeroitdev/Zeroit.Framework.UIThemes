// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ListBox.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Butter
{
    public class ButterscotchListBox : ListBox
    {
        public ButterscotchListBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            DrawMode = DrawMode.OwnerDrawFixed;
            ForeColor = Color.White;
            BackColor = Color.FromArgb(100, 90, 80);
            BorderStyle = BorderStyle.None;
            ItemHeight = 20;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            base.OnPaint(e);
            g.Clear(Color.Transparent);
            g.FillPath(new SolidBrush(Color.FromArgb(100, 90, 80)), Draw.RoundRect(rect, 3));
            g.DrawPath(new Pen(Color.FromArgb(26, 25, 21)), Draw.RoundRect(rect, 1));
            e.Graphics.DrawImage(b, new Point(0, 0));
            g.Dispose();
            b.Dispose();
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Bitmap b = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(b);
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.SetClip(Draw.RoundRect(new Rectangle(0, 0, Width, Height), 3));
            g.Clear(Color.Transparent);
            g.FillRectangle(new SolidBrush(BackColor), new Rectangle(e.Bounds.X, e.Bounds.Y - 1, e.Bounds.Width, e.Bounds.Height + 3));
            if (e.State.ToString().Contains("Selected,"))
            {
                LinearGradientBrush selectgb = new LinearGradientBrush(new Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height), Color.FromArgb(100, 90, 80), Color.FromArgb(48, 43, 39), 90);
                g.FillRectangle(selectgb, new Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height));
                g.DrawRectangle(new Pen(Color.FromArgb(212, 212, 212)), new Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height));
            }
            else
            {
                LinearGradientBrush nonselectgb = new LinearGradientBrush(new Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height), Color.FromArgb(48, 43, 39), Color.FromArgb(100, 90, 80), 90);
                g.FillRectangle(nonselectgb, e.Bounds);
            }
            try
            {
                g.DrawString(GetItemText(Items[e.Index]), new Font("Segoe UI", 10, FontStyle.Regular), new SolidBrush(Color.FromArgb(255, 255, 255)), new Rectangle(e.Bounds.X + 3, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height), new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                });
            }
            catch
            {
            }
            g.DrawPath(new Pen(Color.FromArgb(26, 25, 21), 2), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), 1));
            e.Graphics.DrawImage(b, new Point(0, 0));
            g.Dispose();
            b.Dispose();
        }
    }

}
