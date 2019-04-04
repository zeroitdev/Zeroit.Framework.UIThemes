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

namespace Zeroit.Framework.UIThemes.Newer
{
    public class ImagineGroupBox : ThemeContainer154
    {
        Color Border;
        Color BG;
        Color Edge;
        public ImagineGroupBox()
        {
            ControlMode = true;
            SetColor("BG", 13, 13, 13);
            SetColor("Border", 12, 27, 74);
            SetColor("Edges", Color.FromArgb(170, 170, 170));
            BackColor = GetColor("BG");
            MinimumSize = new Size(158, 33);
            Font = new Font("Segoe UI", 9);
        }
        protected override void ColorHook()
        {
            Border = GetColor("Border");
            BG = GetColor("BG");
            Edge = GetColor("Edges");
        }

        protected override void PaintHook()
        {
            G.Clear(Border);
            HatchBrush HB = new HatchBrush(HatchStyle.BackwardDiagonal, Color.FromArgb(25, Color.White), Color.Transparent);
            G.FillRectangle(new SolidBrush(BackColor), new Rectangle(6, 26, Width - 13, Height - 33));
            G.FillRectangle(HB, new Rectangle(6, 26, Width - 13, Height - 33));
            G.DrawLine(Pens.Black, 6, 26, Width - 8, 26);
            G.DrawLine(Pens.Black, Width - 8, Height - 8, Width - 8, 26);
            G.DrawLine(Pens.Black, 6, Height - 8, 6, 26);
            G.DrawLine(Pens.Black, 6, Height - 8, Width - 8, Height - 8);
            G.DrawString(Text, Font, Brushes.White, new Point(5, 5));
            DrawBorders(Pens.Black);
        }
    }

}

