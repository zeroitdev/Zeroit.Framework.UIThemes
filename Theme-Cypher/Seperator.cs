// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
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

namespace Zeroit.Framework.UIThemes.Cypher
{
    public class CyperxSeperator : Control
    {
        public CyperxSeperator()
        {
            if (Parent is CypherxTheme)
            {
                var _with8 = (CypherxTheme)Parent;
                BackgroundImage = _with8.BackgroundImage;
            }
        }
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            using (Bitmap b = new Bitmap(Width, Height))
            {
                using (Graphics g = Graphics.FromImage(b))
                {
                    g.Clear(BackColor);

                    Color P1 = Color.FromArgb(29, 25, 22);
                    Color P2 = Color.FromArgb(80, 71, 62);
                    g.FillRectangle(new SolidBrush(Color.FromArgb(25, 18, 12)), new Rectangle(0, 0, Width, Height));
                    if (D)
                        Draw.BackGround(Width, Height, g);

                    Rectangle GRec = new Rectangle(0, Height / 2, Width / 5, 2);
                    using (LinearGradientBrush GBrush = new LinearGradientBrush(GRec, Color.Transparent, P2, LinearGradientMode.Horizontal))
                    {
                        g.FillRectangle(GBrush, GRec);
                    }
                    g.DrawLine(new Pen(P2, 2), new Point(GRec.Width, GRec.Y + 1), new Point(Width - GRec.Width + 1, GRec.Y + 1));

                    GRec = new Rectangle(Width - (Width / 5), Height / 2, Width / 5, 2);
                    using (LinearGradientBrush GBrush = new LinearGradientBrush(GRec, P2, Color.Transparent, LinearGradientMode.Horizontal))
                    {
                        g.FillRectangle(GBrush, GRec);
                    }
                    e.Graphics.DrawImage(b, 0, 0);
                }
            }
            base.OnPaint(e);
        }

        bool D = true;
        public bool DrawPatern
        {
            get { return D; }
            set
            {
                D = value;
                Invalidate();
            }
        }
    }

}
