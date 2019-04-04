// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Onyl
{
    public class OnylGroupBox : ContainerControl
    {
        public OnylGroupBox()
        {

            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            Size = new Size(400, 300);

            backBrush = new SolidBrush(Color.FromArgb(0, 70, 90));
            borderPen = new Pen(Color.FromArgb(90, 135, 140));
            coverPen = new Pen(Color.FromArgb(0, 70, 90));

        }

        private SolidBrush backBrush;
        private Pen borderPen;
        private Pen coverPen;

        protected override void OnPaint(PaintEventArgs e)
        {

            ThemeModule.g = e.Graphics;
            ThemeModule.g.Clear(Parent.BackColor);
            ThemeModule.g.SmoothingMode = SmoothingMode.AntiAlias;

            ThemeModule.g.DrawRectangle(borderPen, new Rectangle(0, 0, Width - 1, Height - 1));

            ThemeModule.g.DrawLine(coverPen, new Point(0, Height - 8), new Point(0, (int)(Height * 1.8)));
            ThemeModule.g.DrawLine(coverPen, new Point(Width - 20, 0), new Point(Width - (Width - 8), 0));
            ThemeModule.g.DrawLine(coverPen, new Point(Width - 1, Height - 5), new Point(Width - 1, (int)(Height * 1.25)));


        }

    }
}
