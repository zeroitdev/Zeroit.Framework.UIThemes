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

namespace Zeroit.Framework.UIThemes.Classic
{
    public class ClassicButton : ThemeControl151
    {
        private Bloom[] Bloom;
        private LinearGradientBrush L1;
        private Rectangle R1;
        public ClassicButton()
        {
            Bloom = new Bloom[]{
            new Bloom("Border", Color.Black),
            new Bloom("Highlight", Color.FromArgb(35, 35, 35)),
            new Bloom("Background", Color.FromArgb(24, 24, 24)),
            new Bloom("Shadow", Color.FromArgb(100, Color.Black)),
            new Bloom("Text Color", Color.FromArgb(128, Color.White))
        };
            Font = new Font("Verdana", 7f);
            Size = new Size(97, 23);
        }


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.FillRectangle(Bloom[2].Brush, ClientRectangle);
            DrawBorders(Bloom[0].Pen, ClientRectangle);
            DrawBorders(Bloom[1].Pen, 1, 1, Width - 2, Height - 2);
            R1 = new Rectangle(2, 2, Width - 4, Height - 4);
            switch (State)
            {
                case MouseState.Over:
                    L1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(100, 0, 156, 255), Color.Transparent, 270);
                    G.FillRectangle(L1, R1);
                    G.FillRectangle(Bloom[3].Brush, 1, 7, Width - 2, Height - 7);
                    break;
                case MouseState.Down:
                    L1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(50, 0, 156, 255), Color.Transparent, 90);
                    G.FillRectangle(L1, R1);
                    G.FillRectangle(Bloom[3].Brush, 1, 7, Width - 2, Height - 7);
                    break;
                case MouseState.None:
                    G.FillRectangle(Bloom[3].Brush, 1, 8, Width - 2, Height - 8);
                    break;
            }
            DrawText(Bloom[4].Brush, HorizontalAlignment.Center, 0, 0);
        }
    }

}

