// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Recon
{
    public class ReconButton : ThemeControl
    {
        public ReconButton()
        {
            this.ForeColor = Color.DarkOliveGreen;
        }
        public override void PaintHook()
        {
            switch (MouseState)
            {
                case State.MouseNone:
                    G.Clear(Color.FromArgb(49, 49, 49));
                    DrawGradient(Color.FromArgb(22, 22, 22), Color.FromArgb(34, 34, 34), 1, 1, ClientRectangle.Width, ClientRectangle.Height, 270);
                    DrawBorders(Pens.Black, new Pen(Color.FromArgb(52, 52, 52)), ClientRectangle);
                    DrawText(HorizontalAlignment.Center, this.ForeColor, 0);
                    DrawCorners(this.BackColor, ClientRectangle);
                    break;
                case State.MouseDown:
                    G.Clear(Color.FromArgb(49, 49, 49));
                    DrawGradient(Color.FromArgb(28, 28, 28), Color.FromArgb(38, 38, 38), 1, 1, ClientRectangle.Width, ClientRectangle.Height, 270);
                    DrawGradient(Color.FromArgb(100, 0, 0, 0), Color.Transparent, 1, 1, ClientRectangle.Width, ClientRectangle.Height / 2, 90);
                    DrawBorders(Pens.Black, new Pen(Color.FromArgb(52, 52, 52)), ClientRectangle);
                    DrawText(HorizontalAlignment.Center, this.ForeColor, 1);
                    DrawCorners(this.BackColor, ClientRectangle);
                    break;
                case State.MouseOver:
                    G.Clear(Color.FromArgb(49, 49, 49));
                    DrawGradient(Color.FromArgb(28, 28, 28), Color.FromArgb(38, 38, 38), 1, 1, ClientRectangle.Width, ClientRectangle.Height, 270);
                    DrawGradient(Color.FromArgb(100, 50, 50, 50), Color.Transparent, 1, 1, ClientRectangle.Width, ClientRectangle.Height / 2, 90);
                    DrawBorders(Pens.Black, new Pen(Color.FromArgb(52, 52, 52)), ClientRectangle);
                    DrawText(HorizontalAlignment.Center, this.ForeColor, -1);
                    DrawCorners(this.BackColor, ClientRectangle);
                    break;
            }
            this.Cursor = Cursors.Hand;

        }
    }


}


