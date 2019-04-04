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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Reactor
{
    public class ReactorGroupBox : ContainerControl
    {

        #region " Control Help - Properties & Flicker Control"
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        #endregion

        public ReactorGroupBox()
            : base()
        {
            BackColor = Color.FromArgb(33, 33, 33);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;

            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.HighQuality;

            LinearGradientBrush DrawGradientBrush2 = new LinearGradientBrush(new Rectangle(0, 0, Width, 24), Color.FromArgb(10, 10, 10), Color.FromArgb(50, 50, 50), 90);

            G.FillRectangle(DrawGradientBrush2, new Rectangle(0, 0, Width, 24));
            LinearGradientBrush gloss = new LinearGradientBrush(new Rectangle(0, 0, Width, 12), Color.FromArgb(60, Color.White), Color.FromArgb(20, Color.White), 90);
            G.FillRectangle(gloss, new Rectangle(0, 0, Width, 12));
            G.DrawLine(Pens.Black, 0, 24, Width, 24);

            G.DrawRectangle((new Pen(new SolidBrush(Color.Black))), new Rectangle(1, 1, Width - 3, Height - 3));
            G.DrawRectangle((new Pen(new SolidBrush(Color.FromArgb(70, 70, 70)))), new Rectangle(0, 0, Width - 1, Height - 1));
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, Width, 0);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 0, 0, 0, Height);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), Width - 1, 0, Width - 1, Height);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(31, 31, 31))), 2, 2, Width - 3, 2);

            G.DrawString(Text, Font, Brushes.Black, Width / 2 - (3 * Text.Length) + 1, 6);
            G.DrawString(Text, Font, Brushes.White, Width / 2 - (3 * Text.Length) + 1, 7);
        }


    }

}


