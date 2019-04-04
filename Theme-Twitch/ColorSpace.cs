// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ColorSpace.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Twitch
{
    public class TwitchColorSpace : ThemeContainer154
    {

        public TwitchColorSpace()
        {
            ControlMode = true;
            BackColor = Color.White;
        }


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.FillRectangle(new SolidBrush(BackColor), new Rectangle(0, 0, Width, Height));
        }
    }
}

