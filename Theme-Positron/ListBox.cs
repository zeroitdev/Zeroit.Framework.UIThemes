// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Positron
{
    public class PositronListBox : ListBox
    {
        private bool mShowScroll;
        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (!mShowScroll)
                {

                    cp.Style = cp.Style & ~0x200000;
                }
                return cp;
            }
        }
        [Description("Indicates whether the vertical scrollbar appears or not.")]
        public bool ShowScrollbar
        {
            get { return mShowScroll; }
            set
            {
                if (value == mShowScroll)
                {
                    return;
                }
                mShowScroll = value;
                if (Handle != IntPtr.Zero)
                {
                    RecreateHandle();
                }
            }
        }

        public PositronListBox()
        {
            SetStyle(ControlStyles.DoubleBuffer, true);
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            ItemHeight = 16;
            ForeColor = Color.Black;
            BackColor = Color.FromArgb(210, 210, 210);
            IntegralHeight = false;
            Font = new Font("Verdana", 8);
            ScrollAlwaysVisible = false;
        }
        protected void DrawBorders(Pen p1)
        {
            DrawBorders(p1, 0, 0, Width, Height);
        }
        protected void DrawBorders(Pen p1, int offset)
        {
            DrawBorders(p1, 0, 0, Width, Height, offset);
        }
        protected void DrawBorders(Pen p1, int x, int y, int width, int height)
        {
            CreateGraphics().DrawRectangle(p1, x, y, width - 1, height - 1);
        }
        protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset)
        {
            DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
        }
        protected override void OnDrawItem(System.Windows.Forms.DrawItemEventArgs e)
        {
            if ((e.Index >= 0))
            {
                Rectangle ItemBounds = e.Bounds;
                e.Graphics.FillRectangle(new SolidBrush(BackColor), ItemBounds);

                if (((e.State.ToString().IndexOf("Selected,") + 1) > 0))
                {
                    LinearGradientBrush LGB1 = new LinearGradientBrush(ItemBounds, Color.FromArgb(120, 120, 120), Color.FromArgb(100, 100, 100), 90);
                    HatchBrush HB1 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(10, Color.White), Color.Transparent);
                    e.Graphics.FillRectangle(LGB1, ItemBounds);
                    e.Graphics.FillRectangle(HB1, ItemBounds);
                    e.Graphics.DrawString(Items[e.Index].ToString(), Font, new SolidBrush(Color.FromArgb(200, 200, 200)), 5, Convert.ToInt32((e.Bounds.Y + ((e.Bounds.Height / 2) - 7))));
                }
                else
                {
                    try
                    {
                        e.Graphics.DrawString(Items[e.Index].ToString(), Font, new SolidBrush(Color.FromArgb(100, 100, 100)), 5, Convert.ToInt32((e.Bounds.Y + ((e.Bounds.Height / 2) - 7))));
                    }
                    catch
                    {
                    }
                }
            }
            DrawBorders(new Pen(new SolidBrush(Color.FromArgb(200, 200, 200))));
            DrawBorders(new Pen(new SolidBrush(Color.FromArgb(150, 150, 150))), 1);
            base.OnDrawItem(e);
        }
        public void CustomPaint()
        {
            CreateGraphics().DrawRectangle(new Pen(Color.FromArgb(210, 210, 210)), new Rectangle(0, 0, Width - 1, Height - 1));
        }
    }
}

