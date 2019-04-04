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
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Origin
{
    public class OriginGroupBox : ThemeContainer154
    {

        public OriginGroupBox()
        {
            ControlMode = true;
            SetColor("Border", Color.Silver);
            SetColor("Header", Color.Gray);
            SetColor("TextColor", Color.White);
        }

        Pen Border;
        Brush HeaderColor;

        Brush TextColor;
        protected override void ColorHook()
        {
            Border = GetPen("Border");
            HeaderColor = GetBrush("Header");
            TextColor = GetBrush("TextColor");
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            HatchBrush HB = new HatchBrush(HatchStyle.Percent80, Color.FromArgb(45, Color.FromArgb(39, 38, 38)), Color.Transparent);
            G.FillRectangle(HeaderColor, new Rectangle(0, 0, Width - 2, 25));
            G.FillRectangle(HB, new Rectangle(0, 0, Width - 2, Height - 1));

            G.DrawRectangle(Border, new Rectangle(0, 0, Width - 2, 25));
            G.DrawRectangle(Border, new Rectangle(0, 0, Width - 2, Height - 1));
            G.DrawString(Text, Font, TextColor, new Point(5, 5));
        }
    }

}


