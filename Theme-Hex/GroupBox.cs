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

namespace Zeroit.Framework.UIThemes.Hex
{
    public class HexGroupBox : ContainerControl
    {

        public HexGroupBox()
        {
            Size = new Size(200, 100);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;
            G.Clear(Color.FromArgb(30, 33, 40));
            G.DrawPath(new Pen(Color.FromArgb(236, 95, 75)), Functions.RoundRec(new Rectangle(0, 0, Width - 1, Height - 1), 4));
            G.DrawString(Text, new Font("Segoe UI", 9), Brushes.White, new Point(5, 5));
        }

    }

}


