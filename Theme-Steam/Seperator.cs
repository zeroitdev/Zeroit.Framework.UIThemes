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
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Steam
{
    public class SteamSeparator : ThemeControl153
    {


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.FillRectangle(new SolidBrush(Color.FromArgb(56, 54, 53)), ClientRectangle);
            DrawGradient(Color.FromArgb(107, 104, 101), Color.FromArgb(74, 72, 70), new Rectangle(0, Height / 2, Width, 1), 45);
        }
    }

}

