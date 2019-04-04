// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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

namespace Zeroit.Framework.UIThemes.Recon
{
    public class ReconTxtBox : TextBox
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

        public ReconTxtBox()
        {
            Font = new Font("Microsoft Sans Serif", 8);
            ForeColor = Color.Black;
            BackColor = Color.FromArgb(28, 28, 28);
            BorderStyle = BorderStyle.FixedSingle;
        }

        private void CustomPaint()
        {
            Pen p = new Pen(Color.Black);
            Pen o = new Pen(Color.FromArgb(45, 45, 45));
            CreateGraphics().DrawLine(p, 0, 0, Width, 0);
            CreateGraphics().DrawLine(p, 0, Height - 1, Width, Height - 1);
            CreateGraphics().DrawLine(p, 0, 0, 0, Height - 1);
            CreateGraphics().DrawLine(p, Width - 1, 0, Width - 1, Height - 1);

            CreateGraphics().DrawLine(o, 1, 1, Width - 2, 1);
            CreateGraphics().DrawLine(o, 1, Height - 2, Width - 2, Height - 2);
            CreateGraphics().DrawLine(o, 1, 1, 1, Height - 2);
            CreateGraphics().DrawLine(o, Width - 2, 1, Width - 2, Height - 2);
        }
    }

}


