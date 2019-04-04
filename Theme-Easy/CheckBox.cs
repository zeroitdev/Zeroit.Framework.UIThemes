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
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Easy
{
    public class EasyCheckBox : Control
    {
        private bool _Checked;

        public EasyCheckBox()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Size = new Size(20, 20);
            MaximumSize = Size;
            MinimumSize = Size;
            Cursor = Cursors.Hand;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (_Checked)
            {
                _Checked = false;
            }
            else if (!_Checked)
            {
                _Checked = true;
            }
            Invalidate();
            base.OnMouseClick(e);
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
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            int x = ClientSize.Width;
            int y = ClientSize.Height;

            g.FillEllipse(new SolidBrush(Color.FromArgb(25, 0, 0, 0)), new Rectangle(0, 0, x - 1, y - 1));
            g.FillEllipse(new SolidBrush(Color.FromArgb(75, 255, 255, 255)), new Rectangle(3, 3, x - 7, y - 7));

            if (_Checked)
            {
                g.FillEllipse(new SolidBrush(Color.FromArgb(100, 0, 0, 0)), new RectangleF(5F, 5F, (float)(x / 2.0) - 1, (float)(y / 2.0) - 1));
            }

            g.Dispose();
        }
    }
}
