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

namespace Zeroit.Framework.UIThemes.DarkMatter
{
    public class DarkMatterButton : ThemeControl152
    {

        public DarkMatterButton()
        {
            BackColor = Color.FromArgb(59, 59, 61);
        }

        Color tGlow;
        Color tColor;
        Color tTheme;
        Color tGradA;
        Color tGradB;
        Color tBordA;
        Color tBordB;
        Color tBorder;
        HorizontalAlignment tAlign;
        int tOffX;
        int tOffY;
        protected override void ColorHook()
        {
            tAlign = HorizontalAlignment.Center;
            tOffX = -1;
            tOffY = -1;
            tGlow = Color.FromArgb(35, tTheme);
            tColor = Color.FromArgb(255, tTheme);
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(47, 47, 47));

            switch (_ThemeColor)
            {
                case ColorTheme.GammaRay:
                    //GammaRay
                    tTheme = Color.LawnGreen;
                    tGradA = Color.FromArgb(111, 208, 28);
                    //First Gradient Color
                    tGradB = Color.FromArgb(92, 192, 5);
                    //Second Gradient Color
                    tBordA = Color.FromArgb(213, 248, 188);
                    //First Border Gradient Color
                    tBordB = Color.FromArgb(138, 207, 87);
                    //Second Border Gradient Color
                    tBorder = Color.FromArgb(72, 152, 0);
                    //Outer Border Color
                    break;
                case ColorTheme.RedShift:
                    //RedShift
                    tTheme = Color.Red;
                    tGradA = Color.FromArgb(236, 20, 16);
                    //First Gradient Color
                    tGradB = Color.FromArgb(223, 5, 1);
                    //Second Gradient Color
                    tBordA = Color.FromArgb(255, 198, 198);
                    //First Border Gradient Color
                    tBordB = Color.FromArgb(232, 90, 89);
                    //Second Border Gradient Color
                    tBorder = Color.FromArgb(184, 3, 1);
                    //Outer Border Color
                    break;
                case ColorTheme.Subspace:
                    //SubSpace
                    tTheme = Color.DodgerBlue;
                    tGradA = Color.FromArgb(41, 149, 255);
                    //First Gradient Color
                    tGradB = Color.FromArgb(33, 139, 255);
                    //Second Gradient Color
                    tBordA = Color.FromArgb(218, 244, 255);
                    //First Border Gradient Color
                    tBordB = Color.FromArgb(138, 191, 255);
                    //Second Border Gradient Color
                    tBorder = Color.FromArgb(6, 84, 191);
                    //Outer Border Color
                    break;
                case ColorTheme.SolarFlare:
                    //SolarFlare
                    tTheme = Color.Gold;
                    tGradA = Color.FromArgb(255, 194, 69);
                    //First Gradient Color
                    tGradB = Color.FromArgb(255, 180, 40);
                    //Second Gradient Color
                    tBordA = Color.FromArgb(254, 248, 214);
                    //First Border Gradient Color
                    tBordB = Color.FromArgb(255, 214, 144);
                    //Second Border Gradient Color
                    tBorder = Color.FromArgb(211, 148, 27);
                    //Outer Border Color
                    break;
            }



            switch (State)
            {
                case MouseState.None: //0
                    tGlow = Color.FromArgb(30, tTheme);
                    tColor = Color.FromArgb(255, tTheme);

                    DrawGradient(Color.FromArgb(109, 109, 111), Color.FromArgb(26, 26, 29), ClientRectangle, 45);
                    DrawGradient(Color.FromArgb(58, 58, 60), Color.Black, new Rectangle(2, 2, Width - 4, Height - 4), 45);
                    DrawBorders(new Pen(new SolidBrush(Color.Black)));
                    break;
                case MouseState.Over: //1
                    tGlow = Color.FromArgb(50, tTheme);
                    tColor = Color.FromArgb(255, tTheme);

                    DrawGradient(Color.FromArgb(109, 109, 111), Color.FromArgb(26, 26, 29), ClientRectangle, 45);
                    DrawGradient(Color.FromArgb(58, 58, 60), Color.Black, new Rectangle(2, 2, Width - 4, Height - 4), 45);
                    DrawBorders(new Pen(new SolidBrush(Color.Black)));
                    break;
                case MouseState.Down: //2
                    tGlow = Color.FromArgb(20, Color.Black);
                    tColor = Color.FromArgb(255, Color.Black);

                    DrawGradient(tBordA, tBordB, ClientRectangle, 45);
                    DrawGradient(tGradA, tGradB, new Rectangle(2, 2, Width - 4, Height - 4), 45);
                    DrawGradient(Color.FromArgb(60, Color.White), Color.FromArgb(30, Color.White), new Rectangle(2, 2, Width - 4, Height / 2 - 4), 90);
                    DrawBorders(new Pen(new SolidBrush(tBorder)));
                    break;
            }

            DrawText(new SolidBrush(tGlow), tAlign, tOffX - 1, tOffY);
            DrawText(new SolidBrush(tGlow), tAlign, tOffX - 1, tOffY + 1);
            DrawText(new SolidBrush(tGlow), tAlign, tOffX - 1, tOffY - 1);
            DrawText(new SolidBrush(tGlow), tAlign, tOffX + 1, tOffY);
            DrawText(new SolidBrush(tGlow), tAlign, tOffX + 1, tOffY + 1);
            DrawText(new SolidBrush(tGlow), tAlign, tOffX + 1, tOffY - 1);
            DrawText(new SolidBrush(tGlow), tAlign, tOffX, tOffY + 1);
            DrawText(new SolidBrush(tGlow), tAlign, tOffX, tOffY - 1);
            DrawText(new SolidBrush(tColor), tAlign, tOffX, tOffY);

            DrawCorners(BackColor);

        }
        public enum ColorTheme
        {
            GammaRay = 0,
            RedShift = 1,
            Subspace = 2,
            SolarFlare = 3
        }
        private ColorTheme _ThemeColor;
        public ColorTheme ThemeStyle
        {
            get { return _ThemeColor; }
            set
            {
                _ThemeColor = value;
                Invalidate();
            }
        }

    }

}
