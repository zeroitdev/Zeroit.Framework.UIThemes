// ***********************************************************************
// Assembly         : Zeroit.Framework.UIThemes
// Author           : ZEROIT
// Created          : 03-17-2019
//
// Last Modified By : ZEROIT
// Last Modified On : 03-17-2019
// ***********************************************************************
// <copyright file="ProgressBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Zeroit.Framework.UIThemes.Bonfire
{
    public class BonfireProgressBar : Control
    {
        private int _Maximum = 100;
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                if (value < _Value)
                {
                    _Value = value;
                }
                _Maximum = value;
                Invalidate();
            }
        }

        private int _Value;
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value > _Maximum)
                {
                    value = Maximum;
                }
                _Value = value;
                Invalidate();
            }
        }

        public BonfireProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
            Size = new Size(100, 40);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics G = e.Graphics;

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.Clear(Parent.BackColor);

            Rectangle mainRect = new Rectangle(0, 0, Width - 1, Height - 1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), mainRect);
            G.DrawLine(new Pen(Color.FromArgb(230, 230, 230)), new Point(mainRect.X, mainRect.Height), new Point(mainRect.Width, mainRect.Height));

            Rectangle barRect = new Rectangle(0, 0, Convert.ToInt32(((Width / _Maximum) * _Value) - 1), Height - 1);
            G.FillRectangle(new SolidBrush(Color.FromArgb(20, 160, 230)), barRect);
            if (_Value > 1)
            {
                G.DrawLine(new Pen(Color.FromArgb(20, 140, 200)), new Point(barRect.X, barRect.Height), new Point(barRect.Width, barRect.Height));
            }

            int textX = 12;
            int textY = (int)(((this.Height - 1) / 2.0) - (G.MeasureString(Text, Font).Height / 2.0));
            float percent = (float)((_Value / (double)_Maximum) * 100);
            string txt = Text + " " + Convert.ToString(percent) + "%";
            G.DrawString(txt, Font, new SolidBrush(Color.FromArgb(120, 120, 120)), new Point(textX + 1, textY + 1));
            G.DrawString(txt, Font, Brushes.White, new Point(textX, textY));

        }

    }
}
