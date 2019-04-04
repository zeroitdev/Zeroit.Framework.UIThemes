// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.GreyWash
{
    [DefaultEvent("CheckedChanged")]
    public class GreywashCheckBox : Control
    {
        #region  Declarations 
        private bool _Checked;
        #endregion

        #region  Properties 
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        public bool Checked
        {
            get
            {
                return _Checked;
            }
            set
            {
                _Checked = value;
                Invalidate();
            }
        }

        public delegate void CheckedChangedEventHandler(object sender);
        public event CheckedChangedEventHandler CheckedChanged;
        protected override void OnClick(System.EventArgs e)
        {
            if (!_Checked)
            {
                Checked = true;
            }
            else
            {
                Checked = false;
            }
            if (CheckedChanged != null)
                CheckedChanged(this);
            base.OnClick(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 16;
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var G = e.Graphics;

            if (Parent.BackColor == Color.LightGray)
            {
                G.Clear(BackColor);
                G.FillRectangle(new SolidBrush(Color.DarkGray), new Rectangle(0, 0, 15, 15));
                G.DrawString(Text, new Font("Segoe UI", 10), Brushes.White, new Point(18, -2));
            }
            else
            {
                G.Clear(Color.White);
                G.FillRectangle(new SolidBrush(Color.DarkGray), new Rectangle(0, 0, 15, 15));
                G.DrawString(Text, new Font("Segoe UI", 10), Brushes.Gray, new Point(18, -2));
            }
            if (Checked)
            {
                G.FillRectangle(new SolidBrush(Color.LightGray), new Rectangle(4, 4, 7, 7));
                G.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Red)), new Rectangle(4, 4, 7, 7));
            }

        }
    }

}
