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

namespace Zeroit.Framework.UIThemes.Paladin
{
    public class PaladinButton : ThemeControl154
    {


        protected override void ColorHook()
        {
        }


        protected override void PaintHook()
        {


            G.Clear(Color.FromArgb(205, Color.Gainsboro));

            LinearGradientBrush HeaderLGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height / 2), Color.FromArgb(230, 230, 230), Color.FromArgb(210, 210, 210), 90);
            G.FillRectangle(HeaderLGB, 0, 0, Width, Height / 2);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(215, 215, 215))), 1, Height - 1, Width - 2, Height - 1);



            DrawBorders(new Pen(new SolidBrush(Color.FromArgb(222, 222, 222))), 1, 1, Width - 2, Height - 3);
            // up
            DrawBorders(new Pen(new SolidBrush(Color.FromArgb(140, 140, 140))), 0, 0, Width, Height - 1);
            // sous


            DrawCorners(Color.FromArgb(180, 180, 180), 1, 1, Width - 2, Height - 3);
            DrawCorners(Color.FromArgb(200, 200, 200), 0, 0, Width, Height - 1);

            DrawText(new SolidBrush(Color.Silver), HorizontalAlignment.Center, 1, 1);
            DrawText(new SolidBrush(Color.Black), HorizontalAlignment.Center, 0, 0);

            if (State == MouseState.Over)
            {
                G.Clear(Color.FromArgb(210, Color.Gainsboro));
                LinearGradientBrush HeaderLGB1 = new LinearGradientBrush(new Rectangle(0, 0, Width, Height / 2), Color.FromArgb(235, 235, 235), Color.FromArgb(215, 215, 215), 90);
                G.FillRectangle(HeaderLGB1, 0, 0, Width, Height / 2);
                G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(222, 222, 222))), 1, Height - 1, Width - 2, Height - 1);
                DrawBorders(new Pen(new SolidBrush(Color.FromArgb(230, 230, 230))), 1, 1, Width - 2, Height - 3);
                // up
                DrawBorders(new Pen(new SolidBrush(Color.FromArgb(140, 140, 140))), 0, 0, Width, Height - 1);
                // sous


                DrawCorners(Color.FromArgb(180, 180, 180), 1, 1, Width - 2, Height - 3);
                DrawCorners(Color.FromArgb(200, 200, 200), 0, 0, Width, Height - 1);

                DrawText(new SolidBrush(Color.White), HorizontalAlignment.Center, 1, 1);
                DrawText(new SolidBrush(Color.Black), HorizontalAlignment.Center, 0, 0);


            }
            else if (State == MouseState.Down)
            {
                G.Clear(Color.FromArgb(200, Color.Gainsboro));
                LinearGradientBrush HeaderLGB1 = new LinearGradientBrush(new Rectangle(0, 0, Width, Height / 2), Color.FromArgb(225, 225, 225), Color.FromArgb(205, 205, 205), 90);
                G.FillRectangle(HeaderLGB1, 0, 0, Width, Height / 2);
                G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(210, 210, 210))), 1, Height - 1, Width - 2, Height - 1);


                DrawBorders(new Pen(new SolidBrush(Color.FromArgb(217, 217, 217))), 1, 1, Width - 2, Height - 3);
                // up
                DrawBorders(new Pen(new SolidBrush(Color.FromArgb(140, 140, 140))), 0, 0, Width, Height - 1);
                // sous


                DrawCorners(Color.FromArgb(180, 180, 180), 1, 1, Width - 2, Height - 3);
                DrawCorners(Color.FromArgb(200, 200, 200), 0, 0, Width, Height - 1);

                DrawText(new SolidBrush(Color.Silver), HorizontalAlignment.Center, 1, 1);
                DrawText(new SolidBrush(Color.Black), HorizontalAlignment.Center, 0, 0);

            }
        }
    }

}

