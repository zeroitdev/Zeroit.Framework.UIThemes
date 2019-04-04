// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Windows.Forms;
using System.Drawing;

namespace Zeroit.Framework.UIThemes.UClear
{
    public class UnClearGroupBox : ContainerControl
    {
        public enum TAlign
        {
            Left = 0,
            Center = 1,
            Right = 2
        }

        private TAlign TA;
        public TAlign TextAlignment
        {
            get { return TA; }
            set
            {
                TA = value;
                Invalidate();
            }
        }

        public UnClearGroupBox()
        {
            Size = new Size(275, 75);
            TA = TAlign.Left;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;

            G.Clear(Color.FromArgb(246, 246, 246));

            G.DrawRectangle(ConversionFunctions.ToPen(150, 150, 150), new Rectangle(0, Convert.ToInt32(G.MeasureString(Text, Font).Height / 2), Width - 1, Height - 1 - Convert.ToInt32(G.MeasureString(Text, Font).Height / 2)));

            int TOff = 0;
            switch (TA)
            {
                case TAlign.Left:
                    TOff = 6;
                    break;
                case TAlign.Right:
                    TOff = Width - 6 - (int)G.MeasureString(Text, Font).Width;
                    break;
                case TAlign.Center:
                    TOff = Convert.ToInt32((Width / 2) - (G.MeasureString(Text, Font).Width / 2));
                    break;
            }

            G.FillRectangle(ConversionFunctions.ToBrush(246, 246, 246), new Rectangle(new Point(TOff, 0), G.MeasureString(Text, Font).ToSize()));

            G.DrawString(Text, Font, Brushes.Black, TOff, 0);
        }
    }

}


