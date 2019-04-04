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
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.XVisual
{

    public class xVisualSeperator : Control
    {

        public enum LineStyle
        {
            Horizontal,
            Vertical
        }
        private LineStyle _Style;
        public LineStyle Style
        {
            get { return _Style; }
            set
            {
                _Style = value;
                Invalidate();
            }
        }

        public xVisualSeperator()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(205, 205, 205);
            _Style = LineStyle.Horizontal;

            Size = new Size(174, 3);

            DoubleBuffered = true;
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            base.OnPaint(e);

            Size = Size;
            _Style = Style;

            G.Clear(BackColor);

            G.SmoothingMode = SmoothingMode.HighQuality;

            switch (_Style)
            {
                case LineStyle.Horizontal:
                    G.DrawLine(Draw.GetPen(Color.Black), 0, 0, Width - 1, Height - 3);
                    G.DrawLine(Draw.GetPen(Color.FromArgb(99, 97, 94)), 0, 1, Width - 1, Height - 2);
                    break;
                case LineStyle.Vertical:
                    G.DrawLine(Draw.GetPen(Color.Black), 0, 0, 0, Height - 1);
                    G.DrawLine(Draw.GetPen(Color.FromArgb(99, 97, 94)), 1, 0, 1, Height - 1);
                    break;
            }

            e.Graphics.DrawImage((Bitmap)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

}

