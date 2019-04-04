// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ControlBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Evolve
{

    public class EvolveControlBox : ThemeControl154
    {
        private bool _Min = true;
        private bool _Max = true;

        private int X;
        protected override void ColorHook()
        {
        }

        public bool MinButton
        {
            get { return _Min; }
            set
            {
                _Min = value;
                int tempwidth = 40;
                if (_Min)
                    tempwidth += 25;
                if (_Max)
                    tempwidth += 25;
                this.Width = tempwidth + 1;
                this.Height = 16;
                Invalidate();
            }
        }

        public bool MaxButton
        {
            get { return _Max; }
            set
            {
                _Max = value;
                int tempwidth = 40;
                if (_Min)
                    tempwidth += 25;
                if (_Max)
                    tempwidth += 25;
                this.Width = tempwidth + 1;
                this.Height = 16;
                Invalidate();
            }
        }

        public EvolveControlBox()
        {
            Size = new Size(92, 16);
            Location = new Point(50, 2);
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.Location.X;
            Invalidate();
        }

        protected override void OnClick(System.EventArgs e)
        {
            base.OnClick(e);
            if (_Min & _Max)
            {
                if (X > 0 & X < 25)
                {
                    Parent.FindForm().WindowState = FormWindowState.Minimized;
                }
                else if (X > 25 & X < 50)
                {
                    if (Parent.FindForm().WindowState == FormWindowState.Maximized)
                        Parent.FindForm().WindowState = FormWindowState.Normal;
                    else
                        Parent.FindForm().WindowState = FormWindowState.Maximized;
                }
                else if (X > 50 & X < 90)
                {
                    Parent.FindForm().Close();
                }
            }
            else if (_Min)
            {
                if (X > 0 & X < 25)
                {
                    Parent.FindForm().WindowState = FormWindowState.Minimized;
                }
                else if (X > 25 & X < 65)
                {
                    Parent.FindForm().Close();
                }
            }
            else if (_Max)
            {
                if (X > 0 & X < 25)
                {
                    if (Parent.FindForm().WindowState == FormWindowState.Maximized)
                        Parent.FindForm().WindowState = FormWindowState.Normal;
                    else
                        Parent.FindForm().WindowState = FormWindowState.Maximized;
                }
                else if (X > 25 & X < 65)
                {
                    Parent.FindForm().Close();
                }
            }
            else
            {
                if (X > 0 & X < 40)
                {
                    Parent.FindForm().Close();
                }
            }
        }

        protected override void PaintHook()
        {

            G.Clear(Color.FromArgb(47, 47, 47));
            ColorBlend cblend = new ColorBlend(2);
            cblend.Colors[0] = Color.FromArgb(66, 66, 66);
            cblend.Colors[1] = Color.FromArgb(50, 50, 50);
            cblend.Positions[0] = 0;
            cblend.Positions[1] = 1;
            DrawGradient(cblend, new Rectangle(new Point(0, 0), new Size(this.Width, this.Height)));

            if (_Min & _Max)
            {
                if (State == MouseState.Over)
                {
                    if (X > 0 & X < 25)
                    {
                        cblend = new ColorBlend(2);
                        cblend.Colors[0] = Color.FromArgb(80, 80, 80);
                        cblend.Colors[1] = Color.FromArgb(60, 60, 60);
                        cblend.Positions[0] = 0;
                        cblend.Positions[1] = 1;
                        DrawGradient(cblend, new Rectangle(new Point(1, 0), new Size(25, 15)));
                    }
                    if (X > 25 & X < 50)
                    {
                        cblend = new ColorBlend(2);
                        cblend.Colors[0] = Color.FromArgb(80, 80, 80);
                        cblend.Colors[1] = Color.FromArgb(60, 60, 60);
                        cblend.Positions[0] = 0;
                        cblend.Positions[1] = 1;
                        DrawGradient(cblend, new Rectangle(new Point(25, 0), new Size(25, 15)));
                    }
                    if (X > 50 & X < 90)
                    {
                        cblend = new ColorBlend(2);
                        cblend.Colors[0] = Color.FromArgb(80, 80, 80);
                        cblend.Colors[1] = Color.FromArgb(60, 60, 60);
                        cblend.Positions[0] = 0;
                        cblend.Positions[1] = 1;
                        DrawGradient(cblend, new Rectangle(new Point(50, 0), new Size(40, 15)));
                    }
                }
                G.DrawLine(new Pen(Color.FromArgb(104, 104, 104)), new Point(0, 0), new Point(0, 14));
                G.DrawLine(new Pen(Color.FromArgb(104, 104, 104)), new Point(1, 15), new Point(89, 15));
                G.DrawLine(new Pen(Color.FromArgb(104, 104, 104)), new Point(25, 0), new Point(25, 14));
                G.DrawLine(new Pen(Color.FromArgb(104, 104, 104)), new Point(50, 0), new Point(50, 14));
                G.DrawLine(new Pen(Color.FromArgb(104, 104, 104)), new Point(90, 0), new Point(90, 14));
                DrawPixel(Color.FromArgb(104, 104, 104), 1, 14);
                DrawPixel(Color.FromArgb(104, 104, 104), 89, 14);
                G.DrawString("r", new Font("Marlett", 8), Brushes.White, new Point(63, 2));
                if (Parent.FindForm().WindowState == FormWindowState.Normal)
                {
                    G.DrawString("1", new Font("Marlett", 8), Brushes.White, new Point(32, 2));
                }
                else
                {
                    G.DrawString("2", new Font("Marlett", 8), Brushes.White, new Point(32, 2));
                }
                G.DrawString("0", new Font("Marlett", 8), Brushes.White, new Point(6, 2));
            }
            else if (_Min)
            {
                if (State == MouseState.Over)
                {
                    if (X > 0 & X < 25)
                    {
                        cblend = new ColorBlend(2);
                        cblend.Colors[0] = Color.FromArgb(80, 80, 80);
                        cblend.Colors[1] = Color.FromArgb(60, 60, 60);
                        cblend.Positions[0] = 0;
                        cblend.Positions[1] = 1;
                        DrawGradient(cblend, new Rectangle(new Point(1, 0), new Size(25, 15)));
                    }
                    if (X > 25 & X < 65)
                    {
                        cblend = new ColorBlend(2);
                        cblend.Colors[0] = Color.FromArgb(80, 80, 80);
                        cblend.Colors[1] = Color.FromArgb(60, 60, 60);
                        cblend.Positions[0] = 0;
                        cblend.Positions[1] = 1;
                        DrawGradient(cblend, new Rectangle(new Point(25, 0), new Size(40, 15)));
                    }
                }
                G.DrawLine(new Pen(Color.FromArgb(104, 104, 104)), new Point(0, 0), new Point(0, 14));
                G.DrawLine(new Pen(Color.FromArgb(104, 104, 104)), new Point(25, 0), new Point(25, 14));
                G.DrawLine(new Pen(Color.FromArgb(104, 104, 104)), new Point(65, 0), new Point(65, 14));
                G.DrawLine(new Pen(Color.FromArgb(104, 104, 104)), new Point(1, 15), new Point(64, 15));
                DrawPixel(Color.FromArgb(104, 104, 104), 1, 14);
                DrawPixel(Color.FromArgb(104, 104, 104), 64, 14);
                G.DrawString("0", new Font("Marlett", 8), Brushes.White, new Point(6, 2));
                G.DrawString("r", new Font("Marlett", 8), Brushes.White, new Point(38, 2));
            }
            else if (_Max)
            {
                if (State == MouseState.Over)
                {
                    if (X > 0 & X < 25)
                    {
                        cblend = new ColorBlend(2);
                        cblend.Colors[0] = Color.FromArgb(80, 80, 80);
                        cblend.Colors[1] = Color.FromArgb(60, 60, 60);
                        cblend.Positions[0] = 0;
                        cblend.Positions[1] = 1;
                        DrawGradient(cblend, new Rectangle(new Point(1, 0), new Size(25, 15)));
                    }
                    if (X > 25 & X < 65)
                    {
                        cblend = new ColorBlend(2);
                        cblend.Colors[0] = Color.FromArgb(80, 80, 80);
                        cblend.Colors[1] = Color.FromArgb(60, 60, 60);
                        cblend.Positions[0] = 0;
                        cblend.Positions[1] = 1;
                        DrawGradient(cblend, new Rectangle(new Point(25, 0), new Size(40, 15)));
                    }
                }
                G.DrawLine(new Pen(Color.FromArgb(104, 104, 104)), new Point(0, 0), new Point(0, 14));
                G.DrawLine(new Pen(Color.FromArgb(104, 104, 104)), new Point(25, 0), new Point(25, 14));
                G.DrawLine(new Pen(Color.FromArgb(104, 104, 104)), new Point(65, 0), new Point(65, 14));
                G.DrawLine(new Pen(Color.FromArgb(104, 104, 104)), new Point(1, 15), new Point(64, 15));
                DrawPixel(Color.FromArgb(104, 104, 104), 1, 14);
                DrawPixel(Color.FromArgb(104, 104, 104), 64, 14);
                if (Parent.FindForm().WindowState == FormWindowState.Normal)
                {
                    G.DrawString("1", new Font("Marlett", 8), Brushes.White, new Point(6, 2));
                }
                else
                {
                    G.DrawString("2", new Font("Marlett", 8), Brushes.White, new Point(6, 2));
                }
                G.DrawString("r", new Font("Marlett", 8), Brushes.White, new Point(38, 2));
            }
            else
            {
                if (State == MouseState.Over)
                {
                    if (X > 0 & X < 40)
                    {
                        cblend = new ColorBlend(2);
                        cblend.Colors[0] = Color.FromArgb(80, 80, 80);
                        cblend.Colors[1] = Color.FromArgb(60, 60, 60);
                        cblend.Positions[0] = 0;
                        cblend.Positions[1] = 1;
                        DrawGradient(cblend, new Rectangle(new Point(1, 0), new Size(40, 15)));
                    }
                }
                G.DrawLine(new Pen(Color.FromArgb(104, 104, 104)), new Point(0, 0), new Point(0, 14));
                G.DrawLine(new Pen(Color.FromArgb(104, 104, 104)), new Point(40, 0), new Point(40, 14));
                G.DrawLine(new Pen(Color.FromArgb(104, 104, 104)), new Point(1, 15), new Point(39, 15));
                DrawPixel(Color.FromArgb(104, 104, 104), 1, 14);
                DrawPixel(Color.FromArgb(104, 104, 104), 39, 14);
                G.DrawString("r", new Font("Marlett", 8), Brushes.White, new Point(13, 2));
            }
        }
    }


}


