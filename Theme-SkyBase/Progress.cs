// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Progress.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.SkyLimit
{
    public class SkyDarkProgress : Control
    {

        #region "Properties"
        private int val;
        public int Value
        {
            get { return val; }
            set
            {
                if (value > max)
                {
                    val = max;
                }
                else if (value < 0)
                {
                    val = 0;
                }
                else
                {
                    val = value;
                }
                Invalidate();
            }
        }
        private int max;
        public int Maximum
        {
            get { return max; }
            set
            {
                if (value < 1)
                {
                    max = 1;
                }
                else
                {
                    max = value;
                }

                if (value < val)
                {
                    val = max;
                }

                Invalidate();
            }
        }
        #endregion
        Color C1 = Color.FromArgb(51, 49, 47);
        Color C2 = Color.FromArgb(81, 77, 77);
        Color C3 = Color.FromArgb(64, 60, 59);
        Color C4 = Color.FromArgb(70, 71, 70);

        Color C5 = Color.FromArgb(62, 59, 58);
        public SkyDarkProgress()
        {
            max = 100;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle Fill = new Rectangle(3, 3, Convert.ToInt32((Width - 7) * (val / max)), Height - 7);

            G.Clear(C5);

            LinearGradientBrush G1 = new LinearGradientBrush(new Point(0, 0), new Point(0, Height), C3, C4);
            G.FillRectangle(G1, Fill);
            G1.Dispose();
            G.DrawRectangle(ConversionFunctions.ToPen(C2), Fill);

            G.DrawRectangle(ConversionFunctions.ToPen(C1), 0, 0, Width - 1, Height - 1);
            G.DrawRectangle(ConversionFunctions.ToPen(C2), 1, 1, Width - 3, Height - 3);

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }
}