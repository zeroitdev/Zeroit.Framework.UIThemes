// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Seperator.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.UClear
{
    public class UnClearSeperator : Control
    {

        public enum Alignment
        {
            Horizontal,
            Vertical

        }

        private Alignment al;
        public Alignment Align
        {
            get { return al; }
            set
            {
                al = value;
                Invalidate();
            }
        }

        Color C1 = Color.FromArgb(246, 246, 246);
        Color C2 = Color.FromArgb(140, 140, 140);
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            switch (Align)
            {

                case Alignment.Vertical:
                    G.DrawLine(ConversionFunctions.ToPen(C1), new Point(Width / 2, 0), new Point(Width / 2, Height));
                    G.DrawLine(ConversionFunctions.ToPen(C2), new Point(Width / 2 + 1, 0), new Point(Width / 2 + 1, Height));
                    break;
                case Alignment.Horizontal:
                    G.DrawLine(ConversionFunctions.ToPen(C1), new Point(0, Height / 2), new Point(Width, Height / 2));
                    G.DrawLine(ConversionFunctions.ToPen(C2), new Point(0, Height / 2 + 1), new Point(Width, Height / 2 + 1));
                    break;
            }


            e.Graphics.DrawImage(B, 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

}


