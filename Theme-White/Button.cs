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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.WhitePure
{
    public class WhiteButton : ThemeControl153
    {
        public WhiteButton()
        {
            BackColor = Color.FromArgb(250, 250, 250);

            SetColor("Border1", 225, 225, 225);
            SetColor("Border2", 150, 150, 150);

            SetColor("Grad1", 225, 225, 225);
            SetColor("Grad2", 185, 185, 185);

            this.Size = new Size(100, 23);
        }

        Pen P1;
        Pen P2;
        Color c1;
        Color c2;

        Color tr;
        protected override void ColorHook()
        {
            P1 = new Pen(GetColor("Border1"));
            P2 = new Pen(GetColor("Border2"));

            c1 = GetColor("Grad1");
            c2 = GetColor("Grad2");
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            DrawBorders(P1, 1);

            switch (State)
            {

                case MouseState.Down:
                    DrawGradient(c1, c2, 0, 0, Width, Height);
                    break;
                case MouseState.None:
                    DrawGradient(c2, c1, 0, 0, Width, Height);
                    break;
                case MouseState.Over:
                    DrawGradient(c2, c1, 0, 0, Width, Height);
                    break;
            }

            HatchBrush DarkUp = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.Transparent, Color.FromArgb(50, Color.Black));
            G.FillRectangle(DarkUp, new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height));

            DrawBorders(P2, 0);

            //G.DrawLine(P2, 0, 20, Width, 20)
            //G.DrawLine(P1, 0, 21, Width, 21)
            //G.DrawLine(P1, 0, 22, Width, 22)
            //G.DrawLine(P2, 0, 23, Width, 23)

            DrawText(Brushes.DarkBlue, HorizontalAlignment.Center, 0, 0);
        }
    }

}

