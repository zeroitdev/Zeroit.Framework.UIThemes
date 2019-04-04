// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Hero
{
    public class HeroGroupBox : ThemeContainerControl
    {
        public HeroGroupBox()
        {
            AllowTransparent();
        }

        public override void PaintHook()
        {
            G.Clear(BackColor);
            DrawBorders(Pens.Black, Pens.DimGray, ClientRectangle);
            DrawCorners(Color.Fuchsia, ClientRectangle);
        }
    }

}


