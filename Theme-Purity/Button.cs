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
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Purity
{
    public class PurityxButton : ThemeControl
    {

        public override void PaintHook()
        {
            switch (MouseState)
            {
                case State.MouseNone:
                    G.Clear(Color.Red);
                    DrawGradient(Color.FromArgb(62, 62, 62), Color.FromArgb(38, 38, 38), 0, 0, Width, Height, 90);
                    break;
                case State.MouseOver:
                    G.Clear(Color.Red);
                    DrawGradient(Color.FromArgb(62, 62, 62), Color.FromArgb(38, 38, 38), 0, 0, Width, Height, 90);
                    break;
                case State.MouseDown:
                    G.Clear(Color.DarkRed);
                    DrawGradient(Color.FromArgb(38, 38, 38), Color.FromArgb(62, 62, 62), 0, 0, Width, Height, 90);
                    break;
            }

            DrawBorders(Pens.Black, Pens.DimGray, ClientRectangle);
            // Form Border
            DrawCorners(Color.Black, ClientRectangle);
            // Clean Corners
            DrawText(HorizontalAlignment.Center, Color.Red, 0);
        }
    }

}

