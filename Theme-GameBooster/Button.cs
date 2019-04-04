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

namespace Zeroit.Framework.UIThemes.GameBooster
{
    public class GameBoosterButton : ThemeControl154
    {

        public GameBoosterButton()
        {
        }
        private Color TopGradient;
        private Color BotGradient;
        private Color TopGradientClick;
        private Color BotGradientClick;
        private Color TopGradientHover;
        private Color BotGradientHover;
        private Pen InnerBorder;
        private Pen OuterBorder;
        private Pen InnerBorderHover;
        private Pen OuterBorderHover;
        private Pen InnerBorderClick;
        private Pen OuterBorderClick;
        private SolidBrush TextCol;
        protected override void ColorHook()
        {
            TopGradient = Color.FromArgb(55, 55, 55);
            BotGradient = Color.FromArgb(32, 32, 32);

            TopGradientHover = Color.FromArgb(66, 66, 66);
            BotGradientHover = Color.FromArgb(41, 41, 41);

            TopGradientClick = Color.FromArgb(60, 60, 60);
            BotGradientClick = Color.FromArgb(37, 37, 37);

            TextCol = new SolidBrush(Color.FromArgb(204, 204, 204));

            OuterBorder = new Pen(Color.Black);
            InnerBorder = new Pen(Color.FromArgb(76, 76, 76));

            OuterBorderHover = new Pen(Color.Black);
            InnerBorderHover = new Pen(Color.FromArgb(87, 87, 87));

            OuterBorderClick = new Pen(Color.Black);
            InnerBorderClick = new Pen(Color.FromArgb(71, 71, 71));
        }


        protected override void PaintHook()
        {
            if (State == MouseState.Down)
            {
                DrawGradient(TopGradientClick, BotGradientClick, new Rectangle(2, 1, Width - 4, Height - 3), 90f);
                G.DrawRectangle(InnerBorderClick, 1, 1, ClientRectangle.Width - 3, ClientRectangle.Height - 3);
                //TOPLEFT
                DrawPixel(OuterBorderClick.Color, 1, 1);
                DrawPixel(InnerBorderClick.Color, 2, 2);
                //TOPRIGHT
                DrawPixel(OuterBorderClick.Color, Width - 2, 1);
                DrawPixel(InnerBorderClick.Color, Width - 3, 2);
                //BOTTOMLEFT
                DrawPixel(OuterBorderClick.Color, 1, Height - 2);
                DrawPixel(InnerBorderClick.Color, 1, Height - 3);
                //BOTTOMRIGHT
                DrawPixel(OuterBorderClick.Color, Width - 2, Height - 2);
                DrawPixel(InnerBorderClick.Color, Width - 3, Height - 3);
                DrawBorders(OuterBorderClick);
            }
            else
            {
                DrawGradient(TopGradient, BotGradient, new Rectangle(2, 1, Width - 4, Height - 3), 90f);
                G.DrawRectangle(InnerBorder, 1, 1, ClientRectangle.Width - 3, ClientRectangle.Height - 3);
                //TOPLEFT
                DrawPixel(OuterBorder.Color, 1, 1);
                DrawPixel(InnerBorder.Color, 2, 2);
                //TOPRIGHT
                DrawPixel(OuterBorder.Color, Width - 2, 1);
                DrawPixel(InnerBorder.Color, Width - 3, 2);
                //BOTTOMLEFT
                DrawPixel(OuterBorder.Color, 1, Height - 2);
                DrawPixel(InnerBorder.Color, 1, Height - 3);
                //BOTTOMRIGHT
                DrawPixel(OuterBorder.Color, Width - 2, Height - 2);
                DrawPixel(InnerBorder.Color, Width - 3, Height - 3);
                DrawBorders(OuterBorder);
            }

            if (State == MouseState.Over)
            {
                DrawGradient(TopGradientHover, BotGradientHover, new Rectangle(2, 1, Width - 4, Height - 3), 90f);
                G.DrawRectangle(InnerBorderHover, 1, 1, ClientRectangle.Width - 3, ClientRectangle.Height - 3);
                //TOPLEFT
                DrawPixel(OuterBorderHover.Color, 1, 1);
                DrawPixel(InnerBorderHover.Color, 2, 2);
                //TOPRIGHT
                DrawPixel(OuterBorderHover.Color, Width - 2, 1);
                DrawPixel(InnerBorderHover.Color, Width - 3, 2);
                //BOTTOMLEFT
                DrawPixel(OuterBorderHover.Color, 1, Height - 2);
                DrawPixel(InnerBorderHover.Color, 1, Height - 3);
                //BOTTOMRIGHT
                DrawPixel(OuterBorderHover.Color, Width - 2, Height - 2);
                DrawPixel(InnerBorderHover.Color, Width - 3, Height - 3);
                DrawBorders(OuterBorderHover);
            }

            DrawText(TextCol, HorizontalAlignment.Center, 0, 0);

            DrawCorners(Color.FromArgb(51, 51, 51));
        }
    }

}


