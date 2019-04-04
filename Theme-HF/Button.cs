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

namespace Zeroit.Framework.UIThemes.HF
{
    public class HFxButton : ThemeControl
    {

        public override void PaintHook()
        {
            switch (MouseState)
            {
                case State.MouseNone:
                    G.Clear(Color.Purple);

                    break;
                case State.MouseOver:
                    DrawGradient(Color.Gray, Color.Purple, 0, 0, Width, Height, 90);

                    break;
                case State.MouseDown:
                    DrawGradient(Color.Purple, Color.Gray, 0, 0, Width, Height, 90);
                    break;
            }

            DrawBorders(Pens.Black, Pens.Purple, ClientRectangle);
            // Form Border
            DrawCorners(Color.Black, ClientRectangle);
            // Clean Corners
            DrawText(HorizontalAlignment.Center, Color.White, 0);
        }
    }

}


