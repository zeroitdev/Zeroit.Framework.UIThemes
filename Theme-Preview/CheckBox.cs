// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-18-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Preview
{
    public class PVCheckbox : ThemedControl
    {
        public bool Checked { get; set; }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Checked = !Checked;
            BackColor = Color.FromArgb(21, 23, 25);
        }
        public PVCheckbox() : base()
        {
            Font = new Font("Trebuchet MS", 10.0F);
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            try
            {
                BackColor = this.Parent.BackColor;
            }
            catch (Exception ex)
            {
            }
            Graphics G = e.Graphics;
            base.OnPaint(e);
            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.HighQuality;

            Height = 20;
            Rectangle x = new Rectangle(0, 0, Height - 2, Height - 2);
            Rectangle x2 = new Rectangle(0, 1, Height - 2, Height - 2);
            GraphicsPath y = D.RoundRect(x, 3);
            GraphicsPath y2 = D.RoundRect(x2, 3);

            G.DrawPath(new Pen(Pal.ColHigh), y2);
            G.FillPath(new SolidBrush(Pal.ColDark), y);
            G.DrawPath(new Pen(Color.FromArgb(200, Color.Black)), y);

            if (Checked)
            {
                Rectangle chkPoly = new Rectangle(1 + (Height - 6) / 4, 1 + (Height - 6) / 4, Convert.ToInt32(Math.Truncate((double)(Height - 6) / 2) + 2), Convert.ToInt32(Math.Truncate((double)(Height - 6) / 2) + 4));
                GraphicsPath Poly = new GraphicsPath();
                Poly.AddLine(new Point(chkPoly.X, chkPoly.Y + chkPoly.Height / 2), new Point(chkPoly.X + chkPoly.Width / 2, chkPoly.Y + chkPoly.Height));
                Poly.AddLine(new Point(chkPoly.X + chkPoly.Width / 2, chkPoly.Y + chkPoly.Height), new Point(chkPoly.X + chkPoly.Width, chkPoly.Y - 2));
                G.DrawPath(new Pen(Color.FromArgb(255, Pal.ColHighest), 2F), Poly);
            }

            D.DrawTextWithShadow(G, new Rectangle(Height, 0, Width - Height, Height - 4), Text, Font, HorizontalAlignment.Left, Pal.ColHighest, Color.Black);
        }
    }
}
