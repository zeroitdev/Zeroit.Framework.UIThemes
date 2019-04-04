// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="RadioButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
    public class NSRadioButton : Control
    {

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        public NSRadioButton()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            P1 = new Pen(Color.FromArgb(55, 55, 55));
            P2 = new Pen(Color.FromArgb(24, 24, 24));
        }

        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;

                if (_Checked)
                {
                    InvalidateParent();
                }

                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }
                Invalidate();
            }
        }

        private void InvalidateParent()
        {
            if (Parent == null)
                return;

            foreach (Control C in Parent.Controls)
            {
                if ((!object.ReferenceEquals(C, this)) && (C is NSRadioButton))
                {
                    ((NSRadioButton)C).Checked = false;
                }
            }
        }


        private GraphicsPath GP1;
        private SizeF SZ1;

        private PointF PT1;
        private Pen P1;

        private Pen P2;

        private PathGradientBrush PB1;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            ThemeModule theme = new ThemeModule();
            var G = theme.G;

            G = e.Graphics;
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = new GraphicsPath();
            GP1.AddEllipse(0, 2, Height - 5, Height - 5);

            PB1 = new PathGradientBrush(GP1);
            PB1.CenterColor = Color.FromArgb(50, 50, 50);
            PB1.SurroundColors = new Color[] { Color.FromArgb(45, 45, 45) };
            PB1.FocusScales = new PointF(0.3f, 0.3f);

            G.FillPath(PB1, GP1);

            G.DrawEllipse(P1, 0, 2, Height - 5, Height - 5);
            G.DrawEllipse(P2, 1, 3, Height - 7, Height - 7);

            if (_Checked)
            {
                G.FillEllipse(Brushes.Black, 6, 8, Height - 15, Height - 15);
                G.FillEllipse(Brushes.WhiteSmoke, 5, 7, Height - 15, Height - 15);
            }

            SZ1 = G.MeasureString(Text, Font);
            PT1 = new PointF(Height - 3, Height / 2 - SZ1.Height / 2);

            G.DrawString(Text, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1);
            G.DrawString(Text, Font, Brushes.WhiteSmoke, PT1);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Checked = true;
            base.OnMouseDown(e);
        }

    }

}


