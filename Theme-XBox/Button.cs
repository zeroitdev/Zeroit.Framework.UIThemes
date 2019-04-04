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

namespace Zeroit.Framework.UIThemes.Xbox
{

    public class XboxButton : ThemeControl
    {


        public override void PaintHook()
        {
            switch (MouseState)
            {
                case State.MouseNone:
                    G.Clear(Color.LightGray);
                    DrawGradient(Color.GhostWhite, Color.LightGray, 0, 0, Width, 20, 90);
                    break;
                case State.MouseOver:
                    G.Clear(Color.Orange);
                    DrawGradient(Color.FromArgb(0, 255, 36), (Color.FromArgb(0, 140, 20)), 0, 0, Width, 25, 90);
                    break;
                case State.MouseDown:
                    G.Clear(Color.Orange);
                    DrawGradient(Color.DarkGreen, (Color.FromArgb(18, 255, 0)), 0, 0, Width, 30, 90);
                    break;
            }
            DrawText(HorizontalAlignment.Center, Color.FromArgb(190, 190, 190), 0);
            DrawBorders(Pens.DarkGreen, Pens.LightGray, ClientRectangle);
            DrawCorners(Color.DarkGreen, ClientRectangle);
        }
    }

}


