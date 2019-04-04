// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TopButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Zeus
{
    public class ZeusTopButton : ThemeControl
    {


        #region " Options "

        public ZeusTopButton()
        {
            this.Size = new Size(15, 15);
            this.MinimumSize = new Size(15, 15);
            this.Text = "X";
        }

        #endregion

        #region " PaintHook "


        public override void PaintHook()
        {
            Brush B1 = Brushes.Black;
            Brush B2 = Brushes.LightCyan;
            Brush B3 = Brushes.AliceBlue;
            Color C1 = Color.FromArgb(45, 45, 45);
            Color C2 = Color.FromArgb(150, 255, 255);
            Color C3 = Color.AliceBlue;
            Pen P1 = Pens.Black;
            Pen P2 = Pens.LightCyan;
            Pen P3 = Pens.AliceBlue;


            G.Clear(C1);

            switch (MouseState)
            {
                case State.MouseNone:
                    G.DrawEllipse(P3, 0, 0, Width - 1, Height - 1);
                    this.Font = new Font("Cambria", 8, FontStyle.Bold);
                    DrawText(HorizontalAlignment.Center, C3, 0);
                    break;
                case State.MouseOver:
                    G.DrawEllipse(P3, 0, 0, Width - 1, Height - 1);
                    this.Font = new Font("Cambria", 8, FontStyle.Bold);
                    DrawText(HorizontalAlignment.Center, C3, 0);
                    break;
                case State.MouseDown:
                    G.DrawEllipse(P3, 1, 1, Width - 3, Height - 3);
                    this.Font = new Font("Cambria", 6, FontStyle.Bold);
                    DrawText(HorizontalAlignment.Center, C3, 0);
                    break;
            }



        }

        #endregion

    }

}


