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
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.SubSpace
{
    public class Subspacegroupbox : ThemeContainer154
    {
        public Subspacegroupbox()
        {
            ControlMode = true;
            Header = 18;
        }

        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(30, 30, 30));
            DrawBorders(Pens.Black);


            G.FillRectangle(Brushes.Black, 2, 2, Width - 4, 18);
            G.DrawLine(new Pen(Color.FromArgb(60, 60, 60)), 2, 18, Width - 2, 18);
            G.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.White)), 2, 2, Width - 4, 7);

            DrawGradient(Color.Black, Color.FromArgb(30, 30, 30), 2, 19, Width - 4, 8);


            DrawGradient(Color.FromArgb(30, 30, 30), Color.Black, 7, Height - 16, Width - 14, 8);

            DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(57, 57, 58), 0, Height - 8, Width / 2, Height - 4, 360);
            DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(57, 57, 58), Width / 2, Height - 8, Width / 2, Height - 4, 180);
            G.DrawLine(new Pen(Color.FromArgb(57, 57, 58)), Width / 2, Height - 8, Width / 2, Height);

            DrawText(Brushes.DodgerBlue, HorizontalAlignment.Left, 8, 1);

            //SideBoxes
            G.FillRectangle(Brushes.Black, 2, 19, 5, Height - 4);
            G.DrawLine(new Pen(Color.FromArgb(60, 60, 60)), 5, 19, 5, Height - 2);

            G.FillRectangle(Brushes.Black, Width - 6, 19, 10, Height - 4);
            G.DrawLine(new Pen(Color.FromArgb(60, 60, 60)), Width - 6, 19, Width - 6, Height - 2);
            //EndofSideboxes

            DrawBorders(new Pen(Color.FromArgb(60, 60, 60)), 1);
        }
    }

}




