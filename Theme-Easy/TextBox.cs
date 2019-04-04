// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="TextBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
