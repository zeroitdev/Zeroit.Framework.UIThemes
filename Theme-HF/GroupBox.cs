// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="GroupBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.HF
{
    public class HFxGroupbox : Panel
    {
        Color Bg = Color.Gray;
        Color PC2 = Color.White;
        Color FC = Color.White;
        Pen p;
        SolidBrush sb;
        string _t = "";
        public string Header
        {
            get { return _t; }
            set
            {
                _t = value;
                Invalidate();
            }
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            using (Bitmap b = new Bitmap(Width, Height))
            {
                using (Graphics g = Graphics.FromImage(b))
                {
                    p = new Pen(PC2);
                    sb = new SolidBrush(Bg);
                    SizeF M = g.MeasureString(_t, Font);
                    GraphicsPath Outline = Draw.RoundedRectangle(0, (int)(M.Height / 2), Width - 1, Height - 1, 10, 1);
                    g.Clear(Bg);
                    g.FillRectangle(sb, new Rectangle(0, (int)(M.Height / 2), Width - 1, Height - 1));
                    g.DrawPath(p, Outline);

                    g.FillRectangle(sb, new Rectangle(10, (int)(M.Height / 2) - 2, (int)(M.Width + 10), (int)M.Height));
                    sb = new SolidBrush(FC);
                    g.DrawString(base.Text, base.Font, Brushes.White, 7, 1);
                    e.Graphics.DrawImage(b, 0, 0);
                }
            }
            base.OnPaint(e);
        }
    }

}


