// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 02-18-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="RadioButton.cs" company="Zeroit Dev Technologies">
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
    public class HuraRadioButton : Control
    {

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        public HuraRadioButton()
        {
            SetStyle((ControlStyles)139286, true);
            SetStyle(ControlStyles.Selectable, false);

            P1 = new Pen(Color.FromArgb(50, 50, 50));
            P2 = new Pen(Color.FromArgb(95, 95, 95));
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
                if ((!object.ReferenceEquals(C, this)) && (C is HuraRadioButton))
                {
                    ((HuraRadioButton)C).Checked = false;
                }
            }
        }


        private GraphicsPath GP1;
        private SizeF SZ1;

        private PointF PT1;
        private Pen P1;

        private Pen P2;


        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Graphics G = e.Graphics;

            G.Clear(Color.FromArgb(40, 40, 40));
            G.SmoothingMode = SmoothingMode.AntiAlias;

            GP1 = new GraphicsPath();
            GP1.AddEllipse(0, 1, Height - 5, Height - 5);

            G.DrawEllipse(P1, 0, 2, Height - 5, Height - 5);
            G.DrawEllipse(P2, 1, 3, Height - 7, Height - 7);

            if (_Checked)
            {
                G.FillEllipse(Brushes.Black, 6, 8, Height - 15, Height - 15);
                G.FillEllipse(Brushes.White, 5, 7, Height - 15, Height - 15);
            }

            SZ1 = G.MeasureString(Text, Font);
            PT1 = new PointF(Height - 3, Height / 2 - SZ1.Height / 2);

            G.DrawString(Text, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1);
            G.DrawString(Text, Font, Brushes.White, PT1);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Checked = true;
            base.OnMouseDown(e);
        }

    }

}


