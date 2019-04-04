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

namespace Zeroit.Framework.UIThemes.GTheme
{
    public class GButton : ThemeControl
    {

        private Pen P1;
        private Pen P3;
        private Color C1;
        private Color C2;

        private Color B1;
        public GButton()
        {
            P3 = new Pen(Color.FromArgb(92, 92, 92));
            P1 = new Pen(Color.FromArgb(31, 31, 31));
            C1 = Color.FromArgb(25, 25, 25);
            C2 = Color.FromArgb(43, 43, 43);
            //above
            B1 = Color.FromArgb(204, 204, 204);
        }


        public override void PaintHook()
        {
            if (MouseState == State.MouseDown)
            {
                DrawGradient(C1, C2, 0, 0, Width, Height, 90);
            }
            else
            {
                DrawGradient(C2, C1, 0, 0, Width, Height, 90);
            }
            DrawText(HorizontalAlignment.Center, B1, 0);
            DrawIcon(HorizontalAlignment.Left, 0);

            DrawBorders(P1, P3, ClientRectangle);
            DrawCorners(Color.FromArgb(25, 25, 25), ClientRectangle);
        }

    }


}


