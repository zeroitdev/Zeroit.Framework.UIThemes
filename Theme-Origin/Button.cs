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

namespace Zeroit.Framework.UIThemes.Origin
{

    public class OriginButton : ThemeControl154
    {

        Color ButtonColor;
        Brush TextColor;

        Pen Border;
        public OriginButton()
        {
            SetColor("Button", Color.Orange);
            SetColor("Text", Color.White);
            SetColor("BorderColor", Color.White);
        }

        protected override void ColorHook()
        {
            ButtonColor = GetColor("Button");
            TextColor = GetBrush("Text");
            Border = GetPen("BorderColor");
        }

        protected override void PaintHook()
        {
            G.Clear(ButtonColor);
            switch (State)
            {
                case MouseState.None:
                    G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                    DrawCorners(Color.White);
                    break;
                case MouseState.Over:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.White)), new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                    DrawCorners(Color.White);
                    break;
                case MouseState.Down:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Silver)), new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                    DrawCorners(Color.White);
                    break;
            }
        }
    }

}


