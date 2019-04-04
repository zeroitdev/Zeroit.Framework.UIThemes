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

namespace Zeroit.Framework.UIThemes.ETheme
{

    public class eGroupBox : ThemeContainerControl
    {
        public eGroupBox()
        {
            AllowTransparent();
        }
        public override void PaintHook()
        {
            G.Clear(Color.FromArgb(45, 45, 45));
            DrawBorders(new Pen(Color.FromArgb(25, Color.White)), new Pen(Color.FromArgb(90, Color.Black)), ClientRectangle);
            DrawCorners(BackColor, ClientRectangle);
        }
    }


}

