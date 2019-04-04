// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Seperator.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.ETheme
{


    public class eSeperator : ThemeControl
    {
        public override void PaintHook()
        {
            G.Clear(BackColor);
            G.DrawLine(Pens.Gray, 0, Convert.ToInt32(ClientRectangle.Y / 2), Width, 0);
        }
    }


}

