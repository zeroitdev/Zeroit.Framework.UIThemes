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


using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Fetus
{
    public class YoutubeButton : ThemeControl
    {
        private Pen P1;
        private Pen P2;
        private Pen P11;
        private Pen P12;
        public override void PaintHook()
        {
            P1 = new Pen(Color.FromArgb(225, 225, 225));
            P2 = new Pen(Color.FromArgb(205, 205, 205));
            P11 = new Pen(Color.FromArgb(225, 225, 225));
            P12 = new Pen(Color.FromArgb(200, 200, 200));
            Color gradient1 = Color.FromArgb(243, 243, 243);
            Color gradient2 = Color.FromArgb(245, 245, 245);
            Color gradient11 = Color.FromArgb(245, 245, 245);
            Color gradient12 = Color.FromArgb(247, 247, 247);

            G.Clear(Color.FromArgb(240, 240, 240));
            DrawGradient(Color.FromArgb(250, 250, 250), Color.FromArgb(247, 248, 248), 0, 0, Width, 3, 90);
            DrawGradient(Color.FromArgb(248, 248, 248), Color.FromArgb(0, 0, 0), 0, 0, Width, 275, 90);
            DrawBorders(P11, P12, ClientRectangle);

            switch (MouseState)
            {

                case State.MouseOver:
                    DrawGradient(Color.FromArgb(250, 250, 250), Color.FromArgb(247, 248, 248), 0, 0, Width, 20, 90);
                    DrawGradient(Color.FromArgb(248, 248, 248), Color.FromArgb(0, 0, 0), 0, 0, Width, 250, 90);
                    DrawBorders(P2, P11, ClientRectangle);
                    DrawText(HorizontalAlignment.Center, Color.Red, 0);

                    break;
                case State.MouseDown:
                    Rectangle _Rectangle = new Rectangle(0, -3, Width, Height / 2);
                    LinearGradientBrush _Gradient = new LinearGradientBrush(_Rectangle, Color.FromArgb(238, 238, 238), Color.FromArgb(240, 240, 240), 90);
                    G.FillRectangle(_Gradient, _Rectangle);
                    DrawBorders(new Pen(Color.FromArgb(240, 240, 240)), new Pen(Color.FromArgb(190, 190, 190)), ClientRectangle);
                    DrawText(HorizontalAlignment.Center, Color.Gray, 0);

                    break;
            }



            DrawCorners(Color.FromArgb(240, 240, 240), ClientRectangle);
            DrawText(HorizontalAlignment.Center, Color.Gray, 0);
        }
    }


}

