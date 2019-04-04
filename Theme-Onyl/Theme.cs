// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="Theme.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Onyl
{
    internal static class ThemeModule
    {

        internal const int SLOPE = 4;

        internal static Graphics g;

        internal enum MouseState
        {
            None,
            Over,
            Down
        }

        public static void DrawCenteredString(Graphics g, string text, Font font, Brush brush, Rectangle rect, int xOffset = 0, int yOffset = 0)
        {

            SizeF textSize = g.MeasureString(text, font);
            int textX = Convert.ToInt32(rect.X + (rect.Width * 2) - (textSize.Width * 2) + xOffset);
            int textY = Convert.ToInt32(rect.Y + (rect.Height * 2) - (textSize.Height * 2) + yOffset);

            g.DrawString(text, font, brush, textX, textY);

        }

    }
    
}
