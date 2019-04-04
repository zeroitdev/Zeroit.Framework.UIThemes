// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Button.cs" company="Zeroit Dev Technologies">
//     Copyright � Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.VS
{

    public class VSButton : Control
    {
        public VSButton()
        {
            ForeColor = C3;
        }
        private int State;
        protected override void OnMouseEnter(System.EventArgs e)
        {
            State = 1;
            Invalidate();
            base.OnMouseEnter(e);
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            State = 2;
            Invalidate();
            base.OnMouseDown(e);
        }
        protected override void OnMouseLeave(System.EventArgs e)
        {
            State = 0;
            Invalidate();
            base.OnMouseLeave(e);
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            State = 1;
            Invalidate();
            base.OnMouseUp(e);
        }
        Color C1 = Color.FromArgb(249, 245, 226);
        Color C2 = Color.FromArgb(255, 232, 165);
        Color C3 = Color.FromArgb(111, 88, 38);
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            using (Bitmap B = new Bitmap(Width, Height))
            {
                using (Graphics G = Graphics.FromImage(B))
                {
                    if (State == 2)
                    {
                        Draw.Gradient(G, C2, C1, 0, 0, Width, Height);
                    }
                    else
                    {
                        Draw.Gradient(G, C1, C2, 0, 0, Width, Height);
                    }

                    if (State < 2)
                        G.FillRectangle(new SolidBrush(Color.FromArgb(100, 255, 255, 255)), 0, 0, Width, Convert.ToInt32(Height / 2));

                    G.TextRenderingHint = (TextRenderingHint)5;
                    dynamic S = G.MeasureString(Text, Font);
                    G.DrawString(Text, Font, new SolidBrush(ForeColor), Width / 2 - S.Width / 2, Height / 2 - S.Height / 2);
                    G.DrawRectangle(new Pen(C1), 0, 0, Width - 1, Height - 1);

                    e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
                }
            }
        }
    }

}
