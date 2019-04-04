// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Youtube
{
    public class YTButton : ThemeControl
    {

        public override void PaintHook()
        {
            if (MouseState == State.MouseDown)
            {
                DrawGradient(Color.Red, Color.DarkRed, 0, 0, Width, Height, 90);
            }
            else if (MouseState == State.MouseOver)
            {
                DrawGradient(Color.DarkRed, Color.Red, 0, 0, Width, Height, 90);
            }
            else
            {
                DrawGradient(Color.Red, Color.DarkRed, 0, 0, Width, Height, 90);
            }
            DrawText(HorizontalAlignment.Center, ForeColor, 0);
            DrawBorders(Pens.Red, Pens.White, ClientRectangle);
        }
    }

}

