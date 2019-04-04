// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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

namespace Zeroit.Framework.UIThemes.Drone
{
    public class DroneGroupBox : ThemeContainer153
    {

        public DroneGroupBox()
        {
            ControlMode = true;
            Header = 26;
        }


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(24, 24, 24));

            DrawGradient(Color.FromArgb(0, 55, 90), Color.FromArgb(0, 70, 128), 5, 5, Width - 10, 26);
            G.DrawLine(new Pen(Color.FromArgb(20, Color.White)), 7, 7, Width - 8, 7);

            DrawBorders(Pens.Black, 5, 5, Width - 10, 26, 1);
            DrawBorders(new Pen(Color.FromArgb(36, 36, 36)), 5, 5, Width - 10, 26);

            //???
            DrawBorders(new Pen(Color.FromArgb(8, 8, 8)), 5, 34, Width - 10, Height - 39, 1);
            DrawBorders(new Pen(Color.FromArgb(36, 36, 36)), 5, 34, Width - 10, Height - 39);

            DrawBorders(new Pen(Color.FromArgb(36, 36, 36)), 1);
            DrawBorders(Pens.Black);

            G.DrawLine(new Pen(Color.FromArgb(48, 48, 48)), 1, 1, Width - 2, 1);

            DrawText(Brushes.White, HorizontalAlignment.Left, 9, 5);
        }
    }


}


