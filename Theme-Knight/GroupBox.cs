// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Knight
{
    public class KnightGroupBox : ContainerControl
    {

        public KnightGroupBox()
        {
            Size = new Size(200, 100);
            BackColor = Color.FromArgb(37, 39, 48);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;
            G.Clear(BackColor);
            G.DrawRectangle(new Pen(Color.FromArgb(236, 73, 99)), new Rectangle(0, 0, Width - 1, Height - 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(46, 49, 61)), new Rectangle(0, 0, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(46, 49, 61)), new Rectangle(Width - 1, 0, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(46, 49, 61)), new Rectangle(0, Height - 1, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(46, 49, 61)), new Rectangle(Width - 1, Height - 1, 1, 1));
            G.DrawString(Text, new Font("Segoe UI", 10), Brushes.White, new Point(7, 5));
        }

    }

}


