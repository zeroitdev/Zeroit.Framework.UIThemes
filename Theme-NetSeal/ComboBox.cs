// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ComboBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Zeroit.Framework.UIThemes.NeSeal
{
    public class NSComboBox : ComboBox
    {

        public NSComboBox()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;

            BackColor = Color.FromArgb(50, 50, 50);
            ForeColor = Color.FromArgb(235, 235, 235);

            P1 = new Pen(Color.FromArgb(24, 24, 24));
            P2 = new Pen(Color.FromArgb(235, 235, 235), 2f);
            P3 = new Pen(Brushes.Black, 2f);
            P4 = new Pen(Color.FromArgb(65, 65, 65));

            B1 = new SolidBrush(Color.FromArgb(65, 65, 65));
            B2 = new SolidBrush(Color.FromArgb(55, 55, 55));
        }

        private GraphicsPath GP1;

        private GraphicsPath GP2;
        private SizeF SZ1;

        private PointF PT1;
        private Pen P1;
        private Pen P2;
        private Pen P3;
        private Pen P4;
        private SolidBrush B1;

        private SolidBrush B2;

        private LinearGradientBrush GB1;
        protected override void OnPaint(PaintEventArgs e)
        {
            ThemeModule theme = new ThemeModule();
            var G = theme.G;

            G = e.Graphics;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = theme.CreateRound(0, 0, Width - 1, Height - 1, 7);
            GP2 = theme.CreateRound(1, 1, Width - 3, Height - 3, 7);

            GB1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90f);
            G.SetClip(GP1);
            G.FillRectangle(GB1, ClientRectangle);
            G.ResetClip();

            G.DrawPath(P1, GP1);
            G.DrawPath(P4, GP2);

            SZ1 = G.MeasureString(Text, Font);
            PT1 = new PointF(5, Height / 2 - SZ1.Height / 2);

            G.DrawString(Text, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1);
            G.DrawString(Text, Font, Brushes.WhiteSmoke, PT1);

            G.DrawLine(P3, Width - 15, 10, Width - 11, 13);
            G.DrawLine(P3, Width - 7, 10, Width - 11, 13);
            G.DrawLine(Pens.Black, Width - 11, 13, Width - 11, 14);

            G.DrawLine(P2, Width - 16, 9, Width - 12, 12);
            G.DrawLine(P2, Width - 8, 9, Width - 12, 12);
            G.DrawLine(Pens.WhiteSmoke, Width - 12, 12, Width - 12, 13);

            G.DrawLine(P1, Width - 22, 0, Width - 22, Height);
            G.DrawLine(P4, Width - 23, 1, Width - 23, Height - 2);
            G.DrawLine(P4, Width - 21, 1, Width - 21, Height - 2);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(B1, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(B2, e.Bounds);
            }

            if (!(e.Index == -1))
            {
                e.Graphics.DrawString(GetItemText(Items[e.Index]), e.Font, Brushes.WhiteSmoke, e.Bounds);
            }
        }

    }

}


