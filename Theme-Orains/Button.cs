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


namespace Zeroit.Framework.UIThemes.Orains
{
    public class OrainsButton : ThemeControl154
    {
        public OrainsButton()
        {
            SetColor("ButtonColor Top", 35, 35, 35);
            SetColor("ButtonColor Bot", 20, 20, 20);
            SetColor("Text", Color.Orange);
            SetColor("InnerBorder", 40, 40, 40);
            SetColor("Header", Color.FromArgb(40, 40, 40));
            // Form Header Effect
        }
        Color ButtonColor1;
        Color ButtonColor2;
        Color InnerBorder;
        Brush TextColor;
        Brush Header;

        Pen OuterBorder;
        protected override void ColorHook()
        {
            ButtonColor1 = GetColor("ButtonColor Top");
            ButtonColor2 = GetColor("ButtonColor Bot");
            TextColor = GetBrush("Text");
            InnerBorder = GetColor("InnerBorder");
            Header = GetBrush("Header");
            OuterBorder = Pens.Black;
        }

        protected override void PaintHook()
        {
            //G.Clear(BackColor)


            switch (State)
            {
                case MouseState.None:

                    LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), ButtonColor1, ButtonColor2, 90);
                    G.FillRectangle(LGB, new Rectangle(0, 0, Width - 1, Height - 1));
                    HatchBrush BodyHatch = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(30, Color.Black), Color.Transparent);
                    G.FillRectangle(BodyHatch, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(new SolidBrush(Color.DarkOrange), HorizontalAlignment.Center, 0, 0);

                    G.DrawRectangle(OuterBorder, new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawRectangle(new Pen(InnerBorder), new Rectangle(1, 1, Width - 3, Height - 3));
                    break;
                case MouseState.Over:

                    LinearGradientBrush LGB1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), ButtonColor1, Color.FromArgb(20, 20, 20), 90);
                    G.FillRectangle(LGB1, new Rectangle(0, 0, Width - 1, Height - 1));
                    HatchBrush BodyHatch1 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(30, Color.Black), Color.Transparent);
                    G.FillRectangle(BodyHatch1, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(TextColor, HorizontalAlignment.Center, -1, -1);

                    G.DrawRectangle(OuterBorder, new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawRectangle(new Pen(Color.FromArgb(45, 45, 45)), new Rectangle(1, 1, Width - 3, Height - 3));
                    break;
                case MouseState.Down:
                    LinearGradientBrush LGB2 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(20, 20, 20), ButtonColor2, 90);
                    G.FillRectangle(LGB2, new Rectangle(0, 0, Width - 1, Height - 1));
                    HatchBrush BodyHatch2 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(30, Color.Black), Color.Transparent);
                    G.FillRectangle(BodyHatch2, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(new SolidBrush(Color.DarkOrange), HorizontalAlignment.Center, 1, 1);

                    G.DrawRectangle(OuterBorder, new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawRectangle(new Pen(Color.FromArgb(32, 32, 32)), new Rectangle(1, 1, Width - 3, Height - 3));
                    break;
            }




            //Dim BodyHatch As New HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(20, Color.Black), Color.Transparent)
            // G.FillRectangle(BodyHatch, New Rectangle(0, 0, Width - 1, Height - 1))
        }

    }

}


