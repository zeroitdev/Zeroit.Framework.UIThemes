// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="SeperatorHorizontal.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Drawing;

namespace Zeroit.Framework.UIThemes.CarbonFibre
{
    public class CarbonFiberSeparatorHorizontal : ThemeControl154
    {
        #region "Properties"
        public CarbonFiberSeparatorHorizontal()
        {
            LockHeight = 10;
        }

        protected override void ColorHook()
        {

        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(22, 22, 22));
            G.DrawLine(new Pen(Color.FromArgb(6, 6, 6)), 0, 4, Width - 1, 4);
            G.DrawLine(new Pen(Color.FromArgb(32, 32, 32)), 0, 5, Width - 1, 5);
        }
        #endregion
    }

}


