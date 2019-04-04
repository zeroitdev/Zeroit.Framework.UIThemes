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

namespace Zeroit.Framework.UIThemes.Complex
{

    public class ComplexGroupBox : ThemeContainer154
    {

        public ComplexGroupBox()
        {
            ControlMode = true;
            SetColor("Border", Color.FromArgb(190, 190, 190));
            SetColor("Header", Color.FromArgb(190, 190, 190));
            SetColor("Text", Color.FromArgb(0, 0, 0));
        }

        Pen Border;
        Brush HeaderColor;

        Brush textColor;
        protected override void ColorHook()
        {
            Border = GetPen("Border");
            HeaderColor = GetBrush("Header");
            textColor = GetBrush("Text");
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            G.FillRectangle(HeaderColor, new Rectangle(0, 0, Width - 1, 25));
            G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, 25));
            G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawString(Text, Font, textColor, new Point(7, 5));
        }
    }


}
