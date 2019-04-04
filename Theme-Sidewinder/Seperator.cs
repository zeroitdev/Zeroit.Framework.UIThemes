// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Seperator.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Sidewinder
{
    public class SideWinderSeparator : Control
    {

        #region " Drawing "


        private Graphics G;
        public SideWinderSeparator()
        {
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            G = e.Graphics;
            G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            base.OnPaint(e);

            using (Pen P = new Pen(Color.FromArgb(232, 235, 242)) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
            {
                G.DrawLine(P, new Point(0, 0), new Point(Width, 0));
            }

        }

        #endregion

    }

}