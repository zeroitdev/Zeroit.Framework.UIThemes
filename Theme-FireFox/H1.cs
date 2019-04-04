// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="H1.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.FireFox
{
    public class FirefoxH1 : Label
    {

        #region " Private "
        #endregion
        private Graphics G;

        #region " Control "

        public FirefoxH1()
        {
            DoubleBuffered = true;
            AutoSize = false;
            Font = new Font("Segoe UI Semibold", 20);
            ForeColor = Color.FromArgb(76, 88, 100);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            base.OnPaint(e);

            using (Pen P = new Pen(Helpers.GreyColor(200)))
            {
                G.DrawLine(P, new Point(0, 50), new Point(Width, 50));
            }

        }

        #endregion

    }


}


