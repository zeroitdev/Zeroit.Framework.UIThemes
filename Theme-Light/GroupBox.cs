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

namespace Zeroit.Framework.UIThemes.Light
{
    public class LightGroupBox : ThemeContainerControl
    {
        public LightGroupBox()
        {
            AllowTransparent();
        }
        public override void PaintHook()
        {
            G.Clear(Color.FromArgb(199, 199, 199));
            this.BackColor = Color.FromArgb(196, 196, 196);

            HatchBrush hb = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(15, Color.White), Color.Transparent);
            HatchBrush hb2 = new HatchBrush(HatchStyle.BackwardDiagonal, Color.FromArgb(35, Color.White), Color.Transparent);
            G.FillRectangle(new SolidBrush(Color.FromArgb(196, 196, 196)), 0, 0, Width, Height);
            DrawGradient(Color.FromArgb(196, 196, 196), Color.FromArgb(230, 230, 230), 0, 0, Width, 30, 270);
            G.FillRectangle(hb, 1, 1, Width, Height);

            G.DrawRectangle(Pens.LightGray, 1, 1, Width - 3, 30);
            G.DrawRectangle(Pens.LightGray, 1, 1, Width - 3, 32);
            G.DrawRectangle(Pens.Gray, 0, 0, Width, 32);

            G.DrawString(Text, this.Font, new SolidBrush(this.ForeColor), 5, 10);

            DrawBorders(Pens.Gray, Pens.LightGray, ClientRectangle);
            DrawCorners(this.Parent.BackColor, ClientRectangle);
        }
    }

}


