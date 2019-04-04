// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="CheckBox.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.UIThemes.Hura
{
    [DefaultEvent("CheckedChanged")]
    public class HuraCheckBox : Control
    {

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        public HuraCheckBox()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            P11 = new Pen(Color.FromArgb(50, 50, 50));
            P22 = new Pen(Color.FromArgb(87, 87, 87));
            P3 = new Pen(Color.Black, 2f);
            P4 = new Pen(Color.White, 2f);
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

            Graphics G = e.Graphics;

            G.Clear(Color.FromArgb(40, 40, 40));
            G.SmoothingMode = SmoothingMode.AntiAlias;

            HuraModule hura = new HuraModule();

            GP1 = hura.CreateRound(0, 2, Height - 5, Height - 5, 5);
            GP2 = hura.CreateRound(1, 3, Height - 7, Height - 7, 5);

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
            G.DrawString(Text, Font, Brushes.White, PT1);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Checked = !Checked;
        }

    }

}


