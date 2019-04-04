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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Purity
{
    public class PurityxSeperator : Control
    {

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            using (Bitmap b = new Bitmap(Width, Height))
            {
                using (Graphics g = Graphics.FromImage(b))
                {
                    g.Clear(BackColor);

                    Color P1 = Color.FromArgb(255, 255, 255);
                    Color P2 = Color.FromArgb(255, 255, 255);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(62, 62, 62)), new Rectangle(0, 0, Width, Height));


                    Rectangle GRec = new Rectangle(0, Height / 2, Width / 5, 2);
                    using (LinearGradientBrush GBrush = new LinearGradientBrush(GRec, Color.Transparent, P2, LinearGradientMode.Horizontal))
                    {
                        g.FillRectangle(GBrush, GRec);
                    }
                    g.DrawLine(new Pen(P2, 2), new Point(GRec.Width, GRec.Y + 1), new Point(Width - GRec.Width + 1, GRec.Y + 1));

                    GRec = new Rectangle(Width - (Width / 5), Height / 2, Width / 5, 2);
                    using (LinearGradientBrush GBrush = new LinearGradientBrush(GRec, P2, Color.Transparent, LinearGradientMode.Horizontal))
                    {
                        g.FillRectangle(GBrush, GRec);
                    }
                    e.Graphics.DrawImage(b, 0, 0);
                }
            }
            base.OnPaint(e);
        }
    }

}

