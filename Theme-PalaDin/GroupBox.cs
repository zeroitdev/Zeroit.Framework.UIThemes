// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Paladin
{
    public class PalaDinGroupBox : ThemeContainer154
    {
        public PalaDinGroupBox()
        {
            ControlMode = true;
            Header = 22;
        }

        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(190, Color.Gainsboro));
            G.SmoothingMode = SmoothingMode.HighQuality;

            G.DrawLine(new Pen(Color.FromArgb(120, 120, 120)), 0, 23, Width, 23);


            //G.DrawRectangle((New Pen(New SolidBrush(Color.FromArgb(100, 100, 100)))), New Rectangle(1, 1, Width - 3, Height - 1))
            G.DrawRectangle((new Pen(new SolidBrush(Color.FromArgb(255, 255, 255)))), new Rectangle(0, 0, Width - 1, Height - 1));


            LinearGradientBrush HeaderLGB = new LinearGradientBrush(new Rectangle(2, 2, Width - 5, 11), Color.FromArgb(210, 210, 210), Color.FromArgb(190, 190, 190), 90);
            G.FillRectangle(HeaderLGB, new Rectangle(2, 2, Width - 5, 10));

            //'
            LinearGradientBrush DownLGB = new LinearGradientBrush(new Rectangle(0, -1, Width - 2, 20), Color.FromArgb(60, Color.White), Color.FromArgb(20, Color.White), 90);
            G.FillRectangle(DownLGB, new Rectangle(2, -1, Width - 2, 20));
            DrawBorders(new Pen(Color.FromArgb(150, 150, 150)), new Rectangle(3, 3, Width - 6, 18));

            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(90, 90, 90))), 1, 145, Width - 2, 145);
            //InnerButtumline


            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(100, 100, 100))), 0, 0, Width, 0);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(100, 100, 100))), 0, 0, 0, 145);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(100, 100, 100))), Width - 1, 0, Width - 1, 145);



            DrawText(new SolidBrush(Color.Silver), HorizontalAlignment.Center, 1, 2);
            DrawText(new SolidBrush(Color.Black), HorizontalAlignment.Center, 0, 1);
        }
    }


}

