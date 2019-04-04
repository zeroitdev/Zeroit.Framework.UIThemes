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
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.VibeLander
{

    public class VibePanelBox : ThemeContainerControl
    {
        private bool _Checked;
        public VibePanelBox()
        {
            AllowTransparent();
        }
        public override void PaintHook()
        {
            this.Font = new Font("Tahoma", 10);
            this.ForeColor = Color.FromArgb(40, 40, 40);
            G.SmoothingMode = SmoothingMode.AntiAlias;
            G.FillRectangle(new SolidBrush(Color.FromArgb(235, 235, 235)), new Rectangle(2, 0, Width, Height));
            G.FillRectangle(new SolidBrush(Color.FromArgb(249, 249, 249)), new Rectangle(1, 0, Width - 3, Height - 4));
            G.DrawRectangle(new Pen(Color.FromArgb(214, 214, 214)), 0, 0, Width - 2, Height - 3);
        }
    }

}

