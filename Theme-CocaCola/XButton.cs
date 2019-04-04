// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="XButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Cola
{
    public class CCXButton : ThemeControl151
    {

        public CCXButton()
        {
            SetColor("BackColor", Color.FromArgb(192, 0, 0));
            SetColor("TextColor", Color.Green);
            Size = new Size(19, 12);
        }


        Color C1;
        Color T1;
        Color C2;
        Color C3;
        Color C4;
        Color C5;
        Color C6;
        Color P1;
        Color P2;
        Color B1;
        protected override void ColorHook()
        {
            C1 = GetColor("BackColor");
            T1 = GetColor("TextColor");
        }


        protected override void PaintHook()
        {
            G.Clear(BackColor);
            //G.Clear(C1);
            switch (State)
            {
                case 0:
                    //None
                    DrawGradient(Color.FromArgb(192, 0, 0), Color.FromArgb(192, 0, 0), ClientRectangle, 90);
                    Cursor = Cursors.Arrow;

                    break;
            }

            DrawBorders(new Pen(new SolidBrush(Color.RosyBrown)));
            DrawBorders(new Pen(new SolidBrush(Color.RosyBrown)));
            DrawBorders(new Pen(new SolidBrush(Color.RosyBrown)), new Rectangle(1, 2, -2, Height));
            DrawText(Brushes.White, "X", HorizontalAlignment.Center, 0, 0);

        }
    }

}

