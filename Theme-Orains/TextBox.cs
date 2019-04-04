// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
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
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Zeroit.Framework.UIThemes.Orains
{
    public class OrainsTextBox : TextBox
    {
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr GetWindowDC(IntPtr hwnd);
        [DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0xf)
            {
                Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
                IntPtr hDC = GetWindowDC(this.Handle);
                Graphics g = Graphics.FromHdc(hDC);
                g.DrawRectangle(Pens.Black, new Rectangle(0, 0, Width - 1, Height - 1));
                g.DrawRectangle(new Pen(Color.FromArgb(40, 40, 40)), new Rectangle(1, 1, Width - 3, Height - 3));
                ReleaseDC(this.Handle, hDC);
                g.Dispose();
            }
        }

        public OrainsTextBox()
        {
            DoubleBuffered = true;
            BackColor = Color.FromArgb(20, 20, 20);
            ForeColor = Color.Orange;
            Text = Text;
            SetStyle(ControlStyles.DoubleBuffer, true);
        }
    }

}


