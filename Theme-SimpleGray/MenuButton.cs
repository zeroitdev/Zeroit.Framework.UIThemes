// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="MenuButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.SimpleGray
{
    public class SimplyGrayMenuButton : ThemeControl
    {

        public SimplyGrayMenuButton()
        {
            AllowTransparent();
            ForeColor = Color.White;
            Size S = new Size(15, 20);
            Size = S;
        }

        Color T = Color.Transparent;
        Color LG = Color.LightGray;
        Color Gr = Color.Gray;
        Pen P = Pens.DarkGray;

        Pen Pb = Pens.Black;
        public override void PaintHook()
        {
            G.Clear(Color.DarkGray);

            DrawGradient(LG, Gr, 0, 0, Width, Height, 90);

            G.DrawLine(Pb, 0, 0, Width, 0);
            G.DrawLine(P, 0, 1, Width, 1);

            DrawText(HorizontalAlignment.Center, ForeColor, 0);
        }
    }

}

