// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ControlYellow.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Light
{
    public class LightControlYellow : ThemeControl
    {
        public LightControlYellow()
        {
            Size = new Size(90, 15);
            MinimumSize = new Size(14, 14);
            MaximumSize = new Size(15, 15);
        }

        public override void PaintHook()
        {

            switch (MouseState)
            {
                case State.MouseNone:
                    DrawGradient(Color.FromArgb(160, 160, 0), Color.FromArgb(162, 154, 18), 0, 0, 15, 15, 90);
                    DrawGradient(Color.FromArgb(162, 154, 18), Color.FromArgb(237, 225, 25), 3, 3, 9, 9, 90);
                    DrawGradient(Color.FromArgb(237, 225, 25), Color.FromArgb(162, 154, 18), 4, 4, 7, 7, 90);
                    DrawBorders(Pens.Gray, Pens.LightGray, new Rectangle(0, 0, 15, 15));
                    break;
                case State.MouseDown:
                    DrawGradient(Color.FromArgb(160, 160, 0), Color.FromArgb(162, 154, 18), 0, 0, 15, 15, 90);
                    DrawGradient(Color.FromArgb(162, 154, 18), Color.FromArgb(237, 225, 25), 3, 3, 9, 9, 90);
                    DrawGradient(Color.FromArgb(237, 225, 25), Color.FromArgb(162, 154, 18), 4, 4, 7, 7, 90);
                    DrawBorders(Pens.Gray, Pens.LightGray, new Rectangle(0, 0, 15, 15));
                    break;
                case State.MouseOver:
                    DrawGradient(Color.FromArgb(160, 160, 0), Color.FromArgb(244, 234, 68), 0, 0, 15, 15, 90);
                    DrawGradient(Color.FromArgb(244, 234, 68), Color.FromArgb(237, 225, 25), 3, 3, 9, 9, 90);
                    DrawGradient(Color.FromArgb(237, 225, 25), Color.FromArgb(244, 234, 68), 4, 4, 7, 7, 90);
                    DrawBorders(Pens.Gray, Pens.LightGray, new Rectangle(0, 0, 15, 15));
                    break;
            }
            this.Cursor = Cursors.Hand;

        }
    }

}


