// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="StatusBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.VibeLander
{
    public class VibeStatusBar : ThemeControl
    {
        public VibeStatusBar()
        {
            this.Dock = DockStyle.Bottom;
            this.Size = new Size(Width, 20);
        }
        public override void PaintHook()
        {
            this.Font = new Font("Arial", 10);
            G.Clear(this.BackColor);
            G.SmoothingMode = SmoothingMode.HighQuality;

            switch (MouseState)
            {
                case State.MouseNone:
                    DrawGradient(Color.FromArgb(20, 82, 179), Color.FromArgb(58, 110, 195), 0, 0, Width, Height, 270);
                    G.DrawRectangle(new Pen(Color.FromArgb(12, 69, 180)), 0, 0, Width - 1, Height - 1);
                    DrawText(HorizontalAlignment.Left, Color.FromArgb(240, 240, 240), +1);
                    break;
                case State.MouseDown:
                    DrawGradient(Color.FromArgb(19, 75, 172), Color.FromArgb(70, 110, 198), 0, 0, Width, Height, 270);
                    G.DrawRectangle(new Pen(Color.FromArgb(12, 69, 180)), 0, 0, Width - 1, Height - 1);
                    DrawText(HorizontalAlignment.Left, Color.FromArgb(232, 232, 232), +1);
                    break;
                case State.MouseOver:
                    DrawGradient(Color.FromArgb(21, 79, 177), Color.FromArgb(76, 128, 218), 0, 0, Width, Height, 270);
                    G.DrawRectangle(new Pen(Color.FromArgb(12, 69, 180)), 0, 0, Width - 1, Height - 1);
                    DrawText(HorizontalAlignment.Left, Color.FromArgb(250, 250, 250), +1);
                    break;
            }
            G.DrawLine(new Pen(Color.FromArgb(50, 255, 255, 255)), 1, 1, Width - 3, 1);

        }
    }
}

