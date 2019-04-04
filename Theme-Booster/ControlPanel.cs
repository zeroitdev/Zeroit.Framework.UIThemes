// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ControlPanel.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Booster
{
    public class BoosterControlpanel : ThemeContainer154
    {

        public BoosterControlpanel()
        {
            ControlMode = true;
            Transparent = true;
            BackColor = Color.Transparent;
            Header = 20;
        }

        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(51, 51, 51));
            DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(52, 0, 0), 0, 0, Width, 20);

            G.DrawLine(new Pen(Color.FromArgb(92, 92, 92)), 0, 21, Width, 21);
            G.DrawLine(Pens.Black, 0, 20, Width, 20);
            DrawBorders(Pens.Black);

            DrawText(Brushes.White, HorizontalAlignment.Left, 8, 3);

            DrawBorders(new Pen(Color.FromArgb(92, 92, 92)), 1);
        }
    }


}

