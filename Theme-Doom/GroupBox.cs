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
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Doom
{

    public class DoomGroupBox : ThemeContainer154
    {

        Pen Border;
        Brush HeaderColor;

        Brush TextColor;
        public DoomGroupBox()
        {
            ControlMode = true;
            SetColor("Border", Color.Black);
            SetColor("Text", Color.Red);
            Font = new Font("Arial", 9);
        }

        protected override void ColorHook()
        {
            Border = GetPen("Border");
            TextColor = GetBrush("Text");
        }

        protected override void PaintHook()
        {
            G.Clear(Color.Black);
            //Group Area
            HatchBrush BackBG = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(20, 20, 20), Color.FromArgb(30, 30, 30));
            G.FillRectangle(BackBG, new Rectangle(0, 22, Width - 1, Height - 23));
            //Text Area
            LinearGradientBrush TopBG = new LinearGradientBrush(new Rectangle(0, 0, 75, 22), Color.FromArgb(20, 20, 20), Color.FromArgb(22, 22, 22), 180f);
            G.FillRectangle(TopBG, new Rectangle(0, 0, 75, 22));
            G.FillRectangle(new SolidBrush(Color.FromArgb(255, 18, 18, 18)), new Rectangle(75, 0, Width - 75, 22));
            //Draw Borders
            G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawRectangle(Border, new Rectangle(0, 0, Width - 1, 22));
            //Text
            G.DrawString(Text, Font, TextColor, new Point(5, 4));
        }
    }


}

