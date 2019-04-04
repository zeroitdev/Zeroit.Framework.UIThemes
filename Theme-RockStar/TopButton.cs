// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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

namespace Zeroit.Framework.UIThemes.Rockstar
{
    public class RockstarTopButton : ThemeControl
    {

        public RockstarTopButton()
        {
            Size = new Size(11, 5);
        }

        public override void PaintHook()
        {


            switch (MouseState)
            {
                case State.MouseNone:
                    G.Clear(Color.Yellow);
                    break;
                case State.MouseOver:
                    G.Clear(Color.Black);
                    break;
                case State.MouseDown:
                    G.Clear(Color.Gold);
                    break;
            }

            DrawBorders(Pens.Black, Pens.Yellow, ClientRectangle);
            DrawCorners(Color.Fuchsia, ClientRectangle);
        }
    }

}
