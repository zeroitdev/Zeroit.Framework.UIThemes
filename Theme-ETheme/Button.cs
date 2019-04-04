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

namespace Zeroit.Framework.UIThemes.ETheme
{

    public class eButton : ThemeControl
    {
        public override void PaintHook()
        {
            switch (MouseState)
            {
                case State.MouseNone:
                    G.Clear(Color.FromArgb(49, 49, 49));
                    DrawGradient(Color.FromArgb(50, 50, 50), Color.FromArgb(40, 40, 40), ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height, 90);
                    break;
                case State.MouseDown:
                    G.Clear(Color.FromArgb(49, 49, 49));
                    DrawGradient(Color.FromArgb(40, 40, 40), Color.FromArgb(50, 50, 50), ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height, 90);
                    break;
                case State.MouseOver:
                    G.Clear(Color.FromArgb(49, 49, 49));
                    DrawGradient(Color.FromArgb(60, 60, 60), Color.FromArgb(50, 50, 50), ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height, 90);
                    break;
            }
            DrawText(HorizontalAlignment.Center, Color.Gray, 0);
            DrawBorders(Pens.Black, Pens.DimGray, ClientRectangle);
            DrawCorners(Color.FromArgb(53, 53, 53), ClientRectangle);

        }
    }


}

