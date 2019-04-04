// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ListBoxLessPretty.cs" company="Zeroit Dev Technologies">
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

    public class GhostListboxLessPretty : ListBox
    {

        public GhostListboxLessPretty()
        {
            SetStyle(ControlStyles.DoubleBuffer, true);
            Font = new Font("Microsoft Sans Serif", 9);
            BorderStyle = BorderStyle.None;
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 20;
            ForeColor = Color.DeepSkyBlue;
            BackColor = Color.FromArgb(7, 7, 7);
            IntegralHeight = false;
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 15)
                CustomPaint();
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
                    e.Graphics.FillRectangle(Brushes.Black, e.Bounds);
                    Rectangle x2 = new Rectangle(e.Bounds.Location, new Size(e.Bounds.Width - 1, e.Bounds.Height));
                    Rectangle x3 = new Rectangle(x2.Location, new Size(x2.Width, (x2.Height / 2)));
                    LinearGradientBrush G1 = new LinearGradientBrush(new Point(x2.X, x2.Y), new Point(x2.X, x2.Y + x2.Height), Color.FromArgb(60, 60, 60), Color.FromArgb(50, 50, 50));
                    HatchBrush H = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(15, Color.Black), Color.Transparent);
                    e.Graphics.FillRectangle(G1, x2);
                    G1.Dispose();
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(25, Color.White)), x3);
                    e.Graphics.FillRectangle(H, x2);
                    G1.Dispose();
                    e.Graphics.DrawString(" " + Items[e.Index].ToString(), Font, Brushes.White, e.Bounds.X, e.Bounds.Y + 1);
                }
                else
                {
                    e.Graphics.DrawString(" " + Items[e.Index].ToString(), Font, Brushes.White, e.Bounds.X, e.Bounds.Y + 1);
                }
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(0, 0, 0)), new Rectangle(1, 1, Width - 3, Height - 3));
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(90, 90, 90)), new Rectangle(0, 0, Width - 1, Height - 1));
                base.OnDrawItem(e);
            }
            catch (Exception ex)
            {
            }
        }

        public void CustomPaint()
        {
            CreateGraphics().DrawRectangle(new Pen(Color.FromArgb(0, 0, 0)), new Rectangle(1, 1, Width - 3, Height - 3));
            CreateGraphics().DrawRectangle(new Pen(Color.FromArgb(90, 90, 90)), new Rectangle(0, 0, Width - 1, Height - 1));
        }
    }


}
