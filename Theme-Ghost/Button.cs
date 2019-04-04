// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Ghost
{

    public class GhostButton : ThemeControl154
    {
        private bool Glass = true;
        private Color _color;

        int a = 0;

        protected override void ColorHook()
        {
        }

        protected override void OnAnimation()
        {
            base.OnAnimation();
            switch (State)
            {
                case MouseState.Over:
                    if (a < 20)
                    {
                        a += 5;
                        Invalidate();
                        Application.DoEvents();
                    }
                    break;
                case MouseState.None:
                    if (a > 0)
                    {
                        a -= 5;
                        if (a < 0)
                            a = 0;
                        Invalidate();
                        Application.DoEvents();
                    }
                    break;
            }
        }

        public bool EnableGlass
        {
            get { return Glass; }
            set { Glass = value; }
        }

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Graphics gg = this.CreateGraphics();
            SizeF textSize = this.CreateGraphics().MeasureString(Text, Font);
            gg.DrawString(Text, Font, Brushes.White, new RectangleF(0, 0, this.Width, this.Height));
        }

        protected override void PaintHook()
        {
            G.Clear(_color);
            if (State == MouseState.Over)
            {
                ColorBlend cblend = new ColorBlend(2);
                cblend.Colors[0] = Color.FromArgb(200, 50, 50, 50);
                cblend.Colors[1] = Color.FromArgb(200, 70, 70, 70);
                cblend.Positions[0] = 0;
                cblend.Positions[1] = 1;
                DrawGradient(cblend, new Rectangle(0, 0, Width, Height));
                cblend.Colors[0] = Color.FromArgb(0, 0, 0, 0);
                cblend.Colors[1] = Color.FromArgb(40, Color.White);
                if (Glass)
                    DrawGradient(cblend, new Rectangle(0, 0, Width, Height / 5 * 2));
            }
            else if (State == MouseState.None)
            {
                ColorBlend cblend = new ColorBlend(2);
                cblend.Colors[0] = Color.FromArgb(200, 50, 50, 50);
                cblend.Colors[1] = Color.FromArgb(200, 70, 70, 70);
                cblend.Positions[0] = 0;
                cblend.Positions[1] = 1;
                DrawGradient(cblend, new Rectangle(0, 0, Width, Height));
                cblend.Colors[0] = Color.FromArgb(0, 0, 0, 0);
                cblend.Colors[1] = Color.FromArgb(40, Color.White);
                if (Glass)
                    DrawGradient(cblend, new Rectangle(0, 0, Width, Height / 5 * 2));
            }
            else
            {
                ColorBlend cblend = new ColorBlend(2);
                cblend.Colors[0] = Color.FromArgb(200, 30, 30, 30);
                cblend.Colors[1] = Color.FromArgb(200, 50, 50, 50);
                cblend.Positions[0] = 0;
                cblend.Positions[1] = 1;
                DrawGradient(cblend, new Rectangle(0, 0, Width, Height));
                cblend.Colors[0] = Color.FromArgb(0, 0, 0, 0);
                cblend.Colors[1] = Color.FromArgb(40, Color.White);
                if (Glass)
                    DrawGradient(cblend, new Rectangle(0, 0, Width, Height / 5 * 2));
            }
            G.FillRectangle(new SolidBrush(Color.FromArgb(a, Color.White)), 0, 0, Width, Height);
            HatchBrush hatch = default(HatchBrush);
            hatch = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.FromArgb(25, Color.Black), Color.FromArgb(0, Color.Gray));
            G.FillRectangle(hatch, 0, 0, Width, Height);
            SizeF textSize = this.CreateGraphics().MeasureString(Text, Font, Width - 4);
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            G.DrawString(Text, Font, Brushes.White, new RectangleF(2, 2, this.Width - 5, this.Height - 4), sf);
            DrawBorders(Pens.Black);
            DrawBorders(new Pen(Color.FromArgb(90, 90, 90)), 1);
        }

        public GhostButton()
        {
            IsAnimated = true;
        }

    }


}
