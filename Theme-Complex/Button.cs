// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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

namespace Zeroit.Framework.UIThemes.Complex
{


    public class ComplexButton : ThemeControl154
    {

        Color ButtonColor;
        Brush TextColor;

        Pen Border;
        public ComplexButton()
        {
            SetColor("Button", Color.FromArgb(211, 211, 211));
            SetColor("Text", Color.FromArgb(0, 0, 0));
            SetColor("Border", Color.FromArgb(190, 190, 190));
        }

        protected override void ColorHook()
        {
            ButtonColor = GetColor("Button");
            TextColor = GetBrush("Text");
            Border = GetPen("Border");
        }

        protected override void PaintHook()
        {
            G.Clear(ButtonColor);
            switch (State)
            {
                case MouseState.None:
                    G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                    break;
                case MouseState.Over:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.LightGray)), new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                    break;
                case MouseState.Down:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Black)), new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                    break;
            }
        }
    }

}
