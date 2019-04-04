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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace Zeroit.Framework.UIThemes.Positron
{
    [DefaultEvent("CheckedChanged")]
    public class PositronRadioButton : ThemeControl154
    {
        private Brush TB;
        private Brush Inside;
        private Pen B;

        private Pen IB;
        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                InvalidateControls();
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }
                Invalidate();
            }
        }

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        private void InvalidateControls()
        {
            if (!IsHandleCreated || !_Checked)
            {
                return;
            }

            foreach (Control C in Parent.Controls)
            {
                if (!object.ReferenceEquals(C, this) && C is PositronRadioButton)
                {
                    ((PositronRadioButton)C).Checked = false;
                }
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (!_Checked)
            {
                Checked = true;
            }
            base.OnMouseDown(e);
        }

        public PositronRadioButton()
        {
            LockHeight = 22;
            Width = 140;
            Size = new Size(150, 22);
            SetColor("Text", Color.FromArgb(100, 100, 100));
            SetColor("Border", Color.FromArgb(175, 175, 175));
            SetColor("IB", Color.FromArgb(200, 200, 200));
            SetColor("B", Color.FromArgb(150, 150, 150));
        }

        protected override void ColorHook()
        {
            TB = GetBrush("Text");
            B = GetPen("B");
            IB = GetPen("IB");
            Inside = GetBrush("Border");
        }

        protected override void PaintHook()
        {
            G.Clear(BackColor);
            G.SmoothingMode = SmoothingMode.AntiAlias;
            if (_Checked)
            {
                G.FillEllipse(TB, new Rectangle(new Point(6, 6), new Size(6, 6)));
            }
            if (State == MouseState.Over)
            {
                if (_Checked)
                {
                }
                else
                {
                    G.FillEllipse(Inside, new Rectangle(new Point(5, 5), new Size(8, 8)));
                }
            }

            G.DrawEllipse(new Pen(Color.FromArgb(125, 125, 125)), new Rectangle(new Point(1, 1), new Size(16, 16)));
            G.DrawEllipse(new Pen(Color.FromArgb(200, 200, 200)), new Rectangle(new Point(0, 0), new Size(18, 18)));

            G.DrawString(Text, Font, TB, 19, 2);
        }
    }
}

