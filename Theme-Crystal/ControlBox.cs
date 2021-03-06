// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ControlBox.cs" company="Zeroit Dev Technologies">
//    This program is for creating Theme controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Crystal
{
    public class CrystalClearControlBox : ThemeControl154
    {
        private int X;
        Color BG;
        Pen Edge;
        Color Icons;

        SolidBrush glow;
        int a;
        int b;

        int c;
        protected override void ColorHook()
        {
            Icons = GetColor("Icons");
            BG = GetColor("Background");
            Edge = GetPen("Button edge color");
            glow = GetBrush("Glow");
        }

        public CrystalClearControlBox()
        {
            IsAnimated = true;
            SetColor("Icons", Color.FromArgb(100, 100, 100));
            SetColor("Background", Color.FromArgb(231, 231, 231));
            SetColor("Button edge color", Color.FromArgb(165, 165, 165));
            SetColor("Glow", Color.FromArgb(240, 240, 240));
            this.Size = new Size(84, 18);
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right;



        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.X;
            Invalidate();
        }

        protected override void OnClick(System.EventArgs e)
        {
            base.OnClick(e);
            if (X <= 22)
            {
                Parent.FindForm().WindowState = FormWindowState.Minimized;
            }
            else if (X > 22 & X <= 46)
            {
                if (Parent.FindForm().WindowState == FormWindowState.Maximized)
                    Parent.FindForm().WindowState = FormWindowState.Normal;
                else
                    Parent.FindForm().WindowState = FormWindowState.Maximized;
            }
            else
            {
                Parent.FindForm().Close();
            }
        }

        protected override void OnAnimation()
        {
            base.OnAnimation();
            switch (State)
            {
                case MouseState.Over:
                    if (a < 24 & X <= 22)
                    {
                        a += 4;
                        if (b > 0)
                        {
                            b -= 4;
                        }
                        if (c > 0)
                        {
                            c -= 4;
                        }
                        if (b < 0)
                            b = 0;
                        if (c < 0)
                            c = 0;
                        Invalidate();
                        Application.DoEvents();
                    }

                    if (b < 24 & X > 22 & X <= 46)
                    {
                        b += 4;
                        if (a > 0)
                        {
                            a -= 4;
                        }
                        if (a < 0)
                            a = 0;
                        if (c > 0)
                        {
                            c -= 4;
                        }
                        if (c < 0)
                            c = 0;
                        Invalidate();
                        Application.DoEvents();
                    }

                    if (c < 32 & X > 46)
                    {
                        c += 4;
                        if (a > 0)
                        {
                            a -= 4;
                        }
                        if (b > 0)
                        {
                            b -= 4;
                        }
                        if (a < 0)
                            a = 0;
                        if (b < 0)
                            b = 0;
                        Invalidate();
                        Application.DoEvents();
                    }

                    break;
                case MouseState.None:
                    if (a > 0)
                    {
                        a -= 4;
                    }
                    if (b > 0)
                    {
                        b -= 4;
                    }
                    if (c > 0)
                    {
                        c -= 4;
                    }
                    if (a < 0)
                        a = 0;
                    if (b < 0)
                        b = 0;
                    if (c < 0)
                        c = 0;
                    Invalidate();
                    Application.DoEvents();
                    break;
            }
        }

        protected override void PaintHook()
        {
            //Draw outer edge
            G.Clear(BG);

            //G.Clear(BackColor);

            //Fill buttons
            G.FillRectangle(glow, new Rectangle(0, 0, 21, 8));
            //min button
            G.FillRectangle(glow, new Rectangle(23, 0, 22, 8));
            //max button
            G.FillRectangle(glow, new Rectangle(47, 0, 36, 8));
            //X button

            //Draw button outlines
            G.DrawRectangle(Edge, new Rectangle(0, 0, 21, 17));
            //min button
            G.DrawRectangle(Edge, new Rectangle(23, 0, 22, 17));
            //max button
            G.DrawRectangle(Edge, new Rectangle(47, 0, 36, 17));
            //X button

            //Mouse states
            SolidBrush SB1 = new SolidBrush(Color.FromArgb(a, Color.Cyan));
            SolidBrush SB1_ = new SolidBrush(Color.FromArgb(b, Color.Cyan));
            SolidBrush SB2 = new SolidBrush(Color.FromArgb(c, Color.OrangeRed));
            SolidBrush SB3 = new SolidBrush(Color.FromArgb(20, Color.Black));
            switch (State)
            {
                case MouseState.Down:
                    if (X <= 22)
                    {
                        a = 0;
                        G.FillRectangle(SB3, new Rectangle(0, 0, 21, 17));
                    }
                    else if (X > 22 & X <= 46)
                    {
                        b = 0;
                        G.FillRectangle(SB3, new Rectangle(23, 0, 22, 17));
                    }
                    else
                    {
                        c = 0;
                        G.FillRectangle(SB3, new Rectangle(47, 0, 36, 17));
                    }
                    break;
                default:
                    if (X <= 22)
                    {
                        G.FillRectangle(SB1, new Rectangle(0, 0, 21, 17));
                    }
                    else if (X > 22 & X <= 46)
                    {
                        G.FillRectangle(SB1_, new Rectangle(23, 0, 22, 17));
                    }
                    else
                    {
                        G.FillRectangle(SB2, new Rectangle(47, 0, 36, 17));
                    }
                    break;
            }

            //Draw icons
            G.DrawString("0", new Font("Marlett", 8.25f), GetBrush("Icons"), new Point(5, 4));
            if (Parent.FindForm().WindowState != FormWindowState.Maximized)
                G.DrawString("1", new Font("Marlett", 8), GetBrush("Icons"), new Point(28, 4));
            else
                G.DrawString("2", new Font("Marlett", 8.25f), GetBrush("Icons"), new Point(28, 4));
            G.DrawString("r", new Font("Marlett", 10), GetBrush("Icons"), new Point(56, 3));

            //Round min button corners
            DrawPixel(BG, 0, 0);
            DrawPixel(Edge.Color, 1, 1);
            DrawPixel(Color.FromArgb(210, 210, 210), 0, 17);
            DrawPixel(Edge.Color, 1, 16);

            //Round X button corners
            DrawPixel(BG, Width - 1, 0);
            DrawPixel(Edge.Color, Width - 2, 1);
            DrawPixel(Color.FromArgb(210, 210, 210), Width - 1, 17);
            DrawPixel(Edge.Color, Width - 2, 16);
        }
    }

}



