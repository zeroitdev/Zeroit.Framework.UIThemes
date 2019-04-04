// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ListBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.Redemption
{
    public class RedemptionListBox : ListBox
    {
        public RedemptionListBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            DrawMode = DrawMode.OwnerDrawFixed;
            ForeColor = Color.White;
            BackColor = Color.FromArgb(47, 48, 52);
            BorderStyle = BorderStyle.None;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            int Curve = 5;
            base.OnPaint(e);
            G.Clear(Color.Transparent);
            G.FillPath(new SolidBrush(Color.FromArgb(49, 50, 54)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), Curve));
            Color[] GradientPen = {
            Color.FromArgb(43, 44, 48),
            Color.FromArgb(44, 45, 49),
            Color.FromArgb(45, 46, 50),
            Color.FromArgb(46, 47, 51),
            Color.FromArgb(47, 48, 52),
            Color.FromArgb(48, 49, 53)
        };
            for (int i = 0; i <= 5; i++)
            {
                G.DrawPath(new Pen(GradientPen[i]), Draw.RoundRect(new Rectangle(i + 1, i + 1, Width - ((2 * i) + 3), Height - ((2 * i) + 3)), Curve));
            }
            LinearGradientBrush BorderPen = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.Transparent, Color.FromArgb(87, 88, 92), 90);
            G.DrawPath(new Pen(BorderPen), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 1), Curve));
            G.DrawPath(new Pen(Color.FromArgb(32, 33, 37)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), Curve));

        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Graphics G = e.Graphics;
            int Curve = 5;
            G.TextRenderingHint = TextRenderingHint.AntiAlias;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.SetClip(Draw.RoundRect(new Rectangle(0, 0, Width, Height), Curve));
            G.FillRectangle(new SolidBrush(BackColor), new Rectangle(e.Bounds.X, e.Bounds.Y - 1, e.Bounds.Width, e.Bounds.Height + 3));

            if (e.State.ToString().Contains("Selected,"))
            {
                LinearGradientBrush MainBody = new LinearGradientBrush(new Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height), Color.FromArgb(55, 62, 70), Color.FromArgb(43, 44, 48), 90);
                G.FillRectangle(MainBody, new Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height));
                LinearGradientBrush GlossPen = new LinearGradientBrush(new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), Color.FromArgb(100, 93, 98, 104), Color.Transparent, 90);
                G.DrawRectangle(new Pen(GlossPen), new Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height));

            }
            else
            {
                G.FillRectangle(new SolidBrush(BackColor), e.Bounds);
            }

            try
            {
                G.DrawString(Items[e.Index].ToString(), Font, new SolidBrush(Color.FromArgb(100, Color.Black)), new Rectangle(e.Bounds.X + 4, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height), new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Near
                });
                G.DrawString(Items[e.Index].ToString(), Font, new SolidBrush(ForeColor), new Rectangle(e.Bounds.X + 3, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height), new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Near
                });
            }
            catch
            {
            }
            LinearGradientBrush BorderPen = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), Color.Transparent, Color.FromArgb(87, 88, 92), 90);
            G.DrawPath(new Pen(BorderPen), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 2), Curve));
            G.DrawPath(new Pen(Color.FromArgb(32, 33, 37)), Draw.RoundRect(new Rectangle(0, 0, Width - 1, Height - 3), Curve));
        }
    }


}

