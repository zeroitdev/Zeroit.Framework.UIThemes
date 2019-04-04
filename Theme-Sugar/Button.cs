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
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Sugar
{
    public class SugarButton : ThemeControl154
    {
        Color Buttoncolor;
        Brush Textcolor;

        Pen Border;
        public SugarButton()
        {
            SetColor("Button", Color.FromArgb(220, 232, 235));
            SetColor("Text", Color.FromArgb(49, 51, 48));
            SetColor("Border", Color.White);

        }

        protected override void ColorHook()
        {
            Buttoncolor = GetColor("Button");
            Textcolor = GetBrush("Text");
            Border = GetPen("Border");

        }

        protected override void PaintHook()
        {
            G.Clear(Buttoncolor);


            DrawCorners(BackColor);
            switch (State)
            {
                case MouseState.None:

                    HatchBrush HB = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(30, Color.White), Color.Transparent);
                    G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                    G.FillRectangle(HB, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(Textcolor, HorizontalAlignment.Center, 0, 0);

                    break;
                case MouseState.Over:

                    HatchBrush HB1 = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(30, Color.White), Color.Transparent);
                    G.FillRectangle(new SolidBrush(Color.FromArgb(236, 241, 242)), new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                    G.FillRectangle(HB1, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(Textcolor, HorizontalAlignment.Center, 0, 0);
                    break;
                case MouseState.Down:

                    HatchBrush HB2 = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(30, Color.White), Color.Transparent);
                    G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Black)), new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
                    G.FillRectangle(HB2, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(Textcolor, HorizontalAlignment.Center, 0, 0);
                    break;
            }
        }
    }

}

