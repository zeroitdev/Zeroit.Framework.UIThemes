// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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

namespace Zeroit.Framework.UIThemes.Mumtz
{
    public class MumtzGroupBox : ThemeContainer154
    {

        public MumtzGroupBox()
        {
            ControlMode = true;
            SetColor("Border", Color.MediumTurquoise);
            SetColor("Header", Color.MediumTurquoise);
            SetColor("Text", Color.White);
        }
        Pen Border;
        Brush HeaderColor;

        Brush TextColor;

        protected override void ColorHook()
        {
            Border = GetPen("Border");
            HeaderColor = GetBrush("Header");
            TextColor = GetBrush("Text");
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            G.FillRectangle(HeaderColor, new Rectangle(0, 0, Width - 1, 25));
            G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, 25));
            G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawString(Text, Font, TextColor, new Point(7, 5));
        }
    }
}


