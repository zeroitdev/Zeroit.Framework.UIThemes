// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="BlockQuote.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Sidewinder
{
    public class SideWinderBlockQuote : Control
    {

        #region " Drawing "


        private Graphics G;
        public string Title { get; set; }

        public string Description { get; set; }

        public SideWinderBlockQuote()
        {
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            G = e.Graphics;
            G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            base.OnPaint(e);

            using (Pen P = new Pen(Color.FromArgb(102, 105, 112), 3))
            {
                G.DrawLine(P, new Point(3, 0), new Point(3, Height));
            }

            if (!string.IsNullOrEmpty(Title))
            {
                using (SolidBrush B = new SolidBrush(Color.FromArgb(112, 115, 122)))
                {
                    G.DrawString(Title.ToUpper(), new Font("Segoe UI semibold", 11), B, new Point(13, 0));
                }
            }

            using (SolidBrush B = new SolidBrush(Color.FromArgb(92, 95, 112)))
            {
                G.DrawString(Description, new Font("Segoe UI", 10), B, new Point(13, 23));
            }

        }

        #endregion

    }

}