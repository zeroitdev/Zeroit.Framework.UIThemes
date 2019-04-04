// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="VerticalLine.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Frog
{
    public class FrogVerticalLine : ThemeControl154
    {

        protected override void ColorHook()
        {
            SetColor("EndBorder", Color.FromArgb(255, 60, 60, 60));
            SetColor("Border", Color.FromArgb(255, 200, 200, 200));
        }

        protected override void PaintHook()
        {
            if ((Height > 1))
            {
                Height = 1;
            }
            Color LineColor = GetColor("Border");
            Color EndLineColor = GetColor("EndBorder");
            LinearGradientBrush LGB = new LinearGradientBrush(new Point(0, 0), new Point(Width / 2 / 2, 0), EndLineColor, LineColor);
            LinearGradientBrush LGB2 = new LinearGradientBrush(new Point((Width / 2) + (Width / 2 / 2), 0), new Point(Width, 0), LineColor, EndLineColor);
            G.Clear(LineColor);
            G.FillRectangle(LGB, new Rectangle(0, 0, Width / 2 / 2, Height));
            G.FillRectangle(LGB2, new Rectangle((Width / 2) + (Width / 2 / 2), 0, Width / 2 / 2, Height));
        }
    }


}

