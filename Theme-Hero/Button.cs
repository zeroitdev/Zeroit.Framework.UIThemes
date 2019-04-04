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

namespace Zeroit.Framework.UIThemes.Hero
{
    public class HeroButton : ThemeControl
    {

        public override void PaintHook()
        {
            switch (MouseState)
            {
                case State.MouseNone:
                    G.Clear(Color.FromArgb(50, 50, 50));
                    DrawGradient(Color.FromArgb(62, 62, 62), Color.FromArgb(40, 40, 40), 0, 0, Width, Height, 90);
                    break;
                case State.MouseOver:
                    G.Clear(Color.Gray);
                    DrawGradient(Color.FromArgb(62, 62, 62), Color.FromArgb(40, 40, 40), 0, 0, Width, Height, 90);
                    break;
                case State.MouseDown:
                    G.Clear(Color.FromArgb(211, 211, 211));
                    DrawGradient(Color.FromArgb(38, 38, 38), Color.FromArgb(40, 40, 40), 0, 0, Width, Height, 90);
                    break;
            }

            DrawCorners(Color.Black, ClientRectangle);
            DrawText(HorizontalAlignment.Center, Color.FromArgb(211, 211, 211), 0);
        }
    }

}


