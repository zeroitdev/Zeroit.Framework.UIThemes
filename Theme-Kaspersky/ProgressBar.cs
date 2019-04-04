// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Kaspersky
{
    public class Kaspersky2014ProgressBar : Button
    {

        // x-coordinate of upper-left corner
        // y-coordinate of upper-left corner
        // x-coordinate of lower-right corner
        // y-coordinate of lower-right corner
        // height of ellipse
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        // width of ellipse

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



        private float m_maximum = 100f;
        public float Maximum
        {
            get { return m_maximum; }
            set
            {
                m_maximum = value;
                this.Invalidate();
            }
        }

        private float mValue = 0f;
        public float Value
        {
            get { return mValue; }
            set
            {
                mValue = value;
                this.Invalidate();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width - 1, this.Height - 1, 3, 3));
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.Clear(Color.White);


            int progressWidth = Convert.ToInt32(Math.Truncate((mValue / m_maximum) * this.Width));

            Rectangle progressRect = new Rectangle(0, 0, progressWidth, this.Height);

            if (mValue > 0)
            {
                LinearGradientBrush pbg = new LinearGradientBrush(progressRect, Color.FromArgb(2, 158, 131), Color.FromArgb(4, 129, 107), LinearGradientMode.Vertical);

                g.FillRectangle(pbg, new Rectangle(0, 0, progressWidth, this.Height));
            }
            RectangleF r1 = new RectangleF(1, 1, this.Width - 2, this.Height - 4);
            r1.Width = Convert.ToSingle(r1.Width * mValue / m_maximum);
            Region reg1 = new Region(r1);
            Region reg2 = new Region(this.ClientRectangle);
            reg2.Exclude(reg1);

            SizeF textSize = g.MeasureString(this.Text, this.Font);

            float y = (this.ClientRectangle.Height - textSize.Height) / 2;

            g.Clip = reg1;
            g.DrawString(this.Text, this.Font, Brushes.WhiteSmoke, 10, y);
            g.Clip = reg2;
            g.DrawString(this.Text, this.Font, Brushes.Gray, 10, y);

            reg1.Dispose();
            reg2.Dispose();

            DrawRoundRect(g, Pens.Gray, 0, 0, this.Width - 3, this.Height - 3, 3);
        }

    }
}