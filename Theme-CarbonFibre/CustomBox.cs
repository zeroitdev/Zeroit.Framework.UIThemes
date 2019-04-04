// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="CustomBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Drawing;

namespace Zeroit.Framework.UIThemes.CarbonFibre
{
    public class CarbonFiberCustomBox : ThemeContainer154
    {
        #region "Properties"
        public CarbonFiberCustomBox()
        {
            ControlMode = true;
            Size = new Size(150, 100);
            BackColor = Color.FromArgb(22, 22, 22);
        }



        protected override void ColorHook()
        {
        }
        #endregion
        #region "Color of Control"
        protected override void PaintHook()
        {
            G.Clear(BackColor);
            G.FillRectangle(new SolidBrush(Color.FromArgb(22, 22, 22)), ClientRectangle);
            DrawBorders(new Pen(Color.FromArgb(6, 6, 6)), 1);
            DrawBorders(new Pen(Color.FromArgb(32, 32, 32)));
        }
        #endregion

    }
}


