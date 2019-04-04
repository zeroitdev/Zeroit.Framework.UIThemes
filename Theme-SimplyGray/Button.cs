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

namespace Zeroit.Framework.UIThemes.Simply
{

    public class SimplyGrayButton : ThemeControl
    {

        Color Gr = Color.Gray;
        Color LG = Color.LightGray;
        Color O = Color.FromArgb(244, 244, 244);
        Color D = Color.FromArgb(183, 183, 183);
        Pen P = Pens.DarkGray;

        Pen PG = Pens.Gray;
        public SimplyGrayButton()
        {
            ForeColor = Color.Black;
        }


        public override void PaintHook()
        {
            G.Clear(Color.DarkGray);

            if (MouseState == State.MouseNone)
            {
                DrawGradient(LG, Gr, 0, 0, Width, Height, 90);
            }
            else if (MouseState == State.MouseOver)
            {
                DrawGradient(O, Gr, 0, 0, Width, Height, 90);
            }
            else if (MouseState == State.MouseDown)
            {
                DrawGradient(D, Gr, 0, 0, Width, Height, 90);
            }

            DrawText(HorizontalAlignment.Center, ForeColor, 0);

            DrawBorders(P, PG, ClientRectangle);
            DrawCorners(BackColor, ClientRectangle);
        }
    }

}


