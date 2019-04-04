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
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.CrystalClear
{
    public class VisceralButton : Control
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

        public VisceralButton()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);

            base.OnPaint(e);

            G.Clear(BackColor);
            Font drawFont = new Font("Arial", 8, FontStyle.Bold);
            switch (State)
            {
                case MouseState.None:
                    LinearGradientBrush lgb = new LinearGradientBrush(ClientRectangle, Color.FromArgb(61, 61, 63), Color.FromArgb(14, 14, 14), 90);
                    G.FillPath(lgb, Draw.RoundRect(ClientRectangle, 3));
                    LinearGradientBrush gloss = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height / 2), Color.FromArgb(100, Color.FromArgb(61, 61, 63)), Color.FromArgb(12, 255, 255, 255), 90);
                    G.FillPath(gloss, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height / 2), 3));
                    G.DrawPath(Pens.Black, Draw.RoundRect(ClientRectangle, 3));
                    G.DrawString(Text, drawFont, new SolidBrush(ForeColor), new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Over:
                    LinearGradientBrush lgb1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(245, 61, 61, 63), Color.FromArgb(245, 14, 14, 14), 90);
                    G.FillPath(lgb1, Draw.RoundRect(ClientRectangle, 3));
                    LinearGradientBrush gloss1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height / 2), Color.FromArgb(75, Color.FromArgb(61, 61, 63)), Color.FromArgb(20, 255, 255, 255), 90);
                    G.FillPath(gloss1, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height / 2), 3));
                    G.DrawPath(Pens.Black, Draw.RoundRect(ClientRectangle, 3));
                    G.DrawString(Text, drawFont, new SolidBrush(ForeColor), new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Down:
                    LinearGradientBrush lgb2 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(51, 51, 53), Color.FromArgb(4, 4, 4), 90);
                    G.FillPath(lgb2, Draw.RoundRect(ClientRectangle, 3));
                    LinearGradientBrush gloss2 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height / 2), Color.FromArgb(75, Color.FromArgb(61, 61, 63)), Color.FromArgb(5, 255, 255, 255), 90);
                    G.FillPath(gloss2, Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height / 2), 3));
                    G.DrawPath(Pens.Black, Draw.RoundRect(ClientRectangle, 3));
                    G.DrawString(Text, drawFont, new SolidBrush(ForeColor), new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
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

