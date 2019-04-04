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
using System.Drawing.Drawing2D;

using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Perplex
{

    public class PerplexGroupBox : ContainerControl
    {

        public PerplexGroupBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle Body = new Rectangle(4, 25, Width - 9, Height - 30);
            Rectangle Body2 = new Rectangle(0, 0, Width - 1, Height - 1);

            base.OnPaint(e);

            G.Clear(Color.Transparent);

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.CompositingQuality = CompositingQuality.HighQuality;

            Pen p = new Pen(Color.Black);
            LinearGradientBrush BodyBrush = new LinearGradientBrush(Body2, Color.FromArgb(26, 26, 26), Color.FromArgb(30, 30, 30), 90);
            G.FillPath(BodyBrush, Draw.RoundRect(Body2, 3));
            G.DrawPath(new Pen(Brushes.Black), Draw.RoundRect(Body2, 3));

            LinearGradientBrush BodyBrush2 = new LinearGradientBrush(Body, Color.FromArgb(46, 46, 46), Color.FromArgb(50, 55, 58), 120);
            G.FillPath(BodyBrush2, Draw.RoundRect(Body, 3));
            G.DrawPath(p, Draw.RoundRect(Body, 3));

            Font drawFont = new Font("Tahoma", 9, FontStyle.Bold);
            G.DrawString(Text, drawFont, new SolidBrush(Color.WhiteSmoke), 67, 14, new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }


    }

}


