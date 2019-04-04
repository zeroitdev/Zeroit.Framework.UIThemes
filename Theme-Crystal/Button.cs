// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
//     Copyright � Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Crystal
{

    public class CrystalClearButton : ThemeControl154
    {
        Color G1;
        Color G2;
        Color Glow;
        Color Edge;
        Color TextColor;
        Color Hovercolor;

        int a = 0;
        protected override void ColorHook()
        {
            G1 = GetColor("Gradient 1");
            G2 = GetColor("Gradient 2");
            Glow = GetColor("Glow");
            Edge = GetColor("Edge");
            TextColor = GetColor("Text");
            Hovercolor = GetColor("HoverColor");
        }

        protected override void OnAnimation()
        {
            base.OnAnimation();
            switch (State)
            {
                case MouseState.Over:
                    if (a < 40)
                    {
                        a += 8;
                        Invalidate();
                        Application.DoEvents();
                    }
                    break;
                case MouseState.None:
                    if (a > 0)
                    {
                        a -= 10;
                        if (a < 0)
                            a = 0;
                        Invalidate();
                        Application.DoEvents();
                    }
                    break;
            }
        }

        protected override void PaintHook()
        {
            G.Clear(G1);
            LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(new Point(1, 1), new Size(Width - 2, Height - 2)), G1, G2, 90f);
            HatchBrush HB = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.FromArgb(7, Color.Black), Color.Transparent);
            G.FillRectangle(LGB, new Rectangle(new Point(1, 1), new Size(Width - 2, Height - 2)));
            G.FillRectangle(new SolidBrush(Glow), new Rectangle(new Point(1, 1), new Size(Width - 2, (Height / 2) - 3)));
            G.FillRectangle(HB, new Rectangle(new Point(1, 1), new Size(Width - 2, Height - 2)));

            if (State == MouseState.Over | State == MouseState.None)
            {
                SolidBrush SB = new SolidBrush(Color.FromArgb(a * 2, Color.White));
                G.FillRectangle(SB, new Rectangle(new Point(1, 1), new Size(Width - 2, Height - 2)));
            }
            else if (State == MouseState.Down)
            {
                SolidBrush SB = new SolidBrush(Color.FromArgb(2, Color.Black));
                G.FillRectangle(SB, new Rectangle(new Point(1, 1), new Size(Width - 2, Height - 2)));
            }

            G.DrawRectangle(new Pen(Edge), new Rectangle(new Point(1, 1), new Size(Width - 2, Height - 2)));
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            G.DrawString(Text, Font, GetBrush("Text"), new RectangleF(2, 2, this.Width - 5, this.Height - 4), sf);
        }

        public CrystalClearButton()
        {
            IsAnimated = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            SetColor("Gradient 1", 230, 230, 230);
            SetColor("Gradient 2", 210, 210, 210);
            SetColor("Glow", 230, 230, 230);
            SetColor("Edge", 170, 170, 170);
            SetColor("Text", Color.Black);
            SetColor("HoverColor", Color.White);
            Size = new Size(145, 25);
        }
    }

}



