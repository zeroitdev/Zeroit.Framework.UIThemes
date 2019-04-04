// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupPanelBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.VibeLander
{
    public class VibeGroupPanelBox : ThemeContainerControl
    {
        private bool _Checked;
        public VibeGroupPanelBox()
        {
            AllowTransparent();
        }
        public override void PaintHook()
        {
            this.Font = new Font("Tahoma", 10);
            this.ForeColor = Color.FromArgb(40, 40, 40);
            G.SmoothingMode = SmoothingMode.AntiAlias;
            G.Clear(Color.FromArgb(245, 245, 245));
            G.FillRectangle(new SolidBrush(Color.FromArgb(231, 231, 231)), new Rectangle(0, 0, Width, 30));
            G.DrawLine(new Pen(Color.FromArgb(233, 238, 240)), 1, 1, Width - 2, 1);
            G.DrawRectangle(new Pen(Color.FromArgb(214, 214, 214)), 0, 0, Width - 1, Height - 1);
            G.DrawRectangle(new Pen(Color.FromArgb(214, 214, 214)), 0, 0, Width - 1, 30);
            G.DrawString(Text, Font, new SolidBrush(this.ForeColor), 7, 6);
        }
    }

}

