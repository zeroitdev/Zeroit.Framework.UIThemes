// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Title.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Destiny
{
    public class Destiny_Title : ThemeControl
    {

        public Destiny_Title()
        {
            AllowTransparent();
            ForeColor = Color.Aquamarine;
            Size S = new Size(15, 20);
            Size = S;
        }

        Pen Bl = Pens.Black;
        Color G1 = Color.Teal;

        Color G2 = Color.Black;
        public override void PaintHook()
        {
            DrawGradient(G1, G2, 0, 0, Width, 20, 90);
            G.DrawLine(Bl, 0, 0, Width, 0);
            DrawText(HorizontalAlignment.Left, ForeColor, 0);
        }
    }


}


