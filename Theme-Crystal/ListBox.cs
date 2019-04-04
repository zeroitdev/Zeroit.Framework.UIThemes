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

namespace Zeroit.Framework.UIThemes.Crystal
{
    public class CrystalClearListbox : ListBox
    {

        public CrystalClearListbox()
        {
            SetStyle(ControlStyles.DoubleBuffer, true);
            Font = new Font("Microsoft Sans Serif", 9);
            BorderStyle = BorderStyle.None;
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 21;
            ForeColor = Color.Black;
            BackColor = Color.FromArgb(230, 230, 230);
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
                if (e.Index < 0)
                    return;
                e.DrawBackground();
                Rectangle rect = new Rectangle(new Point(e.Bounds.Left, e.Bounds.Top + 2), new Size(Bounds.Width, 16));
                e.DrawFocusRectangle();
                if (String.Compare(e.State.ToString(), "Selected,") > 0)
                {
                    Rectangle x2 = e.Bounds;
                    Rectangle x3 = new Rectangle(x2.Location, new Size(x2.Width, (x2.Height / 2)));
                    LinearGradientBrush G1 = new LinearGradientBrush(new Point(x2.X, x2.Y), new Point(x2.X, x2.Y + x2.Height), Color.FromArgb(230, 230, 230), Color.FromArgb(210, 210, 210));
                    HatchBrush H = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(10, Color.Black), Color.Transparent);
                    e.Graphics.FillRectangle(G1, x2);
                    G1.Dispose();
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(230, 230, 230)), x3);
                    e.Graphics.FillRectangle(H, x2);
                    G1.Dispose();
                    e.Graphics.DrawString(" " + Items[e.Index].ToString(), Font, Brushes.Black, 5, e.Bounds.Y + (e.Bounds.Height / 2) - 9);
                    e.Graphics.DrawRectangle(new Pen(Color.FromArgb(170, 170, 170)), new Rectangle(new Point(x2.Location.X, x2.Location.Y), new Size(x2.Width, x2.Height)));
                }
                else
                {
                    Rectangle x2 = e.Bounds;
                    e.Graphics.DrawString(" " + Items[e.Index].ToString(), Font, Brushes.Black, 5, e.Bounds.Y + (e.Bounds.Height / 2) - 9);
                    e.Graphics.DrawRectangle(new Pen(Color.FromArgb(215, 215, 215)), new Rectangle(new Point(x2.Location.X, x2.Location.Y), new Size(x2.Width, x2.Height)));
                }
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(170, 170, 170)), new Rectangle(0, 0, Width - 1, Height - 1));
                base.OnDrawItem(e);
            }
            catch (Exception ex)
            {
            }
        }

        public void CustomPaint()
        {
            CreateGraphics().DrawRectangle(new Pen(Color.FromArgb(170, 170, 170)), new Rectangle(0, 0, Width - 1, Height - 1));
        }
    }
}



