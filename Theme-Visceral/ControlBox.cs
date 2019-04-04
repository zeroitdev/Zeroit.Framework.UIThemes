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
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.CrystalClear
{
    public class VisceralControlBox : Control
    {
        #region " MouseStates "
        MouseState State = MouseState.None;
        int X;
        Rectangle MinBtn = new Rectangle(0, 0, 35, 20);
        Rectangle CloseBtn = new Rectangle(35, 0, 35, 20);
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (X > MinBtn.X & X < MinBtn.X + 35)
            {
                Parent.FindForm().WindowState = FormWindowState.Minimized;
            }
            else
            {
                Parent.FindForm().Close();
            }
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
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            X = e.Location.X;
            Invalidate();
        }
        #endregion

        public VisceralControlBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            base.OnPaint(e);

            G.Clear(BackColor);
            Font drawFont = new Font("Merlett", 8, FontStyle.Bold);

            switch (State)
            {
                case MouseState.None:
                    LinearGradientBrush lgb = new LinearGradientBrush(MinBtn, Color.FromArgb(50, 50, 50), Color.FromArgb(45, 45, 45), 90);
                    G.FillPath(lgb, Draw.RoundRect(MinBtn, (int)2.5));
                    G.DrawPath(Pens.Black, Draw.RoundRect(MinBtn, (int)2.5));
                    G.DrawString("_", drawFont, new SolidBrush(Color.Silver), MinBtn, new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    LinearGradientBrush lgb2 = new LinearGradientBrush(CloseBtn, Color.FromArgb(50, 50, 50), Color.FromArgb(45, 45, 45), 90);
                    G.FillPath(lgb2, Draw.RoundRect(CloseBtn, (int)2.5));
                    G.DrawPath(Pens.Black, Draw.RoundRect(CloseBtn, (int)2.5));
                    G.DrawString("x", drawFont, new SolidBrush(Color.Silver), CloseBtn, new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Over:
                    if (X > MinBtn.X & X < MinBtn.X + 35)
                    {
                        LinearGradientBrush lgb1 = new LinearGradientBrush(MinBtn, Color.FromArgb(50, 85, 255, 85), Color.FromArgb(45, 45, 45), 90);
                        G.FillPath(lgb1, Draw.RoundRect(MinBtn, (int)2.5));
                        G.DrawPath(Pens.Black, Draw.RoundRect(MinBtn, (int)2.5));
                        G.DrawString("_", drawFont, new SolidBrush(Color.Silver), MinBtn, new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        LinearGradientBrush lgb21 = new LinearGradientBrush(CloseBtn, Color.FromArgb(50, 50, 50), Color.FromArgb(45, 45, 45), 90);
                        G.FillPath(lgb21, Draw.RoundRect(CloseBtn, (int)2.5));
                        G.DrawPath(Pens.Black, Draw.RoundRect(CloseBtn, (int)2.5));
                        G.DrawString("x", drawFont, new SolidBrush(Color.Silver), CloseBtn, new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        LinearGradientBrush lgb211 = new LinearGradientBrush(CloseBtn, Color.FromArgb(50, 30, 30), Color.FromArgb(45, 45, 45), 90);
                        G.FillPath(lgb211, Draw.RoundRect(CloseBtn, (int)2.5));
                        G.DrawPath(Pens.Black, Draw.RoundRect(CloseBtn, (int)2.5));
                        G.DrawString("x", drawFont, new SolidBrush(Color.Silver), CloseBtn, new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                        LinearGradientBrush lgb11 = new LinearGradientBrush(MinBtn, Color.FromArgb(50, 50, 50), Color.FromArgb(45, 45, 45), 90);
                        G.FillPath(lgb11, Draw.RoundRect(MinBtn, (int)2.5));
                        G.DrawPath(Pens.Black, Draw.RoundRect(MinBtn, (int)2.5));
                        G.DrawString("_", drawFont, new SolidBrush(Color.Silver), MinBtn, new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;
            }


            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

}

