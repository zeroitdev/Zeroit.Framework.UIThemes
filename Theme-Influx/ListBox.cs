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
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Influx
{
    public class InfluxListbox : ListBox
    {

        public InfluxListbox()
        {
            SetStyle(ControlStyles.DoubleBuffer, true);
            Font = new Font("Verdana", 8);
            BorderStyle = BorderStyle.None;
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 22;
            ForeColor = Color.Black;
            BackColor = Color.FromArgb(65, 65, 65);
            IntegralHeight = false;
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 15)
                CustomPaint();
        }

        private Image _Image;
        public Image ItemImage
        {
            get { return _Image; }
            set { _Image = value; }
        }

        protected override void OnDrawItem(System.Windows.Forms.DrawItemEventArgs e)
        {
            try
            {
                if (e.Index >= 0)
                {
                    Rectangle ItemBounds = e.Bounds;
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 255, 255)), ItemBounds);
                    if (String.Compare(e.State.ToString(), "Selected,") > 0)
                    {
                        //Draw item backcolor
                        if (IsEven(e.Index))
                        {
                            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(75, 75, 75)), ItemBounds);
                        }
                        else
                        {
                            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(72, 72, 72)), ItemBounds);
                        }
                        Rectangle ItemBoundsTop = new Rectangle(ItemBounds.X + 2, ItemBounds.Y + 1, ItemBounds.Width - 5, Convert.ToInt32(ItemBounds.Height / 2) - 1);
                        Rectangle ItemBoundsBottom = new Rectangle(ItemBounds.X + 2, ItemBounds.Y + Convert.ToInt32(ItemBounds.Height / 2), ItemBounds.Width - 5, Convert.ToInt32(ItemBounds.Height / 2));
                        LinearGradientBrush TopGradient = new LinearGradientBrush(ItemBoundsTop, Color.FromArgb(115, 115, 115), Color.FromArgb(120, 120, 120), 90);
                        e.Graphics.FillRectangle(TopGradient, ItemBoundsTop);
                        LinearGradientBrush BottomGradient = new LinearGradientBrush(ItemBoundsBottom, Color.FromArgb(90, 90, 90), Color.FromArgb(85, 85, 85), 90);
                        e.Graphics.FillRectangle(BottomGradient, ItemBoundsBottom);
                        //Draw selected item bounds
                        Rectangle SelectedRectangle = new Rectangle(ItemBounds.X + 2, ItemBounds.Y, ItemBounds.Width - 5, ItemBounds.Height - 1);
                        e.Graphics.DrawRectangle(new Pen(Color.FromArgb(60, 60, 60)), SelectedRectangle);
                        //Draw text
                        e.Graphics.DrawString(" " + Items[e.Index].ToString(), Font, new SolidBrush(Color.FromArgb(229, 229, 229)), 5, Convert.ToInt32(e.Bounds.Y + (e.Bounds.Height / 2) - 7));
                    }
                    else
                    {
                        //Draw item backcolor
                        if (IsEven(e.Index))
                        {
                            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(77, 77, 77)), ItemBounds);
                        }
                        else
                        {
                            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(73, 73, 73)), ItemBounds);
                        }
                        //Draw item border
                        e.Graphics.DrawLine(new Pen(Color.FromArgb(65, 65, 65)), ItemBounds.X, ItemBounds.Y, ItemBounds.X + ItemBounds.Width - 1, ItemBounds.Y);
                        //Draw text
                        e.Graphics.DrawString(" " + Items[e.Index].ToString(), Font, new SolidBrush(Color.FromArgb(229, 229, 229)), 5, Convert.ToInt32(e.Bounds.Y + (e.Bounds.Height / 2) - 7));
                    }
                }
                //Draw borders
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(65, 65, 65)), new Rectangle(0, 0, Width - 1, Height - 1));
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(80, 80, 80)), new Rectangle(1, 1, Width - 3, Height - 3));
                base.OnDrawItem(e);
            }
            catch (Exception ex)
            {
            }
        }

        private bool IsEven(int intNumber)
        {
            return (intNumber % 2 == 0);
        }

        public void CustomPaint()
        {
            CreateGraphics().DrawRectangle(new Pen(Color.FromArgb(65, 65, 65)), new Rectangle(0, 0, Width - 1, Height - 1));
            CreateGraphics().DrawRectangle(new Pen(Color.FromArgb(80, 80, 80)), new Rectangle(1, 1, Width - 3, Height - 3));
        }
    }


}


