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

namespace Zeroit.Framework.UIThemes.Zeus
{
    public class ZeusButton : ThemeControl
    {

        #region " PaintHook "


        public override void PaintHook()
        {
            Color C1 = Color.FromArgb(38, 38, 38);
            Color C2 = Color.AliceBlue;
            Color C3 = Color.FromArgb(150, 255, 255);
            Pen P1 = Pens.Black;
            Pen P2 = Pens.AliceBlue;

            switch (MouseState)
            {

                case State.MouseNone:
                    G.Clear(C1);
                    DrawGradient(C2, C3, 0, 0, Width, Height, 90);
                    DrawText(HorizontalAlignment.Center, C1, 0);
                    DrawBorders(P1, P2, ClientRectangle);
                    break;
                case State.MouseOver:
                    G.Clear(C1);
                    DrawGradient(C2, C3, 0, 0, Width, Height, 90);
                    DrawText(HorizontalAlignment.Center, C1, 0);
                    DrawBorders(P2, P1, ClientRectangle);
                    break;
                case State.MouseDown:
                    G.Clear(C1);
                    DrawGradient(C2, C3, 0, 0, Width - 1, Height - 1, 90);
                    G.DrawRectangle(P1, 2, 2, Width - 5, Height - 5);
                    DrawText(HorizontalAlignment.Center, C1, 0);
                    DrawBorders(P1, P2, ClientRectangle);
                    break;
            }

        }

        #endregion

    }

}


