// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
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
    [DefaultEvent("CheckedChanged")]
    public class BonfireCheckbox : Control
    {
        public delegate void CheckedChangedEventHandler(object sender);
        public event CheckedChangedEventHandler CheckedChanged;

        private bool _checked;
        public bool Checked
        {
            get
            {
                return _checked;
            }
            set
            {
                _checked = value;
                Invalidate();
            }
        }

        public BonfireCheckbox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
            Size = new Size(140, 20);
            Font = new Font("Verdana", 8);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {

            Graphics G = e.Graphics;

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.Clear(Parent.BackColor);

            Rectangle box = new Rectangle(0, 0, Height, Height - 1);
            G.FillRectangle(Brushes.White, box);
            G.DrawRectangle(new Pen(Color.FromArgb(225, 225, 225)), box);

            Pen markPen = new Pen(Color.FromArgb(150, 155, 160));
            Pen lightMarkPen = new Pen(Color.FromArgb(170, 175, 180));
            if (_checked)
            {
                G.DrawString("a", new Font("Marlett", 14), Brushes.Gray, new Point(0, 0));
            }

            int textY = Convert.ToInt32((Height / 2) - (G.MeasureString(Text, Font).Height / 2.0));
            G.DrawString(Text, Font, Brushes.Gray, new Point(24, textY));

        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (_checked)
            {
                _checked = false;
            }
            else
            {
                _checked = true;
            }

            if (CheckedChanged != null)
                CheckedChanged(this);
            Invalidate();

        }

    }
}
