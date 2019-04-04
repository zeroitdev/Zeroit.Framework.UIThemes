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
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Empress
{
    public class EmpressGroupBox : ThemeContainer154
    {

        public EmpressGroupBox()
        {
            ControlMode = true;
            SetColor("Border", Color.Black);
            SetColor("Header", ColorConverter.HexToColor("#A12F35"));
            SetColor("Text", Color.Black);
        }
        Pen Border;
        Brush HeaderColor;
        Brush textcolor;
        protected override void ColorHook()
        {
            Border = GetPen("Border");
            HeaderColor = GetBrush("Header");
            textcolor = GetBrush("Text");
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            G.FillRectangle(HeaderColor, new Rectangle(0, 0, Width - 1, 25));
            G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, 25));
            G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawString(Text, Font, textcolor, new Point(7, 6));

            HatchBrush BodyHatch = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(20, Color.Black), Color.Transparent);
            G.FillRectangle(BodyHatch, new Rectangle(0, 0, Width - 1, Height - 1));

        }
    }


}


