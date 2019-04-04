// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Seperator.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.NeSeal
{
    public class NSSeperator : Control
    {

        public NSSeperator()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            Height = 10;

            P1 = new Pen(Color.FromArgb(24, 24, 24));
            P2 = new Pen(Color.FromArgb(55, 55, 55));
        }

        private Pen P1;

        private Pen P2;
        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule theme = new ThemeModule();
            var G = theme.G;

            G = e.Graphics;
            G.Clear(BackColor);

            G.DrawLine(P1, 0, 5, Width, 5);
            G.DrawLine(P2, 0, 6, Width, 6);
        }

    }
}


