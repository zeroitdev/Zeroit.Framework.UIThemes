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

namespace Zeroit.Framework.UIThemes.Rockstar
{
    public class RockstarButton : ThemeControl
    {
        public override void PaintHook()
        {
            switch (MouseState)
            {
                case State.MouseNone:
                    G.Clear(Color.Gold);
                    break;
                case State.MouseOver:
                    G.Clear(Color.LightGoldenrodYellow);
                    break;
                case State.MouseDown:
                    G.Clear(Color.Yellow);
                    break;
            }
            DrawText(HorizontalAlignment.Center, Color.Black, 0);



            DrawCorners(Color.Fuchsia, ClientRectangle);
            DrawBorders(Pens.Black, Pens.Yellow, ClientRectangle);
        }
    }

}
