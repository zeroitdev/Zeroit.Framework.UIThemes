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
using System;
using System.Drawing.Drawing2D;
using System.Drawing;


namespace Zeroit.Framework.UIThemes.Patrick
{
    public class PatrickButton : ThemeControl151
    {
        protected override void ColorHook()
        {
        }
        private Brush B1;
        protected override void PaintHook()
        {
            HatchBrush hb1 = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(15, 15, 15));
            HatchBrush hb2 = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(35, 35, 35));
            HatchBrush hb3 = new HatchBrush(HatchStyle.Trellis, Color.FromArgb(0, 0, 0));
            B1 = new SolidBrush(Color.FromArgb(50, Color.White));
            G.Clear(BackColor);
            switch (State)
            {
                case MouseState.None:
                    G.FillRectangle(hb1, ClientRectangle);
                    break;
                case MouseState.Over:
                    G.FillRectangle(hb2, ClientRectangle);
                    break;
                case MouseState.Down:
                    G.FillRectangle(hb3, ClientRectangle);
                    break;
            }
            G.DrawString(Text, Font, Brushes.White, new Point(Convert.ToInt32((this.Width / 2) - (Measure(Text).Width / 2)), Convert.ToInt32((this.Height / 2) - (Measure(Text).Height / 2))));
            G.DrawRectangle(Pens.Black, new Rectangle(0, 0, Width - 1, Height - 1));
            DrawCorners(Color.White);
        }
    }

}
