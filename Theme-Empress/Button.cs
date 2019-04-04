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
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Empress
{
    public class EmpressButton : ThemeControl154
    {

        Color ButtonColor;
        Color InnerBorder;
        Brush TextColor;

        Pen border;
        public EmpressButton()
        {
            SetColor("ButtonColor", ColorConverter.HexToColor("#A12F35"));
            SetColor("Text", Color.Black);
            SetColor("InnerBorder", Color.FromArgb(55, Color.White));
        }
        protected override void ColorHook()
        {
            ButtonColor = GetColor("ButtonColor");
            TextColor = GetBrush("Text");
            InnerBorder = GetColor("InnerBorder");
            border = Pens.Black;
        }

        protected override void PaintHook()
        {
            G.Clear(ButtonColor);
            switch (State)
            {
                case MouseState.None:
                    LinearGradientBrush ButtonDefinition = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.FromArgb(5, Color.White), Color.FromArgb(55, Color.Black), 90);
                    G.FillRectangle(new SolidBrush(ButtonColor), new Rectangle(0, 0, Width - 1, Height - 1));
                    G.FillRectangle(ButtonDefinition, ButtonDefinition.Rectangle);
                    G.DrawRectangle(border, new Rectangle(0, 0, Width - 1, Height - 1));
                    break;
                case MouseState.Over:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.PeachPuff)), new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawRectangle(border, new Rectangle(0, 0, Width - 1, Height - 1));
                    DrawText(TextColor, HorizontalAlignment.Center, 0, 0);
                    break;
                case MouseState.Down:
                    G.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Violet)), new Rectangle(0, 0, Width - 1, Height - 1));
                    G.DrawRectangle(border, new Rectangle(0, 0, Width - 1, Height - 1));
                    break;
            }
            G.DrawRectangle(new Pen(InnerBorder), new Rectangle(1, 1, Width - 3, Height - 3));
            DrawText(TextColor, HorizontalAlignment.Center, 0, 0);


            HatchBrush BodyHatch = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(20, Color.Black), Color.Transparent);
            G.FillRectangle(BodyHatch, new Rectangle(0, 0, Width - 1, Height - 1));
        }
    }


}


