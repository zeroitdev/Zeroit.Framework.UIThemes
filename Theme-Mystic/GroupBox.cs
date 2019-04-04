// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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

namespace Zeroit.Framework.UIThemes.Mystic
{
    public class MysticGroupBox : ContainerControl
    {

        public MysticGroupBox()
        {
            Size = new Size(200, 100);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            dynamic G = e.Graphics;

            G.Clear(Color.FromArgb(44, 51, 62));

            G.DrawRectangle(new Pen(Color.FromArgb(0, 206, 153), 2), new Rectangle(1, 1, Width - 2, Height - 2));

            G.DrawString(Text, new Font("Segoe UI", 9, FontStyle.Bold), new SolidBrush(Color.FromArgb(0, 206, 153)), new Point(7, 5));

            G.FillRectangle(new SolidBrush(Color.FromArgb(44, 51, 62)), new Rectangle(0, 0, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(44, 51, 62)), new Rectangle(Width - 1, 0, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(44, 51, 62)), new Rectangle(0, Height - 1, 1, 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(44, 51, 62)), new Rectangle(Width - 1, Height - 1, 1, 1));

        }

    }

}

