// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button2.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Origin
{
    public class SecondOriginButton : ThemeControl154
    {

        Color ButtonColorTop;
        Color ButtonColorBottom;
        Brush TextColor;

        Pen Border;
        public SecondOriginButton()
        {
            SetColor("Button Top", Color.Silver);
            SetColor("Button Bottom", Color.Gray);
            SetColor("Text", Color.White);
            SetColor("BorderColor", Color.White);
        }

        protected override void ColorHook()
        {
            ButtonColorTop = GetColor("Button Top");
            ButtonColorBottom = GetColor("Button Bottom");
            TextColor = GetBrush("Text");
            Border = GetPen("BorderColor");
        }

        protected override void PaintHook()
        {
            G.Clear(ButtonColorTop);
            switch (State)
            {
                case MouseState.None:
                    LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), ButtonColorTop, ButtonColorBottom, 90f);
                    G.FillRectangle(LGB, new Rectangle(0, 0, Width - 1, Height - 1));
                    G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Black)), new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                    DrawCorners(Color.White);
                    break;
                case MouseState.Over:
                    LinearGradientBrush LGB1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), ButtonColorTop, ButtonColorBottom, 90f);
                    G.FillRectangle(LGB1, new Rectangle(0, 0, Width - 1, Height - 1));
                    G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.White)), new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                    DrawCorners(Color.White);
                    break;
                case MouseState.Down:
                    //Dim LGB As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 1), ButtonColorTop, ButtonColorBottom, 90.0F)
                    //G.FillRectangle(LGB, New Rectangle(0, 0, Width - 1, Height - 1))
                    G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.White)), new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                    DrawCorners(Color.White);
                    break;
            }
        }
    }

}


