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

namespace Zeroit.Framework.UIThemes.Recon
{
    public class ReconGroupBox : ThemeContainerControl
    {
        public ReconGroupBox()
        {
            AllowTransparent();
        }
        public override void PaintHook()
        {
            G.Clear(Color.FromArgb(25, 25, 25));
            this.BackColor = Color.FromArgb(25, 25, 25);
            DrawGradient(Color.FromArgb(11, 11, 11), Color.FromArgb(26, 26, 26), 1, 1, ClientRectangle.Width, ClientRectangle.Height, 270);
            DrawBorders(Pens.Black, new Pen(Color.FromArgb(52, 52, 52)), ClientRectangle);

            DrawGradient(Color.FromArgb(150, 32, 32, 32), Color.FromArgb(150, 31, 31, 31), 5, 23, Width - 10, Height - 28, 90);
            G.DrawRectangle(new Pen(Color.FromArgb(130, 13, 13, 13)), 5, 23, Width - 10, Height - 28);

            G.DrawString(Text, Font, new SolidBrush(this.ForeColor), 4, 6);

            DrawCorners(Color.Transparent, ClientRectangle);
        }
    }

}


