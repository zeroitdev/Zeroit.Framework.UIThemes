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

namespace Zeroit.Framework.UIThemes.SpicyLips
{
    public class BlackPanel : ThemeControl154
    {
        public BlackPanel()
        {
            Size = new Size(120, 120);
        }

        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(26, 26, 26));
            DrawBorders(new Pen(new SolidBrush(Color.FromArgb(7, 7, 7))), ClientRectangle);
            DrawCorners(Color.FromArgb(22, 22, 22), ClientRectangle);
            DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
        }
    }

}