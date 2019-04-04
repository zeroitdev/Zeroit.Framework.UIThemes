// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TopButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;


namespace Zeroit.Framework.UIThemes.Exotic
{
    public class ExoticTopButton : ThemeControl
    {
        public ExoticTopButton()
        {
            Size = new Size(11, 5);
        }
        public override void PaintHook()
        {
            switch (MouseState)
            {
                case State.MouseNone:
                    DrawGradient(Color.FromArgb(240, 248, 250), Color.FromArgb(0, 0, 0), 0, 0, Width, Height, 90);
                    break;
                case State.MouseOver:
                    DrawGradient(Color.FromArgb(240, 248, 250), Color.FromArgb(0, 0, 0), 0, 0, Width, Height, 90);
                    break;
                case State.MouseDown:
                    DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(0, 0, 0), 0, 0, Width, Height, 90);
                    break;
            }
            DrawCorners(Color.FromArgb(240, 248, 250), ClientRectangle);
            DrawBorders(Pens.Black, Pens.AliceBlue, ClientRectangle);
        }
    }


}


