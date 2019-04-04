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
using System;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Tech
{
    public class TLFButton : ThemeControl
    {

        public TLFButton()
        {
            AllowTransparent();
        }

        public override void PaintHook()
        {
            G.Clear(Color.FromArgb(26, 92, 152));
            Pen bC1 = new Pen(Color.FromArgb(31, 52, 73));
            Pen bC2 = new Pen(Color.FromArgb(16, 90, 156));
            SolidBrush bBC = new SolidBrush(Color.FromArgb(14, 66, 112));
            G.FillRectangle(bBC, ClientRectangle);
            DrawText(HorizontalAlignment.Center, Color.FromArgb(7, 38, 81), 1, 1);

            DrawText(HorizontalAlignment.Center, Color.FromArgb(182, 217, 244), 0);


            DrawText(HorizontalAlignment.Center, Color.FromArgb(7, 38, 81), 1, 1);

            DrawText(HorizontalAlignment.Center, Color.FromArgb(182, 217, 244), 0);

            if (MouseState == State.MouseNone)
            {
                DrawGradient(Color.FromArgb(100, 255, 255, 255), Color.FromArgb(50, 255, 255, 255), 0, 0, Width, Convert.ToInt32(Height / 2), 90);
            }
            else if (MouseState == State.MouseDown)
            {
                DrawGradient(Color.FromArgb(75, 255, 255, 255), Color.FromArgb(25, 255, 255, 255), 0, 0, Width, Convert.ToInt32(Height / 2), 90);
            }
            else if (MouseState == State.MouseOver)
            {
                DrawGradient(Color.FromArgb(125, 255, 255, 255), Color.FromArgb(75, 255, 255, 255), 0, 0, Width, Convert.ToInt32(Height / 2), 90);
            }

            DrawBorders(bC1, bC2, ClientRectangle);
        }
    }

}

