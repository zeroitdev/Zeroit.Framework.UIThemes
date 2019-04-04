// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Kaspersky
{
    public class Kaspersky2014CheckBox : Button
    {

        public void DrawRoundRect(Graphics g, Pen p, float X, float Y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(X + radius, Y, X + width - (radius * 2), Y);
            gp.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
            gp.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
            gp.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            gp.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
            gp.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            gp.AddLine(X, Y + height - (radius * 2), X, Y + radius);
            gp.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
            g.DrawPath(p, gp);
            gp.Dispose();
        }

        private bool mChecked = false;
        public bool Checked
        {
            get { return mChecked; }
            set
            {
                mChecked = value;
                this.Invalidate();
            }
        }

        protected override void OnClick(EventArgs e)
        {
            this.Checked = !this.Checked;
            base.OnClick(e);
        }


        private Font font = new Font("Marlett", 15f);
        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.Clear(this.BackColor);

            DrawRoundRect(g, new Pen(Color.FromArgb(172, 182, 181)), 0, 0, 17, 17, 3);

            switch (mChecked)
            {
                case true:
                    g.DrawString("b", font, Brushes.DarkSlateGray, new PointF(-2, -1));
                    break; // TODO: might not be correct. Was : Exit Select

                    break;
            }

            g.DrawString(this.Text, this.font, Brushes.Black, new PointF(20, 2));
        }

    }

}