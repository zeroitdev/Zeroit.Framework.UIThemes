// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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

namespace Zeroit.Framework.UIThemes.Electric
{
    public class ElectricMenuButton : ThemeControl
    {

        public ElectricMenuButton()
        {
            AllowTransparent();
            ForeColor = Color.White;
            Size S = new Size(15, 20);
            Size = S;
        }

        Pen Bl = Pens.Black;
        Color G1 = Color.FromArgb(43, 136, 170);

        Color G2 = Color.FromArgb(29, 102, 129);
        public override void PaintHook()
        {
            DrawGradient(G1, G2, 0, 0, Width, 20, 90);
            //Draw the same gradient as the menu bar so it matches
            G.DrawLine(Bl, 0, 0, Width, 0);
            //Draw a black line accross the top, matches the theme's border
            DrawText(HorizontalAlignment.Center, ForeColor, 0);
            //Draws text..
        }
    }


}


