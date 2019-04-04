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


namespace Zeroit.Framework.UIThemes.Nameless
{
    public class NameLessbutton : ThemeControl154
    {


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(20, Color.White));
            Rectangle GrdRect = new Rectangle(0, 0, Width, this.Height / 2);
            LinearGradientBrush HeaderLGB = new LinearGradientBrush(GrdRect, Color.FromArgb(130, 130, 130), Color.FromArgb(40, 40, 40), 90);
            G.FillRectangle(HeaderLGB, GrdRect);
            //DrawGradient(Color.FromArgb(70, 70, 70), Color.FromArgb(30, 30, 30), 0, 0, Width, Me.Height \ 2)
            DrawBorders(new Pen(Color.FromArgb(50, 50, 50)), 1);
            DrawBorders(Pens.Black, 2);
            DrawBorders(Pens.Black);

            DrawCorners(Color.Black, ClientRectangle);
            DrawText(new SolidBrush(Color.FromArgb(180, 180, 180)), HorizontalAlignment.Center, 0, 0);


            if (State == MouseState.Over)
            {
                G.Clear(Color.FromArgb(35, Color.White));
                //DrawGradient(Color.FromArgb(80, 80, 80), Color.FromArgb(40, 40, 40), 0, 0, Width, Me.Height \ 2)

                Rectangle GrdRect1 = new Rectangle(0, 0, Width, this.Height / 2);
                LinearGradientBrush HeaderLGB1 = new LinearGradientBrush(GrdRect1, Color.FromArgb(150, 150, 150), Color.FromArgb(50, 50, 50), 90);
                G.FillRectangle(HeaderLGB1, GrdRect1);
                DrawBorders(new Pen(Color.FromArgb(50, 50, 50)), 1);
                DrawBorders(Pens.Black, 2);
                DrawBorders(Pens.Black);

                DrawCorners(Color.Black, ClientRectangle);
                DrawText(new SolidBrush(Color.FromArgb(222, 222, 222)), HorizontalAlignment.Center, 0, 0);


            }
            else if (State == MouseState.Down)
            {
                G.Clear(Color.FromArgb(10, Color.White));
                DrawGradient(Color.FromArgb(60, 60, 60), Color.FromArgb(22, 22, 22), 0, 0, Width, this.Height / 2);
                DrawBorders(new Pen(Color.FromArgb(50, 50, 50)), 1);
                DrawBorders(Pens.Black, 2);
                DrawBorders(Pens.Black);

                DrawCorners(Color.Black, ClientRectangle);
                DrawText(new SolidBrush(Color.FromArgb(170, 170, 170)), HorizontalAlignment.Center, 1, 1);

            }
        }
    }


}