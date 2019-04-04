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
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.UIThemes.Evolve
{

    public class EvolveCheckBox : ThemeControl154
    {
        private bool _Checked;

        private int X;
        protected override void ColorHook()
        {
        }

        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                Invalidate();
            }
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
            if (_Checked)
                _Checked = false;
            else
                _Checked = true;
        }

        public EvolveCheckBox()
        {
            this.BackColor = Color.FromArgb(47, 47, 47);
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            int textSize = 0;
            textSize = (int)this.CreateGraphics().MeasureString(Text, Font).Width;
            this.Width = 20 + textSize;
        }

        protected override void PaintHook()
        {
            G.Clear(Color.FromArgb(47, 47, 47));
            if (!Checked & State == MouseState.None)
            {
                LinearGradientBrush Gbrush = new LinearGradientBrush(new Rectangle(new Point(1, 1), new Size(14, 14)), Color.FromArgb(74, 74, 74), Color.FromArgb(22, 22, 22), 90f);
                G.FillRectangle(Gbrush, new Rectangle(new Point(1, 1), new Size(14, 14)));
                G.DrawLine(Pens.Black, 1, 0, 14, 0);
                G.DrawLine(Pens.Black, 0, 1, 0, 14);
                G.DrawLine(Pens.Black, 15, 1, 15, 14);
                G.DrawLine(Pens.Black, 1, 15, 14, 15);
                DrawPixel(Color.FromArgb(40, Color.Black), 15, 0);
                DrawPixel(Color.FromArgb(40, Color.Black), 0, 0);
                DrawPixel(Color.FromArgb(40, Color.Black), 15, 15);
                DrawPixel(Color.FromArgb(40, Color.Black), 0, 15);
                DrawPixel(Color.FromArgb(85, 85, 85), 1, 1);
                DrawPixel(Color.FromArgb(85, 85, 85), 1, 2);
                DrawPixel(Color.FromArgb(85, 85, 85), 14, 1);
                DrawPixel(Color.FromArgb(85, 85, 85), 14, 2);
                DrawPixel(Color.FromArgb(16, 16, 16), 1, 14);
                DrawPixel(Color.FromArgb(16, 16, 16), 14, 14);
                G.DrawLine(new Pen(Color.FromArgb(110, 110, 110)), 2, 1, 13, 1);
            }
            else if (!Checked & State == MouseState.Over & X < 17)
            {
                LinearGradientBrush Gbrush = new LinearGradientBrush(new Rectangle(new Point(1, 1), new Size(14, 14)), Color.FromArgb(120, 51, 51), Color.FromArgb(50, 13, 13), 90f);
                G.FillRectangle(Gbrush, new Rectangle(new Point(1, 1), new Size(14, 14)));
                G.DrawLine(Pens.Black, 1, 0, 14, 0);
                G.DrawLine(Pens.Black, 0, 1, 0, 14);
                G.DrawLine(Pens.Black, 15, 1, 15, 14);
                G.DrawLine(Pens.Black, 1, 15, 14, 15);
                DrawPixel(Color.FromArgb(40, Color.Black), 15, 0);
                DrawPixel(Color.FromArgb(40, Color.Black), 0, 0);
                DrawPixel(Color.FromArgb(40, Color.Black), 15, 15);
                DrawPixel(Color.FromArgb(40, Color.Black), 0, 15);
                DrawPixel(Color.FromArgb(125, 75, 75), 1, 1);
                DrawPixel(Color.FromArgb(125, 75, 75), 1, 2);
                DrawPixel(Color.FromArgb(125, 75, 75), 14, 1);
                DrawPixel(Color.FromArgb(125, 75, 75), 14, 2);
                DrawPixel(Color.FromArgb(69, 9, 9), 1, 14);
                DrawPixel(Color.FromArgb(69, 9, 9), 14, 14);
                G.DrawLine(new Pen(Color.FromArgb(145, 90, 90)), 2, 1, 13, 1);
            }
            else if (Checked & State == MouseState.None)
            {
                LinearGradientBrush Gbrush = new LinearGradientBrush(new Rectangle(new Point(1, 1), new Size(14, 14)), Color.FromArgb(161, 51, 51), Color.FromArgb(99, 13, 13), 90f);
                G.FillRectangle(Gbrush, new Rectangle(new Point(1, 1), new Size(14, 14)));
                G.DrawLine(Pens.Black, 1, 0, 14, 0);
                G.DrawLine(Pens.Black, 0, 1, 0, 14);
                G.DrawLine(Pens.Black, 15, 1, 15, 14);
                G.DrawLine(Pens.Black, 1, 15, 14, 15);
                DrawPixel(Color.FromArgb(40, Color.Black), 15, 0);
                DrawPixel(Color.FromArgb(40, Color.Black), 0, 0);
                DrawPixel(Color.FromArgb(40, Color.Black), 15, 15);
                DrawPixel(Color.FromArgb(40, Color.Black), 0, 15);
                DrawPixel(Color.FromArgb(125, 75, 75), 1, 1);
                DrawPixel(Color.FromArgb(125, 75, 75), 1, 2);
                DrawPixel(Color.FromArgb(125, 75, 75), 14, 1);
                DrawPixel(Color.FromArgb(125, 75, 75), 14, 2);
                DrawPixel(Color.FromArgb(69, 9, 9), 1, 14);
                DrawPixel(Color.FromArgb(69, 9, 9), 14, 14);
                G.DrawLine(new Pen(Color.FromArgb(181, 90, 90)), 2, 1, 13, 1);
                G.DrawString("a", new Font("Webdings", 13), new SolidBrush(Color.FromArgb(78, 12, 12)), new Point(-3, -2));
                G.DrawString("a", new Font("Webdings", 13), Brushes.White, new Point(-3, -3));
            }
            else if (Checked & State == MouseState.Over & X < 17)
            {
                LinearGradientBrush Gbrush = new LinearGradientBrush(new Rectangle(new Point(1, 1), new Size(14, 14)), Color.FromArgb(180, 51, 51), Color.FromArgb(120, 20, 20), 90f);
                G.FillRectangle(Gbrush, new Rectangle(new Point(1, 1), new Size(14, 14)));
                G.DrawLine(Pens.Black, 1, 0, 14, 0);
                G.DrawLine(Pens.Black, 0, 1, 0, 14);
                G.DrawLine(Pens.Black, 15, 1, 15, 14);
                G.DrawLine(Pens.Black, 1, 15, 14, 15);
                DrawPixel(Color.FromArgb(40, Color.Black), 15, 0);
                DrawPixel(Color.FromArgb(40, Color.Black), 0, 0);
                DrawPixel(Color.FromArgb(40, Color.Black), 15, 15);
                DrawPixel(Color.FromArgb(40, Color.Black), 0, 15);
                DrawPixel(Color.FromArgb(125, 75, 75), 1, 1);
                DrawPixel(Color.FromArgb(125, 75, 75), 1, 2);
                DrawPixel(Color.FromArgb(125, 75, 75), 14, 1);
                DrawPixel(Color.FromArgb(125, 75, 75), 14, 2);
                DrawPixel(Color.FromArgb(69, 9, 9), 1, 14);
                DrawPixel(Color.FromArgb(69, 9, 9), 14, 14);
                G.DrawLine(new Pen(Color.FromArgb(181, 90, 90)), 2, 1, 13, 1);
                G.DrawString("a", new Font("Webdings", 13), new SolidBrush(Color.FromArgb(78, 12, 12)), new Point(-3, -2));
                G.DrawString("a", new Font("Webdings", 13), Brushes.White, new Point(-3, -3));
            }
            else if (Checked & State == MouseState.Over & X >= 17)
            {
                LinearGradientBrush Gbrush = new LinearGradientBrush(new Rectangle(new Point(1, 1), new Size(14, 14)), Color.FromArgb(161, 51, 51), Color.FromArgb(99, 13, 13), 90f);
                G.FillRectangle(Gbrush, new Rectangle(new Point(1, 1), new Size(14, 14)));
                G.DrawLine(Pens.Black, 1, 0, 14, 0);
                G.DrawLine(Pens.Black, 0, 1, 0, 14);
                G.DrawLine(Pens.Black, 15, 1, 15, 14);
                G.DrawLine(Pens.Black, 1, 15, 14, 15);
                DrawPixel(Color.FromArgb(40, Color.Black), 15, 0);
                DrawPixel(Color.FromArgb(40, Color.Black), 0, 0);
                DrawPixel(Color.FromArgb(40, Color.Black), 15, 15);
                DrawPixel(Color.FromArgb(40, Color.Black), 0, 15);
                DrawPixel(Color.FromArgb(125, 75, 75), 1, 1);
                DrawPixel(Color.FromArgb(125, 75, 75), 1, 2);
                DrawPixel(Color.FromArgb(125, 75, 75), 14, 1);
                DrawPixel(Color.FromArgb(125, 75, 75), 14, 2);
                DrawPixel(Color.FromArgb(69, 9, 9), 1, 14);
                DrawPixel(Color.FromArgb(69, 9, 9), 14, 14);
                G.DrawLine(new Pen(Color.FromArgb(181, 90, 90)), 2, 1, 13, 1);
                G.DrawString("a", new Font("Webdings", 13), new SolidBrush(Color.FromArgb(78, 12, 12)), new Point(-3, -2));
                G.DrawString("a", new Font("Webdings", 13), Brushes.White, new Point(-3, -3));
            }
            else
            {
                LinearGradientBrush Gbrush = new LinearGradientBrush(new Rectangle(new Point(1, 1), new Size(14, 14)), Color.FromArgb(74, 74, 74), Color.FromArgb(22, 22, 22), 90f);
                G.FillRectangle(Gbrush, new Rectangle(new Point(1, 1), new Size(14, 14)));
                G.DrawLine(Pens.Black, 1, 0, 14, 0);
                G.DrawLine(Pens.Black, 0, 1, 0, 14);
                G.DrawLine(Pens.Black, 15, 1, 15, 14);
                G.DrawLine(Pens.Black, 1, 15, 14, 15);
                DrawPixel(Color.FromArgb(40, Color.Black), 15, 0);
                DrawPixel(Color.FromArgb(40, Color.Black), 0, 0);
                DrawPixel(Color.FromArgb(40, Color.Black), 15, 15);
                DrawPixel(Color.FromArgb(40, Color.Black), 0, 15);
                DrawPixel(Color.FromArgb(85, 85, 85), 1, 1);
                DrawPixel(Color.FromArgb(85, 85, 85), 1, 2);
                DrawPixel(Color.FromArgb(85, 85, 85), 14, 1);
                DrawPixel(Color.FromArgb(85, 85, 85), 14, 2);
                DrawPixel(Color.FromArgb(16, 16, 16), 1, 14);
                DrawPixel(Color.FromArgb(16, 16, 16), 14, 14);
                G.DrawLine(new Pen(Color.FromArgb(110, 110, 110)), 2, 1, 13, 1);
            }
            G.DrawString(Text, Font, Brushes.Black, 20, 2);
            G.DrawString(Text, Font, Brushes.White, 20, 1);
        }
    }


}


