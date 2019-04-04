// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
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
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Metro
{
    public class MetroUIControlBox : ThemeControl154
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
        }

        public MetroUIControlBox()
        {
            IsAnimated = true;
            SetColor("Icons", Color.Black);
            SetColor("Background", Color.White);
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

            //Mouse states
            SolidBrush SB1 = new SolidBrush(Color.FromArgb(a, Color.FromArgb(53, 157, 181)));
            SolidBrush SB1_ = new SolidBrush(Color.FromArgb(b, Color.FromArgb(53, 157, 181)));
            SolidBrush SB2 = new SolidBrush(Color.FromArgb(c, Color.Red));
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


        }
    }


}


