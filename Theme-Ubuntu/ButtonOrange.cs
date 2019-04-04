// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ButtonOrange.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.Ubuntu
{
    public class UbuntuButtonOrange : Control
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

        public UbuntuButtonOrange()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(86, 109, 109);
            DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);

            base.OnPaint(e);

            G.SmoothingMode = SmoothingMode.HighQuality;

            G.Clear(BackColor);
            Font drawFont = new Font("Tahoma", 11, FontStyle.Regular);
            Pen p = new Pen(Color.FromArgb(157, 118, 103), 1);
            Brush nb = new SolidBrush(Color.FromArgb(86, 109, 109));
            switch (State)
            {
                case MouseState.None:

                    LinearGradientBrush lgb = new LinearGradientBrush(ClientRectangle, Color.FromArgb(249, 163, 128), Color.FromArgb(237, 139, 99), 90);
                    G.FillPath(lgb, Draw.RoundRect(ClientRectangle, 3));
                    G.DrawPath(p, Draw.RoundRect(ClientRectangle, 3));

                    G.DrawString(Text, drawFont, nb, new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Over:
                    LinearGradientBrush lgb1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(255, 186, 153), Color.FromArgb(255, 171, 135), 90);
                    G.FillPath(lgb1, Draw.RoundRect(ClientRectangle, 3));
                    G.DrawPath(p, Draw.RoundRect(ClientRectangle, 3));

                    G.DrawString(Text, drawFont, nb, new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Down:
                    LinearGradientBrush lgb2 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(200, 116, 83), Color.FromArgb(194, 101, 65), 90);
                    G.FillPath(lgb2, Draw.RoundRect(ClientRectangle, 3));
                    G.DrawPath(p, Draw.RoundRect(ClientRectangle, 3));

                    G.DrawString(Text, drawFont, nb, new Rectangle(0, 0, Width - 1, Height - 1), new StringFormat
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


