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

namespace Zeroit.Framework.UIThemes.SpicyLips
{

    public class BlackGroupBox : ThemeContainer154
    {
        public BlackGroupBox()
        {
            ControlMode = true;
            BackColor = Color.FromArgb(20, 20, 20);
        }

        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(26, 26, 26));

            HatchBrush T = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(9, 9, 9), Color.FromArgb(15, 15, 15));
            G.FillRectangle(T, ClientRectangle);
            G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)), ClientRectangle);
            DrawText(Brushes.White, HorizontalAlignment.Center, -1, -1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(22, 22, 22)), 10, 20, Width - 21, Height);
            DrawBorders(new Pen(Color.FromArgb(7, 7, 7)), 0, 0, Width, Height);
            DrawCorners(Color.FromArgb(22, 22, 22), ClientRectangle);
            DrawBorders(Pens.Black, 10, 20, Width - 21, Height);
        }
    }

}