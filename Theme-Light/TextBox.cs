// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="TextBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Light
{
    public class LightTextBox : TextBox
    {

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 15:
                    Invalidate();
                    base.WndProc(ref m);
                    this.CustomPaint();
                    break; // TODO: might not be correct. Was : Exit Select

                    break;
                default:
                    base.WndProc(ref m);
                    break; // TODO: might not be correct. Was : Exit Select

                    break;
            }
        }

        public LightTextBox()
        {
            Font = new Font("Microsoft Sans Serif", 8);
            ForeColor = Color.Black;
            BackColor = Color.FromArgb(230, 230, 230);
            BorderStyle = BorderStyle.FixedSingle;
        }

        private void CustomPaint()
        {
            Pen p = new Pen(Color.Gray);
            CreateGraphics().DrawLine(p, 0, 0, Width, 0);
            CreateGraphics().DrawLine(p, 0, Height - 1, Width, Height - 1);
            CreateGraphics().DrawLine(p, 0, 0, 0, Height - 1);
            CreateGraphics().DrawLine(p, Width - 1, 0, Width - 1, Height - 1);
        }
    }
}


