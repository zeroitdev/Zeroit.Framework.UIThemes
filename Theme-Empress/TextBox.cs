// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TextBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Empress
{


    public class EmpressTextBox : TextBox
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
                g.DrawRectangle(new Pen(Color.FromArgb(90, 90, 90)), new Rectangle(0, 0, Width - 1, Height - 1));
                g.DrawRectangle(Pens.Black, new Rectangle(1, 1, Width - 3, Height - 3));
                ReleaseDC(this.Handle, hDC);
                g.Dispose();
            }
        }

        public EmpressTextBox()
        {
            DoubleBuffered = true;
            BackColor = ColorConverter.HexToColor("#A12F35");
            ForeColor = Color.Black;
            Text = Name.ToString();
            SetStyle(ControlStyles.DoubleBuffer, true);
        }
    }


}


