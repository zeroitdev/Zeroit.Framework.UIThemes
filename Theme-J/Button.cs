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

namespace Zeroit.Framework.UIThemes.Jasta
{
    public class Jbutton : ThemeControl151
    {

        Color Color1;
        Brush Color2;
        Pen Color3;
        Color Color4;
        public Jbutton()
        {
            SetColor("BackColor", Color.FromArgb(15, 15, 15));
            SetColor("Text", Color.White);
            SetColor("Border", Color.FromArgb(30, 30, 30));
            SetColor("MouseOverBack", Color.FromArgb(20, 20, 20));
        }

        protected override void ColorHook()
        {
            Color1 = GetColor("BackColor");
            Color2 = new SolidBrush(GetColor("Text"));
            Color3 = new Pen(GetColor("Border"));
            Color4 = GetColor("MouseOverBack");
        }

        protected override void PaintHook()
        {
            G.Clear(Color1);
            DrawText(Color2, HorizontalAlignment.Center, 0, 0);
            DrawBorders(Color3);

            switch (State)
            {
                case MouseState.Over:
                    G.Clear(Color4);
                    DrawText(Color2, HorizontalAlignment.Center, 0, 0);
                    DrawBorders(Color3);

                    break;
            }

        }
    }

}


