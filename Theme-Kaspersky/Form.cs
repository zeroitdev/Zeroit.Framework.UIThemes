// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Form.cs" company="Zeroit Dev Technologies">
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
    public class Kaspersky2014Form : System.Windows.Forms.Form
    {

        protected const int WM_NCLBUTTONDOWN = 0xa1;

        protected const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]

        public static extern bool ReleaseCapture();

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private Kaspersky2014CloseButton closeButton;

        private Kaspersky2014MinimizeButton minimizeButton;
        public Kaspersky2014Form()
        {
            this.FormBorderStyle = FormBorderStyle.None;

            closeButton = new Kaspersky2014CloseButton();
            minimizeButton = new Kaspersky2014MinimizeButton();

            closeButton.Size = new Size(40, 23);
            minimizeButton.Size = new Size(32, 23);

            closeButton.Left = (this.Width - closeButton.Width) - 15;
            minimizeButton.Left = closeButton.Left - minimizeButton.Width;

            closeButton.Top = border + 1;
            minimizeButton.Top = border + 1;

            this.Controls.Add(closeButton);
            this.Controls.Add(minimizeButton);
        }

        private int m_headerHeight = 80;
        public int HeaderHeight
        {
            get { return m_headerHeight; }
            set
            {
                m_headerHeight = value;
                this.Invalidate();
            }
        }

        private int m_footerHeight = 50;
        public int FooterHeight
        {
            get { return m_footerHeight; }
            set
            {
                m_footerHeight = value;
                this.Invalidate();
            }
        }

        private string m_headerText;
        public string HeaderText
        {
            get { return m_headerText; }
            set
            {
                m_headerText = value;
                this.Invalidate();
            }
        }

        private Font m_headerFont = new Font("Tahoma", 12f);
        public Font HeaderFont
        {
            get { return m_headerFont; }
            set
            {
                m_headerFont = value;
                this.Invalidate();
            }
        }

        private bool m_showDropShadow = true;
        public bool ShowDropShadow
        {
            get { return m_showDropShadow; }
            set
            {
                m_showDropShadow = value;
                this.Invalidate();
            }
        }

        private int border = 4;

        private int dropShadowHeight = 25;
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            closeButton.Left = (this.Width - closeButton.Width) - 15;
            minimizeButton.Left = closeButton.Left - minimizeButton.Width;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            LinearGradientBrush bg = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(138, 157, 158), Color.FromArgb(58, 63, 66), LinearGradientMode.Vertical);

            g.FillRectangle(bg, this.ClientRectangle);

            Rectangle headerRectangle = new Rectangle(border, border, this.Width - (border * 2), m_headerHeight);

            HatchBrush hbg = new HatchBrush(HatchStyle.DashedHorizontal, Color.FromArgb(50, 171, 157), Color.FromArgb(43, 163, 147));
            g.FillRectangle(hbg, headerRectangle);

            LinearGradientBrush grad = new LinearGradientBrush(headerRectangle, Color.FromArgb(20, Color.White), Color.FromArgb(120, Color.Black), LinearGradientMode.Vertical);
            g.FillRectangle(grad, headerRectangle);

            SizeF sz = g.MeasureString(m_headerText, this.Font);

            g.DrawString(m_headerText, m_headerFont, Brushes.WhiteSmoke, new PointF(30, (headerRectangle.Height - sz.Height) / 2));

            g.DrawRectangle(new Pen(Color.FromArgb(80, Color.Black)), headerRectangle);

            Rectangle contentRectangle = new Rectangle(border, m_headerHeight, this.Width - (border * 2), ((this.Height - m_headerHeight) - (border)) - m_footerHeight);

            g.FillRectangle(Brushes.WhiteSmoke, contentRectangle);

            if (m_showDropShadow)
            {
                Rectangle shadowRectangle = new Rectangle(contentRectangle.X, contentRectangle.Y, contentRectangle.Width, dropShadowHeight);

                LinearGradientBrush sbg = new LinearGradientBrush(shadowRectangle, Color.FromArgb(120, 50, 171, 157), Color.WhiteSmoke, LinearGradientMode.Vertical);
                g.FillRectangle(sbg, shadowRectangle);
            }

            Rectangle footerRectangle = new Rectangle(border, (this.Height - border) - m_footerHeight, this.Width - (border * 2), m_footerHeight);

            LinearGradientBrush fbg = new LinearGradientBrush(footerRectangle, Color.FromArgb(54, 57, 62), Color.FromArgb(44, 47, 52), LinearGradientMode.Vertical);

            g.FillRectangle(fbg, footerRectangle);

            g.DrawRectangle(Pens.Black, footerRectangle);

            g.DrawRectangle(new Pen(Color.FromArgb(180, Color.Black)), contentRectangle);
        }

    }

}