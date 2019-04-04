// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="SeperatorVertical.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Drawing;

namespace Zeroit.Framework.UIThemes.CarbonFibre
{
    public class CarbonFiberSeparatorVertical : ThemeControl154
    {
        #region "Properties"
        public CarbonFiberSeparatorVertical()
        {
            LockWidth = 10;
        }

        protected override void ColorHook()
        {

        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(22, 22, 22));

            G.FillRectangle(new SolidBrush(Color.FromArgb(6, 6, 6)), new Rectangle(4, 0, 1, Height - 1));
            G.FillRectangle(new SolidBrush(Color.FromArgb(32, 32, 32)), new Rectangle(5, 0, 1, Height - 1));
        }
        #endregion
    }
}


