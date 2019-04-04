// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="Kach.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.NeSeal
{

    public class NSKach : Control
    {

        public NSKach()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            Font = new Font("Segoe UI", 11.25f, FontStyle.Bold);

            B1 = new SolidBrush(Color.FromArgb(51, 181, 229));
        }

        private string _Value1 = "Ќąȼh";
        public string Value1
        {
            get { return _Value1; }
            set
            {
                _Value1 = value;
                Invalidate();
            }
        }

        private string _Value2 = "ȼℓąƶƶ";
        public string Value2
        {
            get { return _Value2; }
            set
            {
                _Value2 = value;
                Invalidate();
            }
        }


        private SolidBrush B1;
        private PointF PT1;
        private PointF PT2;
        private SizeF SZ1;

        private SizeF SZ2;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            ThemeModule theme = new ThemeModule();
            var G = theme.G;
            G = e.Graphics;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            G.Clear(BackColor);

            SZ1 = G.MeasureString(Value1, Font, Width, StringFormat.GenericTypographic);
            SZ2 = G.MeasureString(Value2, Font, Width, StringFormat.GenericTypographic);

            PT1 = new PointF(0, Height / 2 - SZ1.Height / 2);
            PT2 = new PointF(SZ1.Width + 1, Height / 2 - SZ1.Height / 2);

            G.DrawString(Value1, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1);
            G.DrawString(Value1, Font, Brushes.WhiteSmoke, PT1);

            G.DrawString(Value2, Font, Brushes.Black, PT2.X + 1, PT2.Y + 1);
            G.DrawString(Value2, Font, B1, PT2);
        }

    }


}


