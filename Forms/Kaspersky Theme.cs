// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Kaspersky Theme.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Zeroit.Framework.Form.UIThemes.Kaspersky
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

        class Kaspersky2014CloseButton : Button
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

            private enum MouseState
            {
                None,
                Over,
                Down
            }


            private MouseState state = MouseState.None;
            protected override void OnMouseEnter(EventArgs e)
            {
                state = MouseState.Over;
                base.OnMouseEnter(e);
            }

            protected override void OnMouseLeave(EventArgs e)
            {
                state = MouseState.None;
                base.OnMouseLeave(e);
            }

            protected override void OnMouseDown(MouseEventArgs mevent)
            {
                state = MouseState.Down;
                base.OnMouseDown(mevent);
            }

            protected override void OnMouseUp(MouseEventArgs mevent)
            {
                state = MouseState.Over;
                base.OnMouseUp(mevent);
            }

            protected override void OnClick(EventArgs e)
            {
                base.OnClick(e);
                Environment.Exit(0);
            }


            private Font font = new Font("Marlett", 11f);
            protected override void OnResize(EventArgs e)
            {
                base.OnResize(e);
                this.Region = Region.FromHrgn(CreateRoundRectRgn(-5, -5, this.Width - 1, this.Height - 1, 12, 12));
            }

            protected override void OnPaint(PaintEventArgs pevent)
            {
                Graphics g = pevent.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.White);

                g.FillRectangle(new SolidBrush(Color.FromArgb(160, 46, 37)), this.ClientRectangle);
                g.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)), new Rectangle(0, 0, this.Width, this.Height / 2));

                switch (state)
                {
                    case MouseState.Over:
                        g.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.White)), this.ClientRectangle);
                        break; // TODO: might not be correct. Was : Exit Select


                        break;
                    case MouseState.Down:
                        g.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.Black)), this.ClientRectangle);
                        break; // TODO: might not be correct. Was : Exit Select

                        break;
                }

                TextRenderer.DrawText(g, "r", font, this.ClientRectangle, Color.WhiteSmoke, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

                DrawRoundRect(g, new Pen(Color.DarkRed), -5, -5, this.Width + 2, this.Height + 2, 8);
            }

        }

        class Kaspersky2014MinimizeButton : Button
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

            private enum MouseState
            {
                None,
                Over,
                Down
            }


            private MouseState state = MouseState.None;
            protected override void OnMouseEnter(EventArgs e)
            {
                state = MouseState.Over;
                base.OnMouseEnter(e);
            }

            protected override void OnMouseLeave(EventArgs e)
            {
                state = MouseState.None;
                base.OnMouseLeave(e);
            }

            protected override void OnMouseDown(MouseEventArgs mevent)
            {
                state = MouseState.Down;
                base.OnMouseDown(mevent);
            }

            protected override void OnMouseUp(MouseEventArgs mevent)
            {
                state = MouseState.Over;
                base.OnMouseUp(mevent);
            }

            protected override void OnMouseClick(MouseEventArgs e)
            {
                base.OnMouseClick(e);
                ((System.Windows.Forms.Form)this.Parent).WindowState = FormWindowState.Minimized;
            }


            private Font font = new Font("Marlett", 11f);
            protected override void OnResize(EventArgs e)
            {
                base.OnResize(e);
                this.Region = Region.FromHrgn(CreateRoundRectRgn(1, -5, this.Width + 5, this.Height - 1, 12, 12));
            }

            protected override void OnPaint(PaintEventArgs pevent)
            {
                Graphics g = pevent.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.White);

                g.FillRectangle(new SolidBrush(Color.FromArgb(56, 143, 133)), this.ClientRectangle);
                g.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)), new Rectangle(0, 0, this.Width, this.Height / 2));

                switch (state)
                {
                    case MouseState.Over:
                        g.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.White)), this.ClientRectangle);
                        break; // TODO: might not be correct. Was : Exit Select


                        break;
                    case MouseState.Down:
                        g.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.Black)), this.ClientRectangle);
                        break; // TODO: might not be correct. Was : Exit Select

                        break;
                }

                TextRenderer.DrawText(g, "0", font, this.ClientRectangle, Color.WhiteSmoke, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

                DrawRoundRect(g, new Pen(Color.Teal), 1, -5, this.Width + 5, this.Height + 2, 8);
            }

        }

    }

    


}