// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ButtonWhite.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Excision
{
    public class ExcisionButtonWhite : Control
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

        public ExcisionButtonWhite()
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
            Rectangle InnerRect = new Rectangle(1, 1, Width - 3, Height - 3);


            base.OnPaint(e);

            G.Clear(BackColor);
            Font drawFont = new Font("Tahoma", 10, FontStyle.Bold);

            //G.CompositingQuality = CompositingQuality.HighQuality
            G.SmoothingMode = SmoothingMode.HighQuality;

            switch (State)
            {
                case MouseState.None:
                    LinearGradientBrush BBG = new LinearGradientBrush(ClientRectangle, Color.FromArgb(225, 225, 225), Color.FromArgb(210, 210, 210), 90);
                    G.FillPath(BBG, Draw.RoundRect(ClientRectangle, 4));
                    Pen p = new Pen(new SolidBrush(Color.FromArgb(254, 254, 254)));
                    G.DrawPath(Pens.Black, Draw.RoundRect(ClientRectangle, 4));
                    Pen Ip = new Pen(Color.FromArgb(255, 255, 255));
                    G.DrawPath(Ip, Draw.RoundRect(InnerRect, 4));
                    G.DrawString(Text, drawFont, new SolidBrush(Color.FromArgb(82, 87, 93)), new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                    break;
                case MouseState.Over:
                    LinearGradientBrush BBG1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(222, 222, 222), Color.FromArgb(222, 222, 222), 90);
                    G.FillPath(BBG1, Draw.RoundRect(ClientRectangle, 4));
                    Pen p1 = new Pen(new SolidBrush(Color.FromArgb(222, 222, 222)));
                    G.DrawPath(Pens.Black, Draw.RoundRect(ClientRectangle, 4));
                    Pen Ip1 = new Pen(Color.FromArgb(255, 255, 255));
                    G.DrawPath(Ip1, Draw.RoundRect(InnerRect, 4));
                    G.DrawString(Text, drawFont, new SolidBrush(Color.FromArgb(85, 85, 85)), new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });

                    break;
                case MouseState.Down:
                    LinearGradientBrush BBG2 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(254, 254, 254), Color.FromArgb(248, 246, 247), 90);
                    G.FillPath(BBG2, Draw.RoundRect(ClientRectangle, 4));
                    Pen p2 = new Pen(new SolidBrush(Color.FromArgb(254, 254, 254)));
                    G.DrawPath(Pens.Black, Draw.RoundRect(ClientRectangle, 4));
                    Pen Ip2 = new Pen(Color.FromArgb(255, 255, 255));
                    G.DrawPath(Ip2, Draw.RoundRect(InnerRect, 4));
                    G.DrawString(Text, drawFont, new SolidBrush(Color.FromArgb(82, 87, 93)), new Rectangle(0, 1, Width - 1, Height - 1), new StringFormat
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