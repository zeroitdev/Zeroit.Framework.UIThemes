// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Theme.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Meph
{

    
    enum MouseState : byte
    {
        None = 0,
        Over = 1,
        Down = 2,
        Block = 3
    }
    static class Draw
    {
        public static GraphicsPath RoundRect(Rectangle Rectangle, int Curve)
        {
            GraphicsPath P = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return P;
        }
        public static GraphicsPath RoundRect(int X, int Y, int Width, int Height, int Curve)
        {
            Rectangle Rectangle = new Rectangle(X, Y, Width, Height);
            GraphicsPath P = new GraphicsPath();
            int ArcRectangleWidth = Curve * 2;
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90);
            P.AddLine(new Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
            return P;
        }

        public static void InnerGlow(Graphics G, Rectangle Rectangle, Color[] Colors)
        {
            int SubtractTwo = 1;
            int AddOne = 0;
            foreach (Color c_loopVariable in Colors)
            {
                Color c = c_loopVariable;
                G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(c.R, c.B, c.G))), Rectangle.X + AddOne, Rectangle.Y + AddOne, Rectangle.Width - SubtractTwo, Rectangle.Height - SubtractTwo);
                SubtractTwo += 2;
                AddOne += 1;
            }
        }

        public static void InnerGlowRounded(Graphics G, Rectangle Rectangle, int Degree, Color[] Colors)
        {
            int SubtractTwo = 1;
            int AddOne = 0;
            foreach (Color c_loopVariable in Colors)
            {
                Color c = c_loopVariable;
                G.DrawPath(new Pen(new SolidBrush(Color.FromArgb(c.R, c.B, c.G))), Draw.RoundRect(Rectangle.X + AddOne, Rectangle.Y + AddOne, Rectangle.Width - SubtractTwo, Rectangle.Height - SubtractTwo, Degree));
                SubtractTwo += 2;
                AddOne += 1;
            }
        }


    }

    [ToolboxItem(false)]
    public class MephTheme : ContainerControl
    {

        private string _subHeader;
        public string SubHeader
        {
            get { return _subHeader; }
            set
            {
                _subHeader = value;
                Invalidate();
            }
        }

        private Color _accentColor;
        public Color AccentColor
        {
            get { return _accentColor; }
            set
            {
                _accentColor = value;
                Invalidate();
            }
        }

        public MephTheme()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.FromArgb(28, 28, 28);
            _subHeader = "Insert Sub Header";
            _accentColor = Color.DarkRed;
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;

            Rectangle mainRect = new Rectangle(0, 0, Width, Height);

            base.OnPaint(e);


            G.Clear(Color.Fuchsia);
            //G.SetClip(Draw.RoundRect(New Rectangle(0, 0, Width, Height), 9))

            Color[] c = new Color[] {
            Color.FromArgb(10, 10, 10),
            Color.FromArgb(45, 45, 45),
            Color.FromArgb(40, 40, 40),
            Color.FromArgb(45, 45, 45),
            Color.FromArgb(46, 46, 46),
            Color.FromArgb(47, 47, 47),
            Color.FromArgb(48, 48, 48),
            Color.FromArgb(49, 49, 49),
            Color.FromArgb(50, 50, 50)
        };
            G.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), mainRect);
            Draw.InnerGlow(G, mainRect, c);

            Color[] c2 = new Color[] {
            Color.FromArgb(5, 5, 5),
            Color.FromArgb(40, 40, 40),
            Color.FromArgb(41, 41, 41),
            Color.FromArgb(42, 42, 42),
            Color.FromArgb(43, 43, 43),
            Color.FromArgb(44, 44, 44),
            Color.FromArgb(45, 45, 45)
        };
            G.FillRectangle(new SolidBrush(Color.FromArgb(45, 45, 45)), new Rectangle(0, 35, Width, 23));
            Draw.InnerGlow(G, new Rectangle(0, 35, Width, 23), c2);

            LinearGradientBrush accentGradient = new LinearGradientBrush(new Rectangle(0, 36, 11, 21), _accentColor, Color.FromArgb((_accentColor.R >= 10 ? _accentColor.R - 10 : _accentColor.R + 10), (_accentColor.G >= 10 ? _accentColor.G - 10 : _accentColor.G + 10), (_accentColor.B >= 10 ? _accentColor.B - 10 : _accentColor.B + 10)), 90);
            G.FillRectangle(accentGradient, new Rectangle(0, 36, 11, 21));
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(5, 5, 5))), new Rectangle(0, 35, 11, 22));
            G.FillRectangle(accentGradient, new Rectangle(Width - 12, 36, 11, 21));
            G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(5, 5, 5))), new Rectangle(Width - 12, 35, 11, 22));

            LinearGradientBrush gloss = new LinearGradientBrush(new Rectangle(1, 0, Width - 1, 35 / 2), Color.FromArgb(255, Color.FromArgb(90, 90, 90)), Color.FromArgb(255, 71, 71, 71), 90);
            G.FillRectangle(gloss, new Rectangle(1, 0, Width - 2, 35 / 2));

            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(5, 5, 5))), 0, 0, Width, 0);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(150, 150, 150))), 1, 1, Width - 2, 1);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(85, 85, 85))), 1, 34, Width - 2, 34);
            G.DrawLine(new Pen(new SolidBrush(Color.FromArgb(45, 45, 45))), 1, 58, Width - 2, 58);

            Font drawFont = new Font("Verdana", 10, FontStyle.Regular);
            G.DrawString(Text, drawFont, new SolidBrush(Color.FromArgb(225, 225, 225)), new Rectangle(0, 0, Width, 35), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });

            Font subFont = new Font("Verdana", 8, FontStyle.Regular);
            G.DrawString(_subHeader, subFont, new SolidBrush(Color.FromArgb(225, 225, 225)), new Rectangle(0, 35, Width, 23), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });

            Font controlFont = new Font("Marlett", 10, FontStyle.Regular);
            switch (State)
            {
                case MouseState.None:
                    G.DrawString("r", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-4, -6, Width, 35), new StringFormat
                    {
                        Alignment = StringAlignment.Far,
                        LineAlignment = StringAlignment.Center
                    });
                    G.DrawString("1", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-21, -5, Width, 35), new StringFormat
                    {
                        Alignment = StringAlignment.Far,
                        LineAlignment = StringAlignment.Center
                    });
                    G.DrawString("0", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-38, -6, Width, 35), new StringFormat
                    {
                        Alignment = StringAlignment.Far,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Over:
                    if (X > Width - 18 & X < Width - 10 & Y < 18 & Y > 8)
                    {
                        G.DrawString("r", controlFont, new SolidBrush(Color.FromArgb(255, 255, 255)), new Rectangle(-4, -6, Width, 35), new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        });
                        G.DrawString("1", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-21, -5, Width, 35), new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        });
                        G.DrawString("0", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-38, -6, Width, 35), new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else if (X > Width - 36 & X < Width - 25 & Y < 18 & Y > 8)
                    {
                        G.DrawString("r", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-4, -6, Width, 35), new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        });
                        G.DrawString("1", controlFont, new SolidBrush(Color.FromArgb(255, 255, 255)), new Rectangle(-21, -5, Width, 35), new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        });
                        G.DrawString("0", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-38, -6, Width, 35), new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else if (X > Width - 52 & X < Width - 44 & Y < 18 & Y > 8)
                    {
                        G.DrawString("r", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-4, -6, Width, 35), new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        });
                        G.DrawString("1", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-21, -5, Width, 35), new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        });
                        G.DrawString("0", controlFont, new SolidBrush(Color.FromArgb(255, 255, 255)), new Rectangle(-38, -6, Width, 35), new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        G.DrawString("r", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-4, -6, Width, 35), new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        });
                        G.DrawString("1", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-21, -5, Width, 35), new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        });
                        G.DrawString("0", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-38, -6, Width, 35), new StringFormat
                        {
                            Alignment = StringAlignment.Far,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;
                case MouseState.Down:
                    G.DrawString("r", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-4, -6, Width, 35), new StringFormat
                    {
                        Alignment = StringAlignment.Far,
                        LineAlignment = StringAlignment.Center
                    });
                    G.DrawString("1", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-21, -5, Width, 35), new StringFormat
                    {
                        Alignment = StringAlignment.Far,
                        LineAlignment = StringAlignment.Center
                    });
                    G.DrawString("0", controlFont, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(-38, -6, Width, 35), new StringFormat
                    {
                        Alignment = StringAlignment.Far,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
            }

        }
        private Point MouseP = new Point(0, 0);
        private bool Cap = false;
        private int MoveHeight = 35;
        private int pos = 0;
        MouseState State = MouseState.None;
        int X;
        int Y;
        Rectangle MinBtn = new Rectangle(0, 0, 32, 25);
        Rectangle CloseBtn = new Rectangle(33, 0, 65, 25);
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left & new Rectangle(0, 0, Width, MoveHeight).Contains(e.Location) & X < Width - 53)
            {
                Cap = true;
                MouseP = e.Location;
            }
            else
            {
                if (X > Width - 18 & X < Width - 8 & Y < 18 & Y > 8)
                {
                    Parent.FindForm().Close();
                }
                else if (X > Width - 36 & X < Width - 25 & Y < 18 & Y > 8)
                {
                    if (Parent.FindForm().WindowState == FormWindowState.Maximized)
                    {
                        Parent.FindForm().WindowState = FormWindowState.Normal;
                    }
                    else
                    {
                        Parent.FindForm().WindowState = FormWindowState.Maximized;
                    }
                }
                else if (X > Width - 52 & X < Width - 44 & Y < 18 & Y > 8)
                {
                    Parent.FindForm().WindowState = FormWindowState.Minimized;
                }
            }
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cap = false;
            State = MouseState.Over;
            Invalidate();
        }
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Cap)
            {
                Parent.Location = new Point(MousePosition.X - MouseP.X, MousePosition.Y - MouseP.Y);
            }
            X = e.Location.X;
            Y = e.Location.Y;
            Invalidate();
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.ParentForm.FormBorderStyle = FormBorderStyle.None;
            this.ParentForm.TransparencyKey = Color.Fuchsia;
            Dock = DockStyle.Fill;
        }
    }
    

}


