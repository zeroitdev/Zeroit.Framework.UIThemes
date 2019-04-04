// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ButtonA.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Modern
{
    public class ModernButtonA : Control
    {
        public ModernButtonA()
        {
            ForeColor = Color.FromArgb(65, 65, 65);
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
        Color C1 = Color.FromArgb(31, 31, 31);
        Color C2 = Color.FromArgb(41, 41, 41);
        Color C3 = Color.FromArgb(51, 51, 51);
        Color C4 = Color.FromArgb(0, 0, 0, 0);
        Color C5 = Color.FromArgb(25, 255, 255, 255);
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            using (Bitmap B = new Bitmap(Width, Height))
            {
                using (Graphics G = Graphics.FromImage(B))
                {
                    G.DrawRectangle(new Pen(C1), 0, 0, Width - 1, Height - 1);

                    if (State == 2)
                    {
                        Draw.Gradient(G, C2, C3, 1, 1, Width - 2, Height - 2);
                    }
                    else
                    {
                        Draw.Gradient(G, C3, C2, 1, 1, Width - 2, Height - 2);
                    }

                    dynamic O = G.MeasureString(Text, Font);
                    G.DrawString(Text, Font, new SolidBrush(ForeColor), Width / 2 - O.Width / 2, Height / 2 - O.Height / 2);

                    Draw.Blend(G, C4, C5, C4, 0.5f, 0, 1, 1, Width - 2, 1);

                    e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
                }
            }
        }
    }


}


