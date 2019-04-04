// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Simpla
{

    public class SimplaButton : Control
    {
        #region " MouseStates "
        MouseState State = MouseState.None;
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            Invalidate();
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
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
        #endregion

        public enum ColorSchemes
        {
            DarkGray,
            Green,
            Blue,
            White,
            Red
        }
        private ColorSchemes _ColorScheme;
        public ColorSchemes ColorScheme
        {
            get { return _ColorScheme; }
            set
            {
                _ColorScheme = value;
                Invalidate();
            }
        }

        public SimplaButton()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(205, 205, 205);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
            Rectangle InnerRectangle = new Rectangle(1, 1, Width - 3, Height - 3);

            base.OnPaint(e);

            G.Clear(BackColor);
            Font drawFont = new Font("Calibri (Body)", 10, FontStyle.Bold);

            G.SmoothingMode = SmoothingMode.HighQuality;

            switch (ColorScheme)
            {
                case ColorSchemes.DarkGray:
                    LinearGradientBrush gradientBackground = new LinearGradientBrush(ClientRectangle, Color.FromArgb(23, 23, 23), Color.FromArgb(17, 17, 17), 90);
                    G.FillPath(gradientBackground, Draw.RoundRect(ClientRectangle, 4));

                    Pen p = new Pen(new SolidBrush(Color.FromArgb(56, 56, 56)));
                    G.DrawPath(p, Draw.RoundRect(ClientRectangle, 4));

                    Pen p2 = new Pen(new SolidBrush(Color.FromArgb(5, 240, 240, 240)));
                    G.DrawPath(p2, Draw.RoundRect(InnerRectangle, 4));
                    break;
                case ColorSchemes.Green:
                    LinearGradientBrush gradientBackground1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(121, 185, 0), Color.FromArgb(94, 165, 1), 90);
                    G.FillPath(gradientBackground1, Draw.RoundRect(ClientRectangle, 4));

                    Pen p1 = new Pen(new SolidBrush(Color.FromArgb(159, 207, 1)));
                    G.DrawPath(p1, Draw.RoundRect(ClientRectangle, 4));

                    Pen p21 = new Pen(new SolidBrush(Color.FromArgb(30, 240, 240, 240)));
                    G.DrawPath(p21, Draw.RoundRect(InnerRectangle, 4));
                    break;
                case ColorSchemes.Blue:
                    LinearGradientBrush gradientBackground2 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(0, 124, 186), Color.FromArgb(0, 97, 166), 90);
                    G.FillPath(gradientBackground2, Draw.RoundRect(ClientRectangle, 4));

                    Pen p22 = new Pen(new SolidBrush(Color.FromArgb(0, 161, 207)));
                    G.DrawPath(p22, Draw.RoundRect(ClientRectangle, 4));

                    Pen p220 = new Pen(new SolidBrush(Color.FromArgb(10, 240, 240, 240)));
                    G.DrawPath(p220, Draw.RoundRect(InnerRectangle, 4));
                    break;
                case ColorSchemes.White:
                    LinearGradientBrush gradientBackground22 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(245, 245, 245), Color.FromArgb(246, 246, 246), 90);
                    G.FillPath(gradientBackground22, Draw.RoundRect(ClientRectangle, 4));

                    Pen p221 = new Pen(new SolidBrush(Color.FromArgb(254, 254, 254)));
                    G.DrawPath(p221, Draw.RoundRect(ClientRectangle, 4));

                    Pen p223 = new Pen(new SolidBrush(Color.FromArgb(10, 240, 240, 240)));
                    G.DrawPath(p223, Draw.RoundRect(InnerRectangle, 4));
                    break;
                case ColorSchemes.Red:
                    LinearGradientBrush gradientBackground3 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(185, 0, 0), Color.FromArgb(170, 0, 0), 90);
                    G.FillPath(gradientBackground3, Draw.RoundRect(ClientRectangle, 4));

                    Pen p3 = new Pen(new SolidBrush(Color.FromArgb(209, 1, 1)));
                    G.DrawPath(p3, Draw.RoundRect(ClientRectangle, 4));

                    Pen p23 = new Pen(new SolidBrush(Color.FromArgb(2, 240, 240, 240)));
                    G.DrawPath(p23, Draw.RoundRect(InnerRectangle, 4));
                    break;
                default:

                    break;
            }

            switch (State)
            {
                case MouseState.None:
                    if (ColorScheme == ColorSchemes.White)
                    {
                        G.DrawString(Text, drawFont, new SolidBrush(Color.FromArgb(51, 51, 51)), new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        LinearGradientBrush textGradient = new LinearGradientBrush(ClientRectangle, Color.FromArgb(235, 235, 235), Color.FromArgb(212, 212, 212), 90);
                        G.DrawString(Text, drawFont, textGradient, new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;
                case MouseState.Over:
                    G.DrawString(Text, drawFont, new SolidBrush(Color.Silver), new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Down:
                    G.DrawString(Text, drawFont, new SolidBrush(Color.DimGray), new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
            }


            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

}

