// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 02-18-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;

using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Green
{

    public class GreenButton : Control
    {

        Bitmap B;
        Graphics G;
        Rectangle R1;
        Color C1;
        Color C2;
        Color C3;
        Color C4;
        Pen P1;
        Pen P2;
        Pen P3;
        Pen P4;
        Brush B1;
        Brush B2;
        Brush B5;
        LinearGradientBrush B3;

        LinearGradientBrush B4;
        public GreenButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            C1 = Color.FromArgb(41, 57, 34);
            //Background
            C2 = Color.FromArgb(49, 49, 49);
            //Highlight
            C3 = Color.FromArgb(39, 39, 39);
            //Lesser Highlight
            C4 = Color.FromArgb(60, Color.Black);
            P1 = new Pen(Color.FromArgb(22, 22, 22));
            //Shadow
            P2 = new Pen(Color.FromArgb(20, Color.White));
            P3 = new Pen(Color.FromArgb(10, Color.White));
            P4 = new Pen(Color.FromArgb(30, Color.Black));
            B1 = new SolidBrush(C1);
            B2 = new SolidBrush(C3);
            B5 = new SolidBrush(Color.FromArgb(201, 205, 37));
            //Text Color
            Font = new Font("Verdana", 8f);
        }

        private int State;
        protected override void OnMouseLeave(EventArgs e)
        {
            State = 0;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            State = 1;
            Invalidate();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            State = 1;
            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            State = 2;
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            R1 = new Rectangle(2, 2, Width - 4, 4);
            B3 = new LinearGradientBrush(ClientRectangle, C3, C2, 90f);
            B4 = new LinearGradientBrush(R1, C4, Color.Transparent, 90f);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            B = new Bitmap(Width, Height);
            G = Graphics.FromImage(B);

            G.FillRectangle(B3, ClientRectangle);

            switch (State)
            {
                case 0:
                    //Up
                    G.FillRectangle(B1, 1, 1, Width - 2, Height - 2);
                    G.DrawLine(P2, 2, 2, Width - 3, 2);
                    G.DrawLine(P3, 2, Height - 3, Width - 3, Height - 3);
                    break;
                case 1:
                    //Over
                    G.FillRectangle(B2, 1, 1, Width - 2, Height - 2);
                    G.DrawLine(P2, 2, 2, Width - 3, 2);
                    G.DrawLine(P3, 2, Height - 3, Width - 3, Height - 3);
                    break;
                case 2:
                    //Down
                    G.FillRectangle(B2, 1, 1, Width - 2, Height - 2);
                    G.FillRectangle(B4, R1);
                    G.DrawLine(P4, 2, 2, 2, Height - 3);
                    break;
            }

            SizeF S = G.MeasureString(Text, Font);
            G.DrawString(Text, Font, B5, Convert.ToInt32(Width / 2 - S.Width / 2), Convert.ToInt32(Height / 2 - S.Height / 2));

            G.DrawRectangle(P1, 1, 1, Width - 3, Height - 3);

            e.Graphics.DrawImage(B, 0, 0);
            G.Dispose();
            B.Dispose();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

    }

}
