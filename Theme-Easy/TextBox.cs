// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="TextBox.cs" company="Zeroit Dev Technologies">
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
    public class EasyTextBox : RichTextBox
    {
        public EasyTextBox()
        {
            BorderStyle = BorderStyle.None;
            Multiline = false;
            Size = new Size(Size.Width, 20);
            MaximumSize = new Size(int.MaxValue, Size.Height);
            MinimumSize = Size;
        }

        // PREVENT FLICKERING
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
        }

        private const int WM_PAINT = 15;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_PAINT)
            {
                Invalidate();
                base.WndProc(ref m);
                using (Graphics g = Graphics.FromHwnd(Handle))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
}
