// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Label.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Frog
{

    public class FrogLabel : ThemeControl154
    {

        protected override void ColorHook()
        {
            SetColor("Border", Color.FromArgb(255, 200, 200, 200));
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(255, 60, 60, 60));
            G.DrawString(Text, Font, new SolidBrush(GetColor("Border")), new Point(0, 0));
            Width = (int)G.MeasureString(Text, Font).Width;
            Height = 15;
        }
    }


}

