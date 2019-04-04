// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Influence
{
    public class InfluenceGroupBox : ContainerControl
    {
        #region " Control Help - Properties & Flicker Control"
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        #endregion

        public InfluenceGroupBox()
            : base()
        {
            Size = new Size(200, 100);
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            G.SmoothingMode = SmoothingMode.HighSpeed;
            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
            Color TransparencyKey = this.ParentForm.TransparencyKey;
            Draw d = new Draw();
            base.OnPaint(e);

            G.Clear(BackColor);

            G.FillPath(new SolidBrush(Color.FromArgb(20, 20, 20)), d.RoundRect(ClientRectangle, 2));


            HatchBrush h1 = new HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(100, 31, 31, 31), Color.FromArgb(100, 36, 36, 36));
            LinearGradientBrush g1 = new LinearGradientBrush(new Rectangle(0, 2, Width - 1, 25), Color.FromArgb(40, 40, 40), Color.FromArgb(29, 29, 29), 90);

            G.FillPath(g1, d.RoundRect(new Rectangle(0, 2, Width - 1, 25), 2));
            G.FillPath(h1, d.RoundRect(new Rectangle(0, 2, Width - 1, 25), 2));

            LinearGradientBrush s1 = new LinearGradientBrush(g1.Rectangle, Color.FromArgb(15, Color.White), Color.FromArgb(0, Color.White), 90);
            G.FillRectangle(s1, new Rectangle(1, 1, Width - 1, 13));

            G.DrawLine(new Pen(Color.FromArgb(75, Color.White)), 1, 1, Width - 1, 1);

            G.DrawLine(new Pen(Color.FromArgb(18, 18, 18)), 1, 26, Width - 1, 26);

            G.DrawRectangle(new Pen(Color.FromArgb(37, 37, 37)), new Rectangle(1, 27, Width - 3, Height - 29));

            G.DrawPath(Pens.Black, d.RoundRect(ClientRectangle, 2));

            G.DrawString(Text, Font, Brushes.Black, new Rectangle(8, 8, Width - 1, 10), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Near
            });
            G.DrawString(Text, Font, Brushes.White, new Rectangle(8, 9, Width - 1, 11), new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Near
            });

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }


}

