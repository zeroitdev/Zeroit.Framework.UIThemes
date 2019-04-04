// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
//     Copyright � Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.NeSeal
{
    [DefaultEvent("CheckedChanged")]
    public class NSCheckBox : Control
    {

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        public NSCheckBox()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            P11 = new Pen(Color.FromArgb(55, 55, 55));
            P22 = new Pen(Color.FromArgb(24, 24, 24));
            P3 = new Pen(Color.Black, 2f);
            P4 = new Pen(Color.FromArgb(235, 235, 235), 2f);
        }

        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }

                Invalidate();
            }
        }

        private GraphicsPath GP1;

        private GraphicsPath GP2;
        private SizeF SZ1;

        private PointF PT1;
        private Pen P11;
        private Pen P22;
        private Pen P3;

        private Pen P4;

        private PathGradientBrush PB1;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            ThemeModule theme = new ThemeModule();
            var G = theme.G;

            G = e.Graphics;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = theme.CreateRound(0, 2, Height - 5, Height - 5, 5);
            GP2 = theme.CreateRound(1, 3, Height - 7, Height - 7, 5);

            PB1 = new PathGradientBrush(GP1);
            PB1.CenterColor = Color.FromArgb(50, 50, 50);
            PB1.SurroundColors = new Color[] { Color.FromArgb(45, 45, 45) };
            PB1.FocusScales = new PointF(0.3f, 0.3f);

            G.FillPath(PB1, GP1);
            G.DrawPath(P11, GP1);
            G.DrawPath(P22, GP2);

            if (_Checked)
            {
                G.DrawLine(P3, 5, Height - 9, 8, Height - 7);
                G.DrawLine(P3, 7, Height - 7, Height - 8, 7);

                G.DrawLine(P4, 4, Height - 10, 7, Height - 8);
                G.DrawLine(P4, 6, Height - 8, Height - 9, 6);
            }

            SZ1 = G.MeasureString(Text, Font);
            PT1 = new PointF(Height - 3, Height / 2 - SZ1.Height / 2);

            G.DrawString(Text, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1);
            G.DrawString(Text, Font, Brushes.WhiteSmoke, PT1);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Checked = !Checked;
        }

    }

}

