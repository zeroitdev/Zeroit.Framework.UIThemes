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

namespace Zeroit.Framework.UIThemes.Earn
{
    public class EarnGroupBox : ThemeContainer154
    {

        public EarnGroupBox()
        {
            ControlMode = true;
            TransparencyKey = Color.Fuchsia;

            SetColor("Bord", Color.FromArgb(75, 77, 89));
            SetColor("Border", Color.FromArgb(75, 77, 89));
            SetColor("Head", Color.FromArgb(75, 77, 89));
            SetColor("Text", Color.White);
        }

        Pen BordColor;
        Brush HeadColor;

        Brush TextColor;
        protected override void ColorHook()
        {
            TextColor = GetBrush("Text");
            HeadColor = GetBrush("Head");
            BordColor = GetPen("Bord");

        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(242, 242, 242));
            G.FillRectangle(HeadColor, new Rectangle(0, 0, Width - 1, 25));
            G.DrawRectangle(BordColor, new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawString(Text, Font, TextColor, new Point(7, 6));
            DrawCorners(Color.FromArgb(240, 240, 240));
        }
    }


}

