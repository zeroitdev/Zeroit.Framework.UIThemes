// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button2.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Insomia
{
    public class insomniaButton2 : ThemeControl151
    {
        private Color C1;
        private Color C2;
        private Color C3;
        private Pen P1;
        public insomniaButton2()
        {
            SetColor("BackColor", Color.White);
        }
        protected override void ColorHook()
        {
            C1 = GetColor("BackColor");
            C2 = Color.FromArgb(50, 50, 50);
            C3 = Color.FromArgb(70, 70, 70);
            P1 = new Pen(Color.Black);
        }

        protected override void PaintHook()
        {
            G.Clear(C1);
            if ((State == MouseState.Over))
            {
                DrawGradient(C2, C3, 0, 0, Width, Height);
            }
            else if ((State == MouseState.Down))
            {
                DrawGradient(C3, C2, 0, 0, Width, Height);
            }
            else
            {
                DrawGradient(C3, C2, 0, 0, Width, Height);
            }
            DrawBorders(P1, ClientRectangle);
            DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
        }
    }


}


