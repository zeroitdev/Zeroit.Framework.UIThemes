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

namespace Zeroit.Framework.UIThemes.V
{
    public class VGroupBox : ThemeContainer154
    {

        public VGroupBox()
        {
            ControlMode = true;
        }


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.Transparent);
            DrawBorders(new Pen(Color.FromArgb(36, 36, 36)), 1);
            DrawBorders(Pens.Black);
            G.DrawLine(new Pen(Color.FromArgb(48, 48, 48)), 1, 1, Width - 2, 1);
            G.FillRectangle(new LinearGradientBrush(new Rectangle(8, 8, Width - 16, Height - 16), Color.FromArgb(12, 12, 12), Color.FromArgb(18, 18, 18), LinearGradientMode.BackwardDiagonal), 8, 8, Width - 16, Height - 16);
            DrawBorders(new Pen(Color.FromArgb(36, 36, 36)), 7);
        }
    }
}




