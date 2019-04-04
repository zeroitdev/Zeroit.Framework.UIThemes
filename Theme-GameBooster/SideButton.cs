// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="SideButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.GameBooster
{

    public class GameBoosterSideButton : ThemeControl154
    {
        public enum _Icon
        {
            Square = 1,
            Circle = 2,
            Custom_Image = 3
        }
        public enum _Color
        {
            Red = 1,
            Green = 2,
            Yellow = 3
        }
        private _Icon _DisplayIcon;
        private _Color _Col;
        public _Icon DisplayIcon
        {
            get { return _DisplayIcon; }
            set
            {
                _DisplayIcon = value;
                Invalidate();
            }
        }
        public _Color SideColor
        {
            get { return _Col; }
            set
            {
                _Col = value;
                Invalidate();
            }
        }
        public GameBoosterSideButton()
        {
            LockHeight = 30;
            Width = 227;
        }
        private Color GrayGradient1;
        private Color GrayGradient2;
        private Color GrayGradient3;
        private Color GrayGradient4;
        private Color RedGradient1;
        private Color RedGradient2;
        private Color RedGradient3;
        private Color RedGradient4;
        private Pen OuterBorder;
        private Pen InnerBorderGray;
        private Pen InnerBorderRed;
        private Pen InnerBorderGreen;
        private Pen InnerBorderYellow;
        private Pen InnerBorderGrayHover;
        private Pen InnerBorderGrayClick;
        private Color GreenGradient1;
        private Color GreenGradient2;
        private Color GreenGradient3;
        private Color GreenGradient4;
        private Color YellowGradient1;
        private Color YellowGradient2;
        private Color YellowGradient3;
        private Color YellowGradient4;
        private Color ExtraPixelRed;
        private Color ExtraPixelGreen;
        private Color ExtraPixelYellow;
        private Color GrayGradientHover1;
        private Color GrayGradientHover2;
        private Color GrayGradientHover3;
        private Color GrayGradientHover4;
        private Color GrayGradientClick1;
        private Color GrayGradientClick2;
        private Color GrayGradientClick3;
        private Color GrayGradientClick4;
        private SolidBrush TextCol;
        private Color CircleColor;
        private Color SquareColor;
        protected override void ColorHook()
        {
            OuterBorder = new Pen(Color.Black);
            InnerBorderRed = new Pen(Color.FromArgb(216, 70, 70));
            InnerBorderGray = new Pen(Color.FromArgb(87, 87, 87));
            InnerBorderGreen = new Pen(Color.FromArgb(68, 204, 2));
            InnerBorderYellow = new Pen(Color.FromArgb(247, 219, 17));
            InnerBorderGrayHover = new Pen(Color.FromArgb(104, 104, 104));
            InnerBorderGrayClick = new Pen(Color.FromArgb(79, 79, 79));
            TextCol = new SolidBrush(Color.White);
            ExtraPixelRed = Color.FromArgb(133, 37, 37);
            ExtraPixelGreen = Color.FromArgb(1, 58, 11);
            ExtraPixelYellow = Color.FromArgb(206, 111, 4);
            SquareColor = Color.White;

            GrayGradient1 = Color.FromArgb(59, 59, 59);
            GrayGradient2 = Color.FromArgb(45, 45, 45);
            GrayGradient3 = Color.FromArgb(33, 33, 33);
            GrayGradient4 = Color.FromArgb(24, 24, 24);

            GrayGradientHover1 = Color.FromArgb(78, 78, 78);
            GrayGradientHover2 = Color.FromArgb(64, 64, 64);
            GrayGradientHover3 = Color.FromArgb(48, 48, 48);
            GrayGradientHover4 = Color.FromArgb(38, 38, 38);

            GrayGradientClick1 = Color.FromArgb(48, 48, 48);
            GrayGradientClick2 = Color.FromArgb(35, 35, 35);
            GrayGradientClick3 = Color.FromArgb(33, 33, 33);
            GrayGradientClick4 = Color.FromArgb(24, 24, 24);

            RedGradient1 = Color.FromArgb(206, 38, 38);
            RedGradient2 = Color.FromArgb(157, 25, 25);
            RedGradient3 = Color.FromArgb(147, 12, 12);
            RedGradient4 = Color.FromArgb(104, 2, 2);

            GreenGradient1 = Color.FromArgb(52, 155, 2);
            GreenGradient2 = Color.FromArgb(43, 129, 1);
            GreenGradient3 = Color.FromArgb(2, 100, 19);
            GreenGradient4 = Color.FromArgb(1, 78, 15);

            YellowGradient1 = Color.FromArgb(232, 151, 10);
            YellowGradient2 = Color.FromArgb(236, 167, 12);
            YellowGradient3 = Color.FromArgb(228, 141, 5);
            YellowGradient4 = Color.FromArgb(223, 122, 4);

            CircleColor = Color.White;
        }

        protected override void PaintHook()
        {
            //'---GRAY---
            if (State == MouseState.Down)
            {
                DrawGradient(GrayGradientClick3, GrayGradientClick4, new Rectangle(1, Height / 2 - 1, Width, Height / 2 + 2));
                //BOT
                DrawGradient(GrayGradientClick1, GrayGradientClick2, new Rectangle(1, 1, Width, Height / 2 - 1));
                //TOP
            }
            else if (State == MouseState.Over)
            {
                DrawGradient(GrayGradientHover3, GrayGradientHover4, new Rectangle(1, Height / 2 - 1, Width, Height / 2 + 2));
                //BOT
                DrawGradient(GrayGradientHover1, GrayGradientHover2, new Rectangle(1, 1, Width, Height / 2 - 1));
                //TOP
            }
            else
            {
                DrawGradient(GrayGradient3, GrayGradient4, new Rectangle(1, Height / 2 - 1, Width, Height / 2 + 2));
                //BOT
                DrawGradient(GrayGradient1, GrayGradient2, new Rectangle(1, 1, Width, Height / 2 - 1));
                //TOP
            }
            //'---COLOR---
            if (_Col == _Color.Green)
            {
                DrawGradient(GreenGradient3, GreenGradient4, new Rectangle(1, Height / 2 - 1, 23, Height / 2 + 2));
                //BOT
                DrawGradient(GreenGradient1, GreenGradient2, new Rectangle(1, 1, 23, Height / 2 - 1));
                //TOP
            }
            else if (_Col == _Color.Yellow)
            {
                DrawGradient(YellowGradient3, YellowGradient4, new Rectangle(1, Height / 2 - 1, 23, Height / 2 + 2));
                //BOT
                DrawGradient(YellowGradient1, YellowGradient2, new Rectangle(1, 1, 23, Height / 2 - 1));
                //TOP
            }
            else
            {
                DrawGradient(RedGradient3, RedGradient4, new Rectangle(1, Height / 2 - 1, 23, Height / 2 + 2));
                //BOT
                DrawGradient(RedGradient1, RedGradient2, new Rectangle(1, 1, 23, Height / 2 - 1));
                //TOP
            }
            //'---------
            if (_Col == _Color.Green)
            {
                G.DrawRectangle(InnerBorderGreen, new Rectangle(1, 1, 22, Height - 3));
            }
            else if (_Col == _Color.Yellow)
            {
                G.DrawRectangle(InnerBorderYellow, new Rectangle(1, 1, 22, Height - 3));
            }
            else
            {
                G.DrawRectangle(InnerBorderRed, new Rectangle(1, 1, 22, Height - 3));
            }
            if (State == MouseState.Down)
            {
                G.DrawRectangle(InnerBorderGrayClick, new Rectangle(24, 1, Width - 26, Height - 3));
            }
            else if (State == MouseState.Over)
            {
                G.DrawRectangle(InnerBorderGrayHover, new Rectangle(24, 1, Width - 26, Height - 3));
            }
            else
            {
                G.DrawRectangle(InnerBorderGray, new Rectangle(24, 1, Width - 26, Height - 3));
            }
            DrawBorders(OuterBorder);
            //---TOPLEFT---

            if (_Col == _Color.Green)
            {
                DrawPixel(ExtraPixelGreen, 1, 2);
                DrawPixel(ExtraPixelGreen, 2, 1);
                DrawPixel(InnerBorderGreen.Color, 2, 2);
            }
            else if (_Col == _Color.Yellow)
            {
                DrawPixel(ExtraPixelYellow, 1, 2);
                DrawPixel(ExtraPixelYellow, 2, 1);
                DrawPixel(InnerBorderYellow.Color, 2, 2);
            }
            else
            {
                DrawPixel(ExtraPixelRed, 1, 2);
                DrawPixel(ExtraPixelRed, 2, 1);
                DrawPixel(InnerBorderRed.Color, 2, 2);
            }
            DrawPixel(OuterBorder.Color, 1, 1);
            //---BOTLEFT---
            DrawPixel(Color.FromArgb(51, 51, 51), 0, Height - 1);
            DrawPixel(Color.FromArgb(51, 51, 51), 1, Height - 1);
            DrawPixel(Color.FromArgb(51, 51, 51), 0, Height - 2);

            if (_Col == _Color.Green)
            {
                DrawPixel(InnerBorderGreen.Color, 2, Height - 3);
                DrawPixel(ExtraPixelGreen, 1, Height - 3);
                DrawPixel(ExtraPixelGreen, 2, Height - 2);
            }
            else if (_Col == _Color.Yellow)
            {
                DrawPixel(InnerBorderYellow.Color, 2, Height - 3);
                DrawPixel(ExtraPixelYellow, 1, Height - 3);
                DrawPixel(ExtraPixelYellow, 2, Height - 2);
            }
            else
            {
                DrawPixel(InnerBorderRed.Color, 2, Height - 3);
                DrawPixel(ExtraPixelRed, 1, Height - 3);
                DrawPixel(ExtraPixelRed, 2, Height - 2);
            }
            DrawPixel(OuterBorder.Color, 1, Height - 2);

            //---ICON---
            if (DisplayIcon == _Icon.Square)
            {
                DrawGradient(SquareColor, SquareColor, new Rectangle(7, 9, 5, 5));
                DrawGradient(SquareColor, SquareColor, new Rectangle(13, 9, 5, 5));
                DrawGradient(SquareColor, SquareColor, new Rectangle(7, 15, 5, 5));
                DrawGradient(SquareColor, SquareColor, new Rectangle(13, 15, 5, 5));
            }
            else if (DisplayIcon == _Icon.Circle)
            {
                G.SmoothingMode = SmoothingMode.HighQuality;
                G.DrawEllipse(new Pen(CircleColor), 6, 8, 12, 12);
                G.FillEllipse(new SolidBrush(CircleColor), 8, 10, 8, 8);
            }
            else if (DisplayIcon == _Icon.Custom_Image)
            {
                G.DrawImage(Image, 5, 8, 16, 16);
            }
            else
            {
                DrawGradient(SquareColor, SquareColor, new Rectangle(7, 9, 5, 5));
                DrawGradient(SquareColor, SquareColor, new Rectangle(13, 9, 5, 5));
                DrawGradient(SquareColor, SquareColor, new Rectangle(7, 15, 5, 5));
                DrawGradient(SquareColor, SquareColor, new Rectangle(13, 15, 5, 5));
            }

            DrawText(TextCol, HorizontalAlignment.Left, 31, 0);
            DrawPixel(Color.FromArgb(51, 51, 51), 0, 0);
            DrawPixel(Color.FromArgb(51, 51, 51), 1, 0);
            DrawPixel(Color.FromArgb(51, 51, 51), 0, 1);
            DrawPixel(Color.FromArgb(51, 51, 51), 0, Height - 1);
            DrawPixel(Color.FromArgb(51, 51, 51), 1, Height - 1);
            DrawPixel(Color.FromArgb(51, 51, 51), 0, Height - 2);

        }
    }

}


