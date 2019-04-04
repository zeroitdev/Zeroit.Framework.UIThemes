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

namespace Zeroit.Framework.UIThemes.Twitch
{
    public class TwitchGroupBox : ThemeContainer154
    {

        public TwitchGroupBox()
        {
            ControlMode = true;
            Cursor = Cursors.Default;
            Size sw = new Size(129, 23);
            Size = sw;
        }


        protected override void ColorHook()
        {
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            G.FillRectangle(new SolidBrush(Color.FromArgb(44, 44, 44)), new Rectangle(0, 0, Width, Height));
            G.FillRectangle(new SolidBrush(Color.FromArgb(25, 25, 25)), new Rectangle(0, 0, Width, 26));
            G.DrawLine(Pens.Black, 0, 26, Width, 26);
            G.DrawRectangle(Pens.Black, new Rectangle(0, 0, Width - 1, Height - 1));
            DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
        }
    }
}

