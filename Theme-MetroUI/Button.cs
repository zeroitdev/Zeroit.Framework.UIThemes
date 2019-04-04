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

namespace Zeroit.Framework.UIThemes.Metro
{

    public class MetroUIButton : ThemeControl154
    {
        public MetroUIButton()
        {
            Height = 45;
            Width = 120;
            SetColor("buttonc", Color.FromArgb(53, 157, 181));
            SetColor("textc", Color.White);
            Font = new Font("Segoe UI", 12);
        }

        Color buttonc;
        Brush textc;
        protected override void ColorHook()
        {
            buttonc = GetColor("buttonc");
            textc = GetBrush("textc");
        }

        protected override void PaintHook()
        {
            G.Clear(buttonc);

            switch (State)
            {
                case MouseState.None:
                    DrawText(textc, HorizontalAlignment.Center, 0, 0);
                    break;
                case MouseState.Over:
                    G.Clear(Color.FromArgb(49, 144, 166));
                    DrawText(textc, HorizontalAlignment.Center, 0, 0);
                    break;
                case MouseState.Down:
                    G.Clear(Color.FromArgb(34, 100, 115));
                    DrawText(textc, HorizontalAlignment.Center, 0, 0);
                    break;
            }
        }
    }

}


