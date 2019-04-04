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

namespace Zeroit.Framework.UIThemes.Electric
{
    public class ElectricButton : ThemeControl
    {

        public ElectricButton()
        {
            ForeColor = Color.White;
        }

        Color G1 = Color.FromArgb(23, 102, 139);
        Color G2 = Color.FromArgb(12, 77, 103);
        Color G3 = Color.FromArgb(34, 133, 179);
        Color G4 = Color.FromArgb(17, 89, 119);
        Pen Bl = Pens.Black;
        Color G5 = Color.FromArgb(28, 107, 144);

        Color N = Color.Navy;
        public override void PaintHook()
        {
            G.Clear(N);
            //Temporary, gradient will cover it

            //Draws a gradient depending on the mousestate
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
            //Draws the text...
            G.DrawRectangle(Bl, ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            //Border
        }
    }


}


