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


namespace Zeroit.Framework.UIThemes.Exotic
{
    public class ExoticButton : ThemeControl
    {
        public override void PaintHook()
        {
            G.Clear(Color.LightGray);
            switch (MouseState)
            {
                case State.MouseDown:
                    DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(240, 248, 255), 3, 4, Width - 6, Height - 6, 90);
                    DrawText(HorizontalAlignment.Center, Color.Black, 0);
                    break;
                case State.MouseNone:
                    DrawGradient(Color.FromArgb(240, 248, 255), Color.FromArgb(0, 0, 0), 3, 4, Width - 6, Height - 6, 90);
                    DrawText(HorizontalAlignment.Center, Color.Black, 0);
                    break;
                case State.MouseOver:
                    DrawGradient(Color.FromArgb(240, 248, 255), Color.FromArgb(0, 0, 0), 3, 4, Width - 6, Height - 6, 90);
                    DrawText(HorizontalAlignment.Center, Color.Black, 0);
                    break;
            }
            DrawBorders(Pens.Black, Pens.AliceBlue, ClientRectangle);
            DrawCorners(Color.LightGray, ClientRectangle);
        }
    }


}


