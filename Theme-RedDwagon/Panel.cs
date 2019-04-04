// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Panel.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.RedDwagon
{
    public class RedDwagonPanel : ContainerControl
    {

        public RedDwagonPanel()
        {
            BackColor = Color.FromArgb(34, 34, 34);
            SetStyle((ControlStyles)139270, true);
        }

        private Graphics G;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            G = e.Graphics;

            G.Clear(BackColor);
            G.DrawRectangle(Pens.DimGray, 0, 0, Width - 1, Height - 1);
        }
    }

}

