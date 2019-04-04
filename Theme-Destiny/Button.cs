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

namespace Zeroit.Framework.UIThemes.Destiny
{
    public class Destiny_Button : ThemeControl
    {


        Color G1 = Color.Teal;
        Color G2 = Color.Black;
        Color G3 = Color.Black;
        Color G4 = Color.Teal;
        Pen Bl = Pens.Black;
        Color G5 = Color.Teal;

        Color N;
        public override void PaintHook()
        {
            N = BackColor;
            G.Clear(N);

            if (MouseState == State.MouseNone)
            {
                DrawGradient(G1, G2, 0, 0, Width, Height, 90);
            }
            else if (MouseState == State.MouseOver)
            {
                DrawGradient(G3, G5, 0, 0, Width, Height, 90);
            }
            else if (MouseState == State.MouseDown)
            {
                DrawGradient(G4, G4, 0, 0, Width, Height, 90);
            }

            DrawText(HorizontalAlignment.Center, ForeColor, 0);
            G.DrawRectangle(Bl, ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
        }
    }


}


