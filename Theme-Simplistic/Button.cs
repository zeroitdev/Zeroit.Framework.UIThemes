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

namespace Zeroit.Framework.UIThemes.Simplistic
{

    public class SButton : ThemeControl
    {


        public SButton()
        {
        }


        public override void PaintHook()
        {
            switch (MouseState)
            {
                case State.MouseNone:
                    G.Clear(Color.SteelBlue);
                    break;
                case State.MouseDown:
                    G.Clear(Color.DodgerBlue);
                    break;
            }

            DrawText(HorizontalAlignment.Center, Color.Black, 0);
            DrawBorders(Pens.Black, Pens.LightGray, ClientRectangle);
            DrawCorners(BackColor, ClientRectangle);
        }
    }

}

