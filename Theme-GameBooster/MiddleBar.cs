// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="MiddleBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace Zeroit.Framework.UIThemes.GameBooster
{
    public class GameBoosterMiddleBar : ThemeControl154
    {

        public GameBoosterMiddleBar()
        {
            LockHeight = 31;
            Height = 31;
        }
        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(54, 54, 54));
            G.DrawLine(new Pen(Color.FromArgb(24, 24, 24)), 0, 0, Width, 0);
            G.DrawLine(new Pen(Color.FromArgb(69, 69, 69)), 0, 1, Width, 1);
            G.DrawLine(new Pen(Color.FromArgb(24, 24, 24)), 0, Height - 2, Width, Height - 2);
            G.DrawLine(new Pen(Color.FromArgb(69, 69, 69)), 0, Height - 1, Width, Height - 1);
        }
    }


}


